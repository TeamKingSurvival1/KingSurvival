namespace KingSurvival
{
    internal abstract class Piece
    {
        internal abstract Point Position { get; }

        internal abstract void Move();
    }
}