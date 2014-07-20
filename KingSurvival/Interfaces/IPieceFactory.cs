namespace KingSurvival.Interfaces
{
    using GameplayClasses;

    public interface IPieceFactory
    {
        Pawn[] CreatePawns();

        King CreateKing();
    }
}
