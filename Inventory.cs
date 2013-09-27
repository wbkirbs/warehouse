using System                      ;
using System.Runtime.Serialization;
using Databases                   ;

namespace Warehouse
{
  /** ****************************************************************************
     * <author>Wayne Bryan</author>
     * <date>September 24, 2010 - 11:10 AM</date>
     * <category>WarehouseData Class</category>
     * <summary>
     *   Provides an interface with order line items.
     * </summary>
     *******************************************************************************/
    [Serializable]
    [DataContract (Name="inventory")]
	public class Inventory : Item
    {
        #region members
        /** All possible locations the item is located in.</value> **/ public virtual Location[] Locations { get; set; }

        //an inventory location
        public new class Location : WarehouseData
        {
            public virtual string Name        { get; set; }//name of the location
            public virtual string Description { get; set; }
            public virtual string Lot         { get; set; }
            public virtual int    Quantity    { get; set; }
            public virtual string SKU         { get; set; }//item sku for the location to be associated with


            public Location() : base()
            {

            }
            public Location(Company company) : base(company)
            {

            }
        }
        #endregion members


        #region constructors
        /** ****************************************************************************
		 * <summary>
         *   Constructor. Just calls parent constructor.
         * </summary>
		 ********************************************************************************/
		public Inventory() : base()
        {

        }

        /** ****************************************************************************
         * <summary>Constructor. Assigns company value.</summary>
         * <param name="company">The company to use for this Warehouse object.</param>
         *******************************************************************************/
        public Inventory(Company company) : base(company)
        {
            
        }

        /** ****************************************************************************
         * <summary>Copy Constructor. Copies InventoryItem member data.</summary>
         * <param name="item">The InventoryItem to copy.</param>
         *******************************************************************************/
        public Inventory(Inventory item) : base(item)
        {
            this.Locations = item.Locations;
        }

        /** ****************************************************************************
         * <summary>Copy Constructor. Copies Inventory member data from parent class.</summary>
         * <param name="inventory">The Inventory to copy.</param>
         *******************************************************************************/
        public Inventory(Item item) : base(item)
        {
            
        }
        #endregion constructors



        #region public methods
        /** ****************************************************************************
		 * <summary>
         *   Used to prints out item settings.
         * </summary>
         * <returns>String of the InventoryItem obejcts data members.</returns>
		 *******************************************************************************/
		public override string ToString()
		{
			string s = base.ToString();
            return s;
		}

        /** ****************************************************************************
		 * <summary>Generates an InventoryItem with random made up data.</summary>
		 *******************************************************************************/
        public override void getRandomWarehouse()
        {
            base.getRandomWarehouse();
        }

        /** ****************************************************************************
		 * <summary>Warehouse must implement object Equals.</summary>
         * <param name="obj">The InventoryItem object to compare to.</param>
         * <returns>True if the InventoryItem member data are equivalent. False otherwise.</returns>
		 *******************************************************************************/
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType()) return false;
            Inventory item = (Inventory) obj;
            if (! base.Equals(item)) return false;
            return true;
        }

        /** ****************************************************************************
		 * <summary>Warehouse must implement GetHashCode.</summary>
         * <returns>Unique hashcode for the InventoryItem object.</returns>
		 *******************************************************************************/
        public override int GetHashCode()
        {
            unchecked {
                return base.GetHashCode();
            }
        }


        /** ****************************************************************************
		 * <summary>Compares two Inventory objects.</summary>
         * <param name="obj">The other Inventory object to compare.</param>
         * <returns>0 if the two objects are identical. -1 if the current object is less than obj. +1 if the currnet object is greater than obj.</returns>
		 *******************************************************************************/
        public override int CompareTo(object obj)
        {
            return base.CompareTo(obj);
        }
		#endregion public methods


        #region CRUD
        /** ****************************************************************************
		 * <summary>
         *   Copies item data into a new InventoryItem object.
         * </summary>
         * <returns>The new InventoryItem object with the same data as the current object.</returns>
		 *******************************************************************************/
		public override WarehouseData Copy()
		{
			Inventory item =(Inventory) base.Copy();
            item.Locations = this.Locations;
            return item;
        }
		
		
		/** ****************************************************************************
		 * <summary>
         *   Implements Exists Method for WarehouseData.
         * </summary>
         * <returns>True if the InventoryItem already exists in the items table. False otherwise.</returns>
		 *******************************************************************************/
		public override bool Exists()
		{
			throw new NotImplementedException( "Warehouse.InventoryItem.Exists not implemented." );
		}
		
        /** ****************************************************************************
		 * <summary>
         *   Implements Create Method for WarehouseData.
         * </summary>
		 *******************************************************************************/
		public override bool Create()
		{
			throw new NotImplementedException( "Warehouse.InventoryItem.Create not implemented." );
		}
		
        /** ****************************************************************************
		 * <summary>
         *   Implements Read Method for WarehouseData.
         * </summary>
		 *******************************************************************************/
		public override bool Read()
		{
			throw new NotImplementedException( "Warehouse.InventoryItem.Read not implemented." );
		}
		
		/** ****************************************************************************
		 * <summary>
         *   Implements Update Method for WarehouseData.
         * </summary>
		 *******************************************************************************/
		public override bool Update()
		{
			throw new NotImplementedException( "Warehouse.InventoryItem.Update not implemented." );
		}
		
        /** ****************************************************************************
		 * <summary>
         *   Implements Delete Method for WarehouseData.
         * </summary>
		 *******************************************************************************/
		public override bool Delete()
		{
			throw new NotImplementedException( "Warehouse.InventoryItem.Delete not implemented." );
		}
        #endregion CRUD
    }
}
