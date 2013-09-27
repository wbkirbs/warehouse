using System                      ;
using System.Runtime.Serialization;
using System.Xml.Serialization    ;
using Utilities.String            ;

namespace Warehouse
{
    /** ****************************************************************************
     * <author>Wayne Bryan</author>
     * <date>October 24, 2012 - 2:37 PM</date>
     * <category>Class</category>
     * <summary>
     *   Stores address information for a customer, instead of all the individual fields.
     * </summary>
     *******************************************************************************/
    [Serializable]
    [DataContract(Name="address")]
    public class Address : WarehouseData
    {
        #region members
        protected enum Order {
            Name=1      , FirstName, MiddleName    , LastName  , Address        ,
            BusinessName, Attention, Address1      , Address2  , Address3       ,
            City        , State    , ZipCode       , ISO2      , ISO3           ,
            ISONumeric  , Phone    , PhoneExtension, Phone2    , PhoneExtension2,
            Email       , Fax      , Suffix        , Salutation, Gender
        }

        [IgnoreDataMember]
        public override string LinkID {
            get { return this.CustomerID ; }
            set { this.CustomerID = value; }
        }


        //the link to the customer
        [DataMember(Name="customer_id")]
        [XmlElement(ElementName="customer_id"/*, Order=(int) Order.FirstName*/)]
        public virtual string CustomerID       { get; set; }

        /** <value>A first name.</value>                              **/ 
        [DataMember(Name="first_name", Order=(int) Order.FirstName)]
        [XmlElement(ElementName="first_name"/*, Order=(int) Order.FirstName*/)]
        public virtual string FirstName       { get; set; }

        [DataMember(Name="middle_name", Order=(int) Order.MiddleName)]
        [XmlElement(ElementName="middle_name"/*, Order=(int) Order.MiddleName*/)]
        /** <value>A middle name.</value>                             **/ public virtual string MiddleName      { get; set; }

        [DataMember(Name="last_name"/*, Order=(int) Order.LastName*/)]
        [XmlElement(ElementName="last_name"/*, Order=(int) Order.LastName*/)]
        /** <value>A last name.</value>                               **/ public virtual string LastName        { get; set; }

        [DataMember(Name="business_name"/*, Order=(int) Order.BusinessName*/)]
        [XmlElement(ElementName="business_name"/*, Order=(int) Order.BusinessName*/)]
        /** <value>Business or company name.</value>                  **/ public virtual string BusinessName    { get; set; }

        [DataMember(Name="attention"/*, Order=(int) Order.Attention*/)]
        [XmlElement(ElementName="attention"/*, Order=(int) Order.Attention*/)]
        /** <value>Attention Line. Defaults to business name.</value> **/ public virtual string Attention       { get { if (_attention != null) return _attention; if (this.BusinessName != null) return this.BusinessName; return this.Name; } set { _attention = value; } }

        [DataMember(Name="address_1"/*, Order=(int) Order.Address1*/)]
        [XmlElement(ElementName="address_1"/*, Order=(int) Order.Address1*/)]
        /** <value>First line of street address.</value>              **/ public virtual string Address1        { get; set; }

        [DataMember(Name="address_2"/*, Order=(int) Order.Address2*/)]
        [XmlElement(ElementName="address_2"/*, Order=(int) Order.Address2*/)]
        /** <value>Second line of street address.</value>             **/ public virtual string Address2        { get; set; }

        [DataMember(Name="address_3"/*, Order=(int) Order.Address3*/)]
        [XmlElement(ElementName="address_3"/*, Order=(int) Order.Address3*/)]
        /** <value>Third line of street address.</value>              **/ public virtual string Address3        { get; set; }

        [DataMember(Name="city"/*, Order=(int) Order.City*/)]
        [XmlElement(ElementName="city"/*, Order=(int) Order.City*/)]
        /** <value>The city.</value>                                  **/ public virtual string City            { get; set; }

        [DataMember(Name="state"/*, Order=(int) Order.State*/)]
        [XmlElement(ElementName="state"/*, Order=(int) Order.State*/)]
        /** <value>The state.</value>                                 **/ public virtual string State           { get; set; }

        [DataMember(Name="zipcode"/*, Order=(int) Order.ZipCode*/)]
        [XmlElement(ElementName="zipcode"/*, Order=(int) Order.ZipCode*/)]
        /** <value>The zip code or postal code.</value>               **/ public virtual string ZipCode         { get; set; }

        [DataMember(Name="country"/*, Order=(int) Order.Country*/)]
        [XmlElement(ElementName="country"/*, Order=(int) Order.Country*/)]
        /** <value>The country Name.</value>                          **/ public virtual string Country         { get; set; }

        [DataMember(Name="iso_2"/*, Order=(int) Order.ISO2*/)]
        [XmlElement(ElementName="iso_2"/*, Order=(int) Order.ISO2*/)]
        /** <value>ISO 2-digit code of the country</value>            **/ public virtual string ISO2            { get; set; }

