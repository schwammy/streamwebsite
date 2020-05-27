using System;
using System.Collections.Generic;
using System.Text;

namespace SchwammyStreams.Backend.Dto
{
    public class EpisodeListItemDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string Tags { get; set; }
        public string ArchiveUrl { get; set; }
    }
}
