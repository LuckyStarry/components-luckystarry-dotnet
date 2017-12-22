namespace LuckyStarry.Data.Objects
{
    public interface IDbTable : IDbObject, ISqlTextElement
    {
        string Alias { get; }
        string SqlTextAlias { get; }
    }
}