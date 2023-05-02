namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetPopularityTest()
        {
            StackoverflowAddon.ViewModels.StackoverflowViewModel vm = new();

            await vm.GetTopicsPopularity(123);
            Assert.That(vm.Topics.Count, Is.EqualTo(123));

            Assert.ThrowsAsync<ArgumentOutOfRangeException>(async () => await vm.GetTopicsPopularity(-1));
        }
    }
}