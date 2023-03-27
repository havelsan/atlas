
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


namespace TTStorageManager.Security
{

    public partial class BasePurhaseActionPermission : TTSecurityAuthority
    {
#region Body
            protected override bool HasRight(TTUser user, object securableObjectInstance)
        {
            if (Hospital.HasValue && Hospital.Value)
                return true;

            BasePurchaseAction bpa = securableObjectInstance as BasePurchaseAction;
            if (MasterResource.HasValue && MasterResource.Value)
            {
                if (bpa == null)
                    return false;
                if (bpa.MasterResource == null)
                    return false;

                ResUser resUser = user.UserObject as ResUser;
                if (resUser == null)
                    return false;

                if (bpa.MasterResource.ObjectID.Equals(resUser.SelectedInPatientResource.ObjectID))
                    return true;

                if (bpa.MasterResource.ObjectID.Equals(resUser.SelectedOutPatientResource.ObjectID))
                    return true;

                if (bpa.MasterResource.ObjectID.Equals(resUser.SelectedSecMasterResource.ObjectID))
                    return true;

                return false;
            }
            return false;
        }
            
#endregion Body
    }
}