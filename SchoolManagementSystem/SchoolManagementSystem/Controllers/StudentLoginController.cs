using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMS.DataSource.Entities;
using SMS.DataSource.Interfaces;

namespace SchoolManagementSystem.Controllers
{
    [Route("SMS/StudentLogin")]
    [ApiController]
    public class StudentLoginController : ControllerBase
    {
        IStudentLogin _studentLoginRepo;

        public StudentLoginController(IStudentLogin repo)
        {
            _studentLoginRepo = repo;
        }

        [HttpGet]
        public IActionResult GetAllStudentLogins()
        {
            var students = _studentLoginRepo.GetAllStudentLogins();
            return Ok(students);
        }

        [HttpPost("Login")]
        public IActionResult GetStudentLoginPermission(StudentLogin studentLogin)
        {
            var response = _studentLoginRepo.GetStudentLoginPermission(studentLogin);
            return Ok(response);
        }

        [HttpPost("SignUp")]
        public IActionResult CreateStudentLogin([FromBody] StudentLogin studentLoginObj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (studentLoginObj == null)
            {
                return BadRequest();
            }

            var response = _studentLoginRepo.CreateStudentLogin(studentLoginObj);

            return Ok(response);
        }

        [HttpPut("{Id}")]
        public IActionResult UpdateStudentLogin(int Id, [FromBody] StudentLogin studentLoginObject)
        {
            if (Id < 0)
            {
                BadRequest();
            }

            int result = _studentLoginRepo.UpdateStudentLogin(Id, studentLoginObject);

            if (result == 0)
                return BadRequest();
            return Ok();
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteStudentLogin(int Id)
        {
            if (Id < 0)
                return BadRequest();

            _studentLoginRepo.DeleteStudentLogin(Id);

            return Ok();
        }
    }
}