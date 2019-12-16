using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMS.DataSource.Interfaces;
using SMS.Entities;

namespace SchoolManagementSystem.Controllers
{
    [Route("SMS/classroom")]
    [ApiController]
    public class ClassRoomController : ControllerBase
    {
        IClassRoom _classRoomRepo;

        public ClassRoomController(IClassRoom repo)
        {
            _classRoomRepo = repo;
        }

        [HttpGet]
        public IActionResult GetAllClassRooms()
        {
            var classRooms = _classRoomRepo.GetAllClassRooms();
            return Ok(classRooms);
        }

        [HttpGet("{grade}/{section}/students")]
        public IActionResult GetAllStudentsInClassRoom(string grade, string section)
        {
            var students = _classRoomRepo.GetAllStudentsInClassRoom(grade, section);
            return Ok(students);
        }

        [HttpGet("{grade}/{section}")]
        public IActionResult GetClassRoomById(string grade, string section)
        {
            if (grade == "" || section == "")
            {
                BadRequest();
            }
            var classRoom = _classRoomRepo.GetClassRoomById(grade, section);
            return Ok(classRoom);
        }

        [HttpPost]
        public IActionResult CreateClassRoom(ClassRoom classRoomObj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (classRoomObj == null)
            {
                return BadRequest();
            }

            _classRoomRepo.CreateClassRoom(classRoomObj);

            return Ok();
        }

        [HttpPut("{Id}")]
        public IActionResult UpdateClassRoom(int Id, ClassRoom classRoomObj)
        {
            if (classRoomObj == null)
            {
                BadRequest();
            }

            int result = _classRoomRepo.UpdateClassRoom(Id, classRoomObj);

            if (result == 0)
                return BadRequest();
            return Ok();
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteClassRoom(int Id)
        {
            if (Id < 0)
                return BadRequest();

            _classRoomRepo.DeleteClassRoom(Id);

            return Ok();
        }

    }
}