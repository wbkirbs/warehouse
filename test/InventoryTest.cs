/*using System;
using Utilities.Debugger;
using Databases;
using NUnit.Framework;
using Warehouse;

namespace WarehouseTest
{
    [TestFixture]
    [Ignore("Ignoring InventoryTest ...")]
    public class InventoryTest : WarehouseDataTest
    {
        private Database _abecasDatabase = new SqlDatabase("abecas_practice", "wfsapp02");

        public InventoryTest()
        {
            //turn on debugging
            Debug.DebugMode = true;
            Debug.StepMode  = true;
        }

        [Test]
        public override void getRandomWarehouse_Test()
        {
            Inventory item = new Inventory();
            item.getRandomWarehouse();
            base.getRandomWarehouse_Test(item);
            Assert.IsNotNullOrEmpty(item.colorCode);
            Assert.IsNotNullOrEmpty(item.colorDescription);
            Assert.IsNotNullOrEmpty(item.departmentCode);
            Assert.IsNotNullOrEmpty(item.description);
            Assert.IsNotNull(item.discount);
            Assert.IsNotNullOrEmpty(item.location);
            Assert.IsNotNull(item.oversize);
            Assert.IsNotNull(item.price);
            Assert.IsNotNull(item.quantity);
            Assert.IsNotNullOrEmpty(item.sizeCode);
            Assert.IsNotNullOrEmpty(item.sizeDescription);
            Assert.IsNotNullOrEmpty(item.sku);
            Assert.IsNotNullOrEmpty(item.upc);
        }

        [Test]
        public override void Equals_Test()
        {
            Inventory item1 = new Inventory();
            Inventory item2 = new Inventory();
            base.Equal_TestHelper(item1, item2);

            item1.getRandomWarehouse();
            item2 = new Inventory();
            Assert.AreNotEqual(item1, item2);
            item2.id = item1.id;
            Assert.AreNotEqual(item1, item2);
            item2.colorCode = item1.colorCode;
            Assert.AreNotEqual(item1, item2);
            item2.colorDescription = item1.colorDescription;
            Assert.AreNotEqual(item1, item2);
            item2.departmentCode = item1.departmentCode;
            Assert.AreNotEqual(item1, item2);
            item2.description = item1.description;
            Assert.AreNotEqual(item1, item2);
            item2.discount = item1.discount;
            Assert.AreNotEqual(item1, item2);
            item2.location = item1.location;
            Assert.AreNotEqual(item1, item2);
            item2.oversize = item1.oversize;
            Assert.AreNotEqual(item1, item2);
            item2.price = item1.price;
            Assert.AreNotEqual(item1, item2);
            item2.quantity = item1.quantity;
            Assert.AreNotEqual(item1, item2);
            item2.sizeCode = item1.sizeCode;
            Assert.AreNotEqual(item1, item2);
            item2.sizeDescription = item1.sizeDescription;
            Assert.AreEqual(item1, item2);
            
            //sku and upc are aliases of id
            item2.sku = item1.sku;
            base.Equal_TestHelper(item1, item2);
            
            item2.upc = item1.upc;
            base.Equal_TestHelper(item1, item2);
        }

        [Test]
        public override void Copy_Test()
        {
            _warehouse = new Inventory();
            base.Copy_TestHelper();

            _warehouse.getRandomWarehouse();
            base.Copy_TestHelper();
        }

        [Test]
        public override void Constructor_Test()
        {
            //test the various types of constructors
            _warehouse = new Inventory();
            Inventory item = new Inventory();
            Assert.AreNotSame(_warehouse, item);

            item = new Inventory((Inventory) _warehouse);
            Assert.AreNotSame(_warehouse, item);
            Assert.AreEqual(_warehouse, item);

            Inventory item2 = new Inventory();
            item = new Inventory(item2);
            Assert.AreNotSame(item, item2);
            Assert.AreEqual(item, item2);

            item = new Inventory(new Company());
            item = new Inventory(_abecasDatabase);
        }

        [Test]
        public override void ToString_Test()
        {
            Inventory item = new Inventory();
            item.getRandomWarehouse();
            Assert.IsTrue(item.ToString().Contains(item.id));
            Assert.IsTrue(item.ToString().Contains(item.colorCode));
            Assert.IsTrue(item.ToString().Contains(item.colorDescription));
            Assert.IsTrue(item.ToString().Contains(item.departmentCode));
            Assert.IsTrue(item.ToString().Contains(item.description));
            Assert.IsTrue(item.ToString().Contains(item.discount.ToString()));
            Assert.IsTrue(item.ToString().Contains(item.location));
            Assert.IsTrue(item.ToString().Contains(item.oversize.ToString()));
            Assert.IsTrue(item.ToString().Contains(item.price.ToString()));
            Assert.IsTrue(item.ToString().Contains(item.quantity.ToString()));
            Assert.IsTrue(item.ToString().Contains(item.sizeCode));
            Assert.IsTrue(item.ToString().Contains(item.sizeDescription));
            Assert.IsTrue(item.ToString().Contains(item.sku));
            Assert.IsTrue(item.ToString().Contains(item.upc));
        }

        [Test]
        public override void EqualOperator_Test()
        {
            Inventory item1 = new Inventory();
            Inventory item2 = new Inventory();
            Assert.IsTrue(item1 == item2);

            item1.getRandomWarehouse();
            Assert.IsFalse(item1 == item2);
            
            item2 = new Inventory(item1);
            Assert.IsTrue(item1 == item2);
        }

        [Test]
        public override void NotEqualOperator_Test()
        {
            Inventory item1 = new Inventory();
            Inventory item2 = new Inventory();
            Assert.IsFalse(item1 != item2);
            item2.id = "itemid";
            Assert.IsTrue(item1 != item2);

            item1.getRandomWarehouse();
            Assert.IsTrue(item1 != item2);
            item2 = new Inventory(item1);
            Assert.IsFalse(item1 != item2);
        }

        [Test]
        public override void GetHashCode_Test()
        {
            Inventory item1 = new Inventory();
            Inventory item2 = new Inventory();
            Assert.AreEqual(item1.GetHashCode(), item2.GetHashCode());

            item1.getRandomWarehouse();
            Assert.AreNotEqual(item1.GetHashCode(), item2.GetHashCode());
            
            item2 = new Inventory(item1);
            Assert.AreEqual(item1.GetHashCode(), item2.GetHashCode());
        }

        [Test]
        public override void Exists_Test()
        {
            Inventory item = new Inventory();
            int count = 0;
            try { item.Exists(); }
            catch { count++; }
            Assert.AreEqual(1, count);
        }

        [Test]
        public override void Create_Test()
        {
            Inventory item = new Inventory();
            int count = 0;
            try { item.Create(); }
            catch { count++; }
            Assert.AreEqual(1, count);
        }

        [Test]
        public override void Read_Test()
        {
            Inventory item = new Inventory();
            int count = 0;
            try { item.Read(); }
            catch { count++; }
            Assert.AreEqual(1, count);
        }

        [Test]
        public override void Update_Test()
        {
            Inventory item = new Inventory();
            int count = 0;
            try { item.Update(); }
            catch { count++; }
            Assert.AreEqual(1, count);
        }

        [Test]
        public override void Delete_Test()
        {
            Inventory item = new Inventory();
            int count = 0;
            try { item.Delete(); }
            catch { count++; }
            Assert.AreEqual(1, count);
        }
    }
}
*/