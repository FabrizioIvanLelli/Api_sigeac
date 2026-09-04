using entity_library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dao_library
{
    internal class CourseDAO
    {
        public Course CreateCourse(Course course)
        {
            MockDatabase.Courses.Add(course);
            return course;
        }

        public Course? ReadCourseByName(string name)
        {
            return MockDatabase.Courses.FirstOrDefault(s => s.Name == name);
        }

        public List<Course> ReadCourses()
        {
            return MockDatabase.Courses;
        }

        public bool UpdateCourse(Course updatedCourse)
        {
            var existingCourse = ReadCourseByName(updatedCourse.Name);

            if (existingCourse != null)
            {
                existingCourse.Name = updatedCourse.Name;

                return true;
            }

            return false;
        }

        public bool DeleteCourse(string name)
        {
            var courseToDelete = ReadCourseByName(name);

            if (courseToDelete != null)
            {
                MockDatabase.Courses.Remove(courseToDelete);
                return true;
            }

            return false;
        }
    }
}
