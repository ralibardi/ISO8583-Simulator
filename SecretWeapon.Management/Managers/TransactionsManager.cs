using System.Collections.Generic;
using System.Text.Json;
using Microsoft.AspNetCore.JsonPatch;
using SecretWeapon.Management.Models;
using SecretWeapon.Tools.Validation;

namespace SecretWeapon.Management.Managers
{
    public class TransactionsManager : ITransactionsManager
    {
        public ValidationResultModel<TransactionModel> Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public ValidationResultModel<IEnumerable<TransactionModel>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public ValidationResultModel<TransactionModel> Create(JsonDocument value)
        {
            throw new System.NotImplementedException();
        }

        public ValidationResultModel<TransactionModel> ModifyTransaction(int id, JsonPatchDocument<TransactionModel> value)
        {
            throw new System.NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IDictionary<int, bool> BulkDelete(IEnumerable<int> ids)
        {
            throw new System.NotImplementedException();
        }
    }
}
