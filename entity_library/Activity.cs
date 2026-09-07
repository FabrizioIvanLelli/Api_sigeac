using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity_library
{
    public class Activity
    {
        private long id;
        private string title = "";
        private string? description;
        private DateTime date;
        private TypeActivity typeActivity;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }
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

        public TypeActivity TypeActivity
        {
            get { return typeActivity; }
            set { typeActivity = value; }
        }
    }
}
