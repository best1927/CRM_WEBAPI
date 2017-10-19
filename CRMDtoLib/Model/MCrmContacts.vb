

Imports SsCommon
Imports System.ComponentModel
Imports System.Runtime.Serialization

Namespace Model
    <DataContract()>
    Public Class MCrmContacts
        Inherits DTO.CrmContacts


        <DataMember> Public Property OrganizeName As String

        <DataMember> Public Property ConAnniversarylst As List(Of DTO.CrmContactsAnniversary)
        <DataMember> Public Property ConLinklst As List(Of Model.MCrmActivitiesLink)
        <DataMember> Public Property ConRelatelst As List(Of DTO.CrmContactsRelative)

    End Class
End Namespace


