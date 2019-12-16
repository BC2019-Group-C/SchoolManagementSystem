using SMS.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.DataSource.Interfaces
{
    public interface IPrincipal
    {
        ICollection<SclPrincipal> GetAllPrincipals();

        SclPrincipal GetPrincipalById(int Id);

        void CreatePrincipal(SclPrincipal principalObj);

        int UpdatePrincipal(int Id, SclPrincipal principalObj);

        void DeletePrincipal(int Id);
    }
}
