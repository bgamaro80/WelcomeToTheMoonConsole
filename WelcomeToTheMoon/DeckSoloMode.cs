using System;

using WelcomeToTheMoon.Cards;
using WelcomeToTheMoon.Utils;

namespace WelcomeToTheMoon
{
	public class DeckSoloMode : ICloneable
	{
		private List<Card> mCards = new List<Card>();

		public void PrepareSoloMode_FirstLap()
		{
			mCards.Clear();

			var spaceCraftCards = CardDeckGenerator.GetSpacecraftCards();
			var astraEffectCards = CardDeckGenerator.GetAstraEffectsCards();

			spaceCraftCards.ShuffleCards();
			astraEffectCards.ShuffleCards();

			var divisions = spaceCraftCards.DivideDeck(3);

			divisions[2].AddRange(astraEffectCards);
			divisions[2].ShuffleCards();

			mCards.AddRange(divisions[0]);
			mCards.AddRange(divisions[1]);
			mCards.AddRange(divisions[2]);
		}

		public void PrepareSoloMode_SecondLap(List<Cards.SpacecraftCard> pAstraScoreCards)
		{
			mCards.Clear();

			var spacecraftCards = CardDeckGenerator.GetSpacecraftCards();

			spacecraftCards.RemoveAll(space => pAstraScoreCards.Any(astra => astra.Id == space.Id));

			mCards.AddRange(spacecraftCards);

			mCards.AddRange(CardDeckGenerator.GetAstraEffectsCards());

			mCards.ShuffleCards();
		}

		public bool HasCards => mCards.Count > 0;

		public Card DrawCard()
		{
			var card = mCards[0];
			mCards.RemoveAt(0);
			return card;
		}

        public object Clone()
        {
			DeckSoloMode clone = (DeckSoloMode)MemberwiseClone();

			clone.mCards = mCards.Select(c => (Card)c.Clone()).ToList();

			return clone;
		}
    }
}
