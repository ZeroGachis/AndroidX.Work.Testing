using Android.Content;

namespace AndroidX.Work.Testing.UnitTests
{
    public class RetryWorker : Worker
    {
        public RetryWorker(Context context, WorkerParameters workerParams)
            : base(context, workerParams) { }

        public static PeriodicWorkRequest Build()
        {
            Constraints constraints = new Constraints.Builder()
                .SetRequiresCharging(true)
                .Build();

            var syncWorkRequest = PeriodicWorkRequest
                .Builder
                .From<RetryWorker>(TimeSpan.FromMinutes(15))
                .SetConstraints(constraints)
                .Build();

            return syncWorkRequest;
        }

        public override Result DoWork()
        {
            return Result.InvokeRetry();
        }
    }
}
