namespace RubikCubeChallenge.UnitTests.Application;

using System.Text;

using RubikCubeChallenge.Application;


public class RubikCubeTests
{
    const string WhiteSpaceDelimiter = " ";

    private readonly IRubikCube rubikCube = new RubikCube();

    public RubikCubeTests()
    {
        rubikCube.Reset();
    }

    [Fact]
    public void ToString_ShouldReturnCorrectStringRepresentation()
    {
        var expectedRubikCube = new StringBuilder();
        expectedRubikCube.AppendLine("      W W W            ");
        expectedRubikCube.AppendLine("      W W W            ");
        expectedRubikCube.AppendLine("      W W W            ");
        expectedRubikCube.AppendLine("O O O G G G R R R B B B");
        expectedRubikCube.AppendLine("O O O G G G R R R B B B");
        expectedRubikCube.AppendLine("O O O G G G R R R B B B");
        expectedRubikCube.AppendLine("      Y Y Y            ");
        expectedRubikCube.AppendLine("      Y Y Y            ");
        expectedRubikCube.AppendLine("      Y Y Y            ");

        var rubikCubeToString = rubikCube.ToString(WhiteSpaceDelimiter);

        Assert.Equal(expectedRubikCube.ToString(), rubikCubeToString);
    }

    [Fact]
    public void ToString_ShouldPintTheCorrectRepresentation()
    {
        var expectedRubikCube = new StringBuilder();
        expectedRubikCube.AppendLine("      R O G            ");
        expectedRubikCube.AppendLine("      B W W            ");
        expectedRubikCube.AppendLine("      B B B            ");
        expectedRubikCube.AppendLine("G Y Y O R R Y B O Y B W");
        expectedRubikCube.AppendLine("O O G O G W R R W O B Y");
        expectedRubikCube.AppendLine("B G O W W W O Y R Y Y W");
        expectedRubikCube.AppendLine("      G G B            ");
        expectedRubikCube.AppendLine("      R Y R            ");
        expectedRubikCube.AppendLine("      R G G            ");

        rubikCube.MoveFront();
        rubikCube.MoveRight(true);
        rubikCube.MoveUp();
        rubikCube.MoveBack(true);
        rubikCube.MoveLeft();
        rubikCube.MoveDown(true);

        Assert.Equal(expectedRubikCube.ToString(), rubikCube.ToString(WhiteSpaceDelimiter));
    }

    [Fact]
    public void ToString_ShouldBeCorrect_AfterAllBasicFaceMoves()
    {
        var expected = new StringBuilder();
        expected.AppendLine("      W W W            ");
        expected.AppendLine("      W W W            ");
        expected.AppendLine("      W W W            ");
        expected.AppendLine("O O O G G G R R R B B B");
        expected.AppendLine("O O O G G G R R R B B B");
        expected.AppendLine("O O O G G G R R R B B B");
        expected.AppendLine("      Y Y Y            ");
        expected.AppendLine("      Y Y Y            ");
        expected.AppendLine("      Y Y Y            ");

        var cube = new RubikCube();

        cube.MoveFront();
        cube.MoveRight();
        cube.MoveUp();
        cube.MoveBack();
        cube.MoveLeft();
        cube.MoveDown();
        cube.MoveDown(true);
        cube.MoveLeft(true);
        cube.MoveBack(true);
        cube.MoveUp(true);
        cube.MoveRight(true);
        cube.MoveFront(true);

        Assert.Equal(expected.ToString(), cube.ToString(WhiteSpaceDelimiter));
    }

    [Fact]
    public void ToString_ShouldBeCorrect_AfterAllBasicFaceMovesSecond()
    {
        var expected = new StringBuilder();

        expected.AppendLine("      O O B            ");
        expected.AppendLine("      W W R            ");
        expected.AppendLine("      B O O            ");
        expected.AppendLine("G G O W W G W Y R Y Y Y");
        expected.AppendLine("W O B O G W B R B Y B R");
        expected.AppendLine("G O G W G W B R B O B Y");
        expected.AppendLine("      R Y R            ");
        expected.AppendLine("      G Y G            ");
        expected.AppendLine("      R R Y            ");

        var cube = new RubikCube();

        cube.MoveFront();
        cube.MoveRight();
        cube.MoveUp();
        cube.MoveBack();
        cube.MoveLeft();
        cube.MoveDown();
        cube.MoveFront(true);
        cube.MoveRight(true);
        cube.MoveUp(true);
        cube.MoveBack(true);
        cube.MoveLeft(true);
        cube.MoveDown(true);

        Assert.Equal(expected.ToString(), cube.ToString(WhiteSpaceDelimiter));
    }

