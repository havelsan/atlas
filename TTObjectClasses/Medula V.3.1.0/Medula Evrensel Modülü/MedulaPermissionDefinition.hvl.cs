
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
        public MedulaPermissionDefinition(TTPermissionDef permissionDef) : base(permissionDef)
        {
        }

        public bool? CheckHealthFacility
        {
            get
            {
                object paramVal;
                if (CurrentPermission.ParameterValues.TryGetValue("CheckHealthFacility", out paramVal))
                    return (bool?)paramVal;
                return null;
            }
        }

        public bool? DontCheckHealthFacility
        {
            get
            {
                object paramVal;
                if (CurrentPermission.ParameterValues.TryGetValue("DontCheckHealthFacility", out paramVal))
                    return (bool?)paramVal;
                return null;
            }
        }
    }
}