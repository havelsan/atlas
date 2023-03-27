
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
    /// Ölüm Sebebi Tanımları
    /// </summary>
    public  partial class ReasonForDeathDefinition : TerminologyManagerDef
    {
        public partial class OLAP_ReasonForDeath_Class : TTReportNqlObject 
        {
        }

        public partial class GetReasonForDeathDefinition_Class : TTReportNqlObject 
        {
        }

#region Methods
        public override string ToString()
        {
            return ReasonForDeath;
        }
        public override SendDataTypesEnum?  GetMySendDataTypesEnum()
        {
            return SendDataTypesEnum.ReasonForDeathDefinitionInfo;
        }
        
#endregion Methods

    }
}