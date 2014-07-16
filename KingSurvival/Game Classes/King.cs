namespace KingSurvival
{
    using System;
    internal class King : Piece
    {
        private Position position;

        public King(int initialX, int initialY)
        {
            position = new Position(initialX, initialY);
        }

        internal override Position Position
        {
            get
            {
                return this.position;
            }
        }

        public override void Move(int dirX, int dirY)
        {
            this.Position.Y += dirY;
            this.Position.X += dirX;
            return;
        }
    }
}