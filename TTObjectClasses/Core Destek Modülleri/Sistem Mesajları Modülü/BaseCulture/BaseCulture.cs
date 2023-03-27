
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
    public  abstract  partial class BaseCulture : TerminologyManagerDef
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "LCID":
                    {
                        int? value = (int?)newValue;
#region LCID_SetScript
                        //this.LCID.Value = this.ObjectDef.Attributes.KeysName("LanguageCodeID");
#endregion LCID_SetScript
                    }
                    break;
                case "MESSAGE":
                    {
                        string value = (string)newValue;
#region MESSAGE_SetScript
                        foreach (TTAttribute  att in  ObjectDef.Attributes.Values)
            {
                foreach (TTAttributeParameter par in att.Parameters.Values  )
                {
                    if (par.ParameterDef.Name == "LanguageCodeID")
                    {
                        LCID = Convert.ToInt32(par.Value.ToString()) ;
                    }
                }
            }
#endregion MESSAGE_SetScript
                    }
                    break;

                default:
                    base.RunSetMemberValueScript(memberName, newValue);
                    break;

            }
        }

    }
}