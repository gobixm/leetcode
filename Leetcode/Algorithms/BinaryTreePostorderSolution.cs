namespace Leetcode.Algorithms;

public sealed class BinaryTreePostorderSolution
{
    public IList<int> PostorderTraversal(TreeNode? root)
    {
        var result = new List<int>();
        var stack = new Stack<TreeNode>();
        if (root is null)
        {
            return [];
        }
        
        stack.Push(root);
        while (stack.Any())
        {
            var current = stack.Pop();
            result.Add(current.val);

            if (current.left is not null)
            {
                stack.Push(current.left);
            }

            if (current.right is not null)
            {
                stack.Push(current.right);
            }
        }
        
        result.Reverse();

        return result;
    }

    
    public class TreeNode {
        public int val;
        public TreeNode? left;
        public TreeNode? right;
        public TreeNode(int val=0, TreeNode? left=null, TreeNode? right=null) {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
}