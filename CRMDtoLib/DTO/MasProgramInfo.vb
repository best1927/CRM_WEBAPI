Imports SsCommon
Imports System.ComponentModel
Imports System.Runtime.Serialization

Namespace DTO

<DataContract(),Table("MAS_PROGRAM_INFO")> _
Public Class MasProgramInfo
    Inherits BaseDto
    Implements IEquatable(Of MasProgramInfo)
         
	 
   	Private _ProgramCode As String
		<DataMember(),DataField("PROGRAM_CODE"),DataAnnotations.Key(), DataAnnotations.Required(AllowEmptyStrings:=False)> _
		Public Property ProgramCode() As String
			Get
				Return Me._ProgramCode
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.ProgramCode, value) <> true) Then
						Me._ProgramCode = value
						OnPropertyChanged("ProgramCode")
					End If  
			End Set
		End Property

Private _UserAccess As String
		<DataMember(),DataField("USER_ACCESS"),DataAnnotations.Key(), DataAnnotations.Required(AllowEmptyStrings:=False)> _
		Public Property UserAccess() As String
			Get
				Return Me._UserAccess
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.UserAccess, value) <> true) Then
						Me._UserAccess = value
						OnPropertyChanged("UserAccess")
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

Private _ProgramType As String
		<DataMember(),DataField("PROGRAM_TYPE")> _
		Public Property ProgramType() As String
			Get
				Return Me._ProgramType
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.ProgramType, value) <> true) Then				    
						Me._ProgramType = value
						OnPropertyChanged("ProgramType")
				    End If 
			End Set
		End Property

Private _ProgramPath As String
		<DataMember(),DataField("PROGRAM_PATH")> _
		Public Property ProgramPath() As String
			Get
				Return Me._ProgramPath
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.ProgramPath, value) <> true) Then				    
						Me._ProgramPath = value
						OnPropertyChanged("ProgramPath")
				    End If 
			End Set
		End Property

Private _ProgramExtension As String
		<DataMember(),DataField("PROGRAM_EXTENSION")> _
		Public Property ProgramExtension() As String
			Get
				Return Me._ProgramExtension
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.ProgramExtension, value) <> true) Then				    
						Me._ProgramExtension = value
						OnPropertyChanged("ProgramExtension")
				    End If 
			End Set
		End Property

Private _ProgramIcon As String
		<DataMember(),DataField("PROGRAM_ICON")> _
		Public Property ProgramIcon() As String
			Get
				Return Me._ProgramIcon
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.ProgramIcon, value) <> true) Then				    
						Me._ProgramIcon = value
						OnPropertyChanged("ProgramIcon")
				    End If 
			End Set
		End Property


	
	 
        Public Function Equals1(ByVal other As MasProgramInfo) As Boolean Implements System.IEquatable(Of MasProgramInfo).Equals
           
           if Me.ProgramCode <> other.ProgramCode Then
                Return False
            End If

if Me.UserAccess <> other.UserAccess Then
                Return False
            End If


             Return True
        End Function
        
         Public Overrides Function GetHashCode() As Integer
            Return GetHashValue(ProgramCode) Xor GetHashValue(UserAccess)
        End Function
	
End Class

End Namespace