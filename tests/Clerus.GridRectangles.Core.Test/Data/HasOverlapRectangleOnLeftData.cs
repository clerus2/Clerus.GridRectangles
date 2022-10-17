using Clerus.GridRectangles.Domain.Models;
using System.Collections;
using System.Collections.Generic;

namespace Clerus.GridRectangles.Core.Test.Data
{
    internal class HasOverlapRectangleOnLeftData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                new List<GridRectangle>
                {
                    new GridRectangle(
                        position: new Position { X = 2, Y = 8 },
                        width: 8,
                        height: 4),
                    new GridRectangle(
                        position: new Position { X = 8, Y = 6 },
                        width: 4,
                        height: 4)
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
