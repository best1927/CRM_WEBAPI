Imports SsCommon
Imports System.ComponentModel
Imports System.Runtime.Serialization

Namespace DTO

<DataContract(),Table("GENERAL_TYPE")> _
Public Class GeneralType
    Inherits BaseDto
    Implements IEquatable(Of GeneralType)
         
	 
   	Private _Gdtype As String
		<DataMember(),DataField("GDTYPE"),DataAnnotations.Key(), DataAnnotations.Required(AllowEmptyStrings:=False)> _
		Public Property Gdtype() As String
			Get
				Return Me._Gdtype
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Gdtype, value) <> true) Then
						Me._Gdtype = value
						OnPropertyChanged("Gdtype")
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

Private _NameLocal As String
		<DataMember(),DataField("NAME_LOCAL")> _
		Public Property NameLocal() As String
			Get
				Return Me._NameLocal
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.NameLocal, value) <> true) Then				    
						Me._NameLocal = value
						OnPropertyChanged("NameLocal")
				    End If 
			End Set
		End Property

Private _NameEng As String
		<DataMember(),DataField("NAME_ENG")> _
		Public Property NameEng() As String
			Get
				Return Me._NameEng
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.NameEng, value) <> true) Then				    
						Me._NameEng = value
						OnPropertyChanged("NameEng")
				    End If 
			End Set
		End Property

Private _TitleLabelLocal As String
		<DataMember(),DataField("TITLE_LABEL_LOCAL")> _
		Public Property TitleLabelLocal() As String
			Get
				Return Me._TitleLabelLocal
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.TitleLabelLocal, value) <> true) Then				    
						Me._TitleLabelLocal = value
						OnPropertyChanged("TitleLabelLocal")
				    End If 
			End Set
		End Property

Private _TitleLabelEng As String
		<DataMember(),DataField("TITLE_LABEL_ENG")> _
		Public Property TitleLabelEng() As String
			Get
				Return Me._TitleLabelEng
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.TitleLabelEng, value) <> true) Then				    
						Me._TitleLabelEng = value
						OnPropertyChanged("TitleLabelEng")
				    End If 
			End Set
		End Property

Private _CodeLabelLocal As String
		<DataMember(),DataField("CODE_LABEL_LOCAL")> _
		Public Property CodeLabelLocal() As String
			Get
				Return Me._CodeLabelLocal
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.CodeLabelLocal, value) <> true) Then				    
						Me._CodeLabelLocal = value
						OnPropertyChanged("CodeLabelLocal")
				    End If 
			End Set
		End Property

Private _CodeLabelEng As String
		<DataMember(),DataField("CODE_LABEL_ENG")> _
		Public Property CodeLabelEng() As String
			Get
				Return Me._CodeLabelEng
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.CodeLabelEng, value) <> true) Then				    
						Me._CodeLabelEng = value
						OnPropertyChanged("CodeLabelEng")
				    End If 
			End Set
		End Property

Private _CodeLength As Nullable(of Decimal)
		<DataMember(),DataField("CODE_LENGTH")> _
		Public Property CodeLength() As Nullable(of Decimal)
			Get
				Return Me._CodeLength
			End Get
			Set(ByVal value As Nullable(of Decimal))
					If (Object.Equals(Me.CodeLength, value) <> true) Then				    
						Me._CodeLength = value
						OnPropertyChanged("CodeLength")
				    End If 
			End Set
		End Property

Private _Desc1Flag As String
		<DataMember(),DataField("DESC1_FLAG")> _
		Public Property Desc1Flag() As String
			Get
				Return Me._Desc1Flag
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Desc1Flag, value) <> true) Then				    
						Me._Desc1Flag = value
						OnPropertyChanged("Desc1Flag")
				    End If 
			End Set
		End Property

Private _Desc1LabelLocal As String
		<DataMember(),DataField("DESC1_LABEL_LOCAL")> _
		Public Property Desc1LabelLocal() As String
			Get
				Return Me._Desc1LabelLocal
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Desc1LabelLocal, value) <> true) Then				    
						Me._Desc1LabelLocal = value
						OnPropertyChanged("Desc1LabelLocal")
				    End If 
			End Set
		End Property

Private _Desc1LabelEng As String
		<DataMember(),DataField("DESC1_LABEL_ENG")> _
		Public Property Desc1LabelEng() As String
			Get
				Return Me._Desc1LabelEng
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Desc1LabelEng, value) <> true) Then				    
						Me._Desc1LabelEng = value
						OnPropertyChanged("Desc1LabelEng")
				    End If 
			End Set
		End Property

