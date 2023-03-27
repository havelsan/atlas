
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
    /// Hastanın İlaçları Giriş
    /// </summary>
    public partial class PatientOwnDrugEntry : EpisodeAction
    {
        protected void PreTransition_PharmacyApproval2Completed()
        {
            #region PreTransition_PharmacyApproval2Completed
            foreach (PatientOwnDrugEntryDetail patientOwnDrugEntryDetail in PatientOwnDrugEntryDetails)
            {
                if (DateTime.Now >= ((DateTime)patientOwnDrugEntryDetail.ExpirationDate))
                {
                    throw new Exception(patientOwnDrugEntryDetail.Material.Name + " ilaç son kullanım tarihi geçmiş tarihli olamaz");
                }

                PatientOwnDrugTrx patientOwnDrugTrx = new PatientOwnDrugTrx(ObjectContext);
                patientOwnDrugTrx.Amount = patientOwnDrugEntryDetail.Amount;
                patientOwnDrugTrx.ExpirationDate = patientOwnDrugEntryDetail.ExpirationDate;
                patientOwnDrugTrx.PatientOwnDrugEntryDetail = patientOwnDrugEntryDetail;

                patientOwnDrugEntryDetail.Status = OwnDrugStatus.Complated;
            }
            #endregion PreTransition_PharmacyApproval2Completed
        }

        protected void PreTransition_New2PharmacyApproval()
        {
            #region PreTransition_PharmacyApproval2Completed
            foreach (PatientOwnDrugEntryDetail patientOwnDrugEntryDetail in PatientOwnDrugEntryDetails)
            {
                if (DateTime.Now >= ((DateTime)patientOwnDrugEntryDetail.ExpirationDate))
                {
                    throw new Exception(patientOwnDrugEntryDetail.Material.Name + " ilaç son kullanım tarihi geçmiş tarihli olamaz");
                }
                patientOwnDrugEntryDetail.Amount = patientOwnDrugEntryDetail.SendAmount;

            }
            #endregion PreTransition_PharmacyApproval2Completed
        }

        protected void PreTransition_New2Completed()
        {
            #region PreTransition_New2Completed
            foreach (PatientOwnDrugEntryDetail patientOwnDrugEntryDetail in PatientOwnDrugEntryDetails)
            {
                if (DateTime.Now >= ((DateTime)patientOwnDrugEntryDetail.ExpirationDate))
                {
                    throw new Exception(patientOwnDrugEntryDetail.Material.Name + " ilaç son kullanım tarihi geçmiş tarihli olamaz");
                }
                patientOwnDrugEntryDetail.Amount = patientOwnDrugEntryDetail.SendAmount;
                PatientOwnDrugTrx patientOwnDrugTrx = new PatientOwnDrugTrx(ObjectContext);
                patientOwnDrugTrx.Amount = patientOwnDrugEntryDetail.Amount;
                patientOwnDrugTrx.ExpirationDate = patientOwnDrugEntryDetail.ExpirationDate;
                patientOwnDrugTrx.PatientOwnDrugEntryDetail = patientOwnDrugEntryDetail;

                patientOwnDrugEntryDetail.Status = OwnDrugStatus.Complated;
            }
            #endregion PreTransition_New2Completed
        }

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(PatientOwnDrugEntry).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == PatientOwnDrugEntry.States.New && toState == PatientOwnDrugEntry.States.PharmacyApproval)
                PreTransition_New2PharmacyApproval();

            if (fromState == PatientOwnDrugEntry.States.New && toState == PatientOwnDrugEntry.States.Completed)
                PreTransition_New2Completed();

            if (fromState == PatientOwnDrugEntry.States.PharmacyApproval && toState == PatientOwnDrugEntry.States.Completed)
                PreTransition_PharmacyApproval2Completed();
        }
    }
}