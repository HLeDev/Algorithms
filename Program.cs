using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Program
    {
        #region Validate strings
        //Need to check if all string is uppercase
        //Create a static method for string
        static Boolean IsUppercase(string s)
        {
            //Checking true or false to see if all the characters is uppercase
            return s.All(char.IsUpper);

            //Another way to check it is using an if statement
            //if (s.All(char.IsUpper))
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }

        //Can also do the same as upper method
        static Boolean IsLowercase(string s)
        {
            return s.All(char.IsLower);
        }

        //Create a method to validate if string contain at least 1 number, 1 lower and 1 upper
        static Boolean isPasswordComplex(string s)
        {
            //Checking if any character of the string contains and upper, lower, and digit
            return s.Any(char.IsUpper) && s.Any(char.IsLower) && s.Any(char.IsDigit);
        }
        #endregion

        #region Normalize strings
        //Search for the letter in lowercase form
        //Then search for letter in uppercase form
        static string NormalizeString(String input)
        {
            //string lower = input.ToLower();
            ////trim method remove white space
            //string trim = lower.Trim();
            ////if there are certain char we dont need, remove from string using replace method
            //return trim.Replace(",", "");

            //Normalize the method by first convert everything to lowercase, then trim it to remove white space, then replace commas with blank space
            return input.ToLower().Trim().Replace(",", "");
        }




        //Convert string to all lowercase
        //Only search for one form which is lower case



        //Can also limit input to certain type

        #endregion

        #region Parse and Search Strings
        //Searching for a piece of data in a string
        //If you know nothing, need check every character
        //If u know the strings are sorted, optimize the algorithm by searching in any location

        //The most effective way is to use Contains method such as Console.WriteLine("Hello World).ToLower().Contains("ll);

        //This will display a boolean value

        static void ParseContents(string s)
        {
            //The first option is to use a foreach loop
            Console.WriteLine("Option 1");

            foreach (char c in s)
            {
                Console.WriteLine(c);
            }

            //The second option is to use a for loop
            Console.WriteLine("Option 2");
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];

                Console.WriteLine(c);
            }
            //This method will check every single char one by one
        }

        //Another method would be to check even numbers only in a string such as 2nd, 4th, 6th char etc..
        static Boolean IsAtEvenIndex(String s, char item)
        {
            //First and foremost, check if string is empty or null, if it is, return false
            if (string.IsNullOrEmpty(s))
            {
                return false;
            }

            //In order to search even number only, use a for loop with an increment of 2
            for (int i = 0; i < s.Length / 2 + 1; i = i+2)
                //This will cut time complexity in half by cutting over odd number
            {
                if(s[i] == item)
                {
                    return true;
                }
            }
            return false;
        }


        #endregion

        #region Reversing String Algorithm
        static String Reverse(String input)
        {
            //Check base cases by checking the string
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            //Use function built in the library
            //Use stringbuilder for effiency to prevent extra data
            StringBuilder reversed = new StringBuilder(input.Length);
            //string builder doesn't create new builder, it dynamically expand memory to accommodate modify string

            //IOT rever a string, use a for loop
            //Instead of starting at the first index, use - 1 to start at the LAST index, and with each iteration, decrease by 1
            for (int i = input.Length - 1; i >= 0; i--)
            {
                //Now append the char to the string builder
                reversed.Append(input[i]);
            }
            return reversed.ToString();

        }

        //Another way to reverse string is converting data into a data type that already has a built in reverse method
        static String Reverse2(String input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            //Array has a built int reverse method
            char[] arr = input.ToCharArray();
            Array.Reverse(arr);

            return new string(arr);
        }

        #endregion

        #region Reversing each word in a sentence
        static String ReverseEachWord(String input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            //Use stringbuilder to hold end result
            StringBuilder result = new StringBuilder();

            //Need to pluck out each word to reverse it by using the Split method to cut out all the spaces then save it in an array
            String[] arr = input.Split(' ');

            //Iterate through the array and reverse each word
            for (int i = 0; i < arr.Length; i++)
            {
                //Use reverse the entry at i in the array and append it to the result
                result.Append(Reverse(arr[i]));

                //Spaces were removed and needed to be added back in, this will work for everything except the last word, 
                if (i != arr.Length - 1)
                {
                    result.Append(" ");
                }
            }

            return result.ToString();
        }

        #endregion

        #region Linear Array Search
        //Create a method for an array input and int output
        static Boolean LinearSearch(int[] input, int n)
        {
            //Use a foreach to loop through are the input
            foreach (int current in input)
            {
                //If you find what you're looking for in the input
                if (n == current)
                {
                    //Return the found item
                    return true;
                }
            }
            //If not, return nothing
            return false;
        }

        //If we know an item is sorted, use binary search
        #endregion

        #region Binary Search
        //This method input an array and an item being searchj
        static Boolean BinarySearch(int[] inputArray, int item)
        {
            //Need to find min and max variable

            int min = 0;
            //max Input of array start at end of array
            int max = inputArray.Length - 1;

            //Need to search through array until min is greater or = to max, this make array length is 0, if we get to 0, item doesnt exist
            while (min <= max)
            {
                //Need a mid point to search
                int mid = (min + max) / 2;
                //Then search the item needed to be found
                if (item == inputArray[mid])
                {
                    return true;
                }
                //Need to know to search front half or back half of the array
                else if(item < inputArray[mid])
                {
                    //If it's smaller, go back towards 0
                    max = mid - 1;
                }
                else if (item > inputArray[mid])
                {
                    //If it's greater, go forward to next number
                    min = mid + 1;
                }
            }

            return false;
        }
        #endregion

        #region Aggregating and filtering data
        //If there's multiple arrays, and a new created is needed for filter
        //1.  Merge the arrays then remove invalid item
        //2.  Check each element and only keep valid items
        //3.  Sort each array and take only valid items

        static int[] FindEvenNums(int[] arr1, int[] arr2)
        {
            ArrayList result = new ArrayList();

            //Need to iterate through each array and add even to new array list
            foreach(int num in arr1)
            {
                if (num % 2 == 0)
                {
                    result.Add(num);
                }
            }
            foreach(int num in arr2)
            {
                if(num % 2 == 0)
                {
                    result.Add(num);
                }
            }
            //Now to convert into the result
            return(int[])result.ToArray(typeof(int));
        }

        #endregion

        #region Reversing Array
        //One way is to copy content into another array in reverse order
        static int[] Reverse(int[] input)
        {
            //Create a new array to hold reverse content with the same length
            int[] reversed = new int[input.Length];
            //Iterate through the reverse array and add the content from the input array in reverse order
            for (int i = 0; i < reversed.Length; i++)
                //start at index i, while i is less than length, increment by 1
            {
                //Set the value at index i = last index of the array and put it in front of reverse array, and take whatever in front of input array and put
                //at the end of reversed array
                reversed[i] = input[input.Length - i - 1];
            }
            return reversed;
        }

        //Since no new content is added or removed, can do algorithm in place
        static void ReverseInPlace(int[] input)
        {
            //Here, modify the array instead of creating a new array using for loop
            for (int i = 0; i < input.Length / 2; i++)
            {
                //create a temporary variable to save current array before reversing
                int temp = input[i];
                //swap index i with input length from the rear
                input[i] = input[input.Length - i - 1];
                //value is overwritten from the input array so have to create a variable to save the current index
                //then saving the new array is the current array which is in reverse order
                input[input.Length - i - 1] = temp;
            }
        }

        #endregion

        #region Rotating an Array
        //Input : {1,2,3,4,5,6}
        //Output : {2,3,4,5,6,1}

        static void RotateArrayLeft(int[] input)
        {
            //Store current value of array
            int temp = input[0];
            //Iterate through the array and shift item down by 1
            for(int i = 0; i < input.Length - 1; i++)
            {
                //set the index item to be item of next index
                input[i] = input[i + 1];
                //2 will be 0, 3 is 1, 4 is 2, 5 is 3, 6 is 4, and 1 is 5
            }
            input[input.Length - 1] = temp;
        }

        static void RotateArrayRight(int[] input)
        {
            int temp = input[input.Length - 1];

            for(int i = input.Length - 1; i > 0; i--)
            {
                input[i] = input[i - 1];
            }
            input[0] = temp;
        }

        #endregion

        #region Linked List
        //Similar to array, elements are linked by pointers
        //each element is a node which contains a piece of data and a reference to the next element
        //5 - > 8 - > 13 - > null, 5 is first node, linked to 8 2nd node, linked to 13 last node while null is the end
        //5 is head, 13 is tail
        //size is varied over time, with array, size is set/constant
        //for linkedlist, it can be change or remove at any time such as
        //Original 5 > 8 > 13 > null
        //Modified 5 > 8 > null
        //There's a garbage collector that handles memory for us

        Node head;
        //Node class head call first item or head of the list
        public class Node
            //Inner class used by linklist, each node has 2 attributes, data and a next node to the list
        {
            public int data;

            public Node next;

            public Node(int d) { data = d; }
        }
        public void deleteBackHalf()
        {
            if (head == null || head.next == null)
            {
                head = null;
            }

            Node slow = head;
            Node fast = head;
            Node previous = null;

            while (fast != null && fast.next != null)
            {
                previous = slow;
                slow = slow.next;
                fast = fast.next.next;
            }
            previous.next = null;
        }
        public void displayContents()
        {
            Node current = head;
            while (current != null)
            {
                Console.WriteLine(current.data + "->");
                current = current.next;
            }
        }

        //Delete kth Node from the list
        public void deleteKthNodeFromEnd(int k)
        {
            if (head == null || k == 0)
            {
                return;
            }
            // [a , b , c , d]
            // k = 2
            Node first = head;
            Node second = head;

            for (int i = 0; i < k; i++)
            {
                second = second.next;
                if (second.next == null)
                {
                    if (i == k - 1)
                    {
                        head = head.next;
                    }
                    return;
                }
            }

            // second = c


            while (second.next != null)
            {
                first = first.next;
                second = second.next;
            }

            // first = b
            //second = d
            // [a, b , c ,d]
            //k = 2

            first.next = first.next.next;
        }

        #endregion

        #region Queue Print Binary
        //A queue contains elements in the order they were added
        //elements are inserted at the end and removed from the front, FIFO

        //enqueue = adds an item to the back
        //dequeue = removes from the from front
        //peek = access items from the front of queue

        static void printBinary(int n)
        {
            if (n <= 0)
            {
                return;
            }
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            for (int i = 0; i < n; i++)
            {
                int current = queue.Dequeue();
                Console.WriteLine(current);
                queue.Enqueue(current * 10);
                queue.Enqueue(current * 10 + 1);
            }
            Console.WriteLine();
        }




        #endregion

        #region Stack
        //Useful when need to keep track of state, using push and pop = LIFO
        //push adds to the top
        //pop removes from the top
        //runtime stack = Main function is call, builder function might be use, util function is call

        static void NextGreaterElement(int[] arr)
        {
            if (arr.Length <= 0)
            {
                Console.WriteLine();
                return;
            }

            Stack<int> stack = new Stack<int>();
            stack.Push(arr[0]);
            for (int i = 1; i < arr.Length; i++)
            {
                int next = arr[i];
                if (stack.Count > 0)
                {
                    int popped = stack.Pop();

                    while (popped < next)
                    {
                        Console.WriteLine(popped + "-->" + next);

                        if (stack.Count == 0)
                        {
                            break;
                        }

                        popped = stack.Pop();

                    }

                    if (popped > next)
                    {
                        stack.Push(popped);
                    }

                }
                stack.Push(next);
            }

            while (stack.Count > 0)
            {
                Console.WriteLine(stack.Pop() + "-->" + -1);
            }
        }

        static Boolean MatchingParenthesis(string s)
        {
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < s.Length; i++)
            {
                char current = s[i];

                if(current == '(')
                {
                    stack.Push(current);
                    continue;
                }
                if (current == ')')
                {
                    if (stack.Count > 0)
                    {
                        stack.Pop();
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return stack.Count == 0;
        }

        #endregion

        #region Hash-Based Structures
        //Great when working with collections, sets, and data formatted key-value pair
        //HashSet = Is an unordered collection of unique items.
        //verifying unique vendor codes, store in hashset and verify one time

        //Dictionary = useful for key-value pairs, store value using id such as Employee(value) and Id(key)

        //Dictionary is preferred over HashSet because it adds type safety
        string name;
        int id;
        string department;
        public Program(string name, int id, string department)
        {
            this.name = name;
            this.id = id;
            this.department = department;
        }

        static List<int> findMissingElements(int[] first, int[] second)
        {
            List<int> missingElements = new List<int>();

            HashSet<int> secondArrayItems = new HashSet<int>();

            foreach(int item in second)
            {
                secondArrayItems.Add(item);
            }
            foreach (int item in first)
            {
                if (!secondArrayItems.Contains(item))
                {
                    missingElements.Add(item);
                }
            }
            return missingElements;
        }


        static void displayFreqOfEachElement(int[] arr)
        {
            Dictionary<int, int> freqDictionary = new Dictionary<int, int>();
            for (int i = 0; i <arr.Length; i++)
            {
                if (freqDictionary.ContainsKey(arr[i]))
                {
                    freqDictionary[arr[i]]++;
                }
                else
                {
                    freqDictionary[arr[i]] = 1;
                }
            }

            foreach (KeyValuePair<int,int> x in freqDictionary)
            {
                Console.WriteLine(x.Key + " -> " + x.Value);
            }
        }

        //Node head;
        //public class Node
        //{
        //    public int data;
        //    public Node next;
        //    public Node(int d)
        //    {
        //        data = d;
        //        next = null;
        //    }
        //}

        //public Boolean hasCycle()
        //{
        //    HashSet<Node> nodes = new HashSet<Node>();

        //    Node current = head;
        //    while (current != null)
        //    {
        //        if (nodes.Contains(current))
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            nodes.Add(current);
        //        }

        //        current = current.next;
        //    }
        //    return false;
        //}

        #endregion

        #region Tree Algorithm
        //Useful for working with Non-Linear Data
        //Collection of nodes where each node might be linked to one, two, or even more nodes
        //Top of pyramid is called root node, and any linked is called child


        #endregion

        static void Main(string[] args)
        {
            #region Validate CW
            //Console.WriteLine(IsUppercase("hello"));
            //Console.WriteLine(IsUppercase("HELLO"));



            //Console.WriteLine(IsLowercase("hi"));
            //Console.WriteLine(IsLowercase("HI"));
            #endregion

            #region Normalize CW
            //Console.WriteLine(isPasswordComplex("Hell0"));
            //Console.WriteLine(isPasswordComplex("hell0"));
            //Console.WriteLine(isPasswordComplex("Hello"));
            //Console.WriteLine(isPasswordComplex("Hellooo"));
            //Console.WriteLine(isPasswordComplex("wowwza"));


            //Console.WriteLine(NormalizeString("Hello There, BUD"));
            #endregion

            #region Parsing Contents
            //ParseContents("Hello World");

            //String input = "HeLLo";
            //Console.WriteLine(IsAtEvenIndex(input, 'L'));
            //Console.WriteLine(IsAtEvenIndex(input, 'T'));
            //Console.WriteLine(IsAtEvenIndex(input, 'H'));
            //Console.WriteLine(IsAtEvenIndex("", 'L'));
            //Console.WriteLine(IsAtEvenIndex(null, 'L'));
            #endregion

            #region Reversing String
            //Console.WriteLine(Reverse("Hello World"));
            //Console.WriteLine(Reverse("Hung"));
            //Console.WriteLine(Reverse("Ram Truck"));
            //Console.WriteLine(Reverse("Honda Civic"));

            //Console.WriteLine(Reverse2("Hello World"));
            //Console.WriteLine(Reverse2("Hung"));
            //Console.WriteLine(Reverse2("Ram Truck"));
            //Console.WriteLine(Reverse2("Honda Civic"));
            #endregion

            #region Reverse Sentences
            //Console.WriteLine(ReverseEachWord("Hung is Great!"));
            //Console.WriteLine(ReverseEachWord("Hung is Good"));
            //Console.WriteLine(ReverseEachWord("Hung is Awesome"));
            //Console.WriteLine(ReverseEachWord("Hung is Fantastic"));
            #endregion

            #region Linear Array
            //Create an array of integers then search for it using the method created

            //int[] arr = { 1, 2, 3, 4, 5, 6 };
            //Console.WriteLine(LinearSearch(arr, 4));
            //Console.WriteLine(LinearSearch(arr, 8));

            //There are multiple way to find an item such as Find method, find will only find the first item that meet the condition

            //int item = Array.Find(arr, element => element == 3);
            //Console.WriteLine(item);

            //If 3 exist in the array, item variable will show 3, if not it will show 0
            //Can also use findall to find any item less or greater than such as:

            //int[] items = Array.FindAll(arr, element => element >= 5);

            //If no item meet the condition, it will return empty
            //To display the item, use built in foreach function

            //Array.ForEach(items, Console.WriteLine);
            #endregion

            #region Binary Search Result
            //int[] arr = { 1, 2, 3, 4, 5, 6 };
            //Console.WriteLine(BinarySearch(arr, 5));
            //C# has a function for binary search such ass Array.BinarySearch(arr, 1);
            #endregion

            #region Aggregating and Filterning Result
            //int[] arr1 = { -8, 2, 3, -9, 11, -20 };
            //int[] arr2 = { 0, -2, -9, -39, 39, 10, 7 };

            //int[] evenArray = FindEvenNums(arr1, arr2);
            //Array.ForEach(evenArray, Console.WriteLine);

            #endregion

            #region Reversing Array Result
            //int[] arr = { 1, 2, 3, 4, 5, 6 };
            //Array.ForEach(Reverse(arr), Console.WriteLine);
            //ReverseInPlace(arr);

            //Array.ForEach(arr, Console.WriteLine);
            #endregion

            #region Rotating an Array Result
            //int[] arr = { 1, 2, 3, 4, 5, 6 };
            //RotateArrayLeft(arr);
            ////arrayleft would make it {2,3,4,5,6,1}
            //RotateArrayRight(arr);
            ////after rotate right, it'll go back to original position of {1,2,3,4,5,6}
            //Array.ForEach(arr, Console.WriteLine);


            #endregion

            #region LinkedList Result
            //LinkedList<string> list = new LinkedList<string>();
            //list.AddLast("Sarah");
            //list.AddLast("Joe");
            //list.AddLast("John");
            //list.AddLast("Jim");
            //list.AddLast("Jack");
            //Console.WriteLine(list.Contains("Sarah"));
            //Console.WriteLine(list.Count);

            ////Can use contains method to see if data contains in the list, or remove
            //list.RemoveFirst();
            //foreach(string item in list)
            //{
            //    Console.WriteLine(item + "->");
            //}
            //Console.WriteLine();

            //Program linkedlist = new Program();
            //Node firstNode = new Node(3);
            //Node secondNode = new Node(4);
            //Node thirdNode = new Node(5);
            //Node fourthNode = new Node(6);

            //linkedlist.head = firstNode;
            //firstNode.next = secondNode;
            //secondNode.next = thirdNode;
            //thirdNode.next = fourthNode;

            ////linkedlist.displayContents();

            ////linkedlist.deleteBackHalf();
            ////Console.WriteLine();
            ////linkedlist.displayContents();



            //linkedlist.displayContents();
            //linkedlist.deleteKthNodeFromEnd(2);
            //Console.WriteLine();
            //linkedlist.displayContents();

            #endregion

            #region Queue Result
            //Queue<int> queue = new Queue<int>();

            //queue.Enqueue(1);
            //queue.Enqueue(8);
            //queue.Enqueue(20);
            //queue.Enqueue(23);

            //int removeItem = queue.Dequeue();
            //Console.WriteLine(removeItem);
            //Console.WriteLine(queue.Dequeue());
            //Console.WriteLine(queue.Peek());

            printBinary(5);
            printBinary(-2);
            printBinary(0);
            printBinary(2);
            printBinary(8);

            #endregion

            #region Stack Result
            Stack<string> stack = new Stack<string>();
            Console.WriteLine("Start Main");
            stack.Push("Main");
            Console.WriteLine("Start ResponseBuilder");
            stack.Push("ResponseBuilder");
            Console.WriteLine("Start CallExternalService");
            stack.Push("CallExternalService");
            Console.WriteLine("END" + stack.Pop());
            Console.WriteLine("Start ParseExternalData");
            stack.Push("ParseExternalDataMethod");
            Console.WriteLine("END" + stack.Pop());
            Console.WriteLine("END" + stack.Pop());
            Console.WriteLine("END" + stack.Pop());
            Console.WriteLine();

            //stack.Peek(); stack.TryPeek();

            int[] arr = new int[] { 15, 8, 4, 10 };
            int[] arr2 = new int[] { 2 };
            int[] arr3 = new int[] { 2, 3 };
            int[] arr4 = new int[] { };

            //Iterate from left to right, 15 = -1, 8 = 10, 4 = 10, 10 = -1;

            NextGreaterElement(arr);
            NextGreaterElement(arr2);
            NextGreaterElement(arr3);
            NextGreaterElement(arr4);
            Console.WriteLine();


            Console.WriteLine(MatchingParenthesis("Hello()"));
            Console.WriteLine(MatchingParenthesis("()Hello()"));
            Console.WriteLine(MatchingParenthesis("()()Hello()"));
            Console.WriteLine();

            Console.WriteLine(MatchingParenthesis("Hello))"));
            Console.WriteLine(MatchingParenthesis("Hello(("));
            Console.WriteLine(MatchingParenthesis("Hello)"));
            Console.WriteLine(MatchingParenthesis("(Hello()"));

            #endregion

            #region Hash-Based Structures Result

            Program emp = new Program("Robby", 123, "IT");
            Program emp2 = new Program("Holly", 234, "HR");
            Program emp3 = new Program("Simpson", 456, "Finance");

            Dictionary<int, Program> empByID = new Dictionary<int, Program>();
            empByID.Add(emp.id, emp);
            empByID.Add(emp2.id, emp2);
            empByID.Add(emp3.id, emp3);

            Program e;
            
            if(empByID.TryGetValue(456, out e))
            {
                Console.WriteLine(e.name + " : " + e.department);
            }

            HashSet<string> productCode = new HashSet<string>();
            productCode.Add("AB123");
            productCode.Add("CD123");
            productCode.Add("EF123");

            productCode.Contains("AB123");
            productCode.Contains("AB234");


            findMissingElements(new int[] { 1, 2, 3, 4 }, new int[] { 2, 4 }).ForEach(Console.WriteLine);

            Console.WriteLine();

            findMissingElements(new int[] { 3,2,4,8,5 }, new int[] { 5,7,3,0,2 }).ForEach(Console.WriteLine);

            Console.WriteLine();


            displayFreqOfEachElement(new int[] { 3, 0, 2, 4, 7, 3, 4, 5, 7, 6, 7 });
            Console.WriteLine("End of Hash");





            //Program noCycleLinkedList = new Program();
            //Nodes firstNodes = new Nodes(3);
            //Nodes secondNodes = new Nodes(4);
            //Nodes thirdNodes = new Nodes(5);
            //Nodes fourthNodes = new Nodes(6);

            //noCycleLinkedList.head1.next = firstNodes;
            //firstNodes.next = secondNodes;
            //secondNodes.next = thirdNodes;
            //thirdNodes.next = fourthNodes;

            //Console.WriteLine(noCycleLinkedList.hasCycle());

            //Program cycleLinkedList = new Program();
            //cycleLinkedList.head1 = firstNodes;
            //thirdNodes = secondNodes;
            //Console.WriteLine(cycleLinkedList.hasCycle());


            #endregion

            #region Tree Algorithm Result

            Nodes rootNode = new Nodes();
            rootNode.Data = 4;

            Nodes nodeOne = new Nodes();
            nodeOne.Data = 1;

            Nodes nodeThree = new Nodes();
            nodeThree.Data = 3;

            Nodes nodeEight = new Nodes();
            nodeEight.Data = 8;

            Nodes nodeNine = new Nodes();
            nodeNine.Data = 9;

            Nodes nodeSix = new Nodes();
            nodeSix.Data = 6;

            rootNode.Left = nodeOne;
            rootNode.Right = nodeThree;
            nodeOne.Left = nodeEight;
            nodeOne.Right = nodeNine;
            nodeThree.Left = nodeSix;

            BinaryTrees.preOrderTraversal(rootNode);
            Console.WriteLine("End PreOrder");

            BinaryTrees.inOrderTraversal(rootNode);
            Console.WriteLine("End InOrder");

            BinaryTrees.postOrderTraversal(rootNode);
            Console.WriteLine("End PostOrder");


            BinarySearchTree.Insert(rootNode, 2);
            BinarySearchTree.Insert(rootNode, 3);
            BinarySearchTree.Insert(rootNode, 5);
            BinarySearchTree.Insert(rootNode, 6);
            BinarySearchTree.Insert(rootNode, 4);

            Console.WriteLine(BinarySearchTree.Contains(rootNode, 4));
            Console.WriteLine(BinarySearchTree.Contains(rootNode, 3));
            Console.WriteLine(BinarySearchTree.Contains(rootNode, 5));
            Console.WriteLine(BinarySearchTree.Contains(rootNode, 6));


            Console.WriteLine(BinarySearchTree.Contains(rootNode, 7));
            Console.WriteLine(BinarySearchTree.Contains(rootNode, 8));
            Console.WriteLine(BinarySearchTree.Contains(rootNode, 9));
            Console.WriteLine(BinarySearchTree.Contains(rootNode, 10));

            #endregion
        }
    }
}
