using System                      ;
using System.Runtime.Serialization;
using Databases                   ;

namespace Warehouse
{
    /** ****************************************************************************
     * <author>Wayne Bryan</author>
     * <date>September 26, 2010 - 6:29 PM</date>
     * <category>Class</category>
     * <summary>
     *   Provides a way to setup the company that the WarehouseData should be performed on.
     *   A company should be setup before any WarehouseData objects are created.
     * </summary>
     *******************************************************************************/
    [Serializable]
    public class Company : WarehouseInterface, IDisposable
    {
        #region members
        /** <value>Company id </value> **/ public string id;
        /** <value>Database object that WarehouseData uses. Read-only access.</value> **/
        [IgnoreDataMember] public virtual Database Database { get; set; }
        /** <value>The company name that the WarehouseData is using. Read-only access.</value> **/
		public virtual string Name              { get; set; }
        /** <value>Read-only access.</value> **/
		public virtual string SystemName        { get; set; }
        public BootStrap.Systems.System System { get; set; }
        /** <value>The user name or id that the WarehouseData is using. Read-only access.</value> **/
		public virtual string UserName          { get; set; }
        /** <value>The corresponding name of the MOM database to interface with.</value> **/
        public virtual string MomDatabase       { get { return null; } } 
        /** <value>The corresponding name of the MOM server to interface with.</value> **/
        public virtual string MomServer         { get { return null; } } 
        /** <value>The username to connect to the MOM database.</value> **/
        public virtual string MomUserName       { get { return null; } } 
        /** <value>The password to connect to the MOM database.</value> **/
        public virtual string MomPassword       { get { return null; } } 
        /** <value>The global identifier for this company, for easier access.</value> **/
        public virtual string CompanyGuid       { get; set; } 
        /** <value>The default shipment profile to use for this company.</value> **/
        public virtual string ShipmentProfile   { get; set; }
        /** <value>The default receiving profile to use for this company.</value> **/
        public virtual string ReceivingProfile  { get; set; }
        public virtual string AdjustmentProfile { get; set; }
        public virtual string ItemProfile       { get; set; } 
        /** <value>The customer prefix to use for consignees and customers.</value> **/
        public virtual string CustomerPrefix   { get; set; } 
        /** <value>A minimum item price for all items of this company. For user error checks.</value> **/
        public virtual int    MinimumItemPrice { get { return 0; } }
        public static bool Development;
        public string FriendlyName{
            get {
                if (_friendlyName != null) return _friendlyName;

                //lookup friendly name
                using (Result result = BootStrap.Database.Warwick.Query("select top 1 fullname from company where name = '{0}'", this.Name)) {
                    Row row = result.FetchRow();
                    _friendlyName = row["fullname"];
                }

                return _friendlyName;
            }
            set { _friendlyName = value; }
        }

        private string _friendlyName = null;
        #endregion members
        

        #region constructors
        /** ****************************************************************************
         * <summary>Constructor. Just calls base class to setup the company.</summary>
         *******************************************************************************/
        public Company() : base()
        {

        }

        /** ****************************************************************************
         * <summary>Copy Constructor. Copies Company member data.</summary>
         * <param name="company">The Company to copy.</param>
         *******************************************************************************/
        public Company(Company company)
        {
            if (company == null) return;
            this.id                = company.id;
            this.Database          = company.Database;
            this.Name              = company.Name;
            this.SystemName        = company.SystemName;
            this.UserName          = company.UserName;
            this.CompanyGuid       = company.CompanyGuid;
            this.ItemProfile       = company.ItemProfile;
            this.ShipmentProfile   = company.ShipmentProfile;
            this.ReceivingProfile  = company.ReceivingProfile;
            this.AdjustmentProfile = company.AdjustmentProfile;
        }


        /** ****************************************************************************
         * <summary>Constructor. Assigns company value.</summary>
         * <param name="database">The database to use for the Company object.</param>
         *******************************************************************************/
        public Company(Database database)
        {
            if (database == null) throw new ArgumentNullException("Database is null");
            this.Database = database;
        }
        
        public Company(string companyId) : base()
        {
            this.Name = companyId.Replace(" ", "").Trim().ToLower();
        }


        /** ****************************************************************************
         * <summary>Constructor. Assigns company value.</summary>
         * <param name="database">The database to use for the Company object.</param>
         * <param name="companyId">The company identifier to use for the Company object.</param>
         *******************************************************************************/
        public Company(Database database, string companyId) : base()
        {
            this.Database = (SqlDatabase) database;
            this.Name     = companyId.Trim().ToLower();
        }


        ~Company()
        {
            this.Dispose();
        }
        #endregion constructors


