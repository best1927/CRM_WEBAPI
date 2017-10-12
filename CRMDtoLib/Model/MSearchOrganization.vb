Imports SsCommon
Imports System.ComponentModel
Imports System.Runtime.Serialization

Namespace Model
    <DataContract()>
    Public Class MSearchOrganization
        Inherits SsCommon.BaseDto

        <DataMember> Public Property currRec As Integer
        <DataMember> Public Property maxRec As Integer
        <DataMember> Public Property totalRec As Integer
        <DataMember> Public Property MOrganizationList As List(Of MOrganization)
        <DataMember> Public Property TagList As List(Of DTO.CrmActivitiesTag)

    End Class

    Public Class MOrganization
        Inherits SsCommon.BaseDto
        <DataMember> Public Property OrganizeId As Integer
        <DataMember> Public Property OrganizeName As String
        <DataMember> Public Property FullAddress As String
        <DataMember> Public Property PhoneHome As String
        <DataMember> Public Property PhoneMobile As String
        <DataMember> Public Property VisibileCd As String
        <DataMember> Public Property VisibileType As String


        <DataMember> Public Property Phone As String
        <DataMember> Public Property OrganizeUrl As String

        <DataMember> Public Property AId As Integer


        <DataMember> Public Property PhoneOffice As String
        <DataMember> Public Property PhoneFax As String

        <DataMember> Public Property tagstr As String

    End Class

End Namespace

