using Application.Interfaces.Repositiries;
using Application.Common.DTOs;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Application.Features.Users.Commands.CreateUser;
using Domain.Helpers;

namespace ForumWebApplication.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IGenericRepository<UserDTO> _genericRepository;
        private readonly IMediator _mediator;

        public UserController(IGenericRepository<UserDTO> genericRepo,IMediator mediator)
        {
          _genericRepository = genericRepo;
          _mediator = mediator;
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

        public async Task<ActionResult<ServiceDataResponse<UserDTO>>> Create([FromForm]CreateUserCommand command)
        {
            return await _mediator.Send(command);
        }

        [Route("UpdateUser")]
        [HttpPost]
        public async Task<IActionResult> UpdateUser([FromRoute] Guid id, [FromBody] UserDTO user)
        {

        }
    }
}
