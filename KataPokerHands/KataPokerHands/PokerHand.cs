using System.Collections.Generic;
using System.Linq;

namespace KataPokerHands
{
    public class PokerHand
    {
        public enum handType { HighCard, Pair, TreeOfAKind, Stragiht, Flush, FullHouse, FourOfAKind, StraightFlush }
        private readonly string _hand;

        public PokerHand(string hand)
        {
            _hand = hand;
        }

        public handType typeOfHand()
        {
            if (IsPair())
            {
                return handType.Pair;
            }
            return handType.HighCard;
        }
        public bool highCardBeats(PokerHand other)
        {
            var myCards = CardsOrderedByValue().Select(GetCardValueAsInt).ToArray();
            var otherCards = other.CardsOrderedByValue().Select(GetCardValueAsInt).ToArray();

            for (int i = 0; i < otherCards.Length; i++)
            {
                if (myCards[i] != otherCards[i])
                    return myCards[i] >= otherCards[i];
            }
            return false;
        }
        public bool Beats(PokerHand other)
        {
            if (typeOfHand() != other.typeOfHand())
            {
                return typeOfHand() > other.typeOfHand();
            }
            return highCardBeats(other);
        }

        public string HighestCardValue()
        {
            return CardsOrderedByValue().First().Substring(0, 1);
        }

        private IEnumerable<string> CardsOrderedByValue()
        {
            return _hand.Split(' ').ToList().OrderByDescending(GetCardValueAsInt);
        }

        private static int GetCardValueAsInt(string card)
        {
            var cardValue = card[0].ToString();
            switch (cardValue)
            {
                case "T":
                    return 10;
                case "J":
                    return 11;
                case "Q":
                    return 12;
                case "K":
                    return 13;
                case "A":
                    return 14;
                default:
                    return int.Parse(cardValue);
            }
        }

        public bool IsPair()
        {
            HashSet<int> s = new HashSet<int>();
            foreach (string card in _hand.Split(' '))
            {
                if (!s.Add(card[0]))
                {
                    return true;
                }
            }
            return false;
        }
    }
}