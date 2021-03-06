Imports SsCommon
Imports System.ComponentModel
Imports System.Runtime.Serialization

Namespace DTO

<DataContract(),Table("CRM_LEADS")> _
Public Class CrmLeads
    Inherits BaseDto
    Implements IEquatable(Of CrmLeads)
         
	 
   	Private _LeadId As Decimal
		<DataMember(),DataField("LEAD_ID"),DataAnnotations.Key()> _
		Public Property LeadId() As Decimal
			Get
				Return Me._LeadId
			End Get
			Set(ByVal value As Decimal)
					If (Object.ReferenceEquals(Me.LeadId, value) <> true) Then
						Me._LeadId = value
						OnPropertyChanged("LeadId")
					End If  
			End Set
		End Property


	
	Private _ActivityCat As String
		<DataMember(),DataField("ACTIVITY_CAT")> _
		Public Property ActivityCat() As String
			Get
				Return Me._ActivityCat
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.ActivityCat, value) <> true) Then				    
						Me._ActivityCat = value
						OnPropertyChanged("ActivityCat")
				    End If 
			End Set
		End Property

Private _ConvContactId As Nullable(of Decimal)
		<DataMember(),DataField("CONV_CONTACT_ID")> _
		Public Property ConvContactId() As Nullable(of Decimal)
			Get
				Return Me._ConvContactId
			End Get
			Set(ByVal value As Nullable(of Decimal))
					If (Object.Equals(Me.ConvContactId, value) <> true) Then				    
						Me._ConvContactId = value
						OnPropertyChanged("ConvContactId")
				    End If 
			End Set
		End Property

Private _ConvOrganizeId As Nullable(of Decimal)
		<DataMember(),DataField("CONV_ORGANIZE_ID")> _
		Public Property ConvOrganizeId() As Nullable(of Decimal)
			Get
				Return Me._ConvOrganizeId
			End Get
			Set(ByVal value As Nullable(of Decimal))
					If (Object.Equals(Me.ConvOrganizeId, value) <> true) Then				    
						Me._ConvOrganizeId = value
						OnPropertyChanged("ConvOrganizeId")
				    End If 
			End Set
		End Property

Private _ConvOppId As Nullable(of Decimal)
		<DataMember(),DataField("CONV_OPP_ID")> _
		Public Property ConvOppId() As Nullable(of Decimal)
			Get
				Return Me._ConvOppId
			End Get
			Set(ByVal value As Nullable(of Decimal))
					If (Object.Equals(Me.ConvOppId, value) <> true) Then				    
						Me._ConvOppId = value
						OnPropertyChanged("ConvOppId")
				    End If 
			End Set
		End Property

Private _LeadSt As String
		<DataMember(),DataField("LEAD_ST")> _
		Public Property LeadSt() As String
			Get
				Return Me._LeadSt
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.LeadSt, value) <> true) Then				    
						Me._LeadSt = value
						OnPropertyChanged("LeadSt")
				    End If 
			End Set
		End Property

Private _Title As String
		<DataMember(),DataField("TITLE")> _
		Public Property Title() As String
			Get
				Return Me._Title
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Title, value) <> true) Then				    
						Me._Title = value
						OnPropertyChanged("Title")
				    End If 
			End Set
		End Property

Private _FirstnameLoc As String
		<DataMember(),DataField("FIRSTNAME_LOC")> _
		Public Property FirstnameLoc() As String
			Get
				Return Me._FirstnameLoc
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.FirstnameLoc, value) <> true) Then				    
						Me._FirstnameLoc = value
						OnPropertyChanged("FirstnameLoc")
				    End If 
			End Set
		End Property

Private _LastnameLoc As String
		<DataMember(),DataField("LASTNAME_LOC")> _
		Public Property LastnameLoc() As String
			Get
				Return Me._LastnameLoc
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.LastnameLoc, value) <> true) Then				    
						Me._LastnameLoc = value
						OnPropertyChanged("LastnameLoc")
				    End If 
			End Set
		End Property

Private _FirstnameOth As String
		<DataMember(),DataField("FIRSTNAME_OTH")> _
		Public Property FirstnameOth() As String
			Get
				Return Me._FirstnameOth
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.FirstnameOth, value) <> true) Then				    
						Me._FirstnameOth = value
						OnPropertyChanged("FirstnameOth")
				    End If 
			End Set
		End Property

Private _LastnameOth As String
		<DataMember(),DataField("LASTNAME_OTH")> _
		Public Property LastnameOth() As String
			Get
				Return Me._LastnameOth
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.LastnameOth, value) <> true) Then				    
						Me._LastnameOth = value
						OnPropertyChanged("LastnameOth")
				    End If 
			End Set
		End Property

