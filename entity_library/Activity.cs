using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity_library
{
    public class Activity
    {
        private string title = "";
        private string? description;
        private DateTime date;
        private List<TypeActivity> types = new List<TypeActivity>();

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Description
        {
            get { return title; }
            set { title = value; }
        }

        public DateTime Date 
        {
            get { return date; }
            set { date = value; }
        }

        public List<TypeActivity> Types 
        {  
            get { return types; } 
            set { types = value; }
        }
    }
}
