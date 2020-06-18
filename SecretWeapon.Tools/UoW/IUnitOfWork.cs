using System;
using System.Threading.Tasks;

namespace SecretWeapon.Tools.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();
    }
}