    [Fact]
    public void Reset_ShouldReturnTheInitialCubeView()
    {
        var expectedRubikCube = new StringBuilder();
        expectedRubikCube.AppendLine("      W W W            ");
        expectedRubikCube.AppendLine("      W W W            ");
        expectedRubikCube.AppendLine("      W W W            ");
        expectedRubikCube.AppendLine("O O O G G G R R R B B B");
        expectedRubikCube.AppendLine("O O O G G G R R R B B B");
        expectedRubikCube.AppendLine("O O O G G G R R R B B B");
        expectedRubikCube.AppendLine("      Y Y Y            ");
        expectedRubikCube.AppendLine("      Y Y Y            ");
        expectedRubikCube.AppendLine("      Y Y Y            ");

        rubikCube.MoveLeft();
        rubikCube.MoveDown();
        rubikCube.MoveUp();

        rubikCube.Reset();

        Assert.Equal(expectedRubikCube.ToString(), rubikCube.ToString(WhiteSpaceDelimiter));
    }

    [Fact]
    public void MoveFront_ShouldMoveTheSideClockwise_WhenIsInvertedEqualsFalse()
    {
        var expectedRubikCube = new StringBuilder();
        expectedRubikCube.AppendLine("      W W W            ");
        expectedRubikCube.AppendLine("      W W W            ");
        expectedRubikCube.AppendLine("      O O O            ");
        expectedRubikCube.AppendLine("O O Y G G G W R R B B B");
        expectedRubikCube.AppendLine("O O Y G G G W R R B B B");
        expectedRubikCube.AppendLine("O O Y G G G W R R B B B");
        expectedRubikCube.AppendLine("      R R R            ");
        expectedRubikCube.AppendLine("      Y Y Y            ");
        expectedRubikCube.AppendLine("      Y Y Y            ");

        rubikCube.MoveFront();

        Assert.Equal(expectedRubikCube.ToString(), rubikCube.ToString(WhiteSpaceDelimiter));
    }

    [Fact]
    public void MoveFront_ShouldMoveTheSideAnticlockwise_WhenIsInvertedEqualsTrue()
    {
        var expectedRubikCube = new StringBuilder();
        expectedRubikCube.AppendLine("      W W W            ");
        expectedRubikCube.AppendLine("      W W W            ");
        expectedRubikCube.AppendLine("      R R R            ");
        expectedRubikCube.AppendLine("O O W G G G Y R R B B B");
        expectedRubikCube.AppendLine("O O W G G G Y R R B B B");
        expectedRubikCube.AppendLine("O O W G G G Y R R B B B");
        expectedRubikCube.AppendLine("      O O O            ");
        expectedRubikCube.AppendLine("      Y Y Y            ");
        expectedRubikCube.AppendLine("      Y Y Y            ");

        rubikCube.MoveFront(true);

        Assert.Equal(expectedRubikCube.ToString(), rubikCube.ToString(WhiteSpaceDelimiter));
    }

    [Fact]
    public void MoveRight_ShouldMoveTheSideClockwise_WhenIsInvertedEqualsFalse()
    {
        var expectedRubikCube = new StringBuilder();
        expectedRubikCube.AppendLine("      W W G            ");
        expectedRubikCube.AppendLine("      W W G            ");
        expectedRubikCube.AppendLine("      W W G            ");
        expectedRubikCube.AppendLine("O O O G G Y R R R W B B");
        expectedRubikCube.AppendLine("O O O G G Y R R R W B B");
        expectedRubikCube.AppendLine("O O O G G Y R R R W B B");
        expectedRubikCube.AppendLine("      Y Y B            ");
        expectedRubikCube.AppendLine("      Y Y B            ");
        expectedRubikCube.AppendLine("      Y Y B            ");

        rubikCube.MoveRight();

        Assert.Equal(expectedRubikCube.ToString(), rubikCube.ToString(WhiteSpaceDelimiter));
    }

