
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
    /// 64408499-b82a-4e64-805e-e821aa0c64c9
    /// </summary>
    public  partial class SKRSIlacKullanimPeriyoduBirimi : BaseSKRSCommonDef
    {
        public partial class GetSKRSIlacKullanimPeriyoduBirimi_Class : TTReportNqlObject 
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