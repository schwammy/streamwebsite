using SchwammyStreams.Backend.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchwammyStreams.Backend.Results
{
    public class GetEpisodeHistoryResult
    {
        public GetEpisodeHistoryResult()
        {
            Results = new List<EpisodeListItemDto>();
            Messages = new List<string>();
            Success = false;
        }
        public bool Success { get; set; }
        public List<EpisodeListItemDto> Results { get; set; }
        public List<string> Messages { get; set; }
    }
}
