using System                      ;
using System.Runtime.Serialization;
using System.Xml.Serialization    ;
using Databases                   ;
using Utilities.String            ;

namespace Warehouse
{
    /** ****************************************************************************
     * <author>Wayne Bryan</author>
     * <date>September 24, 2010 - 11:11 AM</date>
     * <category>Class</category>
     * <summary>
     *   Implementation of a customer/consignee.
     * </summary>
     *******************************************************************************/
    [Serializable]
    [DataContract(Name="customer")]
	public class Customer : WarehouseData
    {
        #region members
        [DataMember(Name="address_book")]
        [XmlElement(ElementName="address_book")]
        public virtual Address[] AddressBook { get { return _addressBook; } set { _addressBook = value; } } // = new Address[] { new Address() { FirstName="Hermy"},new Address() { FirstName="Grawpy"}};//{ get { return _addressBook; } }

        [IgnoreDataMember] protected virtual Address[] _addressBook { get; set; }
        [IgnoreDataMember] public virtual Address Address { get { if (_addressBook == null || _addressBook.Length == 0) _addressBook = new Address[] { new Address(this.Company) }; return _addressBook[0]; } }

        /** <value>Customer's first name.</value>                             **/ [IgnoreDataMember] public virtual string FirstName       { get { return this.Address.FirstName      ; } set { this.Address.FirstName       = value; } }
        /** <value>Customer's middle name.</value>                            **/ [IgnoreDataMember] public virtual string MiddleName      { get { return this.Address.MiddleName     ; } set { this.Address.MiddleName      = value; } }
        /** <value>Customer's last name.</value>                              **/ [IgnoreDataMember] public virtual string LastName        { get { return this.Address.LastName       ; } set { this.Address.LastName        = value; } }
        /** <value>Customer's full name.</value>                              **/ [IgnoreDataMember] public virtual string Name            { get { return this.Address.Name           ; } set { this.Address.Name            = value; } }
        /** <value>Customer's business or company name.</value>               **/ [IgnoreDataMember] public virtual string BusinessName    { get { return this.Address.BusinessName   ; } set { this.Address.BusinessName    = value; } }
        /** <value>Attention Line. Defaults to business name.</value>         **/ [IgnoreDataMember] public virtual string Attention       { get { return this.Address.Attention      ; } set { this.Address.Attention       = value; } }
        /** <value>First line of customer's street address.</value>           **/ [IgnoreDataMember] public virtual string Address1        { get { return this.Address.Address1       ; } set { this.Address.Address1        = value; } }
        /** <value>Second line of customer's street address.</value>          **/ [IgnoreDataMember] public virtual string Address2        { get { return this.Address.Address2       ; } set { this.Address.Address2        = value; } }
        /** <value>Thirs line of customer's street address.</value>           **/ [IgnoreDataMember] public virtual string Address3        { get { return this.Address.Address3       ; } set { this.Address.Address3        = value; } }
        /** <value>Customer's city.</value>                                   **/ [IgnoreDataMember] public virtual string City            { get { return this.Address.City           ; } set { this.Address.City            = value; } }
        /** <value>Customer's state.</value>                                  **/ [IgnoreDataMember] public virtual string State           { get { return this.Address.State          ; } set { this.Address.State           = value; } }
        /** <value>Customer's zip code or postal code.</value>                **/ [IgnoreDataMember] public virtual string ZipCode         { get { return this.Address.ZipCode        ; } set { this.Address.ZipCode         = value; } }
        /** <value>Customer's country.</value>                                **/ [IgnoreDataMember] public virtual string Country         { get { return this.Address.Country        ; } set { this.Address.Country         = value; } }
        /** <value>ISO 2-digit code of the country</value>                    **/ [IgnoreDataMember] public virtual string ISO2            { get { return this.Address.ISO2           ; } set { this.Address.ISO2            = value; } }
        /** <value>ISO 3-digit code of the country</value>                    **/ [IgnoreDataMember] public virtual string ISO3            { get { return this.Address.ISO3           ; } set { this.Address.ISO3            = value; } }
        /** <value>ISO numberic code of the country</value>                   **/ [IgnoreDataMember] public virtual string ISONumeric      { get { return this.Address.ISONumeric     ; } set { this.Address.ISONumeric      = value; } }
        /** <value>Customer's phone number.</value>                           **/ [IgnoreDataMember] public virtual string Phone           { get { return this.Address.Phone          ; } set { this.Address.Phone           = value; } }
        /** <value>Customer's phone extension.</value>                        **/ [IgnoreDataMember] public virtual string PhoneExtension  { get { return this.Address.PhoneExtension ; } set { this.Address.PhoneExtension  = value; } }
        /** <value>Customer's second phone number.</value>                    **/ [IgnoreDataMember] public virtual string Phone2          { get { return this.Address.Phone2         ; } set { this.Address.Phone2          = value; } }
        /** <value>Customer's second phone extension.</value>                 **/ [IgnoreDataMember] public virtual string PhoneExtension2 { get { return this.Address.PhoneExtension2; } set { this.Address.PhoneExtension2 = value; } }
        /** <value>Customer's e-mail address.</value>                         **/ [IgnoreDataMember] public virtual string Email           { get { return this.Address.Email          ; } set { this.Address.Email           = value; } }
        /** <value>Customer's fax number.</value>                             **/ [IgnoreDataMember] public virtual string Fax             { get { return this.Address.Fax            ; } set { this.Address.Fax             = value; } }
        /** <value>The suffix (jr., sr., etc.)</value>                        **/ [IgnoreDataMember] public virtual string Suffix          { get { return this.Address.Suffix         ; } set { this.Address.Suffix          = value; } }
        /** <value>The saluation (mr, mrs, etc.)</value>                      **/ [IgnoreDataMember] public virtual string Salutation      { get { return this.Address.Salutation     ; } set { this.Address.Salutation      = value; } }
        /** <value>Gender</value>                                             **/ [IgnoreDataMember] public virtual string Gender          { get { return this.Address.Gender         ; } set { this.Address.Gender          = value; } }
        /** <value>The type of customer. See CustomerType enumerator.</value> **/ public CustomerType   customerType    = CustomerType.SHIPTO; //default is shipto
        /** <value>The city state zipcode address line.</value>               **/ [IgnoreDataMember] public virtual string CityStateZip    { get { return this.Address.CityStateZip; } set { this.Address.CityStateZip = value; }}
        
        /** <value>List of possible customer types.</value> **/
        public enum CustomerType {
            /** <value>A customer that is represented by a shipping adderss.</value> **/ SHIPTO, 
            /** <value>A customer that is represented by a billing adderss.</value>  **/ BILLTO, 
            /** <value>A customer that is represented by a soldto adderss.</value>   **/ SOLDTO
        }
		#endregion members


