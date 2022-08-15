using BacktrackingGames.Deck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WelcomeToTheMoon;
using WelcomeToTheMoon.Cards;
using WelcomeToTheMoon.Utils;

namespace BacktrackingGames.Scenarios
{
    public class Scenario1
    {
        protected const int NUM_ROCKETS = 31;

        protected NormalGameDeck mDeck = new NormalGameDeck();

        protected List<RocketFloor> mFloors = new List<RocketFloor>();

        protected int FilledRockets = 0;
        protected int CircledSystemErrors = 0;

        public Scenario1()
        {
            mFloors.Add(new RocketFloor
            {
                Symbol = Symbol.Astronauta,
                Rooms = new List<Room>
                {
                    new Room(3){ Effects = new List<RoomEffect>{ new RoomEffect(Effect.ActiveRocket, 3), new RoomEffect(Effect.RocketActivation, 0), new RoomEffect(Effect.Building, 0) } },
                }
            });
            mFloors.Add(new RocketFloor
            {
                Symbol = Symbol.Astronauta,
                Rooms = new List<Room>
                {
                    new Room(3){ Effects = new List<RoomEffect>{ new RoomEffect(Effect.ActiveRocket, 2), new RoomEffect(Effect.InactiveRocket, 2), new RoomEffect(Effect.ActiveSabotage, 0) } },
                }
            });

            mFloors.Add(new RocketFloor
            {
                Symbol = Symbol.Agua,
                Rooms = new List<Room>
                {
                    new Room(2){ Effects = new List<RoomEffect>{ new RoomEffect(Effect.ActiveRocket, 2), new RoomEffect(Effect.ActiveSabotage, 0) } },
                    new Room(3){ Effects = new List<RoomEffect>{ new RoomEffect(Effect.ActiveRocket, 3), new RoomEffect(Effect.InactiveRocket, 3) } },
                }
            });

            mFloors.Add(new RocketFloor
            {
                Symbol = Symbol.Robot,
                Rooms = new List<Room>
                {
                    new Room(2){ Effects = new List<RoomEffect>{ new RoomEffect(Effect.RocketActivation, 0), new RoomEffect(Effect.Building, 0) } },
                    new Room(3){ Effects = new List<RoomEffect>{ new RoomEffect(Effect.ActiveRocket, 3), new RoomEffect(Effect.Building, 3) } },
                }
            });
            mFloors.Add(new RocketFloor
            {
                Symbol = Symbol.Robot,
                Rooms = new List<Room>
                {
                    new Room(5){ Effects = new List<RoomEffect>{ new RoomEffect(Effect.ActiveRocket, 3), new RoomEffect(Effect.InactiveRocket, 3), new RoomEffect(Effect.ActiveSabotage, 0), new RoomEffect(Effect.ActiveSabotage, 0) } },
                }
            });

            mFloors.Add(new RocketFloor
            {
                Symbol = Symbol.Planificacion,
                Rooms = new List<Room>
                {
                    new Room(6){ Effects = new List<RoomEffect>{ new RoomEffect(Effect.ActiveRocket, 4), new RoomEffect(Effect.InactiveRocket, 4), new RoomEffect(Effect.Building, 0), new RoomEffect(Effect.ActiveSabotage, 0) } },
                }
            });
            mFloors.Add(new RocketFloor
            {
                Symbol = Symbol.Energia,
                Rooms = new List<Room>
                {
                    new Room(5){ Effects = new List<RoomEffect>{ new RoomEffect(Effect.ActiveRocket, 4), new RoomEffect(Effect.InactiveRocket, 4), new RoomEffect(Effect.ActiveSabotage, 0), new RoomEffect(Effect.ActiveSabotage, 0) } },
                    new Room(2){ Effects = new List<RoomEffect>{ new RoomEffect(Effect.ActiveRocket, 3) } },
                    new Room(3){ Effects = new List<RoomEffect>{ new RoomEffect(Effect.ActiveRocket, 2), new RoomEffect(Effect.RocketActivation, 0), new RoomEffect(Effect.Building, 0) } },
                }
            });
            mFloors.Add(new RocketFloor
            {
                Symbol = Symbol.Planta,
                Rooms = new List<Room>
                {
                    new Room(2){ Effects = new List<RoomEffect>{ new RoomEffect(Effect.ActiveRocket, 2), new RoomEffect(Effect.InactiveRocket, 2) } },
                    new Room(2){ Effects = new List<RoomEffect>{ new RoomEffect(Effect.ActiveRocket, 2), new RoomEffect(Effect.RocketActivation, 0) } },
                    new Room(2){ Effects = new List<RoomEffect>{ new RoomEffect(Effect.ActiveRocket, 2), new RoomEffect(Effect.InactiveRocket, 2) } },
                    new Room(2){ Effects = new List<RoomEffect>{ new RoomEffect(Effect.Building, 0), new RoomEffect(Effect.ActiveSabotage, 0) } },
                }
            });
            mFloors.Add(new RocketFloor
            {
                Symbol = Symbol.Comodin,
                Rooms = new List<Room>
                {
                    new Room(2){ Effects = new List<RoomEffect>{ new RoomEffect(Effect.ActiveRocket, 2), new RoomEffect(Effect.Building, 0) } },
                    new Room(2){ Effects = new List<RoomEffect>{ new RoomEffect(Effect.ActiveRocket, 2), new RoomEffect(Effect.Building, 0) } },
                    new Room(2){ Effects = new List<RoomEffect>{ new RoomEffect(Effect.ActiveRocket, 2), new RoomEffect(Effect.Building, 0) } },
                    new Room(2){ Effects = new List<RoomEffect>{ new RoomEffect(Effect.RocketActivation, 0), new RoomEffect(Effect.Building, 0) } },
                }
            });
        }

