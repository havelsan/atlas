
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
    public  abstract  partial class BaseOLAPRole : BaseOLAPDefinition
    {
        public partial class GetOLAPRoles_Class : TTReportNqlObject 
        {
        }

    /// <summary>
    /// Rol
    /// </summary>
        public string RoleName
        {
            get
            {
                try
                {
#region RoleName_GetScript                    
                    string returnValue = string.Empty;
                    if (RoleID.HasValue)
                    {
                        if (string.IsNullOrEmpty(_roleName))
                        {
                            TTRole currentRole = null;
                            if (TTObjectDefManager.Instance.AllRoles.TryGetValue(RoleID, out currentRole))
                                _roleName = currentRole.Name;
                        }
                        returnValue = _roleName;
                    }
                    return returnValue;
#endregion RoleName_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "RoleName") + " : " + ex.Message, ex);
                }
            }
        }

#region Methods
        private string _roleName;
        
#endregion Methods

    }
}