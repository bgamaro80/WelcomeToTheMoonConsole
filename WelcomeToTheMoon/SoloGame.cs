using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelcomeToTheMoon
{
    public class SoloGame
    {
        private List<Cards.Card> mAstraPointCards = new List<Cards.Card>();

        private StateManager StateMng { get; set; } = new();

        private State ActualState { get => (State)StateMng.CurrentState; }

        public void Start()
        {
            //New initial state
            StateMng.Clear();
            StateMng.Next(new State());

            //New inital deck
            ActualState.Deck = new DeckSoloMode();

            //SET LEVEL
            SetLevel();

            ActualState.Lap = 1;
            ActualState.Deck.PrepareSoloMode_FirstLap();

            //First lap
            PlayLap();

            //Secondlap
            Console.Clear();
            Console.WriteLine("Empezando segunda vuelta...");
            Console.ReadLine();
            
            ActualState.Lap = 2;
            ActualState.Deck.PrepareSoloMode_SecondLap(ActualState.AstraScoreCards);

            PlayLap();

            //End
            Console.Clear();
            Console.WriteLine("Finalizada partida ASTRA...");

            //ASTRA SCORE
            WriteAstraLevel();

            bool end = false;
            while (!end)
            {
                var fin = Console.ReadLine();
                if (fin == "fin")
                    end = true;
                else
                    Console.WriteLine("Para salir, escriba 'fin'");
            }
        }

        private void SetLevel()
        {
            int level = 0;
            Astra.AstraLevel astraLevel = new Astra.AstraLevel();
            while(level <= 0)
            {
                Console.Write("Seleccione un nivel para ASTRA (1-Fácil...8-Difícil): ");

                try
                {
                    level = int.Parse(Console.ReadLine() ?? "");
                    astraLevel.SetLevel(level);
                    ActualState.Level = astraLevel;
                }
                catch
                {
                    Console.WriteLine("Nivel incorrecto, vuelta a intentarlo.");
                    level = 0;
                }
            }
        }

        private void PlayLap()
        {
            bool nextTurn = true;

            while (ActualState.Deck.HasCards)
            {
                if (nextTurn)
                {
                    //Prepare next state
                    ActualState.Round++;
                    ActualState.SpacecraftCards.Clear();
                    ActualState.AstraEffectCards.Clear();
                }
                    
                StateMng.Next((State)ActualState.Clone());

                //Draw cards
                var drawThree = 3;

                while (drawThree > 0)
                {
                    var card = ActualState.Deck.DrawCard();

                    if (card is Cards.AstraEffectCard astra)
                        ActualState.AstraEffectCards.Add(astra);
                    else if (card is Cards.SpacecraftCard spacecraft)
                    {
                        ActualState.SpacecraftCards.Add(spacecraft);
                        drawThree--;
                    }
                }

                nextTurn = WriteTurn();
            }
        }

        private bool WriteTurn()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            //ROUND
            WriteRound();

            //ASTRA LEVEL
            WriteAstraLevel();

            //ASTRA EFFECTS
            WriteAstraEffects();

            //SPACECRAFT CARDS
            WriteSpaceCraftCards();

            //USER ACTION
            SelectAstraCard();
            WriteUserCombinations();

            Console.WriteLine();
            Console.Write("Enter para siguiente turno. ('U' para undo, 'S' para volver a seleccionar carta ASTRA): ");
            var line = Console.ReadLine();

            if (line?.ToLower() == "u")
            {
                StateMng.Undo();
                StateMng.Undo();
                return false;
            }
            else if (line?.ToLower() == "s")
            {
                StateMng.Undo();
                return false;
            }

            return true; // true to play next turn
        }

        private void WriteRound()
        {
            var round = $"ASTRA - Lap {ActualState.Lap} - Round {ActualState.Round}";
            Console.WriteLine(round);
            Console.WriteLine(Utils.ConsoleUtils.GetLine(round.Length));
        }

        private void WriteAstraLevel()
        {
            Console.WriteLine();

            var s = $"{ActualState.Level.Level} {ActualState.Level.Name}";
            Console.WriteLine(s);
            Console.WriteLine(Utils.ConsoleUtils.GetLine(32));

            var min = ActualState.Level.MinScore();
            var max = ActualState.Level.MaxScore();

            var symbols = new List<Symbol> { Symbol.Robot, Symbol.Energia, Symbol.Planta, Symbol.Agua, Symbol.Astronauta, Symbol.Planificacion };

            var subTotal = 0;

            foreach (var symbol in symbols)
            {
                SetBackgroundBySymbol(symbol);
                Console.Write(" ");
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Write(" {0,13}: ", symbol.ToString());

                if (ActualState.Level.Scores[symbol] == min)
                    Console.ForegroundColor = ConsoleColor.Green;
                else if(ActualState.Level.Scores[symbol] == max)
                    Console.ForegroundColor = ConsoleColor.Red;
                else
                    Console.ForegroundColor = ConsoleColor.White;

                var symbolScore = ActualState.Level.Scores[symbol];
                var scoredCards = ActualState.AstraScoreCards.Count(c => c.ActionSymbol == symbol);
                var symbolTotal = symbolScore * scoredCards;

                Console.Write(" {0,2}", symbolScore);
                
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" * {0,2} = {1,4}", scoredCards, symbolTotal);

                subTotal += symbolTotal;
            }
            Console.WriteLine("{0,25} = {1,4}", "SubTotal", subTotal);
            Console.WriteLine(Utils.ConsoleUtils.GetLine(32));
        }

        private void WriteAstraEffects()
        {
            if (ActualState.AstraEffectCards.Count > 0)
            {
                Console.WriteLine();

                foreach (var astraEffect in ActualState.AstraEffectCards)
                {
                    if (astraEffect.Effect == Enums.AstraEffect.A)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                    }
                    else if (astraEffect.Effect == Enums.AstraEffect.B)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                    }
                    else if (astraEffect.Effect == Enums.AstraEffect.C)
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }

                    Console.WriteLine($"Efecto ASTRA => {astraEffect.Effect}");
                }
            }
        }

        public void WriteSpaceCraftCards()
        {
            Console.WriteLine();

            int index = 1;

            foreach(var spacecraftCard in ActualState.SpacecraftCards)
            {
                WriteSpacecraftCard(index, spacecraftCard, spacecraftCard);
                index++;
            }
        }

        private static void WriteSpacecraftCard(int pIndex, Cards.SpacecraftCard pNumberCard, Cards.SpacecraftCard pSymbolCard )
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            if (pIndex >= 0)
                Console.Write("{0}) ", pIndex);
            
            Console.Write("{0,2:N0} ", pNumberCard.Number);

            SetBackgroundBySymbol(pSymbolCard.ActionSymbol);

            Console.Write(" ");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(" {0,-13}", pSymbolCard.ActionSymbol.ToString());
        }

        private static void SetBackgroundBySymbol(Symbol pSymbol)
        {
            if (pSymbol == Symbol.Robot)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
            }
            else if (pSymbol == Symbol.Energia)
            {
                Console.BackgroundColor = ConsoleColor.DarkMagenta;
            }
            else if (pSymbol == Symbol.Planta)
            {
                Console.BackgroundColor = ConsoleColor.Green;
            }
            else if (pSymbol == Symbol.Agua)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
            }
            else if (pSymbol == Symbol.Astronauta)
            {
                Console.BackgroundColor = ConsoleColor.DarkYellow;
            }
            else if (pSymbol == Symbol.Planificacion)
            {
                Console.BackgroundColor = ConsoleColor.Magenta;
            }
        }

        private void SelectAstraCard()
        {
            Console.WriteLine();

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            bool selected = false;
            while (!selected)
            {
                Console.Write("Seleccione carta para ASTRA: ");
                var selection = Console.ReadLine() ?? "";

                try
                {
                    var selectedIndex = int.Parse(selection) - 1;

                    ActualState.AstraScoreCards.Add(ActualState.SpacecraftCards[selectedIndex]);
                    ActualState.SpacecraftCards.RemoveAt(selectedIndex);

                    selected = true;
                }
                catch
                {
                    Console.WriteLine("Escriba un valor válido (1, 2 o 3)");
                }
            }
        }

        private void WriteUserCombinations()
        {
            Console.WriteLine();
            var s = "Combinaciones disponibles:";
            Console.WriteLine(s);
            Console.WriteLine(Utils.ConsoleUtils.GetLine(s.Length));

            for(int i = 0; i < ActualState.SpacecraftCards.Count; i++)
            {
                for(int j = 0; j < ActualState.SpacecraftCards.Count; j++)
                {
                    if (i == j)
                        continue;

                    WriteSpacecraftCard(-1, ActualState.SpacecraftCards[i], ActualState.SpacecraftCards[j]);
                }
            }
        }

        private class State : IState
        {
            public int Lap { get; set; } = 1;
            public int Round { get; set; } = 0;
            public List<Cards.SpacecraftCard> SpacecraftCards { get; private set; } = new List<Cards.SpacecraftCard>();
            public List<Cards.AstraEffectCard> AstraEffectCards { get; private set; } = new List<Cards.AstraEffectCard>();

            public List<Cards.SpacecraftCard> AstraScoreCards { get; private set; } = new List<Cards.SpacecraftCard>();

            public Astra.AstraLevel Level { get; set; } = new Astra.AstraLevel();

            public DeckSoloMode Deck { get; set; } = new DeckSoloMode();

            public object Clone()
            {
                State clon = (State)MemberwiseClone();

                clon.SpacecraftCards = SpacecraftCards.Select(c => (Cards.SpacecraftCard)c.Clone()).ToList();
                clon.AstraEffectCards = AstraEffectCards.Select(c => (Cards.AstraEffectCard)c.Clone()).ToList();
                clon.AstraScoreCards = AstraScoreCards.Select(c => (Cards.SpacecraftCard)c.Clone()).ToList();
                clon.Level = (Astra.AstraLevel)Level.Clone();
                clon.Deck = (DeckSoloMode)Deck.Clone();

                return clon;
            }
        }
    }
}
