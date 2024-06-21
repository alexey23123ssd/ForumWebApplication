using Domain.Interfaces.Repositiries;
using ForumWebApplication.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ForumWebApplication.Controllers
{
    public class UserController : Controller
    {
        private readonly IGenericRepository<UserDTO> _genericRepository;

        public UserController(IGenericRepository<UserDTO> genericRepo)
        {
          _genericRepository = genericRepo;
        }

        public async Task<IActionResult> CreateUser([FromBody]UserDTO user)
        {
            var result = await _genericRepository.CreateAsync(user);

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return View(result);
        }
    }
}
