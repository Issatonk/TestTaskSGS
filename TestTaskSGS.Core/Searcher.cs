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
            if(string.IsNullOrWhiteSpace(searchRequest)) 
            {
                throw new ArgumentNullException("searchRequest is null");
            }
            searchRequest = searchRequest.ToUpper();
            switch (searchParameter)
            {
                case SearchParameter.SearchById:
                    valute = valutes.Values.Where(x => x.ID == searchRequest).FirstOrDefault();
                    break;
                case SearchParameter.SearchByCharKey:
                    valute = valutes.FirstOrDefault(x => x.Key == searchRequest).Value;
                    break;
            }
            if(valute == null)
            {
                throw new Exception("valute not found");
            }
            return valute;
        }
    }

}
