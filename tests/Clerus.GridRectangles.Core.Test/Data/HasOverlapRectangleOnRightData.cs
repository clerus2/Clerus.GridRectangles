using Clerus.GridRectangles.Domain.Models;
using System.Collections;
using System.Collections.Generic;

namespace Clerus.GridRectangles.Core.Test.Data
{
    internal class HasOverlapRectangleOnRightData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                new List<GridRectangle>
                {
                    new GridRectangle(
                        position: new Position { X = 8, Y = 8 },
                        width: 6,
                        height: 4),
                    new GridRectangle(
                        position: new Position { X = 6, Y = 6 },
                        width: 4,
                        height: 4)
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
