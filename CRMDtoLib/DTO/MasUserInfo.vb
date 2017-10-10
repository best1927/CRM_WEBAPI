Imports SsCommon
Imports System.ComponentModel
Imports System.Runtime.Serialization

Namespace DTO

<DataContract(),Table("MAS_USER_INFO")> _
Public Class MasUserInfo
    Inherits BaseDto
    Implements IEquatable(Of MasUserInfo)
         
	 
   	Private _UserId As String
		<DataMember(),DataField("USER_ID"),DataAnnotations.Key(), DataAnnotations.Required(AllowEmptyStrings:=False)> _
		Public Property UserId() As String
			Get
				Return Me._UserId
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.UserId, value) <> true) Then
						Me._UserId = value
						OnPropertyChanged("UserId")
					End If  
			End Set
		End Property


	
	Private _PhoneNo As String
		<DataMember(),DataField("PHONE_NO")> _
		Public Property PhoneNo() As String
			Get
				Return Me._PhoneNo
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.PhoneNo, value) <> true) Then				    
						Me._PhoneNo = value
						OnPropertyChanged("PhoneNo")
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

Private _Cca As String
		<DataMember(),DataField("CCA")> _
		Public Property Cca() As String
			Get
				Return Me._Cca
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Cca, value) <> true) Then				    
						Me._Cca = value
						OnPropertyChanged("Cca")
				    End If 
			End Set
		End Property

Private _CcaServicekey As String
		<DataMember(),DataField("CCA_SERVICEKEY")> _
		Public Property CcaServicekey() As String
			Get
				Return Me._CcaServicekey
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.CcaServicekey, value) <> true) Then				    
						Me._CcaServicekey = value
						OnPropertyChanged("CcaServicekey")
				    End If 
			End Set
		End Property

Private _UserCreate As String
		<DataMember(),DataField("USER_CREATE")> _
		Public Property UserCreate() As String
			Get
				Return Me._UserCreate
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.UserCreate, value) <> true) Then				    
						Me._UserCreate = value
						OnPropertyChanged("UserCreate")
				    End If 
			End Set
		End Property

Private _CreateDate As Nullable(of DateTime)
		<DataMember(),DataField("CREATE_DATE")> _
		Public Property CreateDate() As Nullable(of DateTime)
			Get
				Return Me._CreateDate
			End Get
			Set(ByVal value As Nullable(of DateTime))
					If (Object.Equals(Me.CreateDate, value) <> true) Then				    
						Me._CreateDate = value
						OnPropertyChanged("CreateDate")
				    End If 
			End Set
		End Property

Private _LastUserId As String
		<DataMember(),DataField("LAST_USER_ID")> _
		Public Property LastUserId() As String
			Get
				Return Me._LastUserId
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.LastUserId, value) <> true) Then				    
						Me._LastUserId = value
						OnPropertyChanged("LastUserId")
				    End If 
			End Set
		End Property

Private _LastUpdateDate As Nullable(of DateTime)
		<DataMember(),DataField("LAST_UPDATE_DATE")> _
		Public Property LastUpdateDate() As Nullable(of DateTime)
			Get
				Return Me._LastUpdateDate
			End Get
			Set(ByVal value As Nullable(of DateTime))
					If (Object.Equals(Me.LastUpdateDate, value) <> true) Then				    
						Me._LastUpdateDate = value
						OnPropertyChanged("LastUpdateDate")
				    End If 
			End Set
		End Property

Private _LastFunction As String
		<DataMember(),DataField("LAST_FUNCTION")> _
		Public Property LastFunction() As String
			Get
				Return Me._LastFunction
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.LastFunction, value) <> true) Then				    
						Me._LastFunction = value
						OnPropertyChanged("LastFunction")
				    End If 
			End Set
		End Property

Private _Signature As Byte()
		<DataMember(),DataField("SIGNATURE")> _
		Public Property Signature() As Byte()
			Get
				Return Me._Signature
			End Get
			Set(ByVal value As Byte())
					If (Object.ReferenceEquals(Me.Signature, value) <> true) Then				    
						Me._Signature = value
						OnPropertyChanged("Signature")
				    End If 
			End Set
		End Property


	
	 
        Public Function Equals1(ByVal other As MasUserInfo) As Boolean Implements System.IEquatable(Of MasUserInfo).Equals
           
           if Me.UserId <> other.UserId Then
                Return False
            End If


             Return True
        End Function
        
         Public Overrides Function GetHashCode() As Integer
            Return GetHashValue(UserId)
        End Function
	
End Class

End Namespace