    [Fact]
    public void MoveRight_ShouldMoveTheSideAnticlockwise_WhenIsInvertedEqualsTrue()
    {
        var expectedRubikCube = new StringBuilder();
        expectedRubikCube.AppendLine("      W W B            ");
        expectedRubikCube.AppendLine("      W W B            ");
        expectedRubikCube.AppendLine("      W W B            ");
        expectedRubikCube.AppendLine("O O O G G W R R R Y B B");
        expectedRubikCube.AppendLine("O O O G G W R R R Y B B");
        expectedRubikCube.AppendLine("O O O G G W R R R Y B B");
        expectedRubikCube.AppendLine("      Y Y G            ");
        expectedRubikCube.AppendLine("      Y Y G            ");
        expectedRubikCube.AppendLine("      Y Y G            ");

        rubikCube.MoveRight(true);

        Assert.Equal(expectedRubikCube.ToString(), rubikCube.ToString(WhiteSpaceDelimiter));
    }

    [Fact]
    public void MoveUp_ShouldMoveTheSideClockwise_WhenIsInvertedEqualsFalse()
    {
        var expectedRubikCube = new StringBuilder();
        expectedRubikCube.AppendLine("      W W W            ");
        expectedRubikCube.AppendLine("      W W W            ");
        expectedRubikCube.AppendLine("      W W W            ");
        expectedRubikCube.AppendLine("G G G R R R B B B O O O");
        expectedRubikCube.AppendLine("O O O G G G R R R B B B");
        expectedRubikCube.AppendLine("O O O G G G R R R B B B");
        expectedRubikCube.AppendLine("      Y Y Y            ");
        expectedRubikCube.AppendLine("      Y Y Y            ");
        expectedRubikCube.AppendLine("      Y Y Y            ");

        rubikCube.MoveUp();

        Assert.Equal(expectedRubikCube.ToString(), rubikCube.ToString(WhiteSpaceDelimiter));
    }

    [Fact]
    public void MoveUp_ShouldMoveTheSideAnticlockwise_WhenIsInvertedEqualsTrue()
    {
        var expectedRubikCube = new StringBuilder();
        expectedRubikCube.AppendLine("      W W W            ");
        expectedRubikCube.AppendLine("      W W W            ");
        expectedRubikCube.AppendLine("      W W W            ");
        expectedRubikCube.AppendLine("B B B O O O G G G R R R");
        expectedRubikCube.AppendLine("O O O G G G R R R B B B");
        expectedRubikCube.AppendLine("O O O G G G R R R B B B");
        expectedRubikCube.AppendLine("      Y Y Y            ");
        expectedRubikCube.AppendLine("      Y Y Y            ");
        expectedRubikCube.AppendLine("      Y Y Y            ");

        rubikCube.MoveUp(true);

        Assert.Equal(expectedRubikCube.ToString(), rubikCube.ToString(WhiteSpaceDelimiter));
    }

    [Fact]
    public void MoveBack_ShouldMoveTheSideClockwise_WhenIsInvertedEqualsFalse()
    {
        var expectedRubikCube = new StringBuilder();
        expectedRubikCube.AppendLine("      R R R            ");
        expectedRubikCube.AppendLine("      W W W            ");
        expectedRubikCube.AppendLine("      W W W            ");
        expectedRubikCube.AppendLine("W O O G G G R R Y B B B");
        expectedRubikCube.AppendLine("W O O G G G R R Y B B B");
        expectedRubikCube.AppendLine("W O O G G G R R Y B B B");
        expectedRubikCube.AppendLine("      Y Y Y            ");
        expectedRubikCube.AppendLine("      Y Y Y            ");
        expectedRubikCube.AppendLine("      O O O            ");

        rubikCube.MoveBack();

        Assert.Equal(expectedRubikCube.ToString(), rubikCube.ToString(WhiteSpaceDelimiter));
    }

    [Fact]
    public void MoveBack_ShouldMoveTheSideAnticlockwise_WhenIsInvertedEqualsTrue()
    {
        var expectedRubikCube = new StringBuilder();
        expectedRubikCube.AppendLine("      O O O            ");
        expectedRubikCube.AppendLine("      W W W            ");
        expectedRubikCube.AppendLine("      W W W            ");
        expectedRubikCube.AppendLine("Y O O G G G R R W B B B");
        expectedRubikCube.AppendLine("Y O O G G G R R W B B B");
        expectedRubikCube.AppendLine("Y O O G G G R R W B B B");
        expectedRubikCube.AppendLine("      Y Y Y            ");
        expectedRubikCube.AppendLine("      Y Y Y            ");
        expectedRubikCube.AppendLine("      R R R            ");

        rubikCube.MoveBack(true);

        Assert.Equal(expectedRubikCube.ToString(), rubikCube.ToString(WhiteSpaceDelimiter));
    }

