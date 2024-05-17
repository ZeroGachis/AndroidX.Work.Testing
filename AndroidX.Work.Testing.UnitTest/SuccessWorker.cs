using Android.Content;
using System;

namespace AndroidX.Work.Testing.UnitTests
{
    public class SuccessWorker : Worker
    {
        public SuccessWorker(Context context, WorkerParameters workerParams)
            : base(context, workerParams) { }

        public static PeriodicWorkRequest Build()
        {
            Constraints constraints = new Constraints.Builder()
                .SetRequiresCharging(true)
                .Build();

            var syncWorkRequest = PeriodicWorkRequest
                .Builder
                .From<SuccessWorker>(TimeSpan.FromMinutes(15))
                .SetConstraints(constraints)
                .Build();

            return syncWorkRequest;
        }

        public override Result DoWork()
        {
            return Result.InvokeSuccess();
        }
    }
}
