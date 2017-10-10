Imports SsCommon
Imports System.ComponentModel
Imports System.Runtime.Serialization

Namespace DTO

<DataContract(),Table("CRM_NOTES")> _
Public Class CrmNotes
    Inherits BaseDto
    Implements IEquatable(Of CrmNotes)
         
	 
   	Private _NoteId As Decimal
		<DataMember(),DataField("NOTE_ID"),DataAnnotations.Key()> _
		Public Property NoteId() As Decimal
			Get
				Return Me._NoteId
			End Get
			Set(ByVal value As Decimal)
					If (Object.ReferenceEquals(Me.NoteId, value) <> true) Then
						Me._NoteId = value
						OnPropertyChanged("NoteId")
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

Private _TitleName As String
		<DataMember(),DataField("TITLE_NAME")> _
		Public Property TitleName() As String
			Get
				Return Me._TitleName
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.TitleName, value) <> true) Then				    
						Me._TitleName = value
						OnPropertyChanged("TitleName")
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


	
	 
        Public Function Equals1(ByVal other As CrmNotes) As Boolean Implements System.IEquatable(Of CrmNotes).Equals
           
           if Me.NoteId <> other.NoteId Then
                Return False
            End If


             Return True
        End Function
        
         Public Overrides Function GetHashCode() As Integer
            Return GetHashValue(NoteId)
        End Function
	
End Class

End Namespace