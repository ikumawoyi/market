using CallScheduler.Interfaces;

namespace CallScheduler.Models
{
    public class BasicResponse : IBasicResponse
    {
        public string Status { get; set; }
        public bool Success { get; set; }

        public static BasicResponse SuccessResult(string status = null) => new BasicResponse { Success = true, Status = status };
        public static BasicResponse FailureResult(string status) => new BasicResponse { Success = false, Status = status };

        public override string ToString() => Status;
    }
}
