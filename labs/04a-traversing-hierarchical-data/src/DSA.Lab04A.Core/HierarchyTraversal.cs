using System;
using System.Collections.Generic;

namespace DSA.Lab04A
{
    /// <summary>
    /// Recursive algorithms over a rooted hierarchy.
    ///
    /// The key idea is structural recursion:
    /// solve the current node, then apply the same operation to each child subtree.
    /// </summary>
    public static class HierarchyTraversal
    {
        

        public static int CountNodes<T>(HierarchyNode<T> root)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }

            // TODO: count this node, then count every child subtree.

            int count = 1;
            
            foreach (HierarchyNode<T> child in root.Children)
            {
                count += CountNodes(child);
            }

            return count;
        }

        public static bool Contains<T>(HierarchyNode<T> root, T target)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }

            // TODO: compare the current node, then search child subtrees.

            if (Equals(root.Value, target)) return true;

            foreach (HierarchyNode<T> child in root.Children)
            {
                if (Contains(child, target) == true) return true;
            }

            return false;
        }

        public static IReadOnlyList<T> DepthFirstPreOrder<T>(HierarchyNode<T> root)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }

            // TODO: return values in pre-order:
            // current node first, then each child subtree from left to right.

            List<T> branches = new List<T>();
            branches.Add(root.Value);

            foreach (HierarchyNode<T> child in root.Children)
            {
                branches.AddRange(DepthFirstPreOrder(child)) //Note that AddRange is when you wanna add multiple items at once, and a simple Add won't work.
            }

            return branches;
        }

        public static int MaxDepth<T>(HierarchyNode<T> root)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }

            // Depth is measured in edges from the root.
            // A single-node tree therefore has max depth 0.

            int depth = 0;
            if (root.Children.Count > 0)
            {
                int depth = 0;
                
                foreach (HierarchyNode<T> child in root.Childeren)
                {
                    int childDepth = MaxDepth(child) + 1;
                    if (childDepth > depth) depth = childDepth;
                }
            }

            return depth;
        }
    }
}
