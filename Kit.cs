using System;
using System.Collections.Generic;
using Databases;

namespace Warehouse
{
    /** ****************************************************************************
     * <author>Wayne Bryan</author>
     * <date>November 23, 2011 - 12:44 PM</date>
     * <category>Class</category>
     * <summary>
     *   Implements Kit functionality. A kit is essentially a group of inventory items.
     * </summary>
     *******************************************************************************/
    public class Kit : WarehouseData
    {
        #region members
        /** <value>The list of items in the kit.</value> **/ public virtual Inventory[] Items       { get; set; }
        /** <value>The kit item sku.</value>             **/ public virtual string      SKU         { get; set; } 
        /** <value>The kit name.</value>                 **/ public virtual string      Name        { get; set; }
        /** <value>The kit description.</value>          **/ public virtual string      Description { get; set; }
        /** <value>The kit weight.</value>               **/ public virtual double      Weight      { get; set; }
        /** <value>The kit width.</value>                **/ public virtual double      Width       { get; set; }
        /** <value>The kit length.</value>               **/ public virtual double      Length      { get; set; }
        /** <value>The kit height.</value>               **/ public virtual double      Height      { get; set; }
        /** <value>The quantity of the kit.</value>      **/ public virtual int         Quantity    { get; set; }
        #endregion members


        #region constructors
        /** ****************************************************************************
         * <summary>Constructor. Just calls base class to setup the company.</summary>
         *******************************************************************************/
        public Kit() : base()
        {

        }

        /** ****************************************************************************
         * <summary>Copy Constructor. Copies Kit member data.</summary>
         * <param name="kit">The Kit to copy.</param>
         ********************************************************************************/
        public Kit(Kit kit) : base(kit)
        {
            this.Description = kit.Description;
            if (kit.Items != null)
            {
                this.Items = new Inventory[ kit.Items.Length ];
                for (int i = 0; i < kit.Items.Length; i++) this.Items[i] = (Inventory) kit.Items[i].Copy();
            }
        }

        /** ****************************************************************************
         * <summary>Constructor. Assigns company value.</summary>
         * <param name="company">The company to use for this Warehouse object.</param>
         ********************************************************************************/
        public Kit(Company company) : base(company)
        {
            
        }
        #endregion constructors


        #region public methods
        /** ****************************************************************************
         * <summary>ToString implementation.</summary>
         * <returns>String representation of all Kit members.</returns>
         *******************************************************************************/
        public override string ToString()
        {
            string s = base.ToString();
            string nl = Environment.NewLine;
            s += "Name       : " + this.Name + nl;
            s += "SKU        : " + this.SKU  + nl;
            s += "Description: " + this.Description + nl;
            s += "Items      : " + nl;
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
		 * <summary>Generates a Kit with random made up data.</summary>
		 *******************************************************************************/
        public override void getRandomWarehouse()
        {
            Random random = new Random();
            int kitNumber = random.Next(1, 9999);
            this.ID = "Kit #" + kitNumber;
            this.Description = "Kit Description " + kitNumber;
            this.Items = new Inventory[random.Next(1, 10)];
            for (int i = 0; i < this.Items.Length; i++)
            {
                this.Items[i] = new Inventory();
                this.Items[i].getRandomWarehouse();
            }
        }
        
        /** ****************************************************************************
		 * <summary>Warehouse must implement object Equals.</summary>
         * <param name="obj">The Kit object to compare to.</param>
         * <returns>True if the Kit member data are equivalent. False otherwise.</returns>
		 *******************************************************************************/
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType().Name != "Kit") return false;
            Kit kit = (Kit) obj;
            if (! base.Equals(kit)) return false;
            if (this.Description != kit.Description) return false;
            if (this.Name        != kit.Name       ) return false;
            if (this.SKU         != kit.SKU        ) return false;
            if (this.Items == null && kit.Items  != null) return false;
            if (kit.Items  == null && this.Items != null) return false;
            if (this.Items != null && kit.Items != null && this.Items.Length != kit.Items.Length) return false;
            if (this.Items != null) {
                for (int i = 0; i < this.Items.Length; i++) {
                    if (this.Items[i] != kit.Items[i]) return false;
                }
            }
            return true;
        }

