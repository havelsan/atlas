
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
    /// Meslek Tanımları
    /// </summary>
    public  partial class JobTitleDefinition : TerminologyManagerDef
    {
        public partial class GetJobTitle_Class : TTReportNqlObject 
        {
        }

        
                    
        protected override void PreInsert()
        {
#region PreInsert
            base.PreInsert();
            if (ID.Value == null)
               ID.GetNextValue();
#endregion PreInsert
        }

#region Methods
        public override SendDataTypesEnum?  GetMySendDataTypesEnum()
        {
            return SendDataTypesEnum.JobTitleInfo;
        }
        
#endregion Methods

    }
}