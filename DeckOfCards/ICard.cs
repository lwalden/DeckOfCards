namespace DeckOfCards
{
    interface ICard
    {
        eRank Rank
        { get; }

        eSuit Suit
        { get; }
    }
}
