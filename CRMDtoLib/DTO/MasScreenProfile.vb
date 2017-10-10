Imports SsCommon
Imports System.ComponentModel
Imports System.Runtime.Serialization

Namespace DTO

<DataContract(),Table("MAS_SCREEN_PROFILE")> _
Public Class MasScreenProfile
    Inherits BaseDto
    Implements IEquatable(Of MasScreenProfile)
         
	 
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

Private _LanguageCode As String
		<DataMember(),DataField("LANGUAGE_CODE"),DataAnnotations.Key(), DataAnnotations.Required(AllowEmptyStrings:=False)> _
		Public Property LanguageCode() As String
			Get
				Return Me._LanguageCode
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.LanguageCode, value) <> true) Then
						Me._LanguageCode = value
						OnPropertyChanged("LanguageCode")
					End If  
			End Set
		End Property

Private _ObjectId As String
		<DataMember(),DataField("OBJECT_ID"),DataAnnotations.Key(), DataAnnotations.Required(AllowEmptyStrings:=False)> _
		Public Property ObjectId() As String
			Get
				Return Me._ObjectId
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.ObjectId, value) <> true) Then
						Me._ObjectId = value
						OnPropertyChanged("ObjectId")
					End If  
			End Set
		End Property

Private _ColumnId As String
		<DataMember(),DataField("COLUMN_ID"),DataAnnotations.Key(), DataAnnotations.Required(AllowEmptyStrings:=False)> _
		Public Property ColumnId() As String
			Get
				Return Me._ColumnId
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.ColumnId, value) <> true) Then
						Me._ColumnId = value
						OnPropertyChanged("ColumnId")
					End If  
			End Set
		End Property


	
	Private _ObjectText As String
		<DataMember(),DataField("OBJECT_TEXT")> _
		Public Property ObjectText() As String
			Get
				Return Me._ObjectText
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.ObjectText, value) <> true) Then				    
						Me._ObjectText = value
						OnPropertyChanged("ObjectText")
				    End If 
			End Set
		End Property

Private _ObjectDesc As String
		<DataMember(),DataField("OBJECT_DESC")> _
		Public Property ObjectDesc() As String
			Get
				Return Me._ObjectDesc
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.ObjectDesc, value) <> true) Then				    
						Me._ObjectDesc = value
						OnPropertyChanged("ObjectDesc")
				    End If 
			End Set
		End Property

Private _ObjectType As String
		<DataMember(),DataField("OBJECT_TYPE")> _
		Public Property ObjectType() As String
			Get
				Return Me._ObjectType
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.ObjectType, value) <> true) Then				    
						Me._ObjectType = value
						OnPropertyChanged("ObjectType")
				    End If 
			End Set
		End Property


	
	 
        Public Function Equals1(ByVal other As MasScreenProfile) As Boolean Implements System.IEquatable(Of MasScreenProfile).Equals
           
           if Me.ModuleCode <> other.ModuleCode Then
                Return False
            End If

if Me.ProgramCode <> other.ProgramCode Then
                Return False
            End If

if Me.LanguageCode <> other.LanguageCode Then
                Return False
            End If

if Me.ObjectId <> other.ObjectId Then
                Return False
            End If

if Me.ColumnId <> other.ColumnId Then
                Return False
            End If


             Return True
        End Function
        
         Public Overrides Function GetHashCode() As Integer
            Return GetHashValue(ModuleCode) Xor GetHashValue(ProgramCode) Xor GetHashValue(LanguageCode) Xor GetHashValue(ObjectId) Xor GetHashValue(ColumnId)
        End Function
	
End Class

End Namespace