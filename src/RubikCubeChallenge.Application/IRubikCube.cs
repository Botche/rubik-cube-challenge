namespace RubikCubeChallenge.Application;

public interface IRubikCube
{
    void MoveFront(bool isInverted = false);
    void MoveBack(bool isInverted = false);
    void MoveRight(bool isInverted = false);
    void MoveLeft(bool isInverted = false);
    void MoveUp(bool isInverted = false);
    void MoveDown(bool isInverted = false);

    void Reset();

    string ToString(string delimiterToJoin);
}