Private _Desc1Length As Nullable(of Decimal)
		<DataMember(),DataField("DESC1_LENGTH")> _
		Public Property Desc1Length() As Nullable(of Decimal)
			Get
				Return Me._Desc1Length
			End Get
			Set(ByVal value As Nullable(of Decimal))
					If (Object.Equals(Me.Desc1Length, value) <> true) Then				    
						Me._Desc1Length = value
						OnPropertyChanged("Desc1Length")
				    End If 
			End Set
		End Property

Private _Desc2Flag As String
		<DataMember(),DataField("DESC2_FLAG")> _
		Public Property Desc2Flag() As String
			Get
				Return Me._Desc2Flag
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Desc2Flag, value) <> true) Then				    
						Me._Desc2Flag = value
						OnPropertyChanged("Desc2Flag")
				    End If 
			End Set
		End Property

Private _Desc2LabelLocal As String
		<DataMember(),DataField("DESC2_LABEL_LOCAL")> _
		Public Property Desc2LabelLocal() As String
			Get
				Return Me._Desc2LabelLocal
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Desc2LabelLocal, value) <> true) Then				    
						Me._Desc2LabelLocal = value
						OnPropertyChanged("Desc2LabelLocal")
				    End If 
			End Set
		End Property

Private _Desc2LabelEng As String
		<DataMember(),DataField("DESC2_LABEL_ENG")> _
		Public Property Desc2LabelEng() As String
			Get
				Return Me._Desc2LabelEng
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Desc2LabelEng, value) <> true) Then				    
						Me._Desc2LabelEng = value
						OnPropertyChanged("Desc2LabelEng")
				    End If 
			End Set
		End Property

Private _Desc2Length As Nullable(of Decimal)
		<DataMember(),DataField("DESC2_LENGTH")> _
		Public Property Desc2Length() As Nullable(of Decimal)
			Get
				Return Me._Desc2Length
			End Get
			Set(ByVal value As Nullable(of Decimal))
					If (Object.Equals(Me.Desc2Length, value) <> true) Then				    
						Me._Desc2Length = value
						OnPropertyChanged("Desc2Length")
				    End If 
			End Set
		End Property

Private _Desc3Flag As String
		<DataMember(),DataField("DESC3_FLAG")> _
		Public Property Desc3Flag() As String
			Get
				Return Me._Desc3Flag
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Desc3Flag, value) <> true) Then				    
						Me._Desc3Flag = value
						OnPropertyChanged("Desc3Flag")
				    End If 
			End Set
		End Property

Private _Desc3LabelLocal As String
		<DataMember(),DataField("DESC3_LABEL_LOCAL")> _
		Public Property Desc3LabelLocal() As String
			Get
				Return Me._Desc3LabelLocal
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Desc3LabelLocal, value) <> true) Then				    
						Me._Desc3LabelLocal = value
						OnPropertyChanged("Desc3LabelLocal")
				    End If 
			End Set
		End Property

Private _Desc3LabelEng As String
		<DataMember(),DataField("DESC3_LABEL_ENG")> _
		Public Property Desc3LabelEng() As String
			Get
				Return Me._Desc3LabelEng
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Desc3LabelEng, value) <> true) Then				    
						Me._Desc3LabelEng = value
						OnPropertyChanged("Desc3LabelEng")
				    End If 
			End Set
		End Property

Private _Desc3Length As Nullable(of Decimal)
		<DataMember(),DataField("DESC3_LENGTH")> _
		Public Property Desc3Length() As Nullable(of Decimal)
			Get
				Return Me._Desc3Length
			End Get
			Set(ByVal value As Nullable(of Decimal))
					If (Object.Equals(Me.Desc3Length, value) <> true) Then				    
						Me._Desc3Length = value
						OnPropertyChanged("Desc3Length")
				    End If 
			End Set
		End Property

Private _Desc4Flag As String
		<DataMember(),DataField("DESC4_FLAG")> _
		Public Property Desc4Flag() As String
			Get
				Return Me._Desc4Flag
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Desc4Flag, value) <> true) Then				    
						Me._Desc4Flag = value
						OnPropertyChanged("Desc4Flag")
				    End If 
			End Set
		End Property

