Imports SsCommon
Imports System.ComponentModel
Imports System.Runtime.Serialization

Namespace DTO

<DataContract(),Table("MAS_USER_PERMISSION")> _
Public Class MasUserPermission
    Inherits BaseDto
    Implements IEquatable(Of MasUserPermission)
         
	 
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


	
	Private _PSelect As String
		<DataMember(),DataField("P_SELECT")> _
		Public Property PSelect() As String
			Get
				Return Me._PSelect
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.PSelect, value) <> true) Then				    
						Me._PSelect = value
						OnPropertyChanged("PSelect")
				    End If 
			End Set
		End Property

Private _PInsert As String
		<DataMember(),DataField("P_INSERT")> _
		Public Property PInsert() As String
			Get
				Return Me._PInsert
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.PInsert, value) <> true) Then				    
						Me._PInsert = value
						OnPropertyChanged("PInsert")
				    End If 
			End Set
		End Property

Private _PUpdate As String
		<DataMember(),DataField("P_UPDATE")> _
		Public Property PUpdate() As String
			Get
				Return Me._PUpdate
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.PUpdate, value) <> true) Then				    
						Me._PUpdate = value
						OnPropertyChanged("PUpdate")
				    End If 
			End Set
		End Property

Private _PDelete As String
		<DataMember(),DataField("P_DELETE")> _
		Public Property PDelete() As String
			Get
				Return Me._PDelete
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.PDelete, value) <> true) Then				    
						Me._PDelete = value
						OnPropertyChanged("PDelete")
				    End If 
			End Set
		End Property

Private _PPrint As String
		<DataMember(),DataField("P_PRINT")> _
		Public Property PPrint() As String
			Get
				Return Me._PPrint
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.PPrint, value) <> true) Then				    
						Me._PPrint = value
						OnPropertyChanged("PPrint")
				    End If 
			End Set
		End Property

Private _PSearch As String
		<DataMember(),DataField("P_SEARCH")> _
		Public Property PSearch() As String
			Get
				Return Me._PSearch
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.PSearch, value) <> true) Then				    
						Me._PSearch = value
						OnPropertyChanged("PSearch")
				    End If 
			End Set
		End Property

Private _PSpec1 As String
		<DataMember(),DataField("P_SPEC1")> _
		Public Property PSpec1() As String
			Get
				Return Me._PSpec1
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.PSpec1, value) <> true) Then				    
						Me._PSpec1 = value
						OnPropertyChanged("PSpec1")
				    End If 
			End Set
		End Property

Private _PSpec2 As String
		<DataMember(),DataField("P_SPEC2")> _
		Public Property PSpec2() As String
			Get
				Return Me._PSpec2
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.PSpec2, value) <> true) Then				    
						Me._PSpec2 = value
						OnPropertyChanged("PSpec2")
				    End If 
			End Set
		End Property

Private _PSpec3 As String
		<DataMember(),DataField("P_SPEC3")> _
		Public Property PSpec3() As String
			Get
				Return Me._PSpec3
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.PSpec3, value) <> true) Then				    
						Me._PSpec3 = value
						OnPropertyChanged("PSpec3")
				    End If 
			End Set
		End Property

Private _PSpec4 As String
		<DataMember(),DataField("P_SPEC4")> _
		Public Property PSpec4() As String
			Get
				Return Me._PSpec4
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.PSpec4, value) <> true) Then				    
						Me._PSpec4 = value
						OnPropertyChanged("PSpec4")
				    End If 
			End Set
		End Property

Private _PSpec5 As String
		<DataMember(),DataField("P_SPEC5")> _
		Public Property PSpec5() As String
			Get
				Return Me._PSpec5
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.PSpec5, value) <> true) Then				    
						Me._PSpec5 = value
						OnPropertyChanged("PSpec5")
				    End If 
			End Set
		End Property

Private _PSpec6 As String
		<DataMember(),DataField("P_SPEC6")> _
		Public Property PSpec6() As String
			Get
				Return Me._PSpec6
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.PSpec6, value) <> true) Then				    
						Me._PSpec6 = value
						OnPropertyChanged("PSpec6")
				    End If 
			End Set
		End Property

Private _Status As String
		<DataMember(),DataField("STATUS")> _
		Public Property Status() As String
			Get
				Return Me._Status
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Status, value) <> true) Then				    
						Me._Status = value
						OnPropertyChanged("Status")
				    End If 
			End Set
		End Property

Private _UserCreate As String
		<DataMember(),DataField("USER_CREATE")> _
		Public Property UserCreate() As String
			Get
				Return Me._UserCreate
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.UserCreate, value) <> true) Then				    
						Me._UserCreate = value
						OnPropertyChanged("UserCreate")
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

Private _LastUserId As String
		<DataMember(),DataField("LAST_USER_ID")> _
		Public Property LastUserId() As String
			Get
				Return Me._LastUserId
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.LastUserId, value) <> true) Then				    
						Me._LastUserId = value
						OnPropertyChanged("LastUserId")
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

Private _CancelFlag As String
		<DataMember(),DataField("CANCEL_FLAG")> _
		Public Property CancelFlag() As String
			Get
				Return Me._CancelFlag
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.CancelFlag, value) <> true) Then				    
						Me._CancelFlag = value
						OnPropertyChanged("CancelFlag")
				    End If 
			End Set
		End Property


	
	 
        Public Function Equals1(ByVal other As MasUserPermission) As Boolean Implements System.IEquatable(Of MasUserPermission).Equals
           
           if Me.OrgCode <> other.OrgCode Then
                Return False
            End If

if Me.UserId <> other.UserId Then
                Return False
            End If

if Me.ProgramCode <> other.ProgramCode Then
                Return False
            End If


             Return True
        End Function
        
         Public Overrides Function GetHashCode() As Integer
            Return GetHashValue(OrgCode) Xor GetHashValue(UserId) Xor GetHashValue(ProgramCode)
        End Function
	
End Class

End Namespace