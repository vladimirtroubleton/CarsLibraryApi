using CarsLibraryApi.Context;
using CarsLibraryApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsLibraryApi.Repostitories
{
    public class LogRepostiory : ILogRepostiory
    {
        private LogContext context;
        object glush = new object();
        public LogRepostiory(LogContext context)
        {
            this.context = context;
        }

        public async Task CreateLog(LogModel log)
        {
            lock (glush)
            {
                context.Logs.Add(log);
            };
            await context.SaveChangesAsync();
        }

        public Task<LogModel[]> GetLogs()
        {
            return Task.FromResult(context.Logs.ToArray());
        }



    }
}
