using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchwammyStreams.Backend.Dto
{
    public class AddEpisodeDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Tags { get; set; }
        public DateTime OriginalAirDate { get; set; }
        public string ArchiveUrl { get; set; }

    }
}
