Imports SsCommon
Imports System.ComponentModel
Imports System.Runtime.Serialization

Namespace DTO

<DataContract(),Table("MAS_USER_ORG_MODULE")> _
Public Class MasUserOrgModule
    Inherits BaseDto
    Implements IEquatable(Of MasUserOrgModule)
         
	 
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

Private _OrgCode As String
		<DataMember(),DataField("ORG_CODE"),DataAnnotations.Key(), DataAnnotations.Required(AllowEmptyStrings:=False)> _
		Public Property OrgCode() As String
			Get
				Return Me._OrgCode
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.OrgCode, value) <> true) Then
						Me._OrgCode = value
						OnPropertyChanged("OrgCode")
					End If  
			End Set
		End Property

Private _ModuleCode As String
		<DataMember(),DataField("MODULE_CODE"),DataAnnotations.Key(), DataAnnotations.Required(AllowEmptyStrings:=False)> _
		Public Property ModuleCode() As String
			Get
				Return Me._ModuleCode
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.ModuleCode, value) <> true) Then
						Me._ModuleCode = value
						OnPropertyChanged("ModuleCode")
					End If  
			End Set
		End Property


	
	Private _Privilage As String
		<DataMember(),DataField("PRIVILAGE")> _
		Public Property Privilage() As String
			Get
				Return Me._Privilage
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Privilage, value) <> true) Then				    
						Me._Privilage = value
						OnPropertyChanged("Privilage")
				    End If 
			End Set
		End Property

Private _Sequence As Nullable(of Decimal)
		<DataMember(),DataField("SEQUENCE")> _
		Public Property Sequence() As Nullable(of Decimal)
			Get
				Return Me._Sequence
			End Get
			Set(ByVal value As Nullable(of Decimal))
					If (Object.Equals(Me.Sequence, value) <> true) Then				    
						Me._Sequence = value
						OnPropertyChanged("Sequence")
				    End If 
			End Set
		End Property


	
	 
        Public Function Equals1(ByVal other As MasUserOrgModule) As Boolean Implements System.IEquatable(Of MasUserOrgModule).Equals
           
           if Me.UserId <> other.UserId Then
                Return False
            End If

if Me.OrgCode <> other.OrgCode Then
                Return False
            End If

if Me.ModuleCode <> other.ModuleCode Then
                Return False
            End If


             Return True
        End Function
        
         Public Overrides Function GetHashCode() As Integer
            Return GetHashValue(UserId) Xor GetHashValue(OrgCode) Xor GetHashValue(ModuleCode)
        End Function
	
End Class

End Namespace