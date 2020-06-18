using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.JsonPatch;
using MongoDB.Driver;
using SecretWeapon.Management.Models;
using SecretWeapon.Management.Repositories;

namespace SecretWeapon.Management.Managers
{
    public class TransactionsManager : ITransactionsManager
    {
        private readonly IValidator<TransactionModel> _validation;
        private readonly ITransactionRepository _repository;
        private readonly IMapper _mapper;

        public TransactionsManager(IValidator<TransactionModel> validation, ITransactionRepository repository, IMapper mapper)
        {
            _validation = validation ?? throw new ArgumentNullException(nameof(validation));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public TransactionModel GetOne(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TransactionModel> GetAll()
        {
            var transactions = _repository.GetAll().Result;

            if (!transactions.Any())
            {
                return new List<TransactionModel>();
            }

            var transactionModels = _mapper.Map<IEnumerable<TransactionModel>>(transactions);

            return (from model in transactionModels let validationResult = _validation.Validate(transactionModels) where validationResult.IsValid select model).ToList();
        }

        public TransactionModel CreateOne(TransactionModel value)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TransactionModel> CreateMany(IEnumerable<TransactionModel> value)
        {
            throw new NotImplementedException();
        }

        public UpdateResult UpdateOne(int transactionId, JsonPatchDocument<TransactionModel> patch)
        {
            throw new NotImplementedException();
        }

        public UpdateResult UpdateMany(IEnumerable<int> ids, JsonPatchDocument<IEnumerable<TransactionModel>> patch)
        {
            throw new NotImplementedException();
        }

        public DeleteResult RemoveOne(int id)
        {
            throw new NotImplementedException();
        }

        public DeleteResult RemoveMany(IEnumerable<int> ids)
        {
            throw new NotImplementedException();
        }
    }
}
