using CallScheduler.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallScheduler.Interfaces
{
    public interface IAuditService
    {
        // Task CreateAudit(string action, string description, IPermissionService perm = null);
        Task CreateAudit(string action, string description);
        Task CreateAudit<TEntity>(TEntity entity, AuditType action, string description, string type = null) where TEntity : class, IEntityBase, IAuditDescriptionBase;
        Task CreateAudit<TEntity>(TEntity entity, AuditType action) where TEntity : class, IEntityBase, IAuditDescriptionBase;
        Task CreateAuditAccount<TEntity>(TEntity entity, AuditType action) where TEntity : class, IEntityBase, IAuditDescriptionBase;
    }
}
