using Clerus.GridRectangles.Core.Interfaces;
using FlareExam.Domain.Models;

namespace Clerus.GridRectangles.Core.Services
{
    public class GridRectangleService : IGridRectangleService
    {
        private readonly Grid _grid;

        public GridRectangleService(Grid grid)
        {
            _grid = grid;
        }

        public bool HasValidGrid() => _grid.IsValid();
    }
}
