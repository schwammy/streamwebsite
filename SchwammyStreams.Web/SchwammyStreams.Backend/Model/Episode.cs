using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SchwammyStreams.Backend.Model
{
    public class Episode
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string ArchiveUrl { get; set; }
        public string Tags { get; set; }
        public DateTime AirDate { get; set; }
        //public string CreatedBy { get; set; }
        //public string UpdatedBy { get; set; }
        //public DateTime CreateDate { get; set; }
        //public DateTime? UpdateDate { get; set; }

    }
}