Private _NameLoc As String
		<DataMember(),DataField("NAME_LOC")> _
		Public Property NameLoc() As String
			Get
				Return Me._NameLoc
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.NameLoc, value) <> true) Then				    
						Me._NameLoc = value
						OnPropertyChanged("NameLoc")
				    End If 
			End Set
		End Property

Private _NameOth As String
		<DataMember(),DataField("NAME_OTH")> _
		Public Property NameOth() As String
			Get
				Return Me._NameOth
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.NameOth, value) <> true) Then				    
						Me._NameOth = value
						OnPropertyChanged("NameOth")
				    End If 
			End Set
		End Property

Private _Birthdate As Nullable(of DateTime)
		<DataMember(),DataField("BIRTHDATE")> _
		Public Property Birthdate() As Nullable(of DateTime)
			Get
				Return Me._Birthdate
			End Get
			Set(ByVal value As Nullable(of DateTime))
					If (Object.Equals(Me.Birthdate, value) <> true) Then				    
						Me._Birthdate = value
						OnPropertyChanged("Birthdate")
				    End If 
			End Set
		End Property

Private _RegisterDt As Nullable(of DateTime)
		<DataMember(),DataField("REGISTER_DT")> _
		Public Property RegisterDt() As Nullable(of DateTime)
			Get
				Return Me._RegisterDt
			End Get
			Set(ByVal value As Nullable(of DateTime))
					If (Object.Equals(Me.RegisterDt, value) <> true) Then				    
						Me._RegisterDt = value
						OnPropertyChanged("RegisterDt")
				    End If 
			End Set
		End Property

Private _ConvertDt As Nullable(of DateTime)
		<DataMember(),DataField("CONVERT_DT")> _
		Public Property ConvertDt() As Nullable(of DateTime)
			Get
				Return Me._ConvertDt
			End Get
			Set(ByVal value As Nullable(of DateTime))
					If (Object.Equals(Me.ConvertDt, value) <> true) Then				    
						Me._ConvertDt = value
						OnPropertyChanged("ConvertDt")
				    End If 
			End Set
		End Property

Private _LeadSource As String
		<DataMember(),DataField("LEAD_SOURCE")> _
		Public Property LeadSource() As String
			Get
				Return Me._LeadSource
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.LeadSource, value) <> true) Then				    
						Me._LeadSource = value
						OnPropertyChanged("LeadSource")
				    End If 
			End Set
		End Property

Private _AssignCat As String
		<DataMember(),DataField("ASSIGN_CAT")> _
		Public Property AssignCat() As String
			Get
				Return Me._AssignCat
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.AssignCat, value) <> true) Then				    
						Me._AssignCat = value
						OnPropertyChanged("AssignCat")
				    End If 
			End Set
		End Property

Private _AssignId As String
		<DataMember(),DataField("ASSIGN_ID")> _
		Public Property AssignId() As String
			Get
				Return Me._AssignId
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.AssignId, value) <> true) Then				    
						Me._AssignId = value
						OnPropertyChanged("AssignId")
				    End If 
			End Set
		End Property

Private _Company As String
		<DataMember(),DataField("COMPANY")> _
		Public Property Company() As String
			Get
				Return Me._Company
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Company, value) <> true) Then				    
						Me._Company = value
						OnPropertyChanged("Company")
				    End If 
			End Set
		End Property

Private _AnnualRevenue As Nullable(of Decimal)
		<DataMember(),DataField("ANNUAL_REVENUE")> _
		Public Property AnnualRevenue() As Nullable(of Decimal)
			Get
				Return Me._AnnualRevenue
			End Get
			Set(ByVal value As Nullable(of Decimal))
					If (Object.Equals(Me.AnnualRevenue, value) <> true) Then				    
						Me._AnnualRevenue = value
						OnPropertyChanged("AnnualRevenue")
				    End If 
			End Set
		End Property

Private _NumOfEmp As Nullable(of Decimal)
		<DataMember(),DataField("NUM_OF_EMP")> _
		Public Property NumOfEmp() As Nullable(of Decimal)
			Get
				Return Me._NumOfEmp
			End Get
			Set(ByVal value As Nullable(of Decimal))
					If (Object.Equals(Me.NumOfEmp, value) <> true) Then				    
						Me._NumOfEmp = value
						OnPropertyChanged("NumOfEmp")
				    End If 
			End Set
		End Property

Private _Address As String
		<DataMember(),DataField("ADDRESS")> _
		Public Property Address() As String
			Get
				Return Me._Address
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Address, value) <> true) Then				    
						Me._Address = value
						OnPropertyChanged("Address")
				    End If 
			End Set
		End Property

