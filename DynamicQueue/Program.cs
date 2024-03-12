using System;

namespace DynamicQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine();

            //Create queue
            DynamicQueue<string> qNames = new DynamicQueue<string>();

            //Enqueue some test data
            qNames.Enqueue("Mike");
            qNames.Enqueue("Thabo");
            qNames.Clear();
            qNames.Enqueue("Lily");
            qNames.Enqueue("Susan");
            qNames.Enqueue("Mary");
            qNames.Dequeue();
            qNames.Enqueue("John");
            qNames.Enqueue("Peter");
            qNames.Enqueue("Hendrik");

            //Peek first element
            Console.WriteLine("\tFirst name: " + qNames.Peek());
            Console.WriteLine();

            if (qNames.Contains("Peter"))
                Console.WriteLine("\tPosition of 'Peter': " + qNames.Position("Peter"));
            else
                Console.WriteLine("\t'Peter' is not in the queue.");
            Console.WriteLine();

            //Dequeue and print names
            Console.WriteLine("\tList names:");
            Console.Write("\t");
            while (qNames.Count > 0)
                Console.Write(qNames.Dequeue() + ", ");
            Console.WriteLine(); Console.WriteLine();

            //Peek empty queue
            Console.WriteLine("\tNothing: " + qNames.Peek());

            //Opportunity to read output
            Console.WriteLine();
            Console.Write("\tPress any key to exit ...");
            Console.ReadKey();

        } //Main
    } //class Program
} //namespace
