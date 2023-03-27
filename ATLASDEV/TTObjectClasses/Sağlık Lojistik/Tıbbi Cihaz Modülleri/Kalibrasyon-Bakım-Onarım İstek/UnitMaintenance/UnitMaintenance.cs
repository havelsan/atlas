
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
    /// <summary>
    /// Birlik Seviyesi Bakım Parametreleri
    /// </summary>
    public  partial class UnitMaintenance : TTObject
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "CHECKED":
                    {
                        bool? value = (bool?)Convert.ToBoolean(newValue);
#region CHECKED_SetScript
                        if (value  == true)
            {
                Description = TTUtils.CultureService.GetText("M26334", "Kontrol Edildi.");
            }
            else if( value == false)
            {
                Description = null;
            }
#endregion CHECKED_SetScript
                    }
                    break;

            }
        }

    }
}