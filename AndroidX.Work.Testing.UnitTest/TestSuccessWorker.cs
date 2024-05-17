using Androidx.Work.Testing;
using NFluent;
using NUnit.Framework;

namespace AndroidX.Work.Testing.UnitTests
{

    [TestFixture]
    public class TestSuccessWorker : TestWorker
    {
        public PeriodicWorkRequest Worker { get; private set; }

        public IOperation Operation { get; private set; }

        [SetUp]
        public void Setup()
        {
            Worker = SuccessWorker.Build();
            Operation = WorkManager.EnqueueUniquePeriodicWork("Work", ExistingPeriodicWorkPolicy.Update, Worker);
        }

        [TearDown]
        public void TearDown()
        {
            WorkManager.CancelUniqueWork("Work");
        }

        [Test]
        public void Success()
        {
            var driver = WorkManagerTestInitHelper.GetTestDriver(Context);

            driver.SetAllConstraintsMet(Worker.Id);

            var workInfo = (WorkInfo)WorkManager.GetWorkInfoById(Worker.Id).Get();
            Check.That(workInfo.RunAttemptCount).IsEqualTo(0);

        }
    }
}