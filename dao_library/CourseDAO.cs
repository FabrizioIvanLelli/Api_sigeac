using entity_library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dao_library
{
    public class CourseDAO
    {
        public Course CreateCourse(Course course)
        {
            MockDatabase.Courses.Add(course);
            return course;
        }

        public Course? ReadCourseById(long id)
        {
            return MockDatabase.Courses.FirstOrDefault(c => c.Id == id);
        }

        public List<Course> ReadCourses()
        {
            return MockDatabase.Courses;
        }

        public bool UpdateCourse(Course updatedCourse)
        {
            var existingCourse = ReadCourseById(updatedCourse.Id);

            if (existingCourse != null)
            {
                existingCourse.Name = updatedCourse.Name;

                return true;
            }

            return false;
        }

        public bool DeleteCourse(long id)
        {
            var courseToDelete = ReadCourseById(id);

            if (courseToDelete != null)
            {
                MockDatabase.Courses.Remove(courseToDelete);
                return true;
            }

            return false;
        }
    }
}
