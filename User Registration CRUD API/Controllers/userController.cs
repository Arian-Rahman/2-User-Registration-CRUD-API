using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using User_Registration_CRUD_API.Data;
using User_Registration_CRUD_API.Models;

namespace User_Registration_CRUD_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userController : ControllerBase
    {
        private readonly ApplicationDbContext _context; 
        public userController(ApplicationDbContext context)=>_context=context;


        [HttpPost]
        public async Task<IActionResult> Create(user user)
        {
            await _context.user.AddAsync(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Create), user);
        }

        [HttpGet]
        public async Task<IEnumerable<user>> Get()
        {
            return await _context.user.ToListAsync();
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _context.user.FindAsync(id);
            return user==null? NotFound():Ok(user);    
        }

        [HttpGet("name")]
        public async Task<IActionResult> GetByName(string name)
        {
            var user = await _context.user.FindAsync(name);
            return user == null ? NotFound() : Ok(user);
        }

        [HttpPut("id")]
        public async Task<IActionResult> UpdateById(int id,user user)
        {
            if (id != user.Id) return BadRequest();
            
            _context.Entry(id).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteByID(int id)
        {
            var del = await _context.user.FindAsync(id);
            if(del==null) return NotFound();

            _context.user.Remove(del);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteAll()
        {
            //var all= await _context.user.ToListAsync(); 
            //_context.user.Remove(all);
            //await _context.SaveChangesAsync();
            //var Task = _context.user.FirstOrDefault(x => x.Id == id);

            _context.Entry(user).State = EntityState.Deleted;

            _context.SaveChanges();

            return NoContent();
        }
    }
}
