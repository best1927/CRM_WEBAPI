Imports SsCommon
Imports System.ComponentModel
Imports System.Runtime.Serialization

Namespace DTO

<DataContract(),Table("CRM_TASKS")> _
Public Class CrmTasks
    Inherits BaseDto
    Implements IEquatable(Of CrmTasks)
         
	 
   	Private _TaskId As Decimal
		<DataMember(),DataField("TASK_ID"),DataAnnotations.Key()> _
		Public Property TaskId() As Decimal
			Get
				Return Me._TaskId
			End Get
			Set(ByVal value As Decimal)
					If (Object.ReferenceEquals(Me.TaskId, value) <> true) Then
						Me._TaskId = value
						OnPropertyChanged("TaskId")
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

Private _OwnerCat As String
		<DataMember(),DataField("OWNER_CAT")> _
		Public Property OwnerCat() As String
			Get
				Return Me._OwnerCat
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.OwnerCat, value) <> true) Then				    
						Me._OwnerCat = value
						OnPropertyChanged("OwnerCat")
				    End If 
			End Set
		End Property

Private _OwnerId As Nullable(of Decimal)
		<DataMember(),DataField("OWNER_ID")> _
		Public Property OwnerId() As Nullable(of Decimal)
			Get
				Return Me._OwnerId
			End Get
			Set(ByVal value As Nullable(of Decimal))
					If (Object.Equals(Me.OwnerId, value) <> true) Then				    
						Me._OwnerId = value
						OnPropertyChanged("OwnerId")
				    End If 
			End Set
		End Property

Private _AssignCat As String
		<DataMember(),DataField("ASSIGN_CAT")> _
		Public Property AssignCat() As String
			Get
				Return Me._AssignCat
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.AssignCat, value) <> true) Then				    
						Me._AssignCat = value
						OnPropertyChanged("AssignCat")
				    End If 
			End Set
		End Property

Private _AssignId As String
		<DataMember(),DataField("ASSIGN_ID")> _
		Public Property AssignId() As String
			Get
				Return Me._AssignId
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.AssignId, value) <> true) Then				    
						Me._AssignId = value
						OnPropertyChanged("AssignId")
				    End If 
			End Set
		End Property

Private _TaskName As String
		<DataMember(),DataField("TASK_NAME")> _
		Public Property TaskName() As String
			Get
				Return Me._TaskName
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.TaskName, value) <> true) Then				    
						Me._TaskName = value
						OnPropertyChanged("TaskName")
				    End If 
			End Set
		End Property

Private _TaskSt As String
		<DataMember(),DataField("TASK_ST")> _
		Public Property TaskSt() As String
			Get
				Return Me._TaskSt
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.TaskSt, value) <> true) Then				    
						Me._TaskSt = value
						OnPropertyChanged("TaskSt")
				    End If 
			End Set
		End Property

Private _TaskCat As String
		<DataMember(),DataField("TASK_CAT")> _
		Public Property TaskCat() As String
			Get
				Return Me._TaskCat
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.TaskCat, value) <> true) Then				    
						Me._TaskCat = value
						OnPropertyChanged("TaskCat")
				    End If 
			End Set
		End Property

Private _TaskProgress As Nullable(of Decimal)
		<DataMember(),DataField("TASK_PROGRESS")> _
		Public Property TaskProgress() As Nullable(of Decimal)
			Get
				Return Me._TaskProgress
			End Get
			Set(ByVal value As Nullable(of Decimal))
					If (Object.Equals(Me.TaskProgress, value) <> true) Then				    
						Me._TaskProgress = value
						OnPropertyChanged("TaskProgress")
				    End If 
			End Set
		End Property

Private _DueDt As Nullable(of DateTime)
		<DataMember(),DataField("DUE_DT")> _
		Public Property DueDt() As Nullable(of DateTime)
			Get
				Return Me._DueDt
			End Get
			Set(ByVal value As Nullable(of DateTime))
					If (Object.Equals(Me.DueDt, value) <> true) Then				    
						Me._DueDt = value
						OnPropertyChanged("DueDt")
				    End If 
			End Set
		End Property

Private _StartDt As Nullable(of DateTime)
		<DataMember(),DataField("START_DT")> _
		Public Property StartDt() As Nullable(of DateTime)
			Get
				Return Me._StartDt
			End Get
			Set(ByVal value As Nullable(of DateTime))
					If (Object.Equals(Me.StartDt, value) <> true) Then				    
						Me._StartDt = value
						OnPropertyChanged("StartDt")
				    End If 
			End Set
		End Property

Private _EndDt As Nullable(of DateTime)
		<DataMember(),DataField("END_DT")> _
		Public Property EndDt() As Nullable(of DateTime)
			Get
				Return Me._EndDt
			End Get
			Set(ByVal value As Nullable(of DateTime))
					If (Object.Equals(Me.EndDt, value) <> true) Then				    
						Me._EndDt = value
						OnPropertyChanged("EndDt")
				    End If 
			End Set
		End Property

Private _RepeatYn As String
		<DataMember(),DataField("REPEAT_YN")> _
		Public Property RepeatYn() As String
			Get
				Return Me._RepeatYn
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.RepeatYn, value) <> true) Then				    
						Me._RepeatYn = value
						OnPropertyChanged("RepeatYn")
				    End If 
			End Set
		End Property

