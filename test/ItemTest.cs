/*using System;
using Utilities.Debugger;
using Databases;
using Warehouse;
using NUnit.Framework;

namespace WarehouseTest
{
    [TestFixture]
    [Ignore("Ignoring ItemTest ...")]
    public class ItemTest : WarehouseDataTest
    {
        private Database _abecasDatabase = new SqlDatabase("abecas_practice", "wfsapp02");

        public ItemTest()
        {
            //turn on debugging
            Debug.DebugMode = true;
            Debug.StepMode  = true;
        }

        [Test]
        public override void getRandomWarehouse_Test()
        {
            Item item = new Item();
            item.getRandomWarehouse();
            base.getRandomWarehouse_Test(item);
            Assert.IsNotNull(item.continuity);
            Assert.IsNotNullOrEmpty(item.giftMessage);
            Assert.IsNotNull(item.giftWrap);
            Assert.IsNotNull(item.shipDate);
            Assert.IsNotNull(item.total);
        }

        [Test]
        public override void Equals_Test()
        {
            Item item1 = new Item();
            Item item2 = new Item();
            base.Equal_TestHelper(item1, item2);

            item1.getRandomWarehouse();
            item2 = new Item();
            Assert.AreNotEqual(item1, item2);
            item2.id = item1.id;
            Assert.AreNotEqual(item1, item2);
            item2.continuity = item1.continuity;
            Assert.AreNotEqual(item1, item2);
            item2.giftMessage = item1.giftMessage;
            Assert.AreNotEqual(item1, item2);
            item2.giftWrap = item1.giftWrap;
            Assert.AreNotEqual(item1, item2);
            item2.shipDate = item1.shipDate;
            Assert.AreNotEqual(item1, item2);
            item2.total = item1.total;
            
            item2 = (Item) item1.Copy();
            base.Equal_TestHelper(item1, item2);
        }

        [Test]
        public override void Copy_Test()
        {
            _warehouse = new Item();
            base.Copy_TestHelper();

            _warehouse.getRandomWarehouse();
            base.Copy_TestHelper();
        }

        [Test]
        public override void Constructor_Test()
        {
            //test the various types of constructors
            _warehouse = new Item();
            Item item = new Item();
            Assert.AreNotSame(_warehouse, item);

            item = new Item((Item) _warehouse);
            Assert.AreNotSame(_warehouse, item);
            Assert.AreEqual(_warehouse, item);

            Item item2 = new Item();
            item = new Item(item2);
            Assert.AreNotSame(item, item2);
            Assert.AreEqual(item, item2);

            item = new Item(new Company());
            item = new Item(_abecasDatabase);
        }

        [Test]
        public override void ToString_Test()
        {
            Item item = new Item();
            item.getRandomWarehouse();
            Assert.IsTrue(item.ToString().Contains(item.id));
            Assert.IsTrue(item.ToString().Contains(item.inventory.colorCode));
            Assert.IsTrue(item.ToString().Contains(item.inventory.colorDescription));
            Assert.IsTrue(item.ToString().Contains(item.inventory.departmentCode));
            Assert.IsTrue(item.ToString().Contains(item.inventory.description));
            Assert.IsTrue(item.ToString().Contains(item.inventory.discount.ToString()));
            Assert.IsTrue(item.ToString().Contains(item.inventory.location));
            Assert.IsTrue(item.ToString().Contains(item.inventory.oversize.ToString()));
            Assert.IsTrue(item.ToString().Contains(item.price.ToString()));
            Assert.IsTrue(item.ToString().Contains(item.quantity.ToString()));
            Assert.IsTrue(item.ToString().Contains(item.inventory.sizeCode));
            Assert.IsTrue(item.ToString().Contains(item.inventory.sizeDescription));
            Assert.IsTrue(item.ToString().Contains(item.sku));
            Assert.IsTrue(item.ToString().Contains(item.upc));
            Assert.IsTrue(item.ToString().Contains(item.continuity.ToString()));
            Assert.IsTrue(item.ToString().Contains(item.giftMessage));
            Assert.IsTrue(item.ToString().Contains(item.giftWrap.ToString()));
            Assert.IsTrue(item.ToString().Contains(item.shipDate.ToString()));
            Assert.IsTrue(item.ToString().Contains(item.total.ToString()));
        }


        [Test]
        public override void EqualOperator_Test()
        {
            Item item1 = new Item();
            Item item2 = new Item();
            Assert.IsTrue(item1 == item2);

            item1.getRandomWarehouse();
            Assert.IsFalse(item1 == item2);
            
            item2 = new Item(item1);
            Assert.IsTrue(item1 == item2);
        }


        [Test]
        public override void NotEqualOperator_Test()
        {
            Item item1 = new Item();
            Item item2 = new Item();
            Assert.IsFalse(item1 != item2);
            item2.id = "itemid";
            Assert.IsTrue(item1 != item2);

            item1.getRandomWarehouse();
            Assert.IsTrue(item1 != item2);
            item2 = new Item(item1);
            Assert.IsFalse(item1 != item2);
        }

        [Test]
        public override void GetHashCode_Test()
        {
            Item item1 = new Item();
            Item item2 = new Item();
            Assert.AreEqual(item1.GetHashCode(), item2.GetHashCode());

            item1.getRandomWarehouse();
            Assert.AreNotEqual(item1.GetHashCode(), item2.GetHashCode());
            
            item2 = new Item(item1);
            Assert.AreEqual(item1.GetHashCode(), item2.GetHashCode());
        }

        [Test]
        public override void Exists_Test()
        {
            Item item = new Item();
            int count = 0;
            try { item.Exists(); }
            catch { count++; }
            Assert.AreEqual(1, count);
        }

        [Test]
        public override void Create_Test()
        {
            Item item = new Item();
            int count = 0;
            try { item.Create(); }
            catch { count++; }
            Assert.AreEqual(1, count);
        }

        [Test]
        public override void Read_Test()
        {
            Item item = new Item();
            int count = 0;
            try { item.Read(); }
            catch { count++; }
            Assert.AreEqual(1, count);
        }

        [Test]
        public override void Update_Test()
        {
            Item item = new Item();
            int count = 0;
            try { item.Update(); }
            catch { count++; }
            Assert.AreEqual(1, count);
        }

        [Test]
        public override void Delete_Test()
        {
            Item item = new Item();
            int count = 0;
            try { item.Delete(); }
            catch { count++; }
            Assert.AreEqual(1, count);
        }
    }
}
*/