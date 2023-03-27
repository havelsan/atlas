
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

    public partial class CMRActionPermissionDefinition : TTSecurityAuthority
    {
#region Body
            protected override bool HasRight(TTUser user, object securableObjectInstance)
            {
                ResUser resUser = user.UserObject as ResUser;
                if (resUser == null)
                    return false;

                if (Hospital.HasValue && Hospital.Value)
                    return true;
                
                CMRAction cmr = securableObjectInstance as CMRAction ;
                if (cmr == null)
                    return false;
                
                
                if (MasterDivision.HasValue && MasterDivision.Value)
                {
                    if (cmr.ResDivision == null)
                        return false;

                    foreach (Resource inPatientResource in resUser.InPatientUserResources)
                    {
                        if (cmr.ResDivision.ObjectID.Equals(inPatientResource.ObjectID))
                            return true;
                    }
                    return false;
                }

                if (MasterResource.HasValue && MasterResource.Value)
                {
                    if (cmr.Section == null)
                        return false;

                    foreach (Resource outPatientResource in resUser.OutPatientUserResources)
                    {
                        if (cmr.Section.ObjectID.Equals(outPatientResource.ObjectID))
                            return true;
                    }
                    return false;
                }
                
                if (MasterWorkShop.HasValue && MasterWorkShop.Value)
                {
                    if (cmr.WorkShop == null)
                        return false;

                    foreach (Resource secMasterResource in resUser.SecMasterUserResources)
                    {
                        if (cmr.WorkShop.ObjectID.Equals(secMasterResource.ObjectID))
                            return true;
                    }
                    return false;
                }

                if (UserResource.HasValue && UserResource.Value)
                {
                    if (cmr.ResponsibleUser == null)
                        return false;

                    if (cmr.ResponsibleUser.ObjectID.Equals(resUser.ObjectID))
                        return true;

                    return false;
                }

                if (FromResource.HasValue && FromResource.Value)
                {
                    if (cmr.SenderSection == null)
                        return false;
                    foreach (Resource inPatientResource in resUser.InPatientUserResources)
                    {
                        if (cmr.SenderSection.ObjectID.Equals(inPatientResource.ObjectID))
                            return true;
                    }
                    if (cmr.SenderSection.ObjectID.Equals(resUser.SelectedOutPatientResource.ObjectID))
                        return true;
                    
                    if (cmr.SenderSection.ObjectID.Equals(resUser.SelectedSecMasterResource.ObjectID))
                        return true;

                    return false;
                }

                return false;
            }
            
#endregion Body
    }
}