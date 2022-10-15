namespace FlareExam.Domain
{
    public class Grid
    {
        private readonly int minHeightWidth = 5;
        private readonly int maxHeightWidth = 25;
        private readonly int _height;
        private readonly int _width;

        public int Height { get { return _height; } }

        public int Width { get { return _width; } }

        public Grid(int height, int width)
        {
            _height = height;
            _width = width;
        }
        public bool IsValid() => ValidateHeight() && ValidateWidth();
        
        private bool ValidateHeight() => _height >= minHeightWidth && _height <= maxHeightWidth;

        private bool ValidateWidth() => _width >= minHeightWidth && _width <= maxHeightWidth;

    }
}