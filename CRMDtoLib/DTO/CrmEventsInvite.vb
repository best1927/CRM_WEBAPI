Imports SsCommon
Imports System.ComponentModel
Imports System.Runtime.Serialization

Namespace DTO

<DataContract(),Table("CRM_EVENTS_INVITE")> _
Public Class CrmEventsInvite
    Inherits BaseDto
    Implements IEquatable(Of CrmEventsInvite)
         
	 
   	Private _EventId As Decimal
		<DataMember(),DataField("EVENT_ID"),DataAnnotations.Key()> _
		Public Property EventId() As Decimal
			Get
				Return Me._EventId
			End Get
			Set(ByVal value As Decimal)
					If (Object.ReferenceEquals(Me.EventId, value) <> true) Then
						Me._EventId = value
						OnPropertyChanged("EventId")
					End If  
			End Set
		End Property

Private _Seq As Decimal
		<DataMember(),DataField("SEQ"),DataAnnotations.Key()> _
		Public Property Seq() As Decimal
			Get
				Return Me._Seq
			End Get
			Set(ByVal value As Decimal)
					If (Object.ReferenceEquals(Me.Seq, value) <> true) Then
						Me._Seq = value
						OnPropertyChanged("Seq")
					End If  
			End Set
		End Property


	
	Private _InviteCat As String
		<DataMember(),DataField("INVITE_CAT")> _
		Public Property InviteCat() As String
			Get
				Return Me._InviteCat
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.InviteCat, value) <> true) Then				    
						Me._InviteCat = value
						OnPropertyChanged("InviteCat")
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


	
	 
        Public Function Equals1(ByVal other As CrmEventsInvite) As Boolean Implements System.IEquatable(Of CrmEventsInvite).Equals
           
           if Me.EventId <> other.EventId Then
                Return False
            End If

if Me.Seq <> other.Seq Then
                Return False
            End If


             Return True
        End Function
        
         Public Overrides Function GetHashCode() As Integer
            Return GetHashValue(EventId) Xor GetHashValue(Seq)
        End Function
	
End Class

End Namespace