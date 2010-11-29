using NUnit.Framework;

namespace KataPokerHands.Test
{
    [TestFixture]
    public class PokerHandTest
    {
        [TestCase("2H 2S 2D 2C 2D", "2")]
        [TestCase("3H 3S 3D 3C 2D", "3")]
        [TestCase("4H 4S 4D 4C 2D", "4")]
        [TestCase("5H 5S 5D 5C 2D", "5")]
        [TestCase("6H 6S 6D 6C 2D", "6")]
        [TestCase("7H 7S 7D 7C 2D", "7")]
        [TestCase("8H 8S 8D 8C 2D", "8")]
        [TestCase("9H 9S 9D 9C 9D", "9")]
        [TestCase("9H 9S 9D 9C TD", "T")]
        [TestCase("2H JS TD 2C 2D", "J")]
        [TestCase("3H JS QD 3C 2D", "Q")]
        [TestCase("KH JS QD 4C 2D", "K")]
        [TestCase("5H AS 5D 5C KD", "A")]
        public void Should_find_highest_card(string hand, string highest)
        {
            var pokerHand = new PokerHand(hand);
            pokerHand.HighestCard().ShouldEqual(highest);
        }

        [Test]
        public void Should_find_a_pair_in_a_hand_when_the_hand_has_two_matching_cards()
        {
            var hand = new PokerHand("2H 5S 2D 9C KD");
            hand.IsPair().ShouldBeTrue();
        }

        [Test]
        public void Should_not_find_a_pair_when_the_hand_does_not_contain_two_matching_cards()
        {
            var hand = new PokerHand("2H 3S 4D 5C 6D");
            hand.IsPair().ShouldBeFalse();
        }

        [TestCase("2H JS TD AC 2D", "3H JS QD 3C 2D", true)]
        [TestCase("KH JS QD 4C 2D", "5H AS 6D 7C KD", false)]
        public void Should_rank_poker_hands_with_only_high_card_correct(string firstHand, string secondHand, bool firstHandShouldWinn)
        {
            var hand1 = new PokerHand(firstHand);
            var hand2 = new PokerHand(secondHand);
            hand1.Beats(hand2).ShouldEqual(firstHandShouldWinn);
        }

        [Test]
        public void Should_use_second_highest_card_if_highest_cards_are_equal()
        {
            var hand1 = new PokerHand("AD KD");
            var hand2 = new PokerHand("AC 2D");
            hand1.Beats(hand2).ShouldBeTrue();
        }

        [TestCase("2H JS TD AC 2D", "3H JS QD AC 2D", false)]
        [TestCase("KH JS QD 4C 2D", "5H KS 6D 7C KD", true)]
        [TestCase("QH JS 8D 4C 2D", "5H QS 6D 7C 8D", false)]
        public void Should_use_second_highest_card_if_highest_cards_are_equal_test_2(string firstHand, string secondHand, bool firstHandShouldWinn)
        {
            var hand1 = new PokerHand(firstHand);
            var hand2 = new PokerHand(secondHand);
            hand1.Beats(hand2).ShouldEqual(firstHandShouldWinn);
        }
    }
}