Private _Desc4LabelLocal As String
		<DataMember(),DataField("DESC4_LABEL_LOCAL")> _
		Public Property Desc4LabelLocal() As String
			Get
				Return Me._Desc4LabelLocal
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Desc4LabelLocal, value) <> true) Then				    
						Me._Desc4LabelLocal = value
						OnPropertyChanged("Desc4LabelLocal")
				    End If 
			End Set
		End Property

Private _Desc4LabelEng As String
		<DataMember(),DataField("DESC4_LABEL_ENG")> _
		Public Property Desc4LabelEng() As String
			Get
				Return Me._Desc4LabelEng
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Desc4LabelEng, value) <> true) Then				    
						Me._Desc4LabelEng = value
						OnPropertyChanged("Desc4LabelEng")
				    End If 
			End Set
		End Property

Private _Desc4Length As Nullable(of Decimal)
		<DataMember(),DataField("DESC4_LENGTH")> _
		Public Property Desc4Length() As Nullable(of Decimal)
			Get
				Return Me._Desc4Length
			End Get
			Set(ByVal value As Nullable(of Decimal))
					If (Object.Equals(Me.Desc4Length, value) <> true) Then				    
						Me._Desc4Length = value
						OnPropertyChanged("Desc4Length")
				    End If 
			End Set
		End Property

Private _Desc5Flag As String
		<DataMember(),DataField("DESC5_FLAG")> _
		Public Property Desc5Flag() As String
			Get
				Return Me._Desc5Flag
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Desc5Flag, value) <> true) Then				    
						Me._Desc5Flag = value
						OnPropertyChanged("Desc5Flag")
				    End If 
			End Set
		End Property

Private _Desc5LabelLocal As String
		<DataMember(),DataField("DESC5_LABEL_LOCAL")> _
		Public Property Desc5LabelLocal() As String
			Get
				Return Me._Desc5LabelLocal
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Desc5LabelLocal, value) <> true) Then				    
						Me._Desc5LabelLocal = value
						OnPropertyChanged("Desc5LabelLocal")
				    End If 
			End Set
		End Property

Private _Desc5LabelEng As String
		<DataMember(),DataField("DESC5_LABEL_ENG")> _
		Public Property Desc5LabelEng() As String
			Get
				Return Me._Desc5LabelEng
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Desc5LabelEng, value) <> true) Then				    
						Me._Desc5LabelEng = value
						OnPropertyChanged("Desc5LabelEng")
				    End If 
			End Set
		End Property

Private _Desc5Length As Nullable(of Decimal)
		<DataMember(),DataField("DESC5_LENGTH")> _
		Public Property Desc5Length() As Nullable(of Decimal)
			Get
				Return Me._Desc5Length
			End Get
			Set(ByVal value As Nullable(of Decimal))
					If (Object.Equals(Me.Desc5Length, value) <> true) Then				    
						Me._Desc5Length = value
						OnPropertyChanged("Desc5Length")
				    End If 
			End Set
		End Property

Private _Cond1Flag As String
		<DataMember(),DataField("COND1_FLAG")> _
		Public Property Cond1Flag() As String
			Get
				Return Me._Cond1Flag
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Cond1Flag, value) <> true) Then				    
						Me._Cond1Flag = value
						OnPropertyChanged("Cond1Flag")
				    End If 
			End Set
		End Property

Private _Cond1LabelLocal As String
		<DataMember(),DataField("COND1_LABEL_LOCAL")> _
		Public Property Cond1LabelLocal() As String
			Get
				Return Me._Cond1LabelLocal
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Cond1LabelLocal, value) <> true) Then				    
						Me._Cond1LabelLocal = value
						OnPropertyChanged("Cond1LabelLocal")
				    End If 
			End Set
		End Property

Private _Cond1LabelEng As String
		<DataMember(),DataField("COND1_LABEL_ENG")> _
		Public Property Cond1LabelEng() As String
			Get
				Return Me._Cond1LabelEng
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Cond1LabelEng, value) <> true) Then				    
						Me._Cond1LabelEng = value
						OnPropertyChanged("Cond1LabelEng")
				    End If 
			End Set
		End Property

Private _Cond1Length As Nullable(of Decimal)
		<DataMember(),DataField("COND1_LENGTH")> _
		Public Property Cond1Length() As Nullable(of Decimal)
			Get
				Return Me._Cond1Length
			End Get
			Set(ByVal value As Nullable(of Decimal))
					If (Object.Equals(Me.Cond1Length, value) <> true) Then				    
						Me._Cond1Length = value
						OnPropertyChanged("Cond1Length")
				    End If 
			End Set
		End Property

