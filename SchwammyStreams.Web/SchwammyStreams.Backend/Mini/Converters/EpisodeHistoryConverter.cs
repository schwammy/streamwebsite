using SchwammyStreams.Backend.Dto;
using SchwammyStreams.Backend.Model;

namespace SchwammyStreams.Backend.Mini.Converters
{
    public interface IEpisodeHistoryConverter
    {
        EpisodeListItemDto ToDto(Episode episode);
        Episode ToDomain(AddEpisodeDto dto);
        EpisodeDetailDto ToDetailDto(Episode episode);
    }

    public class EpisodeHistoryConverter : IEpisodeHistoryConverter
    {
        public EpisodeListItemDto ToDto(Episode episode)
        {
            EpisodeListItemDto dto = new EpisodeListItemDto()
            {
                Id = episode.Id,
                Title = episode.Title,
                Details = episode.Details,
                ArchiveUrl = episode.ArchiveUrl,
                Tags = episode.Tags
            };

            return dto;
        }

        public Episode ToDomain(AddEpisodeDto dto)
        {
            Episode episode = new Episode();
            episode.Title = dto.Title;
            episode.Details = dto.Description;
            episode.OriginalAirDate = dto.OriginalAirDate;
            episode.Tags = dto.Tags;
            episode.ArchiveUrl = dto.ArchiveUrl;

            return episode;
        }

        public EpisodeDetailDto ToDetailDto(Episode episode)
        {
            EpisodeDetailDto dto = new EpisodeDetailDto();

            dto.Id = episode.Id;
            dto.Title = episode.Title;
            dto.Details = episode.Details;

            return dto;
        }
    }
}
