using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DeckOfCards
{
    public class Deck
    {
        static Random _random;
        private List<Card> _cards = new List<Card>();

        public ReadOnlyCollection<Card> Cards
        {
            get
            {
                return _cards.AsReadOnly();
            }
        }

        public void Shuffle()
        {
            //fisher-yates-shuffle
            var count = _cards.Count;
            for (int i = 0; i < count; i++)
            {
                int r = i + _random.Next(count - i);
                var temp = _cards[r];
                _cards[r] = _cards[i];
                _cards[i] = temp;
            }
        }

        public void Sort()
        {
            _cards = _cards.OrderBy(c => c.Rank).OrderBy(c => c.Suit).ToList();
        }

        public Deck(Random random)
        {
            _random = random;
            
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
