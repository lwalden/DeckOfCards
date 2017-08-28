using System.Collections.ObjectModel;

namespace DeckOfCards
{
    interface IDeck
    {
        ReadOnlyCollection<ICard> Cards
        { get; }

        void Shuffle();

        void Sort();
    }
}
