using System.Collections.Generic;
using System.Linq;

namespace KataPokerHands
{
    public class PokerHand
    {
        private readonly string _hand;

        public PokerHand(string hand)
        {
            _hand = hand;
        }

        public bool Beats(PokerHand other)
        {
            return GetCardValueAsInt(HighestCard()) > GetCardValueAsInt(other.HighestCard());
        }

        public string HighestCard()
        {
            var cards = _hand.Split(' ');
            return GetCardValueAsText(cards.Max(x => GetCardValueAsInt(x)));
        }

        private static string GetCardValueAsText(int card)
        {
            switch (card)
            {
                case 10:
                    return "T";
                case 11:
                    return "J";
                case 12:
                    return "Q";
                case 13:
                    return "K";
                case 14:
                    return "A";
                default:
                    return card.ToString();
            }
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