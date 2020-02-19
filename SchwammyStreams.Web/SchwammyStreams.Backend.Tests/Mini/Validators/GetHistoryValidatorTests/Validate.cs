using SchwammyStreams.Backend.Dto;
using SchwammyStreams.Backend.Mini.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FluentAssertions;

namespace SchwammyStreams.Backend.Tests.Mini.Validators.GetHistoryValidatorTests
{
    public class Validate
    {
        [Fact]
        public void IfPageNumberGreaterThanZeroReturnsNoMessage()
        {
            //arrange
            //act
            //assert

            GetHistoryDtoValidator sut = new GetHistoryDtoValidator();
            GetHistoryDto dto = new GetHistoryDto();
            dto.PageNumber = 5;
            var results = sut.Validate(dto);

            results.Should().NotContain("Page number must be greater than 0.");
        }

        [Fact]
        public void IfPageSizeGreaterThanZeroReturnsNoMessage()
        {
            GetHistoryDtoValidator sut = new GetHistoryDtoValidator();
            GetHistoryDto dto = new GetHistoryDto();
            dto.PageSize = 55;
            var results = sut.Validate(dto);

            Assert.DoesNotContain("Page size must be greater than 0.", results);

        }

        [Fact]
        public void PageSizeZeroReturnsMessage()
        {
            GetHistoryDtoValidator sut = new GetHistoryDtoValidator();
            GetHistoryDto dto = new GetHistoryDto();
            dto.PageSize = 0;
            var results = sut.Validate(dto);

            results.Should().Contain("Page size must be greater than 0.");
        }

        [Fact]
        public void PageNumberZeroReturnsMessage()
        {
            GetHistoryDtoValidator sut = new GetHistoryDtoValidator();
            GetHistoryDto dto = new GetHistoryDto();
            dto.PageNumber = 0;
            var results = sut.Validate(dto);

            Assert.Contains("Page number must be greater than 0.", results);
        }

        [Fact]
        public void IfPageSizeGreaterThan100ReturnsMessage()
        {
            GetHistoryDtoValidator sut = new GetHistoryDtoValidator();
            GetHistoryDto dto = new GetHistoryDto();
            dto.PageSize = 101;
            var results = sut.Validate(dto);

            Assert.Contains("Page size must be 100 or less.", results);

        }

        [Fact]
        public void IfPageSize100ReturnsNoMessage()
        {
            GetHistoryDtoValidator sut = new GetHistoryDtoValidator();
            GetHistoryDto dto = new GetHistoryDto();
            dto.PageSize = 100;
            var results = sut.Validate(dto);

            Assert.DoesNotContain("Page size must be 100 or less.", results);

        }

        [Fact]
        public void IfSearchCriteriaIsNullReturnAMessage()
        {
            GetHistoryDtoValidator sut = new GetHistoryDtoValidator();
            GetHistoryDto dto = new GetHistoryDto();
            var results = sut.Validate(dto);

            Assert.Contains("Search Criteria cannot be null.", results);
        }

        [Fact]
        public void IfSearchCriteriaIsNotNullReturnNoMessage()
        {
            GetHistoryDtoValidator sut = new GetHistoryDtoValidator();
            GetHistoryDto dto = new GetHistoryDto();
            dto.SearchCriteria = "foo";

            var results = sut.Validate(dto);

            Assert.DoesNotContain("Search Criteria cannot be null.", results);
        }

    }
}
