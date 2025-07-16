using Microsoft.AspNetCore.Mvc;
using WebApiCoreCruds1.Interfaces;
using WebApiCoreCruds1.Services;

namespace WebApiCoreCruds1.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuth auth;
        public AuthController(IAuth authService)
        {
            auth = authService;
        }
        [HttpGet]
        public IActionResult Index(string name)
        {
            var token = auth.GenerateJwtToken(name);
            return Ok(token);
        }
        //[HttpGet]
        //public async Task<IActionResult> GetToken(string name)
        //{
        //    return Ok(auth.GenerateJwtToken(name));
        //}
    }
}
