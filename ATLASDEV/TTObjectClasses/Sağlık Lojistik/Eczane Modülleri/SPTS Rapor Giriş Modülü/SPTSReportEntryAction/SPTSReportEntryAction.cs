
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
    /// SPTS Rapor Giriş 
    /// </summary>
    public partial class SPTSReportEntryAction : EpisodeAction
    {
        protected void PreTransition_Request2Approval()
        {
            // From State : Request   To State : Approval
            #region PreTransition_Request2Approval



            //XXXXXXSptsClasses.RaporInfo raporInfo = ((XXXXXXSptsClasses.RaporInfo)SPTSReportEntryAction.GetRaporInfo(this));
            //TTMessage message = TTMessageFactory.ASyncCall(Sites.SiteMerkezSPTS, TTMessagePriorityEnum.HighPriority, "XXXXXXDLL", "XXXXXXDLL", "RaporGir", null, raporInfo);
            //this.SPTSMessageID = message.MessageID;


            #endregion PreTransition_Request2Approval
        }

        #region Methods
        public static XXXXXXSptsClasses.RaporInfo GetRaporInfo(SPTSReportEntryAction report)
        {
            XXXXXXSptsClasses.RaporInfo raporInfo = new XXXXXXSptsClasses.RaporInfo();
            raporInfo.HastaId = report.Episode.Patient.ObjectID.ToString();
            raporInfo.XXXXXX = SystemParameter.GetParameterValue("SPTSHOSPITALID", null).ToString();
            raporInfo.kurumId = 100000; //TODO: Bu İç SPTS olduğunda kaldırılacaktır.
            raporInfo.kurumturu = (int)report.FoundationType.Value;
            raporInfo.raporbaslangictarihi = report.ReportStartDate.ToString();
            raporInfo.raporbitistarihi = report.ReportEndDate.ToString();
            raporInfo.patoloji = Convert.ToInt32(report.PathologyReport).ToString();
            raporInfo.raporno = report.Report_No.ToString();
            raporInfo.tedavisema = Convert.ToInt32(report.SchemeOfCure).ToString();
            raporInfo.yasboy = Convert.ToInt32(report.AgeAndSize).ToString();
            raporInfo.zdegeri = Convert.ToInt32(report.TValue).ToString();
            raporInfo.agizdanbeslenemez = Convert.ToInt32(report.OralNutrition).ToString();

            raporInfo.uzmanliklar = new List<XXXXXXSptsClasses.uzmanlik>();
            foreach (SpecialityForReport speciality in report.SpecialityForReports)
            {
                XXXXXXSptsClasses.uzmanlik uzmanlık = new XXXXXXSptsClasses.uzmanlik();
                uzmanlık.kodu = speciality.Speciality.Code.ToString();
                uzmanlık.adi = speciality.Speciality.Name.ToString();
                raporInfo.uzmanlikdali = Convert.ToInt16(speciality.Speciality.Code);
            }

            raporInfo.ilaclar = new List<XXXXXXSptsClasses.raporilac>();
            foreach (DrugOrderForReport drugOrder in report.DrugOrderForReports)
            {
                XXXXXXSptsClasses.raporilac raporIlac = new XXXXXXSptsClasses.raporilac();
                long sptsID = drugOrder.BarcodeLevel.SPTSDrugID.Value;
                raporIlac.Id = Convert.ToInt32(sptsID);
                raporIlac.name = drugOrder.BarcodeLevel.Name.ToString();
                raporIlac.Dosage = (int)drugOrder.Dosage;
                raporIlac.DosageAmount = (int)drugOrder.DosageAmount;
                raporIlac.weeklyMonthly = (int)drugOrder.WeeklyMonthly;
                raporIlac.PacketAmount = raporIlac.Dosage * raporIlac.DosageAmount * raporIlac.weeklyMonthly;
                raporIlac.AlternativeId = 0;
                if (drugOrder.HasReport != null)
                {
                    raporIlac.hasReport = (Boolean)drugOrder.HasReport;
                }
                else
                {
                    raporIlac.hasReport = false;
                }
                if (drugOrder.HasTenDays != null)
                {
                    raporIlac.hasTenDays = (Boolean)drugOrder.HasTenDays;
                }
                else
                {
                    raporIlac.hasTenDays = false;
                }
                raporInfo.ilaclar.Add(raporIlac);

            }

            raporInfo.tanilar = new List<XXXXXXSptsClasses.raportani>();
            foreach (DiagnosisForReport diagnosis in report.DiagnosisForReports)
            {
                XXXXXXSptsClasses.raportani dia = new XXXXXXSptsClasses.raportani();
                dia.adi = diagnosis.SPTSDiagnosisInfo.Name.ToString();
                dia.kodu = diagnosis.SPTSDiagnosisInfo.ID.ToString();
                raporInfo.tanilar.Add(dia);
            }
            return raporInfo;
        }

        #endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(SPTSReportEntryAction).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == SPTSReportEntryAction.States.Request && toState == SPTSReportEntryAction.States.Approval)
                PreTransition_Request2Approval();
        }

    }
}