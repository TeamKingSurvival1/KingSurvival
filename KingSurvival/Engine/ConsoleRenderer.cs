//-----------------------------------------------------------------------
// <summary>
//     Class file for initializing the <c>ConsoleRenderer</c> type.
// </summary>
// <copyright file="ConsoleRenderer.cs" company="Telerik Academy - OOP 2014 Course">
//     Copyright (c) Telerik Academy - OOP 2014 Course. All rights reserved.
// </copyright>
// <author>
//     Not avaialbe. Refactored by Team King-Survival-1
// </author>
//-----------------------------------------------------------------------
namespace KingSurvival.Engine
{
    using System;
    using System.Text;

    using Interfaces;
    using Formatters;

    public sealed class ConsoleRenderer : IRenderer
    {
        private static readonly ConsoleRenderer InstanceField = new ConsoleRenderer();

        private IFormatter formatter;

        private ConsoleRenderer()
        {
            this.Formatter = new MediumSpacesFormatter();
        }

        public static ConsoleRenderer Instance
        {
            get
            {
                return InstanceField;
            }
        }

        public IFormatter Formatter
        {
            get
            {
                return this.formatter;
            }

            set
            {
                this.formatter = value;
            }
        }

        public static void PrintMessage(string message)
        {
            Console.Write(message);
        }

        public void Render(char[,] matrix)
        {
            Console.Clear();

            StringBuilder result = new StringBuilder();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    result.Append(this.formatter.Format(matrix[row, col]));
                }

                result.AppendLine();
            }

            Console.Write(result.ToString());
        }
    }
}
