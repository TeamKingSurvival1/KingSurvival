namespace KingSurvival
{
    internal abstract class Piece: IMoveable
    {
        internal abstract Position Position { get; }
        internal abstract char Symbol { get; }

        public abstract void Move(int dirX, int dirY);
    }
}