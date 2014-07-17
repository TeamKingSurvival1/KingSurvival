namespace KingSurvival
{
    using System;
    using System.Collections.Generic;

    internal class Command
    {
        private char targetSymbol;
        private Direction moveDirection;

        private Command(string input)
        {
            this.TranslateInput(input);
        }

        internal char TargetSymbol
        {
            get
            {
                return this.targetSymbol;
            }

            private set
            {
                // TODO: Validation of target symbol (A/B/C/D/K)
                this.targetSymbol = value;
            }
        }

        internal Direction MoveDirection
        {
            get
            {
                return this.moveDirection;
            }
            private set
            {
                // TODO: Validation of move direction command (just the string)
                this.moveDirection = value;
            }
        }

        internal static Command Parse(string input)
        {
            return new Command(input);
        }

        private void TranslateInput(string input)
        {
            // TODO: Remove empty spaces
            this.TargetSymbol = input[0];

            char verticalDirectionLetter = input[1];
            char horizontalDirectionLetter = input[2];
            
            this.MoveDirection = new Direction(verticalDirectionLetter, horizontalDirectionLetter);
        }
    }
}
