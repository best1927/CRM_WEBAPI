Imports SsCommon
Imports System.ComponentModel
Imports System.Runtime.Serialization

Namespace DTO

<DataContract(),Table("CRM_ORGANIZATION")> _
Public Class CrmOrganization
    Inherits BaseDto
    Implements IEquatable(Of CrmOrganization)
         
	 
   	Private _OrganizeId As Decimal
		<DataMember(),DataField("ORGANIZE_ID"),DataAnnotations.Key()> _
		Public Property OrganizeId() As Decimal
			Get
				Return Me._OrganizeId
			End Get
			Set(ByVal value As Decimal)
					If (Object.ReferenceEquals(Me.OrganizeId, value) <> true) Then
						Me._OrganizeId = value
						OnPropertyChanged("OrganizeId")
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

Private _OrganizeSt As String
		<DataMember(),DataField("ORGANIZE_ST")> _
		Public Property OrganizeSt() As String
			Get
				Return Me._OrganizeSt
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.OrganizeSt, value) <> true) Then				    
						Me._OrganizeSt = value
						OnPropertyChanged("OrganizeSt")
				    End If 
			End Set
		End Property

Private _DescrLoc As String
		<DataMember(),DataField("DESCR_LOC")> _
		Public Property DescrLoc() As String
			Get
				Return Me._DescrLoc
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.DescrLoc, value) <> true) Then				    
						Me._DescrLoc = value
						OnPropertyChanged("DescrLoc")
				    End If 
			End Set
		End Property

Private _DescrOth As String
		<DataMember(),DataField("DESCR_OTH")> _
		Public Property DescrOth() As String
			Get
				Return Me._DescrOth
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.DescrOth, value) <> true) Then				    
						Me._DescrOth = value
						OnPropertyChanged("DescrOth")
				    End If 
			End Set
		End Property

Private _OrganizeUrl As String
		<DataMember(),DataField("ORGANIZE_URL")> _
		Public Property OrganizeUrl() As String
			Get
				Return Me._OrganizeUrl
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.OrganizeUrl, value) <> true) Then				    
						Me._OrganizeUrl = value
						OnPropertyChanged("OrganizeUrl")
				    End If 
			End Set
		End Property

Private _OrganizeType As String
		<DataMember(),DataField("ORGANIZE_TYPE")> _
		Public Property OrganizeType() As String
			Get
				Return Me._OrganizeType
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.OrganizeType, value) <> true) Then				    
						Me._OrganizeType = value
						OnPropertyChanged("OrganizeType")
				    End If 
			End Set
		End Property

Private _CorporateDt As Nullable(of DateTime)
		<DataMember(),DataField("CORPORATE_DT")> _
		Public Property CorporateDt() As Nullable(of DateTime)
			Get
				Return Me._CorporateDt
			End Get
			Set(ByVal value As Nullable(of DateTime))
					If (Object.Equals(Me.CorporateDt, value) <> true) Then				    
						Me._CorporateDt = value
						OnPropertyChanged("CorporateDt")
				    End If 
			End Set
		End Property

Private _NotifyYn As String
		<DataMember(),DataField("NOTIFY_YN")> _
		Public Property NotifyYn() As String
			Get
				Return Me._NotifyYn
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.NotifyYn, value) <> true) Then				    
						Me._NotifyYn = value
						OnPropertyChanged("NotifyYn")
				    End If 
			End Set
		End Property

Private _Schedule As String
		<DataMember(),DataField("SCHEDULE")> _
		Public Property Schedule() As String
			Get
				Return Me._Schedule
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Schedule, value) <> true) Then				    
						Me._Schedule = value
						OnPropertyChanged("Schedule")
				    End If 
			End Set
		End Property

Private _OrganizeDt As Nullable(of DateTime)
		<DataMember(),DataField("ORGANIZE_DT")> _
		Public Property OrganizeDt() As Nullable(of DateTime)
			Get
				Return Me._OrganizeDt
			End Get
			Set(ByVal value As Nullable(of DateTime))
					If (Object.Equals(Me.OrganizeDt, value) <> true) Then				    
						Me._OrganizeDt = value
						OnPropertyChanged("OrganizeDt")
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

