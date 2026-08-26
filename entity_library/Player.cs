using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity_library
{
    internal class Player : Person
    {
        private int number = 0;

        public int Number
        {
            get { return number; }
            set { number = value; }
        }
    }
}
