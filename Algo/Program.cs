using System;
using DynamicConnectivity;

namespace Algo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Quick Find
            Console.WriteLine("test : x and y are connected");
            Soln soln = new Soln(5);
            soln.Union(1,2);
            Console.WriteLine(true == soln.IsConnected(1, 2));
            
            Console.WriteLine("test : x and y and z are connected");
            soln = new Soln(5);
            soln.Union(1,2);
            soln.Union(2,3);
            Console.WriteLine(true == soln.IsConnected(1, 3));
            
            Console.WriteLine("test : x and y are not connected");
            soln = new Soln(5);
            soln.Union(2,3);
            Console.WriteLine(false == soln.IsConnected(1, 2));

            
            Console.WriteLine("test : x && y are connected");
            soln = new Soln(10);
            soln.Union(1,2);
            soln.Union(2,3);
            soln.Union(4,5);
            soln.Union(7,8);
            soln.Union(1,8);
            Console.WriteLine(true == soln.IsConnected(2, 8));

            //Quick Union
            Console.WriteLine("test : x and y are connected");
            QuickUnion quickUnion = new QuickUnion(5);
            quickUnion.Union(1,2);
            Console.WriteLine(true == quickUnion.IsConnected(1, 2));
            
            Console.WriteLine("test : x and y and z are connected");
            quickUnion = new QuickUnion(5);
            quickUnion.Union(1,2);
            quickUnion.Union(2,3);
            Console.WriteLine(true == quickUnion.IsConnected(1, 3));
            
            Console.WriteLine("test : x and y are not connected");
            quickUnion = new QuickUnion(5);
            quickUnion.Union(2,3);
            Console.WriteLine(false == quickUnion.IsConnected(1, 2));

            
            Console.WriteLine("test : x && y are connected");
            quickUnion = new QuickUnion(10);
            quickUnion.Union(1,2);
            quickUnion.Print();
            quickUnion.Union(2,3);
            quickUnion.Print();
            quickUnion.Union(4,5);
            quickUnion.Print();
            quickUnion.Union(7,8);
            quickUnion.Print();
            quickUnion.Union(1,8);
            quickUnion.Print();

            Console.WriteLine(true == quickUnion.IsConnected(2, 8));

            Console.WriteLine("Hello World!");
        }
    }
}
