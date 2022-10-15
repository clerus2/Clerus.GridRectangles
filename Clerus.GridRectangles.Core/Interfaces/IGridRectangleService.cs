using Clerus.GridRectangles.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clerus.GridRectangles.Core.Interfaces
{
    public interface IGridRectangleService
    {
        public bool HasValidGrid();

        public bool AddRectangles(List<GridRectangle> rectangles);
    }
}
