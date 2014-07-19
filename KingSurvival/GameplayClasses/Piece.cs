namespace KingSurvival.GameplayClasses
{
    using Interfaces;

    internal abstract class Piece: IMoveable
    {
        private Position position;
        private char symbol;

        protected Piece(char symbol, int initialX, int initialY)
        {
            this.Symbol = symbol;
            this.Position = new Position(initialX, initialY);
        }

        public Position Position
        {
            get
            {
                return this.position;
            }
            set
            {
                this.position = value;
            }
        }

        public char Symbol
        {
            get
            {
                return this.symbol;
            }
            set
            {
                this.symbol = value;
            }
        }

        public virtual void Move(Direction moveDirection)
        {
            this.Position.X += moveDirection.XUpdateValue;
            this.Position.Y += moveDirection.YUpdateValue;
        }
    }
}