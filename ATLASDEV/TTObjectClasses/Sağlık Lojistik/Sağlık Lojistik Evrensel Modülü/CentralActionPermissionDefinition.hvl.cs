
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

    public partial class CentralActionPermissionDefinition : TTSecurityAuthority
    {
        public CentralActionPermissionDefinition(TTPermissionDef permissionDef) : base(permissionDef)
        {
        }

        public bool? CheckFromSite
        {
            get
            {
                object paramVal;
                if (CurrentPermission.ParameterValues.TryGetValue("CheckFromSite", out paramVal))
                    return (bool?)paramVal;
                return null;
            }
        }

        public bool? CheckToSite
        {
            get
            {
                object paramVal;
                if (CurrentPermission.ParameterValues.TryGetValue("CheckToSite", out paramVal))
                    return (bool?)paramVal;
                return null;
            }
        }

        public bool? DontCheckSite
        {
            get
            {
                object paramVal;
                if (CurrentPermission.ParameterValues.TryGetValue("DontCheckSite", out paramVal))
                    return (bool?)paramVal;
                return null;
            }
        }
    }
}