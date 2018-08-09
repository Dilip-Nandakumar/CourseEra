using NUnit.Framework;
using DynamicConnectivity;

namespace Tests
{
    public class QuickUnionTest
    {
        [Test]
        public void IsConnected_NodesAreConnected_ReturnsTrue()
        {
            QuickUnion quickUnion = new QuickUnion(5);
            quickUnion.Union(1, 2);

            Assert.IsTrue(quickUnion.IsConnected(1, 2));
        }

        [Test]
        public void IsConnected_NodesAreNotConnected_ReturnsFalse()
        {
            QuickUnion quickUnion = new QuickUnion(5);
            quickUnion.Union(1, 2);

            Assert.IsFalse(quickUnion.IsConnected(2, 3));
        }

        [Test]
        public void IsConnected_MultipleUnions_ReturnsTrue()
        {
            QuickUnion quickUnion = new QuickUnion(5);
            quickUnion.Union(1, 2);
            quickUnion.Union(2, 3);

            Assert.IsTrue(quickUnion.IsConnected(1, 3));
        }

        [Test]
        public void IsConnected_UnionOfConnectedNodes_ReturnsTrue()
        {
            QuickUnion quickUnion = new QuickUnion(5);
            quickUnion.Union(1, 2);
            quickUnion.Union(4, 5);
            quickUnion.Union(1, 4);

            Assert.IsTrue(quickUnion.IsConnected(2, 4));
        }
    }
}