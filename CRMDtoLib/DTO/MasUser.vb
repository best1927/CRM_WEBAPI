Imports SsCommon
Imports System.ComponentModel
Imports System.Runtime.Serialization

Namespace DTO

<DataContract(),Table("MAS_USER")> _
Public Class MasUser
    Inherits BaseDto
    Implements IEquatable(Of MasUser)
         
	 
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


	
	Private _Password As String
		<DataMember(),DataField("PASSWORD")> _
		Public Property Password() As String
			Get
				Return Me._Password
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Password, value) <> true) Then				    
						Me._Password = value
						OnPropertyChanged("Password")
				    End If 
			End Set
		End Property

Private _TitleCode As String
		<DataMember(),DataField("TITLE_CODE")> _
		Public Property TitleCode() As String
			Get
				Return Me._TitleCode
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.TitleCode, value) <> true) Then				    
						Me._TitleCode = value
						OnPropertyChanged("TitleCode")
				    End If 
			End Set
		End Property

Private _UserNameLoc As String
		<DataMember(),DataField("USER_NAME_LOC")> _
		Public Property UserNameLoc() As String
			Get
				Return Me._UserNameLoc
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.UserNameLoc, value) <> true) Then				    
						Me._UserNameLoc = value
						OnPropertyChanged("UserNameLoc")
				    End If 
			End Set
		End Property

Private _UserNameEng As String
		<DataMember(),DataField("USER_NAME_ENG")> _
		Public Property UserNameEng() As String
			Get
				Return Me._UserNameEng
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.UserNameEng, value) <> true) Then				    
						Me._UserNameEng = value
						OnPropertyChanged("UserNameEng")
				    End If 
			End Set
		End Property

Private _EmpNo As String
		<DataMember(),DataField("EMP_NO")> _
		Public Property EmpNo() As String
			Get
				Return Me._EmpNo
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.EmpNo, value) <> true) Then				    
						Me._EmpNo = value
						OnPropertyChanged("EmpNo")
				    End If 
			End Set
		End Property

Private _DepartmentName As String
		<DataMember(),DataField("DEPARTMENT_NAME")> _
		Public Property DepartmentName() As String
			Get
				Return Me._DepartmentName
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.DepartmentName, value) <> true) Then				    
						Me._DepartmentName = value
						OnPropertyChanged("DepartmentName")
				    End If 
			End Set
		End Property

Private _ExpireDay As Nullable(of Decimal)
		<DataMember(),DataField("EXPIRE_DAY")> _
		Public Property ExpireDay() As Nullable(of Decimal)
			Get
				Return Me._ExpireDay
			End Get
			Set(ByVal value As Nullable(of Decimal))
					If (Object.Equals(Me.ExpireDay, value) <> true) Then				    
						Me._ExpireDay = value
						OnPropertyChanged("ExpireDay")
				    End If 
			End Set
		End Property

Private _EffectDate As Nullable(of DateTime)
		<DataMember(),DataField("EFFECT_DATE")> _
		Public Property EffectDate() As Nullable(of DateTime)
			Get
				Return Me._EffectDate
			End Get
			Set(ByVal value As Nullable(of DateTime))
					If (Object.Equals(Me.EffectDate, value) <> true) Then				    
						Me._EffectDate = value
						OnPropertyChanged("EffectDate")
				    End If 
			End Set
		End Property

Private _DefaultDateType As String
		<DataMember(),DataField("DEFAULT_DATE_TYPE")> _
		Public Property DefaultDateType() As String
			Get
				Return Me._DefaultDateType
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.DefaultDateType, value) <> true) Then				    
						Me._DefaultDateType = value
						OnPropertyChanged("DefaultDateType")
				    End If 
			End Set
		End Property

Private _DateFormat As String
		<DataMember(),DataField("DATE_FORMAT")> _
		Public Property DateFormat() As String
			Get
				Return Me._DateFormat
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.DateFormat, value) <> true) Then				    
						Me._DateFormat = value
						OnPropertyChanged("DateFormat")
				    End If 
			End Set
		End Property

