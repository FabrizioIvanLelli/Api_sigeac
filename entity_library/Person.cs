using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity_library
{
    public class Person
    {
        private long id;
        private string name = "";
        private int age = 0;
        private string? dni;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Dni
        {
            get { return dni; }
            set { dni = value; }
        }
    }
}


