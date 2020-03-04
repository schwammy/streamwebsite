using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchwammyStreams.Backend.Model
{
    public interface IUnitOfWork
    {
        Task SaveAllAsync(CancellationToken token);
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly ISchwammyStreamsDbContext _schwammyStreamsDbContext;
        public UnitOfWork(ISchwammyStreamsDbContext schwammyStreamsDbContext)
        {
            _schwammyStreamsDbContext = schwammyStreamsDbContext;
        }

        public async Task SaveAllAsync(CancellationToken token)
        {
            await _schwammyStreamsDbContext.SaveAllAsync(token);
        }

    }
}
