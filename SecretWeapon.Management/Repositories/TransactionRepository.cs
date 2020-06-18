using SecretWeapon.DataModel;
using SecretWeapon.Tools.Context;
using SecretWeapon.Tools.Database;

namespace SecretWeapon.Management.Repositories
{
    public interface ITransactionRepository : IRepository<Transaction>
    {
    }

    // Implementation
    public class TransactionRepository : BaseRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(IMongoContext context) : base(context)
        {
        }
    }
}