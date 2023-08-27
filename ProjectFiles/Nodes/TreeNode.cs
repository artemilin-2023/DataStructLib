using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace MyDataStucturesLibrary.ProjectFiles.Nodes
{
    internal class TreeNode<T> : BaseNode<T>
    {
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }
        public int Height { get; set; }

        public TreeNode(T value) : base(value)
        {
            Height = 0;
        }
    }
}
