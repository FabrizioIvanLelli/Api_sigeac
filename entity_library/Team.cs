using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity_library
{
    internal class Team
    {
        private string name = "";
        private string category = "";

        private List<Player> player = new List<Player>();
        private List<Trainer> trainer = new List<Trainer>();

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Category
        {
            get { return category; }
            set { category = value; }
        }

        public List<Player> Players
        {
            get { return player; }
            set { player = value; }
        }

        public List<Trainer> Trainers
        {
            get { return trainer; }
            set { trainer = value; }
        }
    }
}
