
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

    public partial class EpisodeActionPermissionDefinition : TTSecurityAuthority
    {
        public EpisodeActionPermissionDefinition(TTPermissionDef permissionDef) : base(permissionDef)
        {
        }

        public bool? AllocatedResource
        {
            get
            {
                object paramVal;
                if (CurrentPermission.ParameterValues.TryGetValue("AllocatedResource", out paramVal))
                    return (bool?)paramVal;
                return null;
            }
        }

        public bool? SecondaryMasterResource
        {
            get
            {
                object paramVal;
                if (CurrentPermission.ParameterValues.TryGetValue("SecondaryMasterResource", out paramVal))
                    return (bool?)paramVal;
                return null;
            }
        }

        public bool? EpisodeAuthorizedResource
        {
            get
            {
                object paramVal;
                if (CurrentPermission.ParameterValues.TryGetValue("EpisodeAuthorizedResource", out paramVal))
                    return (bool?)paramVal;
                return null;
            }
        }

        public bool? MasterResource
        {
            get
            {
                object paramVal;
                if (CurrentPermission.ParameterValues.TryGetValue("MasterResource", out paramVal))
                    return (bool?)paramVal;
                return null;
            }
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

        public bool? FromResource
        {
            get
            {
                object paramVal;
                if (CurrentPermission.ParameterValues.TryGetValue("FromResource", out paramVal))
                    return (bool?)paramVal;
                return null;
            }
        }

        public bool? AuthorizedUser
        {
            get
            {
                object paramVal;
                if (CurrentPermission.ParameterValues.TryGetValue("AuthorizedUser", out paramVal))
                    return (bool?)paramVal;
                return null;
            }
        }
    }
}