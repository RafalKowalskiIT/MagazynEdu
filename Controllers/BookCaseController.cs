using MagazynEdu.DataAccess;
using MagazynEdu.DataAccess.Entities;
using MagazynEduApplicationServices.API.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MagazynEdu.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookCaseController : ControllerBase
    {
        private readonly IMediator mediator;

        public BookCaseController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddBookCase([FromBody] AddBookCaseRequest request)
        {
            var response = await this.mediator.Send(request);
            return Ok(response);
        }
    }
}
