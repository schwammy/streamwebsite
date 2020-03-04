using SchwammyStreams.Backend.Dto;
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
        public List<string> Validate(AddEpisodeDto dto)
        {
            List<string> results = new List<string>();
            if (string.IsNullOrWhiteSpace(dto.Title))
            {
                results.Add("Title is required");
            }

            return results;
        }
    }
}
