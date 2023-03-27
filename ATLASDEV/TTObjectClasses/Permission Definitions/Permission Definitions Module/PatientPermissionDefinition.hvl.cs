
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

    public partial class PatientPermissionDefinition : TTSecurityAuthority
    {
        public PatientPermissionDefinition(TTPermissionDef permissionDef) : base(permissionDef)
        {
        }

        public bool? Hospital
        {
            get
            {
                object paramVal;
                if (CurrentPermission.ParameterValues.TryGetValue("Hospital", out paramVal))
                    return (bool?)paramVal;
                return null;
            }
        }

        public bool? NewPatient
        {
            get
            {
                object paramVal;
                if (CurrentPermission.ParameterValues.TryGetValue("NewPatient", out paramVal))
                    return (bool?)paramVal;
                return null;
            }
        }

        public bool? OldPatient
        {
            get
            {
                object paramVal;
                if (CurrentPermission.ParameterValues.TryGetValue("OldPatient", out paramVal))
                    return (bool?)paramVal;
                return null;
            }
        }

        public bool? IfPatientEditable
        {
            get
            {
                object paramVal;
                if (CurrentPermission.ParameterValues.TryGetValue("IfPatientEditable", out paramVal))
                    return (bool?)paramVal;
                return null;
            }
        }
    }
}