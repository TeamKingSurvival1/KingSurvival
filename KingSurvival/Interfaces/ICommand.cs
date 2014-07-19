namespace KingSurvival.Interfaces
{
    public interface ICommand
    {
        char TargetSymbol { get; }

        IDirection MoveDirection { get; }

    }
}
