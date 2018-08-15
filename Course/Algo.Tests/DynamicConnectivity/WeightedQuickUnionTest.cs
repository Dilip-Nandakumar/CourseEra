using NUnit.Framework;
using DynamicConnectivity;

namespace Tests
{
    public class WeightedQuickUnionTest
    {
        [Test]
        public void IsConnected_NodesAreConnected_ReturnsTrue()
        {
            WeightedQuickUnion weightedQuickUnion = new WeightedQuickUnion(5);
            weightedQuickUnion.Union(1, 2);

            Assert.IsTrue(weightedQuickUnion.IsConnected(1, 2));
        }

        [Test]
        public void IsConnected_NodesAreNotConnected_ReturnsFalse()
        {
            WeightedQuickUnion weightedQuickUnion = new WeightedQuickUnion(5);
            weightedQuickUnion.Union(1, 2);

            Assert.IsFalse(weightedQuickUnion.IsConnected(2, 3));
        }

        [Test]
        public void IsConnected_MultipleUnions_ReturnsTrue()
        {
            WeightedQuickUnion weightedQuickUnion = new WeightedQuickUnion(5);
            weightedQuickUnion.Union(1, 2);
            weightedQuickUnion.Union(2, 3);

            Assert.IsTrue(weightedQuickUnion.IsConnected(1, 3));
        }

        [Test]
        public void IsConnected_UnionOfConnectedNodes_ReturnsTrue()
        {
            WeightedQuickUnion weightedQuickUnion = new WeightedQuickUnion(5);
            weightedQuickUnion.Union(1, 2);
            weightedQuickUnion.Union(4, 5);
            weightedQuickUnion.Union(1, 4);

            Assert.IsTrue(weightedQuickUnion.IsConnected(2, 4));
        }
    }
}