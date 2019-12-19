using SMS.DataSource.Entities;
using SMS.DataSource.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMS.DataSource.Repository
{
    public class AdminLoginRepository : IAdminLogin
    {
        SchoolDBContext _schoolDBContext;

        public AdminLoginRepository(SchoolDBContext sclDBContext)
        {
            _schoolDBContext = sclDBContext;
        }

        public void CreateAdminLogin(AdminLogin adminLoginObj)
        {
            _schoolDBContext.AdminLogins.Add(adminLoginObj);
            _schoolDBContext.SaveChanges();
        }

        public void DeleteAdminLogin(int Id)
        {
            var adminLogin = _schoolDBContext.AdminLogins.Where(a => a.Id == Id).FirstOrDefault();

            _schoolDBContext.AdminLogins.Remove(adminLogin);
            _schoolDBContext.SaveChanges();
        }

        public LoginResponse GetAdminLoginPermission(AdminLogin adminLogin)
        {
            var log = _schoolDBContext.AdminLogins.Where(
                            a => a.UserName.Equals(adminLogin.UserName) &&
                                  a.Password.Equals(adminLogin.Password)).FirstOrDefault();



            if (log == null)
            {
                return new LoginResponse { Status = "Invalid", Message = "Invalid User Name and/or Password." };
            }
            else
                return new LoginResponse { Status = "Success", Message = "Login Successful" };
        }

        public ICollection<AdminLogin> GetAllAdminLogins()
        {
            var adminLogins = _schoolDBContext.AdminLogins.ToList();

            return adminLogins;
        }

        public int UpdateAdminLogin(int Id, AdminLogin adminLoginObj)
        {
            var adminLogin = _schoolDBContext.AdminLogins.Where(a => a.Id == Id).SingleOrDefault();

            if (adminLogin == null)
            {
                return 0;
            }
            else
            {
                adminLogin.Id = adminLoginObj.Id;
                adminLogin.AdminUser = adminLoginObj.AdminUser;
                adminLogin.UserName = adminLoginObj.UserName;
                adminLogin.Password = adminLoginObj.Password;

                _schoolDBContext.SaveChanges();
                return 1;
            }
        }
    }
}
