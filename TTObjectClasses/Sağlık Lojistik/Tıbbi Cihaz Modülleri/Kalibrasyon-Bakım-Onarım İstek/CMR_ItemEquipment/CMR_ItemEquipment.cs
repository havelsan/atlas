
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
    public  partial class CMR_ItemEquipment : ItemEquipment
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "ISCHANGED":
                    {
                        bool? value = (bool?)Convert.ToBoolean(newValue);
#region ISCHANGED_SetScript
                        if(value == true)
            {
                IsDamaged = false;
                IsMissing = false;
                IsNormal = false;
            }
#endregion ISCHANGED_SetScript
                    }
                    break;
                case "ISNORMAL":
                    {
                        bool? value = (bool?)Convert.ToBoolean(newValue);
#region ISNORMAL_SetScript
                        if(value == true)
            {
                IsChanged = false;
                IsMissing = false;
                IsMissing = false;
            }
#endregion ISNORMAL_SetScript
                    }
                    break;
                case "ISMISSING":
                    {
                        bool? value = (bool?)Convert.ToBoolean(newValue);
#region ISMISSING_SetScript
                        if(value == true)
            {
                IsChanged = false;
                IsDamaged = false;
                IsNormal = false;
            }
#endregion ISMISSING_SetScript
                    }
                    break;
                case "ISDAMAGED":
                    {
                        bool? value = (bool?)Convert.ToBoolean(newValue);
#region ISDAMAGED_SetScript
                        if(value == true)
            {
                IsChanged = false;
                IsMissing = false;
                IsNormal = false;
            }
#endregion ISDAMAGED_SetScript
                    }
                    break;

                default:
                    base.RunSetMemberValueScript(memberName, newValue);
                    break;

            }
        }

    }
}