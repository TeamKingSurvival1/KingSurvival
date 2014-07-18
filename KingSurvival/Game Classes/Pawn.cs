namespace KingSurvival
{
    using System;

    internal class Pawn : Piece
    {
        private const char InvalidPawnSymbol = 'K';        
        private Position position;
        private char pieceSymbol;

        public Pawn(char symbol, int initialX, int initialY)
        {
            position = new Position(initialX, initialY);
            if (symbol == InvalidPawnSymbol)
            {
                throw new ArgumentException("Invalid pawn symbol!"); 
            }
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
    }
}