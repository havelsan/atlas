
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
    public  partial class LaboratoryTabNamesGrid : TTObject
    {
        public partial class GetLabTabNamesGridByInjection_Class : TTReportNqlObject 
        {
        }

        public partial class GetByTabs_Class : TTReportNqlObject 
        {
        }

#region Methods
        public override string ToString()
        {
            string tabName = RequestFormTab != null ? RequestFormTab.Name : String.Empty;
            string testName = LaboratoryTestDefinition.Name != null ? LaboratoryTestDefinition.Name : String.Empty;
            string tabOrder = TabOrder.HasValue ? TabOrder.Value.ToString() : String.Empty;
            return tabName + " - " + testName + " : " + tabOrder;
        }
        
#endregion Methods

    }
}