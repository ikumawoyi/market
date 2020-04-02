using CallScheduler.Enums;
using CallScheduler.Models;
using System.Threading.Tasks;

namespace CallScheduler.Interfaces
{
    public interface IAuthorizationService
    {
        Task Initiate<TEntity>(TEntity entity, string action, string desc, string code, AuditType type) where TEntity : class, IEntityBase;
        Task<BasicResponse> Authorize<TEntity>(int id, bool isApproved, string checksum) where TEntity : class, IEntityBase;
    }
}
