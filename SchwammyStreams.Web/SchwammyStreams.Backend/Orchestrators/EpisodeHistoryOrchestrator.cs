using SchwammyStreams.Backend.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchwammyStreams.Backend.Orchestrators
{
    public class EpisodeHistoryOrchestrator
    {
        public void GetHistory()
        {
            //todo: Implement paging too.

            // steps
            // get the data for the shows

            //this is just temp and will be refactored out
            SchwammyStreamsDbContext context = new SchwammyStreamsDbContext();
            context.Episodes.Add(new Episode { Title = "Test" });
            context.SaveChanges();

            // convert the data to dtos
            // return the data

        }
    }
}
