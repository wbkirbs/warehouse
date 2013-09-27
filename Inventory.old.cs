using System;
using Databases;

namespace Warehouse
{
    /** ****************************************************************************
     * <author>Wayne Bryan</author>
     * <date>September 24, 2010 - 11:10 AM</date>
     * <category>Warehouse Class</category>
     * <summary>
     *   Provides inventory functionality.
     * </summary>
     ********************************************************************************/
	public class Inventory : WarehouseData, IComparable
    {
        //protected override Company _company = null;

        #region members
        /** <value>The sku is also the unique identifier. Alias to id.</value>           **/
        public virtual string sku     {
			get { return this.id ; }
			set { this.id = value; }
		}
        /** <value>The upc is also the unique identifier. Alias to id.</value>           **/ 
        public virtual string upc     {
			get { return this.id ; }
			set { this.id = value; }
		}
        /** <value>Current quantity available for this inventory item.</value>           **/ 
        public virtual int    quantity         { get; set; }
        /** <value>A description of the item.</value>                                    **/ 
        public virtual string description      { get; set; }
        /** <value>Additional description of the item.</value>                           **/ 
        public virtual string description2     { get; set; }
        /** <value>The selling price of the item.</value>                                **/ 
        public virtual double price            { get; set; }
        /** <value>The unit price of the item.</value>                                   **/ 
        public virtual double unitprice        { get; set; }
        /** <value>The unit cost of the item.</value>                                   **/
        public virtual double cost             { get; set; }
        /** <value>Any global discount towards the selling price of the item.</value>    **/ 
        public virtual double discount         { get; set; }
        /** <value>A color code describing the item.</value>                             **/ 
        public virtual string colorCode        { get; set; }
        /** <value>A color description describing the item.</value>                      **/ 
        public virtual string colorDescription { get; set; }
        /** <value>A size code desribing the item.</value>                               **/ 
        public virtual string sizeCode         { get; set; }
        /** <value>A size description for the item.</value>                              **/ 
        public virtual string sizeDescription  { get; set; }
        /** <value>A department code describing the item.</value>                        **/ 
        public virtual string departmentCode   { get; set; }
        /** <value>Indicates whether this inventory item should be gift wrapped.</value> **/ 
        public virtual bool   giftWrap         { get; set; }
        /** <value>Indicates whether this inventory item is oversized.</value> **/
        public virtual bool oversize           { get; set; }
        /** <value>The location of the item in inventory.</value>                        **/ 
        public virtual string location         { get; set; }
        /** <value>The weight of the item in inventory.</value>                          **/ 
        public virtual double weight           { get; set; }
        /** <value>The width of the item in inventory.</value>                           **/ 
        public virtual double width            { get; set; }
        /** <value>The length of the item in inventory.</value>                          **/ 
        public virtual double length           { get; set; }
        /** <value>The height of the item in inventory.</value>                          **/ 
        public virtual double height           { get; set; }
        /** <value>Current quantity on backorder for this inventory item.</value>           **/
        public virtual int backOrdered         { get; set; }
        /** <value>Current quantity on order for this inventory item.</value>           **/
        public virtual int onOrder             { get; set; }
        /** <value>Current quantity committed for this inventory item.</value>           **/
        public virtual int qtyCommitted        { get; set; }
        /** <value>The ISBN code of the item.</value>                             **/
        public virtual string isbn              { get; set; }
        
        #endregion members


        #region constructors
        /** ****************************************************************************
		 * <summary>
         *   Constructor.
         * </summary>
		 *******************************************************************************/
		public Inventory() : base()
		{
            
		}

        /** ****************************************************************************
         * <summary>Copy Constructor. Copies Inventory member data.</summary>
         * <param name="inventory">The Inventory to copy.</param>
         *******************************************************************************/
        public Inventory(Inventory inventory) : base(inventory)
        {
            this.id                 = inventory.id;
            this.quantity           = inventory.quantity;
            this.description        = inventory.description;
            this.description2       = inventory.description2;
            this.price              = inventory.price;
            this.cost               = inventory.cost;
            this.discount           = inventory.discount;
            this.colorCode          = inventory.colorCode;
            this.colorDescription   = inventory.colorDescription;
            this.sizeCode           = inventory.sizeCode;
            this.sizeDescription    = inventory.sizeDescription;
            this.departmentCode     = inventory.departmentCode;
            this.oversize           = inventory.oversize;
            this.location           = inventory.location;
            this.backOrdered        = inventory.backOrdered;
            this.onOrder            = inventory.onOrder;
            this.qtyCommitted       = inventory.qtyCommitted;
            this.isbn               = inventory.isbn;
        }

