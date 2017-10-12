Imports SsCommon
Imports System.ComponentModel
Imports System.Runtime.Serialization

Namespace DTO

<DataContract(),Table("CRM_OPPORTUNITY")> _
Public Class CrmOpportunity
    Inherits BaseDto
    Implements IEquatable(Of CrmOpportunity)
         
	 
   	Private _OppuId As Decimal
		<DataMember(),DataField("OPPU_ID"),DataAnnotations.Key()> _
		Public Property OppuId() As Decimal
			Get
				Return Me._OppuId
			End Get
			Set(ByVal value As Decimal)
					If (Object.ReferenceEquals(Me.OppuId, value) <> true) Then
						Me._OppuId = value
						OnPropertyChanged("OppuId")
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

Private _OppuSt As String
		<DataMember(),DataField("OPPU_ST")> _
		Public Property OppuSt() As String
			Get
				Return Me._OppuSt
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.OppuSt, value) <> true) Then				    
						Me._OppuSt = value
						OnPropertyChanged("OppuSt")
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

Private _OppuCat As String
		<DataMember(),DataField("OPPU_CAT")> _
		Public Property OppuCat() As String
			Get
				Return Me._OppuCat
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.OppuCat, value) <> true) Then				    
						Me._OppuCat = value
						OnPropertyChanged("OppuCat")
				    End If 
			End Set
		End Property

Private _ProbWin As Nullable(of Decimal)
		<DataMember(),DataField("PROB_WIN")> _
		Public Property ProbWin() As Nullable(of Decimal)
			Get
				Return Me._ProbWin
			End Get
			Set(ByVal value As Nullable(of Decimal))
					If (Object.Equals(Me.ProbWin, value) <> true) Then				    
						Me._ProbWin = value
						OnPropertyChanged("ProbWin")
				    End If 
			End Set
		End Property

Private _ForecastCloseDt As Nullable(of DateTime)
		<DataMember(),DataField("FORECAST_CLOSE_DT")> _
		Public Property ForecastCloseDt() As Nullable(of DateTime)
			Get
				Return Me._ForecastCloseDt
			End Get
			Set(ByVal value As Nullable(of DateTime))
					If (Object.Equals(Me.ForecastCloseDt, value) <> true) Then				    
						Me._ForecastCloseDt = value
						OnPropertyChanged("ForecastCloseDt")
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

Private _OppuVal As Nullable(of Decimal)
		<DataMember(),DataField("OPPU_VAL")> _
		Public Property OppuVal() As Nullable(of Decimal)
			Get
				Return Me._OppuVal
			End Get
			Set(ByVal value As Nullable(of Decimal))
					If (Object.Equals(Me.OppuVal, value) <> true) Then				    
						Me._OppuVal = value
						OnPropertyChanged("OppuVal")
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


	
	 
        Public Function Equals1(ByVal other As CrmOpportunity) As Boolean Implements System.IEquatable(Of CrmOpportunity).Equals
           
           if Me.OppuId <> other.OppuId Then
                Return False
            End If


             Return True
        End Function
        
         Public Overrides Function GetHashCode() As Integer
            Return GetHashValue(OppuId)
        End Function
	
End Class

End Namespace