namespace KingSurvival.GameplayClasses
{
    using System;
    using Interfaces;

    internal class King : Piece
    {
        private const char KingsSymbol = 'K';
        private int movesMade;

        public King(int initialX, int initialY)
            : base(KingsSymbol, initialX, initialY)
        {
            this.MovesMade = 0;
        }


        public int MovesMade
        {
            get
            {
                return this.movesMade;
            }
            private set
            {
                this.movesMade = value;
            }
        }

        public override void Move(IDirection moveDirection)
        {
            base.Move(moveDirection);
            this.MovesMade += 1;
        }
    }
}