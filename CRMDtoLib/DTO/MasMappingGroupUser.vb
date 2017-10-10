Imports SsCommon
Imports System.ComponentModel
Imports System.Runtime.Serialization

Namespace DTO

<DataContract(),Table("MAS_MAPPING_GROUP_USER")> _
Public Class MasMappingGroupUser
    Inherits BaseDto
    Implements IEquatable(Of MasMappingGroupUser)
         
	 
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

Private _GroupId As String
		<DataMember(),DataField("GROUP_ID"),DataAnnotations.Key(), DataAnnotations.Required(AllowEmptyStrings:=False)> _
		Public Property GroupId() As String
			Get
				Return Me._GroupId
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.GroupId, value) <> true) Then
						Me._GroupId = value
						OnPropertyChanged("GroupId")
					End If  
			End Set
		End Property

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


	
	 
        Public Function Equals1(ByVal other As MasMappingGroupUser) As Boolean Implements System.IEquatable(Of MasMappingGroupUser).Equals
           
           if Me.OrgCode <> other.OrgCode Then
                Return False
            End If

if Me.GroupId <> other.GroupId Then
                Return False
            End If

if Me.UserId <> other.UserId Then
                Return False
            End If


             Return True
        End Function
        
         Public Overrides Function GetHashCode() As Integer
            Return GetHashValue(OrgCode) Xor GetHashValue(GroupId) Xor GetHashValue(UserId)
        End Function
	
End Class

End Namespace