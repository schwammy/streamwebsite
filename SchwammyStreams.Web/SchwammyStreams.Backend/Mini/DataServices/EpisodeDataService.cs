using Microsoft.EntityFrameworkCore;
using SchwammyStreams.Backend.Dto;
using SchwammyStreams.Backend.Mini.Repositories;
using SchwammyStreams.Backend.Model;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SchwammyStreams.Backend.Mini.DataServices
{
    public interface IEpisodeDataService
    {
        IQueryable<Episode> GetEpisodes(GetHistoryDto parameters);
        void AddEpisode(Episode episode);

        Task<Episode> GetEpisodeAsync(int id);
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

        public async Task<Episode> GetEpisodeAsync(int id)
        {
            var result = await _episodeRepository.All().SingleAsync(e => e.Id == id);

            return result;
        }
    }
}
