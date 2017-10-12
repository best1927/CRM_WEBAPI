


Imports SsCommon
Imports System.ComponentModel
Imports System.Runtime.Serialization

Namespace Model
    <DataContract()>
    Public Class MCrmOrganization
        Inherits DTO.CrmOrganization


        <DataMember> Public Property OrgAnniversarylst As List(Of DTO.CrmOrganizationAnniversary)
        <DataMember> Public Property OrgLinklst As List(Of DTO.CrmActivitiesLink)
        <DataMember> Public Property OrgSociallst As List(Of DTO.CrmOrganizationSocial)



    End Class
End Namespace



