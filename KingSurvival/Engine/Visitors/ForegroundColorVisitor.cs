namespace KingSurvival.Engine.Visitors
{
    using System;

    using KingSurvival.Interfaces;

    public class ForegroundColorVisitor : ColorChanger, IVisitor
    {
        public ForegroundColorVisitor(ConsoleColor newForegroundColor)
            : base(newForegroundColor)
        {
        }

        public void Visit(IAcceptor acceptor)
        {
            Console.ForegroundColor = this.NewColor;
        }
    }
}
