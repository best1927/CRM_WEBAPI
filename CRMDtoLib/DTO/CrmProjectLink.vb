Imports SsCommon
Imports System.ComponentModel
Imports System.Runtime.Serialization

Namespace DTO

<DataContract(),Table("CRM_PROJECT_LINK")> _
Public Class CrmProjectLink
    Inherits BaseDto
    Implements IEquatable(Of CrmProjectLink)
         
	 
   	Private _ProjectId As Decimal
		<DataMember(),DataField("PROJECT_ID"),DataAnnotations.Key()> _
		Public Property ProjectId() As Decimal
			Get
				Return Me._ProjectId
			End Get
			Set(ByVal value As Decimal)
					If (Object.ReferenceEquals(Me.ProjectId, value) <> true) Then
						Me._ProjectId = value
						OnPropertyChanged("ProjectId")
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


	
	Private _Category As String
		<DataMember(),DataField("CATEGORY")> _
		Public Property Category() As String
			Get
				Return Me._Category
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Category, value) <> true) Then				    
						Me._Category = value
						OnPropertyChanged("Category")
				    End If 
			End Set
		End Property

Private _LinkId As Nullable(of Decimal)
		<DataMember(),DataField("LINK_ID")> _
		Public Property LinkId() As Nullable(of Decimal)
			Get
				Return Me._LinkId
			End Get
			Set(ByVal value As Nullable(of Decimal))
					If (Object.Equals(Me.LinkId, value) <> true) Then				    
						Me._LinkId = value
						OnPropertyChanged("LinkId")
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


	
	 
        Public Function Equals1(ByVal other As CrmProjectLink) As Boolean Implements System.IEquatable(Of CrmProjectLink).Equals
           
           if Me.ProjectId <> other.ProjectId Then
                Return False
            End If

if Me.Seq <> other.Seq Then
                Return False
            End If


             Return True
        End Function
        
         Public Overrides Function GetHashCode() As Integer
            Return GetHashValue(ProjectId) Xor GetHashValue(Seq)
        End Function
	
End Class

End Namespace