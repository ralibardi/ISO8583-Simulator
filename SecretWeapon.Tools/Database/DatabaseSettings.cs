using MongoDB.Driver;

namespace SecretWeapon.Tools.Database
{
    public class DatabaseSettings
    {
        public static IMongoDatabase Database;

#if DEBUG
        public const string DatabaseName = "SecretWeapon";
        public const string Connection = "mongodb://localhost:37017/";
#else
        public const string DatabaseName = "secret_weapon_db";

        public static readonly string Connection =
        $"mongodb://app_secret_weapon:77a490bace4c4d19a081280c34d60fcf6f013fad@localhost:10180/{DatabaseName}?replicaSet=dev-secret_weapon-rs";
#endif

        public static void ConnectToDatabase()
        {
            Database = new MongoClient(Connection).GetDatabase(DatabaseName);
        }
    }
}
