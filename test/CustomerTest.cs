using System;
using Utilities.Debugger;
using Databases;
using Warehouse;
using NUnit.Framework;

namespace WarehouseTest
{
    [TestFixture]
    [Ignore("Ignoring CustomerTest ...")]
    public class CustomerTest : WarehouseDataTest
    {
        private Database _abecasDatabase = new SqlDatabase("abecas_practice", "wfsapp02");

        public CustomerTest()
        {
            //turn on debugging
            Debug.DebugMode = true;
            Debug.StepMode  = true;
        }

        [Test]
        public override void getRandomWarehouse_Test()
        {
            Customer customer = new Customer();
            customer.getRandomWarehouse();
            base.getRandomWarehouse_Test(customer);
            Assert.IsNotNullOrEmpty(customer.address);
            Assert.IsNotNullOrEmpty(customer.address1);
            Assert.IsNotNullOrEmpty(customer.address2); //not guaranteed to have a value
            Assert.IsNotNullOrEmpty(customer.address3); //not guaranteed to have a value
            Assert.IsNotNullOrEmpty(customer.businessname); //not guaranteed to have a value
            Assert.IsNotNullOrEmpty(customer.city);
            Assert.IsNotNullOrEmpty(customer.country);
            Assert.IsNotNullOrEmpty(customer.email); //not guaranteed to have a value
            Assert.IsNotNullOrEmpty(customer.firstname);
            Assert.IsNotNullOrEmpty(customer.lastname);
            Assert.IsNotNullOrEmpty(customer.middlename); //not guaranteed to have a value
            Assert.IsNotNullOrEmpty(customer.name);
            Assert.IsNotNullOrEmpty(customer.phone); //not guaranteed to have a value
            Assert.IsNotNullOrEmpty(customer.phone2);
            Assert.IsNotNullOrEmpty(customer.state);
            Assert.IsNotNullOrEmpty(customer.zipcode);
        }

        [Test]
        public override void Equals_Test()
        {
            Customer customer1 = new Customer();
            Customer customer2 = new Customer();
            base.Equal_TestHelper(customer1, customer2);

            customer1.getRandomWarehouse();
            customer2 = new Customer();
            Assert.AreNotEqual(customer1, customer2);
            customer2.id = customer1.id;
            Assert.AreNotEqual(customer1, customer2);
            customer2.address1 = customer1.address1;
            Assert.AreNotEqual(customer1, customer2);
            customer2.address2 = customer1.address2;
            Assert.AreNotEqual(customer1, customer2);
            customer2.address3 = customer1.address3;
            Assert.AreNotEqual(customer1, customer2);
            customer2.businessname = customer1.businessname;
            Assert.AreNotEqual(customer1, customer2);
            customer2.city = customer1.city;
            Assert.AreNotEqual(customer1, customer2);
            customer2.country = customer1.country;
            Assert.AreNotEqual(customer1, customer2);
            customer2.email = customer1.email;
            Assert.AreNotEqual(customer1, customer2);
            customer2.firstname = customer1.firstname;
            Assert.AreNotEqual(customer1, customer2);
            customer2.lastname = customer1.lastname;
            Assert.AreNotEqual(customer1, customer2);
            customer2.middlename = customer1.middlename;
            Assert.AreNotEqual(customer1, customer2);
            customer2.phone = customer1.phone;
            Assert.AreNotEqual(customer1, customer2);
            customer2.phone2 = customer1.phone2;
            Assert.AreNotEqual(customer1, customer2);
            customer2.state = customer1.state;
            Assert.AreNotEqual(customer1, customer2);
            customer2.zipcode = customer1.zipcode;

            base.Equal_TestHelper(customer1, customer2);
            
            customer2.address = customer1.address;
            base.Equal_TestHelper(customer1, customer2);
        }

        [Test]
        public override void Copy_Test()
        {
            _warehouse = new Customer();
            base.Copy_TestHelper();

            _warehouse.getRandomWarehouse();
            base.Copy_TestHelper();
        }

