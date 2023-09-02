using MagazynEdu.DataAccess;
using MagazynEdu.DataAccess.Entities;
using MagazynEduApplicationServices.API.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MagazynEdu.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookCaseController : ApiControllerBase
    {
        

        public BookCaseController(IMediator mediator) :base(mediator)
        {
            
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddBookCase([FromBody] AddBookCaseRequest request)
        {
            return this.HandleRequest<AddBookCaseRequest, AddBookCaseResponse>(request);
           
        }
    }
}
