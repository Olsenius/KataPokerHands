using NUnit.Framework;

namespace KataPokerHands.Test
{
    [TestFixture]
    public class PokerHandTest
    {
        [Test]
        public void Should_find_a_pair_in_a_hand_when_the_hand_has_two_matching_cards()
        {
            var hand = "2H 5S 2D 9C KD";
            hand.IsPair().ShouldBeTrue();
        }

        [Test]
        public void Should_not_find_a_pair_when_the_hand_does_not_contain_two_matching_cards()
        {
            var hand = "2H 3S 4D 5C 6D";
            hand.IsPair().ShouldBeFalse();
        }

        [TestCase("2H 2S 2D 2C 2D", 2)]
        [TestCase("3H 3S 3D 3C 2D", 3)]
        [TestCase("4H 4S 4D 4C 2D", 4)]
        [TestCase("5H 5S 5D 5C 2D", 5)]
        [TestCase("6H 6S 6D 6C 2D", 6)]
        [TestCase("7H 7S 7D 7C 2D", 7)]
        [TestCase("8H 8S 8D 8C 2D", 8)]
        [TestCase("9H 9S 9D 9C 9D", 9)]
        public void Should_find_highest_card_amongst_cards_identified_by_numbers(string hand, int highest)
        {
            hand.HighestCard().ShouldEqual(highest.ToString());
        }

        [Test]
        public void Ten_should_be_higher_card_than_9()
        {
            "9H 9S 9D 9C TD".HighestCard().ShouldEqual("T");
        }
    }
}