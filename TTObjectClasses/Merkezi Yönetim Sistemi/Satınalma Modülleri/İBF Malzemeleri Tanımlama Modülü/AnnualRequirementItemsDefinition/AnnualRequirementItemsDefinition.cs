
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
    /// İBF Malzemeleri
    /// </summary>
    public  partial class AnnualRequirementItemsDefinition : TerminologyManagerDef
    {
        public partial class ARItemsDefinitonFormNQL_Class : TTReportNqlObject 
        {
        }

        protected override void PreInsert()
        {
#region PreInsert
            base.PreInsert();
            
//            if (this.AnnualRequirementItems.Count == 0)
//                throw new TTUtils.TTException("Hiçbir satınalma kalemi seçmediniz");
//            
//            IList list = AnnualRequirementItemsDefinition.GetAnnualRequirementsDefByYearNQL(this.ObjectContext, Convert.ToInt16(this.Year), IBFTypeDefinition.ObjectID.ToString());
//            if (list.Count > 1)
//                throw new TTUtils.TTException("Bu yıla ait bir tanımlama var");

#endregion PreInsert
        }

#region Methods
        public override SendDataTypesEnum?  GetMySendDataTypesEnum()
        {
            return SendDataTypesEnum.AnnualRequirementItemsDefinitionInfo;
        }
        
#endregion Methods

    }
}