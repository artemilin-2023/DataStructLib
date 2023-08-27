using MyDataStucturesLibrary.ProjectFiles.Nodes;
using MyDataStucturesLibrary.ProjectFiles.Structures.Enums;
using System;
using System.Collections.Generic;

namespace MyDataStucturesLibrary
{
    public class SearchTree<T> where T: IComparable<T>
    {
        public int Count { get; private set; }
        public List<T> values { get; private set; }

        private TreeNode<T> _root { get; set; }

        public SearchTree()
        {
            Count = 0;
            values = new List<T>();
        }

        public void Add(T item)
        {
            _root = Insert(_root, item);
            Count++;
        }

        private TreeNode<T> Insert(TreeNode<T> current, T item)
        {
            if (current == null)
            {
                return new TreeNode<T>(item);
            }

            if (item.CompareTo(current.Data) <= 0)
            {
                current.Left = Insert(current.Left, item);
            }
            else
            {
                current.Right = Insert(current.Right, item);
            }

            return Balance(current);
        }

        private TreeNode<T> Balance(TreeNode<T> current)
        {
            RecalculateHeight(current);

            if (BalanceFactor(current) == 2)
            {
                if (BalanceFactor(current.Right) < 0)
                    current.Right = RotateRight(current.Right);
                
                return RotateLeft(current);
            }

            if (BalanceFactor(current) == -2)
            {
                if (BalanceFactor(current.Left) > 0)
                    current.Left = RotateLeft(current.Left);

                return RotateRight(current);
            }

            return current;
        }

        private void RecalculateHeight(TreeNode<T> node)
        {
            node.Height = Math.Max(Height(node.Right), Height(node.Left)) + 1;
        }

        private int Height(TreeNode<T> node)
        {
            return node == null ? -1 : node.Height;
        }

        private int BalanceFactor(TreeNode<T> node)
        {
            if (node == null)
                return 0;
            return Height(node.Right) - Height(node.Left);
        }

        private TreeNode<T> RotateRight(TreeNode<T> pivot)
        {
            var newPivot = pivot.Left;
            pivot.Left = newPivot.Right;
            newPivot.Right = pivot;

            RecalculateHeight(pivot);
            RecalculateHeight(newPivot);

            return newPivot;
        }

        private TreeNode<T> RotateLeft(TreeNode<T> pivot)
        {
            var newPivot = pivot.Right;
            pivot.Right = newPivot.Left;
            newPivot.Left = pivot;

            RecalculateHeight(pivot);
            RecalculateHeight(newPivot);

            return newPivot;
        }

        public bool Contains(T value)
        {
            return Search(_root, value) != null;
        }

        private TreeNode<T> Search(TreeNode<T> current, T value)
        {
            if (current == null)
                return null;

            if (current.Data.Equals(value))
                return current;

            if (value.CompareTo(current.Data) > 0)
                return Search(current.Right, value);

            return Search(current.Left, value);
        }

        public bool Remove(T value)
        {
            var result = RemoveProcess(_root, null, NodeOrientation.ParentNode, value) != null;
            if (result)
                Count--;

            return result;
        }

        private TreeNode<T> RemoveProcess(TreeNode<T> current, TreeNode<T> parent, NodeOrientation orientationRelativeParent, T value)
        {
            if (current == null)
                return null;

            if (value.CompareTo(current.Data) < 0)
            {
                current.Left = RemoveProcess(current.Left, current, NodeOrientation.Left, value);
            }
            else if (value.CompareTo(current.Data) > 0)
            {
                current.Right = RemoveProcess(current.Right, current, NodeOrientation.Right, value);
            }
            else
            {
                return DeleteNode(current, parent, orientationRelativeParent);
            }

            return Balance(current);
        }

        private TreeNode<T> DeleteNode(TreeNode<T> current, TreeNode<T> parent, NodeOrientation orientationRelativeParent)
        {
            var right = current.Right;
            var left = current.Left;

            if (right == null)
            {
                DeleteSheet(parent, orientationRelativeParent, left);
            }
            else
            {
                return DeleteNodeWithRightTree(parent, orientationRelativeParent, right, left);
            }

            return null;
        }

        private static void DeleteSheet(TreeNode<T> parent, NodeOrientation orientationRelativeParent, TreeNode<T> left)
        {
            switch (orientationRelativeParent)
            {
                case NodeOrientation.Left:
                    parent.Left = left;
                    break;

                case NodeOrientation.Right:
                    parent.Right = left;
                    break;
            }
        }

        private TreeNode<T> DeleteNodeWithRightTree(TreeNode<T> parent, NodeOrientation orientationRelativeParent, TreeNode<T> right, TreeNode<T> left)
        {
            var min = FindMin(right);

            switch (orientationRelativeParent)
            {
                case NodeOrientation.Left:
                    parent.Left = min;
                    break;

                case NodeOrientation.Right:
                    parent.Right = min;
                    break;
            }

            min.Left = left;
            min.Right = RemoveMin(right);

            return Balance(min);
        }

        private TreeNode<T> FindMin(TreeNode<T> current)
        {
            while (current.Left != null)
            {
                current = current.Left;
            }

            return current;
        }

        private TreeNode<T> RemoveMin(TreeNode<T> current)
        {
            if (current.Left == null)
                return current.Right;
            current.Left = RemoveMin(current.Left);

            return Balance(current);
        }

        public List<T> ToList()
        {
            values.Clear();
            ToListProcess(_root);
            return values;
        }

        private void ToListProcess(TreeNode<T> current)
        {
            if (current == null)
                return;
            ToListProcess(current.Left);
            values.Add(current.Data);
            ToListProcess(current.Right);
        }
        
    }
}
