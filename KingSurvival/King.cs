namespace KingSurvival
{
    internal class King : Piece
    {
        private Position position;

        public King(int x, int y)
        {
            position = new Position(x, y);
        }

        internal override Position Position
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