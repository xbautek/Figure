namespace Figure.Models
{
    public interface IRectangleService
    {
        void Add(Rectangle rectangle);
        void Remove(Rectangle rectangle);
        List<Rectangle> FindAll();
        Rectangle? FindById(int id);




    }
}
