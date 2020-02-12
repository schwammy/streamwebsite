using Moq;
using SchwammyStreams.Backend.Dto;
using SchwammyStreams.Backend.Mini.Converters;
using SchwammyStreams.Backend.Mini.DataServices;
using SchwammyStreams.Backend.Mini.Validators;
using SchwammyStreams.Backend.Model;
using SchwammyStreams.Backend.Orchestrators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace SchwammyStreams.Backend.Tests.Orchestrator.EpisodeHistoryOrchestratorTests
{
    public class GetHistoryTests
    {
        Mock<IGetHistoryDtoValidator> _getHistoryDtoValidator = new Mock<IGetHistoryDtoValidator>();
        Mock<IEpisodeDataService> _episodeDataService = new Mock<IEpisodeDataService>();
        Mock<IEpisodeHistoryConverter> _episodeHistoryConverter = new Mock<IEpisodeHistoryConverter>();
        EpisodeHistoryOrchestrator _sut;

        public GetHistoryTests()
        {

            _sut = new EpisodeHistoryOrchestrator(
                _getHistoryDtoValidator.Object,
                _episodeDataService.Object,
                _episodeHistoryConverter.Object);

        }
        /*
             * what do we want to test
             * does the validator get called?
             * Does the validator get the right args
             * if results of validation fail, does it return success = false
             * does getepisodes get called?
             */

        //private readonly IGetHistoryDtoValidator _getHistoryDtoValidator;
        //private readonly IEpisodeDataService _episodeDataService;
        //private readonly IEpisodeHistoryConverter _episodeHistoryConverter;


        [Fact]
        public void CallsGetHistoryDtoValidatorOnce() //WhenCheckingHistory_ThenCallsGetHistoryValidator
        {
            Mock<IGetHistoryDtoValidator> getHistoryDtoValidator = new Mock<IGetHistoryDtoValidator>();
            Mock<IEpisodeDataService> episodeDataService = new Mock<IEpisodeDataService>();
            Mock<IEpisodeHistoryConverter> episodeHistoryConverter = new Mock<IEpisodeHistoryConverter>();

            EpisodeHistoryOrchestrator sut = new EpisodeHistoryOrchestrator(
                getHistoryDtoValidator.Object,
                episodeDataService.Object,
                episodeHistoryConverter.Object);


            getHistoryDtoValidator.Setup(v => v.Validate(It.IsAny<GetHistoryDto>())).Returns(new List<string>());


            var dto = new GetHistoryDto();

            sut.GetHistory(dto);

            getHistoryDtoValidator.Verify(v => v.Validate(dto), Times.Once);
            getHistoryDtoValidator.Verify(v => v.Validate(It.IsAny<GetHistoryDto>()),Times.Once);
        }

        [Fact]
        public void ReturnsSuccessEqualsFalseWhenValidationFails() //WhenCheckingHistory_ThenCallsGetHistoryValidator
        {
            Mock<IGetHistoryDtoValidator> getHistoryDtoValidator = new Mock<IGetHistoryDtoValidator>();
            Mock<IEpisodeDataService> episodeDataService = new Mock<IEpisodeDataService>();
            Mock<IEpisodeHistoryConverter> episodeHistoryConverter = new Mock<IEpisodeHistoryConverter>();

            EpisodeHistoryOrchestrator sut = new EpisodeHistoryOrchestrator(
                getHistoryDtoValidator.Object,
                episodeDataService.Object,
                episodeHistoryConverter.Object);

            var messages = new List<string>();
            messages.Add("FailedValidation");
            getHistoryDtoValidator.Setup(v => v.Validate(It.IsAny<GetHistoryDto>())).Returns(messages);

            var dto = new GetHistoryDto();

            var result = sut.GetHistory(dto);

            Assert.False(result.Success);
        }

        //[Fact]
        //public void ReturnsSuccessEqualsTrueWhenAllIsWell() 
        //{
        //    Mock<IGetHistoryDtoValidator> getHistoryDtoValidator = new Mock<IGetHistoryDtoValidator>();
        //    Mock<IEpisodeDataService> episodeDataService = new Mock<IEpisodeDataService>();
        //    Mock<IEpisodeHistoryConverter> episodeHistoryConverter = new Mock<IEpisodeHistoryConverter>();

        //    EpisodeHistoryOrchestrator sut = new EpisodeHistoryOrchestrator(
        //        getHistoryDtoValidator.Object,
        //        episodeDataService.Object,
        //        episodeHistoryConverter.Object);

        //    var messages = new List<string>();
        //    //messages.Add("FailedValidation");
        //    getHistoryDtoValidator.Setup(v => v.Validate(It.IsAny<GetHistoryDto>())).Returns(messages);

        //    var dto = new GetHistoryDto();

        //    var result = sut.GetHistory(dto);

        //    Assert.True(result.Success);
        //}

        [Fact]
        public void ReturnsValidationMessagesIfAny() 
        {
            Mock<IGetHistoryDtoValidator> getHistoryDtoValidator = new Mock<IGetHistoryDtoValidator>();
            Mock<IEpisodeDataService> episodeDataService = new Mock<IEpisodeDataService>();
            Mock<IEpisodeHistoryConverter> episodeHistoryConverter = new Mock<IEpisodeHistoryConverter>();

            EpisodeHistoryOrchestrator sut = new EpisodeHistoryOrchestrator(
                getHistoryDtoValidator.Object,
                episodeDataService.Object,
                episodeHistoryConverter.Object);

            var messages = new List<string>();
            messages.Add("FailedValidation");

            getHistoryDtoValidator.Setup(v => v.Validate(It.IsAny<GetHistoryDto>())).Returns(messages);

            var dto = new GetHistoryDto();

            var result = sut.GetHistory(dto);

            Assert.Contains("FailedValidation", result.Messages);
        }

        [Fact]
        public void ReturnsNoValidationMessagesWhenNoneExist()
        {
            Mock<IGetHistoryDtoValidator> getHistoryDtoValidator = new Mock<IGetHistoryDtoValidator>();
            Mock<IEpisodeDataService> episodeDataService = new Mock<IEpisodeDataService>();
            Mock<IEpisodeHistoryConverter> episodeHistoryConverter = new Mock<IEpisodeHistoryConverter>();

            EpisodeHistoryOrchestrator sut = new EpisodeHistoryOrchestrator(
                getHistoryDtoValidator.Object,
                episodeDataService.Object,
                episodeHistoryConverter.Object);

            var messages = new List<string>();

            getHistoryDtoValidator.Setup(v => v.Validate(It.IsAny<GetHistoryDto>())).Returns(messages);

            var dto = new GetHistoryDto();

            var result = sut.GetHistory(dto);

            Assert.Empty(result.Messages);
        }

        [Fact]
        public void DoesNotCallDataServiceIfValidationFails()
        {

            var messages = new List<string>();
            messages.Add("FailedValidation");

            _getHistoryDtoValidator.Setup(v => v.Validate(It.IsAny<GetHistoryDto>())).Returns(messages);

            var dto = new GetHistoryDto();

            var result = _sut.GetHistory(dto);

            _episodeDataService.Verify(ds => ds.GetEpisodes(dto), Times.Never);
        }

        [Fact]
        public void CallsDataServiceGetEpisodesWithCorrectArguments()
        {

            var messages = new List<string>();
            //messages.Add("FailedValidation");

            _getHistoryDtoValidator.Setup(v => v.Validate(It.IsAny<GetHistoryDto>())).Returns(messages);

            var dto = new GetHistoryDto();

            var result = _sut.GetHistory(dto);

            _episodeDataService.Verify(ds => ds.GetEpisodes(dto), Times.Once);
        }

        [Fact]
        public void CallsConverterNeverIfNoDataExists()
        {

            var messages = new List<string>();

            var data = new List<Episode>();
            
            _episodeDataService.Setup(ds => ds.GetEpisodes(It.IsAny<GetHistoryDto>())).Returns(data.AsQueryable());
            _getHistoryDtoValidator.Setup(v => v.Validate(It.IsAny<GetHistoryDto>())).Returns(messages);

            var dto = new GetHistoryDto();

            var result = _sut.GetHistory(dto);

            _episodeHistoryConverter.Verify(c =>c.ToDto(It.IsAny<Episode>()), Times.Never);
        }

        [Fact]
        public void CallsConverterOnceForSingleResult()
        {

            var messages = new List<string>();

            var data = new List<Episode>();
            data.Add(new Episode());
            _episodeDataService.Setup(ds => ds.GetEpisodes(It.IsAny<GetHistoryDto>())).Returns(data.AsQueryable());
            _getHistoryDtoValidator.Setup(v => v.Validate(It.IsAny<GetHistoryDto>())).Returns(messages);

            var dto = new GetHistoryDto();

            var result = _sut.GetHistory(dto);

            _episodeHistoryConverter.Verify(c => c.ToDto(It.IsAny<Episode>()), Times.Once);
        }

        [Fact]
        public void CallsConverterForEachResult()
        {

            var messages = new List<string>();

            var data = new List<Episode>();
            data.Add(new Episode());
            data.Add(new Episode());
            data.Add(new Episode());
            data.Add(new Episode());
            data.Add(new Episode());
            data.Add(new Episode());
            data.Add(new Episode());
            data.Add(new Episode());
            data.Add(new Episode());

            _episodeDataService.Setup(ds => ds.GetEpisodes(It.IsAny<GetHistoryDto>())).Returns(data.AsQueryable());
            _getHistoryDtoValidator.Setup(v => v.Validate(It.IsAny<GetHistoryDto>())).Returns(messages);

            var dto = new GetHistoryDto();

            var result = _sut.GetHistory(dto);

            _episodeHistoryConverter.Verify(c => c.ToDto(It.IsAny<Episode>()), Times.Exactly(data.Count));
        }

    }
}
