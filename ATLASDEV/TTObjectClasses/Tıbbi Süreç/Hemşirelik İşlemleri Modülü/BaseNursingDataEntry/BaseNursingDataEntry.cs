
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
    /// Ana Hemşirelik Veri Girişi
    /// </summary>
    public  partial class BaseNursingDataEntry : TTObject
    {
    /// <summary>
    /// İşlem Özeti
    /// </summary>
        public string ApplicationSummary
        {
            get
            {
                try
                {
                    #region ApplicationSummary_GetScript                    
                   return  GetApplicationSummary();
#endregion ApplicationSummary_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "ApplicationSummary") + " : " + ex.Message, ex);
                }
            }
            set
            {
                try
                {
#region ApplicationSummary_SetScript                    
                    
#endregion ApplicationSummary_SetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M149", "Error setting property '{0}'", "ApplicationSummary") + " : " + ex.Message, ex);
                }
            }
        }

        public virtual string GetApplicationSummary()
        {
            return string.Empty;
        }

        public virtual string GetRowColor()
        {
            return string.Empty;
        }

        //TODO: ismail öntaburcu isteği burda yapılacak
        protected override void PreInsert()
        {
            #region PreInsert
            if (controlPreDischargedDate())
                base.PreInsert();

            #endregion PreInsert
        }

        protected override void PreUpdate()
        {
            #region PreUpdate
            if (controlPreDischargedDate())
                base.PreUpdate();

            #endregion PreUpdate
        }

        protected bool controlPreDischargedDate()
        {
            if (CurrentStateDefID == BaseNursingDataEntry.States.Yeni)
            {
                //DateTime? _dischargedDate = this.NursingApplication.InPatientTreatmentClinicApp.ClinicDischargeDate;

                DateTime? _dischargedDate = null;

                if (NursingApplication.EmergencyIntervention != null && NursingApplication.EmergencyIntervention.DischargeTime != null)
                    _dischargedDate = NursingApplication.EmergencyIntervention.DischargeTime;
                else if (NursingApplication.InPatientTreatmentClinicApp != null)
                    _dischargedDate = NursingApplication.InPatientTreatmentClinicApp.ClinicDischargeDate;

                if (_dischargedDate < ApplicationDate)
                    throw new Exception("Hasta " + _dischargedDate + " tarihinde taburcu olduğu için bu tarihten sonrasına herhangi bir işlem eklenemez / değiştirilemez.");
                else
                    return true;
            }

            return true;
        }


    }
}