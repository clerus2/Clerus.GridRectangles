using Clerus.GridRectangles.Core.Services;
using FlareExam.Domain.Models;
using Moq;
using Xunit;

namespace Clerus.GridRectangles.Core.Test
{
    public class GridRectangleServiceUnitTest
    {
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
            var grid = new Mock<Grid>(height, width);
            var service = new GridRectangleService(grid.Object);

            // act
            var result = service.HasValidGrid();

            // assert
            Assert.NotNull(grid.Object);
            Assert.Equal(expected,result);
        }
    }
}