using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelcomeToTheMoon.Cards
{
    public static class CardDeckGenerator
    {
		public static List<Card> GetSpacecraftCards()
		{
			var cards = new List<Card>();

			cards.Add(new SpacecraftCard { Id = 1, Number = 1, ActionSymbol = Symbol.Energia });
			cards.Add(new SpacecraftCard { Id = 2, Number = 1, ActionSymbol = Symbol.Robot });

			cards.Add(new SpacecraftCard { Id = 3, Number = 2, ActionSymbol = Symbol.Planta });
			cards.Add(new SpacecraftCard { Id = 4, Number = 2, ActionSymbol = Symbol.Robot });

			cards.Add(new SpacecraftCard { Id = 5, Number = 3, ActionSymbol = Symbol.Planificacion });
			cards.Add(new SpacecraftCard { Id = 6, Number = 3, ActionSymbol = Symbol.Astronauta });
			cards.Add(new SpacecraftCard { Id = 7, Number = 3, ActionSymbol = Symbol.Agua });

			cards.Add(new SpacecraftCard { Id = 8, Number = 4, ActionSymbol = Symbol.Planificacion });
			cards.Add(new SpacecraftCard { Id = 9, Number = 4, ActionSymbol = Symbol.Astronauta });
			cards.Add(new SpacecraftCard { Id = 10, Number = 4, ActionSymbol = Symbol.Planta });
			cards.Add(new SpacecraftCard { Id = 11, Number = 4, ActionSymbol = Symbol.Energia });

			cards.Add(new SpacecraftCard { Id = 12, Number = 5, ActionSymbol = Symbol.Planta });
			cards.Add(new SpacecraftCard { Id = 13, Number = 5, ActionSymbol = Symbol.Energia });
			cards.Add(new SpacecraftCard { Id = 14, Number = 5, ActionSymbol = Symbol.Energia });
			cards.Add(new SpacecraftCard { Id = 15, Number = 5, ActionSymbol = Symbol.Robot });
			cards.Add(new SpacecraftCard { Id = 16, Number = 5, ActionSymbol = Symbol.Robot });

			cards.Add(new SpacecraftCard { Id = 17, Number = 6, ActionSymbol = Symbol.Planificacion });
			cards.Add(new SpacecraftCard { Id = 18, Number = 6, ActionSymbol = Symbol.Astronauta });
			cards.Add(new SpacecraftCard { Id = 19, Number = 6, ActionSymbol = Symbol.Agua });
			cards.Add(new SpacecraftCard { Id = 20, Number = 6, ActionSymbol = Symbol.Planta });
			cards.Add(new SpacecraftCard { Id = 21, Number = 6, ActionSymbol = Symbol.Energia });
			cards.Add(new SpacecraftCard { Id = 22, Number = 6, ActionSymbol = Symbol.Robot });

			cards.Add(new SpacecraftCard { Id = 23, Number = 7, ActionSymbol = Symbol.Agua });
			cards.Add(new SpacecraftCard { Id = 24, Number = 7, ActionSymbol = Symbol.Planta });
			cards.Add(new SpacecraftCard { Id = 25, Number = 7, ActionSymbol = Symbol.Planta });
			cards.Add(new SpacecraftCard { Id = 26, Number = 7, ActionSymbol = Symbol.Energia });
			cards.Add(new SpacecraftCard { Id = 27, Number = 7, ActionSymbol = Symbol.Energia });
			cards.Add(new SpacecraftCard { Id = 28, Number = 7, ActionSymbol = Symbol.Robot });

			cards.Add(new SpacecraftCard { Id = 29, Number = 8, ActionSymbol = Symbol.Planificacion });
			cards.Add(new SpacecraftCard { Id = 30, Number = 8, ActionSymbol = Symbol.Astronauta });
			cards.Add(new SpacecraftCard { Id = 31, Number = 8, ActionSymbol = Symbol.Agua });
			cards.Add(new SpacecraftCard { Id = 32, Number = 8, ActionSymbol = Symbol.Planta });
			cards.Add(new SpacecraftCard { Id = 33, Number = 8, ActionSymbol = Symbol.Planta });
			cards.Add(new SpacecraftCard { Id = 34, Number = 8, ActionSymbol = Symbol.Robot });
			cards.Add(new SpacecraftCard { Id = 35, Number = 8, ActionSymbol = Symbol.Robot });

			cards.Add(new SpacecraftCard { Id = 36, Number = 9, ActionSymbol = Symbol.Agua });
			cards.Add(new SpacecraftCard { Id = 37, Number = 9, ActionSymbol = Symbol.Planta });
			cards.Add(new SpacecraftCard { Id = 38, Number = 9, ActionSymbol = Symbol.Planta });
			cards.Add(new SpacecraftCard { Id = 39, Number = 9, ActionSymbol = Symbol.Energia });
			cards.Add(new SpacecraftCard { Id = 40, Number = 9, ActionSymbol = Symbol.Energia });
			cards.Add(new SpacecraftCard { Id = 41, Number = 9, ActionSymbol = Symbol.Robot });

			cards.Add(new SpacecraftCard { Id = 42, Number = 10, ActionSymbol = Symbol.Planificacion });
			cards.Add(new SpacecraftCard { Id = 43, Number = 10, ActionSymbol = Symbol.Astronauta });
			cards.Add(new SpacecraftCard { Id = 44, Number = 10, ActionSymbol = Symbol.Agua });
			cards.Add(new SpacecraftCard { Id = 45, Number = 10, ActionSymbol = Symbol.Planta });
			cards.Add(new SpacecraftCard { Id = 46, Number = 10, ActionSymbol = Symbol.Energia });
			cards.Add(new SpacecraftCard { Id = 47, Number = 10, ActionSymbol = Symbol.Robot });

			cards.Add(new SpacecraftCard { Id = 48, Number = 11, ActionSymbol = Symbol.Planta });
			cards.Add(new SpacecraftCard { Id = 49, Number = 11, ActionSymbol = Symbol.Energia });
			cards.Add(new SpacecraftCard { Id = 50, Number = 11, ActionSymbol = Symbol.Energia });
			cards.Add(new SpacecraftCard { Id = 51, Number = 11, ActionSymbol = Symbol.Robot });
			cards.Add(new SpacecraftCard { Id = 52, Number = 11, ActionSymbol = Symbol.Robot });

			cards.Add(new SpacecraftCard { Id = 53, Number = 12, ActionSymbol = Symbol.Planificacion });
			cards.Add(new SpacecraftCard { Id = 54, Number = 12, ActionSymbol = Symbol.Astronauta });
			cards.Add(new SpacecraftCard { Id = 55, Number = 12, ActionSymbol = Symbol.Planta });
			cards.Add(new SpacecraftCard { Id = 56, Number = 12, ActionSymbol = Symbol.Energia });

			cards.Add(new SpacecraftCard { Id = 57, Number = 13, ActionSymbol = Symbol.Planificacion });
			cards.Add(new SpacecraftCard { Id = 58, Number = 13, ActionSymbol = Symbol.Astronauta });
			cards.Add(new SpacecraftCard { Id = 59, Number = 13, ActionSymbol = Symbol.Agua });

			cards.Add(new SpacecraftCard { Id = 60, Number = 14, ActionSymbol = Symbol.Planta });
			cards.Add(new SpacecraftCard { Id = 61, Number = 14, ActionSymbol = Symbol.Robot });

			cards.Add(new SpacecraftCard { Id = 62, Number = 15, ActionSymbol = Symbol.Energia });
			cards.Add(new SpacecraftCard { Id = 63, Number = 15, ActionSymbol = Symbol.Robot });

			return cards;
		}

		public static List<Card> GetAstraEffectsCards()
		{
			var cards = new List<Card>();

			cards.Add(new AstraEffectCard { Id = 63, Effect = Enums.AstraEffect.A });
			cards.Add(new AstraEffectCard { Id = 64, Effect = Enums.AstraEffect.B });
			cards.Add(new AstraEffectCard { Id = 65, Effect = Enums.AstraEffect.C });

			return cards;
		}
	}
}
