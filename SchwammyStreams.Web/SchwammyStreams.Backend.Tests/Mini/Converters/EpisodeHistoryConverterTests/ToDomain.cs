using SchwammyStreams.Backend.Dto;
using SchwammyStreams.Backend.Mini.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace SchwammyStreams.Backend.Tests.Mini.Converters.EpisodeHistoryConverterTests
{
    public class ToDomain
    {
        [Fact]
        public void GivenAnAddEpisodeDto_ThenAllPropertiesAreMappedToADomainObject()
        {
            AddEpisodeDto dto = new AddEpisodeDto();
            dto.Title = "Title";
            dto.Description = "description";
            dto.ArchiveUrl = "ArchiveUrl";
            dto.Tags = "Tags";
            dto.OriginalAirDate = new DateTime(2020, 1, 1);

            EpisodeHistoryConverter sut = new EpisodeHistoryConverter();

            var domain = sut.ToDomain(dto);

            domain.Title.Should().Be(dto.Title);
            domain.Details.Should().Be(dto.Description);
            domain.ArchiveUrl.Should().Be(dto.ArchiveUrl);
            domain.Tags.Should().Be(dto.Tags);
            domain.OriginalAirDate.Should().Be(dto.OriginalAirDate);


            //use reflection to get all public properties of the dto
            //use reflection to get all public properties of the domain obj
            //then compare

            //asserts

        }
    }
}
