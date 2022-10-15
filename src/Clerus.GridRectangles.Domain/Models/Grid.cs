using Clerus.GridRectangles.Domain.Interfaces;
using Clerus.GridRectangles.Domain.Models;

namespace FlareExam.Domain.Models
{
    public class Grid
    {
        private readonly int minHeightWidth = 5;
        private readonly int maxHeightWidth = 25;
        private readonly int _height;
        private readonly int _width;

        public int Height { get { return _height; } }

        public int Width { get { return _width; } }

        public List<GridRectangle> Rectangles { get; set; }

        public Grid(int height, int width)
        {
            _height = height;
            _width = width;
            Rectangles = new List<GridRectangle>();
        }

        public bool IsValid() => ValidateHeight() && ValidateWidth();
        
        private bool ValidateHeight() => _height >= minHeightWidth && _height <= maxHeightWidth;

        private bool ValidateWidth() => _width >= minHeightWidth && _width <= maxHeightWidth;

    }
}