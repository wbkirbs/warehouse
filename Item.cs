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
     *   Provides an interfaces with items.
     * </summary>
     *******************************************************************************/
    [Serializable]
    [DataContract (Name="item")]
	public class Item : WarehouseData, IComparable
    {
        #region members
        [IgnoreDataMember]
        public override string LinkID {
            get { return this.BoxID ; }
            set { this.BoxID = value; }
        }

        //the link to the box
        [DataMember(Name="box_id")]
        [XmlElement(ElementName="box_id")]
        public virtual string BoxID       { get; set; }

        //the link to the order
        [DataMember(Name="order_id")]
        [XmlElement(ElementName="order_id")]
        public virtual string OrderID       { get; set; }


        /** <value>Representation of the inventory object.</value> **/
        [IgnoreDataMember]
        public virtual Inventory Inventory {
            get { 
                if (_inventory == null) {
                    _inventory = new Inventory(this.Company);
                    _inventory.SKU = this.SKU;
                    _inventory.UPC = this.UPC;
                }
                return _inventory; 
            }
        }
        /** <value>The item sku.</value>                                           **/ 
        [DataMember(Name="sku")]
        [XmlElement(ElementName="sku")]
        public virtual string   SKU                 { get; set; }

        /** <value>The upc of an item.</value>                                     **/ 
        [DataMember(Name="upc")]
        [XmlElement(ElementName="upc")]
        public virtual string   UPC                 { get; set; }

        /** <value>The ISBN code of the item.</value>                              **/ 
        [DataMember(Name="isbn")]
        [XmlElement(ElementName="isbn")]
        public virtual string   ISBN                { get; set; }

        /** <value>A description of the item.</value>                              **/ 
        [DataMember(Name="description")]
        [XmlElement(ElementName="description")]
        public virtual string   Description         { get; set; }

        /** <value>Additional description of the item.</value>                     **/ 
        [DataMember(Name="description_2")]
        [XmlElement(ElementName="description_2")]
        public virtual string   Description2        { get; set; }

        /** <value>The quantity of the item.</value>                               **/ 
        [DataMember(Name="quantity")]
        [XmlElement(ElementName="quantity")]
        public virtual int      Quantity            { get; set; }

        /** <value>The price of the item.</value>                                  **/ 
        [DataMember(Name="price")]
        [XmlElement(ElementName="price")]
        public virtual double   Price               { get; set; }

        /** <value>The unit cost of the item.</value>                              **/ 
        [DataMember(Name="unit_cost")]
        [XmlElement(ElementName="unit_cost")]
        public virtual double   UnitCost            { get; set; }

        /** <value>The discount applied to the item.</value>                       **/ 
        [DataMember(Name="discount")]
        [XmlElement(ElementName="discount")]
        public virtual double   Discount            { get; set; }

        /** <value>The tax associated with this order.</value>                     **/ 
        [DataMember(Name="tax")]
        [XmlElement(ElementName="tax")]
        public virtual double   Tax                 { get; set; }

        /** <value>The shipping cost for shipping this order.</value>              **/ 
        [DataMember(Name="shipping_cost")]
        [XmlElement(ElementName="shipping_cost")]
        public virtual double   ShippingCost        { get; set; }

        /** <value>The total value before shipping, tax, etc. are applied.</value> **/ 
        [DataMember(Name="subtotal")]
        [XmlElement(ElementName="subtotal")]
        public virtual double   Subtotal            { get; set; }

        /** <value>The total cost of item qty, price, discount.</value>            **/ 
        [DataMember(Name="total")]
        [XmlElement(ElementName="total")]
        public virtual double   Total               { 
            get { if (_total != 0) return _total; else return this.Subtotal + this.ShippingCost + this.Tax + this.Discount; }
            set { _total = value; }
        }

        /** <value>List of serial numbers for an item.</value>                     **/ 
        [IgnoreDataMember]
        public virtual string[] SerialNumbers       { get { return _serialNumbers; } set { _serialNumbers = value; } }

        /** <value>The weight of the item.</value>                                 **/ 
        [DataMember(Name="weight")]
        [XmlElement(ElementName="weight")]
        public virtual double   Weight              { get; set; }
        
        /** <value>The width of the item.</value>                                  **/ 
        [DataMember(Name="width")]
        [XmlElement(ElementName="width")]
        public virtual double   Width               { get; set; }

        /** <value>The length of the item.</value>                                 **/ 
        [DataMember(Name="length")]
        [XmlElement(ElementName="length")]
        public virtual double   Length              { get; set; }

        /** <value>The height of the item.</value>                                 **/ 
        [DataMember(Name="height")]
        [XmlElement(ElementName="height")]
        public virtual double   Height              { get; set; }

        /** <value>The item volume.</value>                                        **/ 
        [DataMember(Name="volume")]
        [XmlElement(ElementName="volume")]
        public virtual double   Volume              { 
            get { if (_volume != 0) return _volume; else return this.Width * this.Height * this.Length; } 
            set { _volume = value; } 
        }

        /** <value>Special instructions for the item.</value>                      **/ 
        [DataMember(Name="instructions")]
        [XmlElement(ElementName="instructions")]
        public virtual string   Instructions        { get; set; }

        /** <value>Current quantity on order for this inventory ritem.</value>     **/ 
        [DataMember(Name="quantity_ordered")]
        [XmlElement(ElementName="quantity_ordered")]
        public virtual int      QuantityOrdered     { get; set; }

        /** <value>Current quantity pending for this inventory item.</value>       **/ 
        [DataMember(Name="quantity_pending")]
        [XmlElement(ElementName="quantity_pending")]
        public virtual int      QuantityPending     { get; set; }

        /** <value>Current quantity available to ship.</value>                     **/ 
        [DataMember(Name="quantity_ready_to_ship")]
        [XmlElement(ElementName="quantity_ready_to_ship")]
        public virtual int      QuantityReadyToShip { get; set; }

        /** <value>Current quantity on backorder for this inventory item.</value>  **/ 
        [DataMember(Name="quantity_backordered")]
        [XmlElement(ElementName="quantity_backordered")]
        public virtual int      QuantityBackOrdered { get; set; }

        /** <value>Current quantity committed for this inventory item.</value>     **/ 
        [DataMember(Name="quantity_shipped")]
        [XmlElement(ElementName="quantity_shipped")]
        public virtual int      QuantityShipped     { get; set; }

        /** <value>The quantity cancelled of the item.</value>                     **/ 
        [DataMember(Name="quantity_cancelled")]
        [XmlElement(ElementName="quantity_cancelled")]
        public virtual int     QuantityCancelled   { get; set; }

        /** <value>The quantity fulfilled of the item.</value>                     **/ 
        [DataMember(Name="quantity_filled")]
        [XmlElement(ElementName="quantity_filled")]
        public virtual int      QuantityFilled      { get; set; }

        /** <value>The items unit of measure.</value>                              **/ 
        [DataMember(Name="unit_of_measure")]
        [XmlElement(ElementName="unit_of_measure")]
        public virtual string   UnitOfMeasure       { get; set; }

        /** <value>Indicates whether this item is oversized.</value>               **/ 
        [DataMember(Name="oversize")]
        [XmlElement(ElementName="oversize")]
        public virtual bool     Oversize            { get; set; }

        /** <value>A color code describing the item.</value>                       **/ 
        [DataMember(Name="color_code")]
        [XmlElement(ElementName="color_code")]
        public virtual string   ColorCode           { get; set; }

        /** <value>The color description of the item.</value>                      **/ 
        [DataMember(Name="color")]
        [XmlElement(ElementName="color")]
        public virtual string   Color               { get; set; }

        /** <value>A color description describing the item.</value>                **/ 
        [DataMember(Name="color_description")]
        [XmlElement(ElementName="color_description")]
        public virtual string   ColorDescription    { get; set; }

        /** <value>A size code desribing the item.</value>                         **/ 
        [DataMember(Name="size_code")]
        [XmlElement(ElementName="size_code")]
        public virtual string   SizeCode            { get; set; }

        /** <value>The size describing the item.</value>                           **/ 
        [DataMember(Name="size")]
        [XmlElement(ElementName="size")]
        public virtual string   Size                { get; set; }

        /** <value>A size description for the item.</value>                        **/ 
        [DataMember(Name="size_description")]
        [XmlElement(ElementName="size_description")]
        public virtual string   SizeDescription     { get; set; }

        /** <value>A department code describing the item.</value>                  **/ 
        [DataMember(Name="department_code")]
        [XmlElement(ElementName="department_code")]
        public virtual string   DepartmentCode      { get; set; }

        /** <value>The style associated with this item.</value>                    **/ 
        [DataMember(Name="style")]
        [XmlElement(ElementName="style")]
        public virtual string   Style               { get; set; }

        /** <value>The date this item should be shipped.</value>                   **/ 
        [DataMember(Name="ship_date")]
        [XmlElement(ElementName="ship_date")]
        public virtual DateTime ShipDate            { get; set; }

        /** <value>Indicates whether this item should be gift wrapped.</value>     **/ 
        [DataMember(Name="gift_wrap")]
        [XmlElement(ElementName="gift_wrap")]
        public virtual bool     GiftWrap            { get; set; }

        /** <value>A gift message the customer can enter for this item.</value>    **/ 
        [DataMember(Name="gift_message")]
        [XmlElement(ElementName="gift_message")]
        public virtual string   GiftMessage         { get; set; }

        /** <value>Indicates whether item is part of a continuity order.</value>   **/ 
        [DataMember(Name="continuity")]
        [XmlElement(ElementName="continuity")]
        public virtual bool     Continuity          { get; set; }

        [DataMember(Name="shipment_number")]
        [XmlElement(ElementName="shipment_number")]
        public string ShipmentNumber { get; set; }

        [DataMember(Name="order_number")]
        [XmlElement(ElementName="order_number")]
        public string OrderNumber    { get; set; }

        [DataMember(Name="line_number")]
        [XmlElement(ElementName="line_number")]
        public int    LineNumber     { get; set; }

        [IgnoreDataMember]
        public virtual Inventory.Location Location { get; set; }

        [IgnoreDataMember]
        public Status ItemStatus     { get; set; }
        public enum Status { ReadyToShip, Shipping, Shipped, BackOrdered, Pending, Hold, Return, Exchange, Damaged, NonProduct, Kit, KitBuild, Quote, None };


        private Inventory _inventory     = null;
        private double    _total         = 0;
        private double    _volume        = 0;
        private string[]  _serialNumbers = new string[0];
        #endregion members


        #region constructors
        /** ****************************************************************************
		 * <summary>
         *   Constructor. Just calls parent constructor.
         * </summary>
		 ********************************************************************************/
		public Item() : base()
        {

        }

        /** ****************************************************************************
         * <summary>Constructor. Assigns company value.</summary>
         * <param name="company">The company to use for this Warehouse object.</param>
         *******************************************************************************/
        public Item(Company company) : base(company)
        {
            
        }

        /** ****************************************************************************
         * <summary>Copy Constructor. Copies Item member data.</summary>
         * <param name="item">The Item to copy.</param>
         *******************************************************************************/
        public Item(WarehouseData item) : base(item)
        {
            this.copyFields((Item) item);
        }

        /** ****************************************************************************
         * <summary>Copy Constructor. Copies Inventory member data from parent class.</summary>
         * <param name="inventory">The Inventory to copy.</param>
         *******************************************************************************/
        public Item(Inventory inventory)
        {
            if (inventory == null) return;
            inventory = new Inventory(inventory);

            this.copyFields(inventory);
        }

        //helper to copy constructors
        private void copyFields(Item item)
        {
            this.Quantity      = item.Quantity     ;
            this.UnitOfMeasure = item.UnitOfMeasure;
            this.Price         = item.Price        ;
            this.Discount      = item.Discount     ;
            this.Total         = item.Total        ;
            this.Oversize      = item.Oversize     ;
            this.Location      = item.Location     ;
            this.Volume        = item.Volume       ;
            this.Weight        = item.Weight       ;
            this.Instructions  = item.Instructions ;
            this.Description   = item.Description  ;
            this.Description2  = item.Description2 ;

        }
        #endregion constructors


        #region public methods
        /** ****************************************************************************
		 * <summary>Warehouse must implement object Equals.</summary>
         * <param name="obj">The Item object to compare to.</param>
         * <returns>True if the Item member data are equivalent. False otherwise.</returns>
		 *******************************************************************************/
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType()) return false;
            Item item = (Item) obj;
            if (! base.Equals(item)) return false;
            if (this.SKU                 != item.SKU                ) return false;
            if (this.Description         != item.Description        ) return false;
            if (this.Quantity            != item.Quantity           ) return false;
            if (this.QuantityShipped     != item.QuantityShipped    ) return false;
            if (this.QuantityPending     != item.QuantityPending    ) return false;
            if (this.QuantityCancelled   != item.QuantityCancelled  ) return false;
            if (this.QuantityFilled      != item.QuantityFilled     ) return false;
            if (this.QuantityBackOrdered != item.QuantityBackOrdered) return false;
            if (this.ShipDate            != item.ShipDate           ) return false;
            if (this.Price               != item.Price              ) return false;
            if (this.Discount            != item.Discount           ) return false;
            if (this.Total               != item.Total              ) return false;
            if (this.GiftMessage         != item.GiftMessage        ) return false;
            if (this.GiftWrap            != item.GiftWrap           ) return false;
            if (this.Continuity          != item.Continuity         ) return false;
            if (this.SerialNumbers       != item.SerialNumbers      ) return false;

            return true;
        }

        /** ****************************************************************************
		 * <summary>Compares two Warehouse objects to see if they are less than, equal, or great than one another. This is used for sorting objects.</summary>
         * <param name="warehouse">The object to compare to.</param>
         * <returns>0 if the two objects are identical. -1 if the current object is less than obj. +1 if the currnet object is greater than obj.</returns>
		 *******************************************************************************/
        public override int CompareTo(object warehouse)
        {
            if (warehouse == null || warehouse.GetType() != this.GetType()) return 0;
            Item item = (Item) warehouse;
            return this.SKU.CompareTo(item.Inventory.SKU);
        }

        /** ****************************************************************************
		 * <summary>Warehouse must implement GetHashCode.</summary>
         * <returns>Unique hashcode for the Item object.</returns>
		 *******************************************************************************/
        public override int GetHashCode()
        {
            unchecked {
                int hash = 17 * 23;// + base.GetHashCode(); 
                if (this.SKU != null) hash = hash * 23 + this.SKU.GetHashCode();
                if (this.Description != null) hash = hash * 23 + this.Description.GetHashCode();
                hash = hash * 23 + this.Quantity.GetHashCode();
                hash = hash * 23 + this.QuantityShipped.GetHashCode();
                hash = hash * 23 + this.QuantityPending.GetHashCode();
                hash = hash * 23 + this.QuantityCancelled.GetHashCode();
                hash = hash * 23 + this.QuantityFilled.GetHashCode();
                hash = hash * 23 + this.QuantityBackOrdered.GetHashCode();
                if (this.ShipDate != null) hash = hash * 23 + this.ShipDate.GetHashCode();
                hash = hash * 23 + this.Price.GetHashCode();
                hash = hash * 23 + this.Discount.GetHashCode();
                hash = hash * 23 + this.Total.GetHashCode();
                hash = hash * 23 + this.GiftWrap.GetHashCode();
                if (this.GiftMessage != null) hash = hash * 23 + this.GiftMessage.GetHashCode();
                hash = hash * 23 + this.Continuity.GetHashCode();
                if (this.Style != null) hash = hash * 23 + this.Style.GetHashCode();
                if (this.Color != null) hash = hash * 23 + this.Color.GetHashCode();
                if (this.Size != null) hash = hash * 23 + this.Size.GetHashCode();
                
                return hash; 
            }
        }

        /** *****************************************************************************
		 * <summary>
         *   Gets the price in a string currency format.
         * </summary>
         * <returns>The price as a currency string.</returns>
		 *******************************************************************************/
		public virtual string getPriceString()
		{
			return String.Format("{0:0.00}", this.Price);
		}
		
        
        /** ****************************************************************************
		 * <summary>
         *   Used to print out item settings.
         * </summary>
         * <returns>String of the Item object data members.</returns>
		 *******************************************************************************/
		public override string ToString()
		{
            string s = base.ToString();
            s += "        SKU: " + this.SKU         + "\n";
            s += "Description: " + this.Description + "\n";
            s += "   Quantity: " + this.Quantity    + "\n";
            s += "      Price: " + this.Price       + "\n";
            s += "   Discount: " + this.Discount    + "\n";
            s += "      Total: " + this.Total       + "\n";
            return s;
        }


        /** ****************************************************************************
		 * <summary>Generates an OrderItem with random made up data.</summary>
		 *******************************************************************************/
        public override void getRandomWarehouse()
        {
            base.getRandomWarehouse();
            Random random = new Random();
            this.SKU = "SKU: " + random.Next(0, 99999);
            this.Description = "Description: " + random.Next(0, 99999);
            this.Quantity = random.Next(1, 10);
            this.QuantityShipped = random.Next(1, 10);
            this.QuantityPending = random.Next(1, 10);
            this.QuantityCancelled = random.Next(1, 10);
            this.QuantityFilled = random.Next(1, 10);
            this.QuantityBackOrdered = random.Next(1, 10);
            this.ShipDate = DateTime.Now;
            this.Price = random.Next(1, 100);
            this.Discount = random.Next(1, 50);
            this.Total = this.Quantity * this.Price * (1 - this.Discount);
            this.GiftMessage = "Gift Message " + random.Next(0, 1000);
            if (random.Next(0, 1) == 1) this.GiftWrap = true;
            else this.GiftWrap = false;
            if (random.Next(0, 1) == 1) this.Continuity = true;
            else this.Continuity = false;
        }
        #endregion public methods


        #region CRUD
        /** ****************************************************************************
		 * <summary>
         *   Copies item data into a new Item object.
         * </summary>
         * <returns>The new Item object with the same data as the current object.</returns>
		 *******************************************************************************/
		public override WarehouseData Copy()
		{
            Item item        = new Item();
            item.ID          = this.ID         ;
            item.Description = this.Description;
			item.Quantity    = this.Quantity   ;
			item.Price       = this.Price      ;
            item.Discount    = this.Discount   ;
            item.Total       = this.Total      ;
			item.Oversize    = this.Oversize   ;
            item.Location    = this.Location   ;
            return item;
        }

		/** ****************************************************************************
		 * <summary>
         *   Implements Exists Method for WarehouseData.
         * </summary>
         * <returns>True if the Item already exists in the items table. False otherwise.</returns>
		 *******************************************************************************/
		public override bool Exists()
		{
			throw new NotImplementedException( "Warehouse.Item.Exists not implemented." );
		}
		
        /** ****************************************************************************
		 * <summary>
         *   Implements Create Method for WarehouseData.
         * </summary>
		 *******************************************************************************/
		public override bool Create()
		{
			throw new NotImplementedException( "Warehouse.Item.Create not implemented." );
		}
		
        /** ****************************************************************************
		 * <summary>
         *   Implements Read Method for WarehouseData.
         * </summary>
		 *******************************************************************************/
		public override bool Read()
		{
			throw new NotImplementedException( "Warehouse.Item.Read not implemented." );
		}
		
		/** ****************************************************************************
		 * <summary>
         *   Implements Update Method for WarehouseData.
         * </summary>
		 *******************************************************************************/
		public override bool Update()
		{
			throw new NotImplementedException( "Warehouse.Item.Update not implemented." );
		}
		
        /** ****************************************************************************
		 * <summary>
         *   Implements Delete Method for WarehouseData.
         * </summary>
		 *******************************************************************************/
		public override bool Delete()
		{
			throw new NotImplementedException( "Warehouse.Item.Delete not implemented." );
		}
        #endregion CRUD
    }
}
