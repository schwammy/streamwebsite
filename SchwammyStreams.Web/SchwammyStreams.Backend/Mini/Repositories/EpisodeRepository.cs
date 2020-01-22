using SchwammyStreams.Backend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchwammyStreams.Backend.Mini.Repositories
{
    public interface IEpisodeRepository
    {
        IQueryable<Episode> All();
    }

    public class EpisodeRepository : IEpisodeRepository
    {
        private readonly ISchwammyStreamsDbContext _schwammyStreamsDbContext;
        public EpisodeRepository(ISchwammyStreamsDbContext schwammyStreamsDbContext)
        {
            _schwammyStreamsDbContext = schwammyStreamsDbContext;
        }
        // get, delete, insertorupdate

        public IQueryable<Episode> All()
        {
            return _schwammyStreamsDbContext.Episodes;
        }
    }
}
