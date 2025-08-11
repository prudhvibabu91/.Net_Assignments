using System;

namespace Assignment14_Q2
{
    // Node class
    class QueueNode
    {
        public int Data;
        public QueueNode? Next; // Nullable to prevent warnings
    }

    // Queue implementation using Linked List
    class QueueUsingLinkedList
    {
        private QueueNode? front = null;
        private QueueNode? rear = null;

        // Insert operation (Enqueue)
        public void Insert(int data)
        {
            QueueNode newNode = new QueueNode();
            newNode.Data = data;
            newNode.Next = null;

            if (rear == null)
            {
                front = rear = newNode;
            }
            else
            {
                rear.Next = newNode;
                rear = newNode;
            }

            Console.WriteLine($"{data} inserted into queue");
        }

        // Delete operation (Dequeue)
        public void Delete()
        {
            if (front == null)
            {
                Console.WriteLine("Queue is empty. Nothing to delete.");
                return;
            }

            Console.WriteLine($"{front.Data} deleted from queue");
            front = front.Next;

            if (front == null)
            {
                rear = null;
            }
        }

        // Display queue contents
        public void Display()
        {
            if (front == null)
            {
                Console.WriteLine("Queue is empty.");
                return;
            }

            Console.WriteLine("Queue contents:");
            QueueNode? temp = front;
            while (temp != null)
            {
                Console.WriteLine(temp.Data);
                temp = temp.Next;
            }
        }
    }

    // Main method to test the queue
    class Program
    {
        static void Main(string[] args)
        {
            QueueUsingLinkedList queue = new QueueUsingLinkedList();

            queue.Insert(100);
            queue.Insert(200);
            queue.Insert(300);
            queue.Display();

            queue.Delete();
            queue.Display();

            queue.Delete();
            queue.Delete();
            queue.Delete(); // Extra delete to test empty case

            queue.Display();
        }
    }
}
