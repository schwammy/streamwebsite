using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchwammyStreams.Backend.Results
{
    public class Result
    {
        public Result()
        {
            Messages = new List<string>();
            Success = false;
        }

        public bool Success { get; set; }
        public List<string> Messages { get; set; }
    }

    public class SelectResult<T> : Result
    {
        public List<T> Results { get; set; }
    }

    public class PersistResult<T> : Result
    {
        public T Item { get; set; }
    }

}
