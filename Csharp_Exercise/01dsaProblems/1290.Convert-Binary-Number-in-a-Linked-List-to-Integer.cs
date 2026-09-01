using System.Text;

namespace Csharp_Exercise
{
    public partial class Leecodes
    {
        public int GetDecimalValue(ListNode head)
        {

            string binaryString = "";
            while (head != null)
            {

                binaryString = binaryString + head.val; // new string object created and old string copy + append value.
                head = head.next; //a new string object is created on every loop iteration
            }
            return System.Convert.ToInt32(binaryString, 2);

        }
        public int GetDecimalValue1(ListNode head) // it faster then first method.
        {
            ListNode current = head;
            StringBuilder sb = new StringBuilder();
            while (current != null)
            {
                sb.Append(current.val); // it is mutable, append the value in existing 
                current = current.next;
            }
            return Convert.ToInt32(new string(sb.ToString()), 2);
        }
        public int GetDecimalValue2(ListNode head)
        {
            int result = 0;

            while (head != null)
            {
                result = (result << 1) | head.val;
                head = head.next;
            }

            return result;
        }
        public int GetDecimalValue3(ListNode head)
        {
            int total = 0;

            while (head != null)
            {
                total = total * 2 + head.val;
                head = head.next;
            }
            return total;
        }
        public int GetDecimalValue4(ListNode head)
        {
            var result = 0;

            while (head != null)
            {
                result <<= 1;
                result += head.val;

                head = head.next;
            }

            return result;
        }
    }
}

