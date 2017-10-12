Imports SsCommon
Imports System.ComponentModel
Imports System.Runtime.Serialization

Namespace DTO

<DataContract(),Table("CRM_SPECIALIST_QUAL")> _
Public Class CrmSpecialistQual
    Inherits BaseDto
    Implements IEquatable(Of CrmSpecialistQual)
         
	 
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

Private _SpecialistId As Decimal
		<DataMember(),DataField("SPECIALIST_ID"),DataAnnotations.Key()> _
		Public Property SpecialistId() As Decimal
			Get
				Return Me._SpecialistId
			End Get
			Set(ByVal value As Decimal)
					If (Object.ReferenceEquals(Me.SpecialistId, value) <> true) Then
						Me._SpecialistId = value
						OnPropertyChanged("SpecialistId")
					End If  
			End Set
		End Property


	
	Private _Certifiedlife As Nullable(of DateTime)
		<DataMember(),DataField("CERTIFIEDLIFE")> _
		Public Property Certifiedlife() As Nullable(of DateTime)
			Get
				Return Me._Certifiedlife
			End Get
			Set(ByVal value As Nullable(of DateTime))
					If (Object.Equals(Me.Certifiedlife, value) <> true) Then				    
						Me._Certifiedlife = value
						OnPropertyChanged("Certifiedlife")
				    End If 
			End Set
		End Property

Private _CertDt As Nullable(of DateTime)
		<DataMember(),DataField("CERT_DT")> _
		Public Property CertDt() As Nullable(of DateTime)
			Get
				Return Me._CertDt
			End Get
			Set(ByVal value As Nullable(of DateTime))
					If (Object.Equals(Me.CertDt, value) <> true) Then				    
						Me._CertDt = value
						OnPropertyChanged("CertDt")
				    End If 
			End Set
		End Property

Private _Certificate As String
		<DataMember(),DataField("CERTIFICATE")> _
		Public Property Certificate() As String
			Get
				Return Me._Certificate
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Certificate, value) <> true) Then				    
						Me._Certificate = value
						OnPropertyChanged("Certificate")
				    End If 
			End Set
		End Property

Private _CertType As String
		<DataMember(),DataField("CERT_TYPE")> _
		Public Property CertType() As String
			Get
				Return Me._CertType
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.CertType, value) <> true) Then				    
						Me._CertType = value
						OnPropertyChanged("CertType")
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

Private _CertRmk As String
		<DataMember(),DataField("CERT_RMK")> _
		Public Property CertRmk() As String
			Get
				Return Me._CertRmk
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.CertRmk, value) <> true) Then				    
						Me._CertRmk = value
						OnPropertyChanged("CertRmk")
				    End If 
			End Set
		End Property

Private _Score As Nullable(of Decimal)
		<DataMember(),DataField("SCORE")> _
		Public Property Score() As Nullable(of Decimal)
			Get
				Return Me._Score
			End Get
			Set(ByVal value As Nullable(of Decimal))
					If (Object.Equals(Me.Score, value) <> true) Then				    
						Me._Score = value
						OnPropertyChanged("Score")
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


	
	 
        Public Function Equals1(ByVal other As CrmSpecialistQual) As Boolean Implements System.IEquatable(Of CrmSpecialistQual).Equals
           
           if Me.Seq <> other.Seq Then
                Return False
            End If

if Me.SpecialistId <> other.SpecialistId Then
                Return False
            End If


             Return True
        End Function
        
         Public Overrides Function GetHashCode() As Integer
            Return GetHashValue(Seq) Xor GetHashValue(SpecialistId)
        End Function
	
End Class

End Namespace