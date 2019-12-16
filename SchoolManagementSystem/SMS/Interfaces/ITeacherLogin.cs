using SMS.DataSource.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.DataSource.Interfaces
{
    public interface ITeacherLogin
    {
        ICollection<TeacherLogin> GetAllAdminLogins();

        TeacherLogin GetTeacherLoginById(int Id);

        void CreateTeacherLogin(TeacherLogin teacherLoginObj);

        int UpdateTeacherLogin(int Id, TeacherLogin teacherLoginObj);

        void DeleteTeacherLogin(int Id);
    }
}
