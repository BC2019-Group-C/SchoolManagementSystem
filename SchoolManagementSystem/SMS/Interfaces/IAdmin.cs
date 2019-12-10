using SMS.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.DataSource.Interfaces
{
    public interface IAdmin
    {
        ICollection<Admin> GetAllAdmins();

        Admin GetAdminById(int Id);

        void CreateAdmin(Admin admin);

        int UpdateAdmin(int Id, Admin adminObject);

        void DeleteAdmin(int Id);
    }
}
