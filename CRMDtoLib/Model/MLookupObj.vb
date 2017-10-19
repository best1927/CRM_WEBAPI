Imports SsCommon
Imports System.ComponentModel
Imports System.Runtime.Serialization

Namespace Model
    <DataContract()>
    Public Class MLookupObj
        Inherits SsCommon.BaseDto
        <DataMember> Public Property Code As String
        <DataMember> Public Property Name As String
        <DataMember> Public Property Desc1 As String
        <DataMember> Public Property Desc2 As String
        <DataMember> Public Property Desc3 As String
        <DataMember> Public Property Desc4 As String

    End Class
End Namespace

