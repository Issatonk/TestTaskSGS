using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestTaskSGS.Core.Entities;

namespace TestTaskSGS.Core
{
    public static class Pager
    {
        public static int GetTotalPages(int count, int pageSize)
        {
            return (int)Math.Ceiling((decimal)count / pageSize);
        }
        public static  CbrDaily PaginationMethod(this CbrDaily root, int page, int pageSize)
        {                
            root.Valute = root.Valute
                .Skip(--page * pageSize)
                .Take(pageSize).ToDictionary(k=>k.Key, k=>k.Value);
            return root;
        }
    }
}
