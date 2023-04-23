using TestTaskSGS.Core.Entities;

namespace TestTaskSGS.Core
{
    public interface IRepository
    {
        Task<CbrDaily> Get(CancellationToken token);
    }
}
