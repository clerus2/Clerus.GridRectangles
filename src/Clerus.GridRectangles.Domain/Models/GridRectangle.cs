namespace Clerus.GridRectangles.Domain.Models
{
    public class GridRectangle: Rectangle
    {
        private readonly Coordinate _coordinate;

        public GridRectangle(Coordinate coordinate, int height, int width)
        {
            this.Height = height;
            this.Width = width;
            _coordinate = coordinate;
        }
    }
}
