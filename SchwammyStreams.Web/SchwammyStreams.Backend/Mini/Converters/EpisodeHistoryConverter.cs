using SchwammyStreams.Backend.Dto;
using SchwammyStreams.Backend.Model;

namespace SchwammyStreams.Backend.Mini.Converters
{
    public interface IEpisodeHistoryConverter
    {
        ShowHistoryDto ToDto(Episode episode);
        Episode ToDomain(AddEpisodeDto dto);
    }

    public class EpisodeHistoryConverter : IEpisodeHistoryConverter
    {
        public ShowHistoryDto ToDto(Episode episode)
        {
            ShowHistoryDto dto = new ShowHistoryDto();

            dto.Id = episode.Id;
            dto.Title = episode.Title;
            dto.Details = episode.Details;

            return dto;
        }

        public Episode ToDomain(AddEpisodeDto dto)
        {
            Episode episode = new Episode();
            episode.Title = dto.Title;
            episode.Details = dto.Description;

            return episode;
        }
    }
}
