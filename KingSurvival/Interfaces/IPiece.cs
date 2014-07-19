namespace KingSurvival.Interfaces
{
    public interface IPiece
    {
        int X { get; set; }

        int Y { get; set; }

        void Move(IDirection moveDirection);
    }
}
