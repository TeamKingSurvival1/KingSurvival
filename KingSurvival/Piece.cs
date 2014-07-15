namespace KingSurvival
{
    internal abstract class Piece
    {
        internal abstract Position Position { get; }

        internal abstract void Move();
    }
}