namespace KingSurvival
{
    using System;
    internal class King : Piece
    {
        private const char KingsSymbol = 'K';
        private Position position;
        private char pieceSymbol;

        public King(int initialX, int initialY)
        {
            position = new Position(initialX, initialY);
            this.pieceSymbol = KingsSymbol;
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