Private _DateSeparate As String
		<DataMember(),DataField("DATE_SEPARATE")> _
		Public Property DateSeparate() As String
			Get
				Return Me._DateSeparate
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.DateSeparate, value) <> true) Then				    
						Me._DateSeparate = value
						OnPropertyChanged("DateSeparate")
				    End If 
			End Set
		End Property

Private _TimeFormat As String
		<DataMember(),DataField("TIME_FORMAT")> _
		Public Property TimeFormat() As String
			Get
				Return Me._TimeFormat
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.TimeFormat, value) <> true) Then				    
						Me._TimeFormat = value
						OnPropertyChanged("TimeFormat")
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

Private _UserGroup As String
		<DataMember(),DataField("USER_GROUP")> _
		Public Property UserGroup() As String
			Get
				Return Me._UserGroup
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.UserGroup, value) <> true) Then				    
						Me._UserGroup = value
						OnPropertyChanged("UserGroup")
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

Private _Email As String
		<DataMember(),DataField("EMAIL")> _
		Public Property Email() As String
			Get
				Return Me._Email
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Email, value) <> true) Then				    
						Me._Email = value
						OnPropertyChanged("Email")
				    End If 
			End Set
		End Property

Private _PasswordQuestion As String
		<DataMember(),DataField("PASSWORD_QUESTION")> _
		Public Property PasswordQuestion() As String
			Get
				Return Me._PasswordQuestion
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.PasswordQuestion, value) <> true) Then				    
						Me._PasswordQuestion = value
						OnPropertyChanged("PasswordQuestion")
				    End If 
			End Set
		End Property

Private _PasswordAnswer As String
		<DataMember(),DataField("PASSWORD_ANSWER")> _
		Public Property PasswordAnswer() As String
			Get
				Return Me._PasswordAnswer
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.PasswordAnswer, value) <> true) Then				    
						Me._PasswordAnswer = value
						OnPropertyChanged("PasswordAnswer")
				    End If 
			End Set
		End Property

Private _IsApproved As Nullable(of Decimal)
		<DataMember(),DataField("IS_APPROVED")> _
		Public Property IsApproved() As Nullable(of Decimal)
			Get
				Return Me._IsApproved
			End Get
			Set(ByVal value As Nullable(of Decimal))
					If (Object.Equals(Me.IsApproved, value) <> true) Then				    
						Me._IsApproved = value
						OnPropertyChanged("IsApproved")
				    End If 
			End Set
		End Property

Private _LastActivateDate As Nullable(of DateTime)
		<DataMember(),DataField("LAST_ACTIVATE_DATE")> _
		Public Property LastActivateDate() As Nullable(of DateTime)
			Get
				Return Me._LastActivateDate
			End Get
			Set(ByVal value As Nullable(of DateTime))
					If (Object.Equals(Me.LastActivateDate, value) <> true) Then				    
						Me._LastActivateDate = value
						OnPropertyChanged("LastActivateDate")
				    End If 
			End Set
		End Property

Private _LastLoginDate As Nullable(of DateTime)
		<DataMember(),DataField("LAST_LOGIN_DATE")> _
		Public Property LastLoginDate() As Nullable(of DateTime)
			Get
				Return Me._LastLoginDate
			End Get
			Set(ByVal value As Nullable(of DateTime))
					If (Object.Equals(Me.LastLoginDate, value) <> true) Then				    
						Me._LastLoginDate = value
						OnPropertyChanged("LastLoginDate")
				    End If 
			End Set
		End Property

Private _LastPwsChangeDate As Nullable(of DateTime)
		<DataMember(),DataField("LAST_PWS_CHANGE_DATE")> _
		Public Property LastPwsChangeDate() As Nullable(of DateTime)
			Get
				Return Me._LastPwsChangeDate
			End Get
			Set(ByVal value As Nullable(of DateTime))
					If (Object.Equals(Me.LastPwsChangeDate, value) <> true) Then				    
						Me._LastPwsChangeDate = value
						OnPropertyChanged("LastPwsChangeDate")
				    End If 
			End Set
		End Property

Private _IsOnline As Nullable(of Decimal)
		<DataMember(),DataField("IS_ONLINE")> _
		Public Property IsOnline() As Nullable(of Decimal)
			Get
				Return Me._IsOnline
			End Get
			Set(ByVal value As Nullable(of Decimal))
					If (Object.Equals(Me.IsOnline, value) <> true) Then				    
						Me._IsOnline = value
						OnPropertyChanged("IsOnline")
				    End If 
			End Set
		End Property

