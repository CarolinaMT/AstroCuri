using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AstroCuri.API.Data;
using AstroCuri.Shared.Entities;

namespace AstroCuri.API.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    [ApiController]
    [Route("/api/User")]
    public class UserController : ControllerBase
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }

        //Get con lista
        //Select * From  Users

        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _context.Users.ToListAsync());


        }

        // Get por parámetro
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {

            //200 Ok

            var User = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);

            if (User == null)
            {


                return NotFound();
            }

            return Ok(User);


        }

        // Crear un nuevo registro
        [HttpPost]
        public async Task<ActionResult> Post(User User)
        {
            _context.Add(User);
            await _context.SaveChangesAsync();
            return Ok(User);
        }

        // Actualizar o cambiar registro

        [HttpPut]
        public async Task<ActionResult> Put(User User)
        {
            _context.Update(User);
            await _context.SaveChangesAsync();
            return Ok(User);
        }

        // ELiminar registros

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {


            var FilaAfectada = await _context.Users
                .Where(x => x.Id == id)//5
                .ExecuteDeleteAsync();

            if (FilaAfectada == 0)
            {


                return NotFound();//404
            }

            return NoContent();//204


        }
    }
}
