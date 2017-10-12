
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using GuCommon.Message;
using GuCommon.Enum;
namespace CRMMessageEnum.MessageEnum
{
    [MessageAtt("SSCRM")]
    public enum MessageDataResponse
    {
        #region "0051 - 0100 Data Response && 0101 - 0150 Event Message for Activity Topic"
        //TO Define Msg for Share all App in your Module

        /// <summary>
        /// It cannot generate data.
        /// </summary>
        [MsgTypeAtt(MsgTypeEnum.Fail), MessageLangAtt("SSCRM0051"), MessageTemplateAtt("It cannot generate data.")]
        CannotGen,
        
        /// <summary>
        /// Data has been generate.
        /// </summary>
        [MsgTypeAtt(MsgTypeEnum.Success), MessageLangAtt("SSCRM0052"), MessageTemplateAtt("Data has been generate.")]
        GenDataSuccess,

        /// <summary>
        /// Save Completed.
        /// </summary>
        [MsgTypeAtt(MsgTypeEnum.Success), MessageLangAtt("SSCRM0053"), MessageTemplateAtt("Save Completed.")]
        SaveCompleted,

        /// <summary>
        /// Data Deleted.
        /// </summary>
        [MsgTypeAtt(MsgTypeEnum.Success), MessageLangAtt("SSCRM0054"), MessageTemplateAtt("Data Deleted.")]
        DataDeleted,


        /// <summary>
        /// Data doesn't exisits.
        /// </summary>
        [MsgTypeAtt(MsgTypeEnum.Success), MessageLangAtt("SSCRM0055"), MessageTemplateAtt("Data doesn't exisits.")]
        DataDoesNotExisits,




        /// <summary>
        /// Create Organization.
        /// </summary>
        [MsgTypeAtt(MsgTypeEnum.Success), MessageLangAtt("SSCRM0101"), MessageTemplateAtt("Create Organization")]
        CreateOrganization,

        /// <summary>
        /// Create Contact.
        /// </summary>
        [MsgTypeAtt(MsgTypeEnum.Success), MessageLangAtt("SSCRM0102"), MessageTemplateAtt("Create Contact")]
        CreateContact,

        /// <summary>
        /// Create Task.
        /// </summary>
        [MsgTypeAtt(MsgTypeEnum.Success), MessageLangAtt("SSCRM0103"), MessageTemplateAtt("Create Task")]
        CreateTask,




        #endregion
    }
}
//=======================================================
//Service provided by Telerik (www.telerik.com)
//Conversion powered by NRefactory.
//Twitter: @telerik
//Facebook: facebook.com/telerik
//=======================================================
