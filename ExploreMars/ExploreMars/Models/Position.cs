using ExploreMars.Interfaces;

public class Position : IPosition
{
    private int _currentXPosition;
    private int _currentYPosition;

    public void SetInitialPosition(int initialXPosition, int initialYPosition) => (_currentXPosition, _currentYPosition) = (initialXPosition, initialYPosition);
    public void UpdateXAxis(int xAxisMovement) => _currentXPosition += xAxisMovement;
    public void UpdateYAxis(int yAxisMovement) => _currentYPosition += yAxisMovement;
    public (int x, int y) GetCurrentPosition() => (_currentXPosition, _currentYPosition);
}