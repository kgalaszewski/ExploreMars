namespace ExploreMars.Interfaces;

public interface IPosition
{
    void SetInitialPosition(int x, int y);
    void UpdateXAxis(int xAxisMovement);
    void UpdateYAxis(int yAxisMovement);
    (int x, int y) GetCurrentPosition();
}
