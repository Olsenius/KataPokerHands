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

        public string HighestCard()
        {
            var cards = _hand.Split(' ');
            return GetCardValueAsText(cards.Max(x => GetCardValue(x)));
        }

        private int GetCardValue(string card)
        {
            var value = card[0].ToString();

            return _cardValues.First(kv => kv.Key == value).Value;
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

        private Dictionary<string, int> _cardValues = new Dictionary<string, int>() { { "2", 2 }, { "3", 3 }, { "4", 4 }, { "5", 5 }, { "6", 6 }, { "7", 7 }, { "8", 8 }, { "9", 9 }, { "T", 10 }, { "J", 11 }, { "Q", 12 }, { "K", 13 }, { "A", 14 }, };
    }
}