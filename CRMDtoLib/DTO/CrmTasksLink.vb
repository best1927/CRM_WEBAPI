Imports SsCommon
Imports System.ComponentModel
Imports System.Runtime.Serialization

Namespace DTO

<DataContract(),Table("CRM_TASKS_LINK")> _
Public Class CrmTasksLink
    Inherits BaseDto
    Implements IEquatable(Of CrmTasksLink)
         
	 
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

Private _Seq As Decimal
		<DataMember(),DataField("SEQ"),DataAnnotations.Key()> _
		Public Property Seq() As Decimal
			Get
				Return Me._Seq
			End Get
			Set(ByVal value As Decimal)
					If (Object.ReferenceEquals(Me.Seq, value) <> true) Then
						Me._Seq = value
						OnPropertyChanged("Seq")
					End If  
			End Set
		End Property


	
	Private _GroupType As String
		<DataMember(),DataField("GROUP_TYPE")> _
		Public Property GroupType() As String
			Get
				Return Me._GroupType
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.GroupType, value) <> true) Then				    
						Me._GroupType = value
						OnPropertyChanged("GroupType")
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


	
	 
        Public Function Equals1(ByVal other As CrmTasksLink) As Boolean Implements System.IEquatable(Of CrmTasksLink).Equals
           
           if Me.TaskId <> other.TaskId Then
                Return False
            End If

if Me.Seq <> other.Seq Then
                Return False
            End If


             Return True
        End Function
        
         Public Overrides Function GetHashCode() As Integer
            Return GetHashValue(TaskId) Xor GetHashValue(Seq)
        End Function
	
End Class

End Namespace