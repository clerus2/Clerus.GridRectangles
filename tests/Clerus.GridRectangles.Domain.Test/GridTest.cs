using Xunit;

namespace FlareExam.Domain.Test
{
    public class GridTest
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
        public void Grid_HasValidDimensions_ReturnPassed(int height, int width, bool expected)
        {
            // arrange
            var grid = new Grid(height, width);

            // act
            var valid = grid.IsValid();

            // assert
            Assert.Equal(expected, valid);
        }


        //[Fact]
        //public void Grid_WhenHasValidDimensions_ReturnPassed()
        //{
        //     arrange
        //    int height = 5; // valid height
        //    int width = 25; // valid width
        //    var grid = new Grid(height, width);

        //     act
        //    var valid = grid.IsValid();

        //     assert
        //    Assert.True(valid);
        //}

        //[Fact]
        //public void Grid_WhenHeightIsLessThanMinValue_ReturnFailed()
        //{
        //     arrange
        //    int height = 2; // invalid height
        //    int width = 25; // valid width
        //    var grid = new Grid(height, width);

        //     act
        //    var valid = grid.IsValid();

        //     assert
        //    Assert.False(valid);
        //}

        //[Fact]
        //public void Grid_WhenWidthIsMoreThanMaxValue_ReturnFailed()
        //{
        //     arrange
        //    int height = 5; // valid height
        //    int width = 26; // invalid width
        //    var grid = new Grid(height, width);

        //     act
        //    var valid = grid.IsValid();

        //     assert
        //    Assert.False(valid);
        //}
    }
}