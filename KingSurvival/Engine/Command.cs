//-----------------------------------------------------------------------
// <summary>
//     Class file for initializing the <c>Command</c> type.
// </summary>
// <copyright file="Command.cs" company="Telerik Academy - OOP 2014 Course">
//     Copyright (c) Telerik Academy - OOP 2014 Course. All rights reserved.
// </copyright>
// <author>
//     Not avaialbe. Refactored by Team King-Survival-1
// </author>
//-----------------------------------------------------------------------
namespace KingSurvival.Engine
{
    using System;

    using Engine.Translators;
    using GameplayClasses;
    using Interfaces;

    /// <summary>
    /// Represents the user's command.
    /// </summary>
    public class Command : ICommand
    {
        private char targetSymbol;
        private IDirection moveDirection;

        private Command(string input)
        {
            this.TranslateInput(new NormalTranslate(), input);
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
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException("input", "Input command cannot be null or empty.");
            }

            if (input.Length != 3)
            {
                throw new ArgumentOutOfRangeException("input", "Input command must be 3 characters long.");
            }

            return new Command(input);
        }

        private void TranslateInput(ITranslateStrategy strategy, string input)
        {
            input = input.Trim();

            string translatedInput = strategy.Translate(input);

            this.TargetSymbol = translatedInput[0];

            char verticalDirectionLetter = translatedInput[1];
            char horizontalDirectionLetter = translatedInput[2];

            this.MoveDirection = new Direction(verticalDirectionLetter, horizontalDirectionLetter);
        }
    }
}
