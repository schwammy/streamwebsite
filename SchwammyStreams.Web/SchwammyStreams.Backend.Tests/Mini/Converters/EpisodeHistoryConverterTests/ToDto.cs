﻿using SchwammyStreams.Backend.Dto;
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
            EpisodeListItemDto dto = sut.ToDto(episode);

            dto.Title.Should().Be(episode.Title);
        }

        [Fact]
        public void GivenAnEpisode_WithIsADescription_ThenTheDescriptionIsCopied()
        {
            EpisodeHistoryConverter sut = new EpisodeHistoryConverter();
            Episode episode = new Episode();
            episode.Details = "something else";
            EpisodeListItemDto dto = sut.ToDto(episode);

            Assert.Equal(episode.Details, dto.Details);
        }
        [Fact]
        public void CopiesId()
        {
            EpisodeHistoryConverter sut = new EpisodeHistoryConverter();
            Episode episode = new Episode();
            episode.Id = 78438;
            EpisodeListItemDto dto = sut.ToDto(episode);

            Assert.Equal(episode.Id, dto.Id);
        }

        [Fact]
        public void GivenAnEpisode_WithTags_ThenTagsIsCopied()
        {
            EpisodeHistoryConverter sut = new EpisodeHistoryConverter();
            Episode episode = new Episode();
            episode.Tags = "one, two, three";
            EpisodeListItemDto dto = sut.ToDto(episode);

            dto.Tags.Should().Be(episode.Tags);
        }
    }
}