        /** ****************************************************************************
		 * <summary>Warehouse must implement GetHashCode.</summary>
         * <returns>Unique hashcode for the Kit object.</returns>
		 *******************************************************************************/
        public override int GetHashCode()
        {
            unchecked {
                int hash = 17 * 23 + base.GetHashCode(); 
                if (this.Description != null) hash = hash * 23 + this.Description.GetHashCode();
                if (this.Name        != null) hash = hash * 23 + this.Name.GetHashCode();
                if (this.SKU         != null) hash = hash * 23 + this.SKU.GetHashCode();

                if (this.Items != null) {
                    foreach (Inventory item in this.Items) {
                        hash = hash * 23 + item.GetHashCode();
                    }
                }

                return hash; 
            }
        }
        
        
        /** ****************************************************************************
		 * <summary>Adds an item to the list of kit items.</summary>
         * <param name="item">The item to add to this kit.</param>
		 *******************************************************************************/
        public void AddItem(Inventory item)
        {
            List<Inventory> items = new List<Inventory>();
            if (this.Items != null) items.AddRange(this.Items);
            items.Add(item);
            this.Items = items.ToArray();
        }

        /** ****************************************************************************
		 * <summary>Removes an item from the list of kit items.</summary>
         * <param name="item">The item to remove from the kit.</param>
		 *******************************************************************************/
        public void RemoveItem(Inventory item)
        {
            List<Inventory> items = new List<Inventory>();
            if (this.Items != null) items.AddRange(this.Items);
            items.Remove(item);
            this.Items = items.ToArray();
        }
        #endregion public methods


        #region CRUD
        /** ****************************************************************************
         * <summary>Copies current Kit member data and returns a new Kit instance.</summary>
         * <returns>An equivalent Kit object, as a new object.</returns>
         *******************************************************************************/
        public override WarehouseData Copy()
        {
            Kit kit = new Kit();
            kit.ID = this.ID;
            kit.Description = this.Description;

            //copy inventory items
            if (this.Items != null) 
            {
                kit.Items = new Inventory[ this.Items.Length ];
                for (int i = 0; i < this.Items.Length; i++) kit.Items[ i ] = (Inventory) this.Items[ i ].Copy();
            }
            return kit;
        }

        /** ****************************************************************************
         * <summary>Not implement yet.</summary>
         * <returns>Not implement yet.</returns>
         *******************************************************************************/
        public override bool Exists()
        {
            throw new NotImplementedException();
        }

        /** ****************************************************************************
         * <summary>Not implement yet.</summary>
         * <returns>Not implement yet.</returns>
         *******************************************************************************/
        public override bool Create()
        {
            throw new NotImplementedException();
        }

        /** ****************************************************************************
         * <summary>Not implement yet.</summary>
         * <returns>Not implement yet.</returns>
         *******************************************************************************/
        public override bool Read()
        {
            throw new NotImplementedException();
        }

        /** ****************************************************************************
		 * <summary>Implements ReadAll Method for WarehouseData.</summary>
         * <returns>Not implemented yet.</returns>
		 *******************************************************************************/
		public override WarehouseData[] ReadAll()
		{
			throw new NotImplementedException( "Warehouse.Kit.ReadAll not implemented." );
		}

        /** ****************************************************************************
         * <summary>Not implement yet.</summary>
         * <returns>Not implement yet.</returns>
         *******************************************************************************/
        public override bool Update()
        {
            throw new NotImplementedException();
        }

        /** ****************************************************************************
         * <summary>Not implement yet.</summary>
         * <returns>Not implement yet.</returns>
         *******************************************************************************/
        public override bool Delete()
        {
            throw new NotImplementedException();
        }
        #endregion CRUD
    }
}
