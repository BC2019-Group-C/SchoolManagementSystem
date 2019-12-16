using SMS.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.DataSource.Interfaces
{
    public interface IStudent
    {
        ICollection<Student> GetAllStudent();

        Student GetStudentById(int Id);

        void CreateStudent(Student studentObj);

        int UpdateStudent(int Id, Student studentObj);

        void DeleteStudent(int Id);
    }
}
