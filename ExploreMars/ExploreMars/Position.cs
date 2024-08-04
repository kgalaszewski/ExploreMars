public class Position(int initialXPosition, int initialYPosition)
{
    private int _currentXPosition = initialXPosition;
    private int _currentYPosition = initialYPosition;

    public void UpdateXAxis(int xAxisMovement) => _currentXPosition += xAxisMovement;
    public void UpdateYAxis(int yAxisMovement) => _currentYPosition += yAxisMovement;
    public (int X, int Y) GetCurrentPosition() => (_currentXPosition, _currentYPosition);
}