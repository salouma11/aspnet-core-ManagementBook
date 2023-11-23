using ManagementBooks.API.Services.CategorieService;
using ManagementBooks.Classes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementBooks.API.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class CategorieController : ControllerBase
    {
        private readonly ICategorieService _categorieService;

        public CategorieController(ICategorieService categorieService)
        {
            _categorieService = categorieService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Categorie>>> GetAllCategoriesAsync()
        {

            return await _categorieService.GetAllCategorie();
        }

        [HttpGet("{id}")]
        //[Route]
        public async Task<ActionResult<Categorie>> GetCategorieById(int id)
        {
            var result = await _categorieService.GetCategorieById(id);
            if (result is null)
            {
                return NotFound("sorry , this auteur dosen't exist");
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Categorie>>> AddCategorie(Categorie cat)
        {

            var result = await _categorieService.AddCategorie(cat);

            return Ok(result);

        }

        [HttpPut("{id}")]
        //[Route]
        public async Task<ActionResult<List<Categorie>>> UpdateCategorieAsync(int id, Categorie request)
        {


            //return Ok(SuperHeros);

            var result = await _categorieService.UpdateCategorie(id, request);
            if (result is null)
            {
                return NotFound("sorry ");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        //[Route]
        public async Task<ActionResult<List<Categorie>>> DeleteCategorieAsync(int id)
        {


            var result = await _categorieService.DeleteCategorie(id);
            if (result is null)
            {
                return NotFound("sorry , this hero dosen't exist");
            }
            return Ok(result);
        }
    }
}
