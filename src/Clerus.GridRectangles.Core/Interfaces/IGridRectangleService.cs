using Clerus.GridRectangles.Domain.Models;

namespace Clerus.GridRectangles.Core.Interfaces
{
    public interface IGridRectangleService
    {
        public bool HasValidGrid();

        public bool AddRectangles(List<GridRectangle> rectangles);

        public bool CheckRectanglesIfContainsNegativePosition(List<GridRectangle> rectangles);

        public bool CheckRectanglesXPositionIfBeyondGrid(List<GridRectangle> rectangles);

        public bool CheckRectanglesYPositionIfBeyondGrid(List<GridRectangle> rectangles);

        public GridRectangle? FindGridRectangle(Position position);
    }
}
