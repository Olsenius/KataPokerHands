using NUnit.Framework;

namespace KataPokerHands.Test
{
    [TestFixture]
    public class PokerHandTest
    {
        [Test]
        public void Should_find_a_pair_in_a_hand()
        {
            var hand = "2H 5S 2D 9C KD";
            hand.IsPair().ShouldBeTrue();
        }
        
        [Test]
        public void Should_Find_Highest_Card()
        {
            var hand = "2H 5S 2D 9C 3D";
            hand.HighestCard().ShouldEqual(9);
        }
    }
}