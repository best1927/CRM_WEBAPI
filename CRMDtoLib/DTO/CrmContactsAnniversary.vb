Imports SsCommon
Imports System.ComponentModel
Imports System.Runtime.Serialization

Namespace DTO

<DataContract(),Table("CRM_CONTACTS_ANNIVERSARY")> _
Public Class CrmContactsAnniversary
    Inherits BaseDto
    Implements IEquatable(Of CrmContactsAnniversary)
         
	 
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

Private _RepeatYearYn As String
		<DataMember(),DataField("REPEAT_YEAR_YN")> _
		Public Property RepeatYearYn() As String
			Get
				Return Me._RepeatYearYn
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.RepeatYearYn, value) <> true) Then				    
						Me._RepeatYearYn = value
						OnPropertyChanged("RepeatYearYn")
				    End If 
			End Set
		End Property

Private _ReminderYn As String
		<DataMember(),DataField("REMINDER_YN")> _
		Public Property ReminderYn() As String
			Get
				Return Me._ReminderYn
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.ReminderYn, value) <> true) Then				    
						Me._ReminderYn = value
						OnPropertyChanged("ReminderYn")
				    End If 
			End Set
		End Property

Private _AnniDt As Nullable(of DateTime)
		<DataMember(),DataField("ANNI_DT")> _
		Public Property AnniDt() As Nullable(of DateTime)
			Get
				Return Me._AnniDt
			End Get
			Set(ByVal value As Nullable(of DateTime))
					If (Object.Equals(Me.AnniDt, value) <> true) Then				    
						Me._AnniDt = value
						OnPropertyChanged("AnniDt")
				    End If 
			End Set
		End Property

Private _CatDate As String
		<DataMember(),DataField("CAT_DATE")> _
		Public Property CatDate() As String
			Get
				Return Me._CatDate
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.CatDate, value) <> true) Then				    
						Me._CatDate = value
						OnPropertyChanged("CatDate")
				    End If 
			End Set
		End Property


	
	 
        Public Function Equals1(ByVal other As CrmContactsAnniversary) As Boolean Implements System.IEquatable(Of CrmContactsAnniversary).Equals
           
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