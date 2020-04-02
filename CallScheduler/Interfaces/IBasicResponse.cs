namespace CallScheduler.Interfaces
{
    public interface IBasicResponse
    {
        string Status { get; set; }
        bool Success { get; set; }
    }
}
