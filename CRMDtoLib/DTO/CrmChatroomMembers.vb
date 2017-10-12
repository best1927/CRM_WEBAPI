Imports SsCommon
Imports System.ComponentModel
Imports System.Runtime.Serialization

Namespace DTO

<DataContract(),Table("CRM_CHATROOM_MEMBERS")> _
Public Class CrmChatroomMembers
    Inherits BaseDto
    Implements IEquatable(Of CrmChatroomMembers)
         
	 
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

Private _ChatroomId As Decimal
		<DataMember(),DataField("CHATROOM_ID"),DataAnnotations.Key()> _
		Public Property ChatroomId() As Decimal
			Get
				Return Me._ChatroomId
			End Get
			Set(ByVal value As Decimal)
					If (Object.ReferenceEquals(Me.ChatroomId, value) <> true) Then
						Me._ChatroomId = value
						OnPropertyChanged("ChatroomId")
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

Private _Isleaved As String
		<DataMember(),DataField("ISLEAVED")> _
		Public Property Isleaved() As String
			Get
				Return Me._Isleaved
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Isleaved, value) <> true) Then				    
						Me._Isleaved = value
						OnPropertyChanged("Isleaved")
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


	
	 
        Public Function Equals1(ByVal other As CrmChatroomMembers) As Boolean Implements System.IEquatable(Of CrmChatroomMembers).Equals
           
           if Me.UserId <> other.UserId Then
                Return False
            End If

if Me.ChatroomId <> other.ChatroomId Then
                Return False
            End If


             Return True
        End Function
        
         Public Overrides Function GetHashCode() As Integer
            Return GetHashValue(UserId) Xor GetHashValue(ChatroomId)
        End Function
	
End Class

End Namespace