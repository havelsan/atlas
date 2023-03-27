
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
    /// Patoloji
    /// </summary>
    public partial class Pathology : EpisodeActionWithDiagnosis, IAllocateSpeciality, IWorkListPathology, ITreatmentMaterialCollection, ICheckPaid
    {
        public partial class PathologyTestReqStateInfoNQL_Class : TTReportNqlObject
        {
        }

        public partial class PathologyTestRequestInfoStickerNQL_Class : TTReportNqlObject
        {
        }

        public partial class PathologyTestReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class PathologyTestResultPatientInfoReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class PathologyTestResultReportQuery_Class : TTReportNqlObject
        {
        }

        public partial class GetPathologyStatisticsByInjection_Class : TTReportNqlObject
        {
        }

        public partial class GetPathologyTestByEpisode_Class : TTReportNqlObject
        {
        }

        public partial class GetByPatTestFilterExpressionReport_Class : TTReportNqlObject
        {
            #region GetByPatTestFilterExpressionReport_Methods

            public string RefNo
            {
                get
                {
                    if (Foreign == true)
                        return "(*) " + Convert.ToString(UniqueRefNo);
                    else
                        return Convert.ToString(UniqueRefNo);
                }
            }

            #endregion GetByPatTestFilterExpressionReport_Methods

        }

        public partial class GetByPatTestWorklistDateReport_Class : TTReportNqlObject
        {
            #region GetByPatTestWorklistDateReport_Methods

            public string RefNo
            {
                get
                {
                    if (Foreign == true)
                        return "(*) " + Convert.ToString(UniqueRefNo);
                    else
                        return Convert.ToString(UniqueRefNo);
                }
            }

            #endregion GetByPatTestWorklistDateReport_Methods

        }

        public partial class GetPathologyTestBySubEpisode_Class : TTReportNqlObject
        {
        }

        public partial class GetPathologyStatisticsNewNQL_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetPathologyTest_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetCancelledPathologyTest_Class : TTReportNqlObject
        {
        }

        public partial class GetPathologyStatisticsDynamicNQL_Class : TTReportNqlObject
        {
        }

        public partial class GetPathologyStatisticsNQL_Class : TTReportNqlObject
        {
        }

        public partial class PathologyTestRequestBarcodeNQL_Class : TTReportNqlObject
        {
        }

        public partial class GetPathologyTestStatisticsByFilter_Class : TTReportNqlObject
        {
        }

        public partial class VEM_PATOLOJI_Class : TTReportNqlObject
        {
        }

        #region IAllocateSpeciality Members
        public Episode GetEpisode()
        {
            return Episode;
        }

        public void SetEpisode(Episode value)
        {
            Episode = value;
        }

        public EpisodeAction GetMyEpisodeAction()
        {
            return MyEpisodeAction;
        }

        public void SetMyEpisodeAction(EpisodeAction value)
        {
            MyEpisodeAction = value;
        }

        public SubActionProcedure GetMySubActionProcedure()
        {
            return MySubActionProcedure;
        }

        public void SetMySubActionProcedure(SubActionProcedure value)
        {
            MySubActionProcedure = value;
        }

        public SpecialityDefinition GetProcedureSpeciality()
        {
            return ProcedureSpeciality;
        }

        public void SetProcedureSpeciality(SpecialityDefinition value)
        {
            ProcedureSpeciality = value;
        }

        #endregion

        protected override void PreInsert()
        {
            #region PreInsert
            base.PreInsert();
            #endregion PreInsert
        }

        protected override void PostInsert()
        {
            #region PostInsert
            base.PostInsert();

            //SMS
            string smsPathologyActive = TTObjectClasses.SystemParameter.GetParameterValue("SMSPATHOLOGYACTIVE", "FALSE");

            if (smsPathologyActive == "TRUE")
            {
                EpisodeActionSMSInfo smsInfo = new EpisodeActionSMSInfo(ObjectContext);
                smsInfo.EpisodeAction = this;
                smsInfo.InternalObjectDefName = this.ObjectDef.Name;
                smsInfo.EpisodeActionDate = Common.RecTime();
                smsInfo.CompletedFlag = false; //Action tamamlandığında true olacak
                smsInfo.IsActiveFlag = true; //Yaratılan patoloji iptal edilirse false olacak
                smsInfo.SMSNumberForChief = 0;
                smsInfo.SMSNumberForDoctor = 0;
                smsInfo.SMSNumberForResponsible = 0;
                smsInfo.DoctorUserID = null; //mesaj gönderildiğinde doldurulacak
                smsInfo.ChiefUserID = null;
                smsInfo.ResponsibleUserID = null;

            }



            #endregion PostInsert
        }

        protected override void PostUpdate()
        {
            #region PostUpdate

            base.PostUpdate();

            //if(ReportMacroscopi != null)
            //    ReportMacroscopitxt = Common.CUCase(Common.GetTextOfRTFString(ReportMacroscopi.ToString()), false, false);
            //if(ReportMicroscopi != null)
            //    ReportMicroscopitxt = Common.CUCase(Common.GetTextOfRTFString(ReportMicroscopi.ToString()), false, false);
            //if(ReportDiagnoseComment != null)
            //    ReportDiagnoseCommenttxt = Common.CUCase(Common.GetTextOfRTFString(ReportDiagnoseComment.ToString()), false, false);

            #endregion PostUpdate
        }

        protected void PostTransition_Procedure2Cancelled()
        {
            // From State : Procedure   To State : Cancelled
            #region PostTransition_Procedure2Cancelled

            Cancel();

            CancelSMSForPathology();

            #endregion PostTransition_Procedure2Cancelled
        }

        protected void PostTransition_Procedure2ProcedureMicroscopy()
        {
            // From State : Procedure   To State : ProcedureMicroscopy
            #region PostTransition_Procedure2ProcedureMicroscopy
            if (!Paid())
            {
                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25846", "Hastanın ödemesi gereken hizmet bedeli mevcuttur, işlemi ilerletemezsiniz. İşlemi kaydederek hastayı vezneye yönlendiriniz."));
            }
            #endregion PostTransition_Procedure2ProcedureMicroscopy
        }

        protected void PostTransition_ProcedureMicroscopy2ResultEntry()
        {
            // From State : ProcedureMicroscopy   To State : ResultEntry
            #region PostTransition_ProcedureMicroscopy2ResultEntry
            if (!Paid())
            {
                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25846", "Hastanın ödemesi gereken hizmet bedeli mevcuttur, işlemi ilerletemezsiniz. İşlemi kaydederek hastayı vezneye yönlendiriniz."));
            }
            #endregion PostTransition_ProcedureMicroscopy2ResultEntry
        }

        protected void PreTransition_Approvement2Report()
        {
            // From State : Approvement   To State : Report
            #region PreTransition_Approvement2Report

            if (OlapDate == null)
                OlapDate = DateTime.Now;
            #endregion PreTransition_Approvement2Report
        }

        protected void PostTransition_Approvement2Report()
        {
            // From State : Approvement   To State : Report
            #region PostTransition_Approvement2Report

            //this.AutoCompleteParentObject(Pathology.States.Report, PathologyRequest.States.Report);
            ReportDate = TTObjectDefManager.ServerTime;
            SendSmsForPathologyReport();



            #endregion PostTransition_Approvement2Report
        }



        protected void PostTransition_RequestApprovement2Cancelled()
        {
            // From State : RequestApprovement   To State : Cancelled
            #region PostTransition_RequestApprovement2Cancelled
            /*
            bool hasTestToBeApproved = false;
            foreach(PathologyTest tetkik in this.Pathology.PathologyTests)
            {
                if(this.ObjectID != tetkik.ObjectID && tetkik.CurrentStateDefID != PathologyTest.States.Completed && tetkik.CurrentStateDefID != PathologyTest.States.Cancelled)
                   hasTestToBeApproved = true;
            }
            if(!hasTestToBeApproved)
                this.Pathology.CurrentStateDefID = Pathology.States.Procedure;
                */
            #endregion PostTransition_RequestApprovement2Cancelled
        }

        protected void PostTransition_RequestAcception2Rejected()
        {
            // From State : RequestAcception   To State : Rejected
            #region PostTransition_RequestAcception2Rejected

            Cancel();

            #endregion PostTransition_RequestAcception2Rejected
        }

        protected void PostTransition_RequestAcception2Cancelled()
        {
            // From State : RequestAcception   To State : Cancelled
            #region PostTransition_RequestAcception2Cancelled

            Cancel();

            #endregion PostTransition_RequestAcception2Cancelled
        }

        protected void PostTransition_RequestAcception2Procedure()
        {
            // From State : RequestAcception   To State : Procedure
            #region PostTransition_RequestAcception2Procedure

            /*
            PathologyTestDefinition patTestDef = this.ProcedureObject as PathologyTestDefinition;
            if(patTestDef != null)
            {
                foreach(PathologyGridMaterialDefinition defMaterialGrid in patTestDef.Materials)
                {
                    PathologyLabMaterial patMaterial = new PathologyLabMaterial(this.Pathology.ObjectContext);
                    patMaterial.Amount = 1;
                    patMaterial.Material = defMaterialGrid.Material;
                    patMaterial.EpisodeAction = this.EpisodeAction;
                    this.TreatmentMaterials.Add(patMaterial);
                }
            }
            */


            #endregion PostTransition_RequestAcception2Procedure
        }

        protected void PostTransition_Request2RequestAcception()
        {
            // From State : Request   To State : RequestAcception
            #region PostTransition_Request2RequestAcception

            foreach (PathologyTestProcedure test in PathologyTestProcedures)
            {
                PathologyTestDefinition patTestDef = test.ProcedureObject as PathologyTestDefinition;
                if (patTestDef != null)
                {
                    foreach (PathologyGridMaterialDefinition defMaterialGrid in patTestDef.Materials)
                    {
                        PathologyLabMaterial patMaterial = new PathologyLabMaterial(ObjectContext);
                        patMaterial.Amount = 1;
                        patMaterial.Material = defMaterialGrid.Material;
                        patMaterial.EpisodeAction = this;
                        test.Pathology.TreatmentMaterials.Add(patMaterial);
                        //test.Pathology.PathologyLabMaterials.Add(patMaterial);
                    }
                }
            }

            #endregion PostTransition_Request2RequestAcception
        }

        protected void PostTransition_ResultEntry2Approvement()
        {
            // From State : ResultEntry   To State : Approvement
            #region PostTransition_ResultEntry2Approvement
            if (!Paid())
            {
                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25846", "Hastanın ödemesi gereken hizmet bedeli mevcuttur, işlemi ilerletemezsiniz. İşlemi kaydederek hastayı vezneye yönlendiriniz."));
            }
            #endregion PostTransition_ResultEntry2Approvement
        }

        protected void PreTransition_ResultEntry2Report()
        {
            // From State : ResultEntry   To State : Report
            #region PreTransition_ResultEntry2Report

            if (OlapDate == null)
                OlapDate = DateTime.Now;
            #endregion PreTransition_ResultEntry2Report
        }

        protected void PostTransition_ResultEntry2Report()
        {
            // From State : ResultEntry   To State : Report
            #region PostTransition_ResultEntry2Report

            //this.AutoCompleteParentObject(Pathology.States.Report, PathologyRequest.States.Report);
            #endregion PostTransition_ResultEntry2Report
        }



        #region Methods
        public void AutoCompleteParentObject(Guid childObjectStateDefID, Guid parentObjectStateDefID)
        {
            bool hasTestInPrevState = false;
            foreach (Pathology tetkik in PathologyRequest.Pathologies)
            {
                if (this != tetkik && tetkik.CurrentStateDefID != childObjectStateDefID)
                {
                    hasTestInPrevState = true;
                }
            }
            if (!hasTestInPrevState)
                PathologyRequest.CurrentStateDefID = parentObjectStateDefID;
        }

        public void AutoUndoParentObjectLastTranstion()
        {
            if (CurrentStateDefID != Pathology.States.Report)
                return;

            ((ITTObject)this).UndoLastTransition();
        }





        public void PrintLabel()
        {
            //        const string asc01 = "\u0001"; //SOH
            //        const string asc02 = "\u0002"; //STX
            //        const string crlf = "\r\n"; //CRLF

            //        Pathology test = this;
            //        Patient p = test.Pathology.Episode.Patient;

            //        string kod = test.MatPrtNoString;
            //        string isim = TTUtils.Globals.CUCase(p.FullName,false,false);
            //        string age = p.Age == null ? "" : p.Age.Value.ToString();
            //        string sex = (p.Sex == TTObjectClasses.SexEnum.Male) ? "E" : ((p.Sex == TTObjectClasses.SexEnum.Female) ? "K" : "");
            //        string dt = (Convert.ToDateTime(p.BirthDate)).ToString("dd/MM/yyyy");
            //        string procedureDoctor = "";
            //        if(test.ProcedureDoctor != null)
            //            procedureDoctor = test.ProcedureDoctor.Name;

            //        string kimlikNo;
            //        if(p.UniqueRefNo == null )
            //        {
            //            kimlikNo = string.Empty;
            //        }
            //        else
            //        {
            //            kimlikNo = p.UniqueRefNo.Value.ToString();
            //        }

            //        string islemTarihi;
            //        if(this.ActionDate != null)
            //            islemTarihi = (Convert.ToDateTime(this.ActionDate)).ToString("dd/MM/yyyy");
            //        else islemTarihi = string.Empty;

            //        StringBuilder sb = new StringBuilder();

            //        Guid siteIDGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", Guid.Empty.ToString()));
            //        if(Sites.SiteXXXXXX06XXXXXX == siteIDGuid || Sites.SiteXXXXXX35Mevki == siteIDGuid || Sites.SiteXXXXXX06Mevki == siteIDGuid)
            //        {
            //            sb.AppendLine();
            //            sb.AppendLine("N");
            //            sb.AppendLine("q320");
            //            sb.AppendLine("Q223,24+0");
            //            sb.AppendLine("S3");
            //            sb.AppendLine("D8");
            //            sb.AppendLine("ZT");
            //            sb.AppendLine("TTh:m");
            //            sb.AppendLine("TDy2.mn.dd");
            //            sb.AppendLine("O");
            //            sb.AppendLine("A6,8,0,1,1,1,N," + "\"" + "Adi Soyadi:" + "\"");
            //            sb.AppendLine("A6,26,0,1,1,1,N," + "\"" + "Yasi:" + "\"");
            //            sb.AppendLine("A6,45,0,1,1,1,N," + "\"" + "Dogum Tarihi:" + "\"");
            //            sb.AppendLine("A6,65,0,1,1,1,N," + "\"" + "Sorumlu Tbp:" + "\"");
            //            sb.AppendLine("A6,83,0,1,1,1,N," + "\"" + "Materyal Protokol Nu:" + "\"");
            //            sb.AppendLine("B67,114,0,3,1,3,69,N," + "\"" + kod + "\"");
            //            sb.AppendLine("A136,6,0,1,1,1,N," + "\"" + isim + "\"");
            //            sb.AppendLine("A136,26,0,1,1,1,N," + "\"" + age + "\"");
            //            sb.AppendLine("A138,47,0,1,1,1,N," + "\"" + dt + "\"");
            //            sb.AppendLine("A138,65,0,1,1,1,N," + "\"" + procedureDoctor + "\"");
            //            sb.AppendLine("A83,189,0,4,1,1,N," + "\"" + kod + "\"");
            //            sb.AppendLine("P1");
            //        }
            //        if(Sites.SiteXXXXXX04 == siteIDGuid)
            //        {
            //            //StringBuilder sb = new StringBuilder();
            //            //sb.AppendLine();

            //            sb.AppendLine();
            //            sb.AppendLine("N");
            //            sb.AppendLine("q320");
            //            sb.AppendLine("Q223,24+0");
            //            sb.AppendLine("S3");
            //            sb.AppendLine("D8");
            //            sb.AppendLine("ZT");
            //            sb.AppendLine("TTh:m");
            //            sb.AppendLine("TDy2.mn.dd");
            //            sb.AppendLine("O");
            //            sb.AppendLine("A6,8,0,1,1,1,N," + "\"" + "Adi Soyadi:" + "\"");
            //            sb.AppendLine("A6,26,0,1,1,1,N," + "\"" + "Yasi:" + "\"");
            //            sb.AppendLine("A6,45,0,1,1,1,N," + "\"" + "Dogum Tarihi:" + "\"");
            //            sb.AppendLine("A6,65,0,1,1,1,N," + "\"" + "Sorumlu Tbp:" + "\"");
            //            sb.AppendLine("A6,83,0,1,1,1,N," + "\"" + "Materyal Protokol Nu:" + "\"");
            //            sb.AppendLine("B67,114,0,3,1,3,69,N," + "\"" + kod + "\"");
            //            sb.AppendLine("A136,6,0,1,1,1,N," + "\"" + isim + "\"");
            //            sb.AppendLine("A136,26,0,1,1,1,N," + "\"" + age + "\"");
            //            sb.AppendLine("A138,47,0,1,1,1,N," + "\"" + dt + "\"");
            //            sb.AppendLine("A138,65,0,1,1,1,N," + "\"" + procedureDoctor + "\"");
            //            sb.AppendLine("A83,189,0,4,1,1,N," + "\"" + kod + "\"");
            //            sb.AppendLine("P1");
            //        }
            //        if(Sites.SiteXXXXXX == siteIDGuid)
            //        {
            //            //Zebra TLP-2844(V) modeli için tasarlanmıştır.

            //            sb.AppendLine();
            //            sb.AppendLine("N");
            //            sb.AppendLine("q320");
            //            sb.AppendLine("Q223,24+0");
            //            sb.AppendLine("S3");
            //            sb.AppendLine("D8");
            //            sb.AppendLine("ZT");
            //            sb.AppendLine("TTh:m");
            //            sb.AppendLine("TDy2.mn.dd");
            //            sb.AppendLine("O");
            //            sb.AppendLine("A16,20,0,1,1,1,N," + "\"" + "Ad Soyad :" + "\"");
            //            sb.AppendLine("A16,39,0,1,1,1,N," + "\"" + "Dogum Tarihi :" + "\"");
            //            sb.AppendLine("A16,57,0,1,1,1,N," + "\"" + "T.C. No :" + "\"");
            //            sb.AppendLine("A16,75,0,1,1,1,N," + "\"" + "Sorumlu Tbp. :" + "\"");
            //            sb.AppendLine("A164,20,0,1,1,1,N," + "\"" + isim + "\"");
            //            sb.AppendLine("A164,39,0,1,1,1,N," + "\"" + dt + "\"");
            //            sb.AppendLine("A164,57,0,1,1,1,N," + "\"" + kimlikNo + "\"");
            //            sb.AppendLine("A164,75,0,1,1,1,N," + "\"" + procedureDoctor + "\"");
            //            sb.AppendLine("A164,95,0,1,1,1,N," + "\"" + islemTarihi + "\"");
            //            sb.AppendLine("A16,114,0,1,1,1,N," + "\"" + "Materyal P. No:" + "\"");
            //            sb.AppendLine("A173,114,0,1,1,1,N," + "\"" + kod + "\"");
            //            sb.AppendLine("B63,138,0,3,1,3,45,B," + "\"" + kod + "\"");
            //            sb.AppendLine("A16,95,0,1,1,1,N," + "\"" + "Islem Tarihi :" + "\"");
            //            sb.AppendLine("P1");

            //            //Zebra TLP-2844(X) modeli için tasarlanmıştır.
            //            /*
            //            sb.AppendLine();
            //            sb.AppendLine("GK"+"\""+"PCX1"+"\"");
            //sb.AppendLine();
            //            sb.AppendLine("GK"+"\""+"PCX2"+"\"");
            //sb.AppendLine();
            //            sb.AppendLine("GK"+"\""+"PCX3"+"\"");
            //sb.AppendLine();
            //            sb.AppendLine("GK"+"\""+"PCX4"+"\"");
            //            sb.AppendLine();
            //sb.AppendLine("GK"+"\""+"PCX5"+"\"");
            //sb.AppendLine();
            //sb.AppendLine("I8,1,001");
            //sb.AppendLine();
            //            sb.AppendLine("O");
            //            sb.AppendLine("q318");
            //            sb.AppendLine("S4");
            //            sb.AppendLine("D5");
            //            sb.AppendLine("ZT");
            //            sb.AppendLine("JF");
            //            sb.AppendLine();
            //            sb.AppendLine("N");
            //            sb.AppendLine("A16,20,0,1,1,1,N," + "\"" + "Ad Soyad :" + "\"");
            //            sb.AppendLine("A16,39,0,1,1,1,N," + "\"" + "Dogum Tarihi :" + "\"");
            //            sb.AppendLine("A16,57,0,1,1,1,N," + "\"" + "T.C. No :" + "\"");
            //            sb.AppendLine("A16,75,0,1,1,1,N," + "\"" + "Sorumlu Tbp. :" + "\"");
            //            sb.AppendLine("A164,20,0,1,1,1,N," + "\"" + isim + "\"");
            //            sb.AppendLine("A164,39,0,1,1,1,N," + "\"" + dt + "\"");
            //            sb.AppendLine("A164,57,0,1,1,1,N," + "\"" + kimlikNo + "\"");
            //            sb.AppendLine("A164,75,0,1,1,1,N," + "\"" + responsibleDoctor + "\"");
            //            sb.AppendLine("A164,95,0,1,1,1,N," + "\"" + islemTarihi + "\"");
            //            sb.AppendLine("A16,114,0,1,1,1,N," + "\"" + "Materyal P. No:" + "\"");
            //            sb.AppendLine("A173,114,0,1,1,1,N," + "\"" + kod + "\"");
            //sb.AppendLine("B63,130,0,3,1,3,53,B," + "\"" + kod + "\"");
            //sb.AppendLine("A16,95,0,1,1,1,N," + "\"" + "Islem Tarihi :" + "\"");
            //            sb.AppendLine("P1");
            //             */
            //        }

            //        /* XXXXXX XXXXXX Eski Barkod
            //        StringBuilder sb = new StringBuilder();
            //        sb.AppendLine();
            //        sb.AppendLine("M62,5,5");
            //        sb.AppendLine("N");
            //        sb.AppendLine("q816");
            //        sb.AppendLine("Q609,24+0");
            //        sb.AppendLine("S2");
            //        sb.AppendLine("D8");
            //        sb.AppendLine("ZT");
            //        sb.AppendLine("TTh:m");
            //        sb.AppendLine("TDy2.mn.dd");
            //        sb.AppendLine("O");
            //        sb.AppendLine("A20,49,0,4,1,1,N," + "\"" + isim + "\"");
            //        sb.AppendLine("A20,126,0,4,1,1,N," + "\"" + dt + "\"");
            //        sb.AppendLine("A20,205,0,4,1,1,N," + "\"" + age + " / " + sex + "\"");
            //        sb.AppendLine("A197,300,0,4,1,1,N," + "\"" + "Materyal Protokol Numarasi" + "\"");
            //        sb.AppendLine("B118,361,0,3,3,9,101,N," + "\"" + kod + "\"");
            //        sb.AppendLine("A325,471,0,4,1,1,N," + "\"" + kod + "\"");
            //        sb.AppendLine("P1");
            //         */
            //        try
            //        {
            //            System.IO.Ports.SerialPort s = new System.IO.Ports.SerialPort("COM1", 9600, System.IO.Ports.Parity.None, 8);
            //            s.Handshake = System.IO.Ports.Handshake.None;
            //            s.Open();
            //            s.WriteTimeout = 5000;
            //            s.Write(sb.ToString());
            //            s.Close();
            //        }
            //        catch(Exception ex)
            //        {
            //            InfoBox.Alert("Etiket yazdırma sırasında hata oluştu\r\n" + ex.ToString(), MessageIconEnum.WarningMessage);
            //        }
        }

        public static void CheckUncompletedSpecialProcedures(Pathology pathology)
        {
            bool hasSpecialProceduresToBeCompleted = false;
            foreach (PathologySpecialProcedure specProc in pathology.PathologySpecialProcedures)
            {
                if (specProc.IsApplied == null || specProc.IsApplied == false)
                {
                    hasSpecialProceduresToBeCompleted = true;
                }
            }
            pathology.HasSpecialProcedures = hasSpecialProceduresToBeCompleted;
        }



        public string GetDoctorRegistrationNumber(string branchCode)
        {
            string drTescilNo = string.Empty;
            /* TODO ASLI GetDVO da hangi doktor gönderilecek kontrol et
            //Diğer(Nükleer Tıp) Branşı ise requestDoctor gönderilecek
            if (this.SubEpisode.SGKSEP != null && this.SubEpisode.SGKSEP.Brans != null && (this.SubEpisode.SGKSEP.Brans.ObjectID.ToString() == "8aee43e6-04e7-4a33-850b-848ddc1b513b"))
            {
                if (this.PathologyRequest is PathologyRequest && this.PathologyRequest != null)
                    drTescilNo = this.PathologyRequest.RequestDoctor.DiplomaRegisterNo;
            }
            else if(this.MasterAction is InternalProcedureRequest)
            {
                if(this.PathologyRequest != null && this.PathologyRequest.RequestDoctor != null)
                    drTescilNo = this.PathologyRequest.RequestDoctor.DiplomaRegisterNo;
            }
            else
            {
                if(this.ProcedureDoctor != null)
                    drTescilNo = this.ProcedureDoctor.DiplomaRegisterNo;
                else if(this.SpecialDoctor != null)
                    drTescilNo = this.SpecialDoctor.DiplomaRegisterNo;
                else if(this != null)
                {
                    if(this.PathologyRequest is Pathology)
                    {
                        if(((PathologyRequest)this.EpisodeAction).RequestDoctor != null)
                            drTescilNo = ((PathologyRequest)this.EpisodeAction).RequestDoctor.DiplomaRegisterNo;
                        if(((PathologyRequest)this.EpisodeAction).ProcedureDoctor != null)
                            drTescilNo = ((PathologyRequest)this.EpisodeAction).ProcedureDoctor.DiplomaRegisterNo;
                        if(((PathologyRequest)this.EpisodeAction).SpecialDoctor != null)
                            drTescilNo = ((PathologyRequest)this.EpisodeAction).SpecialDoctor.DiplomaRegisterNo;
                    }
                    else
                    {
                        if (this.ProcedureDoctor != null)
                            drTescilNo = this.ProcedureDoctor.DiplomaRegisterNo;
                    }
                }
            }
            
            if(string.IsNullOrEmpty(drTescilNo))
                drTescilNo = Common.GetDoctorRegisterNoByBranchCode(branchCode);
            */
            return drTescilNo;
        }

        protected override List<EpisodeAction.OldActionPropertyObject> OldActionPropertyList()
        {
            List<EpisodeAction.OldActionPropertyObject> propertyList = base.OldActionPropertyList();
            if (propertyList == null)
                propertyList = new List<EpisodeAction.OldActionPropertyObject>();
            //if(ReportMacroscopi != null)
            //    propertyList.Add(new EpisodeAction.OldActionPropertyObject("Makroskopi Raporu",Common.ReturnObjectAsString(ReportMacroscopi)));
            //if(ReportMicroscopi != null)
            //    propertyList.Add(new EpisodeAction.OldActionPropertyObject("Mikroskopi Raporu",Common.ReturnObjectAsString(ReportMicroscopi)));
            //if(ReportTissueProcedure != null)
            //    propertyList.Add(new EpisodeAction.OldActionPropertyObject("Doku İşlemi Raporu",Common.ReturnObjectAsString(ReportTissueProcedure)));
            //if(ReportAdditionalOperation != null)
            //    propertyList.Add(new EpisodeAction.OldActionPropertyObject("Ek İşlemler Raporu",Common.ReturnObjectAsString(ReportAdditionalOperation)));
            //if(ReportDiagnoseComment != null)
            //    propertyList.Add(new EpisodeAction.OldActionPropertyObject("Tanı Raporu",Common.ReturnObjectAsString(ReportDiagnoseComment)));
            return propertyList;
        }

        public void SetMyPerformedDate()// İşlemin yapıldığı tarihi set edecek şekilde override edilmeli
        {
            for (int i = 0; i < PathologyTestProcedures.Count; i++)
                PathologyTestProcedures[i].PerformedDate = Common.RecTime();
        }

        #endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(Pathology).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == Pathology.States.Approvement && toState == Pathology.States.Report)
                PreTransition_Approvement2Report();

        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(Pathology).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;


            if (fromState == Pathology.States.Procedure && toState == Pathology.States.Cancelled)
                PostTransition_Procedure2Cancelled();
            else if (fromState == Pathology.States.SentToApprovement && toState == Pathology.States.Approvement)
                PostTransition_SentToApprovement2Approvement();
            else if (fromState == Pathology.States.Approvement && toState == Pathology.States.SentToApprovement)
                PostTransition_Approvement2SentToApprovement();
            else if (fromState == Pathology.States.Approvement && toState == Pathology.States.Report)
                PostTransition_Approvement2Report();
            else if (fromState == Pathology.States.Procedure && toState == Pathology.States.SentToApprovement)
                PostTransition_Procedure2SentToApprovement();
            else if (fromState == Pathology.States.Procedure && toState == Pathology.States.Approvement)
                PostTransition_Procedure2Approvement();

        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(Pathology).Name)
                return;

            if (IsOldAction == true) //Aktarımdan gelen işlemler geri alınamaz
            {
                NoBackStateBack();
            }

            //Fatura edilmiş işlemler geri alınamaz
            if (CheckInvoice())
                NoBackStateBack();

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == Pathology.States.Procedure && toState == Pathology.States.Cancelled)
                UndoTransition_Procedure2Cancelled(transDef);
            else if (fromState == Pathology.States.SentToApprovement && toState == Pathology.States.Approvement)
                UndoTransition_SentToApprovement2Approvement(transDef);
            else if (fromState == Pathology.States.Approvement && toState == Pathology.States.SentToApprovement)
                UndoTransition_Approvement2SentToApprovement(transDef);
            else if (fromState == Pathology.States.Approvement && toState == Pathology.States.Report)
                UndoTransition_Approvement2Report(transDef);
            else if (fromState == Pathology.States.Procedure && toState == Pathology.States.SentToApprovement)
                UndoTransition_Procedure2SentToApprovement(transDef);
            else if (fromState == Pathology.States.Procedure && toState == Pathology.States.Approvement)
                UndoTransition_Procedure2Approvement(transDef);
        }

        private bool CheckInvoice()
        {
            for (int i = 0; i < PathologyTestProcedures.Count; i++)
            {
                if (PathologyTestProcedures[i].CurrentStateDefID != PathologyTestProcedure.States.Cancelled && !PathologyTestProcedures[i].IsAllowedToCancel())
                {
                    return true;
                }
            }
            return false;
        }

        protected void PostTransition_SentToApprovement2Approvement()
        {
            if (IsOldAction != true)
            {
                ApproveDate = TTObjectDefManager.ServerTime;
                for (int i = 0; i < PathologyTestProcedures.Count; i++)
                {
                    if (PathologyTestProcedures[i].CurrentStateDefID != PathologyTestProcedure.States.Cancelled)
                    {
                        PathologyTestProcedures[i].ProcedureDoctor = ProcedureDoctor;
                        PathologyTestProcedures[i].CurrentStateDefID = PathologyTestProcedure.States.Completed;
                        PathologyTestProcedures[i].PerformedDate = ApproveDate;
                    }
                }

                //this.SetMyPerformedDate();

                //E-Nabiz 201 Patoloji Veri Seti
                SendToENabiz s = new SendToENabiz();

                if (SubEpisode != null && SendToENabiz())
                {
                    for (int i = 0; i < PathologyTestProcedures.Count; i++)
                    {
                        if (PathologyTestProcedures[i].CurrentStateDefID != PathologyTestProcedure.States.Cancelled)
                        {
                            new SendToENabiz(ObjectContext, SubEpisode, PathologyTestProcedures[i].ObjectID, PathologyTestProcedures[0].ObjectDef.Name, "102", Common.RecTime());

                        }
                    }

                    new SendToENabiz(ObjectContext, SubEpisode, ObjectID, ObjectDef.Name, "201", Common.RecTime());
                }

                CompleteSMSForPathology();


            }

        }
        protected void CompleteSMSForPathology() //İşlem tamamlandığında flag set edilecek ve bir daha mesaj gönderilmeyecek
        {

            //SMS 
            string smsPathologyActive = TTObjectClasses.SystemParameter.GetParameterValue("SMSPATHOLOGYACTIVE", "FALSE");

            if (smsPathologyActive == "TRUE")
            {
                BindingList<EpisodeActionSMSInfo> smsInfo = EpisodeActionSMSInfo.GetEpisodeActionSmsInfo(ObjectContext, this.ObjectID);
                if (smsInfo.Count > 0)
                {
                    smsInfo.FirstOrDefault().CompletedFlag = true;
                }

            }
        }

        protected void CancelSMSForPathology() //İşlem iptal edildiğinde flag set edilecek ve bir daha mesaj gönderilmeyecek
        {

            //SMS 
            string smsPathologyActive = TTObjectClasses.SystemParameter.GetParameterValue("SMSPATHOLOGYACTIVE", "FALSE");

            if (smsPathologyActive == "TRUE")
            {
                BindingList<EpisodeActionSMSInfo> smsInfo = EpisodeActionSMSInfo.GetEpisodeActionSmsInfo(ObjectContext, this.ObjectID);
                if (smsInfo.Count > 0)
                {
                    smsInfo.FirstOrDefault().IsActiveFlag = false;
                }


            }
        }

        protected void PostTransition_Procedure2Approvement()
        {
            if (IsOldAction != true)
            {
                ApproveDate = TTObjectDefManager.ServerTime;
                for (int i = 0; i < PathologyTestProcedures.Count; i++)
                {
                    if (PathologyTestProcedures[i].CurrentStateDefID != PathologyTestProcedure.States.Cancelled)
                    {
                        PathologyTestProcedures[i].ProcedureDoctor = ProcedureDoctor;
                        PathologyTestProcedures[i].CurrentStateDefID = PathologyTestProcedure.States.Completed;
                        PathologyTestProcedures[i].PerformedDate = ApproveDate;
                    }
                }

                //this.SetMyPerformedDate();

                //E-Nabiz 201 Patoloji Veri Seti
                SendToENabiz s = new SendToENabiz();
                if (SubEpisode != null && SendToENabiz())
                {
                    for (int i = 0; i < PathologyTestProcedures.Count; i++)
                    {
                        if (PathologyTestProcedures[i].CurrentStateDefID != PathologyTestProcedure.States.Cancelled)
                        {
                            new SendToENabiz(ObjectContext, SubEpisode, PathologyTestProcedures[i].ObjectID, PathologyTestProcedures[0].ObjectDef.Name, "102", Common.RecTime());

                            //s.ENABIZSend102(this.PathologyTestProcedures[i].ObjectID.ToString());
                        }

                    }

                    new SendToENabiz(ObjectContext, SubEpisode, ObjectID, ObjectDef.Name, "201", Common.RecTime());
                }

                CompleteSMSForPathology();
            }

        }
        protected void PostTransition_Approvement2SentToApprovement()
        {
            ApproveDate = null;
            for (int i = 0; i < PathologyTestProcedures.Count; i++)
            {
                if (PathologyTestProcedures[i].CurrentStateDefID != PathologyTestProcedure.States.Cancelled)
                {
                    PathologyTestProcedures[i].CurrentStateDefID = PathologyTestProcedure.States.New;
                }
            }
        }
        protected void PostTransition_Procedure2SentToApprovement()
        {
            SendToApproveDate = TTObjectDefManager.ServerTime;
        }

        protected void UndoTransition_Approvement2Report(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Approvement   To State : Report
            #region UndoTransition_Approvement2Report

            ReportDate = null;

            #endregion UndoTransition_Approvement2Report
        }

        protected void UndoTransition_SentToApprovement2Approvement(TTObjectStateTransitionDef transitionDef)
        {

            ApproveDate = null;
            for (int i = 0; i < PathologyTestProcedures.Count; i++)
            {
                if (PathologyTestProcedures[i].CurrentStateDefID != PathologyTestProcedure.States.Cancelled)
                {
                    PathologyTestProcedures[i].ProcedureDoctor = null;
                    PathologyTestProcedures[i].CurrentStateDefID = PathologyTestProcedure.States.New;
                    PathologyTestProcedures[i].PerformedDate = null;
                }
            }

        }
        protected void UndoTransition_Procedure2SentToApprovement(TTObjectStateTransitionDef transitionDef)
        {
            SendToApproveDate = null;
        }

        protected void UndoTransition_Procedure2Approvement(TTObjectStateTransitionDef transitionDef)
        {
            ApproveDate = null;
            for (int i = 0; i < PathologyTestProcedures.Count; i++)
            {
                if (PathologyTestProcedures[i].CurrentStateDefID != PathologyTestProcedure.States.Cancelled)
                {
                    PathologyTestProcedures[i].ProcedureDoctor = null;
                    PathologyTestProcedures[i].CurrentStateDefID = PathologyTestProcedure.States.New;
                    PathologyTestProcedures[i].PerformedDate = null;
                }
            }
        }
        protected void UndoTransition_Approvement2SentToApprovement(TTObjectStateTransitionDef transitionDef)
        {
            NoBackStateBack(); //Onayı kaldırdan onaylandı adımına geri alınamaz.
        }

        protected void UndoTransition_Procedure2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            NoBackStateBack(); //Canceldan geri alınamaz.
        }

        override public Guid ProcedureRequestStartedStateDefID()
        {
            return (Guid)Pathology.States.Procedure;
        }

        protected void SendSmsForPathologyReport()//Rapor tamamlandığında hastaya mesaj gönderilir
        {
            string smsPathologyActive = TTObjectClasses.SystemParameter.GetParameterValue("SMSPATHOLOGYACTIVE", "FALSE");

            if (smsPathologyActive == "TRUE")
            {
                try
                {
                    UserMessage userMessage = new UserMessage();
                    string messageText = "Sayın hastamız, patoloji raporunuz hazırlanmıştır. Alo 182 den ya da www.mhrs.gov.tr" +
    " adresinden muayene olduğunuz polikliniğe randevu alarak muayene zamanınızı" +
    " belirleyebilirsiniz.Bu mesajın size ait olmadığını düşünüyorsanız lütfen dikkate almayınız.Sağlıklı" +
    " günler dileğiyle.";
                    List<Patient> patients = new List<Patient> { Episode.Patient };
                    userMessage.SendSMSPatient(patients, messageText, SMSTypeEnum.PathologyReportSMSForPatient);
                }
                catch { }
            }
        }

    }
}