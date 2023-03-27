
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

    public partial class DrugOrderPermissionDefinition : TTSecurityAuthority
    {
        #region Body
        protected override bool HasRight(TTUser user, object securableObjectInstance)
        {
            ResUser resUser = user.UserObject as ResUser;
            if (resUser == null)
                return false;

            if (Hospital.HasValue && Hospital.Value)
                return true;

            DrugOrderDetail drugOrderDetail = securableObjectInstance as DrugOrderDetail;
            if (drugOrderDetail == null)
                return false;

            if (MasterResource.HasValue && MasterResource.Value)
            {
                if (drugOrderDetail.MasterResource == null)
                    return false;
                if (resUser.InPatientUserResources != null)
                {
                    foreach (Resource inpatientResource in resUser.InPatientUserResources)
                    {
                        if (drugOrderDetail.MasterResource.ObjectID.Equals(inpatientResource.ObjectID))
                            return true;
                    }
                }
                if (resUser.SecMasterUserResources != null)
                {
                    foreach (Resource secMasterResource in resUser.SecMasterUserResources)
                    {
                        if (drugOrderDetail.SecondaryMasterResource != null)
                        {
                            if (drugOrderDetail.SecondaryMasterResource.ObjectID.Equals(secMasterResource.ObjectID))
                                return true;
                        }
                    }
                }
                return false;
            }
            return false;
        }

        #endregion Body
    }
}