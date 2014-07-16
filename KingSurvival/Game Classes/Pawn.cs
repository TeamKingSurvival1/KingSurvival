namespace KingSurvival
{
    internal class Pawn : Piece
    {
        private Position position;
        private char pieceSymbol;

        public Pawn(char symbol, int initialX, int initialY)
        {
            position = new Position(initialX, initialY);
            this.pieceSymbol = symbol;
        }

        internal override char Symbol
        {
            get
            {
                return this.pieceSymbol;
            }
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