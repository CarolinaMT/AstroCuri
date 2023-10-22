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
    [Route("/api/link")]
    public class LinkController: ControllerBase
    {
        private readonly DataContext _context;

        public LinkController(DataContext context)
        {
            _context = context;
        }

        //Get con lista
        //Select * From likes

        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _context.Liks.ToListAsync());


        }

        // Get por parámetro
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {

            //200 Ok

            var Link = await _context.Liks.FirstOrDefaultAsync(x => x.Id == id);

            if (Link == null)
            {


                return NotFound();
            }

            return Ok(Link);


        }

        // Crear un nuevo registro
        [HttpPost]
        public async Task<ActionResult> Post(Link Link)
        {
            _context.Add(Link);
            await _context.SaveChangesAsync();
            return Ok(Link);
        }

        // Actualizar o cambiar registro

        [HttpPut]
        public async Task<ActionResult> Put(link link)
        {
            _context.Update(link);
            await _context.SaveChangesAsync();
            return Ok(link);
        }

        // ELiminar registros

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {


            var FilaAfectada = await _context.Links
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
