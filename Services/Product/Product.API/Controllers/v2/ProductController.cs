using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Product.Application.Queries;
using Product.Application.Responses;
using Product.Core.Specs;
using System.Net;

namespace Product.API.Controllers.v2
{
    [ApiVersion("2.0")]
    public class ProductController : APIController
    {
        private readonly IMediator _mediator;
        
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public ActionResult<string> HomePage()
        {
            return Ok("Product Version 2.0");
        }

        [HttpGet]
        [Route("GetEmployeeById/{id}", Name = "GetEmployeeById")]
        [ProducesResponseType(typeof(EmployeeResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<EmployeeResponse>> GetEmployeeById(Guid id)
        {
            var payLoad = new GetEmployeeByIdQuery(id);
            var response = await _mediator.Send(payLoad);
            return Ok(response);
        }

        [HttpGet]
        [Route("GetEmployees", Name = "GetEmployees")]
        [ProducesResponseType(typeof(IEnumerable<EmployeeResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<EmployeeResponse>>> GetEmployees([FromQuery]Pagination pagination)
        {
            var payLoad = new GetAllEmployeesQuery(pagination);
            var response = await _mediator.Send(payLoad);
            return Ok(response);
        }
    }
}
