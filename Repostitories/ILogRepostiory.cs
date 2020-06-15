using CarsLibraryApi.Models;
using System.Threading.Tasks;

namespace CarsLibraryApi.Repostitories
{
    public interface ILogRepostiory
    {
        Task CreateLog(LogModel log);
        Task<LogModel[]> GetLogs();
    }
}