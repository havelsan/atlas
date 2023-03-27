
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
    /// Sağlık Kurulu Muayene Edecek Birim(ler) / XXXXXX(ler) Tanımlama
    /// </summary>
    public  partial class ReasonForExaminationDefinition : TerminologyManagerDef
    {
        public partial class GetReasonForExaminationDefinition_Class : TTReportNqlObject 
        {
        }

        public partial class OLAP_GetHealthCommitteeReasons_Class : TTReportNqlObject 
        {
        }

        public partial class GetAutomaticallyCreatables_Class : TTReportNqlObject 
        {
        }

#region Methods
        public override string ToString()
        {
            return Reason;
        }
        public override SendDataTypesEnum?  GetMySendDataTypesEnum()
        {
            return SendDataTypesEnum.ReasonForExaminationDefinitionInfo;
        }
        
        public override List<string> GetMyLocalPropertyNamesList()
        {
            List<string> localPropertyNamesList = base.GetMyLocalPropertyNamesList();
            if(localPropertyNamesList == null)
                localPropertyNamesList = new List<string>();
            localPropertyNamesList.Add("AutomaticallyCreatable");
            localPropertyNamesList.Add("DirectlyPrintReports");
            return localPropertyNamesList;
        }
        
#endregion Methods

    }
}