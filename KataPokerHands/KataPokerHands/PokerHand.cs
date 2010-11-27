using System.Collections.Generic;
using System.Linq;

namespace KataPokerHands
{
    public static class PokerHand
    {
        static Dictionary<string, int> cards = new Dictionary<string, int>()
        {
            {"2", 2},
            {"3", 3},
            {"4", 4},
            {"5", 5},
            {"6", 6},
            {"7", 7},
            {"8", 8},
            {"9", 9},
            {"T", 10},
            {"J", 11},
            {"Q", 12},
            {"K", 13},
            {"A", 14},
        };
        public static bool IsPair(this string hand)
        {
            HashSet<int> s = new HashSet<int>();
            foreach (string card in hand.Split(' '))
            {
                if(!s.Add(card[0])){
                    return true;
                }
            }
            return false;
        }

        public static int ToPokerValue(this string card) 
        {
            return cards[card];
        }

        public static string ToPokerStringValue(this int card)
        {
            foreach (KeyValuePair<string, int> kp in cards)
            {
                if (kp.Value == card)
                {
                    return kp.Key;
                }
            }
            return "Q";
        }

        public static string HighestCard(this string hand)
        {
            var cards = hand.Split(' ');
            return cards.Max(card => card[0].ToString().ToPokerValue()).ToPokerStringValue();
        }
    }
}


