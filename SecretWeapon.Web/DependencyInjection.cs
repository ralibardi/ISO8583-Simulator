using Microsoft.Extensions.DependencyInjection;
using SecretWeapon.Management.Managers;

namespace SecretWeapon.Web
{
    public static class DependencyInjection
    {
        public static void AddDependencies(this IServiceCollection servicesCollection)
        {
            servicesCollection.AddSingleton<ITransactionsManager>(new TransactionsManager());
        }
    }
}