        [DataMember(Name="iso_3"/*, Order=(int) Order.ISO3*/)]
        [XmlElement(ElementName="iso_3"/*, Order=(int) Order.ISO3*/)]
        /** <value>ISO 3-digit code of the country</value>            **/ public virtual string ISO3            { get; set; }

        [DataMember(Name="iso_numeric"/*, Order=(int) Order.ISONumeric*/)]
        [XmlElement(ElementName="iso_numeric"/*, Order=(int) Order.ISONumeric*/)]
        /** <value>ISO numberic code of the country</value>           **/ public virtual string ISONumeric      { get; set; }

        [DataMember(Name="phone"/*, Order=(int) Order.Phone*/)]
        [XmlElement(ElementName="phone"/*, Order=(int) Order.Phone*/)]
        /** <value>The phone number.</value>                          **/ public virtual string Phone           { get; set; }

        [DataMember(Name="phone_extension"/*, Order=(int) Order.PhoneExtension*/)]
        [XmlElement(ElementName="phone_extension"/*, Order=(int) Order.PhoneExtension*/)]
        /** <value>The phone extension.</value>                       **/ public virtual string PhoneExtension  { get; set; }

        [DataMember(Name="phone_2"/*, Order=(int) Order.Phone2*/)]
        [XmlElement(ElementName="phone_2"/*, Order=(int) Order.Phone2*/)]
        /** <value>The second phone number.</value>                   **/ public virtual string Phone2          { get; set; }

        [DataMember(Name="phone_extension_2"/*, Order=(int) Order.PhoneExtension2*/)]
        [XmlElement(ElementName="phone_extension_2"/*, Order=(int) Order.PhoneExtension2*/)]
        /** <value>The second phone extension.</value>                **/ public virtual string PhoneExtension2 { get; set; }

        [DataMember(Name="email"/*, Order=(int) Order.Email*/)]
        [XmlElement(ElementName="email"/*, Order=(int) Order.Email*/)]
        /** <value>The email address.</value>                         **/ public virtual string Email           { get; set; }

        [DataMember(Name="fax"/*, Order=(int) Order.Fax*/)]
        [XmlElement(ElementName="fax"/*, Order=(int) Order.Fax*/)]
        /** <value>The fax number.</value>                            **/ public virtual string Fax             { get; set; }

        [DataMember(Name="suffix"/*, Order=(int) Order.Suffix*/)]
        [XmlElement(ElementName="suffix"/*, Order=(int) Order.Suffix*/)]
        /** <value>The suffix (jr., sr., etc.)</value>                **/ public virtual string Suffix          { get; set; }

        [DataMember(Name="salutation"/*, Order=(int) Order.Salutation*/)]
        [XmlElement(ElementName="salutation"/*, Order=(int) Order.Salutation*/)]
        /** <value>The saluation (mr, mrs, etc.)</value>              **/ public virtual string Salutation      { get; set; }

        [DataMember(Name="gender"/*, Order=(int) Order.Gender*/)]
        [XmlElement(ElementName="gender"/*, Order=(int) Order.Gender*/)]
        /** <value>Gender</value>                                     **/ public virtual string Gender          { get; set; }

        /** <value>Full name of customer. Calls getName() and setName().</value> **/
        [IgnoreDataMember] public virtual string Name { get { return this.getName(); } set { this.setName( value ); } }
        /** <value>Full address of customer, including street address and city and state. Calls getAddress() and setAddress().</value> **/
		[IgnoreDataMember] public virtual string AddressLine { get { return this.getAddress(); } set { this.setAddress( value ); } }
        /** <value>city state zip code line of address</value> **/
        [IgnoreDataMember] public virtual string CityStateZip { get { return this.getCityStateZip(); } set { this.setCityStateZip(value); } }

        [IgnoreDataMember] private string _attention;
        #endregion members


        #region constructors
        /** ****************************************************************************
         * <summary>Constructor. Does nothing.</summary>
         *******************************************************************************/
        public Address() : base()
        {

        }

        /** ****************************************************************************
         * <summary>Constructor. Sets up company.</summary>
         * <param name="company">The Company to use.</param>
         *******************************************************************************/
        public Address(Company company) : base(company)
        {

        }


