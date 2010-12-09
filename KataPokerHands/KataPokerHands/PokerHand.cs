using System;
using System.Collections.Generic;
using System.Linq;

namespace KataPokerHands
{
    public class PokerHand
    {
        private readonly string _hand;

        public enum HandType { HighCard, Pair, ThreeOfAKind }
        public IEnumerable<string> CardsUsedInBestHand { get; private set; }

        public PokerHand(string hand)
        {
            _hand = hand;
        }

        public bool Beats(PokerHand other)
        {
            if (TypesArentEqual(other))
                return MyTypeIsBetter(other);

            if (TypeOfHand == HandType.ThreeOfAKind)
                return MyMatchingCardsAreBetter(other);

            if (TypeOfHand == HandType.Pair)
                return MyMatchingCardsAreBetter(other);

            return MyHighCardIsBetter(other);
        }

        public HandType TypeOfHand
        {
            get
            {
                if (IsThreeOfAKind())
                    return HandType.ThreeOfAKind;

                if (IsPair())
                    return HandType.Pair;

                return HandType.HighCard;
            }
        }

        private bool TypesArentEqual(PokerHand other)
        {
            return TypeOfHand != other.TypeOfHand;
        }

        private bool MyTypeIsBetter(PokerHand other)
        {
            return TypeOfHand > other.TypeOfHand;
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
            return HaveNumberOfMatchingCards(2);
        }

        private bool IsThreeOfAKind()
        {
            return HaveNumberOfMatchingCards(3);
        }

        private bool HaveNumberOfMatchingCards(int numberOfmatchingCards)
        {
            var groupsOfcards = CardsOrderedByValue().GroupBy(GetCardValueAsInt);

            if (groupsOfcards.Any(x => x.Count() == numberOfmatchingCards))
            {
                CardsUsedInBestHand = groupsOfcards.FirstOrDefault(x => x.Count() == numberOfmatchingCards);
                return true;
            }
            return false;
        }

        private bool MyMatchingCardsAreBetter(PokerHand other)
        {
            var myCardsValue = GetCardValueAsInt(CardsUsedInBestHand.FirstOrDefault());
            var otherCardsValue = GetCardValueAsInt(other.CardsUsedInBestHand.FirstOrDefault());
            if (myCardsValue != otherCardsValue)
                return myCardsValue > otherCardsValue;
            return MyHighCardIsBetter(other);
        }

    }
}