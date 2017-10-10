Imports SsCommon
Imports System.ComponentModel
Imports System.Runtime.Serialization

Namespace DTO

<DataContract(),Table("MAS_USER_NOTIFY_AUTHEN")> _
Public Class MasUserNotifyAuthen
    Inherits BaseDto
    Implements IEquatable(Of MasUserNotifyAuthen)
         
	 
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

Private _EventId As String
		<DataMember(),DataField("EVENT_ID"),DataAnnotations.Key(), DataAnnotations.Required(AllowEmptyStrings:=False)> _
		Public Property EventId() As String
			Get
				Return Me._EventId
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.EventId, value) <> true) Then
						Me._EventId = value
						OnPropertyChanged("EventId")
					End If  
			End Set
		End Property


	
	Private _Cond1 As String
		<DataMember(),DataField("COND1")> _
		Public Property Cond1() As String
			Get
				Return Me._Cond1
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Cond1, value) <> true) Then				    
						Me._Cond1 = value
						OnPropertyChanged("Cond1")
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


	
	 
        Public Function Equals1(ByVal other As MasUserNotifyAuthen) As Boolean Implements System.IEquatable(Of MasUserNotifyAuthen).Equals
           
           if Me.UserId <> other.UserId Then
                Return False
            End If

if Me.EventId <> other.EventId Then
                Return False
            End If


             Return True
        End Function
        
         Public Overrides Function GetHashCode() As Integer
            Return GetHashValue(UserId) Xor GetHashValue(EventId)
        End Function
	
End Class

End Namespace