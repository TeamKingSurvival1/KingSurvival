namespace KingSurvival
{
    using System;
    using System.Text;

    public abstract class Renderer : IRenderer
    {
        public abstract void Render(char[,] matrix);

        protected string PrepareToRender(char[,] matrix)
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
