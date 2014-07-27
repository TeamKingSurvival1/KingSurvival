namespace KingSurvival.Interfaces
{
    using System;

    public interface IAcceptor
    {
        void Accept(IVisitor visitor);
    }
}
