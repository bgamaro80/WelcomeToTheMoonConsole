using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WelcomeToTheMoon;
using WelcomeToTheMoon.Cards;
using WelcomeToTheMoon.Utils;

namespace BacktrackingGames.Deck
{
    public class NormalGameDeck
    {
        List<SpacecraftCard>[] mDecks = new List<SpacecraftCard>[3];

        public NormalGameDeck()
        {
            var spaceCards = CardDeckGenerator.GetSpacecraftCards();

            spaceCards.ShuffleCards();
            var decks = spaceCards.DivideDeck(3);

            for (int i = 0; i < decks.Length; i++)
            {
                if (mDecks[i] == null)
                    mDecks[i] = new List<SpacecraftCard>();

                while (mDecks[i].Count < spaceCards.Count() * 5) //max 5 deck laps
                {
                    decks[i].ShuffleCards();
                    mDecks[i].AddRange(decks[i].Select(c => (SpacecraftCard)c.Clone()));
                }
            }
        }

        public SpacecraftTuple GetTurnCardsInfo(int turnIndex, int tupleIndex)
        {
            var flippedCard = (SpacecraftCard)mDecks[tupleIndex].ElementAt(turnIndex);
            var topCard = (SpacecraftCard)mDecks[tupleIndex].ElementAt(turnIndex + 1);
           
            return new SpacecraftTuple(topCard.Number, flippedCard.ActionSymbol, topCard.ActionSymbol);
        }

        public int GetCardCount() => mDecks[0].Count();

        public class SpacecraftTuple
        { 
            public SpacecraftTuple(int number, Symbol actionSymbol, Symbol nextActionSymbol)
            {
                Number = number;
                ActionSymbol = actionSymbol;
                NextActionSymbol = nextActionSymbol;
            }

            public int Number { get; set; }
            public Symbol ActionSymbol { get; set; }
            public Symbol NextActionSymbol { get; set; }

            public override string ToString()
            {
                return $"Tuple: {Number} {Enum.GetName(typeof(Symbol), ActionSymbol)}";
            }
        }
    }
}
