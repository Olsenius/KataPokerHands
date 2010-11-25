using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KataPokerHands
{
    public static class PokerHand
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
        public static int HighestCard(this string hand)
        {
            return 9;
        }
    }
}


