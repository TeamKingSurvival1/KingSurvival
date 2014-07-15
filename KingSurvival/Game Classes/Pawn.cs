namespace KingSurvival
{
    internal class Pawn : Piece
    {
        private Position position;

        public Pawn(int initialX, int initialY)
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

        public override void Move()
        {
        }
    }
}