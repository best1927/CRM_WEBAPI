Imports SsCommon
Imports System.ComponentModel
Imports System.Runtime.Serialization

Namespace DTO

<DataContract(),Table("MAS_USER_TOKEN")> _
Public Class MasUserToken
    Inherits BaseDto
    Implements IEquatable(Of MasUserToken)
         
	 
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

Private _TokenId As String
		<DataMember(),DataField("TOKEN_ID"),DataAnnotations.Key(), DataAnnotations.Required(AllowEmptyStrings:=False)> _
		Public Property TokenId() As String
			Get
				Return Me._TokenId
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.TokenId, value) <> true) Then
						Me._TokenId = value
						OnPropertyChanged("TokenId")
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

Private _Cond2 As String
		<DataMember(),DataField("COND2")> _
		Public Property Cond2() As String
			Get
				Return Me._Cond2
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Cond2, value) <> true) Then				    
						Me._Cond2 = value
						OnPropertyChanged("Cond2")
				    End If 
			End Set
		End Property

Private _Cond3 As String
		<DataMember(),DataField("COND3")> _
		Public Property Cond3() As String
			Get
				Return Me._Cond3
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Cond3, value) <> true) Then				    
						Me._Cond3 = value
						OnPropertyChanged("Cond3")
				    End If 
			End Set
		End Property

Private _Cond4 As String
		<DataMember(),DataField("COND4")> _
		Public Property Cond4() As String
			Get
				Return Me._Cond4
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Cond4, value) <> true) Then				    
						Me._Cond4 = value
						OnPropertyChanged("Cond4")
				    End If 
			End Set
		End Property

Private _Cond5 As String
		<DataMember(),DataField("COND5")> _
		Public Property Cond5() As String
			Get
				Return Me._Cond5
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Cond5, value) <> true) Then				    
						Me._Cond5 = value
						OnPropertyChanged("Cond5")
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


	
	 
        Public Function Equals1(ByVal other As MasUserToken) As Boolean Implements System.IEquatable(Of MasUserToken).Equals
           
           if Me.UserId <> other.UserId Then
                Return False
            End If

if Me.TokenId <> other.TokenId Then
                Return False
            End If


             Return True
        End Function
        
         Public Overrides Function GetHashCode() As Integer
            Return GetHashValue(UserId) Xor GetHashValue(TokenId)
        End Function
	
End Class

End Namespace