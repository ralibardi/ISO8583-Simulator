using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using SecretWeapon.Management.Managers;
using SecretWeapon.Management.Models;
using SecretWeapon.Management.Repositories;
using SecretWeapon.Management.Validators;
using SecretWeapon.Tools.Context;
using SecretWeapon.Tools.UoW;
using SecretWeapon.Web.DBContext;

namespace SecretWeapon.Web
{
    public static class DependencyInjection
    {
        public static void AddDependencies(this IServiceCollection servicesCollection)
        {
            //DBContext
            servicesCollection.AddScoped<IMongoContext, MongoContext>();

            //Unit of Work Pattern
            servicesCollection.AddScoped<IUnitOfWork, UnitOfWork>();

            //Validators
            servicesCollection.AddTransient<IValidator<TransactionModel>, TransactionsValidator>();

            //Repositories
            servicesCollection.AddScoped<ITransactionRepository, TransactionRepository>();

            //Managers
            servicesCollection.AddScoped<ITransactionsManager, TransactionsManager>();
        }
    }
}