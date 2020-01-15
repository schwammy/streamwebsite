using SchwammyStreams.Backend.Dto;
using SchwammyStreams.Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchwammyStreams.Backend.Orchestrators
{
    public class EpisodeHistoryOrchestrator
    {
        public List<ShowHistoryDto> GetHistory()
        {
            List<ShowHistoryDto> results = new List<ShowHistoryDto>();
            //todo: Implement paging too.

            // steps
            // get the data for the shows

            //this is just temp and will be refactored out
            SchwammyStreamsDbContext context = new SchwammyStreamsDbContext();
            //context.Episodes.Add(new Episode { Title = "Test" });
            //context.SaveChanges();

            var history = context.Episodes.ToList();

            // this needs to move out.
            
            foreach(var episode in history)
            {
                results.Add(new ShowHistoryDto { Id = episode.Id, Title = episode.Title, Details = episode.Details });
            };

            // convert the data to dtos
            // return the data

            return results;
        }
    }
}
