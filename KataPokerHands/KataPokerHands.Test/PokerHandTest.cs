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
        public void Should_find_highest_card_value(string hand, string highest)
        {
            var pokerHand = new PokerHand(hand);
            pokerHand.HighestCardValue().ShouldEqual(highest);
        }

        [Test]
        public void Should_find_a_pair_in_a_hand_when_the_hand_has_two_matching_cards()
        {
            var hand = new PokerHand("2H 2D");
            hand.IsPair().ShouldBeTrue();
        }

        [Test]
        public void Should_not_find_a_pair_when_the_hand_does_not_contain_two_matching_cards()
        {
            var hand = new PokerHand("2H 3S 4D 5C 6D");
            hand.IsPair().ShouldBeFalse();
        }

        [TestCase("AA", "2C")]
        [TestCase("AA, KK", "AA, 2C")]
        [TestCase("AA, KK, QQ", "AA, KK, 2C")]
        [TestCase("AA, KK, QQ, JJ", "AA, KK, QQ, 2C")]
        [TestCase("AA, KK, QQ, JJ, TT", "AA, KK, QQ, JJ, 2C")]
        [TestCase("KH JS QD 4C 3D", "KH JS QD 4C 2D")]
        public void Beats_should_use_first_unlike_highest_card(string bestHand, string worstHand)
        {
            var hand1 = new PokerHand(bestHand);
            var hand2 = new PokerHand(worstHand);
            hand1.Beats(hand2).ShouldBeTrue();
            hand2.Beats(hand1).ShouldBeFalse();
        }

        [Test]
        public void Pair_should_beat_high_card_only()
        {
            var hand1 = new PokerHand("2D 2C");
            var hand2 = new PokerHand("AA 2H");
            hand1.Beats(hand2).ShouldBeTrue();
            hand2.Beats(hand1).ShouldBeFalse();
        }

        [Test]
        public void Pair_should_beat_higher_pair()
        {
            var hand1 = new PokerHand("AC 2D 2C");
            var hand2 = new PokerHand("2H 3A 3H");
            hand1.Beats(hand2).ShouldBeFalse();
            hand2.Beats(hand1).ShouldBeTrue();
        }

        [Test]
        public void Equal_pairs_should_use_high_card_to_determine_winner()
        {
            var hand1 = new PokerHand("2D 2C AC KC TD");
            var hand2 = new PokerHand("2H 2S AD KC 9C");
            hand1.Beats(hand2).ShouldBeTrue();
            hand2.Beats(hand1).ShouldBeFalse();
        }

        [Test]
        public void Three_of_a_kind_should_beat_pair()
        {
            var hand1 = new PokerHand("2D 2C 2S");
            var hand2 = new PokerHand("AH AS KD");
            hand1.Beats(hand2).ShouldBeTrue();
            hand2.Beats(hand1).ShouldBeFalse();
        }
    }
}