
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
    /// Katılım Payı Alınmayacak Hal, Sağlık Hizmeti ve Kişi Tanımları
    /// </summary>
    public  partial class PatientExamParticipationDefinition : TerminologyManagerDef
    {
        public partial class GetPatientParticipationDefs_Class : TTReportNqlObject 
        {
        }

        protected override void PreUpdate()
        {
#region PreUpdate
            base.PreUpdate();
            
            if(OnlyForDefinedUnits == true && Units.Count == 0)
                throw new TTUtils.TTException(SystemMessage.GetMessage(577));

#endregion PreUpdate
        }

#region Methods
        public override SendDataTypesEnum?  GetMySendDataTypesEnum()
        {
            return SendDataTypesEnum.PatientExamParticipationDefinitionInfo;
        }
        
        public override List<string> GetMyLocalPropertyNamesList()
        {
            List<string> localPropertyNamesList = base.GetMyLocalPropertyNamesList();
            if(localPropertyNamesList==null)
                localPropertyNamesList = new List<string>();
            localPropertyNamesList.Add("OnlyForDefinedUnits");
            return localPropertyNamesList;
        }
        
#endregion Methods

    }
}