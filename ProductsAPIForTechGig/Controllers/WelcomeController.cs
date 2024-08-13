using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsAPIForTechGig.Models;
using ProductsAPIForTechGig.Models.Domain;
using ProductsAPIForTechGig.Repository;

namespace ProductsAPIForTechGig.Controllers
{
    [Route("/")]
    [ApiController]
    public class WelcomeController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetProductAsync()
        {
            return Ok("Welocme .Net Core API.");
        }

    }
}
