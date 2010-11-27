using System.Collections.Generic;
using System.Linq;

namespace KataPokerHands
{
    public static class PokerHandStringExtensions
    {
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
    }
}