        /** ****************************************************************************
         * <summary>Constructor. Assigns company value.</summary>
         * <param name="company">The company to use for this Warehouse object.</param>
         *******************************************************************************/
        public Inventory(Company company) : base(company)
        {
            
        }

        /** ****************************************************************************
         * <summary>Constructor. Assigns company value.</summary>
         * <param name="companyId">The company identifier to use for the Company object.</param>
         *******************************************************************************/
        public Inventory(string companyId) : base(companyId)
        {
            
        }

        /** ****************************************************************************
         * <summary>Constructor. Assigns company value.</summary>
         * <param name="companyId">The company identifier to use for the Inventory object.</param>
         * <param name="development">Whether to use development properties of the Inventory.</param>
         *******************************************************************************/
        public Inventory(string companyId, bool development) : base(companyId, development)
        {
            
        }

        /** ****************************************************************************
         * <summary>Constructor. Assigns company value.</summary>
         * <param name="database">The database to use for the Company object.</param>
         *******************************************************************************/
        public Inventory(Database database) : base(database)
        {
            
        }
        #endregion


        #region public methods
        /** ****************************************************************************
		 * <summary>
         *   Used to prints out inventory settings.
         * </summary>
         * <returns>String of the Inventory obejcts data members.</returns>
		 *******************************************************************************/
		public override string ToString()
		{
			string str = "";
			str += "                    SKU: "  + this.sku                   + "\n";
			str += "               Quantity: "  + this.quantity              + "\n";
			str += "            Description: "  + this.description           + "\n";
            str += "           Description2: "  + this.description2          + "\n";
			str += "                 Price: $"  + this.price                 + "\n";
            str += "                  Cost: $"  + this.cost                  + "\n";
            str += "               Discount: "  + this.discount              + "\n";
			str += "             Color Code: "  + this.colorCode             + "\n";
			str += "      Color Description: "  + this.colorDescription      + "\n";
			str += "              Size Code: "  + this.sizeCode              + "\n";
			str += "       Size Description: "  + this.sizeDescription       + "\n";
            str += "        Department Code: "  + this.departmentCode        + "\n";
            str += "               Oversize: "  + this.oversize              + "\n";
            str += "               Location: "  + this.location              + "\n";
            str += "            BackOrdered: "  + this.backOrdered           + "\n";
            str += "               On Order: "  + this.onOrder               + "\n";
            str += "     Quantity Committed: "  + this.qtyCommitted          + "\n";
            str += "                   ISBN: "  + this.isbn                  + "\n";

			return str;
		}

        /** ****************************************************************************
		 * <summary>Warehouse must implement object Equals.</summary>
         * <param name="obj">The Inventory object to compare to.</param>
         * <returns>True if the Inventory member data are equivalent. False otherwise.</returns>
		 *******************************************************************************/
        public override bool Equals(object obj)
        {
            if (obj == null || (obj.GetType().Name != "Inventory" && obj.GetType().Name != "Item")) return false;
            Inventory inventory = (Inventory) obj;
            if (! base.Equals(inventory)) return false;
            if (this.colorCode        != inventory.colorCode       ) return false;
            if (this.colorDescription != inventory.colorDescription) return false;
            if (this.departmentCode   != inventory.departmentCode  ) return false;
            if (this.description      != inventory.description     ) return false;
            if (this.description2     != inventory.description2    ) return false;
            if (this.discount         != inventory.discount        ) return false;
            if (this.location         != inventory.location        ) return false;
            if (this.oversize         != inventory.oversize        ) return false;
            if (this.price            != inventory.price           ) return false;
            if (this.cost             != inventory.cost            ) return false;
            if (this.quantity         != inventory.quantity        ) return false;
            if (this.sizeCode         != inventory.sizeCode        ) return false;
            if (this.sizeDescription  != inventory.sizeDescription ) return false;
            if (this.sku              != inventory.sku             ) return false;
            if (this.upc              != inventory.upc             ) return false;
            if (this.backOrdered      != inventory.backOrdered     ) return false;
            if (this.onOrder          != inventory.onOrder         ) return false;
            if (this.qtyCommitted     != inventory.qtyCommitted    ) return false;
            if (this.isbn             != inventory.isbn            ) return false;


            return true;
        }
		
