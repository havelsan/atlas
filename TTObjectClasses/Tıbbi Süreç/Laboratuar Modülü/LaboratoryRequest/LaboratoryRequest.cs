
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
    /// Laboratuvar
    /// </summary>
    public partial class LaboratoryRequest : EpisodeActionWithDiagnosis, ITreatmentMaterialCollection
    {
        public partial class LaboratoryReportNQL_Class : TTReportNqlObject
        {
        }

        public partial class GetLastTwoLaboratoryRequests_Class : TTReportNqlObject
        {
        }

        public partial class GetLaboratoryRequestByBarcode_Class : TTReportNqlObject
        {
        }

        public partial class LaboratoryResultsTrackingScreenNQL_Class : TTReportNqlObject
        {
        }

        public partial class GetLaboratoryRequestByFilter_Class : TTReportNqlObject
        {
        }

        public partial class LaboratoryTripleTestInfoNQL_Class : TTReportNqlObject
        {
        }

        public partial class LaboratoryBinaryScanInfoNQL_Class : TTReportNqlObject
        {
        }



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
            if (Episode.EmergencyPatientStatusInfo != null)
                Episode.EmergencyPatientStatusInfo.PatientStatus = EmergencyPatientStatusInfoEnum.LabTestRequested;
            #endregion PostInsert
        }

        protected void PostTransition_Procedure2Cancelled()
        {
            // From State : Procedure   To State : Cancelled
            #region PostTransition_Procedure2Cancelled
            Guid savePoint = ObjectContext.BeginSavePoint();
            Cancel();
            try
            {
                var messageObjectContext = new TTObjectContext(false);
                BindingList<SKRSHastaMesajlari> _messageList = SKRSHastaMesajlari.GetHastaMesajlariByKodu(messageObjectContext, 2);
                NabizHBYSServis.HastaMesajGonderTalep input = new NabizHBYSServis.HastaMesajGonderTalep();
                input.SKRS_HASTA_MESAJLARI_KODU = 2;
                input.SKRS_HASTA_MESAJLARI_ADI = _messageList[0].ADI;
                input.HASTA_KIMLIK_NUMARASI = Convert.ToInt64(Episode.Patient.UniqueRefNo);
                input.MESAJ_TARIHI = DateTime.Now;
                input.MESAJ_DETAYI = TTUtils.CultureService.GetText("M26602", "Numune Reddedildi.");
                input.SYSTakipNo = SubEpisode.SYSTakipNo;
                SKRSKurumlar myTesisSKRSKurumlarDefinition = SKRSKurumlar.GetMyTesisSKRSKurumlarDefinition();
                if (myTesisSKRSKurumlarDefinition != null)
                {
                    input.KURUM_KODU = myTesisSKRSKurumlarDefinition.KODU.ToString(); //İşlemin yapıldığı kurum veya birim ÇKYS kodu alanıdır.
                    Guid siteIDGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", Guid.Empty.ToString()));
                    NabizHBYSServis.HastaMesajGonderCevap result = NabizHBYSServis.WebMethods.HastaMesajGonderSync(siteIDGuid, input);
                }
            }
            catch
            {
            }

            //if(this.LaboratoryProcedures.Count == 0)
            //{
            //    String message = SystemMessage.GetMessage(198);
            //    throw new TTUtils.TTException(message);
            //}
            //Cursor current = Cursor.Current;
            //Cursor.Current = Cursors.WaitCursor;
            //try
            //{
            //    string sysparam = TTObjectClasses.SystemParameter.GetParameterValue("LABINTEGRATED", null);
            //    if (sysparam == "TRUE")
            //    {
            //        this.CancelLab(); //Lab İstek İptal için.
            //    }
            //}
            //catch
            //{
            //    try
            //    {
            //        string sysparam = TTObjectClasses.SystemParameter.GetParameterValue("LABINTEGRATED", null);
            //        if (sysparam == "TRUE")
            //        {
            //            this.CancelLab(); //Lab İstek İptal için.
            //        }
            //    }
            //    catch
            //    {
            //        this.ObjectContext.RollbackSavePoint(savePoint);
            //        throw;
            //    }
            //}
            #endregion PostTransition_Procedure2Cancelled
        }

        protected void PostTransition_Procedure2Completed()
        {
            // From State : Procedure   To State : Completed
            #region PostTransition_Procedure2Completed
            //if (this.SourceObjectID != null && this.Episode.CreaterSite != null)
            //{
            //    Guid siteIDGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", Guid.Empty.ToString()));
            //    if (this.Episode.CreaterSite.ObjectID != siteIDGuid)
            //    {
            //        Guid savePoint = this.ObjectContext.BeginSavePoint();
            //        String messageString = "";
            //        try
            //        {
            //            List<DiagnosisGrid> diagnosisList = new List<DiagnosisGrid>();
            //            foreach (DiagnosisGrid dg in this.Diagnosis) // Geriye gönderilirken yalnız Consultasyonda konulan tanılar geriye gönderiliyor.
            //            {
            //                if (dg.ResponsibleUser != null)
            //                    diagnosisList.Add(dg.PrepareDiagnosisGridForRemoteMethod(true));
            //            }

            //            //Alt parametre gönderimi
            //            List<LaboratoryProcedure> procedures = new List<LaboratoryProcedure>();
            //            List<LaboratorySubProcedure> subProcedures = new List<LaboratorySubProcedure>();
            //            foreach (LaboratoryProcedure procedure in this.LaboratoryProcedures)
            //            {
            //                procedures.Add(procedure);
            //                if (procedure.LaboratorySubProcedures != null && procedure.LaboratorySubProcedures.Count > 0)
            //                {
            //                    foreach (LaboratorySubProcedure subprocedure in procedure.LaboratorySubProcedures)
            //                    {
            //                        subProcedures.Add(subprocedure);
            //                    }
            //                }
            //            }
            //        //
            //        //server-client method calismasi icin commentlendi
            //        //TTMessage message = LaboratoryRequest.RemoteMethods.ReturnLaboratoryToSourceHospital(this.Episode.CreaterSite.ObjectID, (LaboratoryRequest)this.PrepareEpisodeActionForRemoteMethod(true), procedures, subProcedures, diagnosisList);
            //        //messageString = message.MessageID.ToString();
            //        }
            //        catch (Exception ex)
            //        {
            //            throw;
            //        }
            //        finally
            //        {
            //            this.ObjectContext.RollbackSavePoint(savePoint);
            //        //this.MessageID = messageString;
            //        //this.ObjectContext.Save();
            //        }
            //    }
            //}

            if (Episode.EmergencyPatientStatusInfo != null)
                Episode.EmergencyPatientStatusInfo.PatientStatus = EmergencyPatientStatusInfoEnum.LabTestCompleted;
            /*
                if(this.SourceObjectID != null) //XXXXXXler Arsı Sevkden yaratıldı ise
                {
                    if(this.Episode.CreaterSite != null)
                    {
                        TTObjectContext objectContext = new TTObjectContext(false);
                        try
                        {
                            TTMessage message = LaboratoryRequest.RemoteMethods.ReturnLaboratoryToSourceHospital(this.Episode.CreaterSite.ObjectID, this);
                            objectContext.Save();
                        }
                        catch(Exception ex)
                        {
                            throw ex;
                        }
                        finally
                        {
                            objectContext.Dispose();
                        }
                    }
                }
                 */
            #endregion PostTransition_Procedure2Completed
        }

        protected void UndoTransition_Procedure2Completed(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Procedure   To State : Completed
            #region UndoTransition_Procedure2Completed
            if (Common.CurrentUser.IsSuperUser == false)
            {
                throw new Exception(TTUtils.CultureService.GetText("M26352", "Kullanıcınız işlemin geri alınmasında yetkili değildir.Lütfen bilgi işlem ile irtibata geçiniz!"));
            }
            #endregion UndoTransition_Procedure2Completed
        }

        protected void PostTransition_New2Procedure()
        {
            // From State : New   To State : Procedure
            #region PostTransition_New2Procedure
            bool sendToLab = false;
            //if ((this.MasterAction is HealthCommittee && (this.SubEpisode.PatientAdmission.AdmissionType == AdmissionTypeEnum.HealthCommitteeExamination || this.SubEpisode.PatientAdmission.AdmissionType == AdmissionTypeEnum.TemporaryHealthCommitteExamination))
            //  || this.PatientAdmission != null)
            //{ sendToLab = true; }
            //if (sendToLab)
            //{
            //    if (this.LaboratoryProcedures.Count == 0)
            //    {
            //        String message = SystemMessage.GetMessage(198);
            //        throw new TTUtils.TTException(message);
            //    }

            //    //TODO : Server-Client method calismasindan dolayi commentlendi. Daha sonra baska bir yontem dusunulecek.
            //    //System.Windows.Forms.Cursor current = System.Windows.Forms.Cursor.Current;
            //    //System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            //    try
            //    {
            //        string sysparam = TTObjectClasses.SystemParameter.GetParameterValue("LABINTEGRATED", null);
            //        if (sysparam == "TRUE")
            //            if (this.TransDef != null && this.TransDef.ToStateDefID == LaboratoryRequest.States.Procedure)
            //                LaboratoryRequest.SendToLabASync(this); //Entegrasyon için.
            //    }
            //    catch (Exception ex)
            //    {
            //        throw;
            //    }
            //finally
            //{
            //    System.Windows.Forms.Cursor.Current = current;
            //}
            //}
            #endregion PostTransition_New2Procedure
        }

        protected void UndoTransition_New2Procedure(TTObjectStateTransitionDef transitionDef)
        {
            // From State : New   To State : Procedure
            #region UndoTransition_New2Procedure
            if (Common.CurrentUser.IsSuperUser == false)
            {
                throw new Exception(TTUtils.CultureService.GetText("M26352", "Kullanıcınız işlemin geri alınmasında yetkili değildir.Lütfen bilgi işlem ile irtibata geçiniz!"));
            }
            #endregion UndoTransition_New2Procedure
        }
        #region LIS Laboratuvar Sonuc Sorgulama

        public static void AskResultsFromLISBySpecimenIDList(List<string> SpecimenIDList)
        {
            //Doktor ekranlarından hasta ornekno bazlı sorgulama yapan method
            foreach (string specimenID in SpecimenIDList)
            {
                bool ret = GetLabResultFromLIS(specimenID, null);
            }
        }

        //KULLANILMIYOR
        //public static void AskResultsFromLIS()
        //{
        //    TTObjectContext objectContext = new TTObjectContext(true);
        //    IBindingList specimenIDList = LaboratoryProcedure.GetLabProcedureGroupBySpecimenId(objectContext);
        //    foreach (LaboratoryProcedure.GetLabProcedureGroupBySpecimenId_Class labProcedure in specimenIDList)
        //    {
        //        bool ret = GetLabResultFromLIS(labProcedure.SpecimenId.ToString(), null);
        //    }
        //}

        public static void GetReadySpecimensFromLIS()
        {
            XXXXXXIHEWS.HazirOrnekler hazirOrnekler = new XXXXXXIHEWS.HazirOrnekler();
            hazirOrnekler = XXXXXXIHEWS.WebMethods.HazirOrnekleriGetirSync(Sites.SiteLocalHost);

            if (hazirOrnekler.HazirOrnekArr != null)
            {
                foreach (XXXXXXIHEWS.HazirOrnek hazirOrnek in hazirOrnekler.HazirOrnekArr)
                {
                    string tarih = hazirOrnek.Tarih;
                    string ornekNo = hazirOrnek.OrnekNo;

                    bool ret = GetLabResultFromLIS(ornekNo, null);

                }
            }
        }

        public static bool GetLabResultFromLIS(string SpecimenID, List<LaboratoryProcedure> laboratoryProcedureList)
        {
            //Numune No (SpecimenID) degerıne gore test sonuclarını sorgular, sonuclanmıs testlerı HBYS de update eder
            TTObjectContext objectContext = new TTObjectContext(false);
            TTObjectContext tempObjectContext = new TTObjectContext(false);

            try
            {
                XXXXXXIHEWS.ORL34 orl34 = new XXXXXXIHEWS.ORL34();
                XXXXXXIHEWS.OUL22 oul22 = new XXXXXXIHEWS.OUL22();
                XXXXXXIHEWS.MSH msh = new XXXXXXIHEWS.MSH();
                XXXXXXIHEWS.Patient patient = new XXXXXXIHEWS.Patient();
                List<XXXXXXIHEWS.OUL22Specimen> oul22SpecimenList = new List<XXXXXXIHEWS.OUL22Specimen>();
                XXXXXXIHEWS.PID pid = new XXXXXXIHEWS.PID();
                XXXXXXIHEWS.PV1 pv1 = new XXXXXXIHEWS.PV1();
                List<XXXXXXIHEWS.OULOrder> orderList = new List<XXXXXXIHEWS.OULOrder>();
                List<XXXXXXIHEWS.OBX> obxList = new List<XXXXXXIHEWS.OBX>();
                //MSH, mesaj basligi segmenti
                msh.EncodingCharacters = @"^~\&";
                msh.SendingApplication = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXSENDINGAPPLICATION", "ATLASHBYS_ATLAS"); //"HBYS_TEST";
                msh.SendingFacility = TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXSENDINGFACILITY", "ATLAS_FTR");  //"HBYS_TEST_HOSPITAL";
                msh.DateTimeOfMessage = DateTime.Now.ToString("yyyyMMddHHmmss");
                msh.ReceivingApplication = "XXXXXX";
                msh.ReceivingFacility = "XXXXXX_Kurumu";
                msh.MessageType = "OML^O33^OML_O33";
                Random random = new Random();
                msh.MessageControlID = random.Next(9999, 19999).ToString();
                //tetkik bilgileri ıle sorgulama yapilmasi icin 
                if (laboratoryProcedureList != null)
                {
                    foreach (LaboratoryProcedure labProc in laboratoryProcedureList)
                    {
                        //Order.OBR, tetkik bilgisi segmenti, SpecimenId ıle sorgulama yapıldıgından asagıdakı blok commentlendı.
                        XXXXXXIHEWS.OBR obr = new XXXXXXIHEWS.OBR();
                        obr.PlacerOrderNumber = labProc.ObjectID.ToString();
                        //obr.UniversalServiceID = labProc.ProcedureObject.SKRSLoincKodu.LOINCNUMARASI.ToString();
                        obr.UniversalServiceID = ((LaboratoryTestDefinition)labProc.ProcedureObject).FreeLOINCCode;
                        obr.OrderingProvider = labProc.Laboratory.RequestDoctor.DiplomaNo + "^" + labProc.Laboratory.RequestDoctor.Person.Surname + "^" + labProc.Laboratory.RequestDoctor.Person.Name + "^" + labProc.Laboratory.RequestDoctor.EmploymentRecordID + "^" + labProc.Laboratory.RequestDoctor.Person.UniqueRefNo + "^" + labProc.Laboratory.RequestDoctor.PhoneNumber; // "N-DOK165^KARAYEĞEN^AYTUĞ^^10000000000^";
                        //Order.ORC, istem bilgisi segmenti
                        XXXXXXIHEWS.ORC orc = new XXXXXXIHEWS.ORC();
                        orc.OrderControl = "NW";
                        orc.PlacerOrderNumber = obr.PlacerOrderNumber;
                        orc.DateTimeofTransaction = ((DateTime)labProc.RequestDate).ToString("yyyyMMddHHmmss");
                        //Order segmenti
                        XXXXXXIHEWS.OULOrder order = new XXXXXXIHEWS.OULOrder();
                        order.Orc = orc;
                        order.Obr = obr;
                        orderList.Add(order);
                    }
                }

                //Specimen.SPM, ornek bilgileri segmenti 
                XXXXXXIHEWS.SPM spm = new XXXXXXIHEWS.SPM();
                spm.SpecimenType = "SER";
                spm.SpecimenDesc = "Aciklama";
                spm.SpecimenID = SpecimenID; //laboratoryProcedure.SpecimenId.ToString();
                //Specimen segmenti
                XXXXXXIHEWS.Specimen specimen = new XXXXXXIHEWS.Specimen();
                specimen.Spm = spm;
                XXXXXXIHEWS.OUL22Specimen oul22Specimen = new XXXXXXIHEWS.OUL22Specimen();
                oul22Specimen.Specimen = specimen;
                oul22Specimen.OULOrderArr = orderList.ToArray();
                oul22SpecimenList.Add(oul22Specimen);
                oul22.Msh = msh;
                oul22.OUL22SpecimenArr = oul22SpecimenList.ToArray();
                orl34 = XXXXXXIHEWS.WebMethods.OUL22ToORL34Sync(Sites.SiteLocalHost, oul22);
                if (orl34.Msa.AcknowledgmentCode == "AA") //basarılı kaydedıldı.
                {
                    foreach (XXXXXXIHEWS.OML33Specimen OML33Specimen in orl34.OML33Specimen)
                    {
                        Dictionary<string, List<LaboratorySubProcedure>> PanelTestProceduresList = new Dictionary<string, List<LaboratorySubProcedure>>();
                        Dictionary<string, List<XXXXXXIHEWS.Order>> PanelTestListForLISAddedTests = new Dictionary<string, List<XXXXXXIHEWS.Order>>();
                        foreach (XXXXXXIHEWS.Order order in OML33Specimen.Order)
                        {
                            if (string.IsNullOrEmpty(order.Orc.PlacerOrderNumber) == false)
                            {
                                LaboratoryProcedure laboratoryProcedure = (LaboratoryProcedure)objectContext.GetObject(new Guid(order.Orc.PlacerOrderNumber), "LABORATORYPROCEDURE");
                                if (order.Obr.ResultStatus == "F" || order.Obr.ResultStatus == "C") //Sonuç Tamamlandı ya da Sonuc Degıstırıldı, TODO: Sonuc Degıstırıldı durumunda doktora mesaj gonderılecek

                                {
                                    if (order.Orc.ParentUniServiceID == null || order.Orc.ParentUniServiceID == "") //Panel test degilse 
                                    {
                                        //Kultur testleri icin birden cok OBX donebiliyor, onlarin sonuclari text olarak toparlanacak.
                                        string resultDetail = "";
                                        LaboratoryAbnormalFlagsEnum abnormalFlagValue;
                                        foreach (XXXXXXIHEWS.OBX obx in order.Obx)
                                        {
                                            string[] resultRefArr = obx.ReferencesRange.Split('^');
                                            string[] resultArr = obx.ObservationValue.Split('^');
                                            string abnormalFlagDesc = "";

                                            switch (obx.AbnormalFlags)
                                            {
                                                case "H":
                                                    abnormalFlagDesc = Common.GetDisplayTextOfDataTypeEnum(LaboratoryAbnormalFlagsEnum.H); //"Yüksek";
                                                    abnormalFlagValue = LaboratoryAbnormalFlagsEnum.H;
                                                    break;
                                                case "HH":
                                                    abnormalFlagDesc = Common.GetDisplayTextOfDataTypeEnum(LaboratoryAbnormalFlagsEnum.HH); //"Yüksek Panik";
                                                    abnormalFlagValue = LaboratoryAbnormalFlagsEnum.HH;
                                                    break;
                                                case "L":
                                                    abnormalFlagDesc = Common.GetDisplayTextOfDataTypeEnum(LaboratoryAbnormalFlagsEnum.L); //"Düşük";
                                                    abnormalFlagValue = LaboratoryAbnormalFlagsEnum.L;
                                                    break;
                                                case "LL":
                                                    abnormalFlagDesc = Common.GetDisplayTextOfDataTypeEnum(LaboratoryAbnormalFlagsEnum.LL); //"Düşük Panik";
                                                    abnormalFlagValue = LaboratoryAbnormalFlagsEnum.LL;
                                                    break;
                                                case "N":
                                                    abnormalFlagDesc = Common.GetDisplayTextOfDataTypeEnum(LaboratoryAbnormalFlagsEnum.N); //"Normal";
                                                    abnormalFlagValue = LaboratoryAbnormalFlagsEnum.N;
                                                    break;
                                                case "NULL":
                                                    abnormalFlagDesc = Common.GetDisplayTextOfDataTypeEnum(LaboratoryAbnormalFlagsEnum.NULL); //"Tanımsız";
                                                    abnormalFlagValue = LaboratoryAbnormalFlagsEnum.NULL;
                                                    break;
                                                case "S":
                                                    abnormalFlagDesc = Common.GetDisplayTextOfDataTypeEnum(LaboratoryAbnormalFlagsEnum.S); //"Duyarlı";
                                                    abnormalFlagValue = LaboratoryAbnormalFlagsEnum.S;
                                                    break;
                                                case "I":
                                                    abnormalFlagDesc = Common.GetDisplayTextOfDataTypeEnum(LaboratoryAbnormalFlagsEnum.I); //"Orta Duyarlı";
                                                    abnormalFlagValue = LaboratoryAbnormalFlagsEnum.I;
                                                    break;
                                                case "R":
                                                    abnormalFlagDesc = Common.GetDisplayTextOfDataTypeEnum(LaboratoryAbnormalFlagsEnum.R); //"Dirençli";
                                                    abnormalFlagValue = LaboratoryAbnormalFlagsEnum.R;
                                                    break;
                                                case "VS":
                                                    abnormalFlagDesc = Common.GetDisplayTextOfDataTypeEnum(LaboratoryAbnormalFlagsEnum.VS); //"Fazla Duyarlı";
                                                    abnormalFlagValue = LaboratoryAbnormalFlagsEnum.VS;
                                                    break;
                                                default:
                                                    abnormalFlagDesc = Common.GetDisplayTextOfDataTypeEnum(LaboratoryAbnormalFlagsEnum.TANIMSIZ); //"Tanımsız";
                                                    abnormalFlagValue = LaboratoryAbnormalFlagsEnum.TANIMSIZ;
                                                    break;
                                            }

                                            if (obx.SetIDOBX == "1") //tetkik istem ana sonuc bu obx te donuyor
                                            {
                                                if (resultRefArr.Length > 0)
                                                {
                                                    laboratoryProcedure.Reference = resultRefArr[0];
                                                }

                                                if (resultArr.Length > 0)
                                                {
                                                    if (resultArr[0].Length > 512)
                                                        laboratoryProcedure.Result = resultArr[0].Substring(0, 512);
                                                    else
                                                        laboratoryProcedure.Result = resultArr[0];

                                                    // resultdescription alanına da ObservationValue da gelen diğer alanlar toplanıp set ediliyor. 
                                                    //Result alanında değer olmayan ama açıklama olarak girilen durumlar için laboratoryprocedure.resultdescription alanı değer set edilecek
                                                    for (int i = 1; i < resultArr.Length; i++)
                                                    {
                                                        if (!string.IsNullOrEmpty(resultArr[i]))
                                                            resultDetail = resultDetail + " " + resultArr[i];
                                                    }
                                                }

                                                laboratoryProcedure.Unit = obx.Units;
                                                laboratoryProcedure.Panic = abnormalFlagValue;
                                                if (obx.DateOfAnalysis != "") //Onay tarihi
                                                    laboratoryProcedure.ApproveDate = DateTime.ParseExact(obx.DateOfAnalysis, "yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture);
                                                if (obx.DateOfObservation != "") //Calisma Tarihi, sonuc tarihi
                                                    laboratoryProcedure.ResultDate = DateTime.ParseExact(obx.DateOfObservation, "yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture);

                                                //Testi Onaylayan kullanici set ediliyor
                                                if (obx.ResponsibleObserver != "")
                                                {
                                                    string[] resUserArr = obx.ResponsibleObserver.Split('^');
                                                    if (resUserArr.Length > 0)
                                                    {
                                                        string resUserTCNo = resUserArr[0];
                                                        bool isTCNoOK = true;
                                                        if (resUserTCNo != null)
                                                        {
                                                            //Onaylayan kisi doktor ise TCNo su gelecek, teknisyen ise baska bir kod gelecek
                                                            if (resUserTCNo.Length == 11)
                                                            {
                                                                //resUserTCNo nun alphabetic karakter icermemesi gerekiyor, GetActiveResUserByUniqeRefNo NQL i exception a dusuyor
                                                                foreach (Char ch in resUserTCNo)
                                                                {
                                                                    if (!Char.IsDigit(ch))
                                                                    {
                                                                        isTCNoOK = false;
                                                                        break;
                                                                    }
                                                                }

                                                                if (isTCNoOK == true)
                                                                {
                                                                    BindingList<ResUser> userList = ResUser.GetActiveResUserByUniqeRefNo(objectContext, resUserTCNo);
                                                                    if (userList.Count > 0)
                                                                        laboratoryProcedure.ApproveUser = userList[0];
                                                                }
                                                            }
                                                        }
                                                    }
                                                }



                                                //Kan Grubu Testi

                                                if (laboratoryProcedure.ProcedureObject.SUTCode == "705140") // LaboratoryProcedure'ın ProcedureObject'i Kan Grubu Testi ise
                                                {
                                                    SKRSKanGrubu kanGrubu = null;
                                                    if (laboratoryProcedure.Result.Contains("AB") && laboratoryProcedure.Result.Contains("+"))
                                                    {
                                                        kanGrubu = SKRSKanGrubu.GetBySKRSKanGrubuKodu(objectContext, "3").FirstOrDefault();

                                                    }
                                                    else if (laboratoryProcedure.Result.Contains("AB") && laboratoryProcedure.Result.Contains("-"))
                                                    {
                                                        kanGrubu = SKRSKanGrubu.GetBySKRSKanGrubuKodu(objectContext, "8").FirstOrDefault();
                                                    }
                                                    else if (laboratoryProcedure.Result.Contains("A") && laboratoryProcedure.Result.Contains("+"))
                                                    {
                                                        kanGrubu = SKRSKanGrubu.GetBySKRSKanGrubuKodu(objectContext, "1").FirstOrDefault();
                                                    }
                                                    else if (laboratoryProcedure.Result.Contains("A") && laboratoryProcedure.Result.Contains("-"))
                                                    {
                                                        kanGrubu = SKRSKanGrubu.GetBySKRSKanGrubuKodu(objectContext, "6").FirstOrDefault();
                                                    }
                                                    else if (laboratoryProcedure.Result.Contains("B") && laboratoryProcedure.Result.Contains("+"))
                                                    {
                                                        kanGrubu = SKRSKanGrubu.GetBySKRSKanGrubuKodu(objectContext, "2").FirstOrDefault();
                                                    }
                                                    else if (laboratoryProcedure.Result.Contains("B") && laboratoryProcedure.Result.Contains("-"))
                                                    {
                                                        kanGrubu = SKRSKanGrubu.GetBySKRSKanGrubuKodu(objectContext, "7").FirstOrDefault();
                                                    }
                                                    else if (laboratoryProcedure.Result.Contains("0") && laboratoryProcedure.Result.Contains("+"))
                                                    {
                                                        kanGrubu = SKRSKanGrubu.GetBySKRSKanGrubuKodu(objectContext, "4").FirstOrDefault();
                                                    }
                                                    else if (laboratoryProcedure.Result.Contains("0") && laboratoryProcedure.Result.Contains("-"))
                                                    {
                                                        kanGrubu = SKRSKanGrubu.GetBySKRSKanGrubuKodu(objectContext, "5").FirstOrDefault();
                                                    }
                                                    laboratoryProcedure.Episode.Patient.BloodGroupType = kanGrubu;

                                                }
                                                //Numume Alma ve Numune Kabul asamasi kontrolu gecici olarak eklendi.
                                                if (laboratoryProcedure.CurrentStateDefID == LaboratoryProcedure.States.Procedure || laboratoryProcedure.CurrentStateDefID == LaboratoryProcedure.States.Approve || laboratoryProcedure.CurrentStateDefID == LaboratoryProcedure.States.SampleTaking || laboratoryProcedure.CurrentStateDefID == LaboratoryProcedure.States.SampleLaboratoryAccept)
                                                    laboratoryProcedure.CurrentStateDefID = LaboratoryProcedure.States.Completed;


                                            }
                                            else
                                            {
                                                //resultDetail = resultDetail + obx.ObservationID + ":" + obx.ObservationValue + " Referans Aralığı:" + obx.ReferencesRange + " Birim:" + obx.Units + " Duyarlılık: " + abnormalFlagDesc + "\n";
                                                resultDetail = resultDetail + obx.ObservationID + ": " + resultArr[0] + " Referans Aralığı:" + resultRefArr[0] + " Birim:" + obx.Units + " Duyarlılık: " + abnormalFlagDesc + "\n";

                                            }

                                            //Dusuk Panik ve Yuksek Panik deger donuc geldiyse, istem yapan kullaniciya mesaj gonderilecek
                                            if (abnormalFlagValue == LaboratoryAbnormalFlagsEnum.LL || abnormalFlagValue == LaboratoryAbnormalFlagsEnum.HH)
                                            {
                                                IList<ResUser> toUser = new List<ResUser>();
                                                toUser.Add(laboratoryProcedure.RequestedByUser);
                                                string msgBody = "";
                                                msgBody = msgBody + "<p>Tetkik Adı:" + laboratoryProcedure.ProcedureObject.Code + "-" + laboratoryProcedure.ProcedureObject.Name + "</p>";
                                                msgBody = msgBody + "<p>Sonuç: " + laboratoryProcedure.Result + " " + laboratoryProcedure.Unit + "</p>";
                                                msgBody = msgBody + "<p>Referans Aralığı:" + "(" + laboratoryProcedure.Reference + ")</p>";

                                                UserMessage.SendMessageInternalWithResUser(objectContext, toUser, "PANİK DEĞER TETKİK SONUCU", msgBody);

                                            }
                                        }

                                        string resultDescription = laboratoryProcedure.Result + "\n" + resultDetail;
                                        if (resultDescription.Length > 4000)
                                            laboratoryProcedure.ResultDescription = resultDescription.Substring(0, 4000);
                                        else
                                            laboratoryProcedure.ResultDescription = resultDescription;

                                        //Kultur testleri icin gelen sonuc aciklamasini Longreport alanında da sakla
                                        if (resultDetail != "")
                                            laboratoryProcedure.LongReport = resultDescription;
                                    }
                                    else
                                    {
                                        //Panel test ise altindaki testler dictionary de toplanacak ve LaboratoryProcedure e subprocedure olarak saklanacak. 
                                        string[] loincInfoArr = order.Obr.UniversalServiceID.Split('^');
                                        string LOINCCode = "";
                                        string resultDetail = "";
                                        if (loincInfoArr.Length > 0)
                                            LOINCCode = loincInfoArr[0];
                                        IBindingList procDefList = LaboratoryTestDefinition.GetByFreeLOINCCode(objectContext, LOINCCode); //order.Obr.UniversalServiceID
                                        if (procDefList.Count > 0)
                                        {
                                            LaboratorySubProcedure subProcedure = new LaboratorySubProcedure(tempObjectContext);
                                            subProcedure.ProcedureObject = (ProcedureDefinition)procDefList[0];
                                            subProcedure.MasterResource = laboratoryProcedure.MasterResource; //labReqTestDef.Departments[0].Department; //tanımdaki ilk bölümü alır
                                            subProcedure.FromResource = laboratoryProcedure.FromResource;

                                            LaboratoryAbnormalFlagsEnum abnormalFlagValue;
                                            switch (order.Obx[0].AbnormalFlags)
                                            {
                                                case "H":
                                                    abnormalFlagValue = LaboratoryAbnormalFlagsEnum.H;
                                                    break;
                                                case "HH":
                                                    abnormalFlagValue = LaboratoryAbnormalFlagsEnum.HH;
                                                    break;
                                                case "L":
                                                    abnormalFlagValue = LaboratoryAbnormalFlagsEnum.L;
                                                    break;
                                                case "LL":
                                                    abnormalFlagValue = LaboratoryAbnormalFlagsEnum.LL;
                                                    break;
                                                case "N":
                                                    abnormalFlagValue = LaboratoryAbnormalFlagsEnum.N;
                                                    break;
                                                case "NULL":
                                                    abnormalFlagValue = LaboratoryAbnormalFlagsEnum.NULL;
                                                    break;
                                                case "S":
                                                    abnormalFlagValue = LaboratoryAbnormalFlagsEnum.S;
                                                    break;
                                                case "I":
                                                    abnormalFlagValue = LaboratoryAbnormalFlagsEnum.I;
                                                    break;
                                                case "R":
                                                    abnormalFlagValue = LaboratoryAbnormalFlagsEnum.R;
                                                    break;
                                                case "VS":
                                                    abnormalFlagValue = LaboratoryAbnormalFlagsEnum.VS;
                                                    break;
                                                default:
                                                    abnormalFlagValue = LaboratoryAbnormalFlagsEnum.TANIMSIZ;
                                                    break;
                                            }

                                            string[] resultRefArr = order.Obx[0].ReferencesRange.Split('^');
                                            if (resultRefArr.Length > 0)
                                            {
                                                subProcedure.Reference = resultRefArr[0];
                                            }


                                            string[] resultArr = order.Obx[0].ObservationValue.Split('^');
                                            if (resultArr.Length > 0)
                                            {
                                                if (resultArr[0].Length > 512)
                                                    subProcedure.Result = resultArr[0].Substring(0, 512);
                                                else
                                                    subProcedure.Result = resultArr[0];
                                            }

                                            // resultdescription alanına da ObservationValue da gelen diğer alanlar toplanıp set ediliyor. 
                                            //Result alanında değer olmayan ama açıklama olarak girilen durumlar için laboratorsubyprocedure.resultdescription alanı değer set edilecek
                                            for (int i = 1; i < resultArr.Length; i++)
                                            {
                                                if (!string.IsNullOrEmpty(resultArr[i]))
                                                    resultDetail = resultDetail + " " + resultArr[i];
                                            }

                                            string resultDescription = subProcedure.Result + "\n" + resultDetail;
                                            if (resultDescription.Length > 4000)
                                                subProcedure.ResultDescription = resultDescription.Substring(0, 4000);
                                            else
                                                subProcedure.ResultDescription = resultDescription;

                                            subProcedure.Unit = order.Obx[0].Units;
                                            subProcedure.Panic = abnormalFlagValue;

                                            if (order.Obx[0].DateOfAnalysis != "")
                                                laboratoryProcedure.ApproveDate = DateTime.ParseExact(order.Obx[0].DateOfAnalysis, "yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture);
                                            if (order.Obx[0].DateOfObservation != "") //Calisma Tarihi, sonuc tarihi
                                                laboratoryProcedure.ResultDate = DateTime.ParseExact(order.Obx[0].DateOfObservation, "yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture);

                                            if (laboratoryProcedure.ApproveUser == null)
                                            {
                                                //Testi Onaylayan kullanici set ediliyor
                                                if (order.Obx[0].ResponsibleObserver != "")
                                                {
                                                    string[] resUserArr = order.Obx[0].ResponsibleObserver.Split('^');
                                                    if (resUserArr.Length > 0)
                                                    {
                                                        string resUserTCNo = resUserArr[0];
                                                        bool isTCNoOK = true;
                                                        if (resUserTCNo != null)
                                                        {
                                                            //Onaylayan kisi doktor ise TCNo su gelecek, teknisyen ise baska bir kod gelecek
                                                            if (resUserTCNo.Length == 11)
                                                            {
                                                                //resUserTCNo nun alphabetic karakter icermemesi gerekiyor, GetActiveResUserByUniqeRefNo NQL i exception a dusuyor
                                                                foreach (Char ch in resUserTCNo)
                                                                {
                                                                    if (!Char.IsDigit(ch))
                                                                    {
                                                                        isTCNoOK = false;
                                                                        break;
                                                                    }
                                                                }

                                                                if (isTCNoOK == true)
                                                                {
                                                                    BindingList<ResUser> userList = ResUser.GetActiveResUserByUniqeRefNo(objectContext, resUserTCNo);
                                                                    if (userList.Count > 0)
                                                                        laboratoryProcedure.ApproveUser = userList[0];
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }

                                            List<LaboratorySubProcedure> subTestList = new List<LaboratorySubProcedure>();
                                            if (PanelTestProceduresList.TryGetValue(order.Orc.PlacerOrderNumber, out subTestList) == false)
                                            {
                                                if (subTestList == null)
                                                    subTestList = new List<LaboratorySubProcedure>();
                                                subTestList.Add(subProcedure);
                                                PanelTestProceduresList.Add(order.Orc.PlacerOrderNumber, subTestList);
                                            }
                                            else
                                                subTestList.Add(subProcedure);
                                        }
                                        else
                                        {
                                            TTUtils.Logger.WriteError("Panel alt testinin ATLAS tarafında LOINC kodu bulunamadı. LOINC Kodu: " + LOINCCode + " ObjectID: " + order.Obr.PlacerOrderNumber);
                                        }
                                    }
                                }

                                if (order.Obr.ResultStatus == "R") //Calısıldı Onay Beklıyor
                                {
                                    if (laboratoryProcedure.CurrentStateDefID == LaboratoryProcedure.States.Procedure)
                                        laboratoryProcedure.CurrentStateDefID = LaboratoryProcedure.States.Approve;
                                }

                                if (order.Obr.ResultStatus == "X") //Reddedildi asmasında ise
                                {
                                    //Laboratuvarda, Numune Kabul, Onay Bekliyor veya Numune Alma asamalarindan Reddedildi asamasina gecis yapilabiliyor.
                                    if (laboratoryProcedure.CurrentStateDefID == LaboratoryProcedure.States.Procedure || laboratoryProcedure.CurrentStateDefID == LaboratoryProcedure.States.SampleLaboratoryAccept || laboratoryProcedure.CurrentStateDefID == LaboratoryProcedure.States.Approve || laboratoryProcedure.CurrentStateDefID == LaboratoryProcedure.States.SampleTaking)
                                    {
                                        //Red edilmis testlerin red nedeni sonuc alanindan aliniyor.
                                        foreach (XXXXXXIHEWS.OBX obx in order.Obx)
                                        {
                                            if (obx.SetIDOBX == "1") //tetkik istem ana sonuc bu obx te donuyor
                                            {
                                                string[] resultArr = obx.ObservationValue.Split('^');
                                                if (resultArr.Length > 0)
                                                {
                                                    if (resultArr[0] != null)
                                                    {
                                                        if (resultArr[0].Length > 512)
                                                            laboratoryProcedure.ReasonOfReject = resultArr[0].Substring(0, 512);
                                                        else
                                                            laboratoryProcedure.ReasonOfReject = resultArr[0];
                                                    }
                                                }
                                            }
                                        }
                                        laboratoryProcedure.CurrentStateDefID = LaboratoryProcedure.States.SampleReject;
                                    }
                                }
                                if (order.Obr.ResultStatus == "I" || order.Obr.ResultStatus == "T") //Calisiliyor veya Tekrar Calisiliyor asamasinda ise
                                {
                                    //Numune Kabul tarihi set ediliyor, XXXXXX ile yapilan gorsume sonucu SpecimenReceivedDateTime alaninin bos gelebilecegi bilgisi alindi. 31/01/2018
                                    //Kullanici kabul etme islemi yapmadan direkt cihaz a koyabilirmis o zaman cihazdan kabul etme tarihi geliyormus. 
                                    //Bos geliyorsa set edilmeyecek, dolu geldigi zaman set edilecek sekilde asagidaki kod guncellendi. 
                                    if (order.Obr.SpecimenReceivedDateTime != "")
                                    {
                                        string[] sampleAcceptInfoArr = order.Obr.SpecimenReceivedDateTime.Split('^');
                                        if (sampleAcceptInfoArr != null)
                                        {
                                            if (sampleAcceptInfoArr.Length > 0)
                                            {
                                                if (sampleAcceptInfoArr[0] != null && sampleAcceptInfoArr[0] != "")
                                                {
                                                    DateTime sampleAcceptDate;
                                                    if (DateTime.TryParseExact(sampleAcceptInfoArr[0], "yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out sampleAcceptDate) == true)
                                                    {
                                                        laboratoryProcedure.SampleAcceptionDate = sampleAcceptDate;
                                                        if (laboratoryProcedure.CurrentStateDefID == LaboratoryProcedure.States.SampleLaboratoryAccept)
                                                            laboratoryProcedure.CurrentStateDefID = LaboratoryProcedure.States.Procedure;
                                                    }
                                                }
                                            }
                                        }
                                    }

                                    //SampleAcceptionDate alani dolu geldiginde calismaya alindi olarak yorumlaniyor.  Asagidaki bolum yukaridaki if bloga tasindi.
                                    //TFS 48271 maddesi icin gelistirildi.
                                    //if (laboratoryProcedure.CurrentStateDefID == LaboratoryProcedure.States.SampleLaboratoryAccept)
                                    //    laboratoryProcedure.CurrentStateDefID = LaboratoryProcedure.States.Procedure;
                                }

                            }
                            else
                            {
                                //LIS tarafinda test eklenmis demek, Yeni LaboratoryProcedure yaratiliyor.
                                string[] loincInfoArr = order.Obr.UniversalServiceID.Split('^');
                                string LOINCCode = "";
                                if (loincInfoArr.Length > 0)
                                    LOINCCode = loincInfoArr[0];

                                //Eklenen tetkik panel test degilse sadece LaboratoryProcedure olusturulacak.
                                if (order.Orc.ParentUniServiceID == null || order.Orc.ParentUniServiceID == "")
                                {
                                    CreateLaboratoryProcedureAddedByLIS(LOINCCode, order, SpecimenID, objectContext);
                                }
                                else
                                {
                                    //Panel test ve altındaki testler dictionary de toplanıyor.
                                    string[] parentTestLoincInfoArr = order.Orc.ParentUniServiceID.Split('^');
                                    string parentTestLOINCCode = "";
                                    if (parentTestLoincInfoArr.Length > 0)
                                        parentTestLOINCCode = parentTestLoincInfoArr[0];


                                    List<XXXXXXIHEWS.Order> subTestOrderList = new List<XXXXXXIHEWS.Order>();
                                    if (PanelTestListForLISAddedTests.TryGetValue(parentTestLOINCCode, out subTestOrderList) == false)
                                    {
                                        if (subTestOrderList == null)
                                            subTestOrderList = new List<XXXXXXIHEWS.Order>();

                                        subTestOrderList.Add(order);
                                        PanelTestListForLISAddedTests.Add(parentTestLOINCCode, subTestOrderList);
                                    }
                                    else
                                        subTestOrderList.Add(order);
                                }
                            }
                        }

                        foreach (KeyValuePair<string, List<LaboratorySubProcedure>> panelTest in PanelTestProceduresList)
                        {
                            LaboratoryProcedure panelLabProcedure = (LaboratoryProcedure)objectContext.GetObject(new Guid(panelTest.Key), "LABORATORYPROCEDURE");
                            if (panelLabProcedure != null)
                            {
                                //TODO: Daha onceden set edilmis alt testleri varsa onlari silip yenilerini olustur. daha sonra update edilerek yapılabilir.
                                //su an objectcontext.save de hata verdıgı ıcın commentlendıö Mehmet Bey ler bakacak
                                //panelLabProcedure.ChildSubActionProcedure.DeleteChildren();

                                //foreach (LaboratorySubProcedure labSubProc in panelTest.Value)
                                //{
                                //    panelLabProcedure.LaboratorySubProcedures.Add(labSubProc);
                                //}

                                //alt tetkikler silinmedigi icin coklama sorununa neden oluyordu.
                                //test varsa update edilecek sekilde kod degistirildi.
                                //LaboratorySubProcedure hıc olusturulmamıssa ınsert edılecek, varsa sonuc degerlerı update edılecek

                                if (panelLabProcedure.LaboratorySubProcedures.Count == 0)
                                {
                                    foreach (LaboratorySubProcedure labSubProc in panelTest.Value)
                                    {
                                        LaboratorySubProcedure myLabSubProcedure = new LaboratorySubProcedure(objectContext);
                                        myLabSubProcedure.CreationDate = panelLabProcedure.CreationDate;
                                        myLabSubProcedure.ProcedureObject = (ProcedureDefinition)labSubProc.ProcedureObject;
                                        myLabSubProcedure.MasterResource = labSubProc.MasterResource; //labReqTestDef.Departments[0].Department; //tanımdaki ilk bölümü alır
                                        myLabSubProcedure.FromResource = labSubProc.FromResource;

                                        //Alt tetkiklerden ücretlenebilir olan testlerin de ücretlenmesi istendi.
                                        myLabSubProcedure.Eligible = true;

                                        myLabSubProcedure.EpisodeAction = panelLabProcedure.Laboratory;
                                        myLabSubProcedure.Reference = labSubProc.Reference;
                                        myLabSubProcedure.Result = labSubProc.Result;
                                        myLabSubProcedure.ResultDescription = labSubProc.ResultDescription;
                                        myLabSubProcedure.Unit = labSubProc.Unit;
                                        myLabSubProcedure.Panic = labSubProc.Panic;
                                        myLabSubProcedure.CurrentStateDefID = LaboratorySubProcedure.States.Completed;

                                        panelLabProcedure.LaboratorySubProcedures.Add(myLabSubProcedure);
                                    }
                                }

                                else
                                {
                                    foreach (LaboratorySubProcedure labSubProc in panelTest.Value)
                                    {
                                        foreach (LaboratorySubProcedure myLabSubProc in panelLabProcedure.LaboratorySubProcedures)
                                        {
                                            if (myLabSubProc.ProcedureObject.ObjectID.ToString() == labSubProc.ProcedureObject.ObjectID.ToString())
                                            {
                                                myLabSubProc.Reference = labSubProc.Reference;
                                                myLabSubProc.Result = labSubProc.Result;
                                                myLabSubProc.ResultDescription = labSubProc.ResultDescription;
                                                myLabSubProc.Unit = labSubProc.Unit;
                                                myLabSubProc.Panic = labSubProc.Panic;
                                                break;
                                            }
                                        }
                                    }
                                }

                                panelLabProcedure.CurrentStateDefID = LaboratoryProcedure.States.Completed;
                            }
                        }

                        foreach (KeyValuePair<string, List<XXXXXXIHEWS.Order>> panelTestLISAdded in PanelTestListForLISAddedTests)
                        {
                            CreateLaboratoryProcedureWithSubTestsAddedByLIS(panelTestLISAdded.Key, panelTestLISAdded.Value, SpecimenID, objectContext);
                        }



                    }

                    objectContext.Save();
                    tempObjectContext.Dispose();
                    return true;
                }
                else
                {
                    try
                    {
                        var msg = "XXXXXX OUL22ToORL34 methodunda hata oluştu. Örnek No: " + SpecimenID.ToString() + " Hata Kodu: " + orl34.Err.ApplicationErrorCode.ToString();
                        int msgCount;
                        if (dctMsg.TryGetValue(msg, out msgCount))
                        {
                            msgCount++;
                            if (msgCount <= 2)
                            {
                                dctMsg[msg] = msgCount;
                                msg = TTUtils.CultureService.GetText("M27089", "Tekrarlanan hata olduğundan bir daha loglanmayacak.") + msg;
                                TTUtils.Logger.WriteError(msg);
                            }
                        }
                        else
                        {
                            dctMsg[msg] = 1;
                            TTUtils.Logger.WriteError(msg);
                        }
                    }
                    catch (Exception ex)
                    {
                        TTUtils.Logger.WriteError("Loglama sırasında hata : " + ex.ToString());
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                TTUtils.Logger.WriteException("GetLabResultFromLIS methodunda hata oluştu.  Örnek No: " + SpecimenID.ToString() + " : ", ex);
                return false;
            }
        }

        public static void CreateLaboratoryProcedureWithSubTestsAddedByLIS(string LOINCCode, List<XXXXXXIHEWS.Order> subTestOrderList, string specimenID, TTObjectContext objectContextForLIS)
        {
            IBindingList procDefList = LaboratoryTestDefinition.GetByFreeLOINCCode(objectContextForLIS, LOINCCode);
            if (procDefList.Count > 0)
            {
                //Gelen ornek numarasina (specimenid) sahip bir LaboratoryProcedure bulunup, onun LabRequest ine eklenecek. 
                BindingList<LaboratoryProcedure> labProcedureList = LaboratoryProcedure.GetLabProcedureBySpecimenId(objectContextForLIS, Convert.ToInt32(specimenID));
                if (labProcedureList.Count > 0)
                {
                    //Aynı tetkigin tekrar eklenmemesini saglaniyor
                    bool labProcedureExists = false;
                    foreach (LaboratoryProcedure lp in labProcedureList)
                    {
                        if (lp.ProcedureObject.ObjectID.ToString() == ((ProcedureDefinition)procDefList[0]).ObjectID.ToString())
                        {
                            labProcedureExists = true;
                            break;
                        }
                    }

                    if (labProcedureExists == false)
                    {

                        LaboratoryRequest myLabRequest = (LaboratoryRequest)labProcedureList[0].EpisodeAction;
                        LaboratoryProcedure labProcedure = new LaboratoryProcedure(objectContextForLIS);
                        labProcedure.RequestedByUser = myLabRequest.RequestDoctor;
                        labProcedure.MasterResource = myLabRequest.MasterResource;
                        labProcedure.FromResource = myLabRequest.FromResource;
                        labProcedure.Episode = myLabRequest.Episode;
                        labProcedure.ProcedureObject = (ProcedureDefinition)procDefList[0];
                        labProcedure.EpisodeAction = myLabRequest;
                        labProcedure.SpecimenId = Convert.ToInt32(specimenID);
                        labProcedure.Amount = 1;
                        labProcedure.Eligible = true;


                        labProcedure.CurrentStateDefID = LaboratoryProcedure.States.SampleAccept;
                        objectContextForLIS.Update();
                        labProcedure.CurrentStateDefID = LaboratoryProcedure.States.SampleTaking;
                        objectContextForLIS.Update();
                        labProcedure.CurrentStateDefID = LaboratoryProcedure.States.Completed;
                        objectContextForLIS.Update();
                        myLabRequest.SubactionProcedures.Add((SubActionProcedure)labProcedure);


                        foreach (XXXXXXIHEWS.Order subTestOrder in subTestOrderList)
                        {
                            //Panel testin alt testleri eklenecek.

                            string[] subTestLoincInfoArr = subTestOrder.Obr.UniversalServiceID.Split('^');
                            string subTestLOINCCode = "";

                            if (subTestLoincInfoArr.Length > 0)
                                subTestLOINCCode = subTestLoincInfoArr[0];
                            IBindingList subProcDefList = LaboratoryTestDefinition.GetByFreeLOINCCode(objectContextForLIS, subTestLOINCCode);
                            if (subProcDefList.Count > 0)
                            {
                                LaboratorySubProcedure subProcedure = new LaboratorySubProcedure(objectContextForLIS);
                                subProcedure.ProcedureObject = (ProcedureDefinition)subProcDefList[0];
                                subProcedure.MasterResource = labProcedure.MasterResource;
                                subProcedure.FromResource = labProcedure.FromResource;

                                //Alt tetkiklerden ücretlenebilir olan testlerin de ücretlenmesi istendi.
                                subProcedure.Eligible = true;

                                string[] resultRefArr = subTestOrder.Obx[0].ReferencesRange.Split('^');
                                if (resultRefArr.Length > 0)
                                {
                                    subProcedure.Reference = resultRefArr[0];
                                }


                                string[] resultArr = subTestOrder.Obx[0].ObservationValue.Split('^');
                                if (resultArr.Length > 0)
                                {
                                    if (resultArr[0].Length > 512)
                                        subProcedure.Result = resultArr[0].Substring(0, 512);
                                    else
                                        subProcedure.Result = resultArr[0];
                                }

                                // resultdescription alanına da ObservationValue da gelen diğer alanlar toplanıp set ediliyor. 
                                //Result alanında değer olmayan ama açıklama olarak girilen durumlar için laboratorsubyprocedure.resultdescription alanı değer set edilecek
                                string resultDetail = "";
                                for (int i = 1; i < resultArr.Length; i++)
                                {
                                    if (!string.IsNullOrEmpty(resultArr[i]))
                                        resultDetail = resultDetail + " " + resultArr[i];
                                }

                                string resultDescription = subProcedure.Result + "\n" + resultDetail;
                                if (resultDescription.Length > 4000)
                                    subProcedure.ResultDescription = resultDescription.Substring(0, 4000);
                                else
                                    subProcedure.ResultDescription = resultDescription;

                                LaboratoryAbnormalFlagsEnum abnormalFlagValue;
                                switch (subTestOrder.Obx[0].AbnormalFlags)
                                {
                                    case "H":
                                        abnormalFlagValue = LaboratoryAbnormalFlagsEnum.H;
                                        break;
                                    case "HH":
                                        abnormalFlagValue = LaboratoryAbnormalFlagsEnum.HH;
                                        break;
                                    case "L":
                                        abnormalFlagValue = LaboratoryAbnormalFlagsEnum.L;
                                        break;
                                    case "LL":
                                        abnormalFlagValue = LaboratoryAbnormalFlagsEnum.LL;
                                        break;
                                    case "N":
                                        abnormalFlagValue = LaboratoryAbnormalFlagsEnum.N;
                                        break;
                                    case "NULL":
                                        abnormalFlagValue = LaboratoryAbnormalFlagsEnum.NULL;
                                        break;
                                    case "S":
                                        abnormalFlagValue = LaboratoryAbnormalFlagsEnum.S;
                                        break;
                                    case "I":
                                        abnormalFlagValue = LaboratoryAbnormalFlagsEnum.I;
                                        break;
                                    case "R":
                                        abnormalFlagValue = LaboratoryAbnormalFlagsEnum.R;
                                        break;
                                    case "VS":
                                        abnormalFlagValue = LaboratoryAbnormalFlagsEnum.VS;
                                        break;
                                    default:
                                        abnormalFlagValue = LaboratoryAbnormalFlagsEnum.TANIMSIZ;
                                        break;
                                }

                                subProcedure.Panic = abnormalFlagValue;
                                subProcedure.Unit = subTestOrder.Obx[0].Units;
                                subProcedure.CurrentStateDefID = LaboratorySubProcedure.States.Completed;

                                if (subTestOrder.Obx[0].DateOfAnalysis != "")
                                    labProcedure.ApproveDate = DateTime.ParseExact(subTestOrder.Obx[0].DateOfAnalysis, "yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture);
                                if (subTestOrder.Obx[0].DateOfObservation != "") //Calisma Tarihi, sonuc tarihi
                                    labProcedure.ResultDate = DateTime.ParseExact(subTestOrder.Obx[0].DateOfObservation, "yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture);

                                labProcedure.BarcodeId = (long)Convert.ToDouble(subTestOrder.Orc.PlacerGroupNumber);
                                labProcedure.RequestDate = labProcedure.ResultDate;
                                labProcedure.CreationDate = labProcedure.ResultDate;
                                labProcedure.PerformedDate = labProcedure.ResultDate;
                                labProcedure.ActionDate = labProcedure.ResultDate;
                                labProcedure.WorkListDate = labProcedure.ResultDate;


                                if (labProcedure.ApproveUser == null)
                                {
                                    //Testi Onaylayan kullanici set ediliyor
                                    if (subTestOrder.Obx[0].ResponsibleObserver != "")
                                    {
                                        string[] resUserArr = subTestOrder.Obx[0].ResponsibleObserver.Split('^');
                                        if (resUserArr.Length > 0)
                                        {
                                            string resUserTCNo = resUserArr[0];
                                            bool isTCNoOK = true;
                                            if (resUserTCNo != null)
                                            {
                                                //Onaylayan kisi doktor ise TCNo su gelecek, teknisyen ise baska bir kod gelecek
                                                if (resUserTCNo.Length == 11)
                                                {
                                                    //resUserTCNo nun alphabetic karakter icermemesi gerekiyor, GetActiveResUserByUniqeRefNo NQL i exception a dusuyor
                                                    foreach (Char ch in resUserTCNo)
                                                    {
                                                        if (!Char.IsDigit(ch))
                                                        {
                                                            isTCNoOK = false;
                                                            break;
                                                        }
                                                    }
                                                    if (isTCNoOK == true)
                                                    {
                                                        BindingList<ResUser> userList = ResUser.GetActiveResUserByUniqeRefNo(objectContextForLIS, resUserTCNo);
                                                        if (userList.Count > 0)
                                                            labProcedure.ApproveUser = userList[0];
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                labProcedure.LaboratorySubProcedures.Add(subProcedure);
                            }
                            else
                            {
                                TTUtils.Logger.WriteError("CreateLaboratoryProcedureWithSubTestsAddedByLIS methodunda, Panel alt testinin ATLAS tarafında LOINC kodu bulunamadı. LOINC Kodu: " + subTestLOINCCode);
                            }
                        }
                    }
                }
                else
                {
                    TTUtils.Logger.WriteError("CreateLaboratoryProcedureWithSubTestsAddedByLIS methodunda, LIS tarafından test ekleme yapıldığı kodda hata oluştu. Eklenen testin örnek numarasına ait HBYS de test bulunamadı. Örnek No: " + specimenID.ToString());
                }
            }
            else
            {
                TTUtils.Logger.WriteError("CreateLaboratoryProcedureWithSubTestsAddedByLIS methodunda, LIS tarafından test ekleme yapıldığı kodda hata oluştu. Eklenen testin LOINC Kodu HBYS de bulunamadı. LOINC Kodu: " + LOINCCode.ToString());
            }
        }

        public static void CreateLaboratoryProcedureAddedByLIS(string LOINCCode, XXXXXXIHEWS.Order pOrder, string specimenID, TTObjectContext objectContextForLIS)
        {
            IBindingList procDefList = LaboratoryTestDefinition.GetByFreeLOINCCode(objectContextForLIS, LOINCCode);
            if (procDefList.Count > 0)
            {
                //Gelen ornek numarasina (specimenid) sahip bir LaboratoryProcedure bulunup, onun LabRequest ine eklenecek. 
                BindingList<LaboratoryProcedure> labProcedureList = LaboratoryProcedure.GetLabProcedureBySpecimenId(objectContextForLIS, Convert.ToInt32(specimenID));
                if (labProcedureList.Count > 0)
                {
                    //Aynı tetkigin tekrar eklenmemesini saglaniyor
                    bool labProcedureExists = false;
                    foreach (LaboratoryProcedure lp in labProcedureList)
                    {
                        if (lp.ProcedureObject.ObjectID.ToString() == ((ProcedureDefinition)procDefList[0]).ObjectID.ToString())
                        {
                            labProcedureExists = true;
                            break;
                        }
                    }

                    if (labProcedureExists == false)
                    {

                        LaboratoryRequest myLabRequest = (LaboratoryRequest)labProcedureList[0].EpisodeAction;
                        LaboratoryProcedure labProcedure = new LaboratoryProcedure(objectContextForLIS);
                        labProcedure.RequestedByUser = myLabRequest.RequestDoctor;
                        labProcedure.MasterResource = myLabRequest.MasterResource;
                        labProcedure.FromResource = myLabRequest.FromResource;
                        labProcedure.Episode = myLabRequest.Episode;
                        labProcedure.ProcedureObject = (ProcedureDefinition)procDefList[0];
                        labProcedure.EpisodeAction = myLabRequest;
                        labProcedure.BarcodeId = (long)Convert.ToDouble(pOrder.Orc.PlacerGroupNumber);
                        labProcedure.SpecimenId = Convert.ToInt32(specimenID);
                        labProcedure.Amount = 1;
                        labProcedure.Eligible = true;




                        //Kultur testleri icin birden cok OBX donebiliyor, onlarin sonuclari text olarak toparlanacak.

                        string resultDetail = "";
                        LaboratoryAbnormalFlagsEnum abnormalFlagValue;
                        foreach (XXXXXXIHEWS.OBX obx in pOrder.Obx)
                        {
                            string[] resultRefArr = obx.ReferencesRange.Split('^');
                            string[] resultArr = obx.ObservationValue.Split('^');
                            string abnormalFlagDesc = "";

                            switch (obx.AbnormalFlags)
                            {
                                case "H":
                                    abnormalFlagDesc = Common.GetDisplayTextOfDataTypeEnum(LaboratoryAbnormalFlagsEnum.H); //"Yüksek";
                                    abnormalFlagValue = LaboratoryAbnormalFlagsEnum.H;
                                    break;
                                case "HH":
                                    abnormalFlagDesc = Common.GetDisplayTextOfDataTypeEnum(LaboratoryAbnormalFlagsEnum.HH); //"Yüksek Panik";
                                    abnormalFlagValue = LaboratoryAbnormalFlagsEnum.HH;
                                    break;
                                case "L":
                                    abnormalFlagDesc = Common.GetDisplayTextOfDataTypeEnum(LaboratoryAbnormalFlagsEnum.L); //"Düşük";
                                    abnormalFlagValue = LaboratoryAbnormalFlagsEnum.L;
                                    break;
                                case "LL":
                                    abnormalFlagDesc = Common.GetDisplayTextOfDataTypeEnum(LaboratoryAbnormalFlagsEnum.LL); //"Düşük Panik";
                                    abnormalFlagValue = LaboratoryAbnormalFlagsEnum.LL;
                                    break;
                                case "N":
                                    abnormalFlagDesc = Common.GetDisplayTextOfDataTypeEnum(LaboratoryAbnormalFlagsEnum.N); //"Normal";
                                    abnormalFlagValue = LaboratoryAbnormalFlagsEnum.N;
                                    break;
                                case "NULL":
                                    abnormalFlagDesc = Common.GetDisplayTextOfDataTypeEnum(LaboratoryAbnormalFlagsEnum.NULL); //"Tanımsız";
                                    abnormalFlagValue = LaboratoryAbnormalFlagsEnum.NULL;
                                    break;
                                case "S":
                                    abnormalFlagDesc = Common.GetDisplayTextOfDataTypeEnum(LaboratoryAbnormalFlagsEnum.S); //"Duyarlı";
                                    abnormalFlagValue = LaboratoryAbnormalFlagsEnum.S;
                                    break;
                                case "I":
                                    abnormalFlagDesc = Common.GetDisplayTextOfDataTypeEnum(LaboratoryAbnormalFlagsEnum.I); //"Orta Duyarlı";
                                    abnormalFlagValue = LaboratoryAbnormalFlagsEnum.I;
                                    break;
                                case "R":
                                    abnormalFlagDesc = Common.GetDisplayTextOfDataTypeEnum(LaboratoryAbnormalFlagsEnum.R); //"Dirençli";
                                    abnormalFlagValue = LaboratoryAbnormalFlagsEnum.R;
                                    break;
                                case "VS":
                                    abnormalFlagDesc = Common.GetDisplayTextOfDataTypeEnum(LaboratoryAbnormalFlagsEnum.VS); //"Fazla Duyarlı";
                                    abnormalFlagValue = LaboratoryAbnormalFlagsEnum.VS;
                                    break;
                                default:
                                    abnormalFlagDesc = Common.GetDisplayTextOfDataTypeEnum(LaboratoryAbnormalFlagsEnum.TANIMSIZ); //"Tanımsız";
                                    abnormalFlagValue = LaboratoryAbnormalFlagsEnum.TANIMSIZ;
                                    break;
                            }

                            if (obx.SetIDOBX == "1") //tetkik istem ana sonuc bu obx te donuyor
                            {
                                if (resultRefArr.Length > 0)
                                {
                                    labProcedure.Reference = resultRefArr[0];
                                }

                                if (resultArr.Length > 0)
                                {
                                    if (resultArr[0].Length > 512)
                                        labProcedure.Result = resultArr[0].Substring(0, 512);
                                    else
                                        labProcedure.Result = resultArr[0];
                                }

                                // resultdescription alanına da ObservationValue da gelen diğer alanlar toplanıp set ediliyor. 
                                //Result alanında değer olmayan ama açıklama olarak girilen durumlar için laboratoryprocedure.resultdescription alanı değer set edilecek
                                for (int i = 1; i < resultArr.Length; i++)
                                {
                                    if (!string.IsNullOrEmpty(resultArr[i]))
                                        resultDetail = resultDetail + " " + resultArr[i];
                                }

                                labProcedure.Unit = obx.Units;
                                labProcedure.Panic = abnormalFlagValue;
                                if (obx.DateOfAnalysis != "") //Onay tarihi
                                    labProcedure.ApproveDate = DateTime.ParseExact(obx.DateOfAnalysis, "yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture);
                                if (obx.DateOfObservation != "") //Calisma Tarihi, sonuc tarihi
                                    labProcedure.ResultDate = DateTime.ParseExact(obx.DateOfObservation, "yyyyMMddHHmmss", System.Globalization.CultureInfo.InvariantCulture);

                                //Testi Onaylayan kullanici set ediliyor
                                if (obx.ResponsibleObserver != "")
                                {
                                    string[] resUserArr = obx.ResponsibleObserver.Split('^');
                                    if (resUserArr.Length > 0)
                                    {
                                        string resUserTCNo = resUserArr[0];
                                        bool isTCNoOK = true;
                                        if (resUserTCNo != null)
                                        {
                                            //Onaylayan kisi doktor ise TCNo su gelecek, teknisyen ise baska bir kod gelecek
                                            if (resUserTCNo.Length == 11)
                                            {
                                                //resUserTCNo nun alphabetic karakter icermemesi gerekiyor, GetActiveResUserByUniqeRefNo NQL i exception a dusuyor
                                                foreach (Char ch in resUserTCNo)
                                                {
                                                    if (!Char.IsDigit(ch))
                                                    {
                                                        isTCNoOK = false;
                                                        break;
                                                    }
                                                }

                                                if (isTCNoOK == true)
                                                {
                                                    BindingList<ResUser> userList = ResUser.GetActiveResUserByUniqeRefNo(objectContextForLIS, resUserTCNo);
                                                    if (userList.Count > 0)
                                                        labProcedure.ApproveUser = userList[0];
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                resultDetail = resultDetail + obx.ObservationID + ": " + resultArr[0] + " Referans Aralığı:" + resultRefArr[0] + " Birim:" + obx.Units + " Duyarlılık: " + abnormalFlagDesc + "\n";
                            }

                            //Dusuk Panik ve Yuksek Panik deger donuc geldiyse, istem yapan kullaniciya mesaj gonderilecek
                            if (labProcedure.Panic == LaboratoryAbnormalFlagsEnum.LL || labProcedure.Panic == LaboratoryAbnormalFlagsEnum.HH)
                            {
                                IList<ResUser> toUser = new List<ResUser>();
                                toUser.Add(labProcedure.RequestedByUser);
                                string msgBody = "";
                                msgBody = msgBody + "<p>Tetkik Adı:" + labProcedure.ProcedureObject.Code + "-" + labProcedure.ProcedureObject.Name + "</p>";
                                msgBody = msgBody + "<p>Sonuç: " + labProcedure.Result + " " + labProcedure.Unit + "</p>";
                                msgBody = msgBody + "<p>Referans Aralığı:" + "(" + labProcedure.Reference + ")</p>";

                                UserMessage.SendMessageInternalWithResUser(objectContextForLIS, toUser, "PANİK DEĞER TETKİK SONUCU", msgBody);

                            }
                        }
                        string resultDescription = labProcedure.Result + "\n" + resultDetail;
                        if (resultDescription.Length > 2000)
                            labProcedure.ResultDescription = resultDescription.Substring(0, 2000);
                        else
                            labProcedure.ResultDescription = resultDescription;

                        //Kultur testleri icin gelen sonuc aciklamasini Longreport alanında da sakla
                        if (resultDetail != "")
                            labProcedure.LongReport = resultDescription;

                        labProcedure.RequestDate = labProcedure.ResultDate;
                        labProcedure.CreationDate = labProcedure.ResultDate;
                        labProcedure.PerformedDate = labProcedure.ResultDate;
                        labProcedure.ActionDate = labProcedure.ResultDate;
                        labProcedure.WorkListDate = labProcedure.ResultDate;


                        labProcedure.CurrentStateDefID = LaboratoryProcedure.States.SampleAccept;
                        objectContextForLIS.Update();
                        labProcedure.CurrentStateDefID = LaboratoryProcedure.States.SampleTaking;
                        objectContextForLIS.Update();
                        labProcedure.CurrentStateDefID = LaboratoryProcedure.States.Completed;
                        objectContextForLIS.Update();
                        myLabRequest.SubactionProcedures.Add((SubActionProcedure)labProcedure);
                    }
                }
                else
                {
                    TTUtils.Logger.WriteError("CreateLaboratoryProcedureAddedByLIS methodunda, LIS tarafından test ekleme yapıldığı kodda hata oluştu. Eklenen testin örnek numarasına ait HBYS de test bulunamadı. Örnek No: " + specimenID.ToString());
                }
            }
            else
            {
                TTUtils.Logger.WriteError("CreateLaboratoryProcedureAddedByLIS methodunda, LIS tarafından test ekleme yapıldığı kodda hata oluştu. Eklenen testin LOINC Kodu HBYS de bulunamadı. LOINC Kodu: " + LOINCCode.ToString());
            }




        }

        #endregion LIS Laboratuvar Sonuc Sorgulama
        static Dictionary<string, int> dctMsg = new Dictionary<string, int>();

        protected void PostTransition_New2RequestAcception()
        {
            #region PostTransition_New2RequestAcception
            //if (this.LaboratoryProcedures.Count == 0)
            //{
            //    String message = SystemMessage.GetMessage(198);
            //    throw new TTUtils.TTException(message);
            //}
            //try
            //{
            //    if (TTObjectClasses.SystemParameter.GetParameterValue("XXXXXXENTEGRATION", "FALSE") == "TRUE")
            //    {
            //        if (this.TransDef != null && this.TransDef.ToStateDefID == LaboratoryRequest.States.RequestAcception)
            //            LaboratoryRequest.SendToLabLIS(this);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            //bool sendToLab = false;
            //this.AccountOperationForPaidPatients();
            //if ((this.MasterAction is HealthCommittee && (this.SubEpisode.PatientAdmission.AdmissionType == AdmissionTypeEnum.HealthCommitteeExamination || this.SubEpisode.PatientAdmission.AdmissionType == AdmissionTypeEnum.TemporaryHealthCommitteExamination))
            //  || this.PatientAdmission != null)
            //{ sendToLab = true; }
            //if (sendToLab)
            //{
            //    if (this.LaboratoryProcedures.Count == 0)
            //    {
            //        String message = SystemMessage.GetMessage(198);
            //        throw new TTUtils.TTException(message);
            //    }
            //    //TODO : Server-Client method calismasindan dolayi commentlendi. Daha sonra baska bir yontem dusunulecek.
            //    //System.Windows.Forms.Cursor current = System.Windows.Forms.Cursor.Current;
            //    //System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
            //    try
            //    {
            //        string sysparam = TTObjectClasses.SystemParameter.GetParameterValue("LABINTEGRATED", null);
            //        if (sysparam == "TRUE")
            //            if (this.TransDef != null && this.TransDef.ToStateDefID == LaboratoryRequest.States.RequestAcception)
            //                LaboratoryRequest.SendToLabASync(this); //Entegrasyon için.
            //    }
            //    catch (Exception ex)
            //    {
            //        throw ex;
            //    }
            //    //finally
            //    //{
            //    //    System.Windows.Forms.Cursor.Current = current;
            //    //}
            //}
            #endregion PostTransition_New2RequestAcception
        }

        protected void UndoTransition_New2RequestAcception(TTObjectStateTransitionDef transitionDef)
        {
            // From State : New   To State : RequestAcception
            #region UndoTransition_New2RequestAcception
            if (Common.CurrentUser.IsSuperUser == false)
            {
                throw new Exception(TTUtils.CultureService.GetText("M26352", "Kullanıcınız işlemin geri alınmasında yetkili değildir.Lütfen bilgi işlem ile irtibata geçiniz!"));
            }
            #endregion UndoTransition_New2RequestAcception
        }

        protected void UndoTransition_RequestAcception2Procedure(TTObjectStateTransitionDef transitionDef)
        {
            // From State : RequestAcception   To State : Procedure
            #region UndoTransition_RequestAcception2Procedure
            if (Common.CurrentUser.IsSuperUser == false)
            {
                throw new Exception(TTUtils.CultureService.GetText("M26352", "Kullanıcınız işlemin geri alınmasında yetkili değildir.Lütfen bilgi işlem ile irtibata geçiniz!"));
            }
            #endregion UndoTransition_RequestAcception2Procedure
        }

        protected void PostTransition_RequestAcception2Completed()
        {
            // From State : RequestAcception   To State : Completed
            #region PostTransition_RequestAcception2Completed
            //foreach (LaboratoryProcedure labProcedure in this.LaboratoryProcedures)
            //            {
            //                if (labProcedure.CurrentStateDefID != LaboratoryProcedure.States.Cancelled && labProcedure.CurrentStateDefID != LaboratoryProcedure.States.SampleReject)
            //                {
            //                    if (this.RequestDate != null)
            //                        labProcedure.RequestDate = this.RequestDate;
            //                }
            //            }
            #endregion PostTransition_RequestAcception2Completed
        }

        protected void PostTransition_RequestAcception2Cancelled()
        {
            // From State : RequestAcception   To State : Cancelled
            #region PostTransition_RequestAcception2Cancelled
            //Guid savePoint = this.ObjectContext.BeginSavePoint();
            Cancel();

            //if(this.LaboratoryProcedures.Count == 0)
            //{
            //    String message = SystemMessage.GetMessage(198);
            //    throw new TTUtils.TTException(message);
            //}
            //Cursor current = Cursor.Current;
            //Cursor.Current = Cursors.WaitCursor;

            //try
            //{
            //    string sysparam = TTObjectClasses.SystemParameter.GetParameterValue("LABINTEGRATED", null);
            //    if (sysparam == "TRUE")
            //    {
            //        this.CancelLab(); //Lab İstek İptal için.
            //    }
            //}
            //catch
            //{
            //    try
            //    {
            //        string sysparam = TTObjectClasses.SystemParameter.GetParameterValue("LABINTEGRATED", null);
            //        if (sysparam == "TRUE")
            //        {
            //            this.CancelLab(); //Lab İstek İptal için.
            //        }
            //    }
            //    catch
            //    {
            //        this.ObjectContext.RollbackSavePoint(savePoint);
            //        throw;
            //    }
            //}
            #endregion PostTransition_RequestAcception2Cancelled
        }

        #region Methods
        public bool triggeredByTheWebService = true;
        public LaboratoryRequest(TTObjectContext objectContext, EpisodeAction episodeAction) : this(objectContext)
        {
            ActionDate = Common.RecTime();
            FromResource = episodeAction.MasterResource;
            CurrentStateDefID = LaboratoryRequest.States.New;
            Episode = episodeAction.Episode;
            ProcedureSpeciality = episodeAction.ProcedureSpeciality;
            MasterAction = episodeAction;
        }

        public LaboratoryRequest(TTObjectContext objectContext, SubactionProcedureFlowable subactionProcedureFlowable) : this(objectContext)
        {
            ActionDate = Common.RecTime();
            FromResource = subactionProcedureFlowable.MasterResource;
            CurrentStateDefID = LaboratoryRequest.States.New;
            Episode = subactionProcedureFlowable.Episode;
            ProcedureSpeciality = subactionProcedureFlowable.ProcedureSpeciality;
            //this.MasterAction = subactionProcedureFlowable;
        }

        /*
        public IList GetLaboratoryTabs()
        {
            IList LabTabs = LaboratoryRequestFormTabDefinition.GetLabTabs(ObjectContext);
            return LabTabs;
        }
         */
        public override ActionTypeEnum ActionType
        {
            get
            {
                return ActionTypeEnum.LaboratoryRequest;
            }
        }

        #region GetTestFromLaboratoryLocation Method (Not Used)
        /*
        public IList GetTestFromLaboratoryLocation(LaboratoryRequestFormTabDefinition Tab)
        {
            IList LabLocations = LaboratoryLocation.GetByTab(ObjectContext,Tab.ObjectID.ToString()  );

            //ObjectContext.QueryObjects("LaboratoryLocation", " TAB = " + ConnectionManager.GuidToString(Tab.ObjectID) + " ");
            return LabLocations;
        }
         */
        #endregion
        public LaboratoryRequest(TTObjectContext objectContext, EpisodeAction episodeAction, TTObjectClasses.ResSection masterResource) : this(objectContext)
        {
            CurrentStateDefID = LaboratoryRequest.States.New;
            ActionDate = Common.RecTime();
            MasterAction = episodeAction;
            MasterResource = masterResource;
            FromResource = episodeAction.MasterResource;
            Episode = episodeAction.Episode;
        }

        public LaboratoryRequest(TTObjectContext objectContext, SubactionProcedureFlowable subactionProcedureFlowable, TTObjectClasses.ResSection masterResource) : this(objectContext)
        {
            CurrentStateDefID = LaboratoryRequest.States.New;
            ActionDate = Common.RecTime();
            //this.MasterAction = subactionProcedureFlowable;
            MasterResource = masterResource;
            FromResource = subactionProcedureFlowable.MasterResource;
            Episode = subactionProcedureFlowable.Episode;
        }

        #region SplitWithDepartmentsOfLaboratoryProcedures Method (Not Used)
        /*
        private void SplitWithDepartmentsOfLaboratoryProcedures()
        {
            int sTCount=0;
            ArrayList requestedProceduresArray = new ArrayList();
            //RequestedProcedures da girilen her bir satırdaki departmentlar bir ArrayListe doldurulur(bir departement yalnızbir kez eklenir)
            foreach (LaboratoryRequestProcedure reqProc in this.RequestedProcedures)
            {
                if (reqProc.ProcedureObject != null)
                {
                    if (requestedProceduresArray.Contains(reqProc.ProcedureDepartment)==false)
                    {
                        requestedProceduresArray.Add(reqProc.ProcedureDepartment);
                    }
                }
            }
            sTCount = requestedProceduresArray.Count;
            // Eğer yalnızca bir tip Department var ise yeni LaboratoryRequest fire edilmesine gerek yok.
            if (sTCount>1)
            {
                sTCount--;
                //Array liste doldurulan birimlerin her biri için bir laboratuvar istek fire edilir içinde dönülür.
                for (int k = 0; k <= sTCount; k++)
                {
                    LaboratoryRequest newLaboratoryRequest = new LaboratoryRequest(this.ObjectContext,this,(TTObjectClasses.ResLaboratoryDepartment)requestedProceduresArray[k]);
                    //RequestedProcedure fire edilen laboratubvar ıstek e atanır.
                    foreach (LaboratoryRequestProcedure reqProc in this.RequestedProcedures)
                    {
                        if (reqProc.ProcedureDepartment == (TTObjectClasses.ResLaboratoryDepartment)requestedProceduresArray[k])
                        {
                            LaboratoryProcedure newLabProcedure = new LaboratoryProcedure(this.ObjectContext,(LaboratoryRequestProcedure)reqProc);
                            newLabProcedure.MasterResource = reqProc.ProcedureDepartment;
                            newLabProcedure.CurrentStateDefID = LaboratoryProcedure.States.Procedure;
                            newLaboratoryRequest.LaboratoryProcedures.Add(newLabProcedure);
                        }
                    }
                }
                this.Cancel();
            }
            else
            {
                //sadece 1 department varsa LaboratorRequest ın masterresource u tetkıgın calısılcagı bolum olarak set edılecek
                foreach (LaboratoryRequestProcedure reqProc in this.RequestedProcedures)
                {
                    LaboratoryProcedure newLabProcedure = new LaboratoryProcedure(this.ObjectContext,(LaboratoryRequestProcedure)reqProc);
                    newLabProcedure.MasterResource = reqProc.ProcedureDepartment;
                    newLabProcedure.CurrentStateDefID = LaboratoryProcedure.States.Procedure;
                    this.LaboratoryProcedures.Add(newLabProcedure);
                }
                this.MasterResource = (TTObjectClasses.ResSection)requestedProceduresArray[0];
            }
        }
         */
        #endregion
        /// <summary>
        /// Laboratuvara gönderilecek nesnelerin oluşturulmuş örneklerinin gönderilmesini sağlar
        /// </summary>
        public void SendToLab()
        {
            LaboratoryRequest.HastaBilgileri hastaBilgileri = new LaboratoryRequest.HastaBilgileri();
            LaboratoryRequest.GelisBilgileri gelisBilgileri = new LaboratoryRequest.GelisBilgileri();
            List<LaboratoryRequest.IstekBilgileri> listIstekBilgileri = new List<LaboratoryRequest.IstekBilgileri>();
            Patient p = Episode.Patient;
            CreateHastaBilgileri(ref hastaBilgileri);
            CreateGelisBilgileri(ref gelisBilgileri);
            listIstekBilgileri = CreateIstekBilgileri();
            if (listIstekBilgileri.Count == 0)
                return;
            try
            {
                TTMessageFactory.SyncCall(Sites.SiteLocalHost, "LATepe", "Main", TTUtils.CultureService.GetText("M17386", "Kaydet"), hastaBilgileri, gelisBilgileri, listIstekBilgileri);
            }
            catch (Exception ex)
            {
                throw;
                //TTVisual.InfoBox.S how("Tetkik İsteği Laboratuvara gönderilemedi. Tekrar deneyiniz.",MessageIconEnum.ErrorMessage);
            }
        }

        [TTStorageManager.Attributes.TTRequiredRoles(TTRoleNames.Laboratuvar_Islemde_Kullanilmiyor, TTRoleNames.Laboratuvar_R_Kullanilmiyor, TTRoleNames.Laboratuvar_Islemde_R__Kullanilmiyor, TTRoleNames.Laboratuvar_Manuel_Sonuc_Girme, TTRoleNames.Laboratuvar_Istek_Kabul, TTRoleNames.Laboratuvar_Iptal_Kullanilmiyor)]
        /// <summary>
        /// Laboratuvara gönderilecek nesnelerin oluşturulmuş örneklerinin gönderilmesini sağlar
        /// </summary>
        public static Guid SendToLabASync(LaboratoryRequest laboratoryRequest)
        {
            LaboratoryRequest.HastaBilgileri hastaBilgileri = new LaboratoryRequest.HastaBilgileri();
            LaboratoryRequest.GelisBilgileri gelisBilgileri = new LaboratoryRequest.GelisBilgileri();
            List<LaboratoryRequest.IstekBilgileri> listIstekBilgileri = new List<LaboratoryRequest.IstekBilgileri>();
            Patient p = laboratoryRequest.Episode.Patient;
            laboratoryRequest.CreateHastaBilgileri(ref hastaBilgileri);
            laboratoryRequest.CreateGelisBilgileri(ref gelisBilgileri);
            listIstekBilgileri = laboratoryRequest.CreateIstekBilgileri();
            if (listIstekBilgileri.Count == 0 || gelisBilgileri.ActionNo == 0)
                return new Guid("{00000000-0000-0000-0000-000000000000}");
            try
            {
                TTMessage message = TTMessageFactory.ASyncCall(Sites.SiteLocalHost, TTMessagePriorityEnum.HighPriority, "LATepe", "Main", TTUtils.CultureService.GetText("M17386", "Kaydet"), null, hastaBilgileri, gelisBilgileri, listIstekBilgileri);
                return message.MessageID;
            }
            catch (Exception ex)
            {
                throw;
                //TTVisual.InfoBox.S how("Tetkik İsteği Laboratuvara gönderilemedi. Tekrar deneyiniz.",MessageIconEnum.ErrorMessage);
            }
        }

        public void CancelLab()
        {
            LaboratoryRequest.HastaBilgileri hastaBilgileri = new LaboratoryRequest.HastaBilgileri();
            LaboratoryRequest.GelisBilgileri gelisBilgileri = new LaboratoryRequest.GelisBilgileri();
            List<LaboratoryRequest.IstekBilgileri> listIstekBilgileri = new List<LaboratoryRequest.IstekBilgileri>();
            Patient p = Episode.Patient;
            CreateHastaBilgileri(ref hastaBilgileri);
            CreateGelisBilgileri(ref gelisBilgileri);
            listIstekBilgileri = CreateIstekBilgileri();
            try
            {
                TTMessageFactory.SyncCall(Sites.SiteLocalHost, "LATepe", "Main", TTUtils.CultureService.GetText("M25991", "Iptal"), listIstekBilgileri, gelisBilgileri);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static void RollbackCancelLabSubProcedure(LaboratorySubProcedure labProcedure)
        {
            try
            {
                TTMessageFactory.SyncCall(Sites.SiteLocalHost, "LATepe", "Main", "RollbackIptalSubAction", labProcedure.ObjectID);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static void CancelLabSubProcedure(LaboratorySubProcedure labProcedure)
        {
            try
            {
                TTMessageFactory.SyncCall(Sites.SiteLocalHost, "LATepe", "Main", "IptalSubAction", labProcedure.ObjectID);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static void RollbackCancelLabProcedure(LaboratoryProcedure labProcedure)
        {
            try
            {
                TTMessageFactory.SyncCall(Sites.SiteLocalHost, "LATepe", "Main", "RollbackIptalSubAction", labProcedure.ObjectID);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static void CancelLabProcedure(LaboratoryProcedure labProcedure)
        {
            //GelisBilgileri gelisBilgileri = new GelisBilgileri();
            //CreateGelisBilgileri(ref gelisBilgileri);
            //List<IstekBilgileri> listIstekBilgileri = new List<IstekBilgileri>();
            //IstekBilgileri istekBilgileri = new IstekBilgileri();
            //istekBilgileri.SubActionID = labProcedure.ObjectID;
            //listIstekBilgileri = CreateIstekBilgisi(ref istekBilgileri); // İstekBilgileri list şeklinde olacakmış
            //try
            //{
            //    TTMessageFactory.SyncCall(Sites.SiteLocalHost, "LATepe", "Main", "Iptal", listIstekBilgileri, gelisBilgileri);
            //}
            //catch (Exception ex)
            //{
            //    throw;
            //}
            try
            {
                TTMessageFactory.SyncCall(Sites.SiteLocalHost, "LATepe", "Main", "IptalSubAction", labProcedure.ObjectID);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// İstek nesnesinin ilgili alanlarını doldurur.
        /// </summary>
        /// <returns></returns>
        private List<LaboratoryRequest.IstekBilgileri> CreateIstekBilgisi(ref LaboratoryRequest.IstekBilgileri i)
        {
            List<LaboratoryRequest.IstekBilgileri> istekler = new List<LaboratoryRequest.IstekBilgileri>();
            LaboratoryProcedure labProcedure = (LaboratoryProcedure)ObjectContext.GetObject(i.SubActionID, "LaboratoryProcedure");
            i.SubActionID = labProcedure.ObjectID;
            i.ActionID = labProcedure.EpisodeAction.ObjectID;
            int j = labProcedure.MasterResource.Name.IndexOf("KAN BANKASI");
            if (j < 0)
                i.KB = false;
            else
                i.KB = true;
            foreach (LaboratorySubProcedure subProcedure in labProcedure.LaboratorySubProcedures)
            {
                LaboratoryRequest.IstekBilgileri s = new LaboratoryRequest.IstekBilgileri();
                s.SubActionID = subProcedure.ObjectID;
                s.ActionID = subProcedure.EpisodeAction.ObjectID;
                s.TestID = subProcedure.ProcedureObject.ObjectID;
                s.MasterTestID = labProcedure.ProcedureObject.ObjectID;
                s.LabID = labProcedure.MasterResource.ObjectID.ToString();
                s.LabAdi = labProcedure.MasterResource.Name;
                s.KisaAdi = subProcedure.ProcedureObject.Code;
                s.Adi = subProcedure.ProcedureObject.Name;
                i.OdemeFlag = !((SubactionProcedureFlowable)subProcedure).Paid();
                istekler.Add(s);
            }

            i.TestID = labProcedure.ProcedureObject.ObjectID;
            i.KisaAdi = labProcedure.ProcedureObject.Code;
            i.Adi = labProcedure.ProcedureObject.Name;
            i.LabID = labProcedure.MasterResource.ObjectID.ToString();
            i.LabAdi = labProcedure.MasterResource.Name;
            i.OdemeFlag = !((SubactionProcedureFlowable)labProcedure).Paid();
            istekler.Add(i);
            return istekler;
        }

        /// <summary>
        /// Hasta bilgileri nesnesinin ilgili alanlarını doldurur
        /// </summary>
        /// <param name = "h"></param>
        private void CreateHastaBilgileri(ref LaboratoryRequest.HastaBilgileri h)
        {
            try
            {
                Patient p = Episode.Patient;
                h.ID = p.ObjectID;
                if (p.ID.Value.HasValue)
                    h.PatientID = p.ID.Value.ToString();
                if (p.UniqueRefNo.HasValue)
                    h.TCKimlikNo = p.ForeignUniqueRefNo.Value.ToString();

                h.Adi = p.Name.Replace("'", " ");
                h.Soyadi = p.Surname.Replace("'", " ");
                //if (p.Sex != null)
                //    h.Cinsiyeti = p.Sex.ADI;
                if (p.BirthDate.HasValue)
                    h.DogumTarihi = p.BirthDate.Value;
                if (p.BirthPlace != null)
                    h.DogumYeri = p.BirthPlace;
                h.BabaAdi = p.FatherName.Replace("'", " ");
                if (p.MotherName != null)
                    h.AnneAdi = p.MotherName.Replace("'", " ");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Geliş bilgilerinin ilgili alanlarını doldurur.
        /// </summary>
        /// <param name = "g"></param>
        private void CreateGelisBilgileri(ref LaboratoryRequest.GelisBilgileri g)
        {
            try
            {
                Patient p = Episode.Patient;
                g.ActionID = ObjectID;
                g.EpisodeID = Episode.ObjectID;
                g.PatientID = p.ObjectID;
                g.ActionNo = ID.Value.HasValue == false ? 0 : (int)ID.Value;
                //if(this.RequestDate.HasValue && this.IsSpecialTemplate)
                //    g.IstekTarihi = Common.RecTime();
                //else if(this.RequestDate.HasValue)
                //    g.IstekTarihi = this.RequestDate.Value;
                g.IstekTarihi = Common.RecTime();
                int j = MasterResource.Name.IndexOf("KAN BANKASI");
                if (j < 0)
                    g.KanBank = false;
                else
                    g.KanBank = true;
                if (WorkListDate.HasValue)
                    g.CalismaTarihi = WorkListDate.Value;
                if (RequestDoctor != null)
                {
                    g.DoktorID = RequestDoctor.ObjectID;
                    g.DoktorAdi = RequestDoctor.Name == null ? "" : RequestDoctor.Name;
                }

                g.BirimID = FromResource.ObjectID;
                g.BirimAdi = FromResource.Name;
                //g.HastaKuvvetiID = (int)p.ForcesCommand.Code;
                //g.HastaKuvveti = p.ForcesCommand.Name;
                string preDiagnosis = null;
                foreach (DiagnosisGrid dig in Episode.Diagnosis)
                {
                    if (dig.DiagnosisType == DiagnosisTypeEnum.Primer)
                        preDiagnosis = preDiagnosis + dig.Diagnose.Code + " - " + dig.Diagnose.Name.ToString() + ", ";
                }

                g.OnTani = Prediagnosis + " Ön Tanı: " + preDiagnosis;
                g.Aciklama = Notes;
                TTDataDictionary.EnumValueDef statusEnum = Common.GetEnumValueDefOfEnumValue(Episode.PatientStatus);
                g.Ayaktan = statusEnum.Value == 0 ? true : false;
                g.Acil = Urgent.HasValue == true ? Urgent.Value : false;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// İstek nesnesinin ilgili alanlarını doldurur.
        /// </summary>
        /// <returns></returns>
        private List<LaboratoryRequest.IstekBilgileri> CreateIstekBilgileri()
        {
            List<LaboratoryRequest.IstekBilgileri> istekler = new List<LaboratoryRequest.IstekBilgileri>();
            foreach (LaboratoryProcedure labProcedure in LaboratoryProcedures)
            {
                LaboratoryTestDefinition testDef = (LaboratoryTestDefinition)(labProcedure.ProcedureObject);
                if (testDef.NotLISTest != true)
                {
                    LaboratoryRequest.IstekBilgileri i = new LaboratoryRequest.IstekBilgileri();
                    i.SubActionID = labProcedure.ObjectID;
                    i.ActionID = labProcedure.EpisodeAction.ObjectID;
                    int j = labProcedure.MasterResource.Name.IndexOf("KAN BANKASI");
                    if (j < 0)
                        i.KB = false;
                    else
                        i.KB = true;
                    foreach (LaboratorySubProcedure subProcedure in labProcedure.LaboratorySubProcedures)
                    {
                        LaboratoryRequest.IstekBilgileri s = new LaboratoryRequest.IstekBilgileri();
                        s.SubActionID = subProcedure.ObjectID;
                        s.ActionID = subProcedure.EpisodeAction.ObjectID;
                        s.TestID = subProcedure.ProcedureObject.ObjectID;
                        s.MasterTestID = labProcedure.ProcedureObject.ObjectID;
                        s.LabID = labProcedure.MasterResource.ObjectID.ToString();
                        s.LabAdi = labProcedure.MasterResource.Name;
                        s.KisaAdi = subProcedure.ProcedureObject.Code;
                        s.Adi = subProcedure.ProcedureObject.Name;
                        i.OdemeFlag = !((SubactionProcedureFlowable)subProcedure).Paid();
                        istekler.Add(s);
                    }

                    i.TestID = labProcedure.ProcedureObject.ObjectID;
                    i.KisaAdi = labProcedure.ProcedureObject.Code;
                    i.Adi = labProcedure.ProcedureObject.Name;
                    i.LabID = labProcedure.MasterResource.ObjectID.ToString();
                    i.LabAdi = labProcedure.MasterResource.Name;
                    i.OdemeFlag = !((SubactionProcedureFlowable)labProcedure).Paid();
                    istekler.Add(i);
                }
            }

            return istekler;
        }

        public override EpisodeAction PrepareEpisodeActionForRemoteMethod(bool withNewObjectID)
        {
            LaboratoryRequest labRequest = (LaboratoryRequest)base.PrepareEpisodeActionForRemoteMethod(withNewObjectID);
            if (withNewObjectID)
            {
                labRequest.RequestDoctor = null;
            }

            return labRequest;
        }

        [LooselyTypeAttribute]
        [Serializable]
        public class HastaBilgileri
        {
            public Guid ID;
            public string PatientID;
            public string TCKimlikNo;
            public string Adi;
            public string Soyadi;
            public SexEnum Cinsiyeti;
            public DateTime DogumTarihi;
            public string DogumYeri;
            public string BabaAdi;
            public string AnneAdi;
        }

        [LooselyTypeAttribute]
        [Serializable]
        public class GelisBilgileri
        {
            public Guid ActionID;
            public Guid EpisodeID;
            public Guid PatientID;
            public int ActionNo;
            public DateTime IstekTarihi;
            public DateTime CalismaTarihi;
            public Guid DoktorID;
            public string DoktorAdi;
            public Guid BirimID;
            public string BirimAdi;
            public int HastaGrubuID;
            public string HastaGrubu;
            public int HastaKuvvetiID;
            public string HastaKuvveti;
            public string OnTani;
            public string Aciklama;
            public bool Ayaktan;
            public bool Acil;
            public bool KanBank = false;
        }

        [LooselyTypeAttribute]
        [Serializable]
        public class IstekBilgileri
        {
            public Guid SubActionID;
            public Guid ActionID;
            public Guid TestID;
            public Guid MasterTestID;
            public string LabID;
            public string LabAdi;
            public string KisaAdi;
            public string Adi;
            public bool OdemeFlag;
            public bool KB;
        }

        public enum HighLowEnum
        {
            None = 0,
            Normal = 1,
            High = 2,
            Low = 3,
            Panic = 4
        }

        //Laboratuvar HISKabul ile ilgili class ve metodlar
        public class HISKabulInfo
        {
            public Guid ActionID;
            public DateTime HISKabulTarihi;
        }

        public static void HISKabul(LaboratoryRequest.HISKabulInfo hisKabul)
        {
            TTObjectContext context = new TTObjectContext(false);
            if (hisKabul.ActionID != null && hisKabul.ActionID != Guid.Empty)
            {
                LaboratoryRequest labRequest = (LaboratoryRequest)context.GetObject(hisKabul.ActionID, "LABORATORYREQUEST");
                if (labRequest != null)
                {
                    if (labRequest.CurrentStateDefID == LaboratoryRequest.States.RequestAcception)
                    {
                        labRequest.CurrentStateDefID = LaboratoryRequest.States.Procedure;
                        if (hisKabul.HISKabulTarihi != null)
                        {
                            labRequest.LabRequestAcceptionDate = hisKabul.HISKabulTarihi;
                        }
                    }

                    context.Save();
                }
                else
                {
                    throw new Exception(TTUtils.CultureService.GetText("M25933", "HISKabulInfo nesnesinin ActionID değeri ile Laboratuvar işlemine ulaşılamadı! Bilgi İşleme haber veriniz!"));
                }
            }
            else
            {
                throw new Exception(TTUtils.CultureService.GetText("M25932", "HISKabulInfo nesnesinin ActionID değeri geçersizdir! Bilgi İşleme haber veriniz!"));
            }
        }

        public void CheckMedulaDiabetFormForLaboratoryProcedure()
        {
            try
            {
                if (SubEpisode.IsSGK)
                {
                    string errorMessage = string.Empty;
                    foreach (LaboratoryProcedure lp in LaboratoryProcedures)
                    {
                        if (((LaboratoryTestDefinition)lp.ProcedureObject).RequiresDiabetesForm != null && ((LaboratoryTestDefinition)lp.ProcedureObject).RequiresDiabetesForm == true)
                        {
                            Guid siteID = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("SITEID", null).ToString());
                            TakipFormuIslemleri.takipFormuOkuGirisDVO takipFormuOkuGirisDVO = new TakipFormuIslemleri.takipFormuOkuGirisDVO();
                            takipFormuOkuGirisDVO.saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();
                            if (Episode.Patient != null && Episode.Patient.UniqueRefNo != null)
                                takipFormuOkuGirisDVO.tcKimlikNo = Episode.Patient.UniqueRefNo.ToString();
                            TakipFormuIslemleri.takipFormuOkuCevapDVO takipFormuOkuCevapDVO = TakipFormuIslemleri.WebMethods.takipFormuOku(siteID, takipFormuOkuGirisDVO);
                            if (takipFormuOkuCevapDVO != null)
                            {
                                if (string.IsNullOrEmpty(takipFormuOkuCevapDVO.sonucKodu) == false)
                                {
                                    if (takipFormuOkuCevapDVO.sonucKodu.Equals("0000"))
                                    {
                                        if (takipFormuOkuCevapDVO.diabetTakipFormlari != null && takipFormuOkuCevapDVO.diabetTakipFormlari.Length <= 0)
                                            errorMessage = TTUtils.CultureService.GetText("M25874", "Hastaya Ait Diabet Takip Formu bulunamadı");
                                        //else if (takipFormuOkuCevapDVO.diabetTakipFormlari != null && takipFormuOkuCevapDVO.diabetTakipFormlari.Length > 0)
                                        //{
                                        //    InfoBox.S how("Hastaya Ait Diabet Takip Formlarının okunması işlemi başarılı şekilde yapıldı.", MessageIconEnum.InformationMessage);
                                        //}
                                    }
                                    else
                                    {
                                        if (string.IsNullOrEmpty(takipFormuOkuCevapDVO.sonucMesaji) == false)
                                            errorMessage = "Meduladan gelen mesaj : " + takipFormuOkuCevapDVO.sonucMesaji;
                                        else
                                            errorMessage = TTUtils.CultureService.GetText("M25872", "Hastaya Ait Diabet Takip Formlarının Meduladan okunması işleminde hata var.");
                                    }
                                }
                                else
                                {
                                    if (string.IsNullOrEmpty(takipFormuOkuCevapDVO.sonucMesaji) == false)
                                        errorMessage = "Meduladan gelen mesaj : " + takipFormuOkuCevapDVO.sonucMesaji;
                                    else
                                        errorMessage = TTUtils.CultureService.GetText("M25873", "Hastaya Ait Diabet Takip Formlarının Meduladan okunması sırasında hata oluştu! Sonuç Kodu ve Sonuç Mesajı alanı boş!");
                                }
                            }
                            else
                                errorMessage = TTUtils.CultureService.GetText("M25871", "Hastaya Ait Diabet Takip Formları Meduladan okunamadı!");
                        }

                        if (!string.IsNullOrEmpty(errorMessage))
                            throw new TTUtils.TTException("Medula '" + lp.ProcedureObject.Name + "' adlı tetkik için Diyabet takip formu istemektedir. Hastaya ait diyabet takip formu sorgulaması sırasında hata oluştu!\r\n" + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new TTUtils.TTException(ex.Message);
            }
        }

        override public Guid ProcedureRequestStartedStateDefID()
        {
            return (Guid)LaboratoryRequest.States.RequestAcception;
        }

        override public void DoMyActionControlsForProcedureRequest()
        {
            // TODO: 
            //Ayaktan hasta icin Episodeda aynı test istenmis mi kontrolu 
            //Testin Uzmanlık dalı episode uzmanlık dalı ile aynı mı kontrolu
            //Istenılen test panel ise alt testlerını create et 
            //Istenen testın MedulaDiabetTakipForm kaydı olup olmadıgı kontrolu 
            //if (!ValidateSutRules(this))
            //{
            //    throw new TTUtils.TTException("Sut kuralları doğrulaması başarısız oldu");//ApplicationException
            //}
            if (Prediagnosis != null)
            {
                if (Prediagnosis.Length > 2000)
                    throw new Exception(TTUtils.CultureService.GetText("M26303", "Kısa Anamnez ve Klinik Bulgular alanına en fazla 2000 karakter uzunluğunda metin girilmesine izin verilmektedir!"));
            }

            //Tekrarlayan tetkik isteklerin kontrolü burada gerçekleşir...
            foreach (EpisodeAction episodeAction in Episode.EpisodeActions)
            {
                if (episodeAction is LaboratoryRequest)
                {
                    if (episodeAction.ObjectID != ObjectID)
                    {
                        if (SubactionProcedures.Count > 0)
                        {
                            foreach (SubActionProcedure labRequestInfo in SubactionProcedures)
                            {
                                foreach (LaboratoryProcedure labProc in ((LaboratoryRequest)episodeAction).LaboratoryProcedures)
                                {
                                    if (labRequestInfo.ProcedureObject.ObjectID == labProc.ProcedureObject.ObjectID)
                                    {
                                        //Basarili ya da Basarisiz tamamlanmis stepler disindaki herhangi bir stepte ayni istem varsa exception verecek.
                                        if (labProc.CurrentStateDefID != LaboratoryProcedure.States.Completed && labProc.CurrentStateDefID != LaboratoryProcedure.States.Cancelled)
                                        {
                                            string errorMsg = "Hastanın vakasında daha önceden istenmiş " + labProc.ProcedureObject.Code.ToString() + " " + labProc.ProcedureObject.Name.ToString() + " tetkik isteği mevcuttur!" + "\n  Laboratuvar İşlem Numarası: " + labProc.EpisodeAction.ID.Value.ToString() + "\n" + TTUtils.CultureService.GetText("M27100", "Tetkik istekten vazgeçildi.");
                                            //throw new TTUtils.TTException(errorMsg);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            //TODO: Asagidaki kontrol PBS modulundeki BranchGrid objesinden yapiliyor. PBS kaldirildigi icin testin brans kontrolu icin farkli bir tasarim yapilarak kontrol edilmeli. 
            /*
                                bool requestOK = false;
                                foreach   (SubActionProcedure labRequestInfo in ea.SubactionProcedures) //(ExtendedLabRequestInfo labProc in tempTestDefList)
                                {
                                    requestOK = false;

                                    if (((LaboratoryTestDefinition)labRequestInfo.ProcedureObject).Branch != null )
                                    {
                                            if (ea.Episode.MainSpeciality.Code == ((LaboratoryTestDefinition)labRequestInfo.ProcedureObject).Branch.bransKodu)
                                            {
                                                requestOK = true;
                                                break;
                                            }

                                    }
                                    else
                                    {
                                        requestOK = true;
                                    }

                                    if (!requestOK)
                                    {
                                        string notification = ((LaboratoryTestDefinition)labRequestInfo.ProcedureObject).Branch.bransAdi;

                                        //foreach (BranchGrid branchTemp in ((LaboratoryTestDefinition)labProc.LabTestDef).BranchGrid)
                                        //{
                                        //    notification += branchTemp.Specialities.Name + "\r\n";
                                        //}
                                        throw new TTUtils.TTException("Hasta vakasının uzmanlık dalı: '" + ea.Episode.MainSpeciality.Name + "'\r\n"
                                                                      + "\r\n'" + labRequestInfo.ProcedureObject.Name + "' tetkik isteğinde yetkili uzmanlık dalları:\r\n"
                                                                      + notification + "\r\n\n"
                                                                      + "Listelenen yetkili uzmanlık bölümlerinden uygun olan seçenek için 'Konsültasyon' işlem isteği başlatınız.\r\n"
                                                                      + "Yeni Süreç >> Prosedürler >> Konsültasyon/Dış Tetkik İstek >> Diğer Birim(ler)den Konsültasyon\r\n"
                                                                      + "işlem adımlarını takip ederek 'Konsültasyon' isteği başlatabilirsiniz.");
                                    }

                                }
               */
            //Istenen testın MedulaDiabetTakipForm kaydı olup olmadıgı kontrolu 
            CheckMedulaDiabetFormForLaboratoryProcedure();
        }

        override public void SetMyActionMandatoryProperties()
        {
            PatientAge = Episode.Patient.AgeByYearByMonthByDay();

            int[] doctorType = new int[3] { 0, 2, 17 };

            if (Common.CurrentResource.TakesPerformanceScore == true && doctorType.Contains((int)Common.CurrentResource.UserType))
            {

                RequestDoctor = Common.CurrentResource;
            }
            else
            {
                if (this.MasterAction is PatientExamination)
                {
                    if (((PatientExamination)this.MasterAction).ProcedureDoctor != null)
                        RequestDoctor = ((PatientExamination)this.MasterAction).ProcedureDoctor;
                }
                else if (this.MasterAction is InPatientPhysicianApplication)
                {
                    if (((InPatientPhysicianApplication)this.MasterAction).ProcedureDoctor != null)
                        RequestDoctor = ((InPatientPhysicianApplication)this.MasterAction).ProcedureDoctor;
                }
                else
                    RequestDoctor = Common.CurrentResource;

            }


        }

        #endregion Methods
        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(LaboratoryRequest).Name)
                return;
            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;
            if (fromState == LaboratoryRequest.States.Procedure && toState == LaboratoryRequest.States.Cancelled)
                PostTransition_Procedure2Cancelled();
            else if (fromState == LaboratoryRequest.States.Procedure && toState == LaboratoryRequest.States.Completed)
                PostTransition_Procedure2Completed();
            else if (fromState == LaboratoryRequest.States.New && toState == LaboratoryRequest.States.Procedure)
                PostTransition_New2Procedure();
            else if (fromState == LaboratoryRequest.States.New && toState == LaboratoryRequest.States.RequestAcception)
                PostTransition_New2RequestAcception();
            else if (fromState == LaboratoryRequest.States.RequestAcception && toState == LaboratoryRequest.States.Completed)
                PostTransition_RequestAcception2Completed();
            else if (fromState == LaboratoryRequest.States.RequestAcception && toState == LaboratoryRequest.States.Cancelled)
                PostTransition_RequestAcception2Cancelled();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(LaboratoryRequest).Name)
                return;
            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;
            if (fromState == LaboratoryRequest.States.Procedure && toState == LaboratoryRequest.States.Completed)
                UndoTransition_Procedure2Completed(transDef);
            else if (fromState == LaboratoryRequest.States.New && toState == LaboratoryRequest.States.Procedure)
                UndoTransition_New2Procedure(transDef);
            else if (fromState == LaboratoryRequest.States.New && toState == LaboratoryRequest.States.RequestAcception)
                UndoTransition_New2RequestAcception(transDef);
            else if (fromState == LaboratoryRequest.States.RequestAcception && toState == LaboratoryRequest.States.Procedure)
                UndoTransition_RequestAcception2Procedure(transDef);
        }
    }
}