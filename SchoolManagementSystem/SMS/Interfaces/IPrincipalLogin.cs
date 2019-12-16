using SMS.DataSource.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.DataSource.Interfaces
{
    public interface IPrincipalLogin
    {
        ICollection<SclPrincipalLogin> GetAllPrincipalLogins();

        SclPrincipalLogin GetPrincipalLoginById(int Id);

        void CreatePrincipalLogin(SclPrincipalLogin principalLoginObj);

        int UpdatePrincipalLogin(int Id, SclPrincipalLogin principalLoginObj);

        void DeletePrincipalLogin(int Id);
    }
}
