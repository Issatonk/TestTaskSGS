using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskSGS.Core.Entities;

namespace TestTaskSGS.Core
{
    public interface IRepository
    {
        Task<CbrDaily> Get();
    }
}
