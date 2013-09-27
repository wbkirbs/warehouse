using System;
using NUnit.Framework;
using NUnit.ConsoleRunner;
using Utilities.Debugger;
using Warehouse;

namespace WarehouseTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //some basic tests
            /*Item item = new Item();
            InventoryItem inventory = (InventoryItem) item;
            item = inventory;
            //inventory = item;

            InventoryItem inventory2 = new InventoryItem();
            Item item2 = inventory2;
            */

            CompanyTest test = new CompanyTest();
            test.CompanyInfoInheritanceTest();

            return;//temp, just testing compilation

            Debug.TurnOffDebugging();

            //args = new string[] { @".\WarehouseTest.exe" };
            //Runner.Main(args);

            //join test
            TableJoinTest joinTest = new TableJoinTest();
            joinTest.AbecasJoin_Test();

            /*Customer customer1 = new Customer();
			Customer customer2 = new Customer();
			customer1 = new Customer((Customer) customer2);
            if (customer1 == customer2) Console.WriteLine("ARE EQUAL");
            customer1.getRandomWarehouse();
            customer2 = new Customer(customer1);
            if(customer1 == customer2) Console.WriteLine("ARE EQUAL");;*/

            /*Customer customer1 = new Customer();
            Customer customer2 = new Customer();
            Assert.IsTrue(customer1 == customer2);

            customer1.getRandomWarehouse();
            Assert.IsFalse(customer1 == customer2);
            
            customer2 = new Customer(customer1);
            if(customer1 == customer2) Console.WriteLine("ARE EQUAL");
            Console.WriteLine("READING ALL DONE..."); Console.ReadLine();
            //return;


            args = new string[] { @".\WarehouseTest.exe" };
            int stressTest = 1;
            for (int i = 0; i < stressTest; i++) Runner.Main(args);

            //OrderTest test = new OrderTest();
            //test.Copy_Test();

            Console.WriteLine("Done Warehouse Tests!");
            //Console.ReadLine();*/
        }
    }
}
