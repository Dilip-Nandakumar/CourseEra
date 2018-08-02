using NUnit.Framework;
using DynamicConnectivity;

namespace Tests
{
    public class QuickFindTest
    {
        [Test]
        public void IsConnected_NodesAreConnected_ReturnsTrue()
        { 
            QuickFind quickFind = new QuickFind(5);
            quickFind.Union(1, 2);

            Assert.IsTrue(quickFind.IsConnected(1, 2));
        }

        [Test]
        public void IsConnected_NodesAreNotConnected_ReturnsFalse()
        { 
            QuickFind quickFind = new QuickFind(5);
            quickFind.Union(1, 2);

            Assert.IsFalse(quickFind.IsConnected(2, 3));
        }

        [Test]
        public void IsConnected_MultipleUnions_ReturnsTrue()
        { 
            QuickFind quickFind = new QuickFind(5);
            quickFind.Union(1, 2);
            quickFind.Union(2, 3);

            Assert.IsTrue(quickFind.IsConnected(1, 3));
        }

        [Test]
        public void IsConnected_UnionOfConnectedNodes_ReturnsTrue()
        {
            QuickFind quickFind = new QuickFind(5);
            quickFind.Union(1, 2);
            quickFind.Union(4, 5);
            quickFind.Union(1, 4);

            Assert.IsTrue(quickFind.IsConnected(2, 4));
        }
    }
}