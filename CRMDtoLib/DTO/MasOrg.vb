Imports SsCommon
Imports System.ComponentModel
Imports System.Runtime.Serialization

Namespace DTO

<DataContract(),Table("MAS_ORG")> _
Public Class MasOrg
    Inherits BaseDto
    Implements IEquatable(Of MasOrg)
         
	 
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

Private _VatFlag As String
		<DataMember(),DataField("VAT_FLAG")> _
		Public Property VatFlag() As String
			Get
				Return Me._VatFlag
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.VatFlag, value) <> true) Then				    
						Me._VatFlag = value
						OnPropertyChanged("VatFlag")
				    End If 
			End Set
		End Property

Private _RefCustomerCode As String
		<DataMember(),DataField("REF_CUSTOMER_CODE")> _
		Public Property RefCustomerCode() As String
			Get
				Return Me._RefCustomerCode
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.RefCustomerCode, value) <> true) Then				    
						Me._RefCustomerCode = value
						OnPropertyChanged("RefCustomerCode")
				    End If 
			End Set
		End Property

Private _LocalCurrencyCode As String
		<DataMember(),DataField("LOCAL_CURRENCY_CODE")> _
		Public Property LocalCurrencyCode() As String
			Get
				Return Me._LocalCurrencyCode
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.LocalCurrencyCode, value) <> true) Then				    
						Me._LocalCurrencyCode = value
						OnPropertyChanged("LocalCurrencyCode")
				    End If 
			End Set
		End Property

Private _RefProductStockOrg As String
		<DataMember(),DataField("REF_PRODUCT_STOCK_ORG")> _
		Public Property RefProductStockOrg() As String
			Get
				Return Me._RefProductStockOrg
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.RefProductStockOrg, value) <> true) Then				    
						Me._RefProductStockOrg = value
						OnPropertyChanged("RefProductStockOrg")
				    End If 
			End Set
		End Property

Private _RefProductPurchaseOrg As String
		<DataMember(),DataField("REF_PRODUCT_PURCHASE_ORG")> _
		Public Property RefProductPurchaseOrg() As String
			Get
				Return Me._RefProductPurchaseOrg
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.RefProductPurchaseOrg, value) <> true) Then				    
						Me._RefProductPurchaseOrg = value
						OnPropertyChanged("RefProductPurchaseOrg")
				    End If 
			End Set
		End Property

Private _RefProductSaleOrg As String
		<DataMember(),DataField("REF_PRODUCT_SALE_ORG")> _
		Public Property RefProductSaleOrg() As String
			Get
				Return Me._RefProductSaleOrg
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.RefProductSaleOrg, value) <> true) Then				    
						Me._RefProductSaleOrg = value
						OnPropertyChanged("RefProductSaleOrg")
				    End If 
			End Set
		End Property

Private _RefProductProductionOrg As String
		<DataMember(),DataField("REF_PRODUCT_PRODUCTION_ORG")> _
		Public Property RefProductProductionOrg() As String
			Get
				Return Me._RefProductProductionOrg
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.RefProductProductionOrg, value) <> true) Then				    
						Me._RefProductProductionOrg = value
						OnPropertyChanged("RefProductProductionOrg")
				    End If 
			End Set
		End Property

Private _CountryCode As String
		<DataMember(),DataField("COUNTRY_CODE")> _
		Public Property CountryCode() As String
			Get
				Return Me._CountryCode
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.CountryCode, value) <> true) Then				    
						Me._CountryCode = value
						OnPropertyChanged("CountryCode")
				    End If 
			End Set
		End Property

Private _VatType As String
		<DataMember(),DataField("VAT_TYPE")> _
		Public Property VatType() As String
			Get
				Return Me._VatType
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.VatType, value) <> true) Then				    
						Me._VatType = value
						OnPropertyChanged("VatType")
				    End If 
			End Set
		End Property

Private _CreditControlArea As String
		<DataMember(),DataField("CREDIT_CONTROL_AREA")> _
		Public Property CreditControlArea() As String
			Get
				Return Me._CreditControlArea
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.CreditControlArea, value) <> true) Then				    
						Me._CreditControlArea = value
						OnPropertyChanged("CreditControlArea")
				    End If 
			End Set
		End Property

