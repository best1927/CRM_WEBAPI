Imports SsCommon
Imports System.ComponentModel
Imports System.Runtime.Serialization

Namespace DTO

<DataContract(),Table("CRM_CONTACTS_RELATIVE")> _
Public Class CrmContactsRelative
    Inherits BaseDto
    Implements IEquatable(Of CrmContactsRelative)
         
	 
   	Private _ContactId As Decimal
		<DataMember(),DataField("CONTACT_ID"),DataAnnotations.Key()> _
		Public Property ContactId() As Decimal
			Get
				Return Me._ContactId
			End Get
			Set(ByVal value As Decimal)
					If (Object.ReferenceEquals(Me.ContactId, value) <> true) Then
						Me._ContactId = value
						OnPropertyChanged("ContactId")
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

Private _CatRelative As String
		<DataMember(),DataField("CAT_RELATIVE")> _
		Public Property CatRelative() As String
			Get
				Return Me._CatRelative
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.CatRelative, value) <> true) Then				    
						Me._CatRelative = value
						OnPropertyChanged("CatRelative")
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


	
	 
        Public Function Equals1(ByVal other As CrmContactsRelative) As Boolean Implements System.IEquatable(Of CrmContactsRelative).Equals
           
           if Me.ContactId <> other.ContactId Then
                Return False
            End If

if Me.Seq <> other.Seq Then
                Return False
            End If


             Return True
        End Function
        
         Public Overrides Function GetHashCode() As Integer
            Return GetHashValue(ContactId) Xor GetHashValue(Seq)
        End Function
	
End Class

End Namespace