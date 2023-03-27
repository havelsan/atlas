
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
    /// Gizlilik bitiþ Tarihi Olan Hastalarý Düzenler
    /// </summary>
    public  partial class ArrangePrivatePatient : BaseScheduledTask
    {
        public override void TaskScript()
        {
            string logTxt = "ArrangePrivatePatient Has Started : " + Common.RecTime();
            try
            {

                using (TTObjectContext objectContext = new TTObjectContext(false))
                {
                    List<Patient> patients = new List<Patient>();
                    patients = Patient.GetPrivatePatientsByDate(objectContext, Common.RecTime().Date).ToList();

                    foreach (Patient p in patients)
                    {
                        try
                        {
                            p.PatientAddress.HomeAddress = p.PrivacyHomeAddress;
                            p.PatientAddress.MobilePhone = p.PrivacyMobilePhone;
                            p.Name = p.PrivacyName;
                            p.Surname = p.PrivacySurname;
                            p.UniqueRefNo = p.PrivacyUniqueRefNo;
                            p.Privacy = false;

                            p.PrivacyHomeAddress = null;
                            p.PrivacyMobilePhone = null;
                            p.PrivacyName = null;
                            p.PrivacySurname = null;
                            p.PrivacyUniqueRefNo = null;
                            p.PrivacyEndDate = null;

                            objectContext.Update();
                        }
                        catch (Exception e)
                        {
                            logTxt += p.ObjectID + " olan nesnenin gizliliði kaldýrýlamadý. Alýnan hata: " + e.ToString();
                        }
                    }

                    objectContext.Save();
                }

                //logTxt += " - Has Finished Succesfully : " + Common.RecTime();

            }
            catch (Exception ex)
            {
                logTxt += " - ERROR: " + ex.ToString() + ": " + Common.RecTime();
            }

            AddLog(logTxt);
        }
    }
}