Private _ProfitCenter As String
		<DataMember(),DataField("PROFIT_CENTER")> _
		Public Property ProfitCenter() As String
			Get
				Return Me._ProfitCenter
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.ProfitCenter, value) <> true) Then				    
						Me._ProfitCenter = value
						OnPropertyChanged("ProfitCenter")
				    End If 
			End Set
		End Property

Private _SoftwareId As String
		<DataMember(),DataField("SOFTWARE_ID")> _
		Public Property SoftwareId() As String
			Get
				Return Me._SoftwareId
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.SoftwareId, value) <> true) Then				    
						Me._SoftwareId = value
						OnPropertyChanged("SoftwareId")
				    End If 
			End Set
		End Property

Private _SubOperationCode As String
		<DataMember(),DataField("SUB_OPERATION_CODE")> _
		Public Property SubOperationCode() As String
			Get
				Return Me._SubOperationCode
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.SubOperationCode, value) <> true) Then				    
						Me._SubOperationCode = value
						OnPropertyChanged("SubOperationCode")
				    End If 
			End Set
		End Property

Private _Schema As String
		<DataMember(),DataField("SCHEMA")> _
		Public Property Schema() As String
			Get
				Return Me._Schema
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.Schema, value) <> true) Then				    
						Me._Schema = value
						OnPropertyChanged("Schema")
				    End If 
			End Set
		End Property

Private _OrgNameLoc As String
		<DataMember(),DataField("ORG_NAME_LOC")> _
		Public Property OrgNameLoc() As String
			Get
				Return Me._OrgNameLoc
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.OrgNameLoc, value) <> true) Then				    
						Me._OrgNameLoc = value
						OnPropertyChanged("OrgNameLoc")
				    End If 
			End Set
		End Property

Private _OrgNameEng As String
		<DataMember(),DataField("ORG_NAME_ENG")> _
		Public Property OrgNameEng() As String
			Get
				Return Me._OrgNameEng
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.OrgNameEng, value) <> true) Then				    
						Me._OrgNameEng = value
						OnPropertyChanged("OrgNameEng")
				    End If 
			End Set
		End Property

Private _CompanyCode As String
		<DataMember(),DataField("COMPANY_CODE")> _
		Public Property CompanyCode() As String
			Get
				Return Me._CompanyCode
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.CompanyCode, value) <> true) Then				    
						Me._CompanyCode = value
						OnPropertyChanged("CompanyCode")
				    End If 
			End Set
		End Property

Private _BusinessAreaCode As String
		<DataMember(),DataField("BUSINESS_AREA_CODE")> _
		Public Property BusinessAreaCode() As String
			Get
				Return Me._BusinessAreaCode
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.BusinessAreaCode, value) <> true) Then				    
						Me._BusinessAreaCode = value
						OnPropertyChanged("BusinessAreaCode")
				    End If 
			End Set
		End Property

Private _BusinessPlaceCode As String
		<DataMember(),DataField("BUSINESS_PLACE_CODE")> _
		Public Property BusinessPlaceCode() As String
			Get
				Return Me._BusinessPlaceCode
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.BusinessPlaceCode, value) <> true) Then				    
						Me._BusinessPlaceCode = value
						OnPropertyChanged("BusinessPlaceCode")
				    End If 
			End Set
		End Property

Private _PlantCode As String
		<DataMember(),DataField("PLANT_CODE")> _
		Public Property PlantCode() As String
			Get
				Return Me._PlantCode
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.PlantCode, value) <> true) Then				    
						Me._PlantCode = value
						OnPropertyChanged("PlantCode")
				    End If 
			End Set
		End Property

Private _ActivityCode As String
		<DataMember(),DataField("ACTIVITY_CODE")> _
		Public Property ActivityCode() As String
			Get
				Return Me._ActivityCode
			End Get
			Set(ByVal value As String)
					If (Object.ReferenceEquals(Me.ActivityCode, value) <> true) Then				    
						Me._ActivityCode = value
						OnPropertyChanged("ActivityCode")
				    End If 
			End Set
		End Property


	
	 
        Public Function Equals1(ByVal other As MasOrg) As Boolean Implements System.IEquatable(Of MasOrg).Equals
           
           if Me.OrgCode <> other.OrgCode Then
                Return False
            End If


             Return True
        End Function
        
         Public Overrides Function GetHashCode() As Integer
            Return GetHashValue(OrgCode)
        End Function
	
End Class

End Namespace