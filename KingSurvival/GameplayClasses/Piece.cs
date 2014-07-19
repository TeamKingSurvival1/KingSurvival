namespace KingSurvival.GameplayClasses
{
    using System;
    using Interfaces;

    internal abstract class Piece: IPiece
    {
        private int x;
        private int y;
        private char symbol;

        protected Piece(char symbol, int initialX, int initialY)
        {
            this.Symbol = symbol;
            this.X = initialX;
            this.Y = initialY;
        }

        public int X
        {
            get
            {
                return this.x;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Piece coordinates cannot be negative");
                }
                this.x = value;
            }
        }

        public int Y
        {
            get
            {
                return this.y;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Piece coordinates cannot be negative");
                }
                this.y = value;
            }
        }

        public char Symbol
        {
            get
            {
                return this.symbol;
            }
            protected set
            {
                if (Char.IsWhiteSpace(value))
                {
                    throw new ArgumentException("Piece symbol cannot be white space");
                }
                this.symbol = value;
            }
        }

        public virtual void Move(IDirection moveDirection)
        {
            this.X += moveDirection.XUpdateValue;
            this.Y += moveDirection.YUpdateValue;
        }
    }
}