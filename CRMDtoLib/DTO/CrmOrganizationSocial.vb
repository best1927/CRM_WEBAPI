Imports SsCommon
Imports System.ComponentModel
Imports System.Runtime.Serialization

Namespace DTO

<DataContract(),Table("CRM_ORGANIZATION_SOCIAL")> _
Public Class CrmOrganizationSocial
    Inherits BaseDto
    Implements IEquatable(Of CrmOrganizationSocial)
         
	 
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

Private _OrganizeId As Decimal
		<DataMember(),DataField("ORGANIZE_ID"),DataAnnotations.Key()> _
		Public Property OrganizeId() As Decimal
			Get
				Return Me._OrganizeId
			End Get
			Set(ByVal value As Decimal)
					If (Object.ReferenceEquals(Me.OrganizeId, value) <> true) Then
						Me._OrganizeId = value
						OnPropertyChanged("OrganizeId")
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

Private _SocialLink As String
		<DataMember(),DataField("SOCIAL_LINK")> _
		Public Property SocialLink() As String
			Get
				Return Me._SocialLink
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.SocialLink, value) <> true) Then				    
						Me._SocialLink = value
						OnPropertyChanged("SocialLink")
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

Private _SocialType As String
		<DataMember(),DataField("SOCIAL_TYPE")> _
		Public Property SocialType() As String
			Get
				Return Me._SocialType
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.SocialType, value) <> true) Then				    
						Me._SocialType = value
						OnPropertyChanged("SocialType")
				    End If 
			End Set
		End Property


	
	 
        Public Function Equals1(ByVal other As CrmOrganizationSocial) As Boolean Implements System.IEquatable(Of CrmOrganizationSocial).Equals
           
           if Me.Seq <> other.Seq Then
                Return False
            End If

if Me.OrganizeId <> other.OrganizeId Then
                Return False
            End If


             Return True
        End Function
        
         Public Overrides Function GetHashCode() As Integer
            Return GetHashValue(Seq) Xor GetHashValue(OrganizeId)
        End Function
	
End Class

End Namespace