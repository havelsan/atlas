﻿
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
    /// 784d0f4f-0603-4425-937f-1a3941fc3a1f
    /// </summary>
    public  partial class SKRSCinsiyet : BaseSKRSCommonDef
    {
        public partial class GetSKRSCinsiyet_Class : TTReportNqlObject 
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