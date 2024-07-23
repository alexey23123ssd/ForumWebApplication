using Application.Features.Users.Commands.CreateUser;
using Application.Features.Users.Commands.DeleteUser;
using Application.Features.Users.Commands.UpdateUser;
using Application.Features.Users.Queries.GetUserById;
using Application.Features.Users.ValidatorBehaivors;
using Application.Features.Users.ValidatorBehaviors;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ForumWebApplication.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
          _mediator = mediator;
        }

        [Route("CreateUser")]
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromForm]CreateUserCommand command)
        {
            var validator = new CreateUserCommandValidator();
            var result = validator.Validate(command);

            if(result.IsValid) 
            {
                await _mediator.Send(command);
            }
            
            return RedirectToAction("Index");
        }

        [Route("UpdateUser")]
        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromRoute] Guid id, [FromForm] UpdateUserCommand command)
        {
            var validator = new UpdateUserCommandValidator();
            var result = validator.Validate(command);

            if (id != command.Id)
            {
                return BadRequest();
            }

            if (result.IsValid)
            {
                await _mediator.Send(command);
            }

            return RedirectToAction("Index");
        }

        [Route("DeleteUser")]
        [HttpDelete]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {
            if(id == Guid.Empty)
            {
                return BadRequest();
            }

            await _mediator.Send(new DeleteUserCommand(id));

            return RedirectToAction("Index");
        }

        [Route ("GetUser")]
        [HttpGet]
        public async Task<IActionResult> GetUserById([FromRoute] Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            await _mediator.Send(new GetUserByIdQuery(id));

            return RedirectToAction("Index");
        }
    }
}
