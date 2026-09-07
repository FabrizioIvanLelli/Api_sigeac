using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entity_library;

namespace dao_library
{
    public class StudentDAO
    {
        public Student CreateStudent(Student student)
        {
            MockDatabase.Students.Add(student);
            return student;
        }

        public Student? ReadStudentById(long id)
        {
            return MockDatabase.Students.FirstOrDefault(s => s.Id == id);
        }

        public List<Student> ReadStudents()
        {
            return MockDatabase.Students;
        }

        public bool UpdateStudent(Student updatedStudent)
        {
            var existingStudent = ReadStudentById(updatedStudent.Id);

            if (existingStudent != null)
            {
                existingStudent.Name = updatedStudent.Name;
                existingStudent.Age = updatedStudent.Age;
                existingStudent.Dni = updatedStudent.Dni;

                existingStudent.Courses = updatedStudent.Courses;

                return true; 
            }

            return false; 
        }

        public bool DeleteStudent(long id)
        {
            var studentToDelete = ReadStudentById(id);

            if (studentToDelete != null)
            {
                MockDatabase.Students.Remove(studentToDelete);
                return true;
            }

            return false;
        }
    }
}
