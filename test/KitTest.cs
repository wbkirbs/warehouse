/*using System;
using Utilities.Debugger;
using Databases;
using Warehouse;
using NUnit.Framework;

namespace WarehouseTest
{
    [TestFixture]
    [Ignore("Ignoring KitTest ...")]
    public class KitTest : WarehouseDataTest
    {
        private Database _abecasDatabase = new SqlDatabase("abecas_practice", "wfsapp02");

        public KitTest()
        {
            //turn on debugging
            Debug.DebugMode = true;
            Debug.StepMode  = true;
        }

        [Test]
        public override void getRandomWarehouse_Test()
        {
            Kit kit = new Kit();
            kit.getRandomWarehouse();
            base.getRandomWarehouse_Test(kit);
            Assert.IsNotNullOrEmpty(kit.description);
            Assert.IsNotNullOrEmpty(kit.name);
            Assert.IsNotNullOrEmpty(kit.sku);
            Assert.IsNotNull(kit.items);
        }

        [Test]
        public override void Equals_Test()
        {
            Kit kit1 = new Kit();
            Kit kit2 = new Kit();
            base.Equal_TestHelper(kit1, kit2);

            kit1.getRandomWarehouse();
            kit2 = new Kit();
            Assert.AreNotEqual(kit1, kit2);
            kit2.id = kit1.id;
            Assert.AreNotEqual(kit1, kit2);
            kit2.description = kit1.description;
            Assert.AreNotEqual(kit1, kit2);
            kit2.name = kit1.name;
            Assert.AreNotEqual(kit1, kit2);
            kit2.sku = kit1.sku;
            Assert.AreNotEqual(kit1, kit2);
            kit2.items = new Inventory[kit1.items.Length];
            for (int i = 0; i < kit1.items.Length; i++) kit2.items[i] = new Inventory(kit1.items[i]);
            
            base.Equal_TestHelper(kit1, kit2);
        }

        [Test]
        public override void Copy_Test()
        {
            _warehouse = new Kit();
            base.Copy_TestHelper();

            _warehouse.getRandomWarehouse();
            base.Copy_TestHelper();
        }

        [Test]
        public override void Constructor_Test()
        {
            //test the various types of constructors
            _warehouse = new Kit();
            Kit kit = new Kit();
            Assert.AreNotSame(_warehouse, kit);

            kit = new Kit((Kit) _warehouse);
            Assert.AreNotSame(_warehouse, kit);
            Assert.AreEqual(_warehouse, kit);

            Kit kit2 = new Kit();
            kit = new Kit(kit2);
            Assert.AreNotSame(kit, kit2);
            Assert.AreEqual(kit, kit2);

            kit = new Kit(new Company());
            kit = new Kit(new SqlDatabase());
        }

        [Test]
        public override void ToString_Test()
        {
            Kit kit = new Kit();
            kit.getRandomWarehouse();
            Assert.IsTrue(kit.ToString().Contains(kit.id));
            Assert.IsTrue(kit.ToString().Contains(kit.description));
            Assert.IsTrue(kit.ToString().Contains(kit.name));
            Assert.IsTrue(kit.ToString().Contains(kit.sku));
            foreach (Inventory item in kit.items) Assert.IsTrue(kit.ToString().Contains(item.ToString()));
        }

        [Test]
        public override void EqualOperator_Test()
        {
            Kit kit1 = new Kit();
            Kit kit2 = new Kit();
            Assert.IsTrue(kit1 == kit2);

            kit1.getRandomWarehouse();
            Assert.IsFalse(kit1 == kit2);
            
            kit2 = new Kit(kit1);
            Assert.IsTrue(kit1 == kit2);
        }

        [Test]
        public override void NotEqualOperator_Test()
        {
            Kit kit1 = new Kit();
            Kit kit2 = new Kit();
            Assert.IsFalse(kit1 != kit2);
            kit2.id = "kitid";
            Assert.IsTrue(kit1 != kit2);

            kit1.getRandomWarehouse();
            Assert.IsTrue(kit1 != kit2);
            kit2 = new Kit(kit1);
            Assert.IsFalse(kit1 != kit2);
        }

        [Test]
        public override void GetHashCode_Test()
        {
            Kit kit1 = new Kit();
            Kit kit2 = new Kit();
            Assert.AreEqual(kit1.GetHashCode(), kit2.GetHashCode());

            kit1.getRandomWarehouse();
            Assert.AreNotEqual(kit1.GetHashCode(), kit2.GetHashCode());
            
            kit2 = new Kit(kit1);
            Assert.AreEqual(kit1.GetHashCode(), kit2.GetHashCode());
        }

        [Test]
        public override void Exists_Test()
        {
            Kit kit = new Kit();
            int count = 0;
            try { kit.Exists(); }
            catch { count++; }
            Assert.AreEqual(1, count);
        }

        [Test]
        public override void Create_Test()
        {
            Kit kit = new Kit();
            int count = 0;
            try { kit.Create(); }
            catch { count++; }
            Assert.AreEqual(1, count);
        }

        [Test]
        public override void Read_Test()
        {
            Kit kit = new Kit();
            int count = 0;
            try { kit.Read(); }
            catch { count++; }
            Assert.AreEqual(1, count);
        }

        [Test]
        public override void Update_Test()
        {
            Kit kit = new Kit();
            int count = 0;
            try { kit.Update(); }
            catch { count++; }
            Assert.AreEqual(1, count);
        }

        [Test]
        public override void Delete_Test()
        {
            Kit kit = new Kit();
            int count = 0;
            try { kit.Delete(); }
            catch { count++; }
            Assert.AreEqual(1, count);
        }
    }
}
*/