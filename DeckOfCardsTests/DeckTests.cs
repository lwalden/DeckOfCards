using NUnit.Framework;
using System;
using System.Linq;

namespace DeckOfCards.Tests
{
    [TestFixture]
    public class DeckTests
    {
        Random random;
        Deck deck;

        [SetUp]
        public void Init()
        {
            random = new Random(1);
            deck = new Deck(random);
        }

        [Test]
        public void Should_Have52Cards()
        {
            Assert.That(deck.Cards.Count, Is.EqualTo(52));
        }

        [Test]
        public void Should_HaveOneOfEachCard([Values()] eSuit suit, [Values()] eRank rank)
        {
            Assert.That(deck.Cards.SingleOrDefault(c => c.Suit == suit && c.Rank == rank), Is.Not.Null);
        }

        [Test]
        public void Shuffle_Should_ReorderDeck()
        {
            var clone = deck.Cards.ToList();

            Assert.That(deck.Cards, Is.EqualTo(clone));

            deck.Shuffle();

            Assert.That(deck.Cards, Is.Not.EqualTo(clone));
            Assert.That(deck.Cards, Is.EquivalentTo(clone));
        }

        [Test]
        public void Shuffle_Should_HaveDifferentOrder_When_SameInitalOrder()
        {
            deck.Sort();
            deck.Shuffle();

            var clone = deck.Cards.ToList();

            deck.Sort();
            deck.Shuffle();

            Assert.That(deck.Cards, Is.Not.EqualTo(clone));
            Assert.That(deck.Cards, Is.EquivalentTo(clone));
        }

        [Test]
        public void Sort_Should_SortAscendingBySuitThenRank([Values()] eSuit suit, [Values()] eRank rank)
        {
            deck.Shuffle();
            deck.Sort();

            var expectedIndex = (int)suit * 13 + (int)rank;
            var card = deck.Cards[expectedIndex];

            Assert.That(card.Rank, Is.EqualTo(rank));
            Assert.That(card.Suit, Is.EqualTo(suit));
        }
    }
}
