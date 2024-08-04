using ExploreMars.Interfaces;

namespace ExploreMarsTests;

[TestFixture]
public class PositionTests
{
    private IPosition _subject;

    [SetUp]
    public void Setup()
    {
        _subject = new Position();
    }

    [TestCase(123, 321)]
    [TestCase(2, 2)]
    [TestCase(0, 0)]
    [TestCase(-2, -2)]
    [TestCase(-123, -321)]
    public void GivenInitialPosition_WhenSetInitialPositionCalled_ThenCorrectValuesAreSet(int initialXValue, int initialYValue)
    {
        // Act
        _subject.SetInitialPosition(initialXValue, initialYValue);
        var (currentXValue, currentYValue) = _subject.GetCurrentPosition();

        // Assert
        Assert.That(currentXValue, Is.EqualTo(initialXValue));
        Assert.That(currentYValue, Is.EqualTo(initialYValue));
    }

    [TestCase(1, 5, 1, 2)]
    [TestCase(1, 5, -1, 0)]
    [TestCase(1, 5, 0, 1)]
    public void GivenPosition_WhenUpdateXAxisCalled_ThenXPositionIsChangedCorrectly_AndYStaysTheSame(int initialXValue, int initialYValue, int XValueChange, int expectedXValue)
    {
        // Arrange
        _subject.SetInitialPosition(initialXValue, initialYValue);

        // Act
        _subject.UpdateXAxis(XValueChange);
        var (currentXValue, currentYValue) = _subject.GetCurrentPosition();

        // Assert
        Assert.That(currentXValue, Is.EqualTo(expectedXValue));
        Assert.That(currentYValue, Is.EqualTo(initialYValue));
    }

    [TestCase(5, 1, 1, 2)]
    [TestCase(5, 1, -1, 0)]
    [TestCase(5, 1, 0, 1)]
    public void GivenPosition_WhenUpdateYAxisCalled_ThenYPositionIsChangedCorrectly_AndXStaysTheSame(int initialXValue, int initialYValue, int YValueChange, int expectedYValue)
    {
        // Arrange
        _subject.SetInitialPosition(initialXValue, initialYValue);

        // Act
        _subject.UpdateYAxis(YValueChange);
        var (currentXValue, currentYValue) = _subject.GetCurrentPosition();

        // Assert
        Assert.That(currentYValue, Is.EqualTo(expectedYValue));
        Assert.That(currentXValue, Is.EqualTo(initialXValue));
    }

    [Test]
    public void GivenPositionWithNoInitialValues_WhenGetCurrentPositionCalled_ThenDefaultIntegerValuesAreReturned()
    {
        // Act
        var (currentXValue, currentYValue) = _subject.GetCurrentPosition();

        // Assert
        Assert.That(currentXValue, Is.EqualTo(default(int)));
        Assert.That(currentYValue, Is.EqualTo(default(int)));
    }
}