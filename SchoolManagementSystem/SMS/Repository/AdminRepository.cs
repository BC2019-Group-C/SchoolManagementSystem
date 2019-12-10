using SMS.DataSource.Interfaces;
using SMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMS.DataSource.Repository
{
    public class AdminRepository : IAdmin
    {
        SchoolDBContext _schoolDBContext;

        public AdminRepository(SchoolDBContext sclDBContext)
        {
            _schoolDBContext = sclDBContext;
        }
        public void CreateAdmin(Admin admin)
        {
            
            _schoolDBContext.Admins.Add(admin);
            _schoolDBContext.SaveChanges();
        }

        public void DeleteAdmin(int Id)
        {
            var admin = _schoolDBContext.Admins.Where(a => a.Id == Id).FirstOrDefault();

            _schoolDBContext.Admins.Remove(admin);
            _schoolDBContext.SaveChanges();
        }

        public Admin GetAdminById(int Id)
        {
            var admin = _schoolDBContext.Admins.Where(a => a.Id == Id).SingleOrDefault();
            return admin;
        }

        public ICollection<Admin> GetAllAdmins()
        {
            var admins = _schoolDBContext.Admins.ToList();

            return admins;
        }

        public int UpdateAdmin(int Id, Admin adminObject)
        {
            var admin = _schoolDBContext.Admins.Where(a => a.Id == Id).SingleOrDefault();

            if (admin == null)
            {
                return 0;

            }
            else
            {
                admin.FirstName = adminObject.FirstName;
                admin.LastName = adminObject.LastName;
                admin.Gender = adminObject.Gender;
                admin.DateOfBirth = adminObject.DateOfBirth;
                admin.ContactNumber = adminObject.ContactNumber;
                _schoolDBContext.SaveChanges();
                return 1;
            }
        }
    }
}
