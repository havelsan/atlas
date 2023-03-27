
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
    /// Kullanıcı seviyesi bakım parametresi
    /// </summary>
    public  partial class UserMaintenance : TTObject
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

        protected override void PreInsert()
        {
#region PreInsert
            base.PreInsert();

#endregion PreInsert
        }

        protected override void PostUpdate()
        {
#region PostUpdate
            
            base.PostUpdate();
            

#endregion PostUpdate
        }

    }
}