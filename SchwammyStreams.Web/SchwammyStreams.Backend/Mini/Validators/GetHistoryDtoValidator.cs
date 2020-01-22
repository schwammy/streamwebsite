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
                validationMessages.Add("page number not valid");
            }

            //temp code
            if (dto.PageSize <= 0)
            {
                validationMessages.Add("page size not valid");
            }

            return validationMessages;
        }
    }
}
