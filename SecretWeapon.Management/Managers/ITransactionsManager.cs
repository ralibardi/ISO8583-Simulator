using System.Collections.Generic;
using Microsoft.AspNetCore.JsonPatch;
using SecretWeapon.Management.Models;
using SecretWeapon.Tools.Validation;

namespace SecretWeapon.Management.Managers
{
    public interface ITransactionsManager
    {
        TransactionModel Get(int id);
        IEnumerable<TransactionModel> GetAll();
        ValidationResultModel<TransactionModel> Create(TransactionModel value);
        ValidationResultModel<TransactionModel> ModifyTransaction(int id, JsonPatchDocument<TransactionModel> value);
        void Delete(int id);
    }
}