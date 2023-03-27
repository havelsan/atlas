
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
        public ErrorReportActionPermissionDefinition(TTPermissionDef permissionDef) : base(permissionDef)
        {
        }

        public bool? CheckFromResource
        {
            get
            {
                object paramVal;
                if (CurrentPermission.ParameterValues.TryGetValue("CheckFromResource", out paramVal))
                    return (bool?)paramVal;
                return null;
            }
        }

        public bool? CheckFromUser
        {
            get
            {
                object paramVal;
                if (CurrentPermission.ParameterValues.TryGetValue("CheckFromUser", out paramVal))
                    return (bool?)paramVal;
                return null;
            }
        }

        public bool? CheckToResource
        {
            get
            {
                object paramVal;
                if (CurrentPermission.ParameterValues.TryGetValue("CheckToResource", out paramVal))
                    return (bool?)paramVal;
                return null;
            }
        }

        public bool? CheckOwnerResource
        {
            get
            {
                object paramVal;
                if (CurrentPermission.ParameterValues.TryGetValue("CheckOwnerResource", out paramVal))
                    return (bool?)paramVal;
                return null;
            }
        }

        public bool? CheckOwnerUser
        {
            get
            {
                object paramVal;
                if (CurrentPermission.ParameterValues.TryGetValue("CheckOwnerUser", out paramVal))
                    return (bool?)paramVal;
                return null;
            }
        }

        public bool? DontCheckResource
        {
            get
            {
                object paramVal;
                if (CurrentPermission.ParameterValues.TryGetValue("DontCheckResource", out paramVal))
                    return (bool?)paramVal;
                return null;
            }
        }
    }
}