Private _Cond2Flag As String
		<DataMember(),DataField("COND2_FLAG")> _
		Public Property Cond2Flag() As String
			Get
				Return Me._Cond2Flag
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Cond2Flag, value) <> true) Then				    
						Me._Cond2Flag = value
						OnPropertyChanged("Cond2Flag")
				    End If 
			End Set
		End Property

Private _Cond2LabelLocal As String
		<DataMember(),DataField("COND2_LABEL_LOCAL")> _
		Public Property Cond2LabelLocal() As String
			Get
				Return Me._Cond2LabelLocal
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Cond2LabelLocal, value) <> true) Then				    
						Me._Cond2LabelLocal = value
						OnPropertyChanged("Cond2LabelLocal")
				    End If 
			End Set
		End Property

Private _Cond2LabelEng As String
		<DataMember(),DataField("COND2_LABEL_ENG")> _
		Public Property Cond2LabelEng() As String
			Get
				Return Me._Cond2LabelEng
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Cond2LabelEng, value) <> true) Then				    
						Me._Cond2LabelEng = value
						OnPropertyChanged("Cond2LabelEng")
				    End If 
			End Set
		End Property

Private _Cond2Length As Nullable(of Decimal)
		<DataMember(),DataField("COND2_LENGTH")> _
		Public Property Cond2Length() As Nullable(of Decimal)
			Get
				Return Me._Cond2Length
			End Get
			Set(ByVal value As Nullable(of Decimal))
					If (Object.Equals(Me.Cond2Length, value) <> true) Then				    
						Me._Cond2Length = value
						OnPropertyChanged("Cond2Length")
				    End If 
			End Set
		End Property

Private _Cond3Flag As String
		<DataMember(),DataField("COND3_FLAG")> _
		Public Property Cond3Flag() As String
			Get
				Return Me._Cond3Flag
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Cond3Flag, value) <> true) Then				    
						Me._Cond3Flag = value
						OnPropertyChanged("Cond3Flag")
				    End If 
			End Set
		End Property

Private _Cond3LabelLocal As String
		<DataMember(),DataField("COND3_LABEL_LOCAL")> _
		Public Property Cond3LabelLocal() As String
			Get
				Return Me._Cond3LabelLocal
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Cond3LabelLocal, value) <> true) Then				    
						Me._Cond3LabelLocal = value
						OnPropertyChanged("Cond3LabelLocal")
				    End If 
			End Set
		End Property

Private _Cond3LabelEng As String
		<DataMember(),DataField("COND3_LABEL_ENG")> _
		Public Property Cond3LabelEng() As String
			Get
				Return Me._Cond3LabelEng
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Cond3LabelEng, value) <> true) Then				    
						Me._Cond3LabelEng = value
						OnPropertyChanged("Cond3LabelEng")
				    End If 
			End Set
		End Property

Private _Cond3Length As Nullable(of Decimal)
		<DataMember(),DataField("COND3_LENGTH")> _
		Public Property Cond3Length() As Nullable(of Decimal)
			Get
				Return Me._Cond3Length
			End Get
			Set(ByVal value As Nullable(of Decimal))
					If (Object.Equals(Me.Cond3Length, value) <> true) Then				    
						Me._Cond3Length = value
						OnPropertyChanged("Cond3Length")
				    End If 
			End Set
		End Property

Private _Cond4Flag As String
		<DataMember(),DataField("COND4_FLAG")> _
		Public Property Cond4Flag() As String
			Get
				Return Me._Cond4Flag
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Cond4Flag, value) <> true) Then				    
						Me._Cond4Flag = value
						OnPropertyChanged("Cond4Flag")
				    End If 
			End Set
		End Property

Private _Cond4LabelLocal As String
		<DataMember(),DataField("COND4_LABEL_LOCAL")> _
		Public Property Cond4LabelLocal() As String
			Get
				Return Me._Cond4LabelLocal
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Cond4LabelLocal, value) <> true) Then				    
						Me._Cond4LabelLocal = value
						OnPropertyChanged("Cond4LabelLocal")
				    End If 
			End Set
		End Property

