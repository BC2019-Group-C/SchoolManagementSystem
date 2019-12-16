using SMS.DataSource.Interfaces;
using SMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMS.DataSource.Repository
{
    public class TeacherRepository : ITeacher
    {
        SchoolDBContext _schoolDBContext;

        public TeacherRepository(SchoolDBContext sclDBContext)
        {
            _schoolDBContext = sclDBContext;
        }
        public void CreateTeacher(Teacher teacher)
        {
            _schoolDBContext.Teachers.Add(teacher);
            _schoolDBContext.SaveChanges();
        }

        public void DeleteTeacher(int Id)
        {
            var teacher = _schoolDBContext.Teachers.Where(t => t.Id == Id).FirstOrDefault();

            _schoolDBContext.Teachers.Remove(teacher);
            _schoolDBContext.SaveChanges();
        }

        public ICollection<Teacher> GetAllTeachers()
        {
            var teachers = _schoolDBContext.Teachers.ToList();

            return teachers;
        }

        public Teacher GetTeacherById(int Id)
        {
            var teacher = _schoolDBContext.Teachers.Where(t => t.Id == Id).SingleOrDefault();
            return teacher;
        }

        public int UpdateTeacher(int Id, Teacher teacherObject)
        {
            var teacher = _schoolDBContext.Teachers.Where(t => t.Id == Id).SingleOrDefault();

            if (teacher == null)
            {
                return 0;
            }
            else
            {
                teacher.FirstName = teacherObject.FirstName;
                teacher.LastName = teacherObject.LastName;
                teacher.Gender = teacherObject.Gender;
                teacher.DateOfBirth = teacherObject.DateOfBirth;
                teacher.ContactNumber = teacherObject.ContactNumber;
                _schoolDBContext.SaveChanges();
                return 1;
            }
        }
    }
}
