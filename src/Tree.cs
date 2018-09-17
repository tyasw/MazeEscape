using System.Collections.Generic;

/** Tree.cs
 * 
 * A generic tree node. Pointers to the parent node and the children are included.
 * Logic is included for checking whether two nodes are in the same tree, and for
 * merging two trees together.
 */
namespace MazeEscapeLibrary.src
{
    public class Tree<T>
    {
        public Tree<T> Parent { get; set; }
        public List<Tree<T>> Children { get; }      // Not sure if this should be get/set
        public T Data { get; set; }

        public Tree()
        {
            Parent = null;
            Children = new List<Tree<T>>();
            Data = default(T);       // How do I get around non-nullable value type?
        }

        public Tree(T data)
        {
            Parent = null;
            Children = new List<Tree<T>>();
            Data = data;
        }

        public void AddChild(Tree<T> child)
        {
            Children.Add(child);
        }

        public Tree<T> GetRoot()
        {
            Tree<T> root = this;
            while (root.Parent != null)
            {
                root = Parent.GetRoot();
            }
            return root;
        }

        public bool IsInSameTreeAs(Tree<T> OtherTree)
        {
            Tree<T> ThisRoot = GetRoot();
            Tree<T> OtherRoot = OtherTree.GetRoot();
            return ThisRoot.Data.Equals(OtherRoot.Data);
        }

        // Merge this tree with another tree of the same type. Note that trees
        // are merged at their roots.
        public void MergeWith(Tree<T> OtherTree)
        {
            Tree<T> ThisRoot = GetRoot();
            Tree<T> OtherRoot = OtherTree.GetRoot();
            ThisRoot.AddChild(OtherRoot);
            OtherRoot.Parent = ThisRoot;
        }
    }
}
