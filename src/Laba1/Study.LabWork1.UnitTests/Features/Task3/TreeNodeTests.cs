using Study.LabWork1.Features.Task3;

namespace Study.LabWork1.UnitTests.Features.Task3
{
    [TestFixture]
    public class TreeNodeTests
    {
        [Test]
        public void Test1_Constructor()
        {
            var node = new TreeNode<int>(42);

            Assert.That(node.Value, Is.EqualTo(42));
            Assert.That(node.Children, Is.Not.Null);
            Assert.That(node.Children, Is.Empty);
        }

        [Test]
        public void Test2_AddChildNode()
        {
            var parent = new TreeNode<string>("Parent");
            var child = new TreeNode<string>("Child");

            parent.AddChild(child);

            Assert.That(parent.Children, Has.Count.EqualTo(1));
            Assert.That(parent.Children[0].Value, Is.EqualTo("Child"));
        }

        [Test]
        public void Test3_AddChildValue()
        {
            var parent = new TreeNode<string>("Parent");

            var child = parent.AddChild("Child");

            Assert.That(parent.Children, Has.Count.EqualTo(1));
            Assert.That(child.Value, Is.EqualTo("Child"));
        }

        [Test]
        public void Test4_Print()
        {
            var root = new TreeNode<string>("Root");
            root.AddChild("Child1");
            root.AddChild("Child2");

            Assert.DoesNotThrow(() => root.PrintChildrenValues());
        }

        [Test]
        public void Test5_Nested()
        {
            var root = new TreeNode<string>("1");
            var child = root.AddChild("1.1");
            child.AddChild("1.1.1");

            Assert.That(root.Children, Has.Count.EqualTo(1));
            Assert.That(root.Children[0].Children, Has.Count.EqualTo(1));
        }
    }
}
