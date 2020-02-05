using SchwammyStreams.Backend.Dto;
using SchwammyStreams.Backend.Mini.Converters;
using SchwammyStreams.Backend.Mini.DataServices;
using SchwammyStreams.Backend.Mini.Validators;
using SchwammyStreams.Backend.Results;
using System.Linq;

namespace SchwammyStreams.Backend.Orchestrators
{
    public interface IEpisodeHistoryOrchestrator
    {
        GetEpisodeHistoryResult GetHistory(GetHistoryDto getHistoryDto);
    }

    public class EpisodeHistoryOrchestrator : IEpisodeHistoryOrchestrator
    {
        private readonly IGetHistoryDtoValidator _getHistoryDtoValidator;
        private readonly IEpisodeDataService _episodeDataService;
        private readonly IEpisodeHistoryConverter _episodeHistoryConverter;
        public EpisodeHistoryOrchestrator(IGetHistoryDtoValidator getHistoryDtoValidator, IEpisodeDataService episodeDataService, IEpisodeHistoryConverter episodeHistoryConverter)
        {
            _getHistoryDtoValidator = getHistoryDtoValidator;
            _episodeDataService = episodeDataService;
            _episodeHistoryConverter = episodeHistoryConverter;
        }

        public GetEpisodeHistoryResult GetHistory(GetHistoryDto getHistoryDto)
        {
            // of course, result object can and will be made generic
            GetEpisodeHistoryResult results = new GetEpisodeHistoryResult();
            //todo: Implement paging too.

            results.Messages = _getHistoryDtoValidator.Validate(getHistoryDto);
            if (results.Messages.Any())
            {
                results.Success = false;
                return results;
            }


            // steps
            // get the data for the shows

            //TODO: add search criteria to dto. Then implement Data Service to call repo.
            var history = _episodeDataService.GetEpisodes(getHistoryDto);

            // this needs to move out.

            foreach (var episode in history)
            {
                results.Results.Add(_episodeHistoryConverter.ToDto(episode));
            };

            // convert the data to dtos
            // return the data

            return results;
        }
    }
}
