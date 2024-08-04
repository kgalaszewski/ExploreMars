using ExploreMars.Enums;
using ExploreMars.Exceptions;
using ExploreMars.Interfaces;

public class Rover : IRover
{
    private Direction _currentDirection;
    private IPosition _currentRoverPosition;

    public Rover(IPosition initialPosition)
    {
        _currentRoverPosition = initialPosition;
    }

    public void Initialize(int initialXPosition, int initialYPosition, Direction initialDirection)
    {
        _currentRoverPosition.SetInitialPosition(initialXPosition, initialYPosition);
        _currentDirection = initialDirection;
    }

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

    public string GetPositionInfo()
    {
        var (currentXPosition, currentYPosition) = _currentRoverPosition.GetCurrentPosition();
        return $"Rover Position: {currentXPosition}, {currentYPosition}, {_currentDirection}";
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
}
