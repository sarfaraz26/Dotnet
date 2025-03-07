using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Product.Application.Commands;
using Product.Application.Responses;
using Product.Core.Specs;
using System.Net;

namespace Product.API.Controllers.v1
{
    [ApiVersion("1.0")]
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
            return Ok("Product Version 1.0");
        }

        [HttpPost]
        [Route("CreateEmployee")]
        [ProducesResponseType(typeof(EmployeeResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<EmployeeResponse>> CreateEmployee([FromBody] CreateEmployeeCommand employeeCommand)
        {
            var result = await _mediator.Send<EmployeeResponse>(employeeCommand);
            return Ok(result);
        }

        [HttpDelete]
        [Route("DeleteEmployee/{id}", Name = "DeleteEmployeeById")]
        [ProducesResponseType(typeof(bool), (int) HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> DeleteEmployee(Guid id)
        {
            var payLoad = new DeleteEmployeeByIdCommand(id);
            var result = await _mediator.Send(payLoad);
            return Ok(result);
        }

        [HttpPut]
        [Route("UpdateEmployee/{id}", Name = "UpdateEmployeeById")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<bool>> UpdateEmployee(Guid id, [FromBody]UpdateEmployeeByIdCommand command)
        {
            var payLoad = new UpdateEmployeeByIdCommand(id, command.Email, command.IsResigned);
            var result = await _mediator.Send(payLoad);
            return Ok(result);
        }

    }
}
