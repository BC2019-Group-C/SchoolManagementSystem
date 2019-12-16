using SMS.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMS.DataSource.Interfaces
{
    public interface IClassRoom
    {
        ICollection<ClassRoom> GetAllClassRooms();

        ICollection<Student> GetAllStudentsInClassRoom(string grade, string section);

        ClassRoom GetClassRoomById(string grade, string section);

        void CreateClassRoom(ClassRoom classRoom);

        int UpdateClassRoom(int Id, ClassRoom classRoomObj);

        void DeleteClassRoom(int Id);
    }
}
