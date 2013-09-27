using System;
using System.Collections.Generic;
using Databases;

namespace Warehouse
{
    /** ****************************************************************************
     * <author>Wayne Bryan</author>
     * <date>November 23, 2011 - 1:05 PM</date>
     * <category>Class</category>
     * <summary>
     *   Implements Purchase Order functionality.
     * </summary>
     *******************************************************************************/
    public class PurchaseOrder : WarehouseData
    {
        #region members
        /** <value>The list of items on the po.</value>                 **/ public virtual PurchaseOrderItem [] Items     { get { return _items.ToArray(); } }
        /** <value>Where the po is shipped from.</value>                **/ public virtual Customer          Shipper      { get; set; }
        /** <value>The date the po was created.</value>                 **/ public virtual DateTime          DateCreated  { get; set; }
        /** <value>The date the po was received.</value>                **/ public virtual DateTime          DateReceived { get; set; }
        /** <value>The date the po truck is destined to arrive.</value> **/ public virtual DateTime          DateExpected { get; set; }
        /** <value>Instructions/Comments on the PO.</value>             **/ public virtual string            Comments     { get; set; }
        public virtual int OrderNumber { get; set; }

        private List<PurchaseOrderItem> _items = new List<PurchaseOrderItem>();
        #endregion members


        #region constructors
        /** ****************************************************************************
         * <summary>Constructor. Just calls base class to setup the company.</summary>
         *******************************************************************************/
        public PurchaseOrder() : base()
        {

        }

        /** ****************************************************************************
         * <summary>Copy Constructor. Copies PurchaseOrder member data.</summary>
         * <param name="po">The PurchaseOrder to copy.</param>
         *******************************************************************************/
        public PurchaseOrder(PurchaseOrder po) : base(po)
        {
            if (po.Shipper == null) this.Shipper = null;
            else this.Shipper       = new Customer(po.Shipper);
            this.DateCreated  = po.DateCreated ;
            this.DateReceived = po.DateReceived;
            this.DateExpected = po.DateExpected;

            //copy inventory items
            /*if (po.Items != null)
            {
                this.Items = new PurchaseOrderItem[ po.Items.Length ];
                for (int i = 0; i < po.Items.Length; i++) this.Items[i] = new PurchaseOrderItem(po.Items[i]);
            }*/
        }

        /** ****************************************************************************
         * <summary>Constructor. Assigns company value.</summary>
         * <param name="company">The company to use for this Warehouse object.</param>
         *******************************************************************************/
        public PurchaseOrder(Company company) : base(company)
        {
            
        }
        #endregion constructors


        #region public methods
        /** ****************************************************************************
         * <summary>ToString implementation.</summary>
         * <returns>String representation of all PurchaseOrder members.</returns>
         *******************************************************************************/
        public override string ToString()
        {
            string s = base.ToString();
            string nl = Environment.NewLine;
            s += "Ship To      : ";
            if (this.Shipper == null) s += "null" + nl;
            else s += nl + this.Shipper.ToString()  + nl;
            s += "Date Created : " + this.DateCreated.ToString()  + nl;
            s += "Date Received: " + this.DateReceived.ToString() + nl;
            s += "Date Expected: " + this.DateExpected.ToString() + nl;
            s += "Items        : " + nl;
            if (this.Items != null)
            {
                for (int i = 0; i < this.Items.Length; i++) 
                {
                    if (this.Items[i] == null) s += "NULL";
                    else s += this.Items[i].ToString();
                }
            }
            return s;
        }


        
        /** ****************************************************************************
		 * <summary>Generates a Customer with random made up data.</summary>
		 *******************************************************************************/
        public override void getRandomWarehouse()
        {
            Random random = new Random();
            int poNumber = random.Next(1, 9999);
            this.ID = "Purchase Order #" + poNumber;
            this.DateCreated  = new DateTime(random.Next(2011, 2015), random.Next(1, 12), random.Next(1, 28));
            this.DateReceived = new DateTime(random.Next(2011, 2015), random.Next(1, 12), random.Next(1, 28));
            this.DateExpected = new DateTime(random.Next(2011, 2015), random.Next(1, 12), random.Next(1, 28));
            this.Shipper = new Customer();
            this.Shipper.getRandomWarehouse();
            /*this.Items = new PurchaseOrderItem[random.Next(1, 10)];
            for (int i = 0; i < this.Items.Length; i++)
            {
                this.Items[i] = new PurchaseOrderItem();
                this.Items[i].getRandomWarehouse();
            }*/
        }
        
