
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
    public  partial class ProcedureTreeDefinition : TerminologyManagerDef
    {
        public partial class GetProcedureTreeDefinitions_Class : TTReportNqlObject 
        {
        }

        public partial class OLAP_ProcedureTreeDef_WithDate_Class : TTReportNqlObject 
        {
        }

        public partial class OLAP_GetRadProcedureTree_Class : TTReportNqlObject 
        {
        }

        public partial class OLAP_GetLabProcedureTree_Class : TTReportNqlObject 
        {
        }

        public partial class OLAP_GetSurgeryProcedureTree_Class : TTReportNqlObject 
        {
        }

        public partial class OLAP_GetSurgeryProcedureTree_WithDate_Class : TTReportNqlObject 
        {
        }

        public partial class OLAP_GetRadProcedureTree_WithDate_Class : TTReportNqlObject 
        {
        }

        public partial class OLAP_GetLabProcedureTree_WithDate_Class : TTReportNqlObject 
        {
        }

        public partial class OLAP_GetManipulationProcedureTree_WithDate_Class : TTReportNqlObject 
        {
        }

        public partial class OLAP_GetPatProcedureTree_WithDate_Class : TTReportNqlObject 
        {
        }

        public partial class OLAP_GetPatProcedureTree_Class : TTReportNqlObject 
        {
        }

        public partial class OLAP_GetGeneticProcedureTree_Class : TTReportNqlObject 
        {
        }

        public partial class OLAP_ProcedureTreeDef_Class : TTReportNqlObject 
        {
        }

        public partial class OLAP_GetGeneticProcedureTree_WithDate_Class : TTReportNqlObject 
        {
        }

#region Methods
        protected override void OnConstruct()
        {
            base.OnConstruct();
            ITTObject theObject = this as ITTObject;
            if (theObject.IsNew)
            {
                ID.GetNextValue();
            }
        }
        
        public RevenueSubAccountCodeDefinition GetRevenueSubAccountCode()
        {
            if (RevenueSubAccountCode != null)
                return RevenueSubAccountCode;
            else
            {
                if (ParentID != null)
                    return ParentID.GetRevenueSubAccountCode();
                else
                    return null;
            }
        }
        
        public override SendDataTypesEnum? GetMySendDataTypesEnum()
        {
            return SendDataTypesEnum.ProcedureTreeInfo;
        }

        public override bool GetMyChildTerminologyManagerDefs() 
        {
            return false;
        }
        
#endregion Methods

    }
}