using CallScheduler.Enums;

namespace CallScheduler.Interfaces
{
    public interface IAuditDescriptionBase
    {
        string GetAuditDescription(AuditType action, bool forApproval = false);
    }
}
