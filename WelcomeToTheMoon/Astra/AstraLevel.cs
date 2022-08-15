using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelcomeToTheMoon.Astra
{
    public class AstraLevel : ICloneable
    {
        public string Name { get; set; } = "";
        public int Level { get; set; }

        public Dictionary<Symbol, int> Scores { get; set;} = new Dictionary<Symbol, int>();
        
        public void SetLevel(int pLevel)
        { 
            switch (pLevel)
            {
                case 1:
                    Name = "KATHERINE";
                    Level= 1;
                    Scores.Add(Symbol.Robot, 2);
                    Scores.Add(Symbol.Energia, 3);
                    Scores.Add(Symbol.Planta, 2);
                    Scores.Add(Symbol.Agua, 3);
                    Scores.Add(Symbol.Astronauta, 1);
                    Scores.Add(Symbol.Planificacion, 4);
                    break;

                case 2:
                    Name = "ALEXEI";
                    Level = 2;
                    Scores.Add(Symbol.Robot, 2);
                    Scores.Add(Symbol.Energia, 3);
                    Scores.Add(Symbol.Planta, 3);
                    Scores.Add(Symbol.Agua, 2);
                    Scores.Add(Symbol.Astronauta, 4);
                    Scores.Add(Symbol.Planificacion, 3);
                    break;

                case 3:
                    Name = "MARGARET";
                    Level = 3;
                    Scores.Add(Symbol.Robot, 5);
                    Scores.Add(Symbol.Energia, 4);
                    Scores.Add(Symbol.Planta, 2);
                    Scores.Add(Symbol.Agua, 2);
                    Scores.Add(Symbol.Astronauta, 2);
                    Scores.Add(Symbol.Planificacion, 3);
                    break;

                case 4:
                    Name = "FRANKLIN";
                    Level = 4;
                    Scores.Add(Symbol.Robot, 2);
                    Scores.Add(Symbol.Energia, 6);
                    Scores.Add(Symbol.Planta, 4);
                    Scores.Add(Symbol.Agua, 3);
                    Scores.Add(Symbol.Astronauta, 3);
                    Scores.Add(Symbol.Planificacion, 2);
                    break;

                case 5:
                    Name = "SERGEI";
                    Level = 5;
                    Scores.Add(Symbol.Robot, 4);
                    Scores.Add(Symbol.Energia, 4);
                    Scores.Add(Symbol.Planta, 4);
                    Scores.Add(Symbol.Agua, 4);
                    Scores.Add(Symbol.Astronauta, 4);
                    Scores.Add(Symbol.Planificacion, 3);
                    break;

                case 6:
                    Name = "STEPHANIE";
                    Level = 6;
                    Scores.Add(Symbol.Robot, 6);
                    Scores.Add(Symbol.Energia, 2);
                    Scores.Add(Symbol.Planta, 4);
                    Scores.Add(Symbol.Agua, 5);
                    Scores.Add(Symbol.Astronauta, 4);
                    Scores.Add(Symbol.Planificacion, 4);
                    break;

                case 7:
                    Name = "THOMAS";
                    Level = 7;
                    Scores.Add(Symbol.Robot, 5);
                    Scores.Add(Symbol.Energia, 4);
                    Scores.Add(Symbol.Planta, 3);
                    Scores.Add(Symbol.Agua, 6);
                    Scores.Add(Symbol.Astronauta, 5);
                    Scores.Add(Symbol.Planificacion, 4);
                    break;

                case 8:
                    Name = "PEGGY";
                    Level = 8;
                    Scores.Add(Symbol.Robot, 5);
                    Scores.Add(Symbol.Energia, 3);
                    Scores.Add(Symbol.Planta, 6);
                    Scores.Add(Symbol.Agua, 3);
                    Scores.Add(Symbol.Astronauta, 6);
                    Scores.Add(Symbol.Planificacion, 6);
                    break;

                default:
                    throw new Exception("Level must be between 1 and 8");
            }
        }

        public int MinScore()
        {
            int min = Math.Min(Scores[Symbol.Robot], Scores[Symbol.Energia]);
            min = Math.Min(Scores[Symbol.Planta], min);
            min = Math.Min(Scores[Symbol.Agua], min);
            min = Math.Min(Scores[Symbol.Astronauta], min);
            min = Math.Min(Scores[Symbol.Planificacion], min);
            return min;
        }

        public int MaxScore()
        {
            int max = Math.Max(Scores[Symbol.Robot], Scores[Symbol.Energia]);
            max = Math.Max(Scores[Symbol.Planta], max);
            max = Math.Max(Scores[Symbol.Agua], max);
            max = Math.Max(Scores[Symbol.Astronauta], max);
            max = Math.Max(Scores[Symbol.Planificacion], max);
            return max;
        }

        public object Clone()
        {
            AstraLevel clon = (AstraLevel)MemberwiseClone();

            clon.Scores = Scores.ToDictionary(entry => entry.Key, entry => entry.Value);

            return clon;
        }
    }
}
