Imports SsCommon
Imports System.ComponentModel
Imports System.Runtime.Serialization

Namespace DTO

<DataContract(),Table("CRM_MAS_TEAM")> _
Public Class CrmMasTeam
    Inherits BaseDto
    Implements IEquatable(Of CrmMasTeam)
         
	 
   	Private _TeamId As String
		<DataMember(),DataField("TEAM_ID"),DataAnnotations.Key(), DataAnnotations.Required(AllowEmptyStrings:=False)> _
		Public Property TeamId() As String
			Get
				Return Me._TeamId
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.TeamId, value) <> true) Then
						Me._TeamId = value
						OnPropertyChanged("TeamId")
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

Private _TeamSt As String
		<DataMember(),DataField("TEAM_ST")> _
		Public Property TeamSt() As String
			Get
				Return Me._TeamSt
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.TeamSt, value) <> true) Then				    
						Me._TeamSt = value
						OnPropertyChanged("TeamSt")
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

Private _Remarks As String
		<DataMember(),DataField("REMARKS")> _
		Public Property Remarks() As String
			Get
				Return Me._Remarks
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Remarks, value) <> true) Then				    
						Me._Remarks = value
						OnPropertyChanged("Remarks")
				    End If 
			End Set
		End Property

Private _TeamUserRole As String
		<DataMember(),DataField("TEAM_USER_ROLE")> _
		Public Property TeamUserRole() As String
			Get
				Return Me._TeamUserRole
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.TeamUserRole, value) <> true) Then				    
						Me._TeamUserRole = value
						OnPropertyChanged("TeamUserRole")
				    End If 
			End Set
		End Property


	
	 
        Public Function Equals1(ByVal other As CrmMasTeam) As Boolean Implements System.IEquatable(Of CrmMasTeam).Equals
           
           if Me.TeamId <> other.TeamId Then
                Return False
            End If

if Me.UserId <> other.UserId Then
                Return False
            End If


             Return True
        End Function
        
         Public Overrides Function GetHashCode() As Integer
            Return GetHashValue(TeamId) Xor GetHashValue(UserId)
        End Function
	
End Class

End Namespace