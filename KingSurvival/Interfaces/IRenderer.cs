namespace KingSurvival.Interfaces
{
    internal interface IRenderer
    {
        void Render(char[,] matrix);

        void PrintMessage(string message);
    }
}