
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
    /// Kurum Grubu
    /// </summary>
    public  partial class PayerGroupDefinition : TerminologyManagerDef
    {
        public partial class GetPayerGroupDefinitions_Class : TTReportNqlObject 
        {
        }

#region Methods
        public override SendDataTypesEnum? GetMySendDataTypesEnum()
        {
            return SendDataTypesEnum.PayerGroupInfo;
        }
        
        public override bool GetMyChildTerminologyManagerDefs()
        {
            return false;
        }
        
#endregion Methods

    }
}