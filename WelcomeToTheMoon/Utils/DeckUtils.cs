using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelcomeToTheMoon.Utils
{

    public static class DeckUtils
    {
        private static readonly Random rng = new Random();

        public static void ShuffleCards(this List<Cards.Card> pCards)
        {
            int n = pCards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                var value = pCards[k];
                pCards[k] = pCards[n];
                pCards[n] = value;
            }
        }

        public static List<Cards.Card>[] DivideDeck(this List<Cards.Card> pCards, int pDivisions)
        {
            var divisions = new List<Cards.Card>[pDivisions];
            
            for(int i = 0; i < pDivisions; i++)
                divisions[i] = new List<Cards.Card>();

            var index = 0;
            foreach(var card in pCards)
            {
                divisions[index].Add(card);

                index = (index + 1) % pDivisions;
            }

            return divisions;
        }
    }
}
