namespace KingSurvival
{
    internal abstract class Piece
    {
        private Point position;

        internal abstract Point Position { get; }

        internal abstract void Move();
    }
}