        /** ****************************************************************************
		 * <summary>Warehouse must implement object Equals.</summary>
         * <param name="obj">The PurchaseOrder object to compare to.</param>
         * <returns>True if the PurchaseOrder member data are equivalent. False otherwise.</returns>
		 *******************************************************************************/
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType().Name != "PurchaseOrder") return false;
            PurchaseOrder po = (PurchaseOrder) obj;
            if (! base.Equals(po)) return false;
            if (this.DateCreated  != po.DateCreated ) return false;
            if (this.DateExpected != po.DateExpected) return false;
            if (this.DateReceived != po.DateReceived) return false;
            if (this.Shipper      != po.Shipper     ) return false;

            if (this.Items  == null && po.Items != null) return false;
            if (po.Items == null && this.Items  != null) return false;
            if (this.Items != null && po.Items != null && this.Items.Length != po.Items.Length) return false;
            if (this.Items != null) {
                for (int i = 0; i < this.Items.Length; i++) {
                    if (this.Items[i] != po.Items[i]) return false;
                }
            }

            return true;
        }

        /** ****************************************************************************
		 * <summary>Warehouse must implement GetHashCode.</summary>
         * <returns>Unique hashcode for the PurchaseOrder object.</returns>
		 *******************************************************************************/
        public override int GetHashCode()
        {
            unchecked {
                int hash = 17 * 23 + base.GetHashCode(); 
                if (this.DateCreated  != null) hash = hash * 23 + this.DateCreated.GetHashCode();
                if (this.DateExpected != null) hash = hash * 23 + this.DateExpected.GetHashCode();
                if (this.DateReceived != null) hash = hash * 23 + this.DateReceived.GetHashCode();
                if (this.Shipper      != null) hash = hash * 23 + this.Shipper.GetHashCode();

                if (this.Items != null) {
                    foreach (PurchaseOrderItem item in this.Items) {
                        hash = hash * 23 + item.GetHashCode();
                    }
                }

                return hash; 
            }
        }
        #endregion public methods


        public void AddItem(PurchaseOrderItem item)
        {
            _items.Add(item);
        }

        #region CRUD
        /** ****************************************************************************
         * <summary>Copies current PurchaseOrder member data and returns a new PurchaseOrder instance.</summary>
         * <returns>An equivalent PurchaseOrder object, as a new object.</returns>
         *******************************************************************************/
        public override WarehouseData Copy()
        {
            PurchaseOrder po = new PurchaseOrder();
            po.ID = this.ID;
            if (this.Shipper == null) po.Shipper = null;
            else po.Shipper = (Customer) this.Shipper.Copy();
            po.DateCreated  = this.DateCreated;
            po.DateReceived = this.DateReceived;
            po.DateExpected = this.DateExpected;

            //copy inventory items
            /*if (this.Items == null) po.Items = null;
            else {
                po.Items = new PurchaseOrderItem[ this.Items.Length ];
                for (int i = 0; i < po.Items.Length; i++) po.Items[i] = (PurchaseOrderItem) this.Items[i].Copy();
            }*/

            return po;
        }

        /** ****************************************************************************
         * <summary>Not implement yet.</summary>
         * <returns>Not implement yet.</returns>
         *******************************************************************************/
        public override bool Exists()
        {
            throw new NotImplementedException("Warehouse.PurchaseOrder.Exists not implemented.");
        }

        /** ****************************************************************************
         * <summary>Not implement yet.</summary>
         * <returns>Not implement yet.</returns>
         *******************************************************************************/
        public override bool Create()
        {
            throw new NotImplementedException("Warehouse.PurchaseOrder.Create not implemented.");
        }

        /** ****************************************************************************
         * <summary>Not implement yet.</summary>
         * <returns>Not implement yet.</returns>
         *******************************************************************************/
        public override bool Read()
        {
            throw new NotImplementedException("Warehouse.PurchaseOrder.Read not implemented.");
        }

        /** ****************************************************************************
		 * <summary>Implements ReadAll Method for WarehouseData.</summary>
         * <returns>Not implemented yet.</returns>
		 *******************************************************************************/
		public override WarehouseData[] ReadAll()
		{
			throw new NotImplementedException( "Warehouse.PurchaseOrder.ReadAll not implemented." );
		}

        /** ****************************************************************************
         * <summary>Not implement yet.</summary>
         * <returns>Not implement yet.</returns>
         *******************************************************************************/
        public override bool Update()
        {
            throw new NotImplementedException("Warehouse.PurchaseOrder.Update not implemented.");
        }

        /** ****************************************************************************
         * <summary>Not implement yet.</summary>
         * <returns>Not implement yet.</returns>
         *******************************************************************************/
        public override bool Delete()
        {
            throw new NotImplementedException("Warehouse.PurchaseOrder.Delete not implemented.");
        }
        #endregion CRUD
    }
}
