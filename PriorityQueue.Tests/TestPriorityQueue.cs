using NUnit.Framework;
using Shouldly;

namespace PriorityQueueCollection.Tests
{
    [TestFixture]
    public class TestPriorityQueue
    {
        private IPriorityQueue<PrioritizableItem> _priorityQueue;

        private PrioritizableItem _one;
        private PrioritizableItem _two;
        private PrioritizableItem _three;
        private PrioritizableItem _four;
        private PrioritizableItem _five;
        private PrioritizableItem _six;
        private PrioritizableItem _seven;

        [SetUp]
        public void Setup()
        {
            _priorityQueue = new PriorityQueue<PrioritizableItem>(new ComparePrioritizableItem());
            _one = new PrioritizableItem(1);
            _two = new PrioritizableItem(2);
            _three = new PrioritizableItem(3);
            _four = new PrioritizableItem(4);
            _five = new PrioritizableItem(5);
            _six = new PrioritizableItem(6);
            _seven = new PrioritizableItem(7);
        }

        [Test]
        public void ShouldOrderPushedItems()
        {
            _priorityQueue.Push(_five);
            _priorityQueue.Push(_three);
            _priorityQueue.Push(_seven);
            _priorityQueue.Push(_two);
            _priorityQueue.Push(_six);
            _priorityQueue.Push(_one);
            _priorityQueue.Push(_four);

            _priorityQueue.Pop().ShouldBe(_one);
            _priorityQueue.Pop().ShouldBe(_two);
            _priorityQueue.Pop().ShouldBe(_three);
            _priorityQueue.Pop().ShouldBe(_four);
            _priorityQueue.Pop().ShouldBe(_five);
            _priorityQueue.Pop().ShouldBe(_six);
            _priorityQueue.Pop().ShouldBe(_seven);
        }

        [Test]
        public void ShouldKnowIfItemExists()
        {
            _priorityQueue.Push(_two);
            _priorityQueue.Push(_one);
            _priorityQueue.Push(_three);

            _priorityQueue.Contains(_one).ShouldBe(true);
            _priorityQueue.Contains(_two).ShouldBe(true);
            _priorityQueue.Contains(_three).ShouldBe(true);
            _priorityQueue.Contains(_four).ShouldBe(false);
        }

        [Test]
        public void ShouldPopFromEmptyQueueForReferenceTypes()
        {
            var one = new PrioritizableItem(1);

            _priorityQueue.Push(one);

            _priorityQueue.Pop().Value.ShouldBe(1);
            _priorityQueue.Pop().ShouldBe(null);
        }

        [Test]
        public void ShouldMaintainOrderedQueue()
        {
            IPriorityQueue<PrioritizableItem> priorityQueue = new PriorityQueue<PrioritizableItem>(new ComparePrioritizableItem());

            var one = new PrioritizableItem(1);
            var two = new PrioritizableItem(2);
            var three = new PrioritizableItem(3);
            var four = new PrioritizableItem(4);

            priorityQueue.Push(three);
            priorityQueue.Push(two);
            priorityQueue.Push(four);
            priorityQueue.Push(one);

            one.Value = 8;
            two.Value = 7;
            three.Value = 6;
            four.Value = 5;

            priorityQueue.Pop().Value.ShouldBe(5);
            priorityQueue.Pop().Value.ShouldBe(6);
            priorityQueue.Pop().Value.ShouldBe(7);
            priorityQueue.Pop().Value.ShouldBe(8);
        }

        [Test]
        public void ShouldSortOnlyAfterChange()
        {
            IPriorityQueue<PrioritizableItem> priorityQueue = new PriorityQueue<PrioritizableItem>(new ComparePrioritizableItem());

            var one = new PrioritizableItem(1);
            var two = new PrioritizableItem(2);
            var three = new PrioritizableItem(3);
            var four = new PrioritizableItem(4);

            priorityQueue.Push(three);
            priorityQueue.Push(two);
            priorityQueue.Push(four);
            priorityQueue.Push(one);

            priorityQueue.Pop().Value.ShouldBe(1);

            two.Value = 99;

            priorityQueue.Pop().Value.ShouldBe(3);
            priorityQueue.Pop().Value.ShouldBe(4);

            Assert.Inconclusive("Need to assert that sort was called only twice");
        }
    }
}
