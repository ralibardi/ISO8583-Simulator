using System.Collections.Generic;
using Microsoft.AspNetCore.JsonPatch;
using MongoDB.Driver;
using SecretWeapon.Management.Models;

namespace SecretWeapon.Management.Managers
{
    public interface ITransactionsManager
    {
        TransactionModel GetOne(int id);

        IEnumerable<TransactionModel> GetAll();

        TransactionModel CreateOne(TransactionModel value);

        IEnumerable<TransactionModel> CreateMany(IEnumerable<TransactionModel> value);

        UpdateResult UpdateOne(int transactionId, JsonPatchDocument<TransactionModel> transaction);

        UpdateResult UpdateMany(IEnumerable<int> ids, JsonPatchDocument<IEnumerable<TransactionModel>> patch);

        DeleteResult RemoveOne(int id);

        DeleteResult RemoveMany(IEnumerable<int> ids);
    }
}