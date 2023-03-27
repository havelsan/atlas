
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
    public  partial class MainPatientGroupDefinition : TerminologyManagerDef
    {
        public partial class GetMainPatientGroupDefinition_Class : TTReportNqlObject 
        {
        }

#region Methods
        public override SendDataTypesEnum?  GetMySendDataTypesEnum()
        {
            return SendDataTypesEnum.MainPatientGroupDefinitionInfo;
        }
        
        public List<PatientGroupDefinition> GetActivePatientGroups()
        {
            List<PatientGroupDefinition> activePatientGroups = new List<PatientGroupDefinition>();
            foreach (PatientGroupDefinition patientGroup in PatientGroups)
            {
                if(patientGroup.IsActive == null || patientGroup.IsActive == true)
                    activePatientGroups.Add(patientGroup);
            }
            return activePatientGroups;
        }
        
#endregion Methods

    }
}