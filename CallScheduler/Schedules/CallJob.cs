using CallScheduler.Data;
using CallScheduler.Enums;
using CallScheduler.Interfaces;
using FluentScheduler;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;

namespace CallScheduler.Schedules
{
    public class CallJob : IScheduleJob
    {
        #region Static
        private const string Name = "CallJob";
        public static int Hour { get; set; }
        public static int Minute { get; set; }
        public static int Days { get; set; }

        public static void Setup(ScheduleRegistry registry)
        {
            registry
                .Schedule<CallJob>()
                .WithName(Name)
                .ToRunEvery(1)
                .Days()
                .At(Hour, Minute);
        }

        public static void Stop() => JobManager.RemoveJob(Name);
        #endregion

        #region Instance

        private CallSchedulerDbContext Context { get; }

        public CallJob()
        {
            Context = ScheduleRegistry.GetDbContext();
        }

        public Action<string> Log { get; set; }
        public Action<object> LogObj { get; set; }

        public void Execute()
        {
            new Thread(async () =>
            {
                var schedules = await (from schedule in Context.Schedules
                                       where schedule.DateToRun.Date == DateTime.Now.Date &&
                                       schedule.DateToRun.TimeOfDay.Hours == DateTime.Now.TimeOfDay.Hours &&
                                       schedule.DateToRun.TimeOfDay.Minutes == DateTime.Now.TimeOfDay.Minutes
                                       orderby schedule.Id
                                       select schedule).ToListAsync();

                if (!schedules.Any()) return;

                foreach (var schedule in schedules)
                {
                    var call = Context.Calls.FirstOrDefault(c => c.Id == schedule.CallId);
                    if (call.Status == CallStatus.Completed || call.Status == CallStatus.PendingOnBank)
                    {
                        call.MetSLA = true;
                        Context.Calls.Update(call);
                        await Context.SaveChangesAsync();
                    }
                }
            }).Start();
        }

        #endregion
    }
}
