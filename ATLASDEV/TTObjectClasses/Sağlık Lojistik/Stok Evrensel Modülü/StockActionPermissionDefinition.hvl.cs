
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

    public partial class StockActionPermissionDefinition : TTSecurityAuthority
    {
        public StockActionPermissionDefinition(TTPermissionDef permissionDef) : base(permissionDef)
        {
        }

        public bool? CheckStore
        {
            get
            {
                object paramVal;
                if (CurrentPermission.ParameterValues.TryGetValue("CheckStore", out paramVal))
                    return (bool?)paramVal;
                return null;
            }
        }

        public bool? CheckHospital
        {
            get
            {
                object paramVal;
                if (CurrentPermission.ParameterValues.TryGetValue("CheckHospital", out paramVal))
                    return (bool?)paramVal;
                return null;
            }
        }

        public bool? DontCheckStore
        {
            get
            {
                object paramVal;
                if (CurrentPermission.ParameterValues.TryGetValue("DontCheckStore", out paramVal))
                    return (bool?)paramVal;
                return null;
            }
        }

        public bool? CheckDestinationStore
        {
            get
            {
                object paramVal;
                if (CurrentPermission.ParameterValues.TryGetValue("CheckDestinationStore", out paramVal))
                    return (bool?)paramVal;
                return null;
            }
        }
    }
}