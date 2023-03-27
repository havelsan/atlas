
using System;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

using TTUtils;
using TTObjectClasses;
using TTDataDictionary;
using TTCoreDefinitions;
using TTConnectionManager;
using TTInstanceManagement;
using TTDefinitionManagement;
using TTStorageManager.Security;



using TTStorageManager;
using System.Runtime.Versioning;


namespace TTObjectClasses
{
    public  partial class PhysiotherapyRequestTemplateDetail : ProcedureRequestTemplateDetail
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "FTRAPPLICATIONAREADEF":
                    {
                        FTRVucutBolgesi value = (FTRVucutBolgesi)newValue;
#region FTRAPPLICATIONAREADEF_SetParentScript
                        if (value == null)
                            value.ftrVucutBolgesiAdi = "";
                        else
                            ApplicationArea = value.ftrVucutBolgesiAdi;
#endregion FTRAPPLICATIONAREADEF_SetParentScript
                    }
                    break;

                default:
                    base.RunSetMemberValueScript(memberName, newValue);
                    break;

            }
        }

    }
}