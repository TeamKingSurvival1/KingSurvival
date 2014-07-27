namespace KingSurvival.Engine.Visitors
{
    using System;

    public abstract class ColorChanger
    {
        public ColorChanger(ConsoleColor newColor)
        {
            this.NewColor = newColor;
        }

        public ConsoleColor NewColor { get; private set; }
    }
}
