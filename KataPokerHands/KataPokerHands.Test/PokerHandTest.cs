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

        [TestCase("9H 9S 9D 9C 9D",9)]
        public void Should_find_highest_card_amongst_non_face_cards(string hand, int highest)
        {
            hand.HighestCard().ShouldEqual(highest);
        }
    }
}