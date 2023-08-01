using MagazynEduApplicationServices.API.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MagazynEdu.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IMediator mediator;

        public BooksController(IMediator mediator) 
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllBooks([FromQuery] GetBookByIdRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
        [HttpGet]
        [Route("{bookId}")]
        public async Task<IActionResult> GetById([FromRoute] int bookId)
        {
            var request = new GetBookByIdRequest()
            {
                BookId = bookId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
    }
}
