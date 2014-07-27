namespace KingSurvival
{
    using Engine;

    /// <summary>
    /// Represents the start of the application.
    /// </summary>
    internal sealed class StartGame
    {
        private static void Main()
        {
            var engine = new KingSurvivalEngine();
            engine.Run();
        }
    }
}