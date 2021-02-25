using System;
using System.Collections;

namespace TestTask
{
    public class BinaryTree<K, V> : IEnumerable where K : IComparable
    {
        private class TreeNode
        {
            public K key;
            public V value;
            public TreeNode left;
            public TreeNode right;
            
            public TreeNode(K key, V value)
            {
                this.value = value;
                this.key = key;
                left = null;
                right = null;
            }
        }

        private TreeNode root;

        public BinaryTree()
        {
            root = null;
        }
        
        public void Add(K key, V val)
        {
            TreeNode node = new TreeNode(key, val);
            InsertNode(ref root, node);
        }

        private void InsertNode(ref TreeNode node, TreeNode newNode)
        {
            if (node != null)
            {
                if (node.key.CompareTo(newNode.key) <= 0)
                {
                    InsertNode(ref node.right, newNode);
                }
                else
                {
                    InsertNode(ref node.left, newNode);
                }
            }
            else
            {
                node = newNode;
            }

        }

        public V Find(K key)
        {
            if (root != null)
            {
                return FindByKey(ref root, key);
            }
            return default(V);
        }

        private V FindByKey(ref TreeNode node, K key)
        {
            if (node == null) return default(V);
            
            if (node.key.Equals(key))
                return node.value;
            
            if (node.key.CompareTo(key) < 0)
                return FindByKey(ref node.right, key);
            
            return FindByKey(ref node.left, key);
        }

        private TreeNode DeleteByKey(ref TreeNode node, K key)
        {
            if (node == null) return node;
            if (node.key.Equals(key))
            {
                if (node.left == null && node.right == null)
                {
                    return null;
                }
                else if (node.left == null)
                {
                    return node.right;
                }
                else if (node.right == null)
                {
                    return node.left;
                }
                else
                {
                    (node.key, node.value) = MinElem(node.right);
                    node.right = DeleteByKey(ref node.right, node.key);
                    return node;
                }
            }
            else if (node.key.CompareTo(key) > 0)
            {
                node.left = DeleteByKey(ref node.left, key);
                return node;
            }
            else
            {
                node.right = DeleteByKey(ref node.right, key);
                return node;
            }
        }

        private (K, V) MinElem(TreeNode node)
        {
            while (node.left != null)
            {
                node = node.left;
            }

            return (node.key, node.value);
        }
        
        public void Delete(K key)
        {
            root = DeleteByKey(ref root, key);            
        }
        
        public IEnumerator GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}