        public Address(WarehouseData data) : base(data)
        {
            Address address      = (Address) data         ;
            this.FirstName       = address.FirstName      ;
            this.MiddleName      = address.MiddleName     ;
            this.LastName        = address.LastName       ;
            this.BusinessName    = address.BusinessName   ;
            this.Attention       = address.Attention      ;
            this.Address1        = address.Address1       ;
            this.Address2        = address.Address2       ;
            this.Address3        = address.Address3       ;
            this.City            = address.City           ;
            this.State           = address.State          ;
            this.ZipCode         = address.ZipCode        ;
            this.Country         = address.Country        ;
            this.ISO2            = address.ISO2           ;
            this.ISO3            = address.ISO3           ;
            this.ISONumeric      = address.ISONumeric     ;
            this.Phone           = address.Phone          ;
            this.PhoneExtension  = address.PhoneExtension ;
            this.Phone2          = address.Phone2         ;
            this.PhoneExtension2 = address.PhoneExtension2;
            this.Email           = address.Email          ;
            this.Fax             = address.Fax            ;
            this.Suffix          = address.Suffix         ;
            this.Salutation      = address.Salutation     ;
            this.Gender          = address.Gender         ;
        }
        #endregion constructors


        #region public methods
        /** ****************************************************************************
		 * <summary>Gets the formatted full name - helper to name property.</summary>
         * <returns>Full Name of a customer</returns>
		 *******************************************************************************/
		protected string getName()
		{
			string name = "";

			if (! string.IsNullOrEmpty( this.FirstName )) name = this.FirstName;
			if (this.MiddleName != null && this.MiddleName != "")
			{
				name = name.Trim() + " " + this.MiddleName;
				if (this.MiddleName.Length == 1) name += "."; // initial only
			}
			if (this.LastName != null && this.LastName != "") name = name.Trim() + " " + this.LastName;
			
			return name.Trim();
		}
		
        
        /** ****************************************************************************
		 * <summary>Takes in a full name and breaks it up into first and last names - helper to name property.</summary>
         * <param name="name">The full name to store.</param>
		 *******************************************************************************/
		public void setName(string name)
		{
            if (name == null) {
                this.FirstName = this.MiddleName = this.LastName = null;
                return;
            }
            name = name.Trim();
			this.FirstName  = Address.getFirstName ( name );
            this.MiddleName = Address.getMiddleName( name );
            this.LastName   = Address.getLastName  ( name );
		}
		

        /** ****************************************************************************
		 * <summary>
         *   Processes a full name and only returns the first name.
         * </summary>
         * <param name="name">The full name of a customer</param>
         * <returns>First Name for a customer</returns>
		 *******************************************************************************/
        public static string getFirstName(string name)
        {
            if (name == null) return null;
            string firstname = "";
            string[] names = name.Trim().Split( ' ' );

            if (names.Length >= 2) firstname = names[ 0 ].Trim();
            return firstname.Trim();
        }

        
        /** ****************************************************************************
		 * <summary>
         *   Processes a full name and only returns the middle name.
         * </summary>
         * <param name="name">The full name of a customer</param>
         * <returns>Middle Name for a customer</returns>
		 *******************************************************************************/
        public static string getMiddleName(string name)
        {
            if (name == null) return null;
            string middlename = "";
            string[] names = name.Trim().Split( ' ' );

            if (names.Length >= 3) 
            {
                // get everything between the first and last names
                for (int i = 1; i < names.Length - 1; i++) 
                {
                    if (names[ i ].Trim() == "") continue; // skip spaces
                    middlename += names[ i ].Trim() + " ";
                }
                middlename = middlename.Trim();
            }

            return middlename.Trim();
        }

        
        /** ****************************************************************************
		 * <summary>Processes a full name and only returns the last name.</summary>
         * <param name="name">The last name of a customer</param>
         * <returns>Last Name for a customer</returns>
		 *******************************************************************************/
        public static string getLastName(string name)
        {
            if (name == null) return null;
            string lastname = "";
            string[] names = name.Trim().Split( ' ' );

            if (names.Length >= 1) lastname = names[ names.Length - 1 ].Trim();

            return lastname.Trim();
        }


        public static string ReplaceFirstName(string name, string firstNameToReplace)
        {
            if (name != null) {
                string firstName = Address.getFirstName(name);
                name = name.Replace(firstName + " ", "");
            }
            name = firstNameToReplace + " " + name;
            name = name.Trim();

            return name;
        }
        public static string ReplaceMiddleName(string name, string middleNameToReplace)
        {
            string firstName = Address.getFirstName(name);
            string lastName  = Address.getLastName(name);
            if (name != null) {
                string middleName = Address.getMiddleName(name);
                name = name.Replace(" " + middleName + " ", "");
            }
            name = firstName + " " + middleNameToReplace + " " + lastName;
            name = name.Trim();

            return name;
        }
        public static string ReplaceLastName(string name, string lastNameToReplace)
        {
            if (name != null) {
                string lastName = Address.getLastName(name);
                name = name.Replace(" " + lastName, "");
            }
            name = name + " " + lastNameToReplace;
            name = name.Trim();

            return name;
        }

