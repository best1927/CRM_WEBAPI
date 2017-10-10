Imports SsCommon
Imports System.ComponentModel
Imports System.Runtime.Serialization

Namespace DTO

<DataContract(),Table("MAS_MENU_INFO")> _
Public Class MasMenuInfo
    Inherits BaseDto
    Implements IEquatable(Of MasMenuInfo)
         
	 
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


	
	Private _ParentProgramCode As String
		<DataMember(),DataField("PARENT_PROGRAM_CODE")> _
		Public Property ParentProgramCode() As String
			Get
				Return Me._ParentProgramCode
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.ParentProgramCode, value) <> true) Then				    
						Me._ParentProgramCode = value
						OnPropertyChanged("ParentProgramCode")
				    End If 
			End Set
		End Property

Private _NodeLevel As Nullable(of Decimal)
		<DataMember(),DataField("NODE_LEVEL")> _
		Public Property NodeLevel() As Nullable(of Decimal)
			Get
				Return Me._NodeLevel
			End Get
			Set(ByVal value As Nullable(of Decimal))
					If (Object.Equals(Me.NodeLevel, value) <> true) Then				    
						Me._NodeLevel = value
						OnPropertyChanged("NodeLevel")
				    End If 
			End Set
		End Property

Private _SeqNo As Nullable(of Decimal)
		<DataMember(),DataField("SEQ_NO")> _
		Public Property SeqNo() As Nullable(of Decimal)
			Get
				Return Me._SeqNo
			End Get
			Set(ByVal value As Nullable(of Decimal))
					If (Object.Equals(Me.SeqNo, value) <> true) Then				    
						Me._SeqNo = value
						OnPropertyChanged("SeqNo")
				    End If 
			End Set
		End Property


	
	 
        Public Function Equals1(ByVal other As MasMenuInfo) As Boolean Implements System.IEquatable(Of MasMenuInfo).Equals
           
           if Me.ModuleCode <> other.ModuleCode Then
                Return False
            End If

if Me.ProgramCode <> other.ProgramCode Then
                Return False
            End If

if Me.UserAccess <> other.UserAccess Then
                Return False
            End If


             Return True
        End Function
        
         Public Overrides Function GetHashCode() As Integer
            Return GetHashValue(ModuleCode) Xor GetHashValue(ProgramCode) Xor GetHashValue(UserAccess)
        End Function
	
End Class

End Namespace