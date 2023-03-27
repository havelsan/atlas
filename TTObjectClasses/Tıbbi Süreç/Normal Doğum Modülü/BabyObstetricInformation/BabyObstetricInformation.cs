
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
    /// Bebek Bilgileri
    /// </summary>
    public partial class BabyObstetricInformation : BaseMultipleDataEntry
    {
        protected override void PostInsert()
        {
            #region PostInsert

            base.PostInsert();
            SendSmsForBaby();
            #endregion PostInsert
        }
        public void SendSmsForBaby()
        {
            if (RegularObstetric != null && RegularObstetric.Patient != null && RegularObstetric.Patient.PatientAddress != null && RegularObstetric.Patient.PatientAddress.MobilePhone != null)
            {
                string messageText = TTObjectClasses.SystemParameter.GetParameterValue("SmsForBabyMessageText", "");
                UserMessage userMessage = new UserMessage();
                List<Patient> patients = new List<Patient> { RegularObstetric.Patient };
                if (!string.IsNullOrEmpty(messageText))
                    userMessage.SendSMSPatient(patients, messageText, SMSTypeEnum.BabyObstetricInfoSMS);
            }
        }
    }
}