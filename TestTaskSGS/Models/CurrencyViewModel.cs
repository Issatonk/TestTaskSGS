using TestTaskSGS.Core.Entities;

namespace TestTaskSGS.Models
{
    public class CurrencyViewModel
    {
        public DateTime Date { get; }
        public DateTime Timestamp { get; }
        
        public Valute Valute { get; }

        public CurrencyViewModel(
            DateTime date,
            DateTime timestamp,
            Valute valute
            )
        {
            Date = date;
            Timestamp = timestamp;
            Valute = valute;
        }
    }
}
