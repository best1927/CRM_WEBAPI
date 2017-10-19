

Imports SsCommon
Imports System.ComponentModel
Imports System.Runtime.Serialization

Namespace Model
    <DataContract()>
    Public Class MCrmActivities
        Inherits DTO.CrmActivities

        <DataMember> Public Property LinkList As List(Of Model.MCrmActivitiesLink)
        <DataMember> Public Property TagList As List(Of DTO.CrmActivitiesTag)
    End Class
End Namespace


