
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

    public partial class ErrorReportActionPermissionDefinition : TTSecurityAuthority
    {
#region Body
            protected override bool HasRight(TTUser user, object securableObjectInstance)
            {
                if (DontCheckResource.HasValue && DontCheckResource.Value)
                    return true;

                ErrorReportAction era = securableObjectInstance as ErrorReportAction;
                if (era == null)
                    return false;

                ResUser resUser = user.UserObject as ResUser;
                if (resUser == null)
                    return false;
                
                if (CheckFromResource.HasValue && CheckFromResource.Value)
                {
                    if (era.FromResource == null)
                        return false;

                    if (resUser.SelectedInPatientResource != null && era.FromResource.ObjectID.Equals(resUser.SelectedInPatientResource.ObjectID))
                        return true;

                    if (resUser.SelectedOutPatientResource != null && era.FromResource.ObjectID.Equals(resUser.SelectedOutPatientResource.ObjectID))
                        return true;

                    if (resUser.SelectedSecMasterResource != null && era.FromResource.ObjectID.Equals(resUser.SelectedSecMasterResource.ObjectID))
                        return true;

                    foreach (UserResource ur in resUser.UserResources)
                    {
                        if(era.FromResource.ObjectID.Equals(ur.Resource.ObjectID))
                            return true;
                    }
                }

                if (CheckFromUser.HasValue && CheckFromUser.Value)
                {
                    if (era.FromUser == null)
                        return false;

                    if (era.FromUser.ObjectID.Equals(resUser.ObjectID))
                        return true;
                }

                if (CheckToResource.HasValue && CheckToResource.Value)
                {
                    if (era.ToResource == null)
                        return false;

                    if (resUser.SelectedInPatientResource != null && era.ToResource.ObjectID.Equals(resUser.SelectedInPatientResource.ObjectID))
                        return true;

                    if (resUser.SelectedOutPatientResource != null && era.ToResource.ObjectID.Equals(resUser.SelectedOutPatientResource.ObjectID))
                        return true;

                    if (resUser.SelectedSecMasterResource != null && era.ToResource.ObjectID.Equals(resUser.SelectedSecMasterResource.ObjectID))
                        return true;

                    foreach (UserResource ur in resUser.UserResources)
                    {
                        if(era.ToResource.ObjectID.Equals(ur.Resource.ObjectID))
                            return true;
                    }
                }

                if (CheckOwnerResource.HasValue && CheckOwnerResource.Value)
                {
                    if (era.OwnerResource == null)
                        return false;

                    if (resUser.SelectedInPatientResource != null && era.OwnerResource.ObjectID.Equals(resUser.SelectedInPatientResource.ObjectID))
                        return true;

                    if (resUser.SelectedOutPatientResource != null && era.OwnerResource.ObjectID.Equals(resUser.SelectedOutPatientResource.ObjectID))
                        return true;

                    if (resUser.SelectedSecMasterResource != null && era.OwnerResource.ObjectID.Equals(resUser.SelectedSecMasterResource.ObjectID))
                        return true;
                    
                    foreach (UserResource ur in resUser.UserResources)
                    {
                        if(era.OwnerResource.ObjectID.Equals(ur.Resource.ObjectID))
                            return true;
                    }                    
                }

                if (CheckOwnerUser.HasValue && CheckOwnerUser.Value)
                {
                    if (era.OwnerUser == null)
                        return false;

                    if (era.OwnerUser.ObjectID.Equals(resUser.ObjectID))
                        return true;
                }
                
                return false;
            }
            
#endregion Body
    }
}