// Fabrice Kalvanda
// October 26th, 2020
// Party Planning Arragement
//Purpose: This program is set to arrange the seating at a particular awards ceremony.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinaPartyPlan
{ 
    class MainClass
    {
        //Creating linked list class and node
        public class Node
        {
            public Node next;
            public string name;
        }

        public class LinkedList
        {
            private Node head;
            private Node last;
            public int count;

            public LinkedList()
            {
                head = new Node();
                last = head;
            }

        //Methode to add node at the end 
            public void AddAtLast(string data)
            {
                Node newNode = new Node();
                newNode.name = data;
                last.next = newNode;
                last = newNode;
                count++;
            }
        //Methode to remove the first node 
            public void RemoveNodeName(string data)
            {
                Node curr = head;
                Node prev;

                while (curr.next != null)
                {
                    prev = curr;
                    curr = curr.next;

                    if (curr.name == data)
                    {
                        prev = curr.next;
                        curr.next = curr.next.next;
                        count++;
                        return;
                    }
                }
            }
            //Methode to print every single node
            public void PrintAllNodes(string separator)
            {
                Node curr = head;

                while(curr.next != null)
                {
                    curr = curr.next;
                    Console.Write(curr.name);

                    if (curr.next != null)
                    {
                        Console.Write(separator);
                    }
                }
            }
        }
        //Methode to define the default list
        private static void DefaultList(LinkedList guestList)
        {
            guestList.AddAtLast("Hasan Minhaj");
            guestList.AddAtLast(" Nick Jonas");
            guestList.AddAtLast(" Priyanka Chopra");
            guestList.AddAtLast(" Angelina Jolie");
            guestList.AddAtLast(" Varun Dhawan");
            guestList.AddAtLast(" Zayn Malik");
            guestList.AddAtLast(" Taylor Swift");
            guestList.AddAtLast(" Shahrukh Khan");
            guestList.AddAtLast(" Selena Gomez");
            guestList.AddAtLast(" Kim Kardashian");
            guestList.AddAtLast(" Salman Khan");
            guestList.AddAtLast(" Sonam Kapoor");
            guestList.AddAtLast(" Kevin Hart");
            guestList.AddAtLast(" Amitabh Bachchan");
            guestList.AddAtLast(" Kanye West\n");
        }
        //Methode to display the wecome message and print the default list
        private static void WlcmMsg(LinkedList guestList, LinkedList orderedList)
        {
            string msg = "Hi, Welcome to Tina's Planning!" +
                "Here are a few options for the seating arrangement for your event!";

            DisplayArrargment(msg, guestList, orderedList);
        }

        //Methode to print the current arrangement
        private static void PrintArragment(LinkedList guestList, LinkedList orderedList)
        {
            const string msg = "Ok, here’s the new arrangement:";
            DisplayArrargment(msg, guestList, orderedList);
        }

        //Methode to print the current list arrangement and add comma between nodes
        private static void DisplayArrargment(string msg, LinkedList guestList, LinkedList orderedList)
        {
            Console.WriteLine(msg);
            Console.WriteLine();
            orderedList.PrintAllNodes(", ");

            if (guestList.count > 0)
            {
                if (orderedList.count > 0)
                {
                    Console.Write(", ");
                }
                guestList.PrintAllNodes(", ");
            }
            Console.WriteLine();
        }

        // Methode to print the Final list 
        private static void PrintFinalList(LinkedList guestList, LinkedList orderedList)
        {
            const string finalMessage = "Great! Here is the final seating arrangement:";
            DisplayArrargment(finalMessage, guestList, orderedList);
        }
        
        

        public static void Main(string[] args)
        {
            const string FINISH = "FINISH";

            LinkedList guestList = new LinkedList();
            LinkedList orderedList = new LinkedList();

            DefaultList(guestList);
            WlcmMsg(guestList, orderedList);
            Console.WriteLine("Who would you like to seat first?");

            string userInput = Console.ReadLine();//Getting the user input

            //Looping the program to get as many arragement the user want
            while (true)
            {
                Console.WriteLine();

                if (userInput == FINISH)
                {
                    PrintFinalList(guestList, orderedList);
                    return;
                }
                else
                {
                    guestList.RemoveNodeName(userInput);
                    orderedList.AddAtLast(userInput);

                    PrintArragment(guestList, orderedList);
                    Console.WriteLine("Who would you like to seat next?");

                    userInput = Console.ReadLine();
                }
            }
        }
    }
}
