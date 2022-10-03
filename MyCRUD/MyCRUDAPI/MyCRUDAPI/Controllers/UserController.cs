using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCRUDAPI.Data;
using System.Collections.Generic;
using System.Linq;

namespace MyCRUDAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;

        public UserController(DataContext context) {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers() {
            return Ok(await _context.Users.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<User>>> GetUsers(int id)
        {
            var dbUser = await _context.Users.FindAsync(id);
            if (dbUser == null)
                return BadRequest("No se Encontro el Usuario");

            return Ok(dbUser);
        }

        [HttpPost]

        public async Task<ActionResult<List<User>>> CreateUser(User user) {
            _context.Users.Add(user);

            await _context.SaveChangesAsync();
            return Ok(await _context.Users.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<User>>> UpdateUser(User user) {
            var dbUser = await _context.Users.FindAsync(user.Id);
            if (dbUser == null)
                return BadRequest("No se Encontro el Usuario");


            dbUser.Id = user.Id;
            dbUser.FirstName = user.FirstName;
            dbUser.LastName = user.LastName;
            dbUser.DocType  = user.DocType;
            dbUser.DocNum = user.DocNum;
            dbUser.Estate = user.Estate;
            dbUser.StartDate = user.StartDate;
            await _context.SaveChangesAsync();

            return Ok(await _context.Users.ToListAsync());
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<List<User>>> DeleteUser(int id){
            var dbUser = await _context.Users.FindAsync(id);
            if (dbUser == null)
                return BadRequest("No se Encontro el Usuario");

            _context.Users.Remove(dbUser); 
            await _context.SaveChangesAsync();

            return Ok(await _context.Users.ToListAsync());
        }
    }
}
