Imports SsCommon
Imports System.ComponentModel
Imports System.Runtime.Serialization

Namespace DTO

<DataContract(),Table("CRM_ACTIVITIES")> _
Public Class CrmActivities
    Inherits BaseDto
    Implements IEquatable(Of CrmActivities)
         
	 
   	Private _AId As Decimal
		<DataMember(),DataField("A_ID"),DataAnnotations.Key()> _
		Public Property AId() As Decimal
			Get
				Return Me._AId
			End Get
			Set(ByVal value As Decimal)
					If (Object.ReferenceEquals(Me.AId, value) <> true) Then
						Me._AId = value
						OnPropertyChanged("AId")
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

Private _Descr2 As String
		<DataMember(),DataField("DESCR2")> _
		Public Property Descr2() As String
			Get
				Return Me._Descr2
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Descr2, value) <> true) Then				    
						Me._Descr2 = value
						OnPropertyChanged("Descr2")
				    End If 
			End Set
		End Property

Private _ActivityId As Nullable(of Decimal)
		<DataMember(),DataField("ACTIVITY_ID")> _
		Public Property ActivityId() As Nullable(of Decimal)
			Get
				Return Me._ActivityId
			End Get
			Set(ByVal value As Nullable(of Decimal))
					If (Object.Equals(Me.ActivityId, value) <> true) Then				    
						Me._ActivityId = value
						OnPropertyChanged("ActivityId")
				    End If 
			End Set
		End Property

Private _ActivityDate As Nullable(of DateTime)
		<DataMember(),DataField("ACTIVITY_DATE")> _
		Public Property ActivityDate() As Nullable(of DateTime)
			Get
				Return Me._ActivityDate
			End Get
			Set(ByVal value As Nullable(of DateTime))
					If (Object.Equals(Me.ActivityDate, value) <> true) Then				    
						Me._ActivityDate = value
						OnPropertyChanged("ActivityDate")
				    End If 
			End Set
		End Property

Private _ActivityTime As String
		<DataMember(),DataField("ACTIVITY_TIME")> _
		Public Property ActivityTime() As String
			Get
				Return Me._ActivityTime
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.ActivityTime, value) <> true) Then				    
						Me._ActivityTime = value
						OnPropertyChanged("ActivityTime")
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

Private _Topic As String
		<DataMember(),DataField("TOPIC")> _
		Public Property Topic() As String
			Get
				Return Me._Topic
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Topic, value) <> true) Then				    
						Me._Topic = value
						OnPropertyChanged("Topic")
				    End If 
			End Set
		End Property

Private _Descr1 As String
		<DataMember(),DataField("DESCR1")> _
		Public Property Descr1() As String
			Get
				Return Me._Descr1
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Descr1, value) <> true) Then				    
						Me._Descr1 = value
						OnPropertyChanged("Descr1")
				    End If 
			End Set
		End Property


	
	 
        Public Function Equals1(ByVal other As CrmActivities) As Boolean Implements System.IEquatable(Of CrmActivities).Equals
           
           if Me.AId <> other.AId Then
                Return False
            End If


             Return True
        End Function
        
         Public Overrides Function GetHashCode() As Integer
            Return GetHashValue(AId)
        End Function
	
End Class

End Namespace