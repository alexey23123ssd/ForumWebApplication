using Application.Features.Comments.Commands.CreateComment;
using Application.Features.Comments.Commands.DeleteComment;
using Application.Features.Comments.Commands.UpdateComment;
using Application.Features.Comments.Queries;
using Application.Features.ValidatorBehaviors;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ForumWebApplication.Controllers
{
    public class CommentController : Controller
    {
        private readonly IMediator _mediator;
        public CommentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("[Create]")]
        [HttpPost]
        public async Task<IActionResult> CreateCommentAsync([FromForm] CreateCommentCommand command)
        {
            var validator = new CreateCommentCommandValidator();
            var result = validator.Validate(command);

            if (result.IsValid)
            {
                await _mediator.Send(command);
            }

            return View();
        }

        [Route("[Delete]/{id?}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteCommentAsync([FromRoute] Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            await _mediator.Send(new DeleteCommentCommand(id));

            return View();
        }

        [Route("[Update]/{id?}")]
        [HttpPut]
        public async Task<IActionResult> UpdateCommentAsync([FromRoute] Guid id, [FromForm] UpdateCommentCommand command)
        {
            var validator = new UpdateCommentCommandValidator();
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
        public async Task<IActionResult> GetCommentByIdAsync([FromRoute] Guid id)
        {
            if(id == Guid.Empty)
            {
                return BadRequest();
            }

            await _mediator.Send(new GetCommentByIdQuery(id));

            return View();
        }

        [Route("[GetAllComments]")]
        [HttpGet]
        public async Task<IActionResult> GetAllCommentsAsync()
        {
            await _mediator.Send(new GetAllCommentsQuery());

            return View();
        }
    }
}
