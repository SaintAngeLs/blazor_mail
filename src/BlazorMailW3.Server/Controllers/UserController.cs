using BlazorMailW3.Shared;
using Microsoft.AspNetCore.Mvc;

namespace BlazorMailW3.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public User Get()
        {
            System.Console.WriteLine("Returning Logged In User");

            return Data.MessageRepo.LoggedInUser();
        }
    }
}
