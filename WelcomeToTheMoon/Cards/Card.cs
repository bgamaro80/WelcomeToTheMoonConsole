using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelcomeToTheMoon.Cards
{
    public class Card : ICloneable
    {
        public int Id { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
