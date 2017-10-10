Imports SsCommon
Imports System.ComponentModel
Imports System.Runtime.Serialization

Namespace Model
    <DataContract()>
    Public Class MSearchContacts
        Inherits SsCommon.BaseDto
        <DataMember> Public Property ContactId As Integer
        <DataMember> Public Property ContactName As String
        <DataMember> Public Property Email As String
        <DataMember> Public Property OrganizeId As Integer
        <DataMember> Public Property OrganizeName As String
        <DataMember> Public Property PhotoUrl As String
        <DataMember> Public Property tagstr As String

    End Class
End Namespace

