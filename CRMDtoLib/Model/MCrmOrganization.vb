


Imports SsCommon
Imports System.ComponentModel
Imports System.Runtime.Serialization

Namespace Model
    <DataContract()>
    Public Class MCrmOrganization
        Inherits DTO.CrmOrganization


        <DataMember> Public Property OrgName As String
        <DataMember> Public Property OrgTypeName As String
        <DataMember> Public Property Phone As String

        <DataMember> Public Property CreateDateStr As String

        <DataMember> Public Property FullAddress As String
        <DataMember> Public Property OrgAnniversarylst As List(Of DTO.CrmOrganizationAnniversary)
        <DataMember> Public Property OrgLinklst As List(Of Model.MCrmActivitiesLink)



    End Class
End Namespace



