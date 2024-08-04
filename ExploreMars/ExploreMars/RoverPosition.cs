using ExploreMars;

public class RoverPosition(int initialXPosition, int initialYPosition, Direction initialDirection)
{
    private int _currentXPosition = initialXPosition;
    private int _currentYPosition = initialYPosition;
    private Direction _currentDirection = initialDirection;

    public void UpdatePosition(int x, int y)
    {
        X = x;
        Y = y;
    }

    public void UpdateFacing(Direction direction)
    {
        CurrentDirection = direction;
    }

    public string ShowCurrentPosition()
    {
        return $"{_currentXPosition}, {_currentYPosition}, {_currentDirection}";
    }
}