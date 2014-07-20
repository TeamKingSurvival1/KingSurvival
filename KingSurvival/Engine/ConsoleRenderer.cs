namespace KingSurvival.Engine
{
    using System;
    using System.Text;
    using Interfaces;

    public sealed class ConsoleRenderer : IRenderer
    {
        private static readonly ConsoleRenderer instance = new ConsoleRenderer();

        private ConsoleRenderer() {}

        public static ConsoleRenderer Instance
        {
            get
            {
                return instance;
            }
        }

        public void Render(char[,] matrix)
        {
            Console.Clear();

            StringBuilder result = new StringBuilder();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    result.AppendFormat("{0,2}", matrix[row, col]);
                }

                result.AppendLine();
            }

            Console.Write(result.ToString());
        }

        public static void PrintMessage(string message)
        {
            Console.Write(message);
        }
    }
}
