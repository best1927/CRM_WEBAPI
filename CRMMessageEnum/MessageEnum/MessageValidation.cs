
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
    public enum MessageValidation
    {

        #region "0151 - 0200 Validation"
        //TO Define Msg for Share all App in your Module

        /// <summary>
        /// Data is exists
        /// </summary>
        [MsgTypeAtt(MsgTypeEnum.Info), MessageLangAtt("SSCRM0151"), MessageTemplateAtt("Data is exists")]
        DataIsExists,
        #endregion

        /// <summary>
        ///This document can't delete !!!
        /// </summary>
        [MsgTypeAtt(MsgTypeEnum.Info), MessageLangAtt("SSCRM0152"), MessageTemplateAtt("This document can't delete !!!")]
        DocumentCannotDelete,

        /// <summary>
        ///Data can't delete !!!
        /// </summary>
        [MsgTypeAtt(MsgTypeEnum.Info), MessageLangAtt("SSCRM0153"), MessageTemplateAtt("Data can't delete !!!")]
        DataCannotDelete




    }
}
//=======================================================
//Service provided by Telerik (www.telerik.com)
//Conversion powered by NRefactory.
//Twitter: @telerik
//Facebook: facebook.com/telerik
//=======================================================
