using System.Collections.Generic;
using System.Text.Json;
using Microsoft.AspNetCore.JsonPatch;
using SecretWeapon.Management.Models;
using SecretWeapon.Tools.Validation;

namespace SecretWeapon.Management.Managers
{
    public interface ITransactionsManager
    {
        ValidationResultModel<TransactionModel> Get(int id);
        ValidationResultModel<IEnumerable<TransactionModel>> GetAll();
        ValidationResultModel<TransactionModel> Create(JsonDocument value);
        ValidationResultModel<TransactionModel> ModifyTransaction(int id, JsonPatchDocument<TransactionModel> value);
        bool Delete(int id);
        IDictionary<int, bool> BulkDelete(IEnumerable<int> ids);
    }
}