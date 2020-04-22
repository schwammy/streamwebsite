using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using SchwammyStreams.Backend.Dto;
using SchwammyStreams.Backend.Mini.Validators;
using Moq;
using SchwammyStreams.Backend.Helpers;

namespace SchwammyStreams.Backend.Tests.Mini.Validators.AddEpisodeDtoValidatorTests
{
    public class Validate
    {
        [Fact]
        public void GivenAnAirDateInTheFuture_ThenReturnsFailMessage()
        {
            AddEpisodeDto dto = new AddEpisodeDto();
            dto.OriginalAirDate = new DateTime(2020, 2, 1);
            Mock<ICalendar> calendar = new Mock<ICalendar>();
            calendar.Setup(c => c.Now).Returns(dto.OriginalAirDate.AddDays(-1));

            AddEpisodeDtoValidator sut = new AddEpisodeDtoValidator(calendar.Object);

            var messages = sut.Validate(dto);

            messages.Should().Contain("Air Date must be in the past");
        }

        [Fact]
        public void GivenAnAirDateInThePast_ThenReturnsNoMessage()
        {
            AddEpisodeDto dto = new AddEpisodeDto();
            dto.OriginalAirDate = new DateTime(2020, 2, 1);
            Mock<ICalendar> calendar = new Mock<ICalendar>();
            calendar.Setup(c => c.Now).Returns(dto.OriginalAirDate.AddDays(1));

            AddEpisodeDtoValidator sut = new AddEpisodeDtoValidator(calendar.Object);

            var messages = sut.Validate(dto);

            messages.Should().NotContain("Air Date must be in the past");
        }
    }
}
