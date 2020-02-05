using SchwammyStreams.Backend.Dto;
using SchwammyStreams.Backend.Mini.Converters;
using SchwammyStreams.Backend.Model;
using Xunit;

namespace SchwammyStreams.Backend.Tests.Mini.Converters.EpisodeHistoryConverterTests
{
    public class ToDto
    {
        [Fact]
        public void CopiesTitle()
        {
            EpisodeHistoryConverter sut = new EpisodeHistoryConverter();
            Episode episode = new Episode();
            episode.Title = "something";
            ShowHistoryDto dto = sut.ToDto(episode);

            Assert.Equal(episode.Title, dto.Title);
        }

        [Fact]
        public void CopiesDetails()
        {
            EpisodeHistoryConverter sut = new EpisodeHistoryConverter();
            Episode episode = new Episode();
            episode.Details = "something else";
            ShowHistoryDto dto = sut.ToDto(episode);

            Assert.Equal(episode.Details, dto.Details);
        }
        [Fact]
        public void CopiesId()
        {
            EpisodeHistoryConverter sut = new EpisodeHistoryConverter();
            Episode episode = new Episode();
            episode.Id = 78438;
            ShowHistoryDto dto = sut.ToDto(episode);

            Assert.Equal(episode.Id, dto.Id);
        }


    }
}
