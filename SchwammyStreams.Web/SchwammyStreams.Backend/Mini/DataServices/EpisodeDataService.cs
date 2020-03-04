using SchwammyStreams.Backend.Dto;
using SchwammyStreams.Backend.Mini.Repositories;
using SchwammyStreams.Backend.Model;
using System;
using System.Linq;

namespace SchwammyStreams.Backend.Mini.DataServices
{
    public interface IEpisodeDataService
    {
        IQueryable<Episode> GetEpisodes(GetHistoryDto parameters);
        void AddEpisode(Episode episode);
    }

    public class EpisodeDataService : IEpisodeDataService
    {
        private readonly IEpisodeRepository _episodeRepository;

        public EpisodeDataService(IEpisodeRepository episodeRepository)
        {
            _episodeRepository = episodeRepository;
        }

        public IQueryable<Episode> GetEpisodes(GetHistoryDto parameters)
        {
            var result = _episodeRepository.All();
            if (!string.IsNullOrWhiteSpace(parameters.SearchCriteria))
                {
                result = result.Where(e => e.Title.Contains(parameters.SearchCriteria, StringComparison.OrdinalIgnoreCase));
            }
            return result;
        }

        public void AddEpisode(Episode episode)
        {
            _episodeRepository.Add(episode);
        }
    }
}