Private _AddLat As String
		<DataMember(),DataField("ADD_LAT")> _
		Public Property AddLat() As String
			Get
				Return Me._AddLat
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.AddLat, value) <> true) Then				    
						Me._AddLat = value
						OnPropertyChanged("AddLat")
				    End If 
			End Set
		End Property

Private _AddLong As String
		<DataMember(),DataField("ADD_LONG")> _
		Public Property AddLong() As String
			Get
				Return Me._AddLong
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.AddLong, value) <> true) Then				    
						Me._AddLong = value
						OnPropertyChanged("AddLong")
				    End If 
			End Set
		End Property

Private _BillAddress As String
		<DataMember(),DataField("BILL_ADDRESS")> _
		Public Property BillAddress() As String
			Get
				Return Me._BillAddress
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.BillAddress, value) <> true) Then				    
						Me._BillAddress = value
						OnPropertyChanged("BillAddress")
				    End If 
			End Set
		End Property

Private _BillSubdistrict As String
		<DataMember(),DataField("BILL_SUBDISTRICT")> _
		Public Property BillSubdistrict() As String
			Get
				Return Me._BillSubdistrict
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.BillSubdistrict, value) <> true) Then				    
						Me._BillSubdistrict = value
						OnPropertyChanged("BillSubdistrict")
				    End If 
			End Set
		End Property

Private _BillDistrict As String
		<DataMember(),DataField("BILL_DISTRICT")> _
		Public Property BillDistrict() As String
			Get
				Return Me._BillDistrict
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.BillDistrict, value) <> true) Then				    
						Me._BillDistrict = value
						OnPropertyChanged("BillDistrict")
				    End If 
			End Set
		End Property

Private _BillCity As String
		<DataMember(),DataField("BILL_CITY")> _
		Public Property BillCity() As String
			Get
				Return Me._BillCity
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.BillCity, value) <> true) Then				    
						Me._BillCity = value
						OnPropertyChanged("BillCity")
				    End If 
			End Set
		End Property

Private _BillState As String
		<DataMember(),DataField("BILL_STATE")> _
		Public Property BillState() As String
			Get
				Return Me._BillState
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.BillState, value) <> true) Then				    
						Me._BillState = value
						OnPropertyChanged("BillState")
				    End If 
			End Set
		End Property

Private _BillCountry As String
		<DataMember(),DataField("BILL_COUNTRY")> _
		Public Property BillCountry() As String
			Get
				Return Me._BillCountry
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.BillCountry, value) <> true) Then				    
						Me._BillCountry = value
						OnPropertyChanged("BillCountry")
				    End If 
			End Set
		End Property

Private _BillPostalcode As String
		<DataMember(),DataField("BILL_POSTALCODE")> _
		Public Property BillPostalcode() As String
			Get
				Return Me._BillPostalcode
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.BillPostalcode, value) <> true) Then				    
						Me._BillPostalcode = value
						OnPropertyChanged("BillPostalcode")
				    End If 
			End Set
		End Property

Private _BillLat As String
		<DataMember(),DataField("BILL_LAT")> _
		Public Property BillLat() As String
			Get
				Return Me._BillLat
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.BillLat, value) <> true) Then				    
						Me._BillLat = value
						OnPropertyChanged("BillLat")
				    End If 
			End Set
		End Property

Private _BillLong As String
		<DataMember(),DataField("BILL_LONG")> _
		Public Property BillLong() As String
			Get
				Return Me._BillLong
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.BillLong, value) <> true) Then				    
						Me._BillLong = value
						OnPropertyChanged("BillLong")
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


	
	 
        Public Function Equals1(ByVal other As CrmOrganization) As Boolean Implements System.IEquatable(Of CrmOrganization).Equals
           
           if Me.OrganizeId <> other.OrganizeId Then
                Return False
            End If


             Return True
        End Function
        
         Public Overrides Function GetHashCode() As Integer
            Return GetHashValue(OrganizeId)
        End Function
	
End Class

End Namespace