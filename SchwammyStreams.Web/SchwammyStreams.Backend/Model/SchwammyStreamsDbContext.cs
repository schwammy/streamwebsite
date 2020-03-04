using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchwammyStreams.Backend.Model
{
    public interface ISchwammyStreamsDbContext
    {
        DbSet<Episode> Episodes { get; set; }
        Task SaveAllAsync(CancellationToken token);

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

        public async Task SaveAllAsync(CancellationToken token = new CancellationToken())
        {
            await SaveChangesAsync(token);
        }

    }
}
