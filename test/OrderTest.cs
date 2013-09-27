/*using System;
using Utilities.Debugger;
using Databases;
using Warehouse;
using NUnit.Framework;

namespace WarehouseTest
{
    [TestFixture]
    [Ignore("Ignoring OrderTest ...")]
    public class OrderTest : WarehouseDataTest
    {
        private Database _abecasDatabase = new SqlDatabase("abecas_practice", "wfsapp02");

        public OrderTest()
        {
            //turn on debugging
            Debug.DebugMode = true;
            Debug.StepMode  = true;
        }

        [Test]
        public override void getRandomWarehouse_Test()
        {
            Order order = new Order();
            order.getRandomWarehouse();
            base.getRandomWarehouse_Test(order);
            Assert.IsNotNullOrEmpty(order.altid);
            Assert.IsNotNull(order.billto);
            Assert.IsNotNull(order.discount);
            Assert.IsNotNullOrEmpty(order.giftMessage);
            Assert.IsNotNull(order.items);
            Assert.IsNotNull(order.orderDate);
            Assert.IsNotNullOrEmpty(order.orderNumber);
            Assert.IsNotNullOrEmpty(order.pickticketNumber);
            Assert.IsNotNullOrEmpty(order.promotionCode);
            Assert.IsNotNull(order.shipDate);
            Assert.IsNotNullOrEmpty(order.shipMethod);
            Assert.IsNotNull(order.shippingCost);
            Assert.IsNotNull(order.shipto);
            Assert.IsNotNullOrEmpty(order.sourceCode);
            Assert.IsNotNull(order.subtotal);
            Assert.IsNotNull(order.tax);
            Assert.IsNotNull(order.total);
            Assert.IsNotNull(order.TotalItemPrice);
            Assert.IsNotNull(order.TotalItemQuantity);
            //Assert.IsNotNullOrEmpty(order.trackingNumber);
        }

        [Test]
        public override void Equals_Test()
        {
            Order order1 = new Order();
            Order order2 = new Order();
            base.Equal_TestHelper(order1, order2);

            order1.getRandomWarehouse();
            order2 = new Order();
            Assert.AreNotEqual(order1, order2);
            order2.id = order1.id;
            Assert.AreNotEqual(order1, order2);
            order2.altid = order1.altid;
            Assert.AreNotEqual(order1, order2);
            order2.billto = new Customer(order1.billto);
            Assert.AreNotEqual(order1, order2);
            order2.discount = order1.discount;
            Assert.AreNotEqual(order1, order2);
            order2.giftMessage = order1.giftMessage;
            Assert.AreNotEqual(order1, order2);
            order2.orderDate = order1.orderDate;
            Assert.AreNotEqual(order1, order2);
            order2.orderNumber = order1.orderNumber;
            Assert.AreNotEqual(order1, order2);
            order2.pickticketNumber = order1.pickticketNumber;
            Assert.AreNotEqual(order1, order2);
            order2.promotionCode = order1.promotionCode;
            Assert.AreNotEqual(order1, order2);
            order2.shipDate = order1.shipDate;
            Assert.AreNotEqual(order1, order2);
            order2.shipMethod = order1.shipMethod;
            Assert.AreNotEqual(order1, order2);
            order2.shippingCost = order1.shippingCost;
            Assert.AreNotEqual(order1, order2);
            order2.shipto = new Customer(order1.shipto);
            Assert.AreNotEqual(order1, order2);
            order2.sourceCode = order1.sourceCode;
            Assert.AreNotEqual(order1, order2);
            order2.subtotal = order1.subtotal;
            Assert.AreNotEqual(order1, order2);
            order2.tax = order1.tax;
            Assert.AreNotEqual(order1, order2);
            order2.total = order1.total;
            Assert.AreNotEqual(order1, order2);
            //order2.trackingNumber = order1.trackingNumber;
            //Assert.AreNotEqual(order1, order2);

            order2.items = new Item[order1.items.Length];
            for (int i = 0; i < order1.items.Length; i++) order2.items[i] = new Item(order1.items[i]);
            
            base.Equal_TestHelper(order1, order2);
        }

        [Test]
        public override void Copy_Test()
        {
            _warehouse = new Order();
            base.Copy_TestHelper();

            _warehouse.getRandomWarehouse();
            base.Copy_TestHelper();
        }

        [Test]
        public override void Constructor_Test()
        {
            //test the various types of constructors
            _warehouse = new Order();
            Order order = new Order();
            Assert.AreNotSame(_warehouse, order);

            order = new Order((Order) _warehouse);
            Assert.AreNotSame(_warehouse, order);
            Assert.AreEqual(_warehouse, order);

            Order order2 = new Order();
            order = new Order(order2);
            Assert.AreNotSame(order, order2);
            Assert.AreEqual(order, order2);

            order = new Order(new Company());
            order = new Order(_abecasDatabase);
        }

        [Test]
        public override void ToString_Test()
        {
            Order order = new Order();
            order.getRandomWarehouse();
            
            Assert.IsTrue(order.ToString().Contains(order.id));
            Assert.IsTrue(order.ToString().Contains(order.altid));
            Assert.IsTrue(order.ToString().Contains(order.billto.id.ToString()));
            Assert.IsTrue(order.ToString().Contains(order.discount.ToString()));
            Assert.IsTrue(order.ToString().Contains(order.giftMessage));
            Assert.IsTrue(order.ToString().Contains(order.orderDate.ToString()));
            Assert.IsTrue(order.ToString().Contains(order.orderNumber));
            Assert.IsTrue(order.ToString().Contains(order.pickticketNumber));
            Assert.IsTrue(order.ToString().Contains(order.promotionCode));
            Assert.IsTrue(order.ToString().Contains(order.shipDate.ToString()));
            Assert.IsTrue(order.ToString().Contains(order.shipMethod));
            Assert.IsTrue(order.ToString().Contains(order.shippingCost.ToString()));
            Assert.IsTrue(order.ToString().Contains(order.shipto.id.ToString()));
            Assert.IsTrue(order.ToString().Contains(order.sourceCode));
            Assert.IsTrue(order.ToString().Contains(order.subtotal.ToString()));
            Assert.IsTrue(order.ToString().Contains(order.tax.ToString()));
            Assert.IsTrue(order.ToString().Contains(order.total.ToString()));
            //Assert.IsTrue(order.ToString().Contains(order.TotalItemPrice.ToString()));
            //Assert.IsTrue(order.ToString().Contains(order.TotalItemQuantity.ToString()));
            //Assert.IsTrue(order.ToString().Contains(order.trackingNumber));
            foreach (Item item in order.items) Assert.IsTrue(order.ToString().Contains(item.ToString()));
        }

        [Test]
        public override void EqualOperator_Test()
        {
            Order order1 = new Order();
            Order order2 = new Order();
            Assert.IsTrue(order1 == order2);

            order1.getRandomWarehouse();
            Assert.IsFalse(order1 == order2);
            
            order2 = new Order(order1);
            Assert.IsTrue(order1 == order2);
        }

        [Test]
        public override void NotEqualOperator_Test()
        {
            Order order1 = new Order();
            Order order2 = new Order();
            Assert.IsFalse(order1 != order2);
            order2.id = "orderid";
            Assert.IsTrue(order1 != order2);

            order1.getRandomWarehouse();
            Assert.IsTrue(order1 != order2);
            order2 = new Order(order1);
            Assert.IsFalse(order1 != order2);
        }

        [Test]
        public override void GetHashCode_Test()
        {
            Order order1 = new Order();
            Order order2 = new Order();
            Assert.AreEqual(order1.GetHashCode(), order2.GetHashCode());

            order1.getRandomWarehouse();
            Assert.AreNotEqual(order1.GetHashCode(), order2.GetHashCode());
            
            order2 = new Order(order1);
            Assert.AreEqual(order1.GetHashCode(), order2.GetHashCode());
        }

        [Test]
        public override void Exists_Test()
        {
            Order order = new Order();
            int count = 0;
            try { order.Exists(); }
            catch { count++; }
            Assert.AreEqual(1, count);
        }

        [Test]
        public override void Create_Test()
        {
            Order order = new Order();
            int count = 0;
            try { order.Create(); }
            catch { count++; }
            Assert.AreEqual(1, count);
        }

        [Test]
        public override void Read_Test()
        {
            Order order = new Order();
            int count = 0;
            try { order.Read(); }
            catch { count++; }
            Assert.AreEqual(1, count);
        }

        [Test]
        public override void Update_Test()
        {
            Order order = new Order();
            int count = 0;
            try { order.Update(); }
            catch { count++; }
            Assert.AreEqual(1, count);
        }

        [Test]
        public override void Delete_Test()
        {
            Order order = new Order();
            int count = 0;
            try { order.Delete(); }
            catch { count++; }
            Assert.AreEqual(1, count);
        }
    }
}
*/