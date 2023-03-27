
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
    public  partial class PatientOwnDrugReturn : EpisodeAction
    {
        protected void PreTransition_New2Completed()
        {
            #region  PreTransition_New2Completed
            foreach (PatientOwnDrugReturnDetail patientOwnDrugReturnDetail in PatientOwnDrugReturnDetails)
            {
                PatientOwnDrugTrxDetail patientOwnDrugTrxDetail = new PatientOwnDrugTrxDetail(ObjectContext);
                patientOwnDrugTrxDetail.Amount = patientOwnDrugReturnDetail.Amount;
                patientOwnDrugTrxDetail.PatientOwnDrugTrx = patientOwnDrugReturnDetail.PatientOwnDrugTrx;
                patientOwnDrugTrxDetail.CurrentStateDefID = PatientOwnDrugTrxDetail.States.Completed;
            }
            #endregion  PreTransition_New2Completed
        }

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(PatientOwnDrugReturn).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == PatientOwnDrugReturn.States.New && toState == PatientOwnDrugReturn.States.Completed)
                PreTransition_New2Completed();

        }
    }
}