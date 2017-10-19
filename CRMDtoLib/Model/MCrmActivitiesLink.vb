

Imports SsCommon
Imports System.ComponentModel
Imports System.Runtime.Serialization

Namespace Model
    Public Class MCrmActivitiesLink
        Inherits DTO.CrmActivitiesLink
        <DataMember> Public Property RelateName As String
        <DataMember> Public Property LinkName As String
        <DataMember> Public Property TbName As String

        <DataMember> Public Property IconPic As String
    End Class
End Namespace




