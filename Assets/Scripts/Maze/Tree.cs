namespace Assets.Scripts.Maze {
    public class Tree<T> {
        public Tree<T> Parent { get; set; }
        public T Data { get; set; }

        public Tree() {
            Parent = null;
            Data = default(T);       // How do I get around non-nullable value type?
        }

        public Tree(T data) {
            Parent = null;
            Data = data;
        }

        public Tree<T> GetRoot() {
            Tree<T> root = this;
            while (root.Parent != null) {
                root = Parent.GetRoot();
            }
            return root;
        }

        public bool IsInSameTreeAs(Tree<T> OtherTree) {
            Tree<T> ThisRoot = GetRoot();
            Tree<T> OtherRoot = OtherTree.GetRoot();
            return ThisRoot.Data.Equals(OtherRoot.Data);
        }

        // Merge this tree with another tree of the same type. Note that trees
        // are merged at their roots.
        public void MergeWith(Tree<T> OtherTree) {
            if (OtherTree != null) {
                Tree<T> ThisRoot = GetRoot();
                Tree<T> OtherRoot = OtherTree.GetRoot();
                if (ThisRoot != OtherRoot) {
                    OtherRoot.Parent = ThisRoot;
                }
            }
        }
    }
}
