using TestTaskSGS.Core.Entities;

namespace TestTaskSGS.Models
{
    public class CurrenciesViewModel
    {
        public DateTime Date { get;}
        public DateTime Timestamp { get;}
        public int TotalPages { get;}
        public int CurrentPage { get; }

        public int PageSize { get; }

        public Dictionary<string, Valute> Valutes { get;}

        public CurrenciesViewModel(
            DateTime date,
            DateTime timestamp,
            Dictionary<string, Valute> valutes,
            int totalPages,
            int currentPage,
            int pageSize)

        {
            Date = date;
            Timestamp = timestamp;
            Valutes = valutes;
            TotalPages = totalPages;
            CurrentPage = currentPage;
            PageSize = pageSize;
        }
    }
}
