using SchwammyStreams.Backend.Dto;
using SchwammyStreams.Backend.Mini.Converters;
using SchwammyStreams.Backend.Model;
using Xunit;
using FluentAssertions;

namespace SchwammyStreams.Backend.Tests.Mini.Converters.EpisodeHistoryConverterTests
{
    public class ToDto
    {
        [Fact]
        //public void CopiesTitle()
        public void WhenShowHistoryDtoHasATitle_ThenTheTitleIsCopiedToTheEpisode()
        {
            EpisodeHistoryConverter sut = new EpisodeHistoryConverter();
            Episode episode = new Episode();
            episode.Title = "something";
            ShowHistoryDto dto = sut.ToDto(episode);

            dto.Title.Should().Be(episode.Title);
        }

        [Fact]
        public void GivenAnEpisode_WithIsADescription_ThenTheDescriptionIsCopied()
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
