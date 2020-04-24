using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using SecretWeapon.Management.Managers;
using SecretWeapon.Management.Models;
using SecretWeapon.Tools.Validation;
using Swashbuckle.Swagger.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SecretWeapon.Web.Controllers
{
    [Route("api/transaction")]
    public class TransactionController : Controller
    {
        private readonly ITransactionsManager _transactionManager;

        public TransactionController(ITransactionsManager transactionManager)
        {
            _transactionManager = transactionManager;
        }

        // GET: api/<controller>
        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(IEnumerable<TransactionModel>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Type = typeof(IEnumerable<TransactionModel>))]
        public IActionResult Get()
        {
            var transactions = _transactionManager.GetAll();

            if (transactions == null || !transactions.Any())
            {
                return NotFound();
            }

            return Ok(transactions);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(TransactionModel))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Type = typeof(TransactionModel))]
        public IActionResult Get([FromRoute] int id)
        {
            var transaction = _transactionManager.Get(id);

            if (transaction == null)
            {
                return NotFound();
            }

            return Ok(transaction);
        }

        // POST api/<controller>
        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(TransactionModel))]
        [SwaggerResponse(StatusCodes.Status404NotFound, Type = typeof(TransactionModel))]
        public IActionResult Post([FromBody] TransactionModel value)
        {
            var result = _transactionManager.Create(value);

            if (result.DeValidationResult.HasErrors())
            {
                return NotFound();
            }

            return Ok(result.DeEntity);
        }

        [HttpPatch]
        [Route("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(TransactionModel))]
        [SwaggerResponse(StatusCodes.Status422UnprocessableEntity,
            Type = typeof(Dictionary<string, IEnumerable<string>>),
            Description = "Validation errors dictionary, keyed by property name.")]
        public IActionResult Patch([FromRoute] int id, [FromBody] JsonPatchDocument<TransactionModel> value)
        {
            var transaction = _transactionManager.ModifyTransaction(id, value);

            if (transaction == null)
            {
                return NotFound();
            }

            return Ok(transaction);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status404NotFound)]
        public void Delete(int id)
        {
            _transactionManager.Delete(id);
        }
    }
}
