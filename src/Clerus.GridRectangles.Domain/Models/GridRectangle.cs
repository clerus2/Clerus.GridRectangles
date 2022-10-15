namespace Clerus.GridRectangles.Domain.Models
{
    public class GridRectangle: Rectangle
    {
        private readonly Position _position;

        public Position Position { get { return _position; } }

        public GridRectangle(int height, int width, Position position)
        {
            this.Height = height;
            this.Width = width;
            _position = position;
        }
    }
}
