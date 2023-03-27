
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

    public partial class AdmissionAppointmentPermisionDefinition : TTSecurityAuthority
    {
#region Body
            protected override bool HasRight(TTUser user, object securableObjectInstance)
        {
            AdmissionAppointment admissionAppointment = (AdmissionAppointment)securableObjectInstance;
            ResUser currentUser = user.UserObject as ResUser;

            if (Hospital.HasValue && Hospital.Value)
                return true;

            if (MasterResource.HasValue && MasterResource.Value)
            {
                if (admissionAppointment.MasterResource == null)
                    return true;

                foreach (UserResource userResource in currentUser.UserResources)
                    if (userResource.Resource.ObjectID == admissionAppointment.MasterResource.ObjectID)
                        return true;
            }
            return false;
        }
            
#endregion Body
    }
}