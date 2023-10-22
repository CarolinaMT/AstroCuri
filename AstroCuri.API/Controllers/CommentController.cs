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
    [Route("/api/Comment")]
    public class CommentController: ControllerBase
    {
        private readonly DataContext _context;

        public CommentController(DataContext context)
        {
            _context = context;
        }

        //Get con lista
        //Select * From comments

        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _context.Comments.ToListAsync());


        }

        // Get por parámetro
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {

            //200 Ok

            var Comment = await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);

            if (Comment == null)
            {


                return NotFound();
            }

            return Ok(Comment);


        }

        // Crear un nuevo registro
        [HttpPost]
        public async Task<ActionResult> Post(Comment Comment)
        {
            _context.Add(Comment);
            await _context.SaveChangesAsync();
            return Ok(Comment);
        }

        // Actualizar o cambiar registro

        [HttpPut]
        public async Task<ActionResult> Put(Comment Comment)
        {
            _context.Update(Comment);
            await _context.SaveChangesAsync();
            return Ok(Comment);
        }

        // ELiminar registros

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {


            var FilaAfectada = await _context.Comments
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
