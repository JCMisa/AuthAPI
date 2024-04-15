using AuthAPI.Data;
using AuthAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuthAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly ApplicationDbContext _db;

        public AuthController(ApplicationDbContext db)
        {
			_db = db;
        }

        [HttpGet]
		public async Task<List<User>> GetAll()
		{
			return await _db.Users.ToListAsync();
		}

		[HttpGet]
		public async Task<ActionResult<User?>> GetAll(int? id)
		{
			if(id == null)
			{
				return BadRequest();
			}
			var user =  await _db.Users.FirstOrDefaultAsync(u => u.Id == id);

			if(user == null)
			{
				return NotFound();
			}

			return user;
		}
	}
}
