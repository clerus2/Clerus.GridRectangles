using Clerus.GridRectangles.Core.Services;
using Clerus.GridRectangles.Domain.Models;
using FlareExam.Domain.Models;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace Clerus.GridRectangles.Core.Test
{
    public class GridRectangleServiceUnitTest
    {

        private Mock<Grid> MockGrid(int height, int width) 
        {
            return new Mock<Grid>(height, width);
        }

        [Theory]
        [InlineData(5, 25, true)]
        [InlineData(25, 5, true)]
        [InlineData(5, 5, true)]
        [InlineData(25, 25, true)]
        [InlineData(4, 5, false)]   // invlid height less than min value
        [InlineData(26, 5, false)]  // invlid height greater than max value
        [InlineData(4, 25, false)]  // invlid height less than min value
        [InlineData(26, 25, false)] // invlid height greater than max value
        [InlineData(5, 4, false)]   // invlid width less than min value
        [InlineData(5, 26, false)]  // invlid width greater than max value
        [InlineData(25, 4, false)]  // invlid width less than min value
        [InlineData(25, 26, false)] // invlid width greater than max value

        public void GridRectangleService_HasValidGrid_ReturnPassed(int height, int width, bool expected)
        {
            // arrange
            var grid = MockGrid(height, width);
            var service = new GridRectangleService(grid.Object);

            // act
            var result = service.HasValidGrid();

            // assert
            Assert.NotNull(grid.Object);
            Assert.Equal(expected,result);
        }

        [Fact]
        public void GridRectangleService_AddRectangles_ReturnPassed() 
        {
            // arrange
            var gridHeight = 25;
            var gridWidth = 25;
            var grid = MockGrid(gridHeight, gridWidth);
            var service = new GridRectangleService(grid.Object);

            var rectangle1 = new GridRectangle(
                height: 2,
                width: 2,
                position: new Position { X = 0, Y = 0 });

            var rectangle2 = new GridRectangle(
                height: 3,
                width: 3,
                position: new Position { X = 1, Y = 1 });

            var rectangles = new List<GridRectangle>
            {
               rectangle1,
               rectangle2
            };

            // act
            var result = service.AddRectangles(rectangles);

            // assert
            Assert.True(result);
            Assert.True(service.Grid.Rectangles.Count > 0);
        }
    }
}