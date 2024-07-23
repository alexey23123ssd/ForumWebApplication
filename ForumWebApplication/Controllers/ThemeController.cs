using Application.Features.Themes.Commands.CreateTheme;
using Application.Features.Themes.Commands.DeleteTheme;
using Application.Features.Themes.Commands.UpdateTheme;
using Application.Features.Themes.Queries;
using Application.Features.Users.ValidatorBehaviors;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ForumWebApplication.Controllers
{
    [Route("[controller]")]
    public class ThemeController : Controller
    {
        private readonly IMediator _mediator;

        public ThemeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("[Create]")]
        [HttpPost]
        public async Task<IActionResult> CreateThemeAsync([FromForm]CreateThemeCommand command)
        {
            var validator = new CreateThemeCommandValidator();
            var result = validator.Validate(command);

            if(result.IsValid) 
            { 
                await _mediator.Send(command); 
            }
            
            return View();
        }

        [Route("[Delete]/{id?}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteThemeAsync([FromRoute]Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            await _mediator.Send(new DeleteThemeCommand(id));

            return View();
        }

        [Route("[Update]/{id?}")]
        [HttpPut]
        public async Task<IActionResult> UpdateThemeAsync([FromRoute]Guid id, [FromForm]UpdateThemeCommand command)
        {
            var validator = new UpdateThemeCommandValidator();
            var result = validator.Validate(command);

            if (id != command.Id)
            {
                return BadRequest();
            }

            if (result.IsValid)
            {
                await _mediator.Send(command);
            }

            return View();
        }

        [Route("[GetTheme]/{id?}")]
        [HttpGet]
        public async Task<IActionResult> GetThemeByIdAsync([FromRoute]Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            await _mediator.Send(new GetThemeByIdQuery(id));

            return View();
        }

    }
}