        public override string ToString()
        {
            var s = "";

            foreach (var floor in mFloors)
                s += $"{floor.ToString()}\n";

            s += "\n";

            s += $"Puntuación: {FilledRockets} cohetes ({GetRocketScore()}) - {GetSystemErrorsScore()} errores = {GetTotalScore()} ({GetExtraFilledRockets()} extras)";

            return s;
        }

        protected int GetRocketScore()
        {
            if (FilledRockets >= 31)
                return 150;
            else if (FilledRockets >= 29)
                return 135;
            else if (FilledRockets >= 27)
                return 120;
            else if (FilledRockets >= 24)
                return 105;
            else if (FilledRockets >= 21)
                return 90;
            else if (FilledRockets >= 18)
                return 75;
            else if (FilledRockets >= 15)
                return 60;
            else if (FilledRockets >= 12)
                return 45;
            else if (FilledRockets >= 9)
                return 30;
            else if (FilledRockets >= 5)
                return 15;

            return 0;
        }

        protected int GetSystemErrorsScore()
        {
            var extra = Math.Max(FilledRockets - NUM_ROCKETS, 0);
            var activeErrorsWithoutRocket = CircledSystemErrors - extra;

            return Math.Max(activeErrorsWithoutRocket, 0) * 5;
        }

        protected int GetTotalScore()
        {
            return GetRocketScore() - GetSystemErrorsScore();
        }

        protected int GetExtraFilledRockets()
        {
            int extra = FilledRockets - NUM_ROCKETS - CircledSystemErrors;
            return Math.Max(extra, 0);
        }

        public bool IsGameEnd(int turnIndex)
        {
            return OutOfCards(turnIndex) || RocketLaunched() || IsAllFilled();
        }

        private bool OutOfCards(int turnIndex)
        {
            return turnIndex >= mDeck.GetCardCount() - 2;
        }

        private bool IsAllFilled()
        {
            foreach (var floor in mFloors)
                foreach (var room in floor.Rooms)
                    if (room.Squares.Any(s => !s.IsFilled))
                        return false;

            return true;
        }

        private bool RocketLaunched()
        {
            return FilledRockets - CircledSystemErrors >= NUM_ROCKETS;
        }

