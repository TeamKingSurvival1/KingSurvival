namespace KingSurvival
{
    using System;

    internal class King : Piece
    {
        private Point position;

        public King(int x, int y)
        {
            this.Position.X = x;
            this.Position.Y = y;
        }

        internal override Point Position
        {
            get
            {
                return this.position;
            }
        }

        internal override void Move()
        {
        }
    }
}