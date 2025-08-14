namespace Leetcode.Algorithms;

public sealed class BinaryTreePreorderSolution
{
    public IList<int> PreorderTraversal(TreeNode? root)
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

            if (current.right is not null)
            {
                stack.Push(current.right);
            }

            if (current.left is not null)
            {
                stack.Push(current.left);
            }
        }
        
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