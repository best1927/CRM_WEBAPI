Imports SsCommon
Imports System.ComponentModel
Imports System.Runtime.Serialization

Namespace DTO

<DataContract(),Table("GENERAL_DESC")> _
Public Class GeneralDesc
    Inherits BaseDto
    Implements IEquatable(Of GeneralDesc)
         
	 
   	Private _Gdcode As String
		<DataMember(),DataField("GDCODE"),DataAnnotations.Key(), DataAnnotations.Required(AllowEmptyStrings:=False)> _
		Public Property Gdcode() As String
			Get
				Return Me._Gdcode
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Gdcode, value) <> true) Then
						Me._Gdcode = value
						OnPropertyChanged("Gdcode")
					End If  
			End Set
		End Property


	
	Private _Gdtype As String
		<DataMember(),DataField("GDTYPE")> _
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

Private _Desc1 As String
		<DataMember(),DataField("DESC1")> _
		Public Property Desc1() As String
			Get
				Return Me._Desc1
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Desc1, value) <> true) Then				    
						Me._Desc1 = value
						OnPropertyChanged("Desc1")
				    End If 
			End Set
		End Property

Private _Desc2 As String
		<DataMember(),DataField("DESC2")> _
		Public Property Desc2() As String
			Get
				Return Me._Desc2
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Desc2, value) <> true) Then				    
						Me._Desc2 = value
						OnPropertyChanged("Desc2")
				    End If 
			End Set
		End Property

Private _Desc3 As String
		<DataMember(),DataField("DESC3")> _
		Public Property Desc3() As String
			Get
				Return Me._Desc3
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Desc3, value) <> true) Then				    
						Me._Desc3 = value
						OnPropertyChanged("Desc3")
				    End If 
			End Set
		End Property

Private _Desc4 As String
		<DataMember(),DataField("DESC4")> _
		Public Property Desc4() As String
			Get
				Return Me._Desc4
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Desc4, value) <> true) Then				    
						Me._Desc4 = value
						OnPropertyChanged("Desc4")
				    End If 
			End Set
		End Property

Private _Desc5 As String
		<DataMember(),DataField("DESC5")> _
		Public Property Desc5() As String
			Get
				Return Me._Desc5
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Desc5, value) <> true) Then				    
						Me._Desc5 = value
						OnPropertyChanged("Desc5")
				    End If 
			End Set
		End Property

Private _Cond1 As String
		<DataMember(),DataField("COND1")> _
		Public Property Cond1() As String
			Get
				Return Me._Cond1
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Cond1, value) <> true) Then				    
						Me._Cond1 = value
						OnPropertyChanged("Cond1")
				    End If 
			End Set
		End Property

Private _Cond2 As String
		<DataMember(),DataField("COND2")> _
		Public Property Cond2() As String
			Get
				Return Me._Cond2
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Cond2, value) <> true) Then				    
						Me._Cond2 = value
						OnPropertyChanged("Cond2")
				    End If 
			End Set
		End Property

Private _Cond3 As String
		<DataMember(),DataField("COND3")> _
		Public Property Cond3() As String
			Get
				Return Me._Cond3
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Cond3, value) <> true) Then				    
						Me._Cond3 = value
						OnPropertyChanged("Cond3")
				    End If 
			End Set
		End Property

Private _Cond4 As String
		<DataMember(),DataField("COND4")> _
		Public Property Cond4() As String
			Get
				Return Me._Cond4
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Cond4, value) <> true) Then				    
						Me._Cond4 = value
						OnPropertyChanged("Cond4")
				    End If 
			End Set
		End Property

Private _Cond5 As String
		<DataMember(),DataField("COND5")> _
		Public Property Cond5() As String
			Get
				Return Me._Cond5
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Cond5, value) <> true) Then				    
						Me._Cond5 = value
						OnPropertyChanged("Cond5")
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


	
	 
        Public Function Equals1(ByVal other As GeneralDesc) As Boolean Implements System.IEquatable(Of GeneralDesc).Equals
           
           if Me.Gdcode <> other.Gdcode Then
                Return False
            End If


             Return True
        End Function
        
         Public Overrides Function GetHashCode() As Integer
            Return GetHashValue(Gdcode)
        End Function
	
End Class

End Namespace