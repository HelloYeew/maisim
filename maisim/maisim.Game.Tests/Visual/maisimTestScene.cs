using osu.Framework.Allocation;
using osu.Framework.Testing;

namespace maisim.Game.Tests.Visual
{
    // ReSharper disable once InconsistentNaming
    public partial class maisimTestScene : TestScene
    {
        protected override ITestSceneTestRunner CreateRunner() => new maisimTestSceneTestRunner();

        public new DependencyContainer Dependencies { get; set; }

        protected override IReadOnlyDependencyContainer CreateChildDependencies(IReadOnlyDependencyContainer parent)
        {
            Dependencies = new DependencyContainer(base.CreateChildDependencies(parent));
            return Dependencies;
        }

        // ReSharper disable once InconsistentNaming
        private partial class maisimTestSceneTestRunner : maisimGameBase, ITestSceneTestRunner
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
