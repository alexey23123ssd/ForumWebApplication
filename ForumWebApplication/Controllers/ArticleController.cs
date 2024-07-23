using Application.Features.Articles.Commands.CreateArticle;
using Application.Features.Articles.Commands.DeleteArticle;
using Application.Features.Articles.Commands.UpdateArticle;
using Application.Features.Themes.Queries;
using Application.Features.ValidatorBehaviors;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ForumWebApplication.Controllers
{
    [Route("[contoller]")]
    public class ArticleController : Controller
    {
        private readonly IMediator _mediator;
        public ArticleController(IMediator mediator) 
        { 
            _mediator = mediator;
        }

        [Route("[Create]")]
        [HttpPost]
        public async Task<IActionResult> CreateArticleAsync([FromForm] CreateArticleCommand command)
        {
            var validator = new CreateArticleCommandValidator(); 
            var result = validator.Validate(command);

            if(result.IsValid) 
            { 
                await _mediator.Send(command); 
            }
            
            return View();
        }

        [Route("[Delete]/{id?}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteArticleAsync([FromRoute] Guid id)
        {
            if (id == Guid.Empty)
            {
                return BadRequest();
            }

            await _mediator.Send(new DeleteArticleCommand(id));

            return View();
        }

        [Route("[Update]/{id?}")]
        [HttpPut]
        public async Task<IActionResult> UpdateArticleAsync([FromRoute] Guid id, [FromForm] UpdateArticleCommand command)
        {
            var validator = new UpdateArticleCommandValidator();
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
        public async Task<IActionResult> GetArticleByIdAsync([FromRoute] Guid id)
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