        public NormalGameDeck.SpacecraftTuple GetTurnCardsInfo(int turnIndex, int tupleIndex)
        {
            return mDeck.GetTurnCardsInfo(turnIndex, tupleIndex);
        }

        public List<Square> GetAvailableSquaresForTurnAndTuple(int turnIndex, int tupleIndex)
        {
            List<Square> squares = new List<Square>();
            var tuple = mDeck.GetTurnCardsInfo(turnIndex, tupleIndex);

            foreach (var floor in mFloors.Where(f => f.Symbol == tuple.ActionSymbol || f.Symbol == Symbol.Comodin))
            {
                squares.AddRange(floor.GetAvailableSquaresForNumber(tuple.Number));
            }

            return squares;
        }

        public void PlayCompletedRooms()
        {
            bool atLeastOneApplied = false;

            foreach (var floor in mFloors)
                foreach (var room in floor.Rooms)
                    if (!room.EffectsApplied && room.IsCompleted)
                    {
                        room.EffectsApplied = true;

                        FillRoomRockets(room);
                        ActivateRockets();
                        FillBuildings(room.Effects.Count(e => e.Effect == Effect.Building));

                        atLeastOneApplied = true;
                    }

            if (atLeastOneApplied)
                PlayCompletedRooms();
        }

        private void FillRoomRockets(Room room)
        {
            foreach (var roomEffect in room.Effects.Where(e => e.Effect == Effect.ActiveRocket))
                FilledRockets += roomEffect.Number;
        }

        private void ActivateRockets()
        {
            var availableRooms = new List<Room>();

            foreach (var floor in mFloors)
                foreach (var room in floor.Rooms)
                    if (!room.EffectsApplied && room.Effects.Any(e => e.Effect == Effect.InactiveRocket))
                        availableRooms.Add(room);

            if (availableRooms.Count > 0)
            {
                var random = new Random();
                var selectedRoom = availableRooms.ElementAt(random.Next(availableRooms.Count));
                foreach (var inactiveRocketEffect in selectedRoom.Effects.Where(e => e.Effect == Effect.InactiveRocket))
                    inactiveRocketEffect.ActivateRocket();
            }
        }

        private void FillBuildings(int numBuildings)
        {
            if (numBuildings == 0)
                return;

            var availableSquares = new List<Square>();

            foreach (var floor in mFloors)
                foreach (var room in floor.Rooms.Where(r => !r.IsCompleted))
                    foreach (var square in room.Squares.Where(s => !s.IsFilled))
                        availableSquares.Add(square);


            while (availableSquares.Count > 0 && numBuildings > 0)
            {
                var random = new Random();
                var selectedSquare = availableSquares.ElementAt(random.Next(availableSquares.Count));
                availableSquares.Remove(selectedSquare);
                selectedSquare.WriteNumber(Square.X);
                numBuildings--;
            }
        }

        public class RocketFloor
        {
            public Symbol Symbol { get; set; }

            public List<Room> Rooms { get; set; } = new List<Room>();

            private IEnumerable<Square> GetAllSquares()
            {
                foreach (var room in Rooms)
                    foreach (var s in room.Squares)
                        yield return s;
            }

            public List<Square> GetAvailableSquaresForNumber(int number)
            {
                List<Square> availableSquares = new List<Square>();

                var allSquares = GetAllSquares().ToArray();
                var floorSquareCount = allSquares.Length;

                var minNumber = 0;
                var maxNumber = 16;

                for (int i = 0; i < floorSquareCount; i++)
                {
                    if (allSquares[i].IsFilled)
                        continue;

                    var leftNumber = GetLeftNumberOf(i, allSquares);
                    var rightNumber = GetRightNumberOf(i, allSquares);


                    //Is valid
                    if (leftNumber < number && number < rightNumber)
                    {
                        if (leftNumber > minNumber) minNumber = leftNumber;
                        if (rightNumber < maxNumber) maxNumber = rightNumber;

                        availableSquares.Add(allSquares[i]);
                    }
                }

                if (availableSquares.Count > 0)
                {
                    minNumber++;
                    maxNumber--;

                    var rangeNumbers = maxNumber - minNumber + 1;
                    var numbersForSquare = rangeNumbers / availableSquares.Count;

                    var relativeNumber = number - minNumber;

                    for (int i = 0; i < availableSquares.Count; i++)
                    {
                        var min = i * numbersForSquare;
                        var max = ((i + 1) * numbersForSquare) - 1;

                        availableSquares[i].RoomProbToFill = min <= relativeNumber && relativeNumber <= max ? 1 : 0;
                    }

                    if (availableSquares.All(a => a.RoomProbToFill == 0))
                        availableSquares.Last().RoomProbToFill = 1;
                }

                return availableSquares;
            }

