using AutoMapper;
using SecretWeapon.DataModel;
using SecretWeapon.Management.Models;

namespace SecretWeapon.Management.Profiles
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<TransactionModel, Transaction>();
            CreateMap<Transaction, TransactionModel>();
        }
    }
}