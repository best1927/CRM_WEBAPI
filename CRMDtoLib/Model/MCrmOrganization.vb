


Imports SsCommon
Imports System.ComponentModel
Imports System.Runtime.Serialization

Namespace Model
    <DataContract()>
    Public Class MCrmOrganization
        Inherits DTO.CrmOrganization

        <DataMember> Public Property OrgAnniversarylst As List(Of DTO.CrmOrganizationAnniversary)
        <DataMember> Public Property OrgLinklst As List(Of DTO.CrmOrganizationLink)
        <DataMember> Public Property OrgSociallst As List(Of DTO.CrmOrganizationSocial)
        <DataMember> Public Property OrgVisiblelst As List(Of DTO.CrmOrganizationVisibility)

    End Class
End Namespace



