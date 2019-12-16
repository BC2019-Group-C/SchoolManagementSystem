using SMS.DataSource.Entities;
using SMS.DataSource.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMS.DataSource.Repository
{
    public class StudentLoginRepository : IStudentLogin
    {
        SchoolDBContext _schoolDBContext;

        public StudentLoginRepository(SchoolDBContext sclDBContext)
        {
            _schoolDBContext = sclDBContext;
        }

        public LoginResponse CreateStudentLogin(StudentLogin studentLoginObj)
        {
            _schoolDBContext.StudentLogins.Add(studentLoginObj);
            _schoolDBContext.SaveChanges();

            return new LoginResponse { Status = "Success", Message = "Account sucessfully generated!" };
        }

        public void DeleteStudentLogin(int Id)
        {
            var studentLogin = _schoolDBContext.StudentLogins.Where(s => s.Id == Id).FirstOrDefault();

            _schoolDBContext.StudentLogins.Remove(studentLogin);
            _schoolDBContext.SaveChanges();
        }


        public LoginResponse GetStudentLoginPermission(StudentLogin studentLogin)
        {
            var log = _schoolDBContext.StudentLogins.Where(
                            s => s.UserName.Equals(studentLogin.UserName) && 
                                  s.Password.Equals(studentLogin.Password)).FirstOrDefault();



            if (log == null)
            {
                return new LoginResponse { Status = "Invalid", Message = "Invalid User Name and/or Password." };
            }
            else
                return new LoginResponse { Status = "Success", Message = "Login Successful" };
        }

        public ICollection<StudentLogin> GetAllStudentLogins()
        {
            var studentLogins = _schoolDBContext.StudentLogins.ToList();

            return studentLogins;
        }

        public int UpdateStudentLogin(int Id, StudentLogin studentLoginObj)
        {
            var studentLogin = _schoolDBContext.StudentLogins.Where(a => a.Id == Id).SingleOrDefault();

            if (studentLogin == null)
            {
                return 0;
            }
            else
            {
                studentLogin.Id = studentLoginObj.Id;
                studentLogin.StudentId = studentLoginObj.StudentId;
                studentLogin.UserName = studentLoginObj.UserName;
                studentLogin.Password = studentLoginObj.Password;

                _schoolDBContext.SaveChanges();
                return 1;
            }
        }
    }
}
