using System                      ;
using System.Collections          ;
using System.Collections.Generic  ;
using System.Runtime.Serialization;
using Databases                   ;

namespace Warehouse
{
    /** ****************************************************************************
     * <author>Wayne Bryan</author>
     * <date>September 28, 2010 - 2:20 PM</date>
     * <category>Abstract Class</category>
     * <summary>
     *   Represents the root of the Warehouse Data class hierarchy. Is more or less
     *   just an abstract placeholder. No functionality at this time.
     * </summary>
     *******************************************************************************/
    [Serializable]
    [DataContract]
	public abstract class WarehouseData : WarehouseInterface, IEnumerator, IEnumerable, IComparable, IDisposable
    {
        #region members
        [DataMember(Name="company"     )] public virtual string CompanyName  { get; set; }
        [DataMember(Name="system"      )] public virtual string System       { get; set; }
        [DataMember(Name="updatesystem")] public virtual string UpdateSystem { get; set; }
        [DataMember(Name="systemid"    )] public virtual string SystemID     { get; set; }
        [DataMember(Name="action"      )] public virtual string Action       { get; set; }
        [DataMember(Name="createdby"   )] public virtual string User         { get; set; }
        [IgnoreDataMember               ] public virtual string LinkID       { get; set; }

        /** <value>The company to perform Warehouse operations on.</value> **/ [IgnoreDataMember] private Company _company = null;

        /** <value>Returns the appropriate company for this Warehouse instance.</value> **/
        [IgnoreDataMember]
        public virtual Company Company {
            get { if (_company == null) _company = new Company(); return _company ; }
            set { _company = value; }
        }


        /** <value>Identifying string. All Warehouse objects must use an id.</value> **/ 
        [IgnoreDataMember] public virtual string ID { get; set; }
        /** <value>The current date and time. Alias of currentTime(). Read-only access.</value> **/
		[IgnoreDataMember] public string Time { get { return currentTime(); } }
        /** <value>Today's date, as of midnight. Alias of currentDate(). Read-only access.</value> **/
		[IgnoreDataMember] public string Date { get { return currentDate(); } }
        /** <value>Today's date, as of midnight in DateTime object.</value> **/
        [IgnoreDataMember] public DateTime MidnightDateTime { get { return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day); } } //midnight
        public DateTime Midnight(DateTime time) {
            return new DateTime(time.Year, time.Month, time.Day);
        }
        /** <value>The item profile for the company.</value> **/
        [IgnoreDataMember] public virtual string ItemProfile { get; set; }

        //added System type by wayne bryan on 2/13/2013
        public enum SYSTEM {
            WAREHOUSE, ABECAS, MOM, MOM_API, SENDSUITE, WARWICK
        }
        [IgnoreDataMember] private SYSTEM _system;
        [IgnoreDataMember] public SYSTEM SystemType { get { return _system; } }
        #endregion members


        #region constructors
        // Constructors. All constructors should be implemented in child classes.

        /** ****************************************************************************
         * <summary>Constructor. Does nothing.</summary>
         *******************************************************************************/
		public WarehouseData()
        {
            
        }

        
        /** ****************************************************************************
         * <summary>
         *    Copy Constructor. Assigns value of Warehouse object to the current instance.
         * </summary>
         * <param name="warehouse"></param>
         *******************************************************************************/
        public WarehouseData(WarehouseData warehouse)
        {
            if (warehouse == null) return;
            this.Company = warehouse.Company;
            this.ID = warehouse.ID;
            this.setDatabaseConnection();
        }
        

        /** ****************************************************************************
         * <summary>
         *    Constructor. Assigns company value.
         * </summary>
         * <param name="company">The company to use for this Warehouse object.</param>
         *******************************************************************************/
        public WarehouseData(Company company)
        {
            //if (company == null) throw new ArgumentOutOfRangeException("Null Company in Warehouse Constructor.");
            _company = company;

            this.setDatabaseConnection();
        }

        private void setDatabaseConnection()
        {
            if (_company == null) _company = BootStrap.Company.Warwick;

            //check to see if the database matches the object. if not, reset it
            if (_company.Database != null) {
                if (! this.GetType().FullName.ToLower().Contains(_company.Database.Name.ToLower())) _company.Database = null;
            }

            //setup the database connection
            if (_company.Database == null)
            {
                //string server = null, database = null;
                if (this.GetType().FullName.Contains("Abecas")) {
                    _company.Database = BootStrap.Database.Abecas;
                }
                else if (this.GetType().FullName.Contains("Mom")) {
                    _company.Database = BootStrap.Database.MomDatabase(_company.Name);
                }
            }
        }
        #endregion constructors


