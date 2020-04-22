using SchwammyStreams.Backend.Dto;
using SchwammyStreams.Backend.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchwammyStreams.Backend.Mini.Validators
{
    public interface IAddEpisodeDtoValidator
    {
        List<string> Validate(AddEpisodeDto dto);
    }

    public class AddEpisodeDtoValidator : IAddEpisodeDtoValidator
    {
        private readonly ICalendar _calendar;

        public AddEpisodeDtoValidator(ICalendar calendar)
        {
            _calendar = calendar;
        }

        public List<string> Validate(AddEpisodeDto dto)
        {
            List<string> results = new List<string>();
            if (string.IsNullOrWhiteSpace(dto.Title))
            {
                results.Add("Title is required");
            }
            if (dto.OriginalAirDate > _calendar.Now)
            {
                results.Add("Air Date must be in the past");
            }

            return results;
        }
    }
}
