namespace KingSurvival.Interfaces
{
    using System;

    public interface IVisitor
    {
        void Visit(IAcceptor acceptor);
    }
}