        #region protected methods
        /** ****************************************************************************
         * <summary>Easy way to verify Company is correctly setup.</summary>
         *******************************************************************************/
        protected void verifyCompany()
        {
            if (Company == null) throw new ArgumentNullException("Company is null");
            if (Company.Database == null) throw new ArgumentNullException("Company.Database is null");
        }
        #endregion protected methods


        #region public methods
        /** ****************************************************************************
         * <summary>ToString implementation.</summary>
         * <returns>String representation of all Warehouse members.</returns>
         *******************************************************************************/
        public override string ToString()
        {
            string nl = Environment.NewLine;
            string s = "";
            if (_company != null && _company.Database != null) s += string.Format("{0} - {1}", _company.Database.Name, _company.Database.Server) + nl;
            //s += "ID: " + this.id + nl;
            return s;
        }
        protected string ToString(string[] columns, object[] values)
        {
            string s = string.Format("----- {0} -----", this.GetType().FullName);
            string nl = Environment.NewLine;
            int maxColumnLength = 0;
            int maxValueLength = 0;

            for (int i = 0; i < columns.Length; i++) {
                if (columns[i].Length > maxColumnLength) maxColumnLength = columns[i].Length;
                if (values[i].ToString().Length > maxValueLength) maxValueLength = values[i].ToString().Length;
            }

            for (int i = 0; i < columns.Length; i++) {
                s += string.Format("{0}: {1}" + nl, columns[i].PadRight(maxColumnLength, ' '), values[i]);
            }
            s += "-".PadRight(maxColumnLength + maxValueLength + 2);

            return s;
        }

        /** ****************************************************************************
		 * <summary>Warehouse must implement object Equals.</summary>
         * <param name="obj">The object to compare to.</param>
         * <returns>True if the Warehouse objects member data are equivalent. False otherwise.</returns>
		 *******************************************************************************/
        public override bool Equals(object obj)
        {
            WarehouseData warehouse = (WarehouseData) obj;
            if (this.ID       != warehouse.ID      ) return false;
            if (this._company != warehouse._company) return false;
            return true;
        }

        /** ****************************************************************************
		 * <summary>Overload the == operator for convenience. Calls the Equals method.</summary>
         * <param name="warehouse1">One of the Warehouse objects to compare.</param>
         * <param name="warehouse2">The other Warehouse object to use for comparison.</param>
         * <returns>True if the Warehouse objects are equivalent. False otherwise.</returns>
		 *******************************************************************************/
        public static bool operator ==(WarehouseData warehouse1, WarehouseData warehouse2)
        {
            //if both are null, or both are same instance, return true.
            if (Object.ReferenceEquals(warehouse1, warehouse2)) return true;
            if (Object.ReferenceEquals(warehouse1, null)) return false;
            if (Object.ReferenceEquals(warehouse2, null)) return false;
            return warehouse1.Equals(warehouse2);
        }

        /** ****************************************************************************
		 * <summary>Overload the != operator for convenience. Calls the == method.</summary>
         * <param name="warehouse1">One of the Warehouse objects to compare.</param>
         * <param name="warehouse2">The other Warehouse object to use for comparison.</param>
         * <returns>False if the Warehouse objects are equivalent. True otherwise.</returns>
		 *******************************************************************************/
        public static bool operator !=(WarehouseData warehouse1, WarehouseData warehouse2)
        {
            if (Object.ReferenceEquals(warehouse1, warehouse2)) return false;
            if (Object.ReferenceEquals(warehouse1, null) && Object.ReferenceEquals(warehouse2, null)) return false;
            if (Object.ReferenceEquals(warehouse1, null)) return true;
            if (Object.ReferenceEquals(warehouse2, null)) return true;
            return ! (warehouse1 == warehouse2);
        }

        /** ****************************************************************************
		 * <summary>Compares two Warehouse objects to see if they are less than, equal, or great than one another. This is used for sorting objects.</summary>
         * <param name="warehouse">The object to compare to.</param>
         * <returns>0 if the two objects are identical. -1 if the current object is less than obj. +1 if the currnet object is greater than obj.</returns>
		 *******************************************************************************/
        public virtual int CompareTo(object warehouse)
        {
            return this.CompareTo(warehouse);
        }

        /** ****************************************************************************
		 * <summary>Warehouse must implement GetHashCode.</summary>
         * <returns>Unique hashcode for the Warehouse object.</returns>
		 ********************************************************************************/
        public override int GetHashCode()
        {
            unchecked {
                int hash = 17; 
                if (this.ID       != null) hash = hash * 23 + this.ID.GetHashCode();
                if (this.Company != null) hash = hash * 23 + this.Company.GetHashCode();
                return hash; 
            }
        }


