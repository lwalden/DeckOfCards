using NUnit.Framework;
using System.Linq;

namespace DeckOfCards.Tests
{
    [TestFixture]
    public class CardTests
    {
        [Test]
        public void ShouldHaveExpectedProperties([Values()] eSuit suit, [Values()] eRank rank)
        {
            var card = new Card(rank, suit);
            
            Assert.That(card.Rank, Is.EqualTo(rank));
            Assert.That(card.Suit, Is.EqualTo(suit));
        }
    }
}
