using System.Collections;
using System;
using System.Linq;

namespace LänkadListaLab
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Skapar lite värden, i min lista

            MyList<int> list = new MyList<int>();
            list.AddElement(3);
            list.AddElement(1);
            list.AddElement(10);
            list.AddElement(2);
            list.AddElement(12);
            list.AddElement(3);
            list.AddElement(20);


            Console.WriteLine("Original list:");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(); // Ny rad efter listan

            // Visa menyn för användaren
            Console.WriteLine($"\nChoose what to do with this list:");
            Console.WriteLine("A = Add a new element");
            Console.WriteLine("S = Sort the list acsending");
            Console.WriteLine("R = Remove all elements after a certain index");
            Console.WriteLine("E = Exit");
            string choice = Console.ReadLine().ToUpper(); // Gör om valet till versaler 

            switch (choice)
            {
                case "A": // Lägg till ett nytt element
                    Console.Write("Enter the value you want to add: ");
                    int newValue;
                    if (int.TryParse(Console.ReadLine(), out newValue))
                    {
                        list.AddElement(newValue);
                        Console.WriteLine($"{newValue} has been added to the list.");

                        foreach (var item in list)
                        {
                            Console.WriteLine(item);
                        }

                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Invalid input! Please enter a valid integer.");
                    }
                    break;

                case "S":
                    Console.WriteLine(" List will be sorted acsending");
                    list.SortMyList(true);          //sorterar listan i stigande ordning
                    Console.WriteLine("Sorted list: \n ");
                    foreach (var item in list)
                    {
                        Console.Write(item + " ");  // Skriver ut varje element i listan
                    }
                    Console.WriteLine();
                    break;

            }

            //Tar bort sista elementet i min orginallista (20)

            list.RemoveLastElement();
            Console.WriteLine("After removing last element:");
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            

            //skriver ut en klonad array (orginal)

            var clonedArray = list.ToClonedArray(); 
            Console.WriteLine("Cloned array:");
            foreach (var item in clonedArray)
            {
                Console.WriteLine(item);
            }

        }
    }
}

    

