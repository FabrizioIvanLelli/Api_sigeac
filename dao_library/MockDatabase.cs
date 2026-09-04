using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entity_library;

namespace dao_library
{
    internal static class MockDatabase
    {
        public static List<Student> Students { get; set; } = new();

        public static List<Course> Courses { get; set; } = new();

        public static List<entity_library.Activity> Activities { get; set; } = new(); //Se escribio de esta forma "entity_library.Activity" por un error con "Activity" en System.Diagnostics

        public static List<Player> Players { get; set; } = new();

        public static List<Team> Teams { get; set; } = new();

        public static List<Trainer> Trainers { get; set; } = new();
    }
}
