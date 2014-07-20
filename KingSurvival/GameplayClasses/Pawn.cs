namespace KingSurvival.GameplayClasses
{
    using System;

    public class Pawn : Piece
    {
        private const char InvalidPawnSymbol = 'K';

        public Pawn(char symbol, int initialX, int initialY)
            : base(symbol, initialX, initialY)
        {
            if (symbol == InvalidPawnSymbol)
            {
                throw new ArgumentException("Invalid pawn symbol!");
            }
        }
    }
}