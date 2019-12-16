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
    [Route("SMS/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        IStudent _studentRepo;

        public StudentController(IStudent repo)
        {
            _studentRepo = repo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var students = _studentRepo.GetAllStudent();
            return Ok(students);
        }

        [HttpGet("{Id}")]
        public IActionResult GetStudentById(int Id)
        {
            if (Id < 0)
            {
                BadRequest();
            }
            var student = _studentRepo.GetStudentById(Id);
            return Ok(student);
        }

        [HttpPost]
        public IActionResult CreateStudent([FromBody] Student studentObj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (studentObj == null)
            {
                return BadRequest();
            }

            _studentRepo.CreateStudent(studentObj);

            return NoContent();
        }

        [HttpPut("{Id}")]
        public IActionResult UpdateStudent(int Id, [FromBody] Student studentObject)
        {
            if (Id < 0)
            {
                BadRequest();
            }

            int result = _studentRepo.UpdateStudent(Id, studentObject);

            if (result == 0)
                return BadRequest();
            return Ok();
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteStudent(int Id)
        {
            if (Id < 0)
                return BadRequest();

            _studentRepo.DeleteStudent(Id);

            return Ok();
        }
    }
}