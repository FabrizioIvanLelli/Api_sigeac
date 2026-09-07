using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity_library
{
    public class Course
    {
        private long id;
        private string name = "";

        private List<Student> students = new List<Student>();
        private List<Activity> activities = new List<Activity>();

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

        public List<Student> Students
        {
            get { return students; }
            set { students = value; }
        }

        public List<Activity> Activities
        {
            get { return activities; }
            set{ activities = value; }
        }
    }
}