        /** ****************************************************************************
		 * <summary>Cleans up warehouse. Disposes of company/database connection.</summary>
		 ********************************************************************************/
        public virtual void Dispose()
        {
            if (this.Company != null) this.Company.Dispose();
        }

        /** ****************************************************************************
		 * <summary>Sets Warehouse members with random data.</summary>
		 *******************************************************************************/
        public virtual void getRandomWarehouse()
        {
            throw new NotImplementedException("Child class must implement getRandomWarehouse.");
        }

        /** ****************************************************************************
         * <summary>Sets the Company object for the Warehouse.</summary>
         * <param name="company">The company object to use.</param>
         *******************************************************************************/
        public virtual void setCompany(Company company)
        {
            if (company == null) throw new ArgumentOutOfRangeException("Null Company in setCompany.");
            _company = company;
        }

        /** ****************************************************************************
		 * <summary>
         *   Returns the current system time.
         * </summary>
         * <returns>Current time, to the millisecond.</returns>
		 *******************************************************************************/
		public string currentTime()
		{
			return DateTime.Now.ToString("yyyyMMdd HH:mm:ss.fff"); // current timestamp
		}

		/** ****************************************************************************
		 * <summary>
         *   Returns the current date, withouth any time information.
         * </summary>
         * <returns>Current time, at midnight.</returns>
		 *******************************************************************************/
        public string currentDate()
		{
			return DateTime.Now.ToString( "yyyyMMdd" ) + " 00:00:00.000"; // current timestamp
		}


        //added by wayne bryan on 2/13/2013 to handle system retrieval by string
        public static SYSTEM getSystem(string system)
        {
            if (string.IsNullOrWhiteSpace(system)) throw new NotImplementedException("Unknown System: " + system);
            system = system.Trim().ToLower();
            switch (system) {
                case "abecas":
                    return WarehouseData.SYSTEM.ABECAS;
                case "mom":
                    return WarehouseData.SYSTEM.MOM;
                case "sendsuite":
                    return WarehouseData.SYSTEM.SENDSUITE;
            }

            throw new NotImplementedException("Unknown System: " + system);
        }
        public void setSystem(SYSTEM system)
        {
            _system = system;
        }
        #endregion public methods


        // some methods to convert string to double, date time, etc
        #region conversions
        /** ****************************************************************************
         * <summary>Useful string to DateTime conversion function.</summary>
         * <param name="datetimeString">The string to use to convert to a DateTime.</param>
         * <returns>Converted DateTime object.</returns>
         *******************************************************************************/
        public DateTime getDateTime(string datetimeString)
        {
            return Utilities.Utility.getDateTime(datetimeString);
        }
        
        
        /** ****************************************************************************
         * <summary>Strips off the time and just returns the date @ midnight.</summary>
         * <param name="datetime">The date to use to convert.</param>
         * <returns>Converted DateTime object.</returns>
         *******************************************************************************/
        public DateTime getDate(DateTime datetime)
        {
            return Utilities.Utility.getDate(datetime);
        }
        

        /** ****************************************************************************
         * <summary>Useful string to double conversion function.</summary>
         * <param name="doubleString">The string to use to convert to a double.</param>
         * <returns>Converted double.</returns>
         *******************************************************************************/
        public double getDouble(string doubleString)
        {
            return Utilities.Utility.getDouble(doubleString);
        }

        /** ****************************************************************************
         * <summary>Useful string to float conversion function.</summary>
         * <param name="floatString">The string to use to convert to a float.</param>
         * <returns>Converted float.</returns>
         *******************************************************************************/
        public float getFloat(string floatString)
        {
            return Utilities.Utility.getFloat(floatString);
        }

        /** ****************************************************************************
         * <summary>Useful string to int conversion function.</summary>
         * <param name="intString">The string to use to convert to a int.</param>
         * <returns>Converted int.</returns>
         *******************************************************************************/
        public int getInt(string intString)
        {
            return Utilities.Utility.getInt(intString);
        }


        /** ****************************************************************************
         * <summary>Converts a string to a boolean object.</summary>
         * <param name="boolean">String format of a boolean, such as true or yes.</param>
         * <returns>Boolean representation of the string.</returns>
         *******************************************************************************/
        public bool getBoolean(string boolean)
        {
            return Utilities.Utility.getBoolean(boolean);
        }

        /** ****************************************************************************
         * <summary>Converts a string to a byte array.</summary>
         * <param name="bytes">String to convert to byte array.</param>
         * <returns>A byte array, using utf8 encoding.</returns>
         *******************************************************************************/
        public byte[] getBytes(string bytes)
        {
            return Utilities.Utility.getBytes(bytes);
        }

