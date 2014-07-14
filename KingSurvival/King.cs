namespace KingSurvival
{
    internal class King : Piece
    {
        private Point position;

        public King(int x, int y)
        {
            position = new Point(x, y);
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