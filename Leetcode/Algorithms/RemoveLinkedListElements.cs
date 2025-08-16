namespace Leetcode.Algorithms;

public sealed class RemoveLinkedListElements
{
    public ListNode RemoveElements(ListNode head, int val)
    {
        ListNode? current = head;
        ListNode? prev = null;
        ListNode? newHead = head;
        while (current is not null)
        {
            if (current.val == val)
            {
                if (current == newHead)
                {
                    newHead = current.next;
                }
                else
                {
                    prev.next = current.next;
                }
            }
            else
            {
                prev = current;
            }
            
            current = current.next;
        }

        return newHead;
    }

    public class ListNode
    {
        public ListNode? next;
        public int val;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
}