

using static BacktrackingGames.Scenarios.Scenario1;

namespace BacktrackingGames
{
    class Program
    {
        static void Main() //Entry point  
        {
            Console.Title = "Welcome To The Moon - BacktrackingGames";

            Scenarios.Scenario1 scenario = new Scenarios.Scenario1();

            int turn = -1;
            int fallos = 0;

            var rnd = new Random();

            while (!scenario.IsGameEnd(turn))
            {
                turn++;

                Console.Clear();
                Console.WriteLine($"Turno: {turn}");

                List<Square> availableSquares = null;
                Deck.NormalGameDeck.SpacecraftTuple selectedTuple = null;

                for (var ti = 0; ti < 3; ti++)
                {
                    var tuple = scenario.GetTurnCardsInfo(turn, ti);
                    var availableSquaresForTuple = scenario.GetAvailableSquaresForTurnAndTuple(turn, ti);

                    if (selectedTuple == null || availableSquares == null || availableSquaresForTuple.Count > availableSquares.Count)
                    {
                        selectedTuple = tuple;
                        availableSquares = availableSquaresForTuple;
                    }
                }

                Console.WriteLine(selectedTuple.ToString());

                if (availableSquares.Count == 0)
                {
                    fallos++;
                    Console.WriteLine($"Fallos:{fallos}");
                    continue;
                }


                var square = availableSquares.FirstOrDefault(s => s.RoomProbToFill == 1);

                if (square != null)
                {
                    square.WriteNumber(selectedTuple.Number);

                    scenario.PlayCompletedRooms();
                Console.WriteLine(scenario.ToString());
                }
                else
                {
                    fallos++;
                    Console.WriteLine($"Fallos:{fallos}");
                }

                Console.ReadLine();
            }

            Console.Clear();
            Console.WriteLine(scenario.ToString());
            Console.WriteLine($"Turno: {turn} Fallos:{fallos}");

        }
    }
}