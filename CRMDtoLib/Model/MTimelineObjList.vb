
Imports SsCommon
Imports System.ComponentModel
Imports System.Runtime.Serialization

Namespace Model


    <DataContract()>
    Public Class MTimelineObjList
        Inherits BaseDto


        <DataMember> Public Property currRec As Integer
        <DataMember> Public Property maxRec As Integer
        <DataMember> Public Property totalRec As Integer
        <DataMember> Public Property TimeObjList As New List(Of MTimelineObj)

    End Class

    <DataContract()>
    Public Class MTimelineObj
        Inherits DTO.CrmActivities

        <DataMember> Public Property IconEvent As String
        <DataMember> Public Property EventName As String
        <DataMember> Public Property PriorityStr As String
        <DataMember> Public Property ActivitiesDtStr As String
    End Class


End Namespace


