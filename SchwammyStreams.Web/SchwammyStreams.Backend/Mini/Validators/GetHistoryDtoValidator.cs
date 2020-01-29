using SchwammyStreams.Backend.Dto;
using System.Collections.Generic;

namespace SchwammyStreams.Backend.Mini.Validators
{
    public interface IGetHistoryDtoValidator
    {
        List<string> Validate(GetHistoryDto dto);
    }

    public class GetHistoryDtoValidator : IGetHistoryDtoValidator
    {
        public List<string> Validate(GetHistoryDto dto)
        {
            List<string> validationMessages = new List<string>();
            if (dto.PageNumber <= 0)
            {
                validationMessages.Add("Page number must be greater than 0.");
            }

            //temp code
            if (dto.PageSize <= 0)
            {
                validationMessages.Add("Page size must be greater than 0.");
            }


            if (dto.PageSize > 100)
            {
                validationMessages.Add("Page size must be 100 or less.");
            }
            return validationMessages;
        }
    }
}
