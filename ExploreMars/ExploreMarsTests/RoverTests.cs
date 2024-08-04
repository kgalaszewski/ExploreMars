using ExploreMars.Enums;
using ExploreMars.Exceptions;
using ExploreMars.Interfaces;

namespace ExploreMarsTests;

[TestFixture]
public class RoverTests
{
    private IPosition _position;
    private IRover _subject;

    [SetUp]
    public void Setup()
    {
        _position = new Position();
        _subject = new Rover(_position);
    }

    [TestCase(1, 2, Direction.North, "Rover Position: 1, 2, North")]
    [TestCase(2, 1, Direction.South, "Rover Position: 2, 1, South")]
    [TestCase(0, 0, Direction.East, "Rover Position: 0, 0, East")]
    [TestCase(-10, 20, Direction.West, "Rover Position: -10, 20, West")]
    public void GivenRover_WhenInitializeCalled_ThenSetsCorrectInitialPositionAndDirection_AndGetPositionInfoReturnsValidPosition(int initialXValue, int initialYValue, Direction initialDirection, string expectedNewPositionInfo)
    {
        // Act
        _subject.Initialize(initialXValue, initialYValue, initialDirection);
        var currentPositionInfo = _subject.GetPositionInfo();

        // Assert
        Assert.That(currentPositionInfo, Is.EqualTo(expectedNewPositionInfo));
    }


    [Test]
    public void GivenRoverWithInitializedNeutralPosition_WhenDriveCalled_ThenUpdatesPositionCorrectlyAndFacesLastDirection()
    {
        // Arrange
        _subject.Initialize(0, 0, Direction.North); // Initialize neutral position
        var driveCommands = "MMMRRMMMLMMMMMMMLMMMLMMMLMMMLMMMMMMLMMMRRMMMLMMM"; // Commands to drive "LOL"
        //  X   XXXX  X
        //  X   X  X  X
        //  X   X  X  X
        //  XXXXXXXXXXXXXX  <-- If first X at this line is at 0,0, then this last X should be at (13, 0) after driving "LOL"
        var expectedRoverPisition = "Rover Position: 13, 0, East";

        // Act
        _subject.Drive(driveCommands);
        var currentPositionInfo = _subject.GetPositionInfo();

        // Assert
        Assert.That(currentPositionInfo, Is.EqualTo(expectedRoverPisition));
    }

    [TestCase("MMLaRM", "Rover Position: 0, 2, West")]
    [TestCase("1MMLRM", "Rover Position: 0, 0, North")]
    public void GivenRoverInNeutralPosition_AndGivenInvalidCommand_WhenDriveCalled_ThenThrowsException_AndRoverRemainsInTheLastPosition(string invalidDriveCommands, string expectedRoverPisition)
    {
        // Arrange
        _subject.Initialize(0, 0, Direction.North);

        // Act & Assert
        Assert.Throws<InvalidMovementCommandException>(() => _subject.Drive(invalidDriveCommands));
        // Rover should stay in the last position before the algorithm crash.
        var currentPositionInfo = _subject.GetPositionInfo();
        Assert.That(currentPositionInfo, Is.EqualTo(expectedRoverPisition));
    }

    [Test]
    public void GivenRoverInRandomPosition_AndGivenCommandToTurnBack_WhenDriveCalled_RoverStaysInTheSamePosition_AndTurnsBack()
    {
        // Arrange
        _subject.Initialize(5, -2, Direction.East);
        var expectedRoverPisition = "Rover Position: 5, -2, West";
        var turnBackCommand = "LL"; // Could be RR as well.

        // Act
        _subject.Drive(turnBackCommand);
        var currentPositionInfo = _subject.GetPositionInfo();

        // Assert
        Assert.That(currentPositionInfo, Is.EqualTo(expectedRoverPisition));
    }
}
