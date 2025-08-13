using Xunit;

namespace Leetcode.Algorithms;

public sealed class LinkedListCycleSolution
{
    public bool HasCycle(ListNode? head) {
        if (head is null)
        {
            return false;
        }

        var slow = head;
        var fast = head;
        while (fast is not null && fast.next is not null)
        {
            fast = fast.next.next;
            slow = slow.next;

            if (fast == slow)
            {
                return true;
            }
        }

        return false;
    }
    
    public bool HasCycleSlow(ListNode? head) {
        var seen = new HashSet<ListNode>();
        if (head is null)
        {
            return false;
        }
        
        if (head.next == head)
        {
            return true;
        }
        seen.Add(head);

        while (head.next is not null)
        {
            if (!seen.Add(head.next))
            {
                return true;
            }

            head = head.next;
        }

        return false;
    }

    public class ListNode {
      public int val;
      public ListNode? next;
      public ListNode(int x) {
          val = x;
          next = null;
      } 
    }
}