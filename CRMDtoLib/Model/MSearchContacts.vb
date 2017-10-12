Imports SsCommon
Imports System.ComponentModel
Imports System.Runtime.Serialization

Namespace Model
    <DataContract()>
    Public Class MSearchContacts
        Inherits SsCommon.BaseDto
        <DataMember> Public Property currRec As Integer
        <DataMember> Public Property maxRec As Integer
        <DataMember> Public Property totalRec As Integer
        <DataMember> Public Property MContactsList As List(Of MContacts)
        <DataMember> Public Property TagList As List(Of DTO.CrmActivitiesTag)

    End Class


    Public Class MContacts
        Inherits SsCommon.BaseDto
        <DataMember> Public Property ContactId As Integer
        <DataMember> Public Property ContactName As String
        <DataMember> Public Property Email As String
        <DataMember> Public Property OrganizeId As Integer
        <DataMember> Public Property OrganizeName As String
        <DataMember> Public Property PhotoUrl As String
        <DataMember> Public Property VisibileCd As String
        <DataMember> Public Property VisibileType As String
        <DataMember> Public Property AId As Integer
        <DataMember> Public Property tagstr As String

    End Class
End Namespace

