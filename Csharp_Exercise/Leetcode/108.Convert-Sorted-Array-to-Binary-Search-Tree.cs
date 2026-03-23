namespace Csharp_Exercise
{
    /**
 Definition for a binary tree node.**/
 public class TreeNode {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
         this.val = val;
          this.left = left;
         this.right = right;
     }
 }

    public partial class Leecodes
    {
        public TreeNode SortedArrayToBST(int[] nums)
        {
            /*
             * The input array is already sorted. When you insert sorted values one by one into a BST, you always go right, creating a skewed tree:
             * This is just a linked list. The problem specifically asks for a height-balanced BST, so this approach fails completely.
             */
            TreeNode temp = null;
            for (int i = 0; i < nums.Length; i++)
            {
                temp = insertTree(temp, nums[i]);
            }
            return temp;
        }
        public TreeNode SortedArrayToBST1(int[] nums) //  [0,1,2,3,4,5]
        {
            /*  strictly increasing order. (means no duplicate)
             * use Divide and Conquer approach  
             * then num.length / 2 = middle one
             * first half was Left side.
             * second half was right side.
             * 
             * nums =[0,1,2,3,4,5]
             * output = [3,0,4,null,1,null,5,null,2] // since we indexed 0 based so least value first taken. so taken hight value first.
             * expected =[3,1,5,0,2,4]
             */
            int arrayMid = nums.Length / 2;
            TreeNode temp = null;
            temp = insertTree(temp, nums[arrayMid]);
            for (int i = 0; i < nums.Length; i++)
            {
                if (i < arrayMid) 
                    temp.left = insertTree(temp.left, nums[i]);
                else if (i > arrayMid)
                    temp.right = insertTree(temp.right, nums[i]);
                    
            }
            return temp;
        }
        public TreeNode SortedArrayToBST2(int[] nums) 
        {
            int arrayMid = nums.Length / 2;
            TreeNode temp = null;
            temp = insertTree(temp, nums[arrayMid]);
            for (int i = arrayMid; i >= 0; i--) // first halve
            {
                if (i < arrayMid)
                    temp.left = insertTree(temp.left, nums[i]);
            }
            for (int rightArray = nums.Length-1; rightArray > arrayMid; rightArray--) // second halve
            {
               temp.right = insertTree(temp.right, nums[rightArray]);
            }
            
            return temp;
        }
        private TreeNode insertTree(TreeNode? node, int value)
        {
            if (node == null)
            {
                return new TreeNode(value);
            }
            else if (value < node.val)
            {
                node.left = insertTree(node.left,value); 
            }
            else
            {
                node.right = insertTree(node.right, value);
            }
            return node;
        }

    }
}
