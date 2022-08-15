using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WelcomeToTheMoon.Cards;
using WelcomeToTheMoon.Utils;

namespace WelcomeToTheMoon
{
    public class DeckNormalMode : ICloneable
    {
        private List<Cards.Card>[] mCards = new List<Cards.Card>[3];

        private int mTurnIndex = 0;

        public void PrepareInitialState()
        {
            var cards = CardDeckGenerator.GetSpacecraftCards();

            cards.ShuffleCards();

            mCards = cards.DivideDeck(3);

            mCards[0].ShuffleCards();
            mCards[1].ShuffleCards();
            mCards[2].ShuffleCards();
        }

        public void NextTurn()
        {
            mTurnIndex++;

            //Shuffle decks
            if (mTurnIndex == mCards.Length - 1)
            {
                mTurnIndex = 0;

                //Keep last card as first
                for (int i = 0; i < mCards.Length; i++)
                {
                    var lastCard = mCards[i].Last();
                    mCards[i].RemoveAt(mCards[i].Count - 1);

                    mCards[i].ShuffleCards();
                    mCards[i].Insert(0, lastCard);
                }
            }
        }

        /// <summary>
        /// 0 Number of the turn
        /// 1 Symbol of the turn
        /// 2 Symol for the next turn
        /// </summary>
        public Tuple<int, Symbol, Symbol> GetTurnCardInfo(int pDeck)
        {
            var flippedCard = (SpacecraftCard)mCards[pDeck].ElementAt(mTurnIndex);
            var topCard = (SpacecraftCard)mCards[pDeck].ElementAt(mTurnIndex + 1);

            return new Tuple<int, Symbol, Symbol>(topCard.Number, flippedCard.ActionSymbol, topCard.ActionSymbol);
        }

        public object Clone()
        {
            DeckNormalMode clone = (DeckNormalMode)MemberwiseClone();

            clone.mCards = new List<Card>[mCards.Length];
            for(int i = 0; i < mCards.Length; i++)
            {
                clone.mCards[i] = mCards[i].Select(c => (Card)c.Clone()).ToList();
            }

            return clone;
        }
    }
}
