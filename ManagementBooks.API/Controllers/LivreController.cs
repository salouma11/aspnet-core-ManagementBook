using ManagementBooks.API.Services.LivreService;
using ManagementBooks.Classes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementBooks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivreController : ControllerBase
    {
        private readonly ILivreService _livreService;

        public LivreController(ILivreService livreService)
        {
            _livreService = livreService;
        }


        [HttpGet]
        public async Task<ActionResult<List<Livre>>> GetAllLivresAsync()
        {

            return await _livreService.GetAllLivre();
        }

        [HttpGet("{id}")]
        //[Route]
        public async Task<ActionResult<Auteur>> GetLivreById(int id)
        {
            var result = await _livreService.GetLivreById(id);
            if (result is null)
            {
                return NotFound("sorry , this book dosen't exist");
            }
            return Ok(result);
        }


        [HttpPost]
        public async Task<ActionResult<List<Livre>>> AddLivre(Livre livre)
        {

            var result = await _livreService.AddLivreWithAll(livre);

            return Ok(result);

        }

        public class AddLivreWithCatModel
        {
            public Livre Livre { get; set; } 
            public List<int> CatSelected { get; set; }

            public ContenueLivre Cont { get; set; }
        }

        //[HttpPost]
        //public async Task<ActionResult<List<Livre>>> AddLivreWithCat ([FromBody] AddLivreWithCatModel model)
        //{

        //    var result = await _livreService.AddLivreWithCategoriesAsync(model.Livre,model.CatSelected , model.Cont);

        //    return Ok(result);

        //}


        [HttpPut("{id}")]
        //[Route]
        public async Task<ActionResult<List<Livre>>> UpdateLivreAsync(int id, Livre request)
        {


            var result = await _livreService.UpdateLivreWithCategoriesAsync(id, request);
            var b = request;
            if (result is null)
            {
                return NotFound("sorry ");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        //[Route]
        public async Task<ActionResult<List<Livre>>> DeleteLivreAsync(int id)
        {


            var result = await _livreService.DeleteLivre(id);
            if (result is null)
            {
                return NotFound("sorry , this book dosen't exist");
            }
            return Ok(result);
        }
    }
}
