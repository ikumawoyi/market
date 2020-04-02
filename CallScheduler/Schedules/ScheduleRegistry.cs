using CallScheduler.Data;
using FluentScheduler;

namespace CallScheduler.Schedules
{
    public class ScheduleRegistry : Registry
    {
        public static readonly string Name = "Scheduler";

        public ScheduleRegistry()
        {
            Schedule<CallJob>().ToRunNow().AndEvery(1).Minutes();
            CallJob.Setup(this);
        }

        public static void RunNow(string pool)
        {
            var reg = new Registry();
            Schedule s = null;
            switch (pool)
            {
                case "call":
                    s = reg.Schedule<CallJob>();
                    break;
            }
            s?.Execute();
        }

        public static CallSchedulerDbContext GetDbContext() => new CallSchedulerDbContext(Utils.GetContextOption<CallSchedulerDbContext>());

        public CallSchedulerDbContext Context = GetDbContext();
    }
}
