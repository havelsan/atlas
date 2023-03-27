
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

    public partial class AppointmentPermissionDefinition : TTSecurityAuthority
    {
#region Body
            protected override bool HasRight(TTUser user, object securableObjectInstance)
            {                
                if (Hospital.HasValue && Hospital.Value)
                    return true;

                if(MasterResource.HasValue == false || MasterResource.Value == false)
                    return false;
                
                Guid? masterResID;
                
                if (securableObjectInstance is Resource)
                    masterResID = ((Resource)securableObjectInstance).ObjectID;
                else if (securableObjectInstance is Appointment)
                    masterResID = (Guid?)(((Appointment)securableObjectInstance)["MASTERRESOURCE"]);
                else
                    masterResID = null;
                
                if (masterResID.HasValue == false)
                    return true;
                
                ResUser currentUser = user.UserObject as ResUser;                
                foreach (UserResource userResource in currentUser.UserResources)
                {
                    if (userResource.Resource.ObjectID == masterResID.Value)
                        return true;
                }
                
                return false;
            }
            
#endregion Body
    }
}