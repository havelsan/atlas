
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
    public  partial class EmergencyPatientStatusInfo : TTObject
    {
#region Methods
        public static List<string> GetActiveItems()
        {
            TTObjectContext context = new TTObjectContext(true);
            BindingList<EmergencyPatientStatusInfo> itemList = null;
            List<string> retList = new List<string>();
            int lastNHours = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("EMERGENCYPATIENTINFOLASTNHOUR", "6"));
            
            DateTime startDate = Common.RecTime().AddHours(lastNHours * -1);
            itemList = EmergencyPatientStatusInfo.GetActiveItems(context, startDate);
            
            StringBuilder strb = new StringBuilder();
            foreach (EmergencyPatientStatusInfo item in itemList)
            {
                Episode episode = item.Episode[0];
                retList.Add(episode.Patient.FullName + " " + Common.GetEnumValueDefOfEnumValue(item.PatientStatus).DisplayText);
            }
            
            return retList;
        }
        
#endregion Methods

    }
}