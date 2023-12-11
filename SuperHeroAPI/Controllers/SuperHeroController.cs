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
            var heroes = await context.SuperHeroes.ToListAsync();
            
            return Ok(heroes);
        }
        
        [HttpGet("{id:int}")]
        public async Task<ActionResult<SuperHero>> GetHero(int id)
        {
            var hero = await context.SuperHeroes.FindAsync(id);

            if (hero == null)
            {
                return NotFound("Hero not found");
            }

            return Ok(hero);
        }
        
        [HttpPost]
        public async Task<ActionResult> CreateHero(SuperHero hero)
        {
            context.SuperHeroes.Add(hero);
            await context.SaveChangesAsync();
            
            return Ok();
        }
        
        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateHero(int id, SuperHero hero)
        {
            if (id != hero.Id)
            {
                return BadRequest("Hero ID mismatch");
            }

            context.Entry(hero).State = EntityState.Modified;
            await context.SaveChangesAsync();
            
            return Ok();
        }
        
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteHero(int id)
        {
            var hero = await context.SuperHeroes.FindAsync(id);

            if (hero == null)
            {
                return NotFound("Hero not found");
            }

            context.SuperHeroes.Remove(hero);
            await context.SaveChangesAsync();
            
            return Ok();
        }
    }
}