            private int GetLeftNumberOf(int of, Square[] squares)
            {
                for (int i = of - 1; i >= 0; i--)
                    if (squares[i].IsFilledWithNumber)
                        return squares[i].Number;

                return 0;
            }

            private int GetRightNumberOf(int of, Square[] squares)
            {
                for (int i = of + 1; i < squares.Length; i++)
                    if (squares[i].IsFilledWithNumber)
                        return squares[i].Number;

                return 16;
            }

            public override string ToString()
            {
                var s = $"{Enum.GetName(typeof(Symbol), Symbol)}\n";
                s += String.Join(" | ", Rooms.Select(r => r.ToString()));
                return s;
            }
        }

        public class Room
        {
            public Room(int numSquares)
            {
                Squares = new List<Square>(numSquares);
                for (int i = 0; i < numSquares; i++)
                    Squares.Add(new Square());
            }

            public List<Square> Squares { get; private set; }

            public List<RoomEffect> Effects { get; set; } = new List<RoomEffect>();

            public bool IsCompleted => Squares.All(s => s.IsFilled);

            public bool EffectsApplied { get; set; } = false;

            public override string ToString()
            {
                var s = string.Join(" ", Squares.Select(s => s.ToString()));
                s += $" ( {string.Join(",", Effects.Select(e => e.ToString()))} )";
                return s;
            }
        }

        public class RoomEffect
        {
            public RoomEffect(Effect effect, int number)
            {
                Effect = effect;
                Number = number;
            }

            public Effect Effect { get; private set; }
            public int Number { get; }

            public void ActivateRocket()
            {
                if (Effect == Effect.InactiveRocket)
                    Effect = Effect.ActiveRocket;
            }

            public override string ToString()
            {
                switch (Effect)
                {
                    case Effect.Building: return "[X]";
                    case Effect.RocketActivation: return $"<<=";
                    case Effect.ActiveRocket: return $"{Number}:R";
                    case Effect.InactiveRocket: return $"{Number}:r";
                    case Effect.ActiveSabotage: return $"<!>";
                    case Effect.InactiveSabotage: return $"<.>";
                }

                return "";
            }
        }

        public enum Effect
        {
            Building, //X
            RocketActivation,
            ActiveRocket,
            InactiveRocket,
            ActiveSabotage,
            InactiveSabotage
        }

        public class Square
        {
            public const int X = int.MaxValue;
            public const int CLEAR = int.MinValue;

            /// <summary>
            /// minValue = clear
            /// 1 - 15 = filled with number
            /// maxValue = filled with X
            /// </summary>
            public int Number { get; private set; } = CLEAR;
            public bool IsFilled => Number != CLEAR;
            public bool IsFilledWithNumber => Number != CLEAR && Number != X;

            public double RoomProbToFill { get; set; } = 0.0;

            public void WriteNumber(int number)
            {
                if ((number >= 1 && number <= 15) || number == X)
                    Number = number;
                else
                    throw new InvalidDataException($"Imposible rellenar una casilla con el número {number}.");
            }

            public override string ToString()
            {
                if (Number == int.MinValue)
                    return "_";
                else if (Number == int.MaxValue)
                    return "X";
                else
                    return Number.ToString();
            }
        }
    }
}
