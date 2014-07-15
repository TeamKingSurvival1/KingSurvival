namespace KingSurvival
{
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

        public override void Move()
        {
        }
    }
}