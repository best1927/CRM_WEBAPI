Imports SsCommon
Imports System.ComponentModel
Imports System.Runtime.Serialization

Namespace DTO

<DataContract(),Table("MAS_GROUP_USER")> _
Public Class MasGroupUser
    Inherits BaseDto
    Implements IEquatable(Of MasGroupUser)
         
	 
   	Private _OrgCode As String
		<DataMember(),DataField("ORG_CODE"),DataAnnotations.Key(), DataAnnotations.Required(AllowEmptyStrings:=False)> _
		Public Property OrgCode() As String
			Get
				Return Me._OrgCode
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.OrgCode, value) <> true) Then
						Me._OrgCode = value
						OnPropertyChanged("OrgCode")
					End If  
			End Set
		End Property

Private _GroupUser As String
		<DataMember(),DataField("GROUP_USER"),DataAnnotations.Key(), DataAnnotations.Required(AllowEmptyStrings:=False)> _
		Public Property GroupUser() As String
			Get
				Return Me._GroupUser
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.GroupUser, value) <> true) Then
						Me._GroupUser = value
						OnPropertyChanged("GroupUser")
					End If  
			End Set
		End Property


	
	Private _DescEng As String
		<DataMember(),DataField("DESC_ENG")> _
		Public Property DescEng() As String
			Get
				Return Me._DescEng
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.DescEng, value) <> true) Then				    
						Me._DescEng = value
						OnPropertyChanged("DescEng")
				    End If 
			End Set
		End Property

Private _DescLoc As String
		<DataMember(),DataField("DESC_LOC")> _
		Public Property DescLoc() As String
			Get
				Return Me._DescLoc
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.DescLoc, value) <> true) Then				    
						Me._DescLoc = value
						OnPropertyChanged("DescLoc")
				    End If 
			End Set
		End Property

Private _Status As String
		<DataMember(),DataField("STATUS")> _
		Public Property Status() As String
			Get
				Return Me._Status
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Status, value) <> true) Then				    
						Me._Status = value
						OnPropertyChanged("Status")
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

Private _CancelFlag As String
		<DataMember(),DataField("CANCEL_FLAG")> _
		Public Property CancelFlag() As String
			Get
				Return Me._CancelFlag
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.CancelFlag, value) <> true) Then				    
						Me._CancelFlag = value
						OnPropertyChanged("CancelFlag")
				    End If 
			End Set
		End Property


	
	 
        Public Function Equals1(ByVal other As MasGroupUser) As Boolean Implements System.IEquatable(Of MasGroupUser).Equals
           
           if Me.OrgCode <> other.OrgCode Then
                Return False
            End If

if Me.GroupUser <> other.GroupUser Then
                Return False
            End If


             Return True
        End Function
        
         Public Overrides Function GetHashCode() As Integer
            Return GetHashValue(OrgCode) Xor GetHashValue(GroupUser)
        End Function
	
End Class

End Namespace