        #region public methods
        /** ****************************************************************************
		 * <summary>Used to prints out company settings, such as company name, user id, etc.</summary>
         * <returns>String of the Company object data members.</returns>
		 *******************************************************************************/
		public override string ToString()
		{
			string s = base.ToString();
			string nl = Environment.NewLine;
			s += "       Company Name: " + this.Name       + nl;
            s += "        System Name: " + this.SystemName + nl;
            s += "          User Name: " + this.UserName   + nl;
			s += "Database Connection: ";
            if (this.Database == null) s += "null";
            else s += this.Database.ToString();
            s += nl;
			return s;
		}
		
        /** ****************************************************************************
		 * <summary>
         *   Closes the database connection and performs cleanup.
         * </summary>
		 *******************************************************************************/
        public void Dispose()
        {
            if (this.Database == null) return;
            this.Database.Close();
            this.Database.Dispose();
        }
        
        /** ****************************************************************************
		 * <summary>Generates a Customer with random made up data.</summary>
		 *******************************************************************************/
        public void getRandomWarehouse()
        {
            Random random = new Random();
            this.id          = "Company ID# " + random.Next(1, 9999);
            this.Name        = "Company #" + random.Next(1, 9999);
            this.SystemName  = "System #" + random.Next(1, 9999);
            this.UserName    = "User #" + random.Next(1, 9999);
        }

        public int CompareTo(object warehouse)
        {
            throw new NotImplementedException("Warehouse.Company.CompareTo(object) IS NOT IMPLEMENTED");
        }

        /** ****************************************************************************
		 * <summary>Warehouse must implement object Equals.</summary>
         * <param name="obj">The Company object to compare to.</param>
         * <returns>True if the Company member data are equivalent. False otherwise.</returns>
		 *******************************************************************************/
        public override bool Equals(object obj)
        {
            if (! base.Equals(obj)) return false;
            if (obj == null || obj.GetType().Name != "Company") return false;
            Company company = (Company) obj;
            if (this.id         != company.id        ) return false;
            if (this.Name       != company.Name      ) return false;
            if (this.Database   != company.Database  ) return false;            
            if (this.SystemName != company.SystemName) return false;
            if (this.UserName   != company.UserName  ) return false;
            return true;
        }

        /** ****************************************************************************
		 * <summary>Warehouse must implement GetHashCode.</summary>
         * <returns>Unique hashcode for the Company object.</returns>
		 *******************************************************************************/
        public override int GetHashCode()
        {
            unchecked {
                int hash = 17; 
                if (Name       != null) hash = hash * 23 + Name      .GetHashCode();
                if (Database   != null) hash = hash * 23 + Database  .GetHashCode();
                if (SystemName != null) hash = hash * 23 + SystemName.GetHashCode();
                if (UserName   != null) hash = hash * 23 + UserName  .GetHashCode();
                return hash; 
            }
        }
        #endregion public methods


        #region CRUD
        /** ****************************************************************************
         * <summary>Copies current Company member data and returns a new Company instance.</summary>
         * <returns>An equivalent Company object, as a new object.</returns>
         *******************************************************************************/
        public WarehouseData Copy()
        {
            throw new NotImplementedException();
        }

        /** ****************************************************************************
         * <summary>Copies current Company member data to the current instance.</summary>
         * <param name="company">The Company object to copy.</param>
         *******************************************************************************/
        public void Copy(Company company)
        {
            this.id         = company.id        ;
            this.Database   = company.Database  ;
            this.Name       = company.Name      ;
            this.SystemName = company.SystemName;
            this.UserName   = company.UserName  ;
        }
        

        /** ****************************************************************************
         * <summary>Not implement yet.</summary>
         * <returns>Not implement yet.</returns>
         *******************************************************************************/
        public bool Exists()
        {
            throw new NotImplementedException();
        }

        /** ****************************************************************************
         * <summary>Not implement yet.</summary>
         * <returns>Not implement yet.</returns>
         *******************************************************************************/
        public bool Create()
        {
            throw new NotImplementedException();
        }

        /** ****************************************************************************
         * <summary>Not implement yet.</summary>
         * <returns>Not implement yet.</returns>
         *******************************************************************************/
        public virtual bool Read()
        {
            throw new NotImplementedException();
        }

        /** ****************************************************************************
		 * <summary>Implements ReadAll Method for WarehouseData.</summary>
         * <returns>Not implemented yet.</returns>
		 *******************************************************************************/
		public virtual WarehouseData[] ReadAll()
		{
			throw new NotImplementedException( "Warehouse.Company.ReadAll not implemented." );
		}

        /** ****************************************************************************
         * <summary>Not implement yet.</summary>
         * <returns>Not implement yet.</returns>
         *******************************************************************************/
        public bool Update()
        {
            throw new NotImplementedException();
        }

        /** ****************************************************************************
         * <summary>Not implement yet.</summary>
         * <returns>Not implement yet.</returns>
         *******************************************************************************/
        public bool Delete()
        {
            throw new NotImplementedException();
        }
        #endregion CRUD
    }
}
