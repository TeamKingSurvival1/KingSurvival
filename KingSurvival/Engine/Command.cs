namespace KingSurvival.Engine
{
    using System;
    using System.Collections.Generic;
    using Interfaces;
    using GameplayClasses;

    public class Command : ICommand
    {
        private char targetSymbol;
        private IDirection moveDirection;

        private Command(string input)
        {
            this.TranslateInput(input);
        }

        public char TargetSymbol
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

        public IDirection MoveDirection
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

        public static Command Parse(string input)
        {
            return new Command(input);
        }

        private void TranslateInput(string input)
        {
            // TODO: check input not to be less than 3 chars
            input = input.Trim();

            string inputUppercase = input.ToUpper();

            this.TargetSymbol = inputUppercase[0];

            char verticalDirectionLetter = inputUppercase[1];
            char horizontalDirectionLetter = inputUppercase[2];

            this.MoveDirection = new Direction(verticalDirectionLetter, horizontalDirectionLetter);
        }
    }
}
