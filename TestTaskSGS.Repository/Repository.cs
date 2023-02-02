using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using System.Net.Http.Json;
using TestTaskSGS.Core;
using CbrDaily = TestTaskSGS.Repository.Entity.CbrDaily;

namespace TestTaskSGS.Repository
{
    public class Repository : IRepository
    {
        private readonly IMapper _mapper;
        private IMemoryCache _memoryCache;
        public Repository(IMapper mapper, IMemoryCache memoryCache)
        {
            _mapper = mapper;
            _memoryCache = memoryCache;
        }
        public async Task<Core.Entities.CbrDaily> Get()
        {

            _memoryCache.TryGetValue(DateTime.Now.Date, out CbrDaily? cbrDaily);

            try
            {
                if (cbrDaily == null)
                {
                    using (HttpClient client = new HttpClient())
                    {
                        cbrDaily = await client.GetFromJsonAsync<CbrDaily>("https://www.cbr-xml-daily.ru/daily_json.js");
                        _memoryCache.Set(DateTime.Now.Date, cbrDaily, new MemoryCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1)});
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            

            return _mapper.Map<Core.Entities.CbrDaily>(cbrDaily);
        }
    }
            
}