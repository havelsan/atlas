
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

    public partial class MedulaPermissionDefinition : TTSecurityAuthority
    {
#region Body
            protected override bool HasRight(TTUser user, object securableObjectInstance)
        {
            if (DontCheckHealthFacility.HasValue && DontCheckHealthFacility.Value)
                return true;


            if (CheckHealthFacility.HasValue && CheckHealthFacility.Value)
            {
#if MEDULA
                BaseMedulaWLAction medulaWLAction = (BaseMedulaWLAction)securableObjectInstance;
                if (((MedulaUserDefinition)TTUser.CurrentUser.UserObject).SaglikTesisi.tesisKodu.Equals(medulaWLAction.HealthFacilityID))
                    return true;
#else
                    return true;
#endif
            }
            return false;
        }
            
#endregion Body
    }
}