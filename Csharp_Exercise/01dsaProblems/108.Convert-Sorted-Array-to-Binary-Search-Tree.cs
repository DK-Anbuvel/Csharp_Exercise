namespace Csharp_Exercise
{
    public partial class Leecodes
    {    /** Definition for a binary tree node.**/
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
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
             * failed to height balanced tree
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
        public TreeNode SortedArrayToBST2(int[] nums) //[0,3,4,5,6,10]
        {    /*  strictly increasing order. (means no duplicate)
             * use Divide and Conquer approach  
             * nums =[0,3,4,5,6,10] // [0,3,4,| 5,6,10]
             * output = [5,4,10,3,null,6,null,0] // since I spliced only two part, inner array not set Tree order properly, 
             * expected =[5,3,10,0,4,6] 
             * need to split each part like in 3 pointers problem and conquer the result.
             * [0,3,4,| 5,[6],10 |,11,12,23]
             */
            if(nums.Length > 6)
            {

            }
                

            int arrayMid = nums.Length / 2;  // 1,4, 5 ,6,7     ,8, |9,| 10,11,12,13,14,15
            TreeNode temp = null;
            temp = insertTree(temp, nums[arrayMid]);
           for (int i = arrayMid-1; i >= 0; i--) // first halve
           {
                   temp.left = insertTree(temp.left, nums[i]);
           }
           for (int rightArray = nums.Length - 1; rightArray > arrayMid; rightArray--) // second halve
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
        public TreeNode SortedArrayToBST3(int[] nums) //time O(NlogN) space O(logN)
        {
            if (nums.Length <= 0)
                return null;

            int mid = nums.Length / 2;
            var tree = new TreeNode(nums[mid]);
            tree.left = SortedArrayToBST3(nums[..mid]);//string s = "".Substring(0, mid);
            tree.right = SortedArrayToBST3(nums[(mid + 1)..]); //string s = "".Substring(1);

            return tree;
        }
        public TreeNode SortedArrayToBST4(int[] nums)
        {
            if (nums.Length == 0) return null;
            if (nums.Length == 1) return new TreeNode(nums[0], null, null);
            var mid = nums.Length / 2;
            return new TreeNode(
                nums[mid],
                SortedArrayToBST4(nums.Take(mid).ToArray()),
                SortedArrayToBST4(nums.Skip(mid + 1).ToArray())
            );
        }
        int i = 0;
        public TreeNode SortedArrayToBST5(int[] nums)
        {
            Queue<TreeNode> queue = new Queue<TreeNode>();
            int mid = nums.Length / 2;
            int l = mid - 1;
            int r = mid + 1;
            TreeNode root = new TreeNode(nums[mid], null, null);
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                TreeNode node = queue.Dequeue();
                if (l >= 0)
                {
                    node.left = new TreeNode(nums[l--], null, null);
                    queue.Enqueue(node.left);
                }
                if (r < nums.Length)
                {
                    node.right = new TreeNode(nums[r++], null, null);
                    queue.Enqueue(node.right);
                }
            }
            dfs(root, nums);
            return root;
        }
        private void dfs(TreeNode root, int[] nums)
        {
            if (root == null) return;

            dfs(root.left, nums);
            root.val = nums[i++];
            dfs(root.right, nums);

        }
        public TreeNode SortedArrayToBST6(int[] nums) // time O(N) space O(logN)
        {
            return BuildNode(nums, 0, nums.Length - 1);
        }
        private TreeNode BuildNode(int[] ints, int left, int right)
        {
            if (left > right) return null;

            int mid = left + (right - left) / 2;

            TreeNode node = new TreeNode();
            node.val = ints[mid];

            node.left = BuildNode(ints, left, mid - 1);
            node.right = BuildNode(ints, mid + 1, right);
            return node;
        }
        public TreeNode SortedArrayToBST7(int[] nums)
        {
            if (nums == null || nums.Length == 0) return null;

            // Only parallelize for the top few levels to avoid too many tasks.
            // 2-4 is usually enough. (3 is a reasonable default.)
            const int parallelDepth = 3;

            return Build(nums, 0, nums.Length - 1, parallelDepth);
        }

        private TreeNode Build(int[] nums, int lo, int hi, int depthLeft)
        {
            if (lo > hi) return null;

            int mid = lo + ((hi - lo) / 2);
            var node = new TreeNode(nums[mid]);

            // If we still want parallelism at this depth, build left & right concurrently.
            if (depthLeft > 0)
            {
                Task<TreeNode> leftTask = Task.Run(() => Build(nums, lo, mid - 1, depthLeft - 1));
                Task<TreeNode> rightTask = Task.Run(() => Build(nums, mid + 1, hi, depthLeft - 1));

                // Wait and attach
                Task.WaitAll(leftTask, rightTask);
                node.left = leftTask.Result;
                node.right = rightTask.Result;
            }
            else
            {
                // Below cutoff depth: do it sequentially (faster, less overhead)
                node.left = Build(nums, lo, mid - 1, 0);
                node.right = Build(nums, mid + 1, hi, 0);
            }

            return node;
        }
        public TreeNode SortedArrayToBST8(int[] nums) // [-10, -3, 0, 5, 9]
        {
            var root = new TreeNode();
            if (nums.Length == 1)
            {
                root.val = nums[0];
                return root;
            }

            var stack = new Stack<(TreeNode, int, int)>();
            stack.Push((root, 0, nums.Length));

            while (stack.Count > 0)
            {
                var (node, left, right) = stack.Pop(); // return the top object and remove
                var mid = left + (right - left) / 2;
                node.val = nums[mid];

                if (left < mid)
                {
                    var lNode = new TreeNode();
                    node.left = lNode;
                    stack.Push((lNode, left, mid));
                }
                if (mid + 1 < right)
                {
                    var rNode = new TreeNode();
                    node.right = rNode;
                    stack.Push((rNode, mid + 1, right));
                }
            }

            return root;
        }
    }
}
