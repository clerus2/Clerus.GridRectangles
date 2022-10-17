using Clerus.GridRectangles.Core.Services;
using Clerus.GridRectangles.Core.Test.Data;
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
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GridRectangleService_CheckRectanglesIfContainsNegativePosition_ReturnTrue()
        {
            // arrange
            var gridHeight = 25;
            var gridWidth = 25;
            var grid = MockGrid(gridHeight, gridWidth);
            var service = new GridRectangleService(grid.Object);

            var invalidPosition = -1;
            var rectangle1 = new GridRectangle(
                height: 2, // invalid
                width: 2,
                position: new Position { X = invalidPosition, Y = 0 });

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
            var result = service.CheckRectanglesIfContainsNegativePosition(rectangles);

            // assert
            Assert.True(result);
            Assert.True(service.Grid.Rectangles.Count == 0);
        }

        [Fact]
        public void GridRectangleService_CheckRectanglesXPositionIfBeyondGrid_ReturnTrue()
        {
            // arrange
            var gridHeight = 25;
            var gridWidth = 25;
            var grid = MockGrid(gridHeight, gridWidth);
            var service = new GridRectangleService(grid.Object);

            // Rectangle's X Position Beyond Grid's Width
            var rectangle1 = new GridRectangle(
                height: 2,
                width: 10,
                position: new Position { X = 20, Y = 0 });

            // Valid Rectangle
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
            var result = service.CheckRectanglesXPositionIfBeyondGrid(rectangles);

            // assert
            Assert.True(result);
            Assert.True(service.Grid.Rectangles.Count == 0);
        }

        [Fact]
        public void GridRectangleService_CheckRectanglesYPositionIfBeyondGrid_ReturnTrue()
        {
            // arrange
            var gridHeight = 25;
            var gridWidth = 25;
            var grid = MockGrid(gridHeight, gridWidth);
            var service = new GridRectangleService(grid.Object);

            // Rectangle's Y Position Beyond Grid's Width
            var rectangle1 = new GridRectangle(
                height: 20,
                width: 3,
                position: new Position { X = 0, Y = 15 });

            // Valid rectangle
            var rectangle2 = new GridRectangle(
                height: 5,
                width: 3,
                position: new Position { X = 1, Y = 2 });

            var rectangles = new List<GridRectangle>
            {
               rectangle1,
               rectangle2
            };

            // act
            var result = service.CheckRectanglesYPositionIfBeyondGrid(rectangles);

            // assert
            Assert.True(result);
            Assert.True(service.Grid.Rectangles.Count == 0);
        }

        [Fact]
        public void GridRectangleService_AddRectangles_ReturnTrue()
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
                position: new Position { X = 5, Y = 5 });

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

        [Fact]
        public void GridRectangleService_FindGridRectangle_ReturnNotNull()
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
                position: new Position { X = 5, Y = 5 });

            var rectangles = new List<GridRectangle>
            {
               rectangle1,
               rectangle2
            };

            var addRectanglesResult = service.AddRectangles(rectangles);

            var searchPosition = new Position { X = 0, Y = 0 };

            // act
            var result = service.FindGridRectangle(searchPosition);

            // assert
            Assert.NotNull(result);
            Assert.Equal(searchPosition.X, result?.Position.X);
            Assert.Equal(searchPosition.Y, result?.Position.Y);
        }

        [Fact]
        public void GridRectangleService_FindGridRectangle_ReturnNull()
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

            var addRectanglesResult = service.AddRectangles(rectangles);

            var searchPosition = new Position { X = 3, Y = 5 };

            // act
            var result = service.FindGridRectangle(searchPosition);

            // assert
            Assert.Null(result);
        }

        [Theory]
        [InlineData(0, 0, 1)]
        [InlineData(2, 2, 1)]
        [InlineData(2, 3, 2)]
        [InlineData(10, 10, 1)]
        [InlineData(13, 13, 1)]
        [InlineData(2, 13, 2)]
        public void GridRectangleService_RemoveGridRectangle_ReturnPassed(int x, int y, int expectedCount)
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
                position: new Position { X = 10, Y = 10 });

            var rectangles = new List<GridRectangle>
            {
               rectangle1,
               rectangle2
            };

            service.AddRectangles(rectangles);

            var deletePosition = new Position { X = x, Y = y };

            // act
            service.RemoveGridRectangle(deletePosition);

            // assert
            Assert.Equal(expectedCount, service.Grid.Rectangles.Count);
        }

        [Theory]
        [ClassData(typeof(HasOverlapRectangleOnRightData))]
        public void GridRectangleService_CheckRectangleOverlapOnRight_ReturnTrue(List<GridRectangle> rectangles)
        {
            // arrange
            var gridHeight = 25;
            var gridWidth = 25;
            var grid = MockGrid(gridHeight, gridWidth);
            var service = new GridRectangleService(grid.Object);

            // act
            var result = service.CheckRectangleOverlap(rectangles);

            // assert
            Assert.True(result);
        }

        [Theory]
        [ClassData(typeof(HasOverlapRectangleOnLeftData))]
        public void GridRectangleService_CheckRectangleOverlapOnLeft_ReturnTrue(List<GridRectangle> rectangles)
        {
            // arrange
            var gridHeight = 25;
            var gridWidth = 25;
            var grid = MockGrid(gridHeight, gridWidth);
            var service = new GridRectangleService(grid.Object);

            // act
            var result = service.CheckRectangleOverlap(rectangles);

            // assert
            Assert.True(result);
        }

        [Theory]
        [ClassData(typeof(HasNoOverlapRectangleData))]
        public void GridRectangleService_CheckRectangleOverlap_ReturnFalse(List<GridRectangle> rectangles)
        {
            // arrange
            var gridHeight = 25;
            var gridWidth = 25;
            var grid = MockGrid(gridHeight, gridWidth);
            var service = new GridRectangleService(grid.Object);

            // act
            var result = service.CheckRectangleOverlap(rectangles);

            // assert
            Assert.False(result);
        }
    }
}