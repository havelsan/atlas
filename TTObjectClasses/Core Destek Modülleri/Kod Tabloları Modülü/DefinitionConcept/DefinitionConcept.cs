
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
    /// Tanım Kavramı
    /// </summary>
    public  partial class DefinitionConcept : TerminologyManagerDef
    {
        public partial class GetEqualDefinitionConcepts_Class : TTReportNqlObject 
        {
        }

        public partial class GetOtherDefinitionConcepts_Class : TTReportNqlObject 
        {
        }

#region Methods
        public override SendDataTypesEnum?  GetMySendDataTypesEnum()
        {
            return SendDataTypesEnum.DefinitionConceptInfo;
        }
        
#endregion Methods

    }
}