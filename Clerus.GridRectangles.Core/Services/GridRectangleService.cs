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

            foreach (var rectangle in rectangles) {

                // validate coordinate

                // add
                _grid.Rectangles.Add(rectangle);
            }

            return true;
        }

        public bool HasValidGrid() => _grid.IsValid();
    }
}