Private _Subdistrict As String
		<DataMember(),DataField("SUBDISTRICT")> _
		Public Property Subdistrict() As String
			Get
				Return Me._Subdistrict
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Subdistrict, value) <> true) Then				    
						Me._Subdistrict = value
						OnPropertyChanged("Subdistrict")
				    End If 
			End Set
		End Property

Private _District As String
		<DataMember(),DataField("DISTRICT")> _
		Public Property District() As String
			Get
				Return Me._District
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.District, value) <> true) Then				    
						Me._District = value
						OnPropertyChanged("District")
				    End If 
			End Set
		End Property

Private _City As String
		<DataMember(),DataField("CITY")> _
		Public Property City() As String
			Get
				Return Me._City
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.City, value) <> true) Then				    
						Me._City = value
						OnPropertyChanged("City")
				    End If 
			End Set
		End Property

Private _State As String
		<DataMember(),DataField("STATE")> _
		Public Property State() As String
			Get
				Return Me._State
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.State, value) <> true) Then				    
						Me._State = value
						OnPropertyChanged("State")
				    End If 
			End Set
		End Property

Private _Country As String
		<DataMember(),DataField("COUNTRY")> _
		Public Property Country() As String
			Get
				Return Me._Country
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Country, value) <> true) Then				    
						Me._Country = value
						OnPropertyChanged("Country")
				    End If 
			End Set
		End Property

Private _Postalcode As String
		<DataMember(),DataField("POSTALCODE")> _
		Public Property Postalcode() As String
			Get
				Return Me._Postalcode
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Postalcode, value) <> true) Then				    
						Me._Postalcode = value
						OnPropertyChanged("Postalcode")
				    End If 
			End Set
		End Property

Private _PhoneHome As String
		<DataMember(),DataField("PHONE_HOME")> _
		Public Property PhoneHome() As String
			Get
				Return Me._PhoneHome
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.PhoneHome, value) <> true) Then				    
						Me._PhoneHome = value
						OnPropertyChanged("PhoneHome")
				    End If 
			End Set
		End Property

Private _PhoneMobile As String
		<DataMember(),DataField("PHONE_MOBILE")> _
		Public Property PhoneMobile() As String
			Get
				Return Me._PhoneMobile
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.PhoneMobile, value) <> true) Then				    
						Me._PhoneMobile = value
						OnPropertyChanged("PhoneMobile")
				    End If 
			End Set
		End Property

Private _PhoneOffice As String
		<DataMember(),DataField("PHONE_OFFICE")> _
		Public Property PhoneOffice() As String
			Get
				Return Me._PhoneOffice
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.PhoneOffice, value) <> true) Then				    
						Me._PhoneOffice = value
						OnPropertyChanged("PhoneOffice")
				    End If 
			End Set
		End Property

Private _PhoneFax As String
		<DataMember(),DataField("PHONE_FAX")> _
		Public Property PhoneFax() As String
			Get
				Return Me._PhoneFax
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.PhoneFax, value) <> true) Then				    
						Me._PhoneFax = value
						OnPropertyChanged("PhoneFax")
				    End If 
			End Set
		End Property

Private _Email As String
		<DataMember(),DataField("EMAIL")> _
		Public Property Email() As String
			Get
				Return Me._Email
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Email, value) <> true) Then				    
						Me._Email = value
						OnPropertyChanged("Email")
				    End If 
			End Set
		End Property

Private _PhotoUrl As String
		<DataMember(),DataField("PHOTO_URL")> _
		Public Property PhotoUrl() As String
			Get
				Return Me._PhotoUrl
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.PhotoUrl, value) <> true) Then				    
						Me._PhotoUrl = value
						OnPropertyChanged("PhotoUrl")
				    End If 
			End Set
		End Property

Private _Rating As Nullable(of Decimal)
		<DataMember(),DataField("RATING")> _
		Public Property Rating() As Nullable(of Decimal)
			Get
				Return Me._Rating
			End Get
			Set(ByVal value As Nullable(of Decimal))
					If (Object.Equals(Me.Rating, value) <> true) Then				    
						Me._Rating = value
						OnPropertyChanged("Rating")
				    End If 
			End Set
		End Property

Private _Descr As String
		<DataMember(),DataField("DESCR")> _
		Public Property Descr() As String
			Get
				Return Me._Descr
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Descr, value) <> true) Then				    
						Me._Descr = value
						OnPropertyChanged("Descr")
				    End If 
			End Set
		End Property

Private _Iscontacted As String
		<DataMember(),DataField("ISCONTACTED")> _
		Public Property Iscontacted() As String
			Get
				Return Me._Iscontacted
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Iscontacted, value) <> true) Then				    
						Me._Iscontacted = value
						OnPropertyChanged("Iscontacted")
				    End If 
			End Set
		End Property

