using System.Linq;
using MongoDB.Bson.Serialization.Attributes;

namespace SecretWeapon.Management.Models
{
    public class TransactionModel
    {
        [BsonIgnoreIfNull]
        public string DePlainText { get; set; }

        [BsonIgnoreIfNull]
        public string DeSizeInString { get; set; }

        [BsonIgnoreIfNull]
        public int DeSize { get; set; }

        [BsonIgnoreIfNull]
        public string DeTpdu { get; set; }                //TPDU

        [BsonIgnoreIfNull]
        public ISOFieldModel Fields { get; set; }

        public override string ToString()
        {
            return GetType()
                .GetProperties()
                .Where(p => p.GetValue(this) != null && p.Name != "PlainText" && p.Name != "Size")
                .Aggregate(string.Empty, (s, p) => s + (string)p.GetValue(this));
        }
    }
}