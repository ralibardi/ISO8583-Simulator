using System.Collections.Generic;
using System.Net;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SecretWeapon.Management.Models;
using Swashbuckle.Swagger.Annotations;

namespace SecretWeapon.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly ILogger<TransactionsController> _logger;

        public TransactionsController(ILogger<TransactionsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("Get/{transactionId}")]
        [SwaggerResponse(HttpStatusCode.OK, "Transaction retrieved successfully")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Transaction couldn't be found")]
        [SwaggerResponse(HttpStatusCode.Created, "Transaction received but waiting for response")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Transaction corrupted")]
        public IActionResult GetTransaction([FromRoute] int transactionId)
        {
            var result = new TransactionModel();

            return Ok(result);
        }

        [HttpGet]
        [Route("Get")]
        [SwaggerResponse(HttpStatusCode.OK, "Transactions retrieved successfully")]
        [SwaggerResponse(HttpStatusCode.NotFound, "No transactions found")]
        public IActionResult GetTransaction()
        {
            var result = new List<TransactionModel>
            {
                new TransactionModel(),
                new TransactionModel(),
                new TransactionModel(),
                new TransactionModel(),
                new TransactionModel()
            };

            return Ok(result);
        }
    }
}
