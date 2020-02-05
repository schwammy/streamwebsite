using SchwammyStreams.Backend.Dto;
using SchwammyStreams.Backend.Model;

namespace SchwammyStreams.Backend.Mini.Converters
{
    public interface IEpisodeHistoryConverter
    {
        ShowHistoryDto ToDto(Episode episode);
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
    }
}
