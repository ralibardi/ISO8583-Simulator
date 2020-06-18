using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SecretWeapon.Management.Managers;
using SecretWeapon.Management.Models;
using Swashbuckle.Swagger.Annotations;

namespace SecretWeapon.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionsManager _transactionsManager;
        private readonly ILogger<TransactionsController> _logger;

        public TransactionsController(ILogger<TransactionsController> logger, ITransactionsManager transactionsManager)
        {
            _transactionsManager = transactionsManager ?? throw new ArgumentNullException(nameof(transactionsManager));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [Route("Get/{transactionId}")]
        [SwaggerResponse(HttpStatusCode.OK, "Transaction retrieved successfully")]
        [SwaggerResponse(HttpStatusCode.NotFound, "Transaction couldn't be found")]
        [SwaggerResponse(HttpStatusCode.Created, "Transaction received but waiting for response")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Transaction corrupted")]
        public IActionResult GetTransaction([FromRoute] int transactionId)
        {
            _logger.Log(LogLevel.Trace, transactionId, $"A transaction with id {transactionId} is being consulted");
            var result = _transactionsManager.GetOne(transactionId);

            if (result == null)
            {
                _logger.Log(LogLevel.Error, transactionId, $"A transaction with id {transactionId} couldn't be found");
                return NotFound();
            }

            _logger.Log(LogLevel.Information, transactionId, $"A transaction with id {transactionId} was retrieved successfully");

            return Ok(result);
        }

        [HttpGet]
        [Route("Get")]
        [SwaggerResponse(HttpStatusCode.OK, "Transactions retrieved successfully")]
        [SwaggerResponse(HttpStatusCode.NotFound, "No transactions found")]
        public IActionResult GetTransaction()
        {
            _logger.Log(LogLevel.Trace, "A check on all transactions is being called");
            var result = _transactionsManager.GetAll();

            if (result == null)
            {
                _logger.Log(LogLevel.Error, "Couldn't find any transactions");
                return NotFound();
            }

            _logger.Log(LogLevel.Information, "All transactions retrieved successfully");
            return Ok(result);
        }

        [HttpPost]
        [Route("Post")]
        [SwaggerResponse(HttpStatusCode.OK, "Transaction created successfully")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Transaction not valid")]
        public IActionResult Create([FromBody] JsonDocument document)
        {
            _logger.Log(LogLevel.Trace, "A new transaction will be created");

            var transaction = JsonSerializer.Deserialize<TransactionModel>(document.ToString());

            var result = _transactionsManager.CreateOne(transaction);

            if (result == null)
            {
                _logger.Log(LogLevel.Error, "Couldn't create the transaction");
                return NotFound();
            }

            _logger.Log(LogLevel.Information, "Transaction created successfully");
            return Ok(result);
        }

        [HttpPatch]
        [Route("Patch/{transactionId}")]
        [SwaggerResponse(HttpStatusCode.OK, "Transaction modified successfully")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Couldn't modify transaction")]
        public IActionResult ModifyTransaction([FromRoute] int transactionId, [FromBody] JsonPatchDocument<TransactionModel> transaction)
        {
            _logger.Log(LogLevel.Trace, "A transaction will be modified");

            var result = _transactionsManager.UpdateOne(transactionId, transaction);

            if (result.IsAcknowledged)
            {
                _logger.Log(LogLevel.Error, "Couldn't modify the transaction");
                return NotFound();
            }

            _logger.Log(LogLevel.Information, "Transaction modified successfully");
            return Ok(result);
        }

        [HttpDelete]
        [Route("Delete/{transactionId}")]
        [SwaggerResponse(HttpStatusCode.OK, "Transaction deleted successfully")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Couldn't delete transaction")]
        public IActionResult Delete([FromRoute] int transactionId)
        {
            _logger.Log(LogLevel.Trace, transactionId, $"A transaction with id {transactionId} will be deleted");

            var result = _transactionsManager.RemoveOne(transactionId);

            if (!result.IsAcknowledged)
            {
                _logger.Log(LogLevel.Error, transactionId, $"A transaction with id {transactionId} couldn't be deleted");

                return NotFound();
            }

            _logger.Log(LogLevel.Information, transactionId, $"A transaction with id {transactionId} was deleted successfully");
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteBulk")]
        [SwaggerResponse(HttpStatusCode.OK, "Transactions deleted successfully")]
        [SwaggerResponse(HttpStatusCode.BadRequest, "Couldn't delete one or more transactions")]
        public IActionResult BulkDelete([FromBody] IEnumerable<int> transactionsIds)
        {
            _logger.Log(LogLevel.Trace, "A bulk delete of all transactions will be initiated");

            var result = _transactionsManager.RemoveMany(transactionsIds);

            if (result.IsAcknowledged)
            {
                _logger.Log(LogLevel.Information, "All transactions retrieved successfully");
                return Ok(result);
            }

            _logger.Log(LogLevel.Error, $"Couldn't delete {result.DeletedCount} transactions");
            return BadRequest(result);
        }
    }
}
