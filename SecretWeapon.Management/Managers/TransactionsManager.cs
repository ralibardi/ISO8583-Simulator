using System.Collections.Generic;
using Microsoft.AspNetCore.JsonPatch;
using SecretWeapon.Management.Models;
using SecretWeapon.Tools.Validation;

namespace SecretWeapon.Management.Managers
{
    public class TransactionsManager : ITransactionsManager
    {
        public TransactionModel Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<TransactionModel> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public ValidationResultModel<TransactionModel> Create(TransactionModel value)
        {
            throw new System.NotImplementedException();
        }

        public ValidationResultModel<TransactionModel> ModifyTransaction(int id, JsonPatchDocument<TransactionModel> value)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
