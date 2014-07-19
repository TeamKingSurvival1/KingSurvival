namespace KingSurvival
{
    internal class Pawn : Piece
    {
        private Position position;

        public Pawn(int x, int y)
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