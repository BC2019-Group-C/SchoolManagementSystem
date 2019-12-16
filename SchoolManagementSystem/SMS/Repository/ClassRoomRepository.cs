using SMS.DataSource.Interfaces;
using SMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SMS.DataSource.Repository
{
    public class ClassRoomRepository : IClassRoom
    {
        SchoolDBContext _schoolDBContext;

        public ClassRoomRepository(SchoolDBContext sclDBContext)
        {
            _schoolDBContext = sclDBContext;
        }

        public void CreateClassRoom(ClassRoom classRoom)
        {
            _schoolDBContext.ClassRooms.Add(classRoom);
            _schoolDBContext.SaveChanges();
        }

        public void DeleteClassRoom(int Id)
        {
            var classRoom = _schoolDBContext.ClassRooms.Where(c => c.Id == Id).FirstOrDefault();

            _schoolDBContext.ClassRooms.Remove(classRoom);
            _schoolDBContext.SaveChanges();
        }

        public ICollection<ClassRoom> GetAllClassRooms()
        {
            var classRooms = _schoolDBContext.ClassRooms.ToList();

            return classRooms;
        }

        public ICollection<Student> GetAllStudentsInClassRoom(string grade, string section)
        {
            // var students = _schoolDBContext.ClassRooms.Where(c => c.Grade == grade && c.Section == section).ToList();
            //var tempClass = _schoolDBContext.ClassRooms.Where(c => c.Grade == grade && c.Section == section);
            int tempClassID = (from c in _schoolDBContext.ClassRooms
                             where c.Grade == grade && c.Section == section
                             select c.Id).FirstOrDefault();

            var students = _schoolDBContext.Students.Where(s => s.ClassRoomId == tempClassID).ToList();

            return students;
        }

        public ClassRoom GetClassRoomById(string grade, string section)
        {
            int tempClassID = (from c in _schoolDBContext.ClassRooms
                               where c.Grade == grade && c.Section == section
                               select c.Id).FirstOrDefault();

            var classRoom = _schoolDBContext.ClassRooms.Where(s => s.Id == tempClassID).SingleOrDefault();

            return classRoom;
        }

        public int UpdateClassRoom(int Id, ClassRoom classRoomObj)
        {
            var classRoom = _schoolDBContext.ClassRooms.Where(a => a.Id == Id).SingleOrDefault();

            if (classRoomObj == null)
            {
                return 0;
            }
            else
            {
                classRoom.Id = classRoomObj.Id;
                classRoom.Grade = classRoomObj.Grade;
                classRoom.Section = classRoomObj.Section;
                classRoom.ClasssTeacherId = classRoomObj.ClasssTeacherId;
                
                _schoolDBContext.SaveChanges();
                return 1;
            }
        }
    }
}
