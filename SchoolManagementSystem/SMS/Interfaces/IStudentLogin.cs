using SMS.DataSource.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.DataSource.Interfaces
{
    public interface IStudentLogin
    {
        ICollection<StudentLogin> GetAllStudentLogins();

        LoginResponse GetStudentLoginPermission(StudentLogin studentLogin);

        LoginResponse CreateStudentLogin(StudentLogin studentLoginObj);

        int UpdateStudentLogin(int Id, StudentLogin studentLoginObj);

        void DeleteStudentLogin(int Id);
    }
}
