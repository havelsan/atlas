
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
    /// <summary>
    /// e8fba324-ae10-49a9-9178-e2c5ad0b57e9
    /// </summary>
    public  partial class SKRSCikisSekli : BaseSKRSCommonDef
    {
        public partial class GetSKRSCikisSekli_Class : TTReportNqlObject 
        {
        }

#region Methods
        public override bool CanMatchByEnumValue()
        {
            return true;
        }
        
#endregion Methods

    }
}