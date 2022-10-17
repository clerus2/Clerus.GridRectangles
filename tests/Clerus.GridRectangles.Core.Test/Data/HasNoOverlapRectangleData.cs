using Clerus.GridRectangles.Domain.Models;
using System.Collections;
using System.Collections.Generic;

namespace Clerus.GridRectangles.Core.Test.Data
{
    internal class HasNoOverlapRectangleData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {
                new List<GridRectangle>
                {
                    new GridRectangle(
                        position: new Position { X = 0, Y = 0 },
                        width: 4,
                        height: 4),
                    new GridRectangle(
                        position: new Position { X = 0, Y = 8 },
                        width: 4,
                        height: 4),
                    new GridRectangle(
                        position: new Position { X = 2, Y = 4 },
                        width: 8,
                        height: 4),
                    new GridRectangle(
                        position: new Position { X = 10, Y = 4 },
                        width: 4,
                        height: 4),
                    new GridRectangle(
                        position: new Position { X = 8, Y = 10 },
                        width: 4,
                        height: 4),
                    new GridRectangle(
                        position: new Position { X = 10, Y = 0 },
                        width: 4,
                        height: 4),
                    new GridRectangle(
                        position: new Position { X = 0, Y = 12 },
                        width: 4,
                        height: 14),
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
