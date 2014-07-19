namespace KingSurvival.Engine
{
    using System;
    using System.Collections.Generic;
    using GameplayClasses;

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
            // TODO: check input not to be less than 3 chars
            string inputUppercase = input.ToUpper();

            this.TargetSymbol = inputUppercase[0];

            char verticalDirectionLetter = inputUppercase[1];
            char horizontalDirectionLetter = inputUppercase[2];
            
            this.MoveDirection = new Direction(verticalDirectionLetter, horizontalDirectionLetter);
        }
    }
}
