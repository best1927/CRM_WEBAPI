Imports SsCommon
Imports System.ComponentModel
Imports System.Runtime.Serialization

Namespace DTO

<DataContract(),Table("CRM_PROJECT")> _
Public Class CrmProject
    Inherits BaseDto
    Implements IEquatable(Of CrmProject)
         
	 
   	Private _ProjectId As Decimal
		<DataMember(),DataField("PROJECT_ID"),DataAnnotations.Key()> _
		Public Property ProjectId() As Decimal
			Get
				Return Me._ProjectId
			End Get
			Set(ByVal value As Decimal)
					If (Object.ReferenceEquals(Me.ProjectId, value) <> true) Then
						Me._ProjectId = value
						OnPropertyChanged("ProjectId")
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

Private _StageId As Nullable(of Decimal)
		<DataMember(),DataField("STAGE_ID")> _
		Public Property StageId() As Nullable(of Decimal)
			Get
				Return Me._StageId
			End Get
			Set(ByVal value As Nullable(of Decimal))
					If (Object.Equals(Me.StageId, value) <> true) Then				    
						Me._StageId = value
						OnPropertyChanged("StageId")
				    End If 
			End Set
		End Property

Private _PipelineId As Nullable(of Decimal)
		<DataMember(),DataField("PIPELINE_ID")> _
		Public Property PipelineId() As Nullable(of Decimal)
			Get
				Return Me._PipelineId
			End Get
			Set(ByVal value As Nullable(of Decimal))
					If (Object.Equals(Me.PipelineId, value) <> true) Then				    
						Me._PipelineId = value
						OnPropertyChanged("PipelineId")
				    End If 
			End Set
		End Property

Private _ProjectVal As Nullable(of Decimal)
		<DataMember(),DataField("PROJECT_VAL")> _
		Public Property ProjectVal() As Nullable(of Decimal)
			Get
				Return Me._ProjectVal
			End Get
			Set(ByVal value As Nullable(of Decimal))
					If (Object.Equals(Me.ProjectVal, value) <> true) Then				    
						Me._ProjectVal = value
						OnPropertyChanged("ProjectVal")
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

Private _ProjectCat As String
		<DataMember(),DataField("PROJECT_CAT")> _
		Public Property ProjectCat() As String
			Get
				Return Me._ProjectCat
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.ProjectCat, value) <> true) Then				    
						Me._ProjectCat = value
						OnPropertyChanged("ProjectCat")
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


	
	 
        Public Function Equals1(ByVal other As CrmProject) As Boolean Implements System.IEquatable(Of CrmProject).Equals
           
           if Me.ProjectId <> other.ProjectId Then
                Return False
            End If


             Return True
        End Function
        
         Public Overrides Function GetHashCode() As Integer
            Return GetHashValue(ProjectId)
        End Function
	
End Class

End Namespace