        /** ****************************************************************************
         * <summary>Converts a string number to currency format.</summary>
         * <param name="number">String format of a number.</param>
         * <returns>A string representation of a number, rounded to two decimal places.</returns>
         *******************************************************************************/
        public string getCurrency(string number)
        {
            return Utilities.Utility.getCurrency(number);
        }

        /** ****************************************************************************
         * <summary>Converts a number to currency format. Alias.</summary>
         * <param name="number">The number to convert to currency.</param>
         * <returns>A string representation of a number, rounded to two decimal places.</returns>
         ********************************************************************************/
        public string getCurrency(double number) 
        { 
            return Utilities.Utility.getCurrency(number);
        }
        #endregion conversions


        #region CRUD
        // CRUD methods -- All Warehouse Data objects can choose to implement basic CRUD functionality.

        //verify that data has been loaded in the warehouse system
        public virtual bool Verify()
        {
            throw new NotImplementedException();
        }
        public virtual void Archive()
        {
            throw new NotImplementedException();
        }


        /** ****************************************************************************
		 * <summary>
         *   Creates a new WarehouseData object and copies all data members to this new object.
         * </summary>
         * <returns>An exact copy of the current WarehouseData object</returns>
		 *******************************************************************************/
        public virtual WarehouseData Copy()
        {
            throw new NotImplementedException();
        }

        /** ****************************************************************************
		 * <summary>
         *   Checks if the current WarehouseData object already exists in the "database" context.
         * </summary>
         * <returns>True if the WarehouseData already exists. False otherwise.</returns>
		 *******************************************************************************/
        public virtual bool Exists()
        {
            throw new NotImplementedException();
        }

        /** ****************************************************************************
		 * <summary>
         *   Creates a new WarehouseData object in the "database" with the values of the
         *   current WarehouseData object.
         * </summary>
         * <returns>True if the WarehouseData object was successfully created. False otherwise.</returns>
		 *******************************************************************************/
        public virtual bool Create()
        {
            throw new NotImplementedException();
        }

        /** ****************************************************************************
		 * <summary>Retrieves data on the current WarehouseData object and updates itself.</summary>
         * <returns>True if the WarehouseData object was successfully read. False otherwise.</returns>
		 *******************************************************************************/
        public virtual bool Read()
        {
            throw new NotImplementedException();
        }

        /** ****************************************************************************
		 * <summary>Retrieves list of data on the current WarehouseData object.</summary>
         * <returns>Array of WarehouseData.</returns>
		 *******************************************************************************/
        public virtual WarehouseData[] ReadAll()
        {
            throw new NotImplementedException();
        }

        /** ****************************************************************************
		 * <summary>Updates the current WarehouseData object in the "database."</summary>
         * <returns>True if the WarehouseData object was successfully updated. False otherwise.</returns>
		 *******************************************************************************/
        public virtual bool Update()
        {
            throw new NotImplementedException();
        }
        
        /** ****************************************************************************
		 * <summary>Deletes the current WarehouseData object in the "database."</summary>
         * <returns>True if the WarehouseData object was successfully deleted. False otherwise.</returns>
		 *******************************************************************************/
        public virtual bool Delete()
        {
            throw new NotImplementedException();
        }


        public virtual WarehouseData[] ToArray()
        {
            return _dataList.ToArray();
        }
        #endregion


        #region foreach
        [IgnoreDataMember] protected virtual List<WarehouseData> _dataList { get { return _theDataList; } }
        [IgnoreDataMember] private List<WarehouseData> _theDataList = new List<WarehouseData>();//initialize
        [IgnoreDataMember] private int _index = -1;
        /** ****************************************************************************
         * <summary>IEnumerator implementation.</summary>
         * <returns>An enumerator to the WarehouseData object.</returns>
         *******************************************************************************/
        public virtual IEnumerator GetEnumerator()
        {
            return (IEnumerator) this;
        }

        /** ****************************************************************************
         * <summary>IEnumerable implementation. Resets the foreach loop.</summary>
         *******************************************************************************/
        public virtual void Reset()
        {
            _index = -1;
        }

        /** ****************************************************************************
         * <summary>IEnumerable implementation. Moves to the next iteration in the loop.</summary>
         * <returns>True if another iteration is possible. False otherwise.</returns>
         *******************************************************************************/
        public virtual bool MoveNext()
        {
            if (_dataList == null) return false;
			_index++;
			return (_index < _dataList.Count);
        }

        /** ****************************************************************************
         * <value>IEnumerable implementation. Returns the current object in the loop.</value>
         *******************************************************************************/
        [IgnoreDataMember]
        public virtual object Current { 
            get { if (_dataList == null || _dataList.Count == 0) return null; else return _dataList[_index]; } 
        }
        #endregion foreach
    }
}