Private _Isconvert As String
		<DataMember(),DataField("ISCONVERT")> _
		Public Property Isconvert() As String
			Get
				Return Me._Isconvert
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Isconvert, value) <> true) Then				    
						Me._Isconvert = value
						OnPropertyChanged("Isconvert")
				    End If 
			End Set
		End Property

Private _Isdeleted As String
		<DataMember(),DataField("ISDELETED")> _
		Public Property Isdeleted() As String
			Get
				Return Me._Isdeleted
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Isdeleted, value) <> true) Then				    
						Me._Isdeleted = value
						OnPropertyChanged("Isdeleted")
				    End If 
			End Set
		End Property

Private _AId As Nullable(of Decimal)
		<DataMember(),DataField("A_ID")> _
		Public Property AId() As Nullable(of Decimal)
			Get
				Return Me._AId
			End Get
			Set(ByVal value As Nullable(of Decimal))
					If (Object.Equals(Me.AId, value) <> true) Then				    
						Me._AId = value
						OnPropertyChanged("AId")
				    End If 
			End Set
		End Property

Private _VisibileType As String
		<DataMember(),DataField("VISIBILE_TYPE")> _
		Public Property VisibileType() As String
			Get
				Return Me._VisibileType
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.VisibileType, value) <> true) Then				    
						Me._VisibileType = value
						OnPropertyChanged("VisibileType")
				    End If 
			End Set
		End Property

Private _VisibileCd As String
		<DataMember(),DataField("VISIBILE_CD")> _
		Public Property VisibileCd() As String
			Get
				Return Me._VisibileCd
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.VisibileCd, value) <> true) Then				    
						Me._VisibileCd = value
						OnPropertyChanged("VisibileCd")
				    End If 
			End Set
		End Property

Private _RefSapcode As String
		<DataMember(),DataField("REF_SAPCODE")> _
		Public Property RefSapcode() As String
			Get
				Return Me._RefSapcode
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.RefSapcode, value) <> true) Then				    
						Me._RefSapcode = value
						OnPropertyChanged("RefSapcode")
				    End If 
			End Set
		End Property

Private _RefMdm As String
		<DataMember(),DataField("REF_MDM")> _
		Public Property RefMdm() As String
			Get
				Return Me._RefMdm
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.RefMdm, value) <> true) Then				    
						Me._RefMdm = value
						OnPropertyChanged("RefMdm")
				    End If 
			End Set
		End Property

Private _Createuser As String
		<DataMember(),DataField("CREATEUSER")> _
		Public Property Createuser() As String
			Get
				Return Me._Createuser
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Createuser, value) <> true) Then				    
						Me._Createuser = value
						OnPropertyChanged("Createuser")
				    End If 
			End Set
		End Property

Private _Createdate As Nullable(of DateTime)
		<DataMember(),DataField("CREATEDATE")> _
		Public Property Createdate() As Nullable(of DateTime)
			Get
				Return Me._Createdate
			End Get
			Set(ByVal value As Nullable(of DateTime))
					If (Object.Equals(Me.Createdate, value) <> true) Then				    
						Me._Createdate = value
						OnPropertyChanged("Createdate")
				    End If 
			End Set
		End Property

Private _Modifyuser As String
		<DataMember(),DataField("MODIFYUSER")> _
		Public Property Modifyuser() As String
			Get
				Return Me._Modifyuser
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Modifyuser, value) <> true) Then				    
						Me._Modifyuser = value
						OnPropertyChanged("Modifyuser")
				    End If 
			End Set
		End Property

Private _Modifydate As Nullable(of DateTime)
		<DataMember(),DataField("MODIFYDATE")> _
		Public Property Modifydate() As Nullable(of DateTime)
			Get
				Return Me._Modifydate
			End Get
			Set(ByVal value As Nullable(of DateTime))
					If (Object.Equals(Me.Modifydate, value) <> true) Then				    
						Me._Modifydate = value
						OnPropertyChanged("Modifydate")
				    End If 
			End Set
		End Property

Private _Programcode As String
		<DataMember(),DataField("PROGRAMCODE")> _
		Public Property Programcode() As String
			Get
				Return Me._Programcode
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Programcode, value) <> true) Then				    
						Me._Programcode = value
						OnPropertyChanged("Programcode")
				    End If 
			End Set
		End Property


	
	 
        Public Function Equals1(ByVal other As CrmLeads) As Boolean Implements System.IEquatable(Of CrmLeads).Equals
           
           if Me.LeadId <> other.LeadId Then
                Return False
            End If


             Return True
        End Function
        
         Public Overrides Function GetHashCode() As Integer
            Return GetHashValue(LeadId)
        End Function
	
End Class

End Namespace