Private _Cond4LabelEng As String
		<DataMember(),DataField("COND4_LABEL_ENG")> _
		Public Property Cond4LabelEng() As String
			Get
				Return Me._Cond4LabelEng
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Cond4LabelEng, value) <> true) Then				    
						Me._Cond4LabelEng = value
						OnPropertyChanged("Cond4LabelEng")
				    End If 
			End Set
		End Property

Private _Cond4Length As Nullable(of Decimal)
		<DataMember(),DataField("COND4_LENGTH")> _
		Public Property Cond4Length() As Nullable(of Decimal)
			Get
				Return Me._Cond4Length
			End Get
			Set(ByVal value As Nullable(of Decimal))
					If (Object.Equals(Me.Cond4Length, value) <> true) Then				    
						Me._Cond4Length = value
						OnPropertyChanged("Cond4Length")
				    End If 
			End Set
		End Property

Private _Cond5Flag As String
		<DataMember(),DataField("COND5_FLAG")> _
		Public Property Cond5Flag() As String
			Get
				Return Me._Cond5Flag
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Cond5Flag, value) <> true) Then				    
						Me._Cond5Flag = value
						OnPropertyChanged("Cond5Flag")
				    End If 
			End Set
		End Property

Private _Cond5LabelLocal As String
		<DataMember(),DataField("COND5_LABEL_LOCAL")> _
		Public Property Cond5LabelLocal() As String
			Get
				Return Me._Cond5LabelLocal
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Cond5LabelLocal, value) <> true) Then				    
						Me._Cond5LabelLocal = value
						OnPropertyChanged("Cond5LabelLocal")
				    End If 
			End Set
		End Property

Private _Cond5LabelEng As String
		<DataMember(),DataField("COND5_LABEL_ENG")> _
		Public Property Cond5LabelEng() As String
			Get
				Return Me._Cond5LabelEng
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Cond5LabelEng, value) <> true) Then				    
						Me._Cond5LabelEng = value
						OnPropertyChanged("Cond5LabelEng")
				    End If 
			End Set
		End Property

Private _Cond5Length As Nullable(of Decimal)
		<DataMember(),DataField("COND5_LENGTH")> _
		Public Property Cond5Length() As Nullable(of Decimal)
			Get
				Return Me._Cond5Length
			End Get
			Set(ByVal value As Nullable(of Decimal))
					If (Object.Equals(Me.Cond5Length, value) <> true) Then				    
						Me._Cond5Length = value
						OnPropertyChanged("Cond5Length")
				    End If 
			End Set
		End Property

Private _TypeAllowFlag As String
		<DataMember(),DataField("TYPE_ALLOW_FLAG")> _
		Public Property TypeAllowFlag() As String
			Get
				Return Me._TypeAllowFlag
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.TypeAllowFlag, value) <> true) Then				    
						Me._TypeAllowFlag = value
						OnPropertyChanged("TypeAllowFlag")
				    End If 
			End Set
		End Property

Private _Remark As String
		<DataMember(),DataField("REMARK")> _
		Public Property Remark() As String
			Get
				Return Me._Remark
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Remark, value) <> true) Then				    
						Me._Remark = value
						OnPropertyChanged("Remark")
				    End If 
			End Set
		End Property

Private _EntryStatus As String
		<DataMember(),DataField("ENTRY_STATUS")> _
		Public Property EntryStatus() As String
			Get
				Return Me._EntryStatus
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.EntryStatus, value) <> true) Then				    
						Me._EntryStatus = value
						OnPropertyChanged("EntryStatus")
				    End If 
			End Set
		End Property

Private _EntryStatusDate As Nullable(of DateTime)
		<DataMember(),DataField("ENTRY_STATUS_DATE")> _
		Public Property EntryStatusDate() As Nullable(of DateTime)
			Get
				Return Me._EntryStatusDate
			End Get
			Set(ByVal value As Nullable(of DateTime))
					If (Object.Equals(Me.EntryStatusDate, value) <> true) Then				    
						Me._EntryStatusDate = value
						OnPropertyChanged("EntryStatusDate")
				    End If 
			End Set
		End Property


	
	 
        Public Function Equals1(ByVal other As GeneralType) As Boolean Implements System.IEquatable(Of GeneralType).Equals
           
           if Me.Gdtype <> other.Gdtype Then
                Return False
            End If


             Return True
        End Function
        
         Public Overrides Function GetHashCode() As Integer
            Return GetHashValue(Gdtype)
        End Function
	
End Class

End Namespace