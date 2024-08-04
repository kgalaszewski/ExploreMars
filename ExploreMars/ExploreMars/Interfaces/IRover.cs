using ExploreMars.Enums;

namespace ExploreMars.Interfaces;

public interface IRover
{
    void Initialize(int x, int y, Direction direction);
    void Drive(string movementCommands);
    string GetPositionInfo();
}