Private _IsLockedOut As Nullable(of Decimal)
		<DataMember(),DataField("IS_LOCKED_OUT")> _
		Public Property IsLockedOut() As Nullable(of Decimal)
			Get
				Return Me._IsLockedOut
			End Get
			Set(ByVal value As Nullable(of Decimal))
					If (Object.Equals(Me.IsLockedOut, value) <> true) Then				    
						Me._IsLockedOut = value
						OnPropertyChanged("IsLockedOut")
				    End If 
			End Set
		End Property

Private _LastLockedOutDate As Nullable(of DateTime)
		<DataMember(),DataField("LAST_LOCKED_OUT_DATE")> _
		Public Property LastLockedOutDate() As Nullable(of DateTime)
			Get
				Return Me._LastLockedOutDate
			End Get
			Set(ByVal value As Nullable(of DateTime))
					If (Object.Equals(Me.LastLockedOutDate, value) <> true) Then				    
						Me._LastLockedOutDate = value
						OnPropertyChanged("LastLockedOutDate")
				    End If 
			End Set
		End Property

Private _FailedPwdAttemptCount As Nullable(of Decimal)
		<DataMember(),DataField("FAILED_PWD_ATTEMPT_COUNT")> _
		Public Property FailedPwdAttemptCount() As Nullable(of Decimal)
			Get
				Return Me._FailedPwdAttemptCount
			End Get
			Set(ByVal value As Nullable(of Decimal))
					If (Object.Equals(Me.FailedPwdAttemptCount, value) <> true) Then				    
						Me._FailedPwdAttemptCount = value
						OnPropertyChanged("FailedPwdAttemptCount")
				    End If 
			End Set
		End Property

Private _FailedPwdAttempWinStart As Nullable(of DateTime)
		<DataMember(),DataField("FAILED_PWD_ATTEMP_WIN_START")> _
		Public Property FailedPwdAttempWinStart() As Nullable(of DateTime)
			Get
				Return Me._FailedPwdAttempWinStart
			End Get
			Set(ByVal value As Nullable(of DateTime))
					If (Object.Equals(Me.FailedPwdAttempWinStart, value) <> true) Then				    
						Me._FailedPwdAttempWinStart = value
						OnPropertyChanged("FailedPwdAttempWinStart")
				    End If 
			End Set
		End Property

Private _FailedPwdAnsAttemptCount As Nullable(of Decimal)
		<DataMember(),DataField("FAILED_PWD_ANS_ATTEMPT_COUNT")> _
		Public Property FailedPwdAnsAttemptCount() As Nullable(of Decimal)
			Get
				Return Me._FailedPwdAnsAttemptCount
			End Get
			Set(ByVal value As Nullable(of Decimal))
					If (Object.Equals(Me.FailedPwdAnsAttemptCount, value) <> true) Then				    
						Me._FailedPwdAnsAttemptCount = value
						OnPropertyChanged("FailedPwdAnsAttemptCount")
				    End If 
			End Set
		End Property

Private _FailedPwdAnsWinStart As Nullable(of DateTime)
		<DataMember(),DataField("FAILED_PWD_ANS_WIN_START")> _
		Public Property FailedPwdAnsWinStart() As Nullable(of DateTime)
			Get
				Return Me._FailedPwdAnsWinStart
			End Get
			Set(ByVal value As Nullable(of DateTime))
					If (Object.Equals(Me.FailedPwdAnsWinStart, value) <> true) Then				    
						Me._FailedPwdAnsWinStart = value
						OnPropertyChanged("FailedPwdAnsWinStart")
				    End If 
			End Set
		End Property


	
	 
        Public Function Equals1(ByVal other As MasUser) As Boolean Implements System.IEquatable(Of MasUser).Equals
           
           if Me.UserId <> other.UserId Then
                Return False
            End If


             Return True
        End Function
        
         Public Overrides Function GetHashCode() As Integer
            Return GetHashValue(UserId)
        End Function
	
End Class

End Namespace