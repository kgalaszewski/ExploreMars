using ExploreMars;

public class Rover(int initialXPosition, int initialYPosition, Direction initialDirection)
{
    private Direction _currentDirection = initialDirection;

    private readonly Position _currentRoverPosition = new(initialXPosition, initialYPosition);

    public void Drive(string movementCommands)
    {
        foreach (char movementCommand in movementCommands)
        {
            switch (movementCommand)
            {
                case 'L':
                    TurnLeft();
                    break;
                case 'R':
                    TurnRight();
                    break;
                case 'M':
                    MoveForward();
                    break;
                default:
                    throw new InvalidMovementCommandException(movementCommand);
            }
        }
    }

    private void TurnLeft()
    {
        _currentDirection = _currentDirection switch
        {
            Direction.North => Direction.West,
            Direction.West => Direction.South,
            Direction.South => Direction.East,
            Direction.East => Direction.North,
            _ => _currentDirection
        };
    }

    private void TurnRight()
    {
        _currentDirection = _currentDirection switch
        {
            Direction.North => Direction.East,
            Direction.East => Direction.South,
            Direction.South => Direction.West,
            Direction.West => Direction.North,
            _ => _currentDirection
        };
    }

    private void MoveForward()
    {
        switch (_currentDirection)
        {
            case Direction.North:
                _currentRoverPosition.UpdateYAxis(1);
                break;
            case Direction.South:
                _currentRoverPosition.UpdateYAxis(-1);
                break;
            case Direction.East:
                _currentRoverPosition.UpdateXAxis(1);
                break;
            case Direction.West:
                _currentRoverPosition.UpdateXAxis(-1);
                break;
        }
    }

    public void DisplayPosition()
    {
        var (currentXPosition, currentYPosition) = _currentRoverPosition.GetCurrentPosition();
        Console.WriteLine($"Rover Position: {currentXPosition}, {currentYPosition}, {_currentDirection}");
    }
}
