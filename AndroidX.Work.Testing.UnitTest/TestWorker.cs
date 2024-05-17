using Android.Content;
using Androidx.Work.Testing;
using NUnit.Framework;

namespace AndroidX.Work.Testing.UnitTests
{
    public class TestWorker
    {
        public Context Context { get; private set; }
        public WorkManager WorkManager { get; private set; }

        [TestFixtureSetUp]
        public void OneTimeSetup()
        {
            Context = Application.Context;
            WorkManagerTestInitHelper.InitializeTestWorkManager(Context);
            WorkManager = WorkManager.GetInstance(Context);
        }
    }
}