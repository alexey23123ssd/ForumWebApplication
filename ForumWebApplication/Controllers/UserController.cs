using Domain.Interfaces.Repositiries;
using ForumWebApplication.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ForumWebApplication.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IGenericRepository<UserDTO> _genericRepository;

        public UserController(IGenericRepository<UserDTO> genericRepo)
        {
          _genericRepository = genericRepo;
        }

        [Route("CreateUser")]
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserDTO user)
        {
            var result = await _genericRepository.CreateAsync(user);

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!result.IsSuccess)
            {
                return BadRequest(result.ErrorMessage);
            }
            return RedirectToAction("Index");
        }

        [Route("UpdateUser")]
        [HttpPost]
        public async Task<IActionResult> UpdateUser([FromRoute] Guid id, [FromBody] UserDTO user)
        {

        }
    }
}
