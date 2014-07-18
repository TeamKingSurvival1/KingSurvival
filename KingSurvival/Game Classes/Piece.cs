namespace KingSurvival
{
    internal abstract class Piece: IMoveable
    {
        internal abstract Position Position { get; }

        internal abstract char Symbol { get; }

        public void Move(Direction moveDirection)
        {
            this.Position.X += moveDirection.XUpdateValue;
            this.Position.Y += moveDirection.YUpdateValue;
        }
    }
}