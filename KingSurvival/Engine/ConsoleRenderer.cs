namespace KingSurvival.Engine
{
    using System;
    using System.Text;
    using Interfaces;

    public class ConsoleRenderer : IRenderer
    {
        // Singleton
        public ConsoleRenderer()
        {
        }

        public void Render(char[,] matrix)
        {
            Console.Clear();
            Console.Write(this.PrepareToRender(matrix));
        }

        private string PrepareToRender(char[,] matrix)
        {
            StringBuilder result = new StringBuilder();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    result.AppendFormat("{0,2}", matrix[row, col]);
                }

                result.AppendLine();
            }

            return result.ToString();
        }
    }
}
