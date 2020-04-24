using System.Collections.Generic;
using MongoDB.Driver;

namespace SecretWeapon.Tools.Database
{
    public interface IRepository<T>
    {
        void CreateOne(T value);

        void CreateMany(IEnumerable<T> value);

        UpdateResult UpdateOne(T value);

        IEnumerable<T> UpdateMany(IEnumerable<T> value);

        DeleteResult DeleteOne(T value);

        void DeleteMany(IEnumerable<T> value);
    }
}