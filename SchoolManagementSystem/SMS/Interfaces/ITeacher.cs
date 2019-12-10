using SMS.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.DataSource.Interfaces
{
    public interface ITeacher
    {
        ICollection<Teacher> GetAllTeachers();

        Teacher GetTeacherById(int Id);

        void CreateTeacher(Teacher teacher);

        int UpdateTeacher(int Id, Teacher teacherObject);

        void DeleteTeacher(int Id);
    }
}