        /** ****************************************************************************
		 * <summary>Warehouse must implement GetHashCode.</summary>
         * <returns>Unique hashcode for the Inventory object.</returns>
		 *******************************************************************************/
        public override int GetHashCode()
        {
            unchecked {
                int hash = 17 * 23 + base.GetHashCode(); 
                if (this.colorCode        != null) hash = hash * 23 + this.colorCode.GetHashCode();
                if (this.colorDescription != null) hash = hash * 23 + this.colorDescription.GetHashCode();
                if (this.departmentCode   != null) hash = hash * 23 + this.departmentCode.GetHashCode();
                if (this.description      != null) hash = hash * 23 + this.description.GetHashCode();
                hash = hash * 23 + this.discount.GetHashCode();
                if (this.location         != null) hash = hash * 23 + this.location.GetHashCode();
                hash = hash * 23 + this.oversize.GetHashCode();
                hash = hash * 23 + this.price.GetHashCode();
                hash = hash * 23 + this.cost.GetHashCode();
                hash = hash * 23 + this.quantity.GetHashCode();
                if (this.sizeCode         != null) hash = hash * 23 + this.sizeCode.GetHashCode();
                if (this.sizeDescription  != null) hash = hash * 23 + this.sizeDescription.GetHashCode();
                if (this.sku              != null) hash = hash * 23 + this.sku.GetHashCode();
                if (this.upc              != null) hash = hash * 23 + this.upc.GetHashCode();
                hash = hash * 23 + this.backOrdered.GetHashCode();
                hash = hash * 23 + this.onOrder.GetHashCode();
                hash = hash * 23 + this.qtyCommitted.GetHashCode();

                return hash; 
            }
        }

        /** ****************************************************************************
		 * <summary>
         *   Sets the quantity with a numeric string.
         * </summary>
		 *******************************************************************************/
        public void setQuantity(string d)
		{
			int q = int.Parse(Math.Round(double.Parse( d )).ToString());
			this.quantity = q;
		}
    
		
		/** ****************************************************************************
		 * <summary>
         *   Gets the price in a string currency format.
         * </summary>
         * <returns>The price as a currency string.</returns>
		 *******************************************************************************/
		public string getPriceString()
		{
			return String.Format("{0:0.00}", this.price);
		}

		
        /** ****************************************************************************
		 * <summary>Gets a new Inventory object with random data fields.</summary>
		 ********************************************************************************/
		public override void getRandomWarehouse()
		{
			string[] items = new string[] {
				"Enchanted Coins", "Howler", "Invisibility Cloak", "Deluminator", "Hand of Glory",
				"Horcrux", "Elder Wand", "Resurrection Stone", "Foe-Glass", "Probity Probe",
				"Remembrall", "Revealer", "Secrecy Sensor", "Sneakoscope", "Weasley Family Clock",
				"Self-Shuffling Cards", "Wizard's Chess", "Exploding Snap", "Goblet of Fire", "Godric Gryffindor's Sword",
				"The Sorcerer's Stone", "Sorting Hat", "The Mirror of Erised", "Amortentia", "Confusing Concoction",
				"Draught of Living Death", "Draught of Peace", "Felix Felicis", "Polyjuice Potion", "Veritaserum",
				"Weasley's Wild-fire Whiz-Bangs", "Skiving Snackboxes", "Patented Daydream Charms", "Headless Hat", "Shield Hat",
				"Trick Wand", "Ton-Tongue Toffees", "Canary Creams", "Moody's Magical Trunk", "Pensieve",
				"Hermione's handbag", "Mokeskin pouch", "Basic Broomstick", "Mr. Weasley's Ford Anglia", "Floo Powder",
				"Flying Carpet", "Hogwarts Express", "Knight Bus", "Sirius Black's motorbike", "Portkeys",
				"Time-Turners", "Vanishing Cabinet", "Anti-Cheating Quill", "Auto-Answer Quill", "Blood Quill",
				"Quick Quotes Quill", "Spell-Checking Quill", "Cauldron", "Gubraithian Fire", "The Marauder's Map",
				"Omnioculars", " Spellotape", "Student's Wand"
			};
			
			Random r = new Random();
			this.sku = items[ r.Next(0, items.Length - 1) ];
			this.quantity = r.Next(1, 10);
            this.colorCode = "Color Code " + r.Next(0, 1000);
            this.colorDescription = "Color Description " + r.Next(0, 1000);
            this.departmentCode = "Department Code " + r.Next(0, 1000);
            this.description = "Description " + r.Next(0, 1000);
            this.description2 = "Description2 " + r.Next(0, 1000);
            this.discount = r.Next(0, 100);
            this.location = "Location " + r.Next(0, 1000);
            if (r.Next(0, 1) == 1) this.oversize = true; else this.oversize = false;
            this.price = r.Next(1, 1000);
            this.cost = r.Next(1, 1000);
            this.sizeCode = "Size Code " + r.Next(0, 1000);
            this.sizeDescription = "Size Description " + r.Next(0, 1000);
            this.backOrdered = r.Next(1, 10);
            this.onOrder = r.Next(1, 10);
            this.qtyCommitted = r.Next(1, 10);
            this.isbn = "ISBN: " + r.Next(0, 1000);

		} // getRandomItem
        #endregion public methods


