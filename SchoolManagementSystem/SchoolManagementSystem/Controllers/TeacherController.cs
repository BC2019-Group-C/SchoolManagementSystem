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
    [Route("SMS/teacher")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        ITeacher _teacherRepo;

        public TeacherController(ITeacher repo)
        {
            _teacherRepo = repo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var teachers = _teacherRepo.GetAllTeachers();
            return Ok(teachers);
        }

        [HttpGet("{Id}")]
        public IActionResult GetTeacherById(int Id)
        {
            if (Id < 0)
            {
                BadRequest();
            }
            var teacher = _teacherRepo.GetTeacherById(Id);
            return Ok(teacher);
        }

        [HttpPost]
        public IActionResult CreateTeacher([FromBody] Teacher NewObj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (NewObj == null)
            {
                return BadRequest();
            }

            _teacherRepo.CreateTeacher(NewObj);

            return NoContent();
        }

        [HttpPut("{Id}")]
        public IActionResult UpdateTeacher(int Id, [FromBody] Teacher teacherObject)
        {
            if (Id < 0)
            {
                BadRequest();
            }

            int result = _teacherRepo.UpdateTeacher(Id, teacherObject);

            if (result == 0)
                return BadRequest();
            return Ok();
        }
    }
}