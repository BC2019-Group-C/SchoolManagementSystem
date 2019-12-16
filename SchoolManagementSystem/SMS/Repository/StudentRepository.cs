using SMS.DataSource.Interfaces;
using SMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMS.DataSource.Repository
{
    public class StudentRepository : IStudent
    {
        SchoolDBContext _schoolDBContext;

        public StudentRepository(SchoolDBContext sclDBContext)
        {
            _schoolDBContext = sclDBContext;
        }

        public void CreateStudent(Student student)
        {
            _schoolDBContext.Students.Add(student);
            _schoolDBContext.SaveChanges();
        }

        public void DeleteStudent(int Id)
        {
            var student = _schoolDBContext.Students.Where(a => a.Id == Id).FirstOrDefault();

            _schoolDBContext.Students.Remove(student);
            _schoolDBContext.SaveChanges();
        }

        public ICollection<Student> GetAllStudent()
        {
            var students = _schoolDBContext.Students.ToList();

            return students;
        }

        public Student GetStudentById(int Id)
        {
            var student = _schoolDBContext.Students.Where(s => s.Id == Id).SingleOrDefault();
            return student;
        }

        public int UpdateStudent(int Id, Student studentObject)
        {
            var student = _schoolDBContext.Students.Where(s => s.Id == Id).SingleOrDefault();

            if (student == null)
            {
                return 0;
            }
            else
            {
                student.FirstName = studentObject.FirstName;
                student.LastName = studentObject.LastName;
                student.Gender = studentObject.Gender;
                student.DateOfBirth = studentObject.DateOfBirth;
                student.ContactNumber = studentObject.ContactNumber;
                _schoolDBContext.SaveChanges();
                return 1;
            }
        }
    }
}
