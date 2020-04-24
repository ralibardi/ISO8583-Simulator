using SecretWeapon.Tools.Database;

namespace SecretWeapon.Management.Repositories
{
    public class TransactionRepository : BaseRepository<DataModel.Transaction>
    {
        public TransactionRepository() : base(Resources.TransactionCollectionName)
        {
        }
    }
}