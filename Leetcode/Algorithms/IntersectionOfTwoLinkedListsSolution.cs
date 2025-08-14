namespace Leetcode.Algorithms;

public sealed class IntersectionOfTwoLinkedListsSolution
{
    public ListNode? GetIntersectionNodeTwoPointers(ListNode? headA, ListNode? headB)
    {
        var pointerA = headA;
        var pointerB = headB;
        while (pointerA != pointerB)
        {
            pointerA = pointerA is null ? headB : pointerA.next;

            pointerB = pointerB is null ? headA : pointerB.next;
        }

        return pointerA;
    }
    
    public ListNode? GetIntersectionNode(ListNode? headA, ListNode? headB)
    {
        if (headA is null || headB is null)
        {
            return null;
        }
        
        var lengthA = GetLength(headA);
        var lengthB = GetLength(headB);
        if (lengthA > lengthB)
        {
            headA = Skip(headA, lengthA - lengthB);
        }
        else
        {
            headB = Skip(headB, lengthB - lengthA);
        }

        while (headA != null)
        {
            if (headA == headB)
            {
                return headA;
            }

            headA = headA.next;
            headB = headB.next;
        }

        return null;
    }

    private int GetLength(ListNode? head)
    {
        var length = 1;
        while (head != null)
        {
            head = head.next;
            length++;
        }

        return length;
    }

    private ListNode Skip(ListNode head, int skip)
    {
        for (int i = 0; i < skip; i++)
        {
            head = head.next;
        }
        return head;
    }

    
    public class ListNode {
         public int val;
         public ListNode next;
         public ListNode(int x) { val = x; }
    }
}