﻿using MagazynEduApplicationServices.API.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MagazynEdu.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ApiControllerBase
    {
        private readonly IMediator mediator;

        public BooksController(IMediator mediator) : base(mediator) 
        { 
        }
        

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllBooks([FromQuery] GetBookRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
        [HttpGet]
        [Route("{bookId}")]
        public Task<IActionResult> GetById([FromRoute] int bookId)
        {
            var request = new GetBookByIdRequest()
            {
                BookId = bookId
            };
            
            return this.HandleRequest<GetBookByIdRequest, GetBookByIdResponse>(request);
        }
    }
}
