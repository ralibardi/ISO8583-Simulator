using System.Collections.Generic;

namespace SecretWeapon.DataModel
{
    public class Transaction
    {
        public int Size { get; set; }

        public string Tpdu { get; set; } //TPDU

        public Dictionary<int, ISOField> Fields { get; set; }
    }
}