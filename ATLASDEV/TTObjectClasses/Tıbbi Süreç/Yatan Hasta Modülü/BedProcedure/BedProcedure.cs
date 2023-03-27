
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
    /// Nabýz için yatak clone iþlemleri
    /// </summary>
    public partial class BedProcedure : SubActionProcedure
    {
        // Yatak için pandemi hizmeti oluþturan metod
        public void CreatePandemicProcedure()
        {
            if (SystemParameter.GetParameterValue("CREATEPANDEMICPROCEDURE", "TRUE") == "TRUE")
            {
                BedProcedureDefinition bedProcedureDefinition = ProcedureObject as BedProcedureDefinition;

                if (bedProcedureDefinition?.PandemicProcedure != null) // Pandemi hizmeti tanýmlý ise
                {
                    PandemicProcedure pandemicProcedure = new PandemicProcedure(ObjectContext);
                    pandemicProcedure.PricingDate = PricingDate;
                    pandemicProcedure.PerformedDate = PerformedDate;
                    pandemicProcedure.EpisodeAction = EpisodeAction;
                    pandemicProcedure.CurrentStateDefID = SubActionProcedure.States.Completed;
                    pandemicProcedure.ProcedureObject = bedProcedureDefinition.PandemicProcedure;
                    pandemicProcedure.MasterSubActionProcedure = this;
                    pandemicProcedure.ProcedureDoctor = BaseBedProcedure?.InPatientTreatmentClinicApp?.ProcedureDoctor;
                }
            }
        }

        public override string GetDVORefakatciGunSayisi(AccountTransaction accTrx, string yatisBaslangicTarihi = null, string yatisBitisTarihi = null)
        {
            DateTime baslangicTarihi;
            DateTime bitisTarihi;

            if (!string.IsNullOrEmpty(yatisBaslangicTarihi))
                baslangicTarihi = Convert.ToDateTime(yatisBaslangicTarihi);
            else
                baslangicTarihi = Convert.ToDateTime(GetDVOYatisBaslangicTarihi(accTrx));

            if (!string.IsNullOrEmpty(yatisBitisTarihi))
                bitisTarihi = Convert.ToDateTime(yatisBitisTarihi);
            else
                bitisTarihi = Convert.ToDateTime(GetDVOYatisBitisTarihi(accTrx));

            return BaseBedProcedure.GetCompanionDayCount(accTrx, baslangicTarihi, bitisTarihi);
        }

        public override string GetDVOAciklama(AccountTransaction accTrx)
        {
            return BaseBedProcedure?.Aciklama;
        }

        public override string GetDVOYatakKodu()
        {
            return BaseBedProcedure?.Bed?.BedCodeForMedula;
        }

        public override string GetDVOBransKodu(AccountTransaction accTrx)
        {
            return EpisodeAction?.ProcedureSpeciality?.Code;
        }

        public override string GetDVODrTescilNo(string branchCode)
        {
            if (BaseBedProcedure?.InPatientTreatmentClinicApp != null)
            {
                if (BaseBedProcedure.InPatientTreatmentClinicApp.ProcedureDoctor != null && !string.IsNullOrEmpty(BaseBedProcedure.InPatientTreatmentClinicApp.ProcedureDoctor.DiplomaRegisterNo))
                    return BaseBedProcedure.InPatientTreatmentClinicApp.ProcedureDoctor.DiplomaRegisterNo;
            }

            if (EpisodeAction.ProcedureDoctor != null && !string.IsNullOrEmpty(EpisodeAction.ProcedureDoctor.DiplomaRegisterNo))
                return EpisodeAction.ProcedureDoctor.DiplomaRegisterNo;

            return Common.GetDoctorRegisterNoByBranchCode(branchCode);
        }

        override public bool SendToENabiz(bool isNewInserted)
        {
            if (IsOldAction == true)
                return false;

            return true;
        }
    }
}