        [Test]
        public override void Constructor_Test()
        {
            //test the various types of constructors
            _warehouse = new Customer();
            Customer customer = new Customer();
            Assert.AreNotSame(_warehouse, customer);

            customer = new Customer((Customer) _warehouse);
            Assert.AreNotSame(_warehouse, customer);
            Assert.AreEqual(_warehouse, customer);

            Customer customer2 = new Customer();
            customer = new Customer(customer2);
            Assert.AreNotSame(customer, customer2);
            Assert.AreEqual(customer, customer2);

            customer = new Customer(new Company());
            //customer = new Customer(_abecasDatabase);
        }

        [Test]
        public override void ToString_Test()
        {
            Customer customer = new Customer();
            customer.getRandomWarehouse();
            Assert.IsTrue(customer.ToString().Contains(customer.id));
            Assert.IsTrue(customer.ToString().Contains(customer.address1));
            Assert.IsTrue(customer.ToString().Contains(customer.address2));
            Assert.IsTrue(customer.ToString().Contains(customer.address3));
            Assert.IsTrue(customer.ToString().Contains(customer.businessname));
            Assert.IsTrue(customer.ToString().Contains(customer.city));
            Assert.IsTrue(customer.ToString().Contains(customer.country));
            Assert.IsTrue(customer.ToString().Contains(customer.email));
            Assert.IsTrue(customer.ToString().Contains(customer.firstname));
            Assert.IsTrue(customer.ToString().Contains(customer.lastname));
            Assert.IsTrue(customer.ToString().Contains(customer.middlename));
            Assert.IsTrue(customer.ToString().Contains(customer.name));
            Assert.IsTrue(customer.ToString().Contains(customer.phone));
            Assert.IsTrue(customer.ToString().Contains(customer.phone2));
            Assert.IsTrue(customer.ToString().Contains(customer.state));
            Assert.IsTrue(customer.ToString().Contains(customer.zipcode));
        }

        [Test]
        public override void EqualOperator_Test()
        {
            Customer customer1 = new Customer();
            Customer customer2 = new Customer();
            Assert.IsTrue(customer1 == customer2);

            customer1.getRandomWarehouse();
            Assert.IsFalse(customer1 == customer2);
            
            customer2 = new Customer(customer1);
            Assert.IsTrue(customer1 == customer2);
        }

        [Test]
        public override void NotEqualOperator_Test()
        {
            Customer customer1 = new Customer();
            Customer customer2 = new Customer();
            Assert.IsFalse(customer1 != customer2);
            customer2.id = "customerid";
            Assert.IsTrue(customer1 != customer2);

            customer1.getRandomWarehouse();
            Assert.IsTrue(customer1 != customer2);
            customer2 = new Customer(customer1);
            Assert.IsFalse(customer1 != customer2);
        }

        [Test]
        public override void GetHashCode_Test()
        {
            Customer customer1 = new Customer();
            Customer customer2 = new Customer();
            Assert.AreEqual(customer1.GetHashCode(), customer2.GetHashCode());

            customer1.getRandomWarehouse();
            Assert.AreNotEqual(customer1.GetHashCode(), customer2.GetHashCode());
            
            customer2 = new Customer(customer1);
            Assert.AreEqual(customer1.GetHashCode(), customer2.GetHashCode());
        }

        [Test]
        public override void Exists_Test()
        {
            Customer customer = new Customer();
            int count = 0;
            try { customer.Exists(); }
            catch { count++; }
            Assert.AreEqual(1, count);
        }

        [Test]
        public override void Create_Test()
        {
            Customer customer = new Customer();
            int count = 0;
            try { customer.Create(); }
            catch { count++; }
            Assert.AreEqual(1, count);
        }

        [Test]
        public override void Read_Test()
        {
            Customer customer = new Customer();
            int count = 0;
            try { customer.Read(); }
            catch { count++; }
            Assert.AreEqual(1, count);
        }

        [Test]
        public override void Update_Test()
        {
            Customer customer = new Customer();
            int count = 0;
            try { customer.Update(); }
            catch { count++; }
            Assert.AreEqual(1, count);
        }

        [Test]
        public override void Delete_Test()
        {
            Customer customer = new Customer();
            int count = 0;
            try { customer.Delete(); }
            catch { count++; }
            Assert.AreEqual(1, count);
        }
    }
}