        /** ****************************************************************************
		 * <summary>Gets a formatted address - helper to address property.</summary>
         * <returns>The formatted address.</returns>
		 *******************************************************************************/
		protected string getAddress()
		{
			string address = "";
			
			if (! string.IsNullOrEmpty( this.Address1 )) address += this.Address1 + Environment.NewLine;
            if (! string.IsNullOrEmpty( this.Address2 )) address += this.Address2 + Environment.NewLine;
            if (! string.IsNullOrEmpty( this.Address3 )) address += this.Address3 + Environment.NewLine;
            address += this.getCityStateZip();
			
			return address.Trim();
		}


        /** ****************************************************************************
		 * <summary>Gets the city, state zipcode line of an address.</summary>
         * <returns>The formatted address.</returns>
		 *******************************************************************************/
        protected string getCityStateZip()
        {
            string address = "";
            if (! string.IsNullOrEmpty( this.City     ))
            {
                address += this.City;
                if (! string.IsNullOrEmpty( this.State )) address += ", ";
            }
            if (! string.IsNullOrEmpty( this.State    )) 
            {
                if (this.State.Trim().Length == 2) address += this.State;
                else address += this.State;
                address += " ";
            }
            if (! string.IsNullOrEmpty(this.ZipCode)) address += this.ZipCode;

            return address.Trim();
        }


        // takes in a full address and breaks it up into individual street address lines -- helper to address property
        private void setAddress(string address)
        {
            if (string.IsNullOrEmpty( address )) return;
            string[] lines = SuperString.Split( address, "\n" );
            lines = SuperString.RemoveBlankLines( lines );
            if (lines == null) return;

            // assume last line is city/state/zipcode line
            string citystateLine = null;
            if (lines.Length >= 2)
            {
                citystateLine = lines[ lines.Length - 1 ];
                if (citystateLine.Contains( "," ))
                {
                    this.City = citystateLine.Substring( 0, citystateLine.IndexOf( ',' )).Trim();
                    
                    string statezip = citystateLine.Substring( citystateLine.IndexOf( ',' ) + 1 ).Trim();
                    
                    this.State = statezip.Substring( 0, statezip.LastIndexOf( ' ' )).Trim();
                    if (this.State.Length == 2) this.State = this.State.ToUpper();
                    
                    this.ZipCode = statezip.Substring( statezip.LastIndexOf( ' ' ) + 1 ).Trim(); // assume zip code is last word
                }
                else this.City = citystateLine;

                // remove last line
                lines[ lines.Length - 1 ] = "";
                lines = SuperString.RemoveBlankLines( lines );
            }

            if (lines.Length >= 1) this.Address1 = lines[ 0 ].Trim();
            if (lines.Length >= 2) this.Address2 = lines[ 1 ].Trim();
            if (lines.Length >= 3) this.Address3 = lines[ 2 ].Trim();
            if (lines.Length >  3) for (int i = 3; i < lines.Length; i++) this.Address3 += Environment.NewLine + lines[ i ].Trim();
        }


        public void setCityStateZip(string address)
        {
            if (string.IsNullOrWhiteSpace(address)) return;
            if (! address.Contains(",")) return;

            address = address.Trim();
            int lastSpace = address.LastIndexOf(' ');
            int firstSpace = address.IndexOf(' ');
            int comma = address.IndexOf(',');
            this.City = address.Substring(0, comma).Trim();
            this.State = address.Substring(comma + 1, lastSpace - comma).Trim();
            this.ZipCode = address.Substring(lastSpace + 1).Trim();

        }

        /** ****************************************************************************
		 * <summary>
         *   Retrieves a printable string of all the customer fields.
         * </summary>
         * <returns>String of each customer field member.</returns>
		 *******************************************************************************/
		public override string ToString()
		{
			string s = "";
			string fullAddress = this.getAddress().Replace( "\n", "\n                " );
			
			s += "            ID: "  + this.ID            + "\n";
			s += "    First Name: "  + this.FirstName     + "\n";
			s += "   Middle Name: "  + this.MiddleName    + "\n";
			s += "     Last Name: "  + this.LastName      + "\n";
			s += "     Full Name: "  + this.Name          + "\n";
			s += "  Company Name: "  + this.BusinessName  + "\n";
			s += "Address Line 1: "  + this.Address1      + "\n";
			s += "Address Line 2: "  + this.Address2      + "\n";
			s += "Address Line 3: "  + this.Address3      + "\n";
            s += "          City: "  + this.City          + "\n";
			s += "         State: "  + this.State         + "\n";
			s += "       Zipcode: "  + this.ZipCode       + "\n";
			s += "       Country: "  + this.Country       + "\n";
			s += "  Full Address: "  + fullAddress        + "\n";
			s += "         Phone: "  + this.Phone         + "\n";
            s += "       Phone 2: "  + this.Phone2        + "\n";
			s += "        E-mail: "  + this.Email         + "\n";

			return s;
		}
        #endregion public methods
    }
}