        #region CRUD
        /** ****************************************************************************
		 * <summary>Copies inventory data into a new Inventory object.</summary>
         * <returns>The new Inventory object with the same data as the current object.</returns>
		 ********************************************************************************/
		public override WarehouseData Copy()
		{
			Inventory inventory = new Inventory();
         
            inventory.id               = this.id              ;
			inventory.quantity         = this.quantity        ;
			inventory.description      = this.description     ;
			inventory.price            = this.price           ;
            inventory.cost             = this.cost;
			inventory.discount         = this.discount        ;
			inventory.colorCode        = this.colorCode       ;
			inventory.colorDescription = this.colorDescription;
			inventory.sizeCode         = this.sizeCode        ;
			inventory.sizeDescription  = this.sizeDescription ;
            inventory.departmentCode   = this.departmentCode  ;
            inventory.oversize         = this.oversize        ;
            inventory.location         = this.location        ;
            inventory.backOrdered      = this.backOrdered;
            inventory.onOrder          = this.onOrder;
            inventory.qtyCommitted     = this.qtyCommitted;
            inventory.isbn             = this.isbn;
            return inventory;
        }
		
		/** ****************************************************************************
		 * <summary>Implements Exists Method for WarehouseData.</summary>
         * <returns>True if the inventory item already exists. False otherwise.</returns>
		 ********************************************************************************/
		public override bool Exists()
		{
			throw new NotImplementedException( "Warehouse.Inventory.Exists not implemented." );
		}

        /** ****************************************************************************
		 * <summary>
         *   Implements Create Method for WarehouseData. Inserts row into the inventory
         *   table in the warwick database.
         * </summary>
		 ********************************************************************************/
		public override bool Create()
		{
            throw new NotImplementedException( "Warehouse.Inventory.Create not implemented." );
		}
		
        /** ****************************************************************************
		 * <summary>Implements Read Method for WarehouseData.</summary>
		 *******************************************************************************/
		public override bool Read()
		{
			throw new NotImplementedException( "Warehouse.Inventory.Read not implemented." );
		}

        /** ****************************************************************************
		 * <summary>Implements ReadAll Method for WarehouseData.</summary>
         * <returns>Not implemented yet.</returns>
		 ********************************************************************************/
		public override WarehouseData[] ReadAll()
		{
			throw new NotImplementedException( "Warehouse.Inventory.ReadAll not implemented." );
		}
		
        /** ****************************************************************************
		 * <summary>Implements Update Method for WarehouseData.</summary>
         * <returns>Not implemented yet.</returns>
		 ********************************************************************************/
		public override bool Update()
		{
			throw new NotImplementedException( "Warehouse.Inventory.Update not implemented." );
		}
		
        /** ****************************************************************************
		 * <summary>Implements Delete Method for WarehouseData.</summary>
         * <returns>Not implemented yet.</returns>
		 ********************************************************************************/
		public override bool Delete()
		{
			 throw new NotImplementedException( "Warehouse.Inventory.Delete not implemented." );
		}
        #endregion CRUD



        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
