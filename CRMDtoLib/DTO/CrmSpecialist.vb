Imports SsCommon
Imports System.ComponentModel
Imports System.Runtime.Serialization

Namespace DTO

<DataContract(),Table("CRM_SPECIALIST")> _
Public Class CrmSpecialist
    Inherits BaseDto
    Implements IEquatable(Of CrmSpecialist)
         
	 
   	Private _SpecialistId As Decimal
		<DataMember(),DataField("SPECIALIST_ID"),DataAnnotations.Key()> _
		Public Property SpecialistId() As Decimal
			Get
				Return Me._SpecialistId
			End Get
			Set(ByVal value As Decimal)
					If (Object.ReferenceEquals(Me.SpecialistId, value) <> true) Then
						Me._SpecialistId = value
						OnPropertyChanged("SpecialistId")
					End If  
			End Set
		End Property


	
	Private _OwnerCat As String
		<DataMember(),DataField("OWNER_CAT")> _
		Public Property OwnerCat() As String
			Get
				Return Me._OwnerCat
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.OwnerCat, value) <> true) Then				    
						Me._OwnerCat = value
						OnPropertyChanged("OwnerCat")
				    End If 
			End Set
		End Property

Private _OwnerId As Nullable(of Decimal)
		<DataMember(),DataField("OWNER_ID")> _
		Public Property OwnerId() As Nullable(of Decimal)
			Get
				Return Me._OwnerId
			End Get
			Set(ByVal value As Nullable(of Decimal))
					If (Object.Equals(Me.OwnerId, value) <> true) Then				    
						Me._OwnerId = value
						OnPropertyChanged("OwnerId")
				    End If 
			End Set
		End Property

Private _SpecialistSt As String
		<DataMember(),DataField("SPECIALIST_ST")> _
		Public Property SpecialistSt() As String
			Get
				Return Me._SpecialistSt
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.SpecialistSt, value) <> true) Then				    
						Me._SpecialistSt = value
						OnPropertyChanged("SpecialistSt")
				    End If 
			End Set
		End Property

Private _SpecialistType As String
		<DataMember(),DataField("SPECIALIST_TYPE")> _
		Public Property SpecialistType() As String
			Get
				Return Me._SpecialistType
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.SpecialistType, value) <> true) Then				    
						Me._SpecialistType = value
						OnPropertyChanged("SpecialistType")
				    End If 
			End Set
		End Property

Private _TitleCode As String
		<DataMember(),DataField("TITLE_CODE")> _
		Public Property TitleCode() As String
			Get
				Return Me._TitleCode
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.TitleCode, value) <> true) Then				    
						Me._TitleCode = value
						OnPropertyChanged("TitleCode")
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

Private _JobCode As String
		<DataMember(),DataField("JOB_CODE")> _
		Public Property JobCode() As String
			Get
				Return Me._JobCode
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.JobCode, value) <> true) Then				    
						Me._JobCode = value
						OnPropertyChanged("JobCode")
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

Private _Priority As String
		<DataMember(),DataField("PRIORITY")> _
		Public Property Priority() As String
			Get
				Return Me._Priority
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Priority, value) <> true) Then				    
						Me._Priority = value
						OnPropertyChanged("Priority")
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


	
	 
        Public Function Equals1(ByVal other As CrmSpecialist) As Boolean Implements System.IEquatable(Of CrmSpecialist).Equals
           
           if Me.SpecialistId <> other.SpecialistId Then
                Return False
            End If


             Return True
        End Function
        
         Public Overrides Function GetHashCode() As Integer
            Return GetHashValue(SpecialistId)
        End Function
	
End Class

End Namespace