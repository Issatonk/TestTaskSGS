using AutoMapper;
using System.Net.Http.Json;
using TestTaskSGS.Core;
using CbrDaily = TestTaskSGS.Repository.Entity.CbrDaily;

namespace TestTaskSGS.Repository
{
    public class Repository : IRepository
    {
        private readonly IMapper _mapper;
        private CbrDaily _response;
        public Repository(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<Core.Entities.CbrDaily> Get()
        {
            if(_response == null || _response.Timestamp.Date != DateTime.Now.Date || _response.Timestamp.Hour != DateTime.Now.Hour) 
            {
                using (HttpClient client = new HttpClient())
                {
                    _response = await client.GetFromJsonAsync<CbrDaily>("https://www.cbr-xml-daily.ru/daily_json.js");
                }
            }

            return _mapper.Map<Core.Entities.CbrDaily>(_response);
        }
    }
            
}