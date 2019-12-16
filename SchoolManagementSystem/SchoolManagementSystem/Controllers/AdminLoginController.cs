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
    [Route("SMS/AdminLogin")]
    [ApiController]
    public class AdminLoginController : ControllerBase
    {
        IAdminLogin _adminLoginRepo;

        public AdminLoginController(IAdminLogin repo)
        {
            _adminLoginRepo = repo;
        }

        [HttpGet]
        public IActionResult GetAllAdminLogins()
        {
            var admins = _adminLoginRepo.GetAllAdminLogins();
            return Ok(admins);
        }

        

        [HttpPost("Login")]
        public IActionResult GetAdminLoginPermission(AdminLogin adminLogin)
        {
            var response = _adminLoginRepo.GetAdminLoginPermission(adminLogin);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult CreateAdminLogin([FromBody] AdminLogin adminLoginObj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (adminLoginObj == null)
            {
                return BadRequest();
            }

            _adminLoginRepo.CreateAdminLogin(adminLoginObj);

            return Ok();
        }

        [HttpPut("{Id}")]
        public IActionResult UpdateAdminLogin(int Id, [FromBody] AdminLogin adminLoginObject)
        {
            if (Id < 0)
            {
                BadRequest();
            }

            int result = _adminLoginRepo.UpdateAdminLogin(Id, adminLoginObject);

            if (result == 0)
                return BadRequest();
            return Ok();
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteAdminLogin(int Id)
        {
            if (Id < 0)
                return BadRequest();

            _adminLoginRepo.DeleteAdminLogin(Id);

            return Ok();
        }

    }
}