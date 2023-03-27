
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
    /// Hasta kabul esnasında başlatılacak işlem/hizmetler
    /// </summary>
    public partial class PatientAdmissionStartedActions : TerminologyManagerDef
    {
        #region Methods
        public static PatientAdmissionStartedActions GetFiredActionsandProcedures(ResPoliclinic policlinic,AdmissionStatusEnum? admissionStatus)
        {
            PatientAdmissionStartedActions returnVal = null;
            TTObjectContext context = new TTObjectContext(true);

            if (admissionStatus.HasValue == true)
            {
                if (admissionStatus == AdmissionStatusEnum.OluKabul)
                {
                    IBindingList list = PatientAdmissionStartedActions.GetByDeathAdmissionStatus(context, admissionStatus.Value);
                    if (list.Count > 0)
                        returnVal = (PatientAdmissionStartedActions)list[0];
                }
                else if (admissionStatus == AdmissionStatusEnum.HizmetProtokol ||admissionStatus == AdmissionStatusEnum.DisaridanGelenKonsultasyon)
                {
                    IBindingList list = PatientAdmissionStartedActions.GetStartedActionByStatus(context, admissionStatus.Value);
                    if (list.Count > 0)
                        returnVal = (PatientAdmissionStartedActions)list[0];
                }
                else
                {
                    IBindingList list = PatientAdmissionStartedActions.GetByAdmissionStatus(context, admissionStatus.Value, policlinic.ObjectID);
                    if (list.Count > 0)
                        returnVal = (PatientAdmissionStartedActions)list[0];
                }
             
            }
            return returnVal;
       
        }

       
        #endregion
    }
}