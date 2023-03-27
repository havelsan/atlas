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
    /// Ölçü Birimi Tanımları
    /// </summary>
    public  partial class DistributionTypeDefinition : TerminologyManagerDef
    {
        public partial class GetDistributionTypeDefinition_Class : TTReportNqlObject 
        {
        }

        public partial class OLAP_DistributionType_Class : TTReportNqlObject 
        {
        }

#region Methods
        public override string ToString()
        {
            return DistributionType;
        }
        
        public override SendDataTypesEnum?  GetMySendDataTypesEnum()
        {
            return SendDataTypesEnum.DistributionTypeInfo;
        }
        
#endregion Methods

    }
}