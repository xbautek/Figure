namespace Figure.Models
{
    public class MemoryRectangleService : IRectangleService
    {
        private readonly Dictionary<int, Rectangle> _rectangles = new Dictionary<int, Rectangle>();
        private int id = 1;

        IDateTimeProvider _timeProvider;

        public MemoryRectangleService(IDateTimeProvider dateTimeProvider)
        {
            _timeProvider = dateTimeProvider;
        }

        public void Add(Rectangle rectangle)
        {
            rectangle.Id = id;
            rectangle.Created = _timeProvider.GetCurrentData();
            _rectangles.Add(rectangle.Id, rectangle);
            Console.WriteLine(_rectangles.Count); 
            id++;
        }

        public List<Rectangle> FindAll()
        {
            return _rectangles.Values.ToList();
        }

        public Rectangle? FindById(int id)
        {
            return _rectangles.ContainsKey(id) ? _rectangles[id] : null;
        }

        public void Remove(Rectangle rectangle)
        {
            _rectangles.Remove(rectangle.Id);
        }
    }
}
