using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchwammyStreams.Backend.Model
{
    public interface ISchwammyStreamsDbContext
    {
        DbSet<Episode> Episodes { get; set; }
    }

    public class SchwammyStreamsDbContext : DbContext, ISchwammyStreamsDbContext
    {
        public DbSet<Episode> Episodes { get; set; }

        public SchwammyStreamsDbContext() : base()
        {

        }
        public SchwammyStreamsDbContext(DbContextOptions<SchwammyStreamsDbContext> options)
        : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=SchwammyStreams;Trusted_Connection=True");
        }
    }
}
