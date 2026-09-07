using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entity_library;

namespace dao_library
{
    public static class MockDatabase
    {
        public static List<Student> Students { get; set; } = new();

        public static List<Course> Courses { get; set; } = new();

        public static List<entity_library.Activity> Activities { get; set; } = new(); //Se escribio de esta forma "entity_library.Activity" por un error con "Activity" en System.Diagnostics

        public static List<Player> Players { get; set; } = new();

        public static List<Team> Teams { get; set; } = new();

        public static List<Trainer> Trainers { get; set; } = new();

        public static List<User> Users { get; set; } = new();


        static MockDatabase()
        {
            var student1 = new Student { Id = 1, Name = "John Doe", Dni = "12345678A", File = "file1" };
            var student2 = new Student { Id = 2, Name = "Jane Smith", Dni = "87654321B", File = "file2" };

            var course1 = new Course { Id = 1, Name = "Mathematics" };
            var course2 = new Course { Id = 2, Name = "Physics" };

            var activity1 = new entity_library.Activity { Id = 1, Title = "Math Exam", Description = "Final exam for Mathematics", Date = DateTime.Now, TypeActivity = TypeActivity.Exam };
            var activity2 = new entity_library.Activity { Id = 2, Title = "Physics Lab", Description = "Lab session for Physics", Date = DateTime.Now, TypeActivity = TypeActivity.Proyect };

            var user1 = new User { Id = 1, Name = "Pedro", Dni = "1234", Email = "pedro@email.com", PasswordHash = "1234" };

            course1.Activities.Add(activity1);
            course2.Activities.Add(activity2);

            course1.Students.Add(student1);
            course2.Students.Add(student2);

            student1.Courses.Add(course1);
            student2.Courses.Add(course2);

            Students.Add(student1);
            Students.Add(student2);

            Courses.Add(course1);
            Courses.Add(course2);

            Activities.Add(activity1);
            Activities.Add(activity2);
            Users.Add(user1);
        }
    }
}
