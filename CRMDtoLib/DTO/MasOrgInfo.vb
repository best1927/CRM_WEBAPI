Imports SsCommon
Imports System.ComponentModel
Imports System.Runtime.Serialization

Namespace DTO

<DataContract(),Table("MAS_ORG_INFO")> _
Public Class MasOrgInfo
    Inherits BaseDto
    Implements IEquatable(Of MasOrgInfo)
         
	 
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


	
	Private _ShortNameLoc As String
		<DataMember(),DataField("SHORT_NAME_LOC")> _
		Public Property ShortNameLoc() As String
			Get
				Return Me._ShortNameLoc
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.ShortNameLoc, value) <> true) Then				    
						Me._ShortNameLoc = value
						OnPropertyChanged("ShortNameLoc")
				    End If 
			End Set
		End Property

Private _ShortNameEng As String
		<DataMember(),DataField("SHORT_NAME_ENG")> _
		Public Property ShortNameEng() As String
			Get
				Return Me._ShortNameEng
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.ShortNameEng, value) <> true) Then				    
						Me._ShortNameEng = value
						OnPropertyChanged("ShortNameEng")
				    End If 
			End Set
		End Property

Private _CenterOrg As String
		<DataMember(),DataField("CENTER_ORG")> _
		Public Property CenterOrg() As String
			Get
				Return Me._CenterOrg
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.CenterOrg, value) <> true) Then				    
						Me._CenterOrg = value
						OnPropertyChanged("CenterOrg")
				    End If 
			End Set
		End Property


	
	 
        Public Function Equals1(ByVal other As MasOrgInfo) As Boolean Implements System.IEquatable(Of MasOrgInfo).Equals
           
           if Me.OrgCode <> other.OrgCode Then
                Return False
            End If


             Return True
        End Function
        
         Public Overrides Function GetHashCode() As Integer
            Return GetHashValue(OrgCode)
        End Function
	
End Class

End Namespace