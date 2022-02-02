using osu.Framework.Testing;

namespace maisim.Game.Tests.Visual
{
    public class maisimTestScene : TestScene
    {
        protected override ITestSceneTestRunner CreateRunner() => new maisimTestSceneTestRunner();

        private class maisimTestSceneTestRunner : maisimGameBase, ITestSceneTestRunner
        {
            private TestSceneTestRunner.TestRunner runner;

            protected override void LoadAsyncComplete()
            {
                base.LoadAsyncComplete();
                Add(runner = new TestSceneTestRunner.TestRunner());
            }

            public void RunTestBlocking(TestScene test) => runner.RunTestBlocking(test);
        }
    }
}