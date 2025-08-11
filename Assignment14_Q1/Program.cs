using System; 

namespace Assignment14_Q1
{
    // Node class
    class StackNode
    {
        public int Data;
        public StackNode? Next; // Nullable to avoid warning
    }

    // Stack implementation using Linked List
    class StackUsingLinkedList
    {
        private StackNode? top = null;

        // Push operation
        public void Push(int data)
        {
            StackNode newNode = new StackNode();
            newNode.Data = data;
            newNode.Next = top;
            top = newNode;
            Console.WriteLine($"{data} pushed to stack");
        }

        // Pop operation
        public void Pop()
        {
            if (top == null)
            {
                Console.WriteLine("Stack is empty. Nothing to pop.");
                return;
            }
            Console.WriteLine($"{top.Data} popped from stack");
            top = top.Next;
        }

        // Display stack contents
        public void Display()
        {
            if (top == null)
            {
                Console.WriteLine("Stack is empty.");
                return;
            }

            Console.WriteLine("Stack contents:");
            StackNode? temp = top;
            while (temp != null)
            {
                Console.WriteLine(temp.Data);
                temp = temp.Next;
            }
        }
    }

    // Main method to test the stack
    class Program
    {
        static void Main(string[] args)
        {
            StackUsingLinkedList stack = new StackUsingLinkedList();

            stack.Push(10);
            stack.Push(20);
            stack.Push(30);
            stack.Display();

            stack.Pop();
            stack.Display();

            stack.Pop();
            stack.Pop();
            stack.Pop(); // Extra pop to test empty case

            stack.Display();
        }
    }
}
