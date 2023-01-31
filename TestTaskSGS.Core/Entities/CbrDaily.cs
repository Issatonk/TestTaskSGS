namespace TestTaskSGS.Core.Entities
{
    public class CbrDaily
    {
        public DateTime Date { get; set; }
        public DateTime Timestamp { get; set; }
        public Dictionary<string, Valute> Valute { get; set; }
    }
}