using System                      ;
using System.Runtime.Serialization;
using System.Collections          ;
using System.Collections.Generic  ;
using Databases                   ;

namespace Warehouse
{
    /** ****************************************************************************
     * <author>Wayne Bryan</author>
     * <date>September 21, 2010 - 3:51 PM</date>
     * <category>WarehouseData Class</category>
     * <summary>
     *   Provides an interfaces to orders.
     * </summary>
     *******************************************************************************/
    [Serializable]
    [DataContract (Name="order")]
	public class Order : WarehouseData
    {
        #region members
        /** <value>The order id number for this transaction. Alias of id.</value>  **/ [DataMember(Name = "order_number")] public virtual string   OrderNumber      { get; set; }
        public virtual Shipment[] Shipments { get { return _shipments.ToArray(); } }
        public virtual Price Price { get; set; }
        /** <value>The Total value before shipping, Tax, etc. are applied.</value> **/ public virtual double   SubTotal         { get; set; }
        /** <value>A discount amount for the order</value>                         **/ public virtual double   Discount         { get; set; }
        /** <value>The shipping cost for shipping this order.</value>              **/ public virtual double   ShippingCost     { get; set; }
        /** <value>The Tax associated with this order.</value>                     **/ public virtual double   Tax              { get; set; }
        /** <value>The final Total amount on the order.</value>                    **/ public virtual double   Total            { get; set; }
        /** <value>A gift message the customer can enter for the order</value>     **/ [DataMember(Name = "gift_message")] public virtual string   GiftMessage      { get; set; }
        /** <value>A source code to track this order.</value>                      **/ public virtual string   SourceCode       { get; set; }
        /** <value>The date the order was "placed".</value>                        **/ public virtual DateTime OrderDate        { get; set; }
        public virtual Payment[] Payments { get; set; }
        [IgnoreDataMember] public virtual Status OrderStatus { 
            get { if (_orderStatus == "PROCESSING") return Status.PROCESSING; else return Status.NONE; }
            set { _orderStatus = value.ToString(); }
        }
        [DataMember(Name = "items")] public virtual OrderItem[] Items { get; set; } 
            
        public enum Status { PROCESSING, NONE }
        private List<Shipment> _shipments = new List<Shipment>();
        protected string _orderStatus;

        public virtual Customer ShipTo { get; set; }
        public virtual Customer BillTo { get; set; }

        #endregion members


        #region constructors
        /** ****************************************************************************
		 * <summary>Constructor. Call parent constructor.</summary>
		 *******************************************************************************/
		public Order() : base()
        {
            
        }

        /** ****************************************************************************
         * <summary>Copy Constructor. Copies Order member data.</summary>
         * <param name="order">The Order to copy.</param>
         *******************************************************************************/
        public Order(WarehouseData data) : base(data)
        {
            Order order = (Order) data;
            this.ID          = order.ID;
			this.OrderNumber = order.OrderNumber;
            
            _shipments = new List<Shipment>();
            _shipments.AddRange(order.Shipments);
        }

        /** ****************************************************************************
         * <summary>Constructor. Assigns company value.</summary>
         * <param name="company">The company to use for this Warehouse object.</param>
         *******************************************************************************/
        public Order(Company company) : base(company)
        {
            
        }
        #endregion constructors


        #region public methods
        public void AddShipment(params Shipment[] shipments)
        {
            _shipments.AddRange(shipments);
        }

        /** ****************************************************************************
		 * <summary>Used to prints out order settings.</summary>
         * <returns>String of the Order obejcts data members.</returns>
		 *******************************************************************************/
		public override string ToString()
		{
            string s = "";
			s += "Order Number  : " + this.OrderNumber          + "\n";
            return s;
		}
		
        /** ****************************************************************************
		 * <summary>Warehouse must implement object Equals.</summary>
         * <param name="obj">The Order object to compare to.</param>
         * <returns>True if the Order member data are equivalent. False otherwise.</returns>
		 *******************************************************************************/
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType().Name != "Order") return false;
            Order order = (Order) obj;
            if (! base.Equals(order)) return false;
            if (this.OrderNumber != order.OrderNumber) return false;
            return true;
        }


        /** ****************************************************************************
		 * <summary>Warehouse must implement GetHashCode.</summary>
         * <returns>Unique hashcode for the Order object.</returns>
		 *******************************************************************************/
        public override int GetHashCode()
        {
            unchecked {
                int hash = 17 * 23 + base.GetHashCode(); 
                if (this.OrderNumber != null) hash = hash * 23 + this.OrderNumber.GetHashCode();
                
                return hash; 
            }
        }

        /** ****************************************************************************
		 * <summary>
         *   Copies random order data into an Order object.
         * </summary>
		 *******************************************************************************/
        public override void getRandomWarehouse()
        {
            Random r = new Random();

            // get random order number(s)
            this.OrderNumber = r.Next( 1000, 99999 ).ToString();
        }
        #endregion public methods


        #region CRUD
        /** ****************************************************************************
		 * <summary>
         *   Copies order data into a new Order object.
         * </summary>
         * <returns>The new Order object with the same data as the current object.</returns>
		 *******************************************************************************/
		public override WarehouseData Copy()
		{
			Order o = new Order();
		
            o.ID               = this.ID;
			o.OrderNumber      = this.OrderNumber;
            
            return o;
        }

        /** ****************************************************************************
		 * <summary>
         *   Implements Exists Method for WarehouseData.
         * </summary>
		 *******************************************************************************/
		public override bool Exists()
		{
			throw new NotImplementedException( "Warehouse.Order.Exists not implemented." );
		}
		
		/** ****************************************************************************
		 * <summary>
         *   Implements Create Method for WarehouseData.
         * </summary>
		 *******************************************************************************/
		public override bool Create()
		{
			throw new NotImplementedException( "Warehouse.Order.Create not implemented." );
		}
		
        /** ****************************************************************************
		 * <summary>
         *   Implements Read Method for WarehouseData.
         * </summary>
		 *******************************************************************************/
		public override bool Read()
		{
			throw new NotImplementedException( "Warehouse.Order.Read not implemented." );
		}

        /** ****************************************************************************
		 * <summary>Implements ReadAll Method for WarehouseData.</summary>
         * <returns>Not implemented yet.</returns>
		 *******************************************************************************/
		public override WarehouseData[] ReadAll()
		{
			throw new NotImplementedException( "Warehouse.Order.ReadAll not implemented." );
		}
		
        /** ****************************************************************************
		 * <summary>
         *   Implements Update Method for WarehouseData.
         * </summary>
		 *******************************************************************************/
		public override bool Update()
		{
			throw new NotImplementedException( "Warehouse.Order.Update not implemented." );
		}
		
        /** ****************************************************************************
		 * <summary>
         *   Implements Delete Method for WarehouseData.
         * </summary>
		 *******************************************************************************/
		public override bool Delete()
		{
			throw new NotImplementedException( "Warehouse.Order.Delete not implemented." );
        }
        #endregion CRUD
    }
}
