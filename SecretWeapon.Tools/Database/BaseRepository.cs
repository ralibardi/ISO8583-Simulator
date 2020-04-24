using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using InsertManyOptions = MongoDB.Driver.InsertManyOptions;

namespace SecretWeapon.Tools.Database
{
    public class BaseRepository<T> : IRepository<T>
    {
        private readonly string _collectionName;

        public BaseRepository(string collectionName)
        {
            _collectionName = collectionName;
        }

        private IMongoCollection<T> GetMongoCollection()
        {
            DatabaseSettings.ConnectToDatabase();

            return DatabaseSettings.Database.GetCollection<T>(_collectionName);
        }

        public void CreateOne(T value)
        {
            var collection = GetMongoCollection();

            collection.InsertOne(value);
        }

        public void CreateMany(IEnumerable<T> value)
        {
            var collection = GetMongoCollection();

            collection.InsertMany(value, new InsertManyOptions());
        }

        public UpdateResult UpdateOne(T value)
        {
            var collection = GetMongoCollection();

            FilterDefinition<T> filter = new BsonDocumentFilterDefinition<T>(BsonDocument.Create(value));
            UpdateDefinition<T> update = new BsonDocumentUpdateDefinition<T>(BsonDocument.Create(value));

            return collection.UpdateOne(filter, update);
        }

        public IEnumerable<T> UpdateMany(IEnumerable<T> value)
        {
            throw new System.NotImplementedException();
        }

        public DeleteResult DeleteOne(T value)
        {
            var collection = GetMongoCollection();

            FilterDefinition<T> filter = new BsonDocumentFilterDefinition<T>(BsonDocument.Create(value));

            return collection.DeleteOne(filter);
        }

        public void DeleteMany(IEnumerable<T> value)
        {
            throw new System.NotImplementedException();
        }
    }
}