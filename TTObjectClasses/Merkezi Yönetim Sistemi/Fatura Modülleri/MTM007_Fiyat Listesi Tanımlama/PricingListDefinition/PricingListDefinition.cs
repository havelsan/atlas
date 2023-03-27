
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
    /// Fiyat Listesi
    /// </summary>
    public  partial class PricingListDefinition : TerminologyManagerDef
    {
        public partial class GetPricingListDefinitions_Class : TTReportNqlObject 
        {
        }

        public partial class OLAP_GetPricingListDef_Class : TTReportNqlObject 
        {
        }

#region Methods
        public override SendDataTypesEnum?  GetMySendDataTypesEnum()
        {
            return SendDataTypesEnum.PricingListInfo;
        }
        
        public override bool GetMyChildTerminologyManagerDefs()
        {
            return false;
        }
        
#endregion Methods

    }
}