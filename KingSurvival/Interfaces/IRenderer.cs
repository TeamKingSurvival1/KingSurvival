namespace KingSurvival.Interfaces
{
    internal interface IRenderer : IAcceptor
    {
        void Render(char[,] matrix);

        void PrintMessage(string message);
    }
}