using System;
using System.Collections.Generic;
using System.Linq;

namespace KataPokerHands
{
    public class PokerHand
    {
        private readonly string _hand;

        private enum HandType { HighCard, Pair, ThreeOfAKind }
        public IEnumerable<string> CardsUsedInBestHand { get; private set; }

        public PokerHand(string hand)
        {
            _hand = hand;
        }

        public bool Beats(PokerHand other)
        {
            if (TypesArentEqual(other))
            {
                return MyTypeIsBetter(other);
            }
            if (TypeOfHand() == HandType.Pair)
            {
                return MyPairIsBetter(other);
            }
            return MyHighCardIsBetter(other);
        }

        private HandType TypeOfHand()
        {
            if (IsThreeOfAKind())
                return HandType.ThreeOfAKind;

            if (IsPair())
                return HandType.Pair;
            return HandType.HighCard;
        }

        private bool IsThreeOfAKind()
        {
            return CardsOrderedByValue()
                .GroupBy(GetCardValueAsInt)
                .Any(group => group.Count() == 3);
        }

        private bool TypesArentEqual(PokerHand other)
        {
            return TypeOfHand() != other.TypeOfHand();
        }

        private bool MyTypeIsBetter(PokerHand other)
        {
            return TypeOfHand() > other.TypeOfHand();
        }

        private bool MyPairIsBetter(PokerHand other)
        {
            var myCardValue = GetCardValueAsInt(CardsUsedInBestHand.First());
            var otherHandCardValue = GetCardValueAsInt(other.CardsUsedInBestHand.First());
            if (myCardValue == otherHandCardValue)
            {
                return MyHighCardIsBetter(other);
            }
            return myCardValue >= otherHandCardValue;
        }

        private bool MyHighCardIsBetter(PokerHand other)
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
                    CardsUsedInBestHand = CardsOrderedByValue().Where(x => GetCardValueAsInt(x) == GetCardValueAsInt(card));
                    return true;
                }
            }
            return false;
        }
    }
}