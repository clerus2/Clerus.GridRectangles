using Clerus.GridRectangles.Core.Interfaces;
using Clerus.GridRectangles.Domain.Models;
using FlareExam.Domain.Models;

namespace Clerus.GridRectangles.Core.Services
{
    public class GridRectangleService : IGridRectangleService
    {
        private readonly Grid _grid;

        public Grid Grid { get { return _grid; } }

        public GridRectangleService(Grid grid)
        {
            _grid = grid;
        }

        public bool AddRectangles(List<GridRectangle> rectangles)
        {
            if (!HasValidGrid()) return false;

            if (rectangles is null || rectangles.Count is 0) return false;

            if (CheckRectanglesIfContainsNegativePosition(rectangles)) return false;

            if (CheckRectanglesXPositionIfBeyondGrid(rectangles)) return false;

            if (CheckRectanglesYPositionIfBeyondGrid(rectangles)) return false;

            _grid.Rectangles.AddRange(rectangles);

            return true;
        }

        public bool HasValidGrid() => _grid.IsValid();

        public bool CheckRectanglesIfContainsNegativePosition(List<GridRectangle> rectangles) => rectangles.Any(a => a.Position.X < 0 || a.Position.Y < 0);

        public bool CheckRectanglesXPositionIfBeyondGrid(List<GridRectangle> rectangles) => rectangles.Any(rectangle => (rectangle.Position.X + rectangle.Width) > Grid.Width);

        public bool CheckRectanglesYPositionIfBeyondGrid(List<GridRectangle> rectangles) => rectangles.Any(rectangle => (rectangle.Position.Y + rectangle.Height) > Grid.Height);
    }
}
