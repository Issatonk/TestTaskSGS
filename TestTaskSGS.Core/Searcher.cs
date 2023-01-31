using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Runtime.CompilerServices;
using TestTaskSGS.Core.Entities;

namespace TestTaskSGS.Core
{
    public enum SearchParameter
    {
        SearchByCharKey = 0,
        SearchById = 1,
    }
    public static class Searcher
    {
        public static Valute Search(
            this Dictionary<string, Valute> valutes, 
            string searchRequest, 
            SearchParameter searchParameter = SearchParameter.SearchById)
        {
            Valute valute = null;

            switch (searchParameter)
            {
                case SearchParameter.SearchById:
                    valute = valutes.Values.Where(x => x.ID == searchRequest).FirstOrDefault();
                    break;
                case SearchParameter.SearchByCharKey:
                    valute = valutes.FirstOrDefault(x => x.Key == searchRequest.ToUpper()).Value;
                    break;
            }
            return valute;
        }
    }

}
