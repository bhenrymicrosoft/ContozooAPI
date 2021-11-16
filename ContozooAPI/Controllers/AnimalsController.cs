using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContozooAPI.Models;
using ContozooAPI.Services;

namespace ContozooAPI.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly AnimalsContext _context;

        public AnimalsController(AnimalsContext context)
        {
            _context = context;
        }

        //Get all action
        [HttpGet]
        //[Route("/")]
        public async Task<ActionResult<IEnumerable<Animals>>> GetAllAnimals()
        {
            return await _context.Animals.ToListAsync();
        }

        // GET by Id action
        [HttpGet("{AnimalId}")]
        public async Task<ActionResult<Animals>> GetAnimals(int AnimalId)
        {
            var animal = await _context.Animals.FindAsync(AnimalId);

            if (animal == null)
            {
                return NotFound();
            }

            return animal;
        }

        // POST action
        [HttpPost]
        public async Task<ActionResult<Animals>> CreateAnimals(Animals animal)
        {
            //var animals = new Animals
            //{
            //    Name = animal.Name,
            //    Number = animal.Number,
            //    Location = animal.Location,
            //    ActiveHours = animal.ActiveHours,
            //    Notes = animal.Notes
            //};

            _context.Animals.Add(animal);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetAnimals),
                new { id = animal.AnimalId },
                animal);
        }


        // PUT action
        [HttpPut("{AnimalId}")]
        public async Task<IActionResult> UpdateAnimals(int AnimalId, Animals animal)
        {
            if (AnimalId != animal.AnimalId)
            {
                return BadRequest();
            }

            //var animals = await _context.Animals.FindAsync(AnimalId);
            //if (animal == null)
            //{
            //    return NotFound();
            //}

            //animal.AnimalId = animal.AnimalId;
            //animal.Name = animal.Name;
            //animal.Number = animal.Number;
            //animal.Location = animal.Location;
            //animal.ActiveHours = animal.ActiveHours;
            //animal.Notes = animal.Notes;

            _context.Entry(animal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) 
            
            when (!AnimalExists(AnimalId))
            {
                return NotFound();
            }

            return NoContent();
        }


        // DELETE action
        [HttpDelete("{AnimalId}")]
        public async Task<IActionResult> DeleteAnimals(int AnimalId)
        {
            var animal = await _context.Animals.FindAsync(AnimalId);

            if (animal == null)
            {
                return NotFound();
            }

            _context.Animals.Remove(animal);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        private bool AnimalExists(int id)
        {
            return _context.Animals.Any(e => e.AnimalId == id);
        }
            
        //private static Animals Animals(Animals animal) =>
        //    new Animals
        //    {
        //        Id = animal.Id,
        //        Name = animal.Name,
        //        Number = animal.Number,
        //        Location = animal.Location,
        //        ActiveHours = animal.ActiveHours,
        //        Notes = animal.Notes,
        //    };
    }
}
