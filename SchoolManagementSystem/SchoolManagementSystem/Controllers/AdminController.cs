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
    [Route("SMS/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        IAdmin _adminRepo;

        public AdminController(IAdmin repo)
        {
            _adminRepo = repo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var admins = _adminRepo.GetAllAdmins();
            return Ok(admins);
        }

        [HttpGet("{Id}")]
        public IActionResult GetAdminById(int Id)
        {
            if (Id < 0)
            {
                BadRequest();
            }
            var admin = _adminRepo.GetAdminById(Id);
            return Ok(admin);
        }

        [HttpPost]
        public IActionResult CreateAdmin([FromBody] Admin NewObj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (NewObj == null)
            {
                return BadRequest();
            }

            _adminRepo.CreateAdmin(NewObj);

            return NoContent();
        }

        [HttpPut("{Id}")]
        public IActionResult UpdateAdmin(int Id, [FromBody] Admin adminObject)
        {
            if (Id < 0)
            {
                BadRequest();
            }

            int result = _adminRepo.UpdateAdmin(Id, adminObject);

            if (result == 0)
                return BadRequest();
            return Ok();
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteAdmin(int Id)
        {
            if (Id < 0)
                return BadRequest();

            _adminRepo.DeleteAdmin(Id);

            return Ok();
        }
    }
}