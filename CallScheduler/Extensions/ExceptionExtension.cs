using System;

namespace CallScheduler.Extensions
{
    public static class ExceptionExtension
    {
        public static string InnerMostMessage(this Exception exception)
        {
            var msg = string.Empty;
            var inner = exception?.InnerException ?? exception;
            while (inner != null)
            {
                msg = inner.Message;
                inner = inner.InnerException;
            }
            return msg;
        }
    }
}
