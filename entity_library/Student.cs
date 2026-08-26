using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity_library
{
    public class Student : Person
    {
        private string file = "";

        private List<Course> courses = new List<Course>();

        public string File
        {
            get { return file; }
            set { file = value; }
        }

        public List<Course> Courses
        {
            get { return courses; }
            set { courses = value; }
        }
    }
}
