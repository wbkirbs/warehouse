using System;
using Utilities.Debugger;
using Databases;
using Warehouse;
using NUnit.Framework;

namespace WarehouseTest
{
    [TestFixture]
    [Ignore("Ignoring CompanyTest ...")]
    public class CompanyTest : WarehouseDataTest
    {
        private Database _abecasDatabase = new SqlDatabase("abecas_practice", "wfsapp02");

        public CompanyTest()
        {
            //turn on debugging
            Debug.DebugMode = true;
            Debug.StepMode  = true;
        }

        [Test]
        public void CompanyInfoInheritanceTest()
        {
            AbecasCompany company = CompanyFactor.GIGGLE;
            Company company2 = (Company) CompanyFactor.GIGGLE;
        }


        [Test]
        public override void getRandomWarehouse_Test()
        {
            Company company = new Company();
            company.getRandomWarehouse();
            base.getRandomWarehouse_Test(company);
            Assert.IsNotNullOrEmpty(company.CompanyName);
            Assert.IsNotNullOrEmpty(company.Date);
            Assert.IsNotNullOrEmpty(company.SystemName);
            Assert.IsNotNullOrEmpty(company.Time);
            Assert.IsNotNullOrEmpty(company.UserName);
        }

        [Test]
        public override void Equals_Test()
        {
            Company company1 = new Company();
            Company company2 = new Company();
            base.Equal_TestHelper(company1, company2);

            company1.getRandomWarehouse();
            company2 = new Company();
            Assert.AreNotEqual(company1, company2);
            company2.id = company1.id;
            Assert.AreNotEqual(company1, company2);
            company2.setCompanyName(company1.CompanyName);
            Assert.AreNotEqual(company1, company2);
            company2.setDataBase(company1.Database);
            Assert.AreNotEqual(company1, company2);
            company2.setSystemName(company1.SystemName);
            Assert.AreNotEqual(company1, company2);
            company2.setUserName(company1.UserName);

            base.Equal_TestHelper(company1, company2);
        }

        [Test]
        public override void Copy_Test()
        {
            _warehouse = new Company();
            base.Copy_TestHelper();

            _warehouse.getRandomWarehouse();
            base.Copy_TestHelper();
        }

        [Test]
        public override void Constructor_Test()
        {
            //test the various types of constructors
            _warehouse = new Company();
            Company company = new Company();
            Assert.AreNotSame(_warehouse, company);

            company = new Company((Company) _warehouse);
            Assert.AreNotSame(_warehouse, company);
            Assert.AreEqual(_warehouse, company);

            Company company2 = new Company();
            company = new Company(company2);
            Assert.AreNotSame(company, company2);
            Assert.AreEqual(company, company2);

            company = new Company(new Company());
            company = new Company(_abecasDatabase);
        }

        [Test]
        public override void ToString_Test()
        {
            Company company = new Company();
            company.getRandomWarehouse();
            Assert.IsTrue(company.ToString().Contains(company.CompanyName));
            Assert.IsTrue(company.ToString().Contains(company.SystemName));
            Assert.IsTrue(company.ToString().Contains(company.UserName));
        }

        [Test]
        public override void EqualOperator_Test()
        {
            Company company1 = new Company();
            Company company2 = new Company();
            Assert.IsTrue(company1 == company2);

            company1.getRandomWarehouse();
            Assert.IsFalse(company1 == company2);
            
            company2 = new Company(company1);
            Assert.IsTrue(company1 == company2);
        }

        [Test]
        public override void NotEqualOperator_Test()
        {
            Company company1 = new Company();
            Company company2 = new Company();
            Assert.IsFalse(company1 != company2);
            company2.id = "companyid";
            Assert.IsTrue(company1 != company2);

            company1.getRandomWarehouse();
            Assert.IsTrue(company1 != company2);
            company2 = new Company(company1);
            Assert.IsFalse(company1 != company2);
        }

        [Test]
        public override void GetHashCode_Test()
        {
            Company company1 = new Company();
            Company company2 = new Company();
            Assert.AreEqual(company1.GetHashCode(), company2.GetHashCode());

            company1.getRandomWarehouse();
            Assert.AreNotEqual(company1.GetHashCode(), company2.GetHashCode());
            
            company2 = new Company(company1);
            Assert.AreEqual(company1.GetHashCode(), company2.GetHashCode());
        }

        [Test]
        public override void Exists_Test()
        {
            Company company = new Company();
            int count = 0;
            try { company.Exists(); }
            catch { count++; }
            Assert.AreEqual(1, count);
        }

        [Test]
        public override void Create_Test()
        {
            Company company = new Company();
            int count = 0;
            try { company.Create(); }
            catch { count++; }
            Assert.AreEqual(1, count);
        }

        [Test]
        public override void Read_Test()
        {
            Company company = new Company();
            int count = 0;
            try { company.Read(); }
            catch { count++; }
            Assert.AreEqual(1, count);
        }

        [Test]
        public override void Update_Test()
        {
            Company company = new Company();
            int count = 0;
            try { company.Update(); }
            catch { count++; }
            Assert.AreEqual(1, count);
        }

        [Test]
        public override void Delete_Test()
        {
            Company company = new Company();
            int count = 0;
            try { company.Delete(); }
            catch { count++; }
            Assert.AreEqual(1, count);
        }
    }
}
