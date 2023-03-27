
using System;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Linq;
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
    /// İzinli Hasta Çıkış Bilgileri
    /// </summary>
    public  partial class PatientOnVacation : TTObject
    {
        public static string HasActiveVacation(DateTime dateTime,Guid patientID)
        {
            using (var objectContext = new TTObjectContext(false))
            {
                string returnMessage = string.Empty;

                GetVacationByDateAndPatient_Class activeVacation = PatientOnVacation.GetVacationByDateAndPatient(dateTime, patientID).FirstOrDefault();

                if (activeVacation != null)
                {
                    returnMessage = "İşlem yapmak istediğiniz hasta " + activeVacation.StartDate + " ile " + activeVacation.EndDate + " arasında izinlidir";
                }

                return returnMessage;
            }
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(CompanionApplication).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == PatientOnVacation.States.OnVacation && toState == PatientOnVacation.States.VacationFinish)
                PostTransition_OnVacation2VacationFinish();

        }

        private void PostTransition_OnVacation2VacationFinish()
        {
        }
    }
}