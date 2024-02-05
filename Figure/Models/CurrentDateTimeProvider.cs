namespace Figure.Models
{
    public class CurrentDateTimeProvider : IDateTimeProvider
    {
        public DateTime GetCurrentData()
        {
            return DateTime.Now;
        }
    }
}