Private _RepeatType As String
		<DataMember(),DataField("REPEAT_TYPE")> _
		Public Property RepeatType() As String
			Get
				Return Me._RepeatType
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.RepeatType, value) <> true) Then				    
						Me._RepeatType = value
						OnPropertyChanged("RepeatType")
				    End If 
			End Set
		End Property

Private _NotifyYn As String
		<DataMember(),DataField("NOTIFY_YN")> _
		Public Property NotifyYn() As String
			Get
				Return Me._NotifyYn
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.NotifyYn, value) <> true) Then				    
						Me._NotifyYn = value
						OnPropertyChanged("NotifyYn")
				    End If 
			End Set
		End Property

Private _Schedule As String
		<DataMember(),DataField("SCHEDULE")> _
		Public Property Schedule() As String
			Get
				Return Me._Schedule
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Schedule, value) <> true) Then				    
						Me._Schedule = value
						OnPropertyChanged("Schedule")
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

Private _Priority As String
		<DataMember(),DataField("PRIORITY")> _
		Public Property Priority() As String
			Get
				Return Me._Priority
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Priority, value) <> true) Then				    
						Me._Priority = value
						OnPropertyChanged("Priority")
				    End If 
			End Set
		End Property

Private _Isdeleted As String
		<DataMember(),DataField("ISDELETED")> _
		Public Property Isdeleted() As String
			Get
				Return Me._Isdeleted
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Isdeleted, value) <> true) Then				    
						Me._Isdeleted = value
						OnPropertyChanged("Isdeleted")
				    End If 
			End Set
		End Property

Private _AId As Nullable(of Decimal)
		<DataMember(),DataField("A_ID")> _
		Public Property AId() As Nullable(of Decimal)
			Get
				Return Me._AId
			End Get
			Set(ByVal value As Nullable(of Decimal))
					If (Object.Equals(Me.AId, value) <> true) Then				    
						Me._AId = value
						OnPropertyChanged("AId")
				    End If 
			End Set
		End Property

Private _VisibileType As String
		<DataMember(),DataField("VISIBILE_TYPE")> _
		Public Property VisibileType() As String
			Get
				Return Me._VisibileType
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.VisibileType, value) <> true) Then				    
						Me._VisibileType = value
						OnPropertyChanged("VisibileType")
				    End If 
			End Set
		End Property

Private _VisibileCd As String
		<DataMember(),DataField("VISIBILE_CD")> _
		Public Property VisibileCd() As String
			Get
				Return Me._VisibileCd
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.VisibileCd, value) <> true) Then				    
						Me._VisibileCd = value
						OnPropertyChanged("VisibileCd")
				    End If 
			End Set
		End Property

Private _RefSapcode As String
		<DataMember(),DataField("REF_SAPCODE")> _
		Public Property RefSapcode() As String
			Get
				Return Me._RefSapcode
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.RefSapcode, value) <> true) Then				    
						Me._RefSapcode = value
						OnPropertyChanged("RefSapcode")
				    End If 
			End Set
		End Property

Private _RefMdm As String
		<DataMember(),DataField("REF_MDM")> _
		Public Property RefMdm() As String
			Get
				Return Me._RefMdm
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.RefMdm, value) <> true) Then				    
						Me._RefMdm = value
						OnPropertyChanged("RefMdm")
				    End If 
			End Set
		End Property

Private _Createuser As String
		<DataMember(),DataField("CREATEUSER")> _
		Public Property Createuser() As String
			Get
				Return Me._Createuser
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Createuser, value) <> true) Then				    
						Me._Createuser = value
						OnPropertyChanged("Createuser")
				    End If 
			End Set
		End Property

Private _Createdate As Nullable(of DateTime)
		<DataMember(),DataField("CREATEDATE")> _
		Public Property Createdate() As Nullable(of DateTime)
			Get
				Return Me._Createdate
			End Get
			Set(ByVal value As Nullable(of DateTime))
					If (Object.Equals(Me.Createdate, value) <> true) Then				    
						Me._Createdate = value
						OnPropertyChanged("Createdate")
				    End If 
			End Set
		End Property

Private _Modifyuser As String
		<DataMember(),DataField("MODIFYUSER")> _
		Public Property Modifyuser() As String
			Get
				Return Me._Modifyuser
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Modifyuser, value) <> true) Then				    
						Me._Modifyuser = value
						OnPropertyChanged("Modifyuser")
				    End If 
			End Set
		End Property

Private _Modifydate As Nullable(of DateTime)
		<DataMember(),DataField("MODIFYDATE")> _
		Public Property Modifydate() As Nullable(of DateTime)
			Get
				Return Me._Modifydate
			End Get
			Set(ByVal value As Nullable(of DateTime))
					If (Object.Equals(Me.Modifydate, value) <> true) Then				    
						Me._Modifydate = value
						OnPropertyChanged("Modifydate")
				    End If 
			End Set
		End Property

Private _ActivityCat As String
		<DataMember(),DataField("ACTIVITY_CAT")> _
		Public Property ActivityCat() As String
			Get
				Return Me._ActivityCat
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.ActivityCat, value) <> true) Then				    
						Me._ActivityCat = value
						OnPropertyChanged("ActivityCat")
				    End If 
			End Set
		End Property


	
	 
        Public Function Equals1(ByVal other As CrmTasks) As Boolean Implements System.IEquatable(Of CrmTasks).Equals
           
           if Me.TaskId <> other.TaskId Then
                Return False
            End If


             Return True
        End Function
        
         Public Overrides Function GetHashCode() As Integer
            Return GetHashValue(TaskId)
        End Function
	
End Class

End Namespace