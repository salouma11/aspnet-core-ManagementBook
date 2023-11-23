using ManagementBooks.API.Services.CatLivrService;
using ManagementBooks.Classes.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagementBooks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatLivrController : ControllerBase
    {
        private readonly ICatLivrService _catLivrService;

        public CatLivrController(ICatLivrService catLivrService)
        {
            _catLivrService = catLivrService;
        }


        [HttpGet]
        public async Task<ActionResult<List<CatLivr>>> GetAllCateLivrAsync()
        {

            return await _catLivrService.GetAllCateLivr();
        }
    }
}
