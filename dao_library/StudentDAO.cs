using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entity_library;

namespace dao_library
{
    internal class StudentDAO
    {
        public Student CreateStudent(Student student)
        {
            MockDatabase.Students.Add(student);
            return student;
        }

        public Student? ReadStudentById(string fileId)
        {
            return MockDatabase.Students.FirstOrDefault(s => s.File == fileId);
        }

        public List<Student> ReadStudents()
        {
            return MockDatabase.Students;
        }

        public bool UpdateStudent(Student updatedStudent)
        {
            var existingStudent = ReadStudentById(updatedStudent.File);

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

        public bool DeleteStudent(string fileId)
        {
            var studentToDelete = ReadStudentById(fileId);

            if (studentToDelete != null)
            {
                MockDatabase.Students.Remove(studentToDelete);
                return true;
            }

            return false;
        }
    }
}
