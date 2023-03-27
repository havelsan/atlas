
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
    /// 15 gün içinde Covid Tanısı Girilmemiş Hastaların Pandemi bilgisini siler
    /// </summary>
    public partial class ClearCovidInfoFromPatient : BaseScheduledTask
    {
        public override void TaskScript()
        {
            string logTxt = "ClearCovidInfoFromPatient Has Started : " + Common.RecTime();
            try
            {

                List<RadiologyTest.GetAllRadiologyWithFilter_Class> radiologyTestList = new List<RadiologyTest.GetAllRadiologyWithFilter_Class>();

                int dateLimit = Convert.ToInt32(TTObjectClasses.SystemParameter.GetParameterValue("DELETECOVIDINFODATEPARAM", "15"));

                List<Patient.GetCovidPatientByDate_Class> patientList = Patient.GetCovidPatientByDate(DateTime.Now.AddDays(-dateLimit)).ToList();

                foreach (Patient.GetCovidPatientByDate_Class item in patientList)
                {
                    using (TTObjectContext objectContext = new TTObjectContext(false))
                    {
                        Patient patient = (Patient)objectContext.GetObject(item.ObjectID.Value, "PATIENT");
                        patient.MedicalInformation.Pandemic = false;

                        objectContext.Save();

                        AddLog(patient.ObjectID+ " li hastaya ait Pandemi Bilgisi Kaldırıldı");
                    }
                }

                logTxt += " - Has Finished Succesfully : " + Common.RecTime();

                AddLog(logTxt);

            }
            catch (Exception ex)
            {
                logTxt += " - ERROR: " + ex.ToString() + ": " + Common.RecTime();
                AddLog(logTxt);
            }
        }
    }
}