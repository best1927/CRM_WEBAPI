
Imports SsCommon
Imports System.ComponentModel
Imports System.Runtime.Serialization

Namespace Model
    <DataContract()>
    Public Class MGeneralType
        Inherits SsCommon.BaseDto
        <DataMember> Public Property GdType As String
        <DataMember> Public Property GdCodeLst As New List(Of CRMDtoLib.DTO.GeneralDesc)
    End Class
End Namespace

