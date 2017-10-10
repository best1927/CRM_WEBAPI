Imports SsCommon
Imports System.ComponentModel
Imports System.Runtime.Serialization

Namespace DTO

<DataContract(),Table("MAS_MODULE")> _
Public Class MasModule
    Inherits BaseDto
    Implements IEquatable(Of MasModule)
         
	 
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


	
	Private _DescLoc As String
		<DataMember(),DataField("DESC_LOC")> _
		Public Property DescLoc() As String
			Get
				Return Me._DescLoc
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.DescLoc, value) <> true) Then				    
						Me._DescLoc = value
						OnPropertyChanged("DescLoc")
				    End If 
			End Set
		End Property

Private _DescEng As String
		<DataMember(),DataField("DESC_ENG")> _
		Public Property DescEng() As String
			Get
				Return Me._DescEng
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.DescEng, value) <> true) Then				    
						Me._DescEng = value
						OnPropertyChanged("DescEng")
				    End If 
			End Set
		End Property

Private _UserOwner As String
		<DataMember(),DataField("USER_OWNER")> _
		Public Property UserOwner() As String
			Get
				Return Me._UserOwner
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.UserOwner, value) <> true) Then				    
						Me._UserOwner = value
						OnPropertyChanged("UserOwner")
				    End If 
			End Set
		End Property

Private _CreateDate As Nullable(of DateTime)
		<DataMember(),DataField("CREATE_DATE")> _
		Public Property CreateDate() As Nullable(of DateTime)
			Get
				Return Me._CreateDate
			End Get
			Set(ByVal value As Nullable(of DateTime))
					If (Object.Equals(Me.CreateDate, value) <> true) Then				    
						Me._CreateDate = value
						OnPropertyChanged("CreateDate")
				    End If 
			End Set
		End Property

Private _LastUpdateDate As Nullable(of DateTime)
		<DataMember(),DataField("LAST_UPDATE_DATE")> _
		Public Property LastUpdateDate() As Nullable(of DateTime)
			Get
				Return Me._LastUpdateDate
			End Get
			Set(ByVal value As Nullable(of DateTime))
					If (Object.Equals(Me.LastUpdateDate, value) <> true) Then				    
						Me._LastUpdateDate = value
						OnPropertyChanged("LastUpdateDate")
				    End If 
			End Set
		End Property

Private _LastFunction As String
		<DataMember(),DataField("LAST_FUNCTION")> _
		Public Property LastFunction() As String
			Get
				Return Me._LastFunction
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.LastFunction, value) <> true) Then				    
						Me._LastFunction = value
						OnPropertyChanged("LastFunction")
				    End If 
			End Set
		End Property


	
	 
        Public Function Equals1(ByVal other As MasModule) As Boolean Implements System.IEquatable(Of MasModule).Equals
           
           if Me.ModuleCode <> other.ModuleCode Then
                Return False
            End If


             Return True
        End Function
        
         Public Overrides Function GetHashCode() As Integer
            Return GetHashValue(ModuleCode)
        End Function
	
End Class

End Namespace