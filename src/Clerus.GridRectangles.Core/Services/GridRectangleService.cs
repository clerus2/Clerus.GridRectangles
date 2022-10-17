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

            if (CheckRectangleOverlap(rectangles)) return false;

            _grid.Rectangles.AddRange(rectangles);

            return true;
        }

        public bool HasValidGrid() => _grid.IsValid();

        public bool CheckRectanglesIfContainsNegativePosition(List<GridRectangle> rectangles) => rectangles.Any(a => a.Position.X < 0 || a.Position.Y < 0);

        public bool CheckRectanglesXPositionIfBeyondGrid(List<GridRectangle> rectangles) => rectangles.Any(rectangle => (rectangle.Position.X + rectangle.Width) > Grid.Width);

        public bool CheckRectanglesYPositionIfBeyondGrid(List<GridRectangle> rectangles) => rectangles.Any(rectangle => (rectangle.Position.Y + rectangle.Height) > Grid.Height);

        public GridRectangle? FindGridRectangle(Position position) => _grid.Rectangles?.Where(a => a.Position?.X == position.X && a.Position?.Y == position.Y).FirstOrDefault();

        public void RemoveGridRectangle(Position position) =>
            _grid.Rectangles.RemoveAll(a =>
                (position.X >= a.Position.X) &&
                (position.X <= (a.Position.X + a.Width)) &&
                (position.Y >= a.Position.Y) &&
                (position.Y <= (a.Position.Y + a.Height)));

        public bool CheckRectangleOverlap(List<GridRectangle> rectangles)
        {
            var hasOverlap = false;
            var compareRectangles = new List<GridRectangle>(rectangles);

            foreach (var rectangle in rectangles)
            {
                int index = rectangles.IndexOf(rectangle);

                foreach (var compareRectangle in compareRectangles)
                {
                    int compareIndex = compareRectangles.IndexOf(compareRectangle);
                    if (index == compareIndex) continue;

                    var overlapOnRight = CheckRectangleOverlapOnRight(compareRectangle, rectangle);
                    var overlapOnLeft = CheckRectangleOverlapOnLeft(compareRectangle, rectangle);

                    hasOverlap = overlapOnRight || overlapOnLeft;

                    if (hasOverlap) break;
                }
                if (hasOverlap) break;
            }
            return hasOverlap;
        }

        private int GetRectangleMaxAxisDimension(int axis, int dimension) => axis + dimension;

        private bool CheckRectangleOverlapOnRight(GridRectangle compareRectangle, GridRectangle fromRectangle)
        {
            var compareRectangleXMax = GetRectangleMaxAxisDimension(compareRectangle.Position.X, compareRectangle.Width);
            var compareRectangleYMax = GetRectangleMaxAxisDimension(compareRectangle.Position.Y, compareRectangle.Height);

            var fromRectangleXMax = GetRectangleMaxAxisDimension(fromRectangle.Position.X, fromRectangle.Width);
            var fromRectangleYMax = GetRectangleMaxAxisDimension(fromRectangle.Position.Y, fromRectangle.Height);

            var sumX = compareRectangleXMax + fromRectangleXMax;
            var sumY = compareRectangleYMax + fromRectangleYMax;

            if (compareRectangleYMax <= fromRectangle.Position.Y ||
                compareRectangle.Position.X >= fromRectangleXMax ||
                compareRectangleXMax <= fromRectangle.Position.X)
            {
                return false;
            }

            if (compareRectangleXMax >= fromRectangle.Position.X &&
                compareRectangleXMax <= fromRectangleXMax &&
                compareRectangleYMax >= fromRectangle.Position.Y &&
                compareRectangleYMax <= fromRectangleYMax)
            {
                return true;
            }

            return false;
        }

        private bool CheckRectangleOverlapOnLeft(GridRectangle compareRectangle, GridRectangle fromRectangle)
        {
            var compareRectangleYMax = GetRectangleMaxAxisDimension(compareRectangle.Position.Y, compareRectangle.Height);

            var fromRectangleXMax = GetRectangleMaxAxisDimension(fromRectangle.Position.X, fromRectangle.Width);
            var fromRectangleYMax = GetRectangleMaxAxisDimension(fromRectangle.Position.Y, fromRectangle.Height);

            if (compareRectangleYMax <= fromRectangle.Position.Y ||
                compareRectangle.Position.X >= fromRectangleXMax)
            {
                return false;
            }

            if (compareRectangle.Position.X >= fromRectangle.Position.X &&
                compareRectangle.Position.X <= fromRectangleXMax &&
                compareRectangleYMax >= fromRectangle.Position.Y &&
                compareRectangleYMax <= fromRectangleYMax)
            {
                return true;
            }

            return false;
        }
    }
}
