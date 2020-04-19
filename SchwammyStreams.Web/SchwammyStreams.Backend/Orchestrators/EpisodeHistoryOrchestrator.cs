using Microsoft.EntityFrameworkCore;
using SchwammyStreams.Backend.Dto;
using SchwammyStreams.Backend.Mini.Converters;
using SchwammyStreams.Backend.Mini.DataServices;
using SchwammyStreams.Backend.Mini.Validators;
using SchwammyStreams.Backend.Model;
using SchwammyStreams.Backend.Results;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchwammyStreams.Backend.Orchestrators
{
    public interface IEpisodeHistoryOrchestrator
    {
        Task<GetEpisodeHistoryResult> GetHistoryAsync(GetHistoryArgsDto getHistoryDto);
        Task<PersistResult<AddEpisodeDto>> AddEpisodeAsync(AddEpisodeDto episode);

        Task<SelectResult<EpisodeDetailDto>> GetEpisodeDetailAsync(int id);
    }

    public class EpisodeHistoryOrchestrator : IEpisodeHistoryOrchestrator
    {
        private readonly IGetHistoryDtoValidator _getHistoryDtoValidator;
        private readonly IEpisodeDataService _episodeDataService;
        private readonly IEpisodeHistoryConverter _episodeHistoryConverter;
        private readonly IAddEpisodeDtoValidator _addEpisodeDtoValidator;
        private readonly IUnitOfWork _unitOfWork;
        public EpisodeHistoryOrchestrator(IGetHistoryDtoValidator getHistoryDtoValidator, 
            IEpisodeDataService episodeDataService, 
            IEpisodeHistoryConverter episodeHistoryConverter,
            IAddEpisodeDtoValidator addEpisodeDtoValidator,
            IUnitOfWork unitOfWork
            )
        {
            _getHistoryDtoValidator = getHistoryDtoValidator;
            _episodeDataService = episodeDataService;
            _episodeHistoryConverter = episodeHistoryConverter;
            _addEpisodeDtoValidator = addEpisodeDtoValidator;
            _unitOfWork = unitOfWork;
        }


        public async Task<SelectResult<EpisodeDetailDto>> GetEpisodeDetailAsync(int id)
        {
            SelectResult<EpisodeDetailDto> result = new SelectResult<EpisodeDetailDto>();

            var item = await _episodeDataService.GetEpisodeAsync(id);

            result.Item = _episodeHistoryConverter.ToDetailDto(item);

            return result;
        }
        public async Task<PersistResult<AddEpisodeDto>> AddEpisodeAsync(AddEpisodeDto episode)
        {
            PersistResult<AddEpisodeDto> result = new PersistResult<AddEpisodeDto>();
            //validate
            var messages = _addEpisodeDtoValidator.Validate(episode);
            if (messages.Any())
            {
                result.Messages.AddRange(messages);
                result.Success = false;
                return result;
            }

            //convert it
            var entity = _episodeHistoryConverter.ToDomain(episode);

            // add it
            _episodeDataService.AddEpisode(entity);

            // commit it
            await _unitOfWork.SaveAllAsync(new CancellationToken());

            return result;
        }

        public async Task<GetEpisodeHistoryResult> GetHistoryAsync(GetHistoryArgsDto getHistoryArgs)
        {
            


            // of course, result object can and will be made generic
            GetEpisodeHistoryResult results = new GetEpisodeHistoryResult();
            //todo: Implement paging too.

            results.Messages = _getHistoryDtoValidator.Validate(getHistoryArgs);
            if (results.Messages.Any())
            {
                results.Success = false;
                return results;
            }

            // steps
            // get the data for the shows

            //TODO: add search criteria to dto. Then implement Data Service to call repo.
            var history = _episodeDataService.GetEpisodes(getHistoryArgs);

            // this needs to move out.

            foreach (var episode in await history.ToListAsync())
            {
                results.Results.Add(_episodeHistoryConverter.ToDto(episode));
            };

            // convert the data to dtos
            // return the data
            results.Success = true;
            return results;
        }
    }
}
