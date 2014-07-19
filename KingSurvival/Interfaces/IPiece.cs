namespace KingSurvival.Interfaces
{
    public interface IPiece
    {
        int X { get; }

        int Y { get; }

        void Move(IDirection moveDirection);
    }
}
