using System;
using Utilities.Debugger;
using Warehouse;
using NUnit.Framework;

namespace WarehouseTest
{
    [TestFixture]
    [Ignore("Ignoring TableTest ...")]
    public class TableTest : WarehouseDataTest
    {
        public TableTest()
        {
            //turn on debugging
            Debug.DebugMode = true;
            Debug.StepMode  = true;
        }

        [Test]
        public override void getRandomWarehouse_Test()
        {
            Table table = new MyTable();
            table.getRandomWarehouse();
            base.getRandomWarehouse_Test(table);
            Assert.IsNotNullOrEmpty(table.TableName);
        }

        [Test]
        public override void Equals_Test()
        {
            Table table1 = new MyTable();
            Table table2 = new MyTable();
            base.Equal_TestHelper(table1, table2);

            table1.getRandomWarehouse();
            table2 = new MyTable(table1);
            
            base.Equal_TestHelper(table1, table2);
        }

        [Test]
        public override void Copy_Test()
        {
            //can't copy abstract table...
        }

        [Test]
        public override void Constructor_Test()
        {
            //can't instantiate abstract table...
        }

        [Test]
        public override void ToString_Test()
        {
            Table table = new MyTable();
            table.getRandomWarehouse();
            Assert.IsTrue(table.ToString().Contains(table.TableName));
        }

        [Test]
        public override void EqualOperator_Test()
        {
            Table table1 = new MyTable();
            Table table2 = new MyTable();
            Assert.IsTrue(table1 == table2);

            table1.getRandomWarehouse();
            Assert.IsFalse(table1 == table2);
            
            table2 = new MyTable(table1);
            Assert.IsTrue(table1 == table2);
        }

        [Test]
        public override void NotEqualOperator_Test()
        {
            Table table1 = new MyTable();
            Table table2 = new MyTable();
            Assert.IsFalse(table1 != table2);
            table2.id = "tableid";
            Assert.IsTrue(table1 != table2);

            table1.getRandomWarehouse();
            Assert.IsTrue(table1 != table2);
            table2 = new MyTable(table1);
            Assert.IsFalse(table1 != table2);
        }

        [Test]
        public override void GetHashCode_Test()
        {
            Table table1 = new MyTable();
            Table table2 = new MyTable();
            Assert.AreEqual(table1.GetHashCode(), table2.GetHashCode());

            table1.getRandomWarehouse();
            Assert.AreNotEqual(table1.GetHashCode(), table2.GetHashCode());
            
            table2 = new MyTable(table1);
            Assert.AreEqual(table1.GetHashCode(), table2.GetHashCode());
        }

        [Test]
        public override void Exists_Test()
        {
            Table table = new MyTable();
            int count = 0;
            try { table.Exists(); }
            catch { count++; }
            Assert.AreEqual(1, count);
        }

        [Test]
        public override void Create_Test()
        {
            Table table = new MyTable();
            int count = 0;
            try { table.Create(); }
            catch { count++; }
            Assert.AreEqual(1, count);
        }

        [Test]
        public override void Read_Test()
        {
            Table table = new MyTable();
            int count = 0;
            try { table.Read(); }
            catch { count++; }
            Assert.AreEqual(1, count);
        }

        [Test]
        public override void Update_Test()
        {
            Table table = new MyTable();
            int count = 0;
            try { table.Update(); }
            catch { count++; }
            Assert.AreEqual(0, count);
        }

        [Test]
        public override void Delete_Test()
        {
            Table table = new MyTable();
            Assert.IsFalse(table.Delete());
        }
    }

    //table for testing
    public class MyTable : Table
    {
        public MyTable() : base() { }
        public MyTable(Table table) : base(table) { }
    }
}
