using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPI.Data;
using SuperHeroAPI.Entities;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController(DataContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            // var heroes = new List<SuperHero> {
            //     new SuperHero
            //     {
            //         Id = 1,
            //         Name = "Batman",
            //         FirstName = "Bruce",
            //         LastName = "Wayne",
            //         Place = "Gotham City"
            //     }
            // };
            var heroes = await context.SuperHeroes.ToListAsync();
            
            return Ok(heroes);
        }
    }
}
