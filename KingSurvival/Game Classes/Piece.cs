namespace KingSurvival
{
    internal abstract class Piece: IMoveable
    {
        internal abstract Position Position { get; }

        public abstract void Move(int dirX, int dirY);
    }
}