using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRMDtoLib.DTO;
using CRMDtoLib.Model;
using SsCommon;
using GuCommon.Model;
using GuCommon.Model.Ext;

namespace CRM_Lib
{
    interface ISpecialist_Controller
    {
        GuResult<String> TestMessage(String Name);

        GuResult<List<CrmSpecialist>> GetLstOfSpeciallist(string lang, string local, string txtFilter);
    }
}
