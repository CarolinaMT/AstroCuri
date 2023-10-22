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
    public class ArticleController : ControllerBase
    {
        private readonly DataContext _context;

        public ArticleController(DataContext context)
        {
            _context = context;
        }

        //Get con lista
        //Select * From Articles

        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _context.Articles.ToListAsync());


        }

        // Get por parámetro
        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(string id)
        {

            //200 Ok

            var Article = await _context.Articles.FirstOrDefaultAsync(x => x.Id == id);

            if (Article == null)
            {


                return NotFound();
            }

            return Ok(Article);


        }

        // Crear un nuevo registro
        [HttpPost]
        public async Task<ActionResult> Post(Article Article)
        {
            _context.Add(Article);
            await _context.SaveChangesAsync();
            return Ok(Article);
        }

        // Actualizar o cambiar registro

        [HttpPut]
        public async Task<ActionResult> Put(Article Article)
        {
            _context.Update(Article);
            await _context.SaveChangesAsync();
            return Ok(Article);
        }

        // ELiminar registros

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(string id)
        {


            var FilaAfectada = await _context.Articles
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