    [Fact]
    public void MoveLeft_ShouldMoveTheSideClockwise_WhenIsInvertedEqualsFalse()
    {
        var expectedRubikCube = new StringBuilder();
        expectedRubikCube.AppendLine("      B W W            ");
        expectedRubikCube.AppendLine("      B W W            ");
        expectedRubikCube.AppendLine("      B W W            ");
        expectedRubikCube.AppendLine("O O O W G G R R R B B Y");
        expectedRubikCube.AppendLine("O O O W G G R R R B B Y");
        expectedRubikCube.AppendLine("O O O W G G R R R B B Y");
        expectedRubikCube.AppendLine("      G Y Y            ");
        expectedRubikCube.AppendLine("      G Y Y            ");
        expectedRubikCube.AppendLine("      G Y Y            ");

        rubikCube.MoveLeft();

        Assert.Equal(expectedRubikCube.ToString(), rubikCube.ToString(WhiteSpaceDelimiter));
    }

    [Fact]
    public void MoveLeft_ShouldMoveTheSideAnticlockwise_WhenIsInvertedEqualsTrue()
    {
        var expectedRubikCube = new StringBuilder();
        expectedRubikCube.AppendLine("      G W W            ");
        expectedRubikCube.AppendLine("      G W W            ");
        expectedRubikCube.AppendLine("      G W W            ");
        expectedRubikCube.AppendLine("O O O Y G G R R R B B W");
        expectedRubikCube.AppendLine("O O O Y G G R R R B B W");
        expectedRubikCube.AppendLine("O O O Y G G R R R B B W");
        expectedRubikCube.AppendLine("      B Y Y            ");
        expectedRubikCube.AppendLine("      B Y Y            ");
        expectedRubikCube.AppendLine("      B Y Y            ");

        rubikCube.MoveLeft(true);

        Assert.Equal(expectedRubikCube.ToString(), rubikCube.ToString(WhiteSpaceDelimiter));
    }

    [Fact]
    public void MoveDown_ShouldMoveTheSideClockwise_WhenIsInvertedEqualsFalse()
    {
        var expectedRubikCube = new StringBuilder();
        expectedRubikCube.AppendLine("      W W W            ");
        expectedRubikCube.AppendLine("      W W W            ");
        expectedRubikCube.AppendLine("      W W W            ");
        expectedRubikCube.AppendLine("O O O G G G R R R B B B");
        expectedRubikCube.AppendLine("O O O G G G R R R B B B");
        expectedRubikCube.AppendLine("B B B O O O G G G R R R");
        expectedRubikCube.AppendLine("      Y Y Y            ");
        expectedRubikCube.AppendLine("      Y Y Y            ");
        expectedRubikCube.AppendLine("      Y Y Y            ");

        rubikCube.MoveDown();

        Assert.Equal(expectedRubikCube.ToString(), rubikCube.ToString(WhiteSpaceDelimiter));
    }

    [Fact]
    public void MoveDown_ShouldMoveTheSideAnticlockwise_WhenIsInvertedEqualsTrue()
    {
        var expectedRubikCube = new StringBuilder();
        expectedRubikCube.AppendLine("      W W W            ");
        expectedRubikCube.AppendLine("      W W W            ");
        expectedRubikCube.AppendLine("      W W W            ");
        expectedRubikCube.AppendLine("O O O G G G R R R B B B");
        expectedRubikCube.AppendLine("O O O G G G R R R B B B");
        expectedRubikCube.AppendLine("G G G R R R B B B O O O");
        expectedRubikCube.AppendLine("      Y Y Y            ");
        expectedRubikCube.AppendLine("      Y Y Y            ");
        expectedRubikCube.AppendLine("      Y Y Y            ");

        rubikCube.MoveDown(true);

        Assert.Equal(expectedRubikCube.ToString(), rubikCube.ToString(WhiteSpaceDelimiter));
    }
}
