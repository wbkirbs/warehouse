using System;
using Databases;

namespace Warehouse
{
    /** ****************************************************************************
     * <author>Wayne Bryan</author>
     * <date>September 24, 2010 - 11:10 AM</date>
     * <category>WarehouseData Class</category>
     * <summary>
     *   Provides an interfaces with order line items.
     * </summary>
     *******************************************************************************/
	public class PurchaseOrderItem : Item
    {
        #region members
        /** <value>The quantity delivered of the item.</value>            **/  public virtual int     QuantityDelivered   { get; set; }
        /** <value>The quantity applied to the purchase order.</value>    **/  public virtual int     QuantityApplied     { get; set; }
        /** <value>The date the item is expected.</value>                 **/ public virtual DateTime ExpectedDate        { get; set; }
        /** <value>The date the item was received.</value>                **/ public virtual DateTime ReceivedDate        { get; set; }
        /** <value>Indicates whether this item has been received.</value> **/ public virtual bool     Received            { get; set; }
        /** <value>Supplier Sku number.</value>                           **/ public virtual string   SupplierSku         { get; set; }
        /** <value>Supplier Description.</value>                          **/ public virtual string   SupplierDescription { get; set; }
        #endregion members


        #region constructors
        /** ****************************************************************************
		 * <summary>Constructor. Just calls parent constructor.</summary>
		 ********************************************************************************/
		public PurchaseOrderItem() : base()
        {

        }

        /** ****************************************************************************
         * <summary>Constructor. Assigns company value.</summary>
         * <param name="company">The company to use for this Warehouse object.</param>
         *******************************************************************************/
        public PurchaseOrderItem(Company company) : base(company)
        {
            
        }

        /** ****************************************************************************
         * <summary>Copy Constructor. Copies PurchaseOrderItem member data.</summary>
         * <param name="item">The PurchaseOrderItem to copy.</param>
         *******************************************************************************/
        public PurchaseOrderItem(PurchaseOrderItem item) : base(item)
        {
            this.QuantityDelivered   = item.QuantityDelivered  ;
            this.QuantityApplied     = item.QuantityApplied    ;
            this.ExpectedDate        = item.ExpectedDate       ;
            this.ReceivedDate        = item.ReceivedDate       ;
            this.Received            = item.Received           ;
            this.SupplierSku         = item.SupplierSku        ;
            this.SupplierDescription = item.SupplierDescription;
        }

        /** ****************************************************************************
         * <summary>Copy Constructor. Copies Inventory member data from parent class.</summary>
         * <param name="inventory">The Inventory to copy.</param>
         *******************************************************************************/
        public PurchaseOrderItem(Inventory inventory) : base(inventory)
        {
            
        }
        #endregion constructors


        #region public methods
        /** ****************************************************************************
		 * <summary>
         *   Used to prints out item settings.
         * </summary>
         * <returns>String of the PurchaseOrderItem object data members.</returns>
		 *******************************************************************************/
		public override string ToString()
		{
			string s = base.ToString();
            s += "Qty Delivered: " + this.QuantityDelivered   + "\n";
            s += "  Qty Applied: " + this.QuantityApplied     + "\n";
			s += "     Received: " + this.Received.ToString() + "\n";
            s += " Supplier Sku: " + this.SupplierSku         + "\n";
			s += "Expected Date: " + this.ExpectedDate        + "\n";
            return s;
		}

        /** ****************************************************************************
		 * <summary>Generates an PurchaseOrderItem with random made up data.</summary>
		 *******************************************************************************/
        public override void getRandomWarehouse()
        {
            base.getRandomWarehouse();
        }

        /** ****************************************************************************
		 * <summary>Warehouse must implement object Equals.</summary>
         * <param name="obj">The PurchaseOrderItem object to compare to.</param>
         * <returns>True if the PurchaseOrderItem member data are equivalent. False otherwise.</returns>
		 *******************************************************************************/
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType()) return false;
            PurchaseOrderItem item = (PurchaseOrderItem) obj;
            if (! base.Equals(item)) return false;
            return true;
        }

        /** ****************************************************************************
		 * <summary>Compares two Warehouse objects to see if they are less than, equal, or great than one another. This is used for sorting objects.</summary>
         * <param name="warehouse">The object to compare to.</param>
         * <returns>0 if the two objects are identical. -1 if the current object is less than obj. +1 if the currnet object is greater than obj.</returns>
		 *******************************************************************************/
        public override int CompareTo(object warehouse)
        {
            return base.CompareTo(warehouse);
        }

        /** ****************************************************************************
		 * <summary>Warehouse must implement GetHashCode.</summary>
         * <returns>Unique hashcode for the PurchaseOrderItem object.</returns>
		 *******************************************************************************/
        public override int GetHashCode()
        {
            unchecked {
                return base.GetHashCode();
            }
        }
		#endregion public methods


        #region CRUD
        /** ****************************************************************************
		 * <summary>
         *   Copies item data into a new PurchaseOrderItem object.
         * </summary>
         * <returns>The new PurchaseOrderItem object with the same data as the current object.</returns>
		 *******************************************************************************/
		public override WarehouseData Copy()
		{
			PurchaseOrderItem item = (PurchaseOrderItem) base.Copy();
			
            return item;
        }
		
		
		/** ****************************************************************************
		 * <summary>
         *   Implements Exists Method for WarehouseData.
         * </summary>
         * <returns>True if the PurchaseOrderItem already exists in the items table. False otherwise.</returns>
		 *******************************************************************************/
		public override bool Exists()
		{
			throw new NotImplementedException( "Warehouse.PurchaseOrderItem.Exists not implemented." );
		}
		
        /** ****************************************************************************
		 * <summary>
         *   Implements Create Method for WarehouseData.
         * </summary>
		 *******************************************************************************/
		public override bool Create()
		{
			throw new NotImplementedException( "Warehouse.PurchaseOrderItem.Create not implemented." );
		}
		
        /** ****************************************************************************
		 * <summary>
         *   Implements Read Method for WarehouseData.
         * </summary>
		 *******************************************************************************/
		public override bool Read()
		{
			throw new NotImplementedException( "Warehouse.PurchaseOrderItem.Read not implemented." );
		}
		
		/** ****************************************************************************
		 * <summary>
         *   Implements Update Method for WarehouseData.
         * </summary>
		 *******************************************************************************/
		public override bool Update()
		{
			throw new NotImplementedException( "Warehouse.PurchaseOrderItem.Update not implemented." );
		}
		
        /** ****************************************************************************
		 * <summary>
         *   Implements Delete Method for WarehouseData.
         * </summary>
		 *******************************************************************************/
		public override bool Delete()
		{
			throw new NotImplementedException( "Warehouse.PurchaseOrderItem.Delete not implemented." );
		}
        #endregion CRUD
    }
}
