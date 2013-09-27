using System                      ;
using System.Runtime.Serialization;
using System.Xml.Serialization    ;
using Databases                   ;

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
    [Serializable]
    [DataContract (Name="item")]
	public class OrderItem : Warehouse.Item
    {
        #region members
        [DataMember(Name="sales_price")]
        [XmlElement(ElementName="sales_price")]
        /** <value>The sales price of the item. Alias to price.</value> **/ public virtual double SalesPrice { get; set; }
        #endregion members


        #region constructors
        /** ****************************************************************************
		 * <summary>
         *   Constructor. Just calls parent constructor.
         * </summary>
		 ********************************************************************************/
		public OrderItem() : base()
        {

        }

        /** ****************************************************************************
         * <summary>Constructor. Assigns company value.</summary>
         * <param name="company">The company to use for this Warehouse object.</param>
         *******************************************************************************/
        public OrderItem(Company company) : base(company)
        {
            
        }

        /** ****************************************************************************
         * <summary>Copy Constructor. Copies OrderItem member data.</summary>
         * <param name="item">The OrderItem to copy.</param>
         *******************************************************************************/
        public OrderItem(WarehouseData item) : base(item)
        {
            this.SalesPrice = ((OrderItem) item).SalesPrice;
        }

        /** ****************************************************************************
         * <summary>Copy Constructor. Copies Inventory member data from parent class.</summary>
         * <param name="inventory">The Inventory to copy.</param>
         *******************************************************************************/
        public OrderItem(Inventory inventory) : base(inventory)
        {
            
        }
        #endregion constructors



        #region public methods
        /** ****************************************************************************
		 * <summary>
         *   Used to prints out item settings.
         * </summary>
         * <returns>String of the OrderItem obejcts data members.</returns>
		 *******************************************************************************/
		public override string ToString()
		{
			string s = base.ToString();
            s += "Sales Price: " + this.SalesPrice + "\n";
            return s;
		}


        /** ****************************************************************************
		 * <summary>Warehouse must implement object Equals.</summary>
         * <param name="obj">The OrderItem object to compare to.</param>
         * <returns>True if the OrderItem member data are equivalent. False otherwise.</returns>
		 *******************************************************************************/
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType()) return false;
            OrderItem item = (OrderItem) obj;
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
         * <returns>Unique hashcode for the OrderItem object.</returns>
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
         *   Copies item data into a new OrderItem object.
         * </summary>
         * <returns>The new OrderItem object with the same data as the current object.</returns>
		 *******************************************************************************/
		public override WarehouseData Copy()
		{
			OrderItem item = (OrderItem) base.Copy();
            return item;
        }
		
		
		/** ****************************************************************************
		 * <summary>
         *   Implements Exists Method for WarehouseData.
         * </summary>
         * <returns>True if the OrderItem already exists in the items table. False otherwise.</returns>
		 *******************************************************************************/
		public override bool Exists()
		{
			throw new NotImplementedException( "Warehouse.OrderItem.Exists not implemented." );
		}
		
        /** ****************************************************************************
		 * <summary>
         *   Implements Create Method for WarehouseData.
         * </summary>
		 *******************************************************************************/
		public override bool Create()
		{
			throw new NotImplementedException( "Warehouse.OrderItem.Create not implemented." );
		}
		
        /** ****************************************************************************
		 * <summary>
         *   Implements Read Method for WarehouseData.
         * </summary>
		 *******************************************************************************/
		public override bool Read()
		{
			throw new NotImplementedException( "Warehouse.OrderItem.Read not implemented." );
		}
		
		/** ****************************************************************************
		 * <summary>
         *   Implements Update Method for WarehouseData.
         * </summary>
		 *******************************************************************************/
		public override bool Update()
		{
			throw new NotImplementedException( "Warehouse.OrderItem.Update not implemented." );
		}
		
        /** ****************************************************************************
		 * <summary>
         *   Implements Delete Method for WarehouseData.
         * </summary>
		 *******************************************************************************/
		public override bool Delete()
		{
			throw new NotImplementedException( "Warehouse.OrderItem.Delete not implemented." );
		}
        #endregion CRUD
    }
}
