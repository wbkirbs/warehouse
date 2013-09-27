/*using System;
using Utilities.Debugger;
using Databases;
using Warehouse;
using NUnit.Framework;

namespace WarehouseTest
{
    [TestFixture]
    [Ignore("Ignoring PurchaseOrderTest ...")]
    public class PurchaseOrderTest : WarehouseDataTest
    {
        private Database _abecasDatabase = new SqlDatabase("abecas_practice", "wfsapp02");

        public PurchaseOrderTest()
        {
            //turn on debugging
            Debug.DebugMode = true;
            Debug.StepMode  = true;
        }

        [Test]
        public override void getRandomWarehouse_Test()
        {
            PurchaseOrder po = new PurchaseOrder();
            po.getRandomWarehouse();
            base.getRandomWarehouse_Test(po);
            Assert.IsNotNull(po.dateCreated);
            Assert.IsNotNull(po.dateExpected);
            Assert.IsNotNull(po.dateReceived);
            Assert.IsNotNull(po.items);
            Assert.IsNotNull(po.shipper);
        }

        [Test]
        public override void Equals_Test()
        {
            PurchaseOrder po1 = new PurchaseOrder();
            PurchaseOrder po2 = new PurchaseOrder();
            base.Equal_TestHelper(po1, po2);

            po1.getRandomWarehouse();
            po2 = new PurchaseOrder();
            Assert.AreNotEqual(po1, po2);
            po2.id = po1.id;
            Assert.AreNotEqual(po1, po2);
            po2.dateCreated = po1.dateCreated;
            Assert.AreNotEqual(po1, po2);
            po2.dateExpected = po1.dateExpected;
            Assert.AreNotEqual(po1, po2);
            po2.dateReceived = po1.dateReceived;
            Assert.AreNotEqual(po1, po2);
            po2.shipper = new Customer(po1.shipper);
            Assert.AreNotEqual(po1, po2);

            po2.items = new Inventory[po1.items.Length];
            for (int i = 0; i < po1.items.Length; i++) po2.items[i] = new Inventory(po1.items[i]);
            
            base.Equal_TestHelper(po1, po2);
        }

        [Test]
        public override void Copy_Test()
        {
            _warehouse = new PurchaseOrder();
            base.Copy_TestHelper();

            _warehouse.getRandomWarehouse();
            base.Copy_TestHelper();
        }

        [Test]
        public override void Constructor_Test()
        {
            //test the various types of constructors
            _warehouse = new PurchaseOrder();
            PurchaseOrder po = new PurchaseOrder();
            Assert.AreNotSame(_warehouse, po);

            po = new PurchaseOrder((PurchaseOrder) _warehouse);
            Assert.AreNotSame(_warehouse, po);
            Assert.AreEqual(_warehouse, po);

            PurchaseOrder po2 = new PurchaseOrder();
            po = new PurchaseOrder(po2);
            Assert.AreNotSame(po, po2);
            Assert.AreEqual(po, po2);

            po = new PurchaseOrder(new Company());
            po = new PurchaseOrder(_abecasDatabase);
        }

        [Test]
        public override void ToString_Test()
        {
            PurchaseOrder po = new PurchaseOrder();
            po.getRandomWarehouse();
            Assert.IsTrue(po.ToString().Contains(po.id));
            Assert.IsTrue(po.ToString().Contains(po.dateCreated.ToString()));
            Assert.IsTrue(po.ToString().Contains(po.dateExpected.ToString()));
            Assert.IsTrue(po.ToString().Contains(po.dateReceived.ToString()));
            Assert.IsTrue(po.ToString().Contains(po.shipper.ToString()));
            foreach (Inventory item in po.items) Assert.IsTrue(po.ToString().Contains(item.ToString()));
        }

        [Test]
        public override void EqualOperator_Test()
        {
            PurchaseOrder po1 = new PurchaseOrder();
            PurchaseOrder po2 = new PurchaseOrder();
            Assert.IsTrue(po1 == po2);

            po1.getRandomWarehouse();
            Assert.IsFalse(po1 == po2);
            
            po2 = new PurchaseOrder(po1);
            Assert.IsTrue(po1 == po2);
        }

        [Test]
        public override void NotEqualOperator_Test()
        {
            PurchaseOrder po1 = new PurchaseOrder();
            PurchaseOrder po2 = new PurchaseOrder();
            Assert.IsFalse(po1 != po2);
            po2.id = "poid";
            Assert.IsTrue(po1 != po2);

            po1.getRandomWarehouse();
            Assert.IsTrue(po1 != po2);
            po2 = new PurchaseOrder(po1);
            Assert.IsFalse(po1 != po2);
        }

        [Test]
        public override void GetHashCode_Test()
        {
            PurchaseOrder po1 = new PurchaseOrder();
            PurchaseOrder po2 = new PurchaseOrder();
            Assert.AreEqual(po1.GetHashCode(), po2.GetHashCode());

            po1.getRandomWarehouse();
            Assert.AreNotEqual(po1.GetHashCode(), po2.GetHashCode());
            
            po2 = new PurchaseOrder(po1);
            Assert.AreEqual(po1.GetHashCode(), po2.GetHashCode());
        }

        [Test]
        public override void Exists_Test()
        {
            PurchaseOrder po = new PurchaseOrder();
            int count = 0;
            try { po.Exists(); }
            catch { count++; }
            Assert.AreEqual(1, count);
        }

        [Test]
        public override void Create_Test()
        {
            PurchaseOrder po = new PurchaseOrder();
            int count = 0;
            try { po.Create(); }
            catch { count++; }
            Assert.AreEqual(1, count);
        }

        [Test]
        public override void Read_Test()
        {
            PurchaseOrder po = new PurchaseOrder();
            int count = 0;
            try { po.Read(); }
            catch { count++; }
            Assert.AreEqual(1, count);
        }

        [Test]
        public override void Update_Test()
        {
            PurchaseOrder po = new PurchaseOrder();
            int count = 0;
            try { po.Update(); }
            catch { count++; }
            Assert.AreEqual(1, count);
        }

        [Test]
        public override void Delete_Test()
        {
            PurchaseOrder po = new PurchaseOrder();
            int count = 0;
            try { po.Delete(); }
            catch { count++; }
            Assert.AreEqual(1, count);
        }
    }
}
*/