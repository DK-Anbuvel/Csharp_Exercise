using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp_Exercise
{
 
 // Definition for singly-linked list.
  public class ListNode {
      public int val;
      public ListNode next;
      public ListNode(int val=0, ListNode next=null) {
          this.val = val;
          this.next = next;
      }
  }

    public partial class Exercise
    {
       
        public ListNode MiddleNode(ListNode head)
        {

          int c=getNodeCode(head);
    
            return getNodeByPosition(head, c / 2);


        }
         public int getNodeCode (ListNode head) 
         {
            ListNode temp = head;
            int nodeCount = 1;
            while (temp.next != null)
            {
                nodeCount++;
                temp = temp.next;
             
            }
            return nodeCount;
        }
        public ListNode getNodeByPosition(ListNode head,int position)
        {
            ListNode temp = head;
            while(temp.next != null && position !=0)
            {
                temp = temp.next;
                position--;
            }
            return temp;
        }

        public ListNode middleNode1(ListNode head) // best case
        {
            if (head == null || head.next == null) return head;
            ListNode fast = head;
            ListNode slow = head;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
            }
            return slow;
        }

        public bool CanConstruct(string ransomNote, string magazine)
        {
            List<char> letter = magazine.ToList();


            for (int i = 0; i < ransomNote.Length; i++)
            {
                if (letter.Contains(ransomNote[i]))
                {
                    letter.Remove(ransomNote[i]);
                   
                }
                else return false;
            }
            return true;
        }
        
    }
}
