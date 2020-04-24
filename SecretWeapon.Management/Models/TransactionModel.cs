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
        public string DeMessage { get; set; }             //MSG

        [BsonIgnoreIfNull]
        public string DeBitmap { get; set; }              //bitmap

        [BsonIgnoreIfNull]
        public string De02 { get; set; }                //DE02

        public string De03 { get; set; }                //DE03

        [BsonIgnoreIfNull]
        public string De04 { get; set; }                //DE04

        [BsonIgnoreIfNull]
        public string De05 { get; set; }                //DE05

        [BsonIgnoreIfNull]
        public string De06 { get; set; }                //DE06

        [BsonIgnoreIfNull]
        public string De07 { get; set; }                //DE07

        [BsonIgnoreIfNull]
        public string De08 { get; set; }                //DE08

        [BsonIgnoreIfNull]
        public string De09 { get; set; }                //DE09

        [BsonIgnoreIfNull]
        public string De10 { get; set; }                //DE10

        [BsonIgnoreIfNull]
        public string De11 { get; set; }                //DE11

        [BsonIgnoreIfNull]
        public string De12 { get; set; }                //DE12

        [BsonIgnoreIfNull]
        public string De13 { get; set; }                //DE13

        [BsonIgnoreIfNull]
        public string De14 { get; set; }                //DE14

        [BsonIgnoreIfNull]
        public string De15 { get; set; }                //DE15

        [BsonIgnoreIfNull]
        public string De16 { get; set; }                //DE16

        [BsonIgnoreIfNull]
        public string De17 { get; set; }                //DE17

        [BsonIgnoreIfNull]
        public string De18 { get; set; }                //DE18

        [BsonIgnoreIfNull]
        public string De19 { get; set; }                //DE19

        [BsonIgnoreIfNull]
        public string De20 { get; set; }                //DE20

        [BsonIgnoreIfNull]
        public string De21 { get; set; }                //DE21

        [BsonIgnoreIfNull]
        public string De22 { get; set; }                //DE22

        [BsonIgnoreIfNull]
        public string De23 { get; set; }                //DE23

        [BsonIgnoreIfNull]
        public string De24 { get; set; }                 //DE24

        [BsonIgnoreIfNull]
        public string De25 { get; set; }                //DE25

        [BsonIgnoreIfNull]
        public string De26 { get; set; }                //DE26

        [BsonIgnoreIfNull]
        public string De27 { get; set; }                //DE27

        [BsonIgnoreIfNull]
        public string De28 { get; set; }                //DE28

        [BsonIgnoreIfNull]
        public string De29 { get; set; }                //DE29

        [BsonIgnoreIfNull]
        public string De30 { get; set; }                //DE30

        [BsonIgnoreIfNull]
        public string De31 { get; set; }                //DE31

        [BsonIgnoreIfNull]
        public string De32 { get; set; }                //DE32

        [BsonIgnoreIfNull]
        public string De33 { get; set; }                //DE33

        [BsonIgnoreIfNull]
        public string De34 { get; set; }                //DE34

        [BsonIgnoreIfNull]
        public string De35 { get; set; }                //DE35

        [BsonIgnoreIfNull]
        public string De36 { get; set; }                //DE36

        [BsonIgnoreIfNull]
        public string De37 { get; set; }                //DE37

        [BsonIgnoreIfNull]
        public string De38 { get; set; }                //DE38

        [BsonIgnoreIfNull]
        public string De39 { get; set; }                //DE39

        [BsonIgnoreIfNull]
        public string De40 { get; set; }                //DE40

        [BsonIgnoreIfNull]
        public string De41 { get; set; }                //DE41

        [BsonIgnoreIfNull]
        public string De42 { get; set; }                //DE42

        [BsonIgnoreIfNull]
        public string De43 { get; set; }                //DE43

        [BsonIgnoreIfNull]
        public string De44 { get; set; }                //DE44

        [BsonIgnoreIfNull]
        public string De45 { get; set; }                //DE45

        [BsonIgnoreIfNull]
        public string De46 { get; set; }                //DE46

        [BsonIgnoreIfNull]
        public string De47 { get; set; }                //DE47

        [BsonIgnoreIfNull]
        public string De48 { get; set; }                //DE48

        [BsonIgnoreIfNull]
        public string De49 { get; set; }                //DE49

        [BsonIgnoreIfNull]
        public string De50 { get; set; }                //DE50

        [BsonIgnoreIfNull]
        public string De51 { get; set; }                //DE51

        [BsonIgnoreIfNull]
        public string DePinBlock { get; set; }            //DE52

        [BsonIgnoreIfNull]
        public string De53 { get; set; }                //DE53

        [BsonIgnoreIfNull]
        public string De54 { get; set; }                //DE54

        [BsonIgnoreIfNull]
        public string De55 { get; set; }                //DE55

        ///////////////////////////////////////////////////
        [BsonIgnoreIfNull]
        public string De56 { get; set; }                //DE56

        [BsonIgnoreIfNull]
        public string De57 { get; set; }                //DE57

        [BsonIgnoreIfNull]
        public string De58 { get; set; }                //DE58

        [BsonIgnoreIfNull]
        public string De59 { get; set; }                //DE59

        [BsonIgnoreIfNull]
        public string De60 { get; set; }                //DE60

        [BsonIgnoreIfNull]
        public string De61 { get; set; }                //DE61

        [BsonIgnoreIfNull]
        public string De62 { get; set; }                //DE62

        [BsonIgnoreIfNull]
        public string De63 { get; set; }                //DE63

        public override string ToString()
        {
            return GetType()
                .GetProperties()
                .Where(p => p.GetValue(this) != null && p.Name != "PlainText" && p.Name != "Size")
                .Aggregate(string.Empty, (s, p) => s + (string)p.GetValue(this));
        }
    }
}