using ManagementBooks.API.Services.AuteurService;
using ManagementBooks.Classes.DTO;
using ManagementBooks.Classes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementBooks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuteurController : ControllerBase
    {
        private readonly IAuteurService _auteurService;

        public AuteurController(IAuteurService auteurService)
        {
            _auteurService = auteurService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Auteur>>> GetAllAuteursAsync()
        {

            return await _auteurService.GetAllAuteur();
        }

        [HttpGet("{id}")]
        //[Route]
        public async Task<ActionResult<Auteur>> GetAuteurById(int id)
        {
            var result = await _auteurService.GetAuteurById(id);
            if (result is null)
            {
                return NotFound("sorry , this auteur dosen't exist");
            }

            var auteurDTO = new AuteurDTO
            {
                Id = result.Id,
                NameAut = result.NameAut,
                Livres = result.Livres

            };
            return Ok(auteurDTO);
        }


        [HttpPost]
        public async Task<ActionResult<List<Auteur>>> AddAuteur(Auteur aut)
        {
            
            var result = await _auteurService.AddAuteur(aut);

            return Ok(result);

        }

        [HttpPut("{id}")]
        //[Route]
        public async Task<ActionResult<List<Auteur>>> UpdateAuteurAsync(int id, Auteur request)
        {
            

            //return Ok(SuperHeros);

            var result = await _auteurService.UpdateAuteur(id, request);
            if (result is null)
            {
                return NotFound("sorry ");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Auteur>>> DeleteAuteurAsync(int id)
        {
            var result = await _auteurService.DeleteAuteur(id);

            if (result is null)
            {
                return NotFound("Sorry, this author doesn't exist.");
            }
            else if (result.Count == 0)
            {
                return BadRequest("Auteur has associated Livres. Delete them first.");
            }

            return Ok(result);
        }
    }
}
