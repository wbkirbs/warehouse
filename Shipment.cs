using System                      ;
using System.Runtime.Serialization;
using System.Xml.Serialization    ;
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
    [DataContract (Name="shipment")]
	public class Shipment : WarehouseData
    {
        #region members
        [IgnoreDataMember]
        public override string LinkID {
            get { return this.OrderID ; }
            set { this.OrderID = value; }
        }

        //the link to the order
        [DataMember(Name="order_id")]
        [XmlElement(ElementName="order_id")]
        public virtual string OrderID            { get; set; }
        
        /*[DataMember(Name="ship_to_id")]
        [XmlElement(ElementName="ship_to_id")]
        public string ShipToID {
            get { return this.ShipTo.ID ; }
            set { this.ShipTo.ID = value; }
        }*/

        /** <value>Alternative order identifier.</value>                           **/ 
        [DataMember(Name="shipment_number")] [XmlElement(ElementName="shipment_number")]
        public virtual string   ShipmentNumber   { get; set; }

        [DataMember(Name="order_number")] [XmlElement(ElementName="order_number")]
        public virtual string   OrderNumber      { get; set; }

        /** <value>The date the order was "placed".</value>                        **/ 
        [DataMember(Name="order_date")] [XmlElement(ElementName="order_date")]
        public virtual DateTime OrderDate        { get; set; }

        /** <value>The date the order was "shipped".</value>                       **/ 
        [DataMember(Name="ship_date")] [XmlElement(ElementName="ship_date")]
        public virtual DateTime ShipDate         { get; set; }

        /** <value>A pick ticket reference number.</value>                         **/ 
        [DataMember(Name="pickticket_number")] [XmlElement(ElementName="pickticket_number")]
        public virtual string   PickTicketNumber { get; set; }

        /** <value>A gift message the customer can enter for the order</value>     **/ 
        [DataMember(Name="gift_message")] [XmlElement(ElementName="gift_message")]
        public virtual string   GiftMessage      { get; set; }

        [DataMember(Name="comment")] [XmlElement(ElementName="comment")]
        public virtual string   Comment      { get; set; }

        /** <value>The Total value before shipping, Tax, etc. are applied.</value> **/ 
        [DataMember(Name="subtotal")] [XmlElement(ElementName="subtotal")]
        public virtual double   SubTotal         { get; set; }

        /** <value>A discount amount for the order</value>                         **/ 
        [DataMember(Name="discount")] [XmlElement(ElementName="discount")]
        public virtual double   Discount         { get; set; }

        /** <value>The shipping cost for shipping this order.</value>              **/ 
        [DataMember(Name="shipping_cost")] [XmlElement(ElementName="shipping_cost")]
        public virtual double   ShippingCost     { get; set; }

        /** <value>The Tax associated with this order.</value>                     **/ 
        [DataMember(Name="tax")] [XmlElement(ElementName="tax")]
        public virtual double   Tax              { get; set; }

        [DataMember(Name="total")] [XmlElement(ElementName="total")]
        /** <value>The final Total amount on the order.</value>                    **/ public virtual double   Total            { get; set; }

        [DataMember(Name="source_code")] [XmlElement(ElementName="source_code")]
        /** <value>A source code to track this order.</value>                      **/ public virtual string   SourceCode       { get; set; }

        [DataMember(Name="order_type")] [XmlElement(ElementName="order_type")]
        /** <value>The type of order: Internet, Phone, etc.</value>                **/ public virtual Type     OrderType        { get; set; }
        public enum Type { Shipment, PurchaseOrder, Adjustment }

        [DataMember(Name="catalog_code")] [XmlElement(ElementName="catalog_code")]
        /** <value>The catalog code.</value>                                       **/ public virtual string   CatalogCode      { get; set; }

        [DataMember(Name="promotion_code")] [XmlElement(ElementName="promotion_code")]
        /** <value>A promotion code entered by the customer.</value>               **/ public virtual string   PromotionCode    { get; set; }

        [DataMember(Name="multiship")] [XmlElement(ElementName="multiship")]
        /** <value>Whether or not this order has multiple shipto addresses</value> **/ public virtual bool     Multiship        { get; set; }

        [DataMember(Name="ship_method")] [XmlElement(ElementName="ship_method")]
        /** <value>The shipping method used for the order.</value>                 **/ public virtual ShipType ShipMethod       { get; set; }

        /** <value>List of possible shipping methods.</value> **/
        public enum ShipType {
            /** <value>UPS Ground shipping.</value>                 **/ UPSG            , 
            /** <value>UPS next day shipping.</value>               **/ UPS1            , 
            /** <value>UPS next day AN shipping.</value>            **/ UPS1AM          , 
            /** <value>UPS next day PM shipping.</value>            **/ UPS1PM          , 
            /** <value>UPS next day air saver.</value>              **/ UPS1SAVER       , 
            /** <value>UPS 2nd day shipping.</value>                **/ UPS2            ,
            /** <value>UPS 2nd day AM shipping.</value>             **/ UPS2AM          ,
            /** <value>UPS 2nd day PM shipping.</value>             **/ UPS2PM          ,
            /** <value>UPS 3rd day select shipping.</value>         **/ UPS3            ,
            /** <value>Post office shipping.</value>                **/ USPS            ,
            /** <value>Mail Innovations shipping.</value>           **/ UPSMI           ,
            /** <value>Mail Innovations overnight shipping.</value> **/ UPSMI1          ,
            /** <value>Mail Innovations 2nd day shipping.</value>   **/ UPSMI2          ,
            /** <value>UPS Expedited International.</value>         **/ UPSINTERNATIONAL,
            /** <value>Fed Ex Ground shipping.</value>              **/ FEDEX           , 
            /** <value>Fed Ex Home Delivery shipping.</value>       **/ FEDEXHOM        , 
            /** <value>Fed Ex standard overnight shipping.</value>  **/ FEDEX1          ,
            /** <value>Fed Ex express overnight shipping.</value>   **/ FEDEX1AM        ,
            /** <value>Fed Ex first overnight shipping.</value>     **/ FEDEX1EAM       ,
            /** <value>Fed Ex 2nd day shipping.</value>             **/ FEDEX2          ,
            /** <value>Fed Ex 3rd day shipping.</value>             **/ FEDEX3          ,
            /** <value>Fed Ex SmartPost (USPS) shipping.</value>    **/ FEDEXSP         ,
            /** <value>Fed Ex Express Saver (3DF)</value>           **/ FEDEXSAVER      ,
            /** <value>LTL shipping.</value>                        **/ LTL             ,
            /** <value>Amazon shipping.</value>                     **/ AMAZON
        }
        /** <value>The tracking number for the order.</value>                                          **/ 
        [DataMember(Name="tracking_number")] [XmlElement(ElementName="tracking_number")]
        public virtual string   TrackingNumber   { 
            get { if (this.TrackingNumbers == null || this.TrackingNumbers.Length == 0) return null; else return this.TrackingNumbers[0].TheTrackingNumber; }
            set { 
                TrackingNumber TrackingNumber = new TrackingNumber(this.Company, value);
                if (this.TrackingNumbers == null) { 
                    this.TrackingNumbers = new TrackingNumber[1] { TrackingNumber };
                    return;
                }
                List<TrackingNumber> TrackingNumbers = new List<TrackingNumber>();
                TrackingNumbers.AddRange(this.TrackingNumbers);
                TrackingNumbers.Add(TrackingNumber);
                this.TrackingNumbers = TrackingNumbers.ToArray();
            }
        }
        /** <value>List of tracking number objects.</value>                                            **/ 
        [IgnoreDataMember] public virtual TrackingNumber[] TrackingNumbers { get; set; } //list of tracking numbers

        /** <value>The customer paying for the order.</value>                                          **/ 
        [IgnoreDataMember] public virtual Customer BillTo           { get; set; }

        /** <value>The customer the order is shipping to.</value>                                      **/ 
        [DataMember(Name="ship_to")] [XmlElement(ElementName="ship_to")]
        //public virtual Customer ShipTo           { get { if (_shipto == null) _shipto = new Customer(this.Company); return _shipto; } set { _shipto = value; } }
        public virtual Customer ShipTo           { get ; set; }
        //private Customer _shipto;

        [IgnoreDataMember] public virtual Customer SoldTo           { get; set; }

        /** <value>List of items that were ordered.</value>                                            **/ 
        [IgnoreDataMember] public virtual OrderItem[]   Items       { get { if (_items == null || _items.Count == 0) return null; else return _items.ToArray(); } }

        /** <value>List of boxes on the order.</value>                                             **/ 
        [DataMember(Name="boxes")] [XmlElement(ElementName="boxes")]
        public virtual Box[] Boxes              { get { if (_boxes == null) return null; /*_boxes = new List<Box>();*/ return _boxes.ToArray(); } set { _boxes = new List<Box>(); _boxes.AddRange(value); } }
        [IgnoreDataMember] public virtual Box Box { get { if (_boxes == null) return null;/*_boxes = new List<Box>();*/ _boxes.Add(new Box(this.Company)); return (Box) _boxes[0]; } }

        /** <value>List of payments on the order.</value> **/
        [IgnoreDataMember] public virtual Payment[] Payments        { get; set; }

        /** <value>Default payment of the order.</value> **/
        [IgnoreDataMember]
        public virtual Payment Payment { 
            get { if (this.Payments == null || this.Payments.Length != 1) return null; else return this.Payments[0]; } 
            set { this.Payments = new Payment[1]; this.Payments[0] = value; }
        }
        
        /** ****************************************************************************
		 * <summary>Computes the Total price, according to the price of each individual item.</summary>
         * <returns>Total price of the items.</returns>
		 *******************************************************************************/
        [IgnoreDataMember] 
		public virtual double TotalItemPrice {
			get {
				if (this.Items == null || this.Items.Length <= 0) return 0;
				double total = 0;
				for (int i = 0; i < this.Items.Length; i++) if (this.Items[i] != null) total += this.Items[ i ].Inventory.Price;
				return total;
			}
		}

        [IgnoreDataMember] 
        public virtual double TotalItemUnitCost {
			get {
				if (this.Items == null || this.Items.Length <= 0) return 0;
				double total = 0;
				for (int i = 0; i < this.Items.Length; i++) if (this.Items[i] != null) total += this.Items[ i ].Inventory.UnitCost;
				return total;
			}
		}
        /** ****************************************************************************
		 * <summary>Computes the Total number of items on the order.</summary>
         * <returns>Total quanity of items in the order...eg number of item units.</returns>
		 *******************************************************************************/
        [IgnoreDataMember] 
		public virtual int TotalItemQuantity {//Total number of units
			get {
                if (this.Items == null) return 0;
				int total = 0;
				for (int i = 0; i < this.Items.Length; i++) {
					if (this.Items[i] != null) total += this.Items[i].Quantity;
				}
				return total;
			}
            set { }
		}

        [IgnoreDataMember] 
        public virtual int TotalItemCount {//number of line items
			get {
                if (this.Items == null) return 0;
				int Total = 0;
				for (int i = 0; i < this.Items.Length; i++) {
					if (this.Items[i] != null) Total++;
				}
				return Total;
			}
            set { }
		}

		protected List<OrderItem> _items = new List<OrderItem>();
        protected List<Box> _boxes = new List<Box>();
        #endregion members


        #region constructors
        /** ****************************************************************************
		 * <summary>Constructor. Call parent constructor.</summary>
		 *******************************************************************************/
		public Shipment() : base()
        {
            
        }

        /** ****************************************************************************
         * <summary>Copy Constructor. Copies Order member data.</summary>
         * <param name="order">The Order to copy.</param>
         *******************************************************************************/
        public Shipment(WarehouseData data) : base(data)
        {
            Shipment shipment = (Shipment) data;
            this.ID               = shipment.ID;
            this.ShipmentNumber   = shipment.ShipmentNumber;
			this.OrderDate        = shipment.OrderDate;
			this.PickTicketNumber = shipment.PickTicketNumber;
			this.ShipMethod       = shipment.ShipMethod;
            this.ShipDate         = shipment.ShipDate;
            this.ShippingCost     = shipment.ShippingCost;
			this.GiftMessage      = shipment.GiftMessage;
			this.SubTotal         = shipment.SubTotal;
			this.Discount         = shipment.Discount;
			this.Tax              = shipment.Tax;
			this.Total            = shipment.Total;
			this.TrackingNumber   = shipment.TrackingNumber;
			this.SourceCode       = shipment.SourceCode;
            this.OrderType        = shipment.OrderType;
            this.CatalogCode      = shipment.CatalogCode;
			this.PromotionCode    = shipment.PromotionCode;
            this.TrackingNumber   = shipment.TrackingNumber;
			
			if (shipment.BillTo != null) this.BillTo = new Customer(shipment.BillTo);
            else this.BillTo = null;
			if (shipment.ShipTo != null) this.ShipTo = new Customer(shipment.ShipTo);
            else this.ShipTo = null;

			if (shipment.Items == null) _items = null;
            else {
                _items = new List<OrderItem>();
                _items.AddRange(shipment.Items);
			}
        }

        /** ****************************************************************************
         * <summary>Constructor. Assigns company value.</summary>
         * <param name="company">The company to use for this Warehouse object.</param>
         *******************************************************************************/
        public Shipment(Company company) : base(company)
        {
            
        }
        #endregion constructors


        #region public methods
        public void AddTrackingNumber(TrackingNumber TrackingNumber)
        {
            bool TrackingNumberExists = false;
            List<TrackingNumber> TrackingNumbers = new List<TrackingNumber>();
            if (this.TrackingNumbers != null) {
                TrackingNumbers.AddRange(this.TrackingNumbers);
                foreach (TrackingNumber tn in this.TrackingNumbers) {
                    if (tn.TheTrackingNumber == TrackingNumber.TheTrackingNumber) {
                        TrackingNumberExists = true;
                        break;
                    }
                }
            }

            if (! TrackingNumberExists) {
                TrackingNumbers.Add(TrackingNumber);
                this.TrackingNumbers = TrackingNumbers.ToArray();
            }
        }


        /** ****************************************************************************
         * <summary>Sets the appropriate shipping method based on a string value.</summary>
         * <param name="shipType">The shipping method to lookup.</param>
         *******************************************************************************/
        public void setShipType(string shipType)
        {
            if (string.IsNullOrWhiteSpace(shipType)) return;
            shipType = shipType.Trim().ToUpper();
            if      (shipType == "UPS"  ) this.ShipMethod = ShipType.UPSG ;
            else if (shipType == "UPSG" ) this.ShipMethod = ShipType.UPSG ;
            else if (shipType == "UPS1" ) this.ShipMethod = ShipType.UPS1 ;
            else if (shipType == "UPS2" ) this.ShipMethod = ShipType.UPS2 ;
            else if (shipType == "FEDEX") this.ShipMethod = ShipType.FEDEX;
            else if (shipType == "USPS" ) this.ShipMethod = ShipType.USPS ;
        }


        /** ****************************************************************************
		 * <summary>Used to prints out order settings.</summary>
         * <returns>String of the Order obejcts data members.</returns>
		 *******************************************************************************/
		public override string ToString()
		{
			string s = "";
			
			s += "       Shipment Number: " + this.ShipmentNumber                + "\n";
			s += "           Order Date : " + this.OrderDate.ToString() + "\n";
			s += "   Pick Ticket Number : " + this.PickTicketNumber     + "\n";
            s += "            Ship Date : " + this.ShipDate             + "\n";
			s += "      Shipping Method : " + this.ShipMethod           + "\n";
            s += "        Shipping Cost : " + this.ShippingCost         + "\n";
			s += "         Gift Message : " + this.GiftMessage          + "\n";
			s += "             SubTotal : " + this.SubTotal             + "\n";
			s += "             Discount : " + this.Discount             + "\n";
			s += "                  Tax : " + this.Tax                  + "\n";
			s += "                Total : " + this.Total                + "\n";
			s += "      Tracking Number : " + this.TrackingNumber       + "\n";
            s += "          Source Code : " + this.SourceCode           + "\n";
            s += "            OrderType : " + this.OrderType            + "\n";
            s += "         Catalog Code : " + this.CatalogCode          + "\n";
            s += "       Promotion Code : " + this.PromotionCode        + "\n";
			s += "\n";

			//s += "  " + sep + "\n    Bill To\n  " + sep + "\n\n";
			//if (this.BillTo != null) s += this.BillTo.ToString() + "\n";
			//else s += "NULL\n";
			
            /*try { s += this.BillTo.ToString() + "\n"; }
            catch { s += "NULL...\n"; }

			s += "  " + sep + "\n    Ship To\n  " + sep + "\n\n";
			if (this.ShipTo != null) s += this.ShipTo.ToString() + "\n";
			else s += "NULL\n";
			
			s += "  " + sep + "\n    Items\n  " + sep + "\n\n";
			for (int i = 0; this.Items != null && i < this.Items.Length; i++)
			{
                if (this.Items[i] == null) s += "null\n";
				else s += "    " + sep + "\n" + this.Items[i].ToString() + "    " + sep + "\n\n";
			}*/
			
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
            Shipment shipment = (Shipment) obj;
            if (! base.Equals(shipment)) return false;
            if (this.ShipmentNumber    != shipment.ShipmentNumber            ) return false;
            if (this.Discount          != shipment.Discount         ) return false;
            if (this.GiftMessage       != shipment.GiftMessage      ) return false;
            if (this.OrderDate         != shipment.OrderDate        ) return false;
            if (this.PickTicketNumber  != shipment.PickTicketNumber ) return false;
            if (this.PromotionCode     != shipment.PromotionCode    ) return false;
            if (this.ShipDate          != shipment.ShipDate         ) return false;
            if (this.ShipMethod        != shipment.ShipMethod       ) return false;
            if (this.ShippingCost      != shipment.ShippingCost     ) return false;
            if (this.SourceCode        != shipment.SourceCode       ) return false;
            if (this.OrderType         != shipment.OrderType        ) return false;
            if (this.CatalogCode       != shipment.CatalogCode      ) return false;
            if (this.SubTotal          != shipment.SubTotal         ) return false;
            if (this.Tax               != shipment.Tax              ) return false;
            if (this.Total             != shipment.Total            ) return false;
            if (this.TrackingNumber    != shipment.TrackingNumber   ) return false;
            if (this.TotalItemPrice    != shipment.TotalItemPrice   ) return false;
            if (this.TotalItemQuantity != shipment.TotalItemQuantity) return false;

            if (this.BillTo != shipment.BillTo) return false;
            if (this.ShipTo != shipment.ShipTo) return false;

            if (this.Items  == null && shipment.Items != null) return false;
            if (shipment.Items == null && this.Items  != null) return false;
            if (this.Items != null && shipment.Items != null && this.Items.Length != shipment.Items.Length) return false;
            if (this.Items != null) {
                for (int i = 0; i < this.Items.Length; i++) {
                    if (this.Items[i] != shipment.Items[i]) return false;
                }
            }

            return true;
        }


        /** ****************************************************************************
		 * <summary>Adds an item to the list of order items.</summary>
         * <param name="item">The item to add to this order.</param>
		 *******************************************************************************/
        public virtual void AddItem(params OrderItem[] items)
        {
            if (_items == null) _items = new List<OrderItem>();
            _items.AddRange(items);
        }

        /** ****************************************************************************
		 * <summary>Adds an item to the list of order items.</summary>
         * <param name="sku">The item sku to add to this order.</param>
         * <param name="quantity">The item quantity to add to this order.</param>
		 *******************************************************************************/
        public void AddItem(string sku, int quantity)
        {
            OrderItem item = new OrderItem(this.Company);
            item.Inventory.SKU = sku;
            item.Quantity = quantity;
            this.AddItem( item );
        }

        /** ****************************************************************************
		 * <summary>Removes an item from the list of order items.</summary>
         * <param name="item">The item to remove from the order.</param>
		 *******************************************************************************/
        public virtual void RemoveItem(OrderItem item)
        {
            _items.Remove(item);
        }

        /** ****************************************************************************
		 * <summary>Removes an item from the list of order items.</summary>
         * <param name="sku">The item sku to remove from the order.</param>
         * <param name="quantity">The item quantity to remove from the order.</param>
		 *******************************************************************************/
        public void RemoveItem(string sku, int quantity)
        {
            if (this.Items == null) return;
            List<OrderItem> items = new List<OrderItem>();
            items.AddRange( this.Items );
            foreach (OrderItem item in items) {
                if (item.SKU == sku && item.Quantity == quantity) {
                    items.Remove(item);
                    break;
                }
            }
            _items = items;
        }

        /** ****************************************************************************
		 * <summary>Adds a payment to the list of order payments.</summary>
         * <param name="payment">The payment to add to this order.</param>
		 *******************************************************************************/
        public virtual void AddPayment(Payment payment)
        {
            List<Payment> payments = new List<Payment>();
            if (this.Payments != null) payments.AddRange(this.Payments);
            payments.Add(payment);
            this.Payments = payments.ToArray();
        }

        /** ****************************************************************************
		 * <summary>Removes a payment from the list of order payments.</summary>
         * <param name="payment">The payment to remove from the order.</param>
		 *******************************************************************************/
        public virtual void RemovePayment(Payment payment)
        {
            List<Payment> payments = new List<Payment>();
            if (this.Payments != null) payments.AddRange(this.Payments);
            payments.Remove(payment);
            this.Payments = payments.ToArray();
        }



        /** ****************************************************************************
		 * <summary>Warehouse must implement GetHashCode.</summary>
         * <returns>Unique hashcode for the Order object.</returns>
		 *******************************************************************************/
        public override int GetHashCode()
        {
            unchecked {
                int hash = 17 * 23 + base.GetHashCode(); 
                if (this.ShipmentNumber             != null) hash = hash * 23 + this.ShipmentNumber.GetHashCode();
                hash = hash * 23 + this.Discount.GetHashCode();
                if (this.GiftMessage       != null) hash = hash * 23 + this.GiftMessage.GetHashCode();
                if (this.OrderDate         != null) hash = hash * 23 + this.OrderDate.GetHashCode();
                if (this.PickTicketNumber  != null) hash = hash * 23 + this.PickTicketNumber.GetHashCode();
                if (this.PromotionCode     != null) hash = hash * 23 + this.PromotionCode.GetHashCode();
                if (this.ShipDate          != null) hash = hash * 23 + this.ShipDate.GetHashCode();
                hash = hash * 23 + this.ShipMethod.GetHashCode();
                hash = hash * 23 + this.ShippingCost.GetHashCode();
                if (this.SourceCode        != null) hash = hash * 23 + this.SourceCode.GetHashCode();
                hash = hash * 23 + this.SubTotal.GetHashCode();
                hash = hash * 23 + this.Tax.GetHashCode();
                hash = hash * 23 + this.Total.GetHashCode();
                //if (this.OrderType != null) hash = hash * 23 + this.OrderType.GetHashCode();
                if (this.CatalogCode != null) hash = hash * 23 + this.CatalogCode.GetHashCode();
                if (this.TrackingNumber    != null) hash = hash * 23 + this.TrackingNumber.GetHashCode();
                hash = hash * 23 + this.TotalItemPrice.GetHashCode();
                hash = hash * 23 + this.TotalItemQuantity.GetHashCode();
                
                if (this.BillTo != null) hash = hash * 23 + this.BillTo.GetHashCode();
                if (this.ShipTo != null) hash = hash * 23 + this.ShipTo.GetHashCode();

                if (this.Items != null) {
                    foreach (OrderItem item in this.Items) {
                        if (item != null) hash = hash * 23 + item.GetHashCode();
                    }
                }

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
            this.ShipmentNumber   = r.Next( 1000, 99999 ).ToString();
            this.PickTicketNumber = r.Next( 1000, 99999 ).ToString();
            this.ShipMethod       = ShipType.UPSG;
            this.OrderDate        = DateTime.Now;
            this.GiftMessage      = "Gift Message " + r.Next(0, 1000);
            this.PromotionCode    = "Promotion #" + r.Next(0, 1000);
            this.SourceCode       = "Source Code #" + r.Next(0, 1000);            
            this.TrackingNumber   = "Tracking #" + r.Next(0, 1000);
            
            // get our customers
            this.BillTo = new Customer();
            this.BillTo.getRandomWarehouse();
            this.ShipTo = new Customer();
            this.ShipTo.getRandomWarehouse();

            // get some items
            int numItems = r.Next( 1, 10 );
            _items = new List<OrderItem>();
            for (int i = 0; i < numItems; i++)
            {
                this.Items[i] = new OrderItem();
                this.Items[i].getRandomWarehouse();
            }
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
			Shipment o = new Shipment();
		
            o.ID               = this.ID;
			o.ShipmentNumber   = this.ShipmentNumber;
			o.OrderDate        = this.OrderDate;
			o.PickTicketNumber = this.PickTicketNumber;
			o.ShipDate         = this.ShipDate;
            o.ShipMethod       = this.ShipMethod;
            o.ShippingCost     = this.ShippingCost;
			o.GiftMessage      = this.GiftMessage;
			o.SubTotal         = this.SubTotal;
			o.Discount         = this.Discount;
			o.Tax              = this.Tax;
			o.Total            = this.Total;
			o.TrackingNumber   = this.TrackingNumber;
			o.SourceCode       = this.SourceCode;
            o.OrderType        = this.OrderType;
            o.CatalogCode      = this.CatalogCode;
			o.PromotionCode    = this.PromotionCode;
			o.TrackingNumber   = this.TrackingNumber;

            
			if (this.BillTo != null) {
                o.BillTo = new Customer(this.BillTo);
			}
            else o.BillTo = null;

			if (this.ShipTo != null) {
                o.ShipTo = new Customer(this.ShipTo);
			}
            else o.ShipTo = null;
			
            /*if (this.Items == null) o.Items = null;
			else {
				o.Items            = new OrderItem[ this.Items.Length ];
				for (int i = 0; i < this.Items.Length; i++)
				{
                    if (this.Items[i] == null) o.Items[i] = null;
					else o.Items[i] = (OrderItem) this.Items[i].Copy();
				}
			}*/
            
            return o;
        }

        /** ****************************************************************************
		 * <summary>
         *   Implements Exists Method for WarehouseData.
         * </summary>
		 *******************************************************************************/
		public override bool Exists()
		{
			throw new NotImplementedException( "Warehouse.Shipment.Exists not implemented." );
		}
		
		/** ****************************************************************************
		 * <summary>
         *   Implements Create Method for WarehouseData.
         * </summary>
		 *******************************************************************************/
		public override bool Create()
		{
			throw new NotImplementedException( "Warehouse.Shipment.Create not implemented." );
		}
		
        /** ****************************************************************************
		 * <summary>
         *   Implements Read Method for WarehouseData.
         * </summary>
		 *******************************************************************************/
		public override bool Read()
		{
			throw new NotImplementedException( "Warehouse.Shipment.Read not implemented." );
		}

        /** ****************************************************************************
		 * <summary>Implements ReadAll Method for WarehouseData.</summary>
         * <returns>Not implemented yet.</returns>
		 *******************************************************************************/
		public override WarehouseData[] ReadAll()
		{
			throw new NotImplementedException( "Warehouse.Shipment.ReadAll not implemented." );
		}
		
        /** ****************************************************************************
		 * <summary>
         *   Implements Update Method for WarehouseData.
         * </summary>
		 *******************************************************************************/
		public override bool Update()
		{
			throw new NotImplementedException( "Warehouse.Shipment.Update not implemented." );
		}
		
        /** ****************************************************************************
		 * <summary>
         *   Implements Delete Method for WarehouseData.
         * </summary>
		 *******************************************************************************/
		public override bool Delete()
		{
			throw new NotImplementedException( "Warehouse.Shipment.Delete not implemented." );
        }
        #endregion CRUD
    }
}
