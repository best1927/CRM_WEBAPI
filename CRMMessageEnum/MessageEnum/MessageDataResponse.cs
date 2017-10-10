
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
        #region "0051 - 0100 Data Response"
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





        #endregion
    }
}
//=======================================================
//Service provided by Telerik (www.telerik.com)
//Conversion powered by NRefactory.
//Twitter: @telerik
//Facebook: facebook.com/telerik
//=======================================================
