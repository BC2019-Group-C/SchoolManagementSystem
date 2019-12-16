using SMS.DataSource.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.DataSource.Interfaces
{
    public interface IAdminLogin
    {
        ICollection<AdminLogin> GetAllAdminLogins();

        LoginResponse GetAdminLoginPermission(AdminLogin adminLogin);

        void CreateAdminLogin(AdminLogin adminLoginObj);

        int UpdateAdminLogin(int Id, AdminLogin adminLoginObj);

        void DeleteAdminLogin(int Id);
    }
}
