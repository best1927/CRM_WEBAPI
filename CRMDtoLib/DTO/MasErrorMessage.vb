Imports SsCommon
Imports System.ComponentModel
Imports System.Runtime.Serialization

Namespace DTO

<DataContract(),Table("MAS_ERROR_MESSAGE")> _
Public Class MasErrorMessage
    Inherits BaseDto
    Implements IEquatable(Of MasErrorMessage)
         
	 
   	Private _ErrorId As String
		<DataMember(),DataField("ERROR_ID"),DataAnnotations.Key(), DataAnnotations.Required(AllowEmptyStrings:=False)> _
		Public Property ErrorId() As String
			Get
				Return Me._ErrorId
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.ErrorId, value) <> true) Then
						Me._ErrorId = value
						OnPropertyChanged("ErrorId")
					End If  
			End Set
		End Property

Private _ErrorType As String
		<DataMember(),DataField("ERROR_TYPE"),DataAnnotations.Key(), DataAnnotations.Required(AllowEmptyStrings:=False)> _
		Public Property ErrorType() As String
			Get
				Return Me._ErrorType
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.ErrorType, value) <> true) Then
						Me._ErrorType = value
						OnPropertyChanged("ErrorType")
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


	
	Private _ErrorDesc As String
		<DataMember(),DataField("ERROR_DESC")> _
		Public Property ErrorDesc() As String
			Get
				Return Me._ErrorDesc
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.ErrorDesc, value) <> true) Then				    
						Me._ErrorDesc = value
						OnPropertyChanged("ErrorDesc")
				    End If 
			End Set
		End Property

Private _MessType As String
		<DataMember(),DataField("MESS_TYPE")> _
		Public Property MessType() As String
			Get
				Return Me._MessType
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.MessType, value) <> true) Then				    
						Me._MessType = value
						OnPropertyChanged("MessType")
				    End If 
			End Set
		End Property


	
	 
        Public Function Equals1(ByVal other As MasErrorMessage) As Boolean Implements System.IEquatable(Of MasErrorMessage).Equals
           
           if Me.ErrorId <> other.ErrorId Then
                Return False
            End If

if Me.ErrorType <> other.ErrorType Then
                Return False
            End If

if Me.LanguageCode <> other.LanguageCode Then
                Return False
            End If


             Return True
        End Function
        
         Public Overrides Function GetHashCode() As Integer
            Return GetHashValue(ErrorId) Xor GetHashValue(ErrorType) Xor GetHashValue(LanguageCode)
        End Function
	
End Class

End Namespace