        #region constructors
        /** ****************************************************************************
		 * <summary>
         *   Constructor. Call parent constructor.
         * </summary>
		 *******************************************************************************/
		public Customer() : base()
        {
            
        }

        /** ****************************************************************************
         * <summary>Copy Constructor. Copies Customer member data.</summary>
         * <param name="customer">The Customer to copy.</param>
         *******************************************************************************/
        public Customer(WarehouseData data) : base(data)
        {
            Customer customer = (Customer) data;
            if (customer == null) return;
            this.ID           = customer.ID;
			this.FirstName    = customer.FirstName;
			this.MiddleName   = customer.MiddleName;
			this.LastName     = customer.LastName;
			this.BusinessName = customer.BusinessName;
			this.Address1     = customer.Address1;
			this.Address2     = customer.Address2;
			this.Address3     = customer.Address3;
			this.City         = customer.City;
			this.State        = customer.State;
			this.ZipCode      = customer.ZipCode;
			this.Country      = customer.Country;
			this.Phone        = customer.Phone;
			this.Phone2       = customer.Phone2;
			this.Email        = customer.Email;
        }

        /** ****************************************************************************
         * <summary>Constructor. Assigns company value.</summary>
         * <param name="company">The company to use for this Customer object.</param>
         *******************************************************************************/
        public Customer(Company company) : base(company)
        {
            
        }

        /** ****************************************************************************
         * <summary>Constructor. Assigns address and company values.</summary>
         * <param name="address">The address to use for this Customer object.</param>
         *******************************************************************************/
        public Customer(Address address) : base(address.Company)
        {
            this.Address1 = address.Address1;
            this.Address2 = address.Address2;
            this.Address3 = address.Address3;
            this.City     = address.City    ;
            this.State    = address.State   ;
            this.ZipCode  = address.ZipCode ;
            this.Country  = address.Country ;
        }
        #endregion constructors


        #region public methods
        /** ****************************************************************************
		 * <summary>
         *   Retrieves a printable string of all the customer fields.
         * </summary>
         * <returns>String of each customer field member.</returns>
		 *******************************************************************************/
		public override string ToString()
		{
			string s = "";
			s += this.Address.ToString();
			return s;
		}


        


        /** ****************************************************************************
		 * <summary>Generates a Customer with random made up data.</summary>
		 *******************************************************************************/
        public override void getRandomWarehouse()
        {
            // some random customer info.
			string[] firstNames = new string[] {
				"Harry", "Hermione", "Ron", "Draco", "Fred",
				"George", "Ginny", "Charity", "Armando", "Albus Percival Wulfric Brian",
				"Argus", "Filius", "Wilhelmina", "Rubeus", "Roland",
				"Gilderoy", "Minerva", "Irma", "Poppy", "Quirinus",
				"Horace", "Severus", "Pomona", "Sybill", "Bloody",
				"Sir", "Fat", "Fat", "Helena", "Moaning",
				"Nearly Headless", "Phineas Nigellus", "Peeves", "Sorting", "Hannah",
				"Marcus", "Katie", "Susan", "Miles", "Lavendar",
				"Millicent", "Flora", "Hestia", "Cho", "Penelope",
				"Vincent", "Colin", "Roger", "Cedric", "Justin",
				"Marcus", "Seamus", "Gregory", "Terence", "Angelina",
				"Lee", "Neville", "Luna", "Ernie", "Cormac",
				"Nigel", "Pansy", "Padma", "Parvati", "Adrian",
				"Zacharias", "Alicia", "Dean", "Romilda", "Oliver",
				"Blaise", "Regulus", "Alecto", "Amycus", "Barty",
				"Antonin", "Fenrir", "Bellatrix", "Walden", "Lucius",
				"Narcissa", "Peter", "Thorfinn", "Chief", "Lord",
				"Amelia", "Mary", "Reg", "Barty", "John",
				"Amos", "Cornelius", "Mafalda", "Albert", "Rufus",
				"Pius", "Dolores", "Percy", "Sirius", "Dedalus",
				"Elphias", "Aberforth", "Arabella", "Mundungus", "Alice",
				"Frank", "Remus", "Alastor", "James", "Lily",
				"Kingsley", "Nymphadora", "Emmeline", "Arthur", "Bill",
				"Charlie", "Molly", "Frank", "Dudley", "Marge",
				"Petunia", "Vernon", "Piers", "Fleur", "Gabrielle",
				"Mr.", "Gellert", "Igor", "Viktor", "Olympe",
				"Bathilda", "Mr.", "Barnabas", "Ariana", "Auntie",
				"Xenophilius", "Ollie", "Ernie", "Madam", "Stan",
				"Rita", "Tom", "Myron", "Eldred", "Grawpy",
				"Kreacher", "Dubby"
			};
			string[] lastNames = new string[] {
				"Potter", "Granger", "Weasley", "Malfoy", "Weasley",
				"Weasley", "Weasley", "Burbage", "Dippet", "Dumbledore",
				"Filch", "Flitwick", "Grubbly-Plank", "Hagrid", "Hooch",
				"Lockhart", "McGonagall", "Pince", "Pomfrey", "Quirrell",
				"Slughorn", "Snape", "Sprout", "Trelawney", "Baron",
				"Cadogan", "Friar", "Lady", "Ravenclaw", "Myrtle",
				"Nick", "Black", "The Poltergeist", "Hat", "Abbott",
				"Belby", "Bell", "Bones", "Bletchley", "Brown",
				"Bulstrode", "Carrow", "Carrow", "Chang", "Clearwater",
				"Crabbe", "Creevey", "Davies", "Diggory", "Finch-Fletchey",
				"Flint", "Finnigan", "Goyle", "Higgs", "Johnson",
				"Jordan", "Longbottom", "Lovegood", "Macmillan", "McLaggen",
				"Wespurt", "Parkinson", "Patil", "Patil", "Pucey",
				"Smith", "Spinnet", "Thomas", "Vane", "Wood",
				"Zabini", "Black", "Carrow", "Carrow", "Crouch Jr.",
				"Dolohov", "Greyback", "Lestrange", "Macnair", "Malfoy",
				"Malfoy", "Pettigrew", "Rowle", "Snatcher", "Voldemort",
				"Bones", "Cattermole", "Cattermole", "Crouch Sr.", "Dawlish",
				"Diggory", "Fudge", "Hopkirk", "Runcorn", "Scrimgeour",
				"Thicknesse", "Umbridge", "Weasley", "Black", "Diggle",
				"Doge", "Dumbledore", "Figg", "Fletcher", "Longbottom",
				"Longbottom", "Lupin", "Moody", "Potter", "Potter",
				"Shacklebolt", "Tonks", "Vance", "Weasley", "Weasley",
				"Weasley", "Weasley", "Bryce", "Dursley", "Dursley",
				"Dursley", "Dursley", "Polkiss", "Delacour", "Delacour",
				"Gregorovitch", "Grindelwald", "Karkaroff", "Krum", "Maxime",
				"Bagshot", "Borgin", "Cuffe", "Dumbledore", "Muriel",
				"Lovegood", "Ollivander", "Prang", "Rosmerta", "Shunpike",
				"Skeeter", "Barman", "Wagtail", "Worple", "Grawp",
				"Houseelf", "Houseelf"
			};
			string[] companies = new string[] {
				"The Burrow", "Godric's Hollow", "Ottery St. Catchpole", "Tinworth", "Diagon Alley",
				"Little Hangleton", "Little Whinging", "Malfoy Manor", "Grimmauld Place", "Shell Cottage",
				"Spinner's End", "Beauxbatons", "Hogwarts", "Durmstrang", "Daily Prophet",
				"Eeylops", "Florean Fortescue's", "Flourish & Blotts", "Gringotts", "The Leaky Cauldron",
				"Madam Malkin's", "Magical Menagerie", "Ollivander's", "Potage's", "Quality Quidditch Supplies",
				"Slug and Jiggers Apothecary", "Gambol and Japes", "Stalls", "Telescope Shop", "Twilfitt and Tatting's",
				"Weasleys' Wizard Wheezes", "Hogsmeade", "The Three Broomsticks", "Zonko's Joke Shop", "The Hog's Head",
				"Dervish & Banges", "Gladrags Wizardwear", "Scrivenshaft's Quill Shop", "Madam Puddifoot's", "Honeydukes Sweetshop",
				"Post Office", "Shrieking Shack", "Azkaban", "Ministry of Magic", "Platform Nine and Three Quarters",
				"St. Mungo's", "Knockturn Alley", "Nurmengard",
			};
			string[] streets = new string[] {
				"Oxford St.", "Regent Street", "Soho Ln.", "Chinatown Way", "Covent Garden Rd.",
				"Bond St.", "Piccadilly and Jermyn St.", "Edgware Road", "Tottenham Court Road", "Seven Dials Blvd.",
				"Marylebone Place", "St. Christopher's Pl.", "Carnaby St.", "Charing Cross Rd.","Commercial Street",
				"Connaught Square", "Covent Garden", "Downing Street", "Fleet Street", "Haymarket Rd.",
				"The Mall Way", "Piccadilly Circus Lane", "Portobello Road", "Russell Square", "Shaftesbury Avenue",
				"Trafalgar Square"
			};
            string[] cities = new string[] {
                "Abell", "Aberdeen", "Aberdeen Proving Ground", "Aberdeen Proving Ground", "Abingdon", "Accident", "Accokeek", "Adamstown", "Adelphi", "Adelphi", "Allen", "Andrews AFB", "Annapolis", "Annapolis", "Annapolis", "Annapolis", "Annapolis", "Annapolis", "Annapolis", "Annapolis", "Annapolis Junction", "APG", "Aquasco", "Arbutus", "Ardmore", "Arlington", "Arnold", "Ashton", "Aspen Hill", "Aspen Hill", "Avenue", "Avondale", "Avondale", "Bainbridge", "Baldwin", "Baltimore", "Baltimore", "Baltimore", "Baltimore", "Baltimore", "Baltimore", "Baltimore", "Baltimore", "Baltimore", "Baltimore", "Baltimore", "Baltimore", "Baltimore", "Baltimore", "Baltimore", "Baltimore", "Baltimore", "Baltimore", "Baltimore", "Baltimore", "Baltimore", "Baltimore", "Baltimore", "Baltimore", "Baltimore", "Baltimore", "Baltimore", "Baltimore", "Baltimore", "Baltimore", "Baltimore", "Baltimore", "Baltimore", "Baltimore", "Baltimore", "Baltimore", "Baltimore", "Baltimore", "Baltimore", "Baltimore", "Baltimore", "Baltimore", "Baltimore", "Baltimore", "Baltimore", "Baltimore", "Baltimore", "Baltimore", "Baltimore", "Baltimore", "Baltimore", "Baltimore", "Baltimore", "Baltimore", "Baltimore", "Baltimore", "Baltimore", "Baltimore", "Baltimore", "Baltimore", "Baltimore", "Baltimore", "Baltimore", "Baltimore", "Baltimore", "Baltimore", "Baltimore Sunpapers", "Bancroft Hall", "Bank of America", "Bank of America", "Bank of America", "Bank of America", "Bank One", "Barclay", "Barnesville", "Barstow", "Barton", "Beachville", "Beallsville", "Bel Air", "Bel Air", "Bel Alton", "Belcamp", "Beltsville", "Beltsville", "Benedict", "Benson", "Bentley Springs", "Berlin", "Berwyn", "Berwyn Heights", "Bethesda", "Bethesda", "Bethesda", "Bethesda", "Bethesda", "Bethesda", "Bethesda", "Bethesda", "Bethesda", "Bethesda", "Bethesda", "Bethesda", "Bethesda", "Bethlehem", "Betterton", "Beverley Bch", "Big Pool", "Big Spring", "Bishop", "Bishopville", "Bittinger", "Bivalve", "Bladensburg", "Bloomington", "Boonsboro", "Boring", "Bowie", "Bowie", "Bowie", "Bowie", "Bowie", "Bowie", "Bowie", "Boyds", "Bozman", "Braddock Heights", "Bradshaw", "Brandywine", "Brentwd", "Brentwood", "Brinklow", "Brookeville", "Brooklandville", "Brooklandvl", "Brooklyn", "Brooklyn", "Brooklyn Park", "Broomes Island", "Brownsville", "Brunswick", "Brunswick", "Bryans Rd", "Bryans Road", "Bryantown", "Buckeystown", "Burkittsville", "Burtonsville", "Bushwood", "Butler", "Bwi Airport", "Cabin John", "California", "Callaway", "Calverton", "Cambridge", "Camp Springs", "Camp Springs", "Cape Saint Claire", "Capitol Heights", "Capitol Heights", "Capitol Heights", "Capitol Heights", "Capitol Heights", "Capitol Heights", "Capitol Heights PO", "Capitol Hgts", "Capitol Hgts", "Capitol Hgts", "Capitol Hgts", "Capitol Hgts", "Cardiff", "Carroll", "Carrollton", "Cascade", "Catonsville", "Catonsville", "Cavetown", "Cecilton", "Census Bureau", "Centreville", "Chance", "Chaptico", "Charlestown", "Charlott Hall", "Charlotte Hall", "Chase", "Cheltenham", "Cheltenham", "Chesapeak Bch", "Chesapeake Beach", "Chesapeake City", "Chesapeake Cy", "Chester", "Chestertown", "Chestertown", "Cheverly", "Cheverly", "Cheverly", "Chevy Chase", "Chevy Chase", "Chevy Chase", "Chewsville", "Childs", "Chillum", "Church Creek", "Church Hill", "Church Hill", "Churchton", "Churchville", "Citicorp", "Citicorp", "Citicorp ", "Claiborne", "Clarksburg", "Clarksville", "Clear Spring", "Clements", "Clifton", "Clifton East End", "Clifton East End", "Clinton", "Cloverly", "Cobb Island", "Cockeysville", "Cockeysville Hunt Valley", "Cockys Ht Valley", "Cockysvil", "Colesville", "Colesville", "Colesville", "College Estates", "College Park", "College Park", "College Park", "Colmar Manor", "Colora", "Coltons Point", "Columbia", "Columbia", "Columbia", "Columbia", "Compton", "Comptroller of the Treasury", "Comus", "Conowingo", "Cooksville", "Cordova", "Corriganville", "Cottage City", "Cpe St Claire", "Crapo", "Crellin", "Cresaptown", "Cresaptown", "Crestar Bank", "Crisfield", "Crocheron", "Crofton", "Crownsville", "Crumpton", "Cumberland", "Cumberland", "Cumberland", "Cumberland", "Cumberland", "Curtis Bay", "Damascus", "Dameron", "Dames Quarter", "Daniels", "Dares Beach", "Darlington", "Darnestown", "Darnestown", "Davidsonville", "Dayton", "Deal Island", "Deale", "Deer Park", "Delmar", "Denton", "Dentsville", "Dept HS", "Derwood", "Detour", "DHS", "Dickerson", "District Heights", "District Heights", "Doubs", "Dowell", "Drayden", "Druid", "Dundalk", "Dundalk Sparrows Point", "Dundalk Sparrows Point", "Dunkirk", "Earleville", "East Case", "East End", "East New Market", "Eastern Correctional Inst", "Easton", "Easton Correctional Inst", "Easton Correctional Inst", "Eastport", "Eckhart Mines", "Eden", "Edgemere", "Edgewater", "Edgewater Bch", "Edgewood", "Edgewood Arsenal", "Edmonston", "Eldersburg", "Elk Mills", "Elkridge", "Elkton", "Elkton", "Ellerslie", "Ellicott", "Ellicott", "Ellicott", "Ellicott City", "Ellicott City", "Ellicott City", "Elliott", "Emmitsburg", "Essex", "Eudowood", "Ewell", "Fairhaven", "Fairmount", "Fairmount Heights", "Fairmount Hgt", "Fairplay", "Fallston", "Faulkner", "Federalsburg", "Finksburg", "Firms-Business Reply", "Firms-Courtesy Reply", "Fishing Creek", "Flintstone", "Forest Heights", "Forest Hill", "Forestville", "Forestville", "Fork", "Fort Detrick", "Fort George G Meade", "Fort George Meade", "Fort Howard", "Fort Meade", "Fort Ritchie", "Fort Washington", "Fort Washington", "Fort Washington", "Fowbelsburg", "Foxridge", "Franklin", "Frederick", "Frederick", "Frederick", "Frederick", "Frederick", "Frederick", "Freeland", "Friendship", "Friendsville", "Frostburg", "Fruitland", "Fulton", "Funkstown", "Gaither", "Gaithersburg", "Gaithersburg", "Gaithersburg", "Gaithersburg", "Gaithersburg", "Gaithersburg", "Gaithersburg", "Gaithersburg", "Gaithersburg", "Gaithersburg", "Galena", "Galesville", "Gambrills", "Gapland", "Garrett Park", "Garrison", "Geico", "Geico", "Georgetown", "Germantown", "Germantown", "Germantown", "Gibson Island", "Girdletree", "Glen Arm", "Glen Burnie", "Glen Burnie", "Glen Burnie", "Glen Echo", "Glenarden", "Glenarden", "Glenburnie", "Glenburnie", "Glencoe", "Glenelg", "Glenmont", "Glenn Dale", "Glenwood", "Glyndon", "Glyndon", "Goddard Flight Center", "Goldsboro", "Golts", "Govans", "Graceham", "Granite", "Grantsville", "Grasonville", "Great Mills", "Green Meadow", "Greenbelt", "Greenbelt", "Greenbelt", "Greenmount", "Greensboro", "Gunpowder", "Gwynn Oak", "Hagerstown", "Hagerstown", "Hagerstown", "Hagerstown", "Hagerstown", "Hagerstown", "Hagerstown", "Halethorpe", "Hamilton", "Hampden", "Hampstead", "Hancock", "Hanover", "Hanover", "Harmans", "Harmans", "Harwood", "Havre de Grace", "Hebron", "Helen", "Henderson", "Henryton", "Henryton", "Hereford", "HHS", "Highfield", "Highland", "Highland Bch", "Highlandtown", "Hillandale", "Hillcrest Heights", "Hillcrest Heights", "Hillcrest Hgts", "Hillsboro", "Holland Point", "Hollywood", "Hood College", "Hoopersville", "Household Bank", "Hughesville", "Hunt Valley", "Hunt Valley", "Hunt Valley", "Huntingtown", "Huntvalley", "Hurlock", "Hutton", "Hvre de Grace", "Hyattstown", "Hyattsville", "Hyattsville", "Hyattsville", "Hyattsville", "Hyattsville", "Hyattsville", "Hyattsville", "Hydes", "Ijamsville", "Ilchester", "Indian Head", "Ingleside", "Ironsides", "Issue", "Jacksonville", "Jarrettsville", "Jefferson", "Jennings", "Jessup", "Johns Hopkins", "Johns Hopkins Hospital", "Joppa", "Joppatown", "Joppatowne", "Keedysville", "Kennedyville", "Kensington", "Kensington", "Kettering", "Kettering", "Keymar", "Kingston", "Kingsville", "Kitzmiller", "Knoxville", "Knoxville", "La Plata", "Ladiesburg", "Lake Linganore", "Lake Shore", "Lake Shore", "Landover", "Landover Hills", "Landover Hls", "Langley Park", "Langley Park", "Lanham", "Lanham", "Lanham", "Lanham Seabrook", "Lanham Seabrook", "Lansdowne", "Laplata", "Largo", "Largo", "Laurel", "Laurel", "Laurel", "Laurel", "Laurel", "Laurel", "Laurel", "Lavale", "Lavale", "Laytonsville", "Laytonsville", "Leisure World", "Leonardtown", "Lewisdale", "Lewistown", "LEX Park", "Lexington Park", "Libertytown", "Lineboro", "Lineboro", "Linkwood", "Linthicum", "Linthicum Heights", "Linwood", "Lisbon", "Little Orleans", "Loch Raven", "Loch Raven", "Loch Raven", "Lonaconing", "Long Green", "Lothian", "Loveville", "Luke", "Lusby", "Lutherville", "Lutherville", "Lutherville Timonium", "Lutherville Timonium", "Luthvle Timon", "Luthvle Timon", "Lynch", "M T Bank", "Maddox", "Madison", "Madison", "Magnolia", "Manchester", "Manchester", "Manokin", "Marbury", "Mardela", "Mardela Springs", "Marion", "Marion Station", "Marlboro", "Marlow Heights", "Marlow Heights", "Marlow Hgts", "Marriottsville", "Marriottsvl", "Marshall Hall", "Marydel", "Maryland City", "Maryland Correctional System", "Maryland Line", "Maryland Motor Vehicle Admin", "Massey", "Maugansville", "Mayo", "Mc Henry", "McCoole", "McDaniel", "McDonogh Run", "McHenry", "Md City", "Mechanicsville", "Mechanicsvlle", "Middle River", "Middleburg", "Middletown", "Midland", "Midlothian", "Millers", "Millersville", "Millersville", "Millington", "Mitchellville", "Mitchellville", "Mitchellville", "Mnt Lake Park", "Monkton", "Monrovia", "Montgomery Village", "Montgomery Village", "Montgomery Village", "Montgomry Village", "Montgomry Village", "Montgomry Village", "Montpelier", "Montpelier", "Morgan State University", "Morganza", "Morningside", "Mount Airy", "Mount Lake Park", "Mount Rainier", "Mount Savage", "Mount Victoria", "Mount Washington", "Mountain Lake Park", "Mtin Lk Park", "Myersville", "Nanjemoy", "Nanticoke", "National Harbor", "National Institute of Health", "National Institute Stds & Tech", "National Library of Medicine", "National Naval Medical Center", "Naval Academy", "Neavitt", "New Carrolltn", "New Carrollton", "New Market", "New Midway", "New Windsor", "Newark", "Newburg", "Newburg", "Newcomb", "No Bethesda", "No Brentwood", "No Potomac", "Norbeck", "Norrisville", "North Beach", "North Bethesda", "North Bethesda", "North Brentwo", "North Brentwood", "North College Park", "North East", "North Englewood", "North Ocean City", "North Potomac", "Northeast", "Northern", "Northwood", "Nottingham", "Oakland", "Ocean City", "Ocean City", "Ocean Pines", "Ocean Pnes", "Odenton", "Oella", "Oldtown", "Olney", "Olney", "Orchard Beach", "Oriole", "Owings", "Owings Mills", "Oxford", "Oxon Hill", "Oxon Hill", "Palmer Park", "Park Hall", "Parkton", "Parkville", "Parsonsburg", "Pasadena", "Pasadena", "Patapsco", "Patterson", "Patuxent Riv", "Patuxent River", "Patuxent River Naval Air Station", "Pdp Group Inc", "Perry Hall", "Perry Point", "Perryhall", "Perryman", "Perryville", "Phoenix", "Pikesville", "Pikesville", "Pikesville Finance", "Piney Point", "Pinto", "Pisgah", "Pittsville", "Pittsville", "Pocomoke", "Pocomoke City", "Point of Rocks", "Pomfret", "Poolesville", "Port Deposit", "Port Republic", "Port Tobacco", "Potomac", "Potomac", "Powellville", "Pr Frederick", "Preston", "Price", "Prince Frederick", "Prince George Plaza", "Prince Georges Metro Center", "Princess Anne", "Prnc Frederck", "Pylesville", "Quantico", "Queen Anne", "Queenstown", "Randallstown", "Raspeburg", "Rawlings", "Rehobeth", "Reisterstown", "Reisterstown", "Reisterstown Rd Plaza", "Rhodes Point", "Rhodesdale", "Riderwood", "Ridge", "Ridgely", "Rising Sun", "Rison", "Riva", "Riverdale", "Riverdale", "Riverside", "Riviera Beach", "Riviera Beach", "Rock Hall", "Rock Point", "Rockville", "Rockville", "Rockville", "Rockville", "Rockville", "Rockville", "Rockville", "Rockville", "Rockville", "Rockville", "Rockville", "Rocky Ridge", "Rogers Heights", "Rohrersville", "Roland Park", "Rose Haven", "Rosedale", "Royal Oak", "Rumbley", "Russett", "Ruxton", "Sabillasville", "Saint Charles", "Saint Charles", "Saint Charles", "Saint Inigoes", "Saint James", "Saint Leonard", "Saint Marys", "Saint Marys City", "Saint Michaels", "Saint Michaels", "Saint Michaels", "Salem", "Salisbury", "Salisbury", "Salisbury", "Salisbury", "Sandy Spring", "Sang Run", "Savage", "Scaggsville", "Scotland", "Seabrook", "Seabrook", "Seat Pleasant", "Secretary", "Severn", "Severna Park", "Shady Side", "Shallmar", "Sharpsburg", "Sharptown", "Sherwood", "Sherwood Forest", "Sherwood Frst", "Showell", "Silver Hill", "Silver Spring", "Silver Spring", "Silver Spring", "Silver Spring", "Silver Spring", "Silver Spring", "Silver Spring", "Silver Spring", "Silver Spring", "Silver Spring", "Silver Spring", "Silver Spring", "Silver Spring", "Silver Spring", "Silver Spring", "Silver Spring", "Silver Spring", "Silver Spring", "Simpsonville", "Smithsburg", "Snow Hill", "Social Security Admin", "Social Security Admin", "Social Security Administrat", "Solomons", "Somerset", "South Bowie", "Southern Md Brmas", "Southern Md Brmas", "Southern MD Facility", "Southern MD Facility", "Southern MD Facility", "Southern MD Facility", "Sparks", "Sparks Glenco", "Sparks Glencoe", "Sparrows Point", "Spencerville", "Spring Gap", "Springdale", "State Farm Ins Co", "Stevenson", "Stevensville", "Sthrn MD Fac", "Sthrn MD Fac", "Still Pond", "Stockton", "Street", "Subn MD Fac", "Suburb Maryland Fac", "Suburb Maryland Fac", "Suburban Md Brmas", "Sudlersville", "Suitland", "Suitland", "Sun Trust Bank", "Sunderland", "Sunshine", "Swan Point", "Swanton", "Sykesville", "T Rowe Price Associates Inc", "Takoma Park", "Takoma Park", "Takoma Park", "Takoma Park", "Takoma Park", "Tall Timbers", "Taneytown", "Taylors Island", "Temple Hills", "Temple Hills", "Temple Hills", "Temple Hills", "Temple Hills", "Templeville", "Thurmont", "Tilghman", "Timonium", "Timonium", "Toddville", "Towson", "Towson", "Towson", "Towson", "Towson", "Towson Finance", "Towson State University", "Tracys Landing", "Tracys Lndg", "Trappe", "Tuscarora", "Tuxedo", "Tyaskin", "Tylerton", "Union Bridge", "Unionville", "Unity", "University of Maryland", "University of Md Baltimore County", "University Pa", "University Park", "Upper Fairmount", "Upper Fairmt", "Upper Falls", "Upper Hill", "Upper Marlboro", "Upper Marlboro", "Upper Marlboro", "Upper Marlboro", "Upper Marlboro", "Upperco", "Uppr Marlboro", "Uppr Marlboro", "Uppr Marlboro", "Uppr Marlboro", "Uppr Marlboro", "UPR Marlboro", "Urbana", "Us Food and Drug Admin", "Usa Fulfillment", "Valley Lee", "Verizon", "Vienna", "Wachovia Bank", "Walbrook", "Waldorf", "Waldorf", "Waldorf", "Waldorf", "Walkersville", "Warwick", "Washingtn Grv", "Washington Bmc", "Washington Grove", "Waverly", "Welcome", "Wenona", "West Bethesda", "West Bowie", "West Friendship", "West Hyattsville", "West Hyattsville", "West Ocean City", "West River", "Westernport", "Westernport", "Westlake", "Westlake", "Westminster", "Westminster", "Westover", "Westover", "Whaleyville", "Wheaton", "Wheaton", "Wheaton", "White Hall", "White Marsh", "White Plns", "Whiteford", "Whitehaven", "Willards", "Williamsport", "Windsor Mill", "Wingate", "Wittman", "Woodbine", "Woodland Bch", "Woodlawn", "Woodsboro", "Woodstock", "Woodstock", "Woolford", "Woolford", "Worton", "Wye Mills"
            };
            string[] states = new string[] {
                "AL", "AK", "AS", "AZ", "AR", "CA", "CO", "CT", "DE", "DC", "FM", "FL", "GA", "GU", "HI", "ID", "IL", "IN", "IA", "KS", "KY", "LA", "ME", "MH", "MD", "MA", "MI", "MN", "MS", "MO", "MT", "NE", "NV", "NH", "NJ", "NM", "NY", "NC", "ND", "MP", "OH", "OK", "OR", "PW", "PA", "PR", "SC", "SD", "TN", "TX", "UT", "VT", "VI", "VA", "WA", "WV", "WI", "WY"
            };
            string[] zipcodes = new string[] {
                "20606", "21001", "21005", "21010", "21009", "21520", "20607", "21710", "20783", "20787", "21810", "20762", "21401", "21402", "21403", "21404", "21405", "21409", "21411", "21412", "20701", "21005", "20608", "21227", "20785", "21215", "21012", "20861", "20906", "20916", "20609", "20781", "20782", "21904", "21013", "21201", "21202", "21203", "21204", "21205", "21206", "21207", "21208", "21209", "21210", "21211", "21212", "21213", "21214", "21215", "21216", "21217", "21218", "21219", "21220", "21221", "21222", "21223", "21224", "21225", "21226", "21227", "21228", "21229", "21230", "21231", "21233", "21234", "21235", "21236", "21237", "21239", "21240", "21241", "21244", "21250", "21251", "21252", "21260", "21263", "21264", "21265", "21270", "21273", "21274", "21275", "21278", "21279", "21280", "21281", "21282", "21283", "21284", "21285", "21286", "21287", "21288", "21289", "21290", "21297", "21298", "21278", "21412", "21263", "21273", "21274", "21280", "21283", "21607", "20838", "20610", "21521", "20684", "20839", "21014", "21015", "20611", "21017", "20704", "20705", "20612", "21018", "21120", "21811", "20740", "20740", "20810", "20811", "20813", "20814", "20815", "20816", "20817", "20824", "20825", "20827", "20889", "20892", "20894", "21609", "21610", "21037", "21711", "21722", "21813", "21813", "21522", "21814", "20710", "21523", "21713", "21020", "20715", "20716", "20717", "20718", "20719", "20720", "20721", "20841", "21612", "21714", "21087", "20613", "20722", "20722", "20862", "20833", "21022", "21022", "21225", "21226", "21225", "20615", "21715", "21716", "21758", "20616", "20616", "20617", "21717", "21718", "20866", "20618", "21023", "21240", "20818", "20619", "20620", "20705", "21613", "20746", "20748", "21401", "20731", "20743", "20753", "20790", "20791", "20799", "20790", "20731", "20743", "20790", "20791", "20799", "21160", "21229", "21157", "21719", "21228", "21250", "21720", "21913", "21260", "21617", "21821", "20621", "21914", "20622", "20622", "21027", "20588", "20623", "20732", "20732", "21915", "21915", "21619", "21620", "21690", "20781", "20784", "20785", "20813", "20815", "20825", "21721", "21916", "20782", "21622", "21623", "21656", "20733", "21028", "21747", "21748", "21749", "21624", "20871", "21029", "21722", "20624", "21213", "21205", "21213", "20735", "20904", "20625", "21030", "21065", "21065", "21030", "20904", "20905", "20914", "21702", "20740", "20741", "20742", "20722", "21917", "20626", "20588", "21044", "21045", "21046", "20627", "21411", "20842", "21918", "21723", "21625", "21524", "20722", "21401", "21626", "21550", "21502", "21505", "21279", "21817", "21627", "21114", "21032", "21628", "21501", "21502", "21503", "21504", "21505", "21226", "20872", "20628", "21821", "21043", "20678", "21034", "20874", "20878", "21035", "21036", "21821", "20751", "21550", "21875", "21629", "20646", "20588", "20855", "21757", "20588", "20842", "20747", "20753", "21710", "20629", "20630", "21217", "21222", "21219", "21222", "20754", "21919", "21202", "21205", "21631", "21890", "21601", "21871", "21890", "21403", "21528", "21822", "21219", "21037", "21037", "21040", "21010", "20781", "21784", "21920", "21075", "21921", "21922", "21529", "21041", "21042", "21043", "21041", "21042", "21043", "21869", "21727", "21221", "21204", "21824", "20779", "21867", "20743", "20743", "21733", "21047", "20632", "21632", "21048", "21298", "21297", "21634", "21530", "20745", "21050", "20747", "20753", "21051", "21702", "20755", "20755", "21052", "20755", "21719", "20744", "20749", "20750", "21155", "21133", "21223", "21701", "21702", "21703", "21704", "21705", "21709", "21053", "20758", "21531", "21532", "21826", "20759", "21734", "21784", "20877", "20878", "20879", "20882", "20883", "20884", "20885", "20886", "20898", "20899", "21635", "20765", "21054", "21779", "20896", "21117", "20810", "20811", "21930", "20874", "20875", "20876", "21056", "21829", "21057", "21060", "21061", "21062", "20812", "20706", "20774", "21060", "21061", "21152", "21737", "20906", "20769", "21738", "21071", "21136", "20771", "21636", "21635", "21212", "21788", "21163", "21536", "21638", "20634", "20782", "20768", "20770", "20771", "21074", "21639", "21010", "21207", "21740", "21741", "21742", "21746", "21747", "21748", "21749", "21227", "21214", "21211", "21074", "21750", "21075", "21076", "21076", "21077", "20776", "21078", "21830", "20635", "21640", "21104", "21163", "21111", "20857", "21719", "20777", "21403", "21224", "20903", "20746", "20748", "20746", "21641", "20714", "20636", "21701", "21634", "21288", "20637", "21030", "21031", "21065", "20639", "21065", "21643", "21550", "21078", "20871", "20781", "20782", "20783", "20784", "20785", "20787", "20788", "21082", "21754", "21043", "20640", "21644", "20643", "20645", "21131", "21084", "21755", "21536", "20794", "21287", "21287", "21085", "21085", "21085", "21756", "21645", "20891", "20895", "20774", "20775", "21757", "21871", "21087", "21538", "21716", "21758", "20646", "21759", "21774", "21122", "21123", "20785", "20784", "20784", "20783", "20787", "20703", "20706", "20784", "20703", "20706", "21227", "20646", "20774", "20792", "20707", "20708", "20709", "20723", "20724", "20725", "20726", "21502", "21504", "20879", "20882", "20906", "20650", "20782", "21701", "20653", "20653", "21762", "21088", "21102", "21835", "21090", "21090", "21791", "21765", "21766", "21204", "21284", "21286", "21539", "21092", "20711", "20656", "21540", "20657", "21093", "21094", "21093", "21094", "21093", "21094", "21678", "21264", "20621", "21648", "21677", "21085", "21088", "21102", "21836", "20658", "21837", "21837", "21838", "21838", "20772", "20746", "20748", "20748", "21104", "21104", "20616", "21649", "20724", "21746", "21105", "21062", "21650", "21767", "21106", "21541", "21562", "21647", "21133", "21541", "20724", "20659", "20659", "21220", "21757", "21769", "21542", "21543", "21102", "21108", "21122", "21651", "20716", "20717", "20721", "21550", "21111", "21770", "20877", "20879", "20886", "20877", "20879", "20886", "20708", "20709", "21251", "20660", "20746", "21771", "21550", "20712", "21545", "20661", "21209", "21550", "21550", "21773", "20662", "21840", "20745", "20892", "20899", "20894", "20889", "21402", "21652", "20784", "20784", "21774", "21775", "21776", "21841", "20664", "20682", "21653", "20852", "20722", "20878", "20906", "21161", "20714", "20852", "20895", "20722", "20722", "20740", "21901", "20785", "21842", "20878", "21901", "21742", "21239", "21236", "21550", "21842", "21843", "21811", "21811", "21113", "21043", "21555", "20830", "20832", "21226", "21853", "20736", "21117", "21654", "20745", "20750", "20785", "20667", "21120", "21234", "21849", "21122", "21123", "21048", "21231", "20670", "20670", "20670", "21065", "21128", "21902", "21128", "21130", "21903", "21131", "21208", "21282", "21282", "20674", "21556", "20640", "21850", "21852", "21851", "21851", "21777", "20675", "20837", "21904", "20676", "20677", "20854", "20859", "21852", "20678", "21655", "21656", "20678", "20788", "20782", "21853", "20678", "21132", "21856", "21657", "21658", "21133", "21206", "21557", "21857", "21071", "21136", "21270", "21824", "21659", "21139", "20680", "21660", "21911", "20658", "21140", "20737", "20738", "21017", "21122", "21123", "21661", "20682", "20847", "20848", "20849", "20850", "20851", "20852", "20853", "20854", "20855", "20857", "20859", "21778", "20781", "21779", "21210", "20714", "21237", "21662", "21871", "20724", "21204", "21780", "20602", "20603", "20604", "20684", "21781", "20685", "20686", "20686", "21624", "21647", "21663", "21869", "21801", "21802", "21803", "21804", "20860", "21541", "20763", "20723", "20687", "20703", "20706", "20743", "21664", "21144", "21146", "20764", "21538", "21782", "21861", "21665", "21405", "21405", "21862", "20746", "20901", "20902", "20903", "20904", "20905", "20906", "20907", "20908", "20910", "20911", "20912", "20913", "20914", "20915", "20916", "20918", "20993", "20997", "21150", "21783", "21863", "21241", "21290", "21235", "20688", "20815", "20716", "20697", "20797", "20697", "20790", "20791", "20797", "21152", "21152", "21152", "21219", "20868", "21560", "20774", "21709", "21153", "21666", "20697", "20797", "21667", "21864", "21154", "20897", "20897", "20898", "20897", "21668", "20746", "20752", "21279", "20689", "20833", "20645", "21561", "21784", "21289", "20901", "20903", "20910", "20912", "20913", "20690", "21787", "21669", "20746", "20748", "20752", "20757", "20762", "21670", "21788", "21671", "21093", "21094", "21672", "21204", "21252", "21284", "21285", "21286", "21285", "21252", "20779", "20779", "21673", "21790", "20781", "21865", "21866", "21791", "21792", "20833", "20742", "21250", "20782", "20782", "21867", "21867", "21156", "21867", "20772", "20773", "20774", "20775", "20792", "21155", "20772", "20773", "20774", "20775", "20792", "20774", "21704", "20993", "21690", "20692", "21265", "21869", "21275", "21216", "20601", "20602", "20603", "20604", "21793", "21912", "20880", "20799", "20880", "21218", "20693", "21821", "20827", "20719", "21794", "20782", "20788", "21842", "20778", "21540", "21562", "20817", "20827", "21157", "21158", "21871", "21890", "21872", "20902", "20906", "20915", "21161", "21162", "20695", "21160", "21856", "21874", "21795", "21244", "21675", "21676", "21797", "21037", "21207", "21798", "21104", "21163", "21648", "21677", "21678", "21679"
            };
            
			
			// generate a random customer
			Random r = new Random();
			
            // get a random id #
            this.ID = r.Next( 1, 10000 ).ToString();

            // get random name
			int nameIndex = r.Next(0, firstNames.Length - 1);
			this.FirstName = firstNames[ nameIndex ];
            this.MiddleName = firstNames[ r.Next(0, firstNames.Length - 1) ];
			this.LastName = lastNames[ nameIndex ];
            if (r.Next(100, 105) == 103) this.MiddleName = firstNames[ r.Next(0, firstNames.Length - 1) ];
			
			string companyAddress = companies[ r.Next(0, companies.Length - 1) ];
			string streetAddress = r.Next(1, 999).ToString() + " " + streets[ r.Next(0, streets.Length - 1) ];
			string streetAddress2 = "Apt. #" + r.Next(1, 999) + "C";


            this.BusinessName = companyAddress + " LLC.";
			this.Address1 = companyAddress;
			this.Address2 = streetAddress;
			this.Address3 = streetAddress2;
			
			
            int cityzipIndex = r.Next( 0, cities.Length - 1 );
		    this.City    = cities  [ cityzipIndex ];
			this.ZipCode = zipcodes[ cityzipIndex ];
            this.State   = states[ r.Next( 0, states.Length - 1 ) ];
            this.Country = "US";


            // setup a phone #
            this.Phone = "";
            for (int i = 0; i < 10; i++) this.Phone += r.Next( 0, 9 );
            
            // decide whether to setup a 2nd phone #
            this.Phone2 = "";
            for (int i = 0; i < 10; i++) this.Phone2 += r.Next( 0, 9 );
            
            // decide whether to setup an email address
            this.Email = "";
            int userLength = r.Next( 1, 10 );
            for (int i = 0; i < userLength; i++) this.Email += (char) r.Next( 97, 122 );
            this.Email += "@";
            int domainLength = r.Next( 1, 10 );
            for (int i = 0; i < domainLength; i++) this.Email += (char) r.Next( 97, 122 );
            this.Email += ".com";
        }

