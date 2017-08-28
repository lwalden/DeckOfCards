using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DeckOfCards
{
    public class Deck: IDeck
    {
        private List<ICard> _cards = new List<Card>();

        public ReadOnlyCollection<ICard> Cards
        {
            get
            {
                return _cards.AsReadOnly();
            }
        }

        public void Shuffle()
        { }

        public void Sort()
        { }

        public Deck()
        {
            foreach (eSuit suit in Enum.GetValues(typeof(eSuit)))
            {
                foreach (eRank rank in Enum.GetValues(typeof(eRank)))
                {
                    _cards.Add(new Card(rank, suit));
                }
            }
        }
    }
}
