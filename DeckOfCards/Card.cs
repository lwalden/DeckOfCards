using System;

namespace DeckOfCards
{
    public class Card : ICard
    {
        public eRank Rank
        { get; private set; }

        public eSuit Suit
        { get; private set; }

        public Card(eRank rank, eSuit suit)
        {
            Rank = rank;
            Suit = suit;
        }
    }
}
