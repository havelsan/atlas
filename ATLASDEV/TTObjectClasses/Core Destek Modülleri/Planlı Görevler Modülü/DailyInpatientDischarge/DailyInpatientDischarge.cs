
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
    public  partial class DailyInpatientDischarge : BaseScheduledTask
    {
        public override void TaskScript()
        {
            string logTxt = "DailyInpatientDischarge Has Started : " + Common.RecTime();
            try
            {

                using (TTObjectContext objectContext = new TTObjectContext(false))
                {
                    List<InPatientTreatmentClinicApplication> DischargeObjects = new List<InPatientTreatmentClinicApplication>();
                    DischargeObjects = InPatientTreatmentClinicApplication.GetDailyAppForDischarge(objectContext, Common.RecTime().Date.AddDays(1).AddSeconds(-1), Common.RecTime().Date.AddDays(-30)).ToList();

                    foreach(InPatientTreatmentClinicApplication app in DischargeObjects)
                    {
                        try
                        {
                            app.TreatmentDischarge.CurrentStateDefID = TreatmentDischarge.States.Discharged;
                            objectContext.Save();
                        }
                        catch(Exception e)
                        {
                            logTxt += app.ObjectID + " olan nesne taburcu adýmýna geçemedi. Alýnan hata: " + e.ToString();
                        }
                    }
                }

                logTxt += " - Has Finished Succesfully : " + Common.RecTime();

            }
            catch (Exception ex)
            {
                logTxt += " - ERROR: " + ex.ToString() + ": " + Common.RecTime();

            }
            AddLog(logTxt);
        }

    }
}