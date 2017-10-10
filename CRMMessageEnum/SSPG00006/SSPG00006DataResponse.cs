
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using GuCommon.Message;
using GuCommon.Enum;
namespace SSPG00006MessageEnum
{
[MessageAtt("SSPG")]
public enum SSPG00006DataResponse
{
    #region "SSPG00006000 - SSPG0006099 Data Response"
    //Example
    ///// <summary>
    ///// Record inserted
    ///// </summary>
    ///// <remarks></remarks>
    //[MsgTypeAtt(MsgTypeEnum.Success), MessageLangAtt("SSPG00006000"), MessageTemplateAtt("Test1")]
    //Test1,

    /// <summary>
    /// This period has been generate.
    /// </summary>
    /// <remarks></remarks>
    [MsgTypeAtt(MsgTypeEnum.Fail), MessageLangAtt("SSPG00006000"), MessageTemplateAtt("This period has been generate.")]
    PeriodHasGen

    #endregion
}
}
//=======================================================
//Service provided by Telerik (www.telerik.com)
//Conversion powered by NRefactory.
//Twitter: @telerik
//Facebook: facebook.com/telerik
//=======================================================
