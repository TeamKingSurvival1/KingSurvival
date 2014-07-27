namespace KingSurvival.Engine.Visitors
{
    using System;

    using Interfaces;

    public class BackgroundColorVisitor : ColorChanger, IVisitor
    {
        public BackgroundColorVisitor(ConsoleColor newBackgroundColor)
            : base(newBackgroundColor)
        {
        }

        public void Visit(IAcceptor acceptor)
        {
            Console.BackgroundColor = this.NewColor;
        }
    }
}
