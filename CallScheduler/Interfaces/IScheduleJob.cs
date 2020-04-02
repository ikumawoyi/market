using FluentScheduler;
using System;

namespace CallScheduler.Interfaces
{
    public interface IScheduleJob : IJob
    {
        Action<string> Log { get; set; }
        Action<object> LogObj { get; set; }
    }
}
