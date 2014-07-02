namespace KingSurvival
{
    using System;

    public class ConsoleRenderer : Renderer, IRenderer
    {
        private static readonly IRenderer instance;

        static ConsoleRenderer()
        {
            instance = new ConsoleRenderer();
        }

        private ConsoleRenderer() { }

        public static IRenderer Instance
        {
            get
            {
                return instance;
            }
        }

        public override void Render(char[,] matrix)
        {
            Console.Clear();
            Console.Write(this.PrepareToRender(matrix));
        }
    }
}