        /** ****************************************************************************
		 * <summary>Warehouse must implement object Equals.</summary>
         * <param name="obj">The Customer object to compare to.</param>
         * <returns>True if the Customer member data are equivalent. False otherwise.</returns>
		 *******************************************************************************/
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType().Name != "Customer") return false;
            Customer customer = (Customer) obj;
            if (! base.Equals(customer)) return false;
                        
            if (this.Name         != customer.Name        ) return false;
            if (this.FirstName    != customer.FirstName   ) return false;
            if (this.MiddleName   != customer.MiddleName  ) return false;
            if (this.LastName     != customer.LastName    ) return false;
            if (this.BusinessName != customer.BusinessName) return false;
            if (this.Address1     != customer.Address1    ) return false;
            if (this.Address2     != customer.Address2    ) return false;
            if (this.Address3     != customer.Address3    ) return false;
            if (this.City         != customer.City        ) return false;
            if (this.State        != customer.State       ) return false;
            if (this.ZipCode      != customer.ZipCode     ) return false;
            if (this.Country      != customer.Country     ) return false;
            if (this.Phone        != customer.Phone       ) return false;
            if (this.Phone2       != customer.Phone2      ) return false;
            if (this.Email        != customer.Email       ) return false;
            return true;
        }

        /** ****************************************************************************
		 * <summary>Warehouse must implement GetHashCode.</summary>
         * <returns>Unique hashcode for the Customer object.</returns>
		 *******************************************************************************/
        public override int GetHashCode()
        {
            unchecked {
                int hash = 17 * 23 + base.GetHashCode(); 
                if (this.Name         != null) hash = hash * 23 + this.Name.GetHashCode();
                if (this.FirstName    != null) hash = hash * 23 + this.FirstName.GetHashCode();
                if (this.MiddleName   != null) hash = hash * 23 + this.MiddleName.GetHashCode();
                if (this.LastName     != null) hash = hash * 23 + this.LastName.GetHashCode();
                if (this.BusinessName != null) hash = hash * 23 + this.BusinessName.GetHashCode();
                if (this.Address1     != null) hash = hash * 23 + this.Address1.GetHashCode();
                if (this.Address2     != null) hash = hash * 23 + this.Address2.GetHashCode();
                if (this.Address3     != null) hash = hash * 23 + this.Address3.GetHashCode();
                if (this.City         != null) hash = hash * 23 + this.City.GetHashCode();
                if (this.State        != null) hash = hash * 23 + this.State.GetHashCode();
                if (this.ZipCode      != null) hash = hash * 23 + this.ZipCode.GetHashCode();
                if (this.Country      != null) hash = hash * 23 + this.Country.GetHashCode();
                if (this.Phone        != null) hash = hash * 23 + this.Phone.GetHashCode();
                if (this.Phone2       != null) hash = hash * 23 + this.Phone2.GetHashCode();
                if (this.Email        != null) hash = hash * 23 + this.Email.GetHashCode();
                return hash; 
            }
        }
        #endregion public methods


        #region CRUD Methods
		/** ****************************************************************************
		 * <summary>
         *   Copies customer data into a new Customer object.
         * </summary>
         * <returns>The new Customer object with the same data as the current object.</returns>
		 *******************************************************************************/
		public override WarehouseData Copy()
		{
			Customer c = new Customer();
            
            c.ID           = this.ID;
			c.FirstName    = this.FirstName;
			c.MiddleName   = this.MiddleName;
			c.LastName     = this.LastName;
			c.BusinessName = this.BusinessName;
			c.Address1     = this.Address1;
			c.Address2     = this.Address2;
			c.Address3     = this.Address3;
			c.City         = this.City;
			c.State        = this.State;
			c.ZipCode      = this.ZipCode;
			c.Country      = this.Country;
			c.Phone        = this.Phone;
			c.Phone2       = this.Phone2;
			c.Email        = this.Email;

			return c;
		}
        
	

        /** ****************************************************************************
		 * <summary>
         *   Implements Exists Method for WarehouseData.
         * </summary>
         * <returns>True if this customer already exists in the customers table. False otherwise</returns>
		 *******************************************************************************/
		public override bool Exists()
		{
			throw new NotImplementedException( "Warehouse.Customer.Exists not implemented." );
		}
		
		
		/** ****************************************************************************
		 * <summary>
         *   Implements Create Method for WarehouseData.
         * </summary>
		 *******************************************************************************/
		public override bool Create()
		{
            throw new NotImplementedException( "Warehouse.Customer.Create not implemented." );
		}
		
		
        /** ****************************************************************************
		 * <summary>
         *   Implements Read Method for WarehouseData.
         * </summary>
		 *******************************************************************************/
		public override bool Read()
		{
			throw new NotImplementedException( "Warehouse.Customer.Read not implemented." );
		}
		
        /** ****************************************************************************
		 * <summary>Implements ReadAll Method for WarehouseData.</summary>
         * <returns>Not implemented yet.</returns>
		 *******************************************************************************/
		public override WarehouseData[] ReadAll()
		{
			throw new NotImplementedException( "Warehouse.Customer.ReadAll not implemented." );
		}
		
        /** ****************************************************************************
		 * <summary>
         *   Implements Update Method for WarehouseData.
         * </summary>
		 *******************************************************************************/
		public override bool Update()
		{
			throw new NotImplementedException( "Warehouse.Customer.Update not implemented." );
		}
		
        /** ****************************************************************************
		 * <summary>
         *   Implements Delete Method for WarehouseData.
         * </summary>
		 *******************************************************************************/
		public override bool Delete()
		{
            //todo: verify address informagtion is sane before updating
			throw new NotImplementedException( "Warehouse.Customer.Delete not implemented." );
        }
        #endregion CRUD Methods
    }
}
