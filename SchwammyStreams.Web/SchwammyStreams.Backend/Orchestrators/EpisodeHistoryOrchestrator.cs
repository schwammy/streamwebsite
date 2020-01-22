using SchwammyStreams.Backend.Dto;
using SchwammyStreams.Backend.Mini.Repositories;
using SchwammyStreams.Backend.Mini.Validators;
using SchwammyStreams.Backend.Model;
using SchwammyStreams.Backend.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchwammyStreams.Backend.Orchestrators
{
    public interface IEpisodeHistoryOrchestrator
    {
        GetEpisodeHistoryResult GetHistory(GetHistoryDto getHistoryDto);
    }

    public class EpisodeHistoryOrchestrator : IEpisodeHistoryOrchestrator
    {
        private readonly IGetHistoryDtoValidator _getHistoryDtoValidator;
        private readonly IEpisodeRepository _episodeRepository;
        public EpisodeHistoryOrchestrator(IGetHistoryDtoValidator getHistoryDtoValidator, IEpisodeRepository episodeRepository)
        {
            _getHistoryDtoValidator = getHistoryDtoValidator;
            _episodeRepository = episodeRepository;
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


            var history = _episodeRepository.All().ToList();

            // this needs to move out.

            foreach (var episode in history)
            {
                results.Results.Add(new ShowHistoryDto { Id = episode.Id, Title = episode.Title, Details = episode.Details });
            };

            // convert the data to dtos
            // return the data

            return results;
        }
    }
}
