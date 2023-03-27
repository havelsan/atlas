
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
    /// c2fbe9bb-f6b3-4cb5-8670-47890ed7ed4b
    /// </summary>
    public  partial class SKRSReceteTuru : BaseSKRSCommonDef
    {
        public partial class GetSKRSReceteTuru_Class : TTReportNqlObject 
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