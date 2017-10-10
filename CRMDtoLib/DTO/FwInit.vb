Imports SsCommon
Imports System.ComponentModel
Imports System.Runtime.Serialization

Namespace DTO

<DataContract(),Table("FW_INIT")> _
Public Class FwInit
    Inherits BaseDto
    Implements IEquatable(Of FwInit)
         
	 
   	Private _ProgramId As String
		<DataMember(),DataField("PROGRAM_ID"),DataAnnotations.Key(), DataAnnotations.Required(AllowEmptyStrings:=False)> _
		Public Property ProgramId() As String
			Get
				Return Me._ProgramId
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.ProgramId, value) <> true) Then
						Me._ProgramId = value
						OnPropertyChanged("ProgramId")
					End If  
			End Set
		End Property

Private _KeyName As String
		<DataMember(),DataField("KEY_NAME"),DataAnnotations.Key(), DataAnnotations.Required(AllowEmptyStrings:=False)> _
		Public Property KeyName() As String
			Get
				Return Me._KeyName
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.KeyName, value) <> true) Then
						Me._KeyName = value
						OnPropertyChanged("KeyName")
					End If  
			End Set
		End Property


	
	Private _Descr As String
		<DataMember(),DataField("DESCR")> _
		Public Property Descr() As String
			Get
				Return Me._Descr
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Descr, value) <> true) Then				    
						Me._Descr = value
						OnPropertyChanged("Descr")
				    End If 
			End Set
		End Property

Private _Value As String
		<DataMember(),DataField("VALUE")> _
		Public Property Value() As String
			Get
				Return Me._Value
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Value, value) <> true) Then				    
						Me._Value = value
						OnPropertyChanged("Value")
				    End If 
			End Set
		End Property

Private _Owner As String
		<DataMember(),DataField("OWNER")> _
		Public Property Owner() As String
			Get
				Return Me._Owner
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Owner, value) <> true) Then				    
						Me._Owner = value
						OnPropertyChanged("Owner")
				    End If 
			End Set
		End Property

Private _Accessdate As Nullable(of DateTime)
		<DataMember(),DataField("ACCESSDATE")> _
		Public Property Accessdate() As Nullable(of DateTime)
			Get
				Return Me._Accessdate
			End Get
			Set(ByVal value As Nullable(of DateTime))
					If (Object.Equals(Me.Accessdate, value) <> true) Then				    
						Me._Accessdate = value
						OnPropertyChanged("Accessdate")
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

Private _CreatedDate As Nullable(of DateTime)
		<DataMember(),DataField("CREATED_DATE")> _
		Public Property CreatedDate() As Nullable(of DateTime)
			Get
				Return Me._CreatedDate
			End Get
			Set(ByVal value As Nullable(of DateTime))
					If (Object.Equals(Me.CreatedDate, value) <> true) Then				    
						Me._CreatedDate = value
						OnPropertyChanged("CreatedDate")
				    End If 
			End Set
		End Property

Private _CreatedUser As String
		<DataMember(),DataField("CREATED_USER")> _
		Public Property CreatedUser() As String
			Get
				Return Me._CreatedUser
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.CreatedUser, value) <> true) Then				    
						Me._CreatedUser = value
						OnPropertyChanged("CreatedUser")
				    End If 
			End Set
		End Property

Private _Function As String
		<DataMember(),DataField("FUNCTION")> _
		Public Property [Function]() As String
			Get
				Return Me._Function
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Function, value) <> true) Then				    
						Me._Function = value
						OnPropertyChanged("Function")
				    End If 
			End Set
		End Property


	
	 
        Public Function Equals1(ByVal other As FwInit) As Boolean Implements System.IEquatable(Of FwInit).Equals
           
           if Me.ProgramId <> other.ProgramId Then
                Return False
            End If

if Me.KeyName <> other.KeyName Then
                Return False
            End If


             Return True
        End Function
        
         Public Overrides Function GetHashCode() As Integer
            Return GetHashValue(ProgramId) Xor GetHashValue(KeyName)
        End Function
	
End Class

End Namespace