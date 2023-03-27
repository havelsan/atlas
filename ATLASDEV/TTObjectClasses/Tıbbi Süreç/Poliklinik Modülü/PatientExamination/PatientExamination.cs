
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
using AtlasDataModel;

namespace TTObjectClasses
{
    /// <summary>
    /// Hasta Muayenesi İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
    public partial class PatientExamination : PhysicianApplication, IPatientWorkList, IReasonOfReject, IAppointmentDef, IAllocateSpeciality, ICheckTreatmentMaterialIsEmpty, IOAExamination, IWorkListEpisodeAction, ITreatmentMaterialCollection, INumaratorAppointment
    {
        public partial class OLAP_GetPatientExamination_Class : TTReportNqlObject
        {
        }

        public partial class GetPatientExaminationNQL_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetCancelledPatientExamination_Class : TTReportNqlObject
        {
        }

        public partial class GetPatientAbsentNQL_Class : TTReportNqlObject
        {
        }

        public partial class GetPatientExaminationByMasterResource_Class : TTReportNqlObject
        {
        }

        public partial class GetPatientExamiationsForBeatenAndAlcohol_Class : TTReportNqlObject
        {
        }

        public partial class GetPatientExaminationByObjectIDs_Class : TTReportNqlObject
        {
        }

        public partial class GetPANoDiagnose_Class : TTReportNqlObject
        {
        }

        public partial class GetDoctorsWorkListReportNQL_Class : TTReportNqlObject
        {
        }

        #region INumaratorAppointment Members

        public AppointmentTypeEnum GetNumaratorAppointmentType()
        {
            return NumaratorAppointmentType;
        }

        public Resource GetNumaratorAppointmentMasterResource()
        {
            return NumaratorAppointmentMasterResource;
        }

        public Resource GetNumaratorAppointmentResource()
        {
            return NumaratorAppointmentResource;
        }
        #endregion

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

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "EMERGENCYINTERVENTION":
                    {
                        EmergencyIntervention value = (EmergencyIntervention)newValue;
                        #region EMERGENCYINTERVENTION_SetParentScript
                        if (value != null)
                        {
                            ProcedureDoctor = value.ResponsibleDoctor;

                            bool addNewAuthorizedUser = true;
                            if (value.ResponsibleDoctor != null)
                            {
                                if (AuthorizedUsers.Count > 0)
                                {
                                    foreach (AuthorizedUser authorizedUser in AuthorizedUsers)
                                    {
                                        if (authorizedUser.User.ObjectID == value.ResponsibleDoctor.ObjectID)
                                        {
                                            authorizedUser.User = value.ResponsibleDoctor;
                                            addNewAuthorizedUser = false;
                                            break;
                                        }
                                    }
                                }
                                if (addNewAuthorizedUser)
                                {
                                    AuthorizedUser newAuthorizedUser = new AuthorizedUser(ObjectContext);
                                    newAuthorizedUser.User = (ResUser)value.ResponsibleDoctor;
                                    AuthorizedUsers.Add(newAuthorizedUser);

                                }
                            }


                        }
                        #endregion EMERGENCYINTERVENTION_SetParentScript
                    }
                    break;
                case "TREATMENTRESULT":
                    {
                        SKRSCikisSekli value = (SKRSCikisSekli)newValue;
                        #region TREATMENTRESULT_SetParentScript
                        if (value != null)
                        {
                            BindingList<MedulaDischargeTypeDefinition> medulaDischargeTypeDefinitionList = MedulaDischargeTypeDefinition.GetBySKRSCikisSekli(ObjectContext, value.ObjectID, "");
                            if (medulaDischargeTypeDefinitionList.Count > 0)
                                MTSDischargeType = medulaDischargeTypeDefinitionList[0].XXXXXXDischargeType;
                        }
                        else
                            MTSDischargeType = null;
                        #endregion TREATMENTRESULT_SetParentScript
                    }
                    break;
                default:
                    base.RunSetMemberValueScript(memberName, newValue);
                    break;

            }
        }

        public GreenListEnum MyMhrsAppointmentGreenListInfo()
        {
            GreenListEnum greenListEnum = GreenListEnum.Exception;
            if (TTObjectClasses.SystemParameter.GetParameterValue("MHRSYEBILDIR", "FALSE").ToUpper() == "TRUE")
            {
                foreach (Appointment app in EpisodeAction.MyCompletedAppointments(ObjectID))
                {
                    if (app.MHRSRandevuHrn != null && ProcedureDoctor.SentToMHRS == true)
                    {
                        if (MasterResource is ResPoliclinic)
                        {
                            int? mhrsCode = ((ResPoliclinic)MasterResource).MHRSCode;
                            if (mhrsCode != null)
                                return SearchInMHRSGreenList(Convert.ToInt32(mhrsCode));
                        }

                    }
                }
            }

            return greenListEnum;
        }

        public GreenListEnum SearchInMHRSGreenList(int MHRSCode)
        {
            try
            {
                string userName = TTObjectClasses.SystemParameter.GetParameterValue("MHRSUSERNAME", "XXXXXX");
                string password = TTObjectClasses.SystemParameter.GetParameterValue("MHRSPASSWORD", "XXXXXX");
                string MHRSKurumKodu = TTObjectClasses.SystemParameter.GetParameterValue("MHRSKURUMKODU", "XXXXXX");
                string MHRSFirmaKodu = TTObjectClasses.SystemParameter.GetParameterValue("MHRSFIRMAKODU", "XXXXXX");

                MHRSServis.YetkilendirmeGirisBilgileriType yetkilendirmeGirisBilgileri = new MHRSServis.YetkilendirmeGirisBilgileriType();
                MHRSServis.KurumBilgileriType kurumBilgileri = new MHRSServis.KurumBilgileriType();
                MHRSServis.YesilListeVatandasSorgulamaTalepType yesilListeVatandasSorgulama = new MHRSServis.YesilListeVatandasSorgulamaTalepType();
                MHRSServis.YesilListeVatandasSorgulamaCevapType yesilListeVatandasSorgulamaCevap = new MHRSServis.YesilListeVatandasSorgulamaCevapType();

                if (userName != null && password != null && MHRSKurumKodu != null)
                {
                    yetkilendirmeGirisBilgileri.KullaniciKodu = Convert.ToInt64(userName);
                    yetkilendirmeGirisBilgileri.KullaniciSifre = password;
                    yetkilendirmeGirisBilgileri.KulaniciTuru = 2;
                    yesilListeVatandasSorgulama.YetkilendirmeGirisBilgileri = yetkilendirmeGirisBilgileri;

                    kurumBilgileri.IslemYapanKisiTCNo = Convert.ToInt64(ProcedureDoctor.UniqueNo);
                    kurumBilgileri.KurumKodu = Convert.ToInt32(MHRSKurumKodu);
                    kurumBilgileri.KurumKoduSpecified = true;
                    kurumBilgileri.GonderenBirim = MHRSFirmaKodu;
                    yesilListeVatandasSorgulama.KurumBilgileri = kurumBilgileri;

                    yesilListeVatandasSorgulama.TCKimlikNo = Episode.Patient.UniqueRefNo.ToString();

                    yesilListeVatandasSorgulama.KlinikKodu = MHRSCode;
                    yesilListeVatandasSorgulama.KlinikKoduSpecified = true;
                    yesilListeVatandasSorgulamaCevap = MHRSServis.WebMethods.YesilListeVatandasSorgulamaSync(Sites.SiteLocalHost, yesilListeVatandasSorgulama);

                    if (yesilListeVatandasSorgulamaCevap != null && yesilListeVatandasSorgulamaCevap.TemelCevapBilgileri != null)
                    {
                        if (yesilListeVatandasSorgulamaCevap.TemelCevapBilgileri.ServisBasarisi == true)
                        {
                            if (yesilListeVatandasSorgulamaCevap.YesilListeBilgileri == null || yesilListeVatandasSorgulamaCevap.YesilListeBilgileri.Length == 0)
                                return GreenListEnum.Add;
                            else
                            {
                                bool added = false;
                                bool approved = false;
                                foreach (MHRSServis.YesilListeBilgileriType yesilListeBilgi in yesilListeVatandasSorgulamaCevap.YesilListeBilgileri)
                                {
                                    if (yesilListeBilgi.KlinikKodu == MHRSCode)
                                    {
                                        added = true;
                                        if (yesilListeBilgi.OnayDurumu == 1)
                                            approved = true;
                                        else
                                            approved = false;

                                        break;
                                    }
                                    else
                                        added = false;
                                }
                                if (!added)
                                    return GreenListEnum.Add;
                                if (added && !approved)
                                    return GreenListEnum.Approve;
                                if (added && approved)
                                    return GreenListEnum.Approved;

                                return GreenListEnum.Exception;
                            }
                        }
                        else
                        {
                            // InfoBox.Alert("MHRS Bildirim Hatası : " + yesilListeVatandasSorgulamaCevap.TemelCevapBilgileri.Aciklama);
                            return GreenListEnum.Exception;
                        }
                    }
                    else
                        return GreenListEnum.Exception;
                }
                else
                    return GreenListEnum.Exception;
            }
            catch (Exception ex)
            {
                // InfoBox.Alert(ex);
                throw;
            }
        }

        /// <summary>
        /// Adli muayene olup olmadığını döndürü
        /// </summary>
        public bool IsForensicMedicalExam
        {
            get
            {
                try
                {
                    #region IsForensicMedicalExam_GetScript              
                    //todo bg
                    /*      
                    if (this.SubEpisode.PatientAdmission.AdmissionType == AdmissionTypeEnum.JudicialMedicineAdmission)
                        return true;*/
                    return false;
                    #endregion IsForensicMedicalExam_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "IsForensicMedicalExam") + " : " + ex.Message, ex);
                }
            }
        }


        /// <summary>
        /// yeşil Alan muayene olup olmadığını döndürü
        /// </summary>
        public bool IsGreenAreaExamination
        {
            get
            {
                try
                {
                    #region IsGreenAreaExamination_GetScript                    
                    if (EmergencyIntervention != null)
                        return EmergencyIntervention.IsGreenAreaExamination;

                    return false;
                    #endregion IsGreenAreaExamination_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "IsGreenAreaExamination") + " : " + ex.Message, ex);
                }
            }
        }

        protected override void PreInsert()
        {
            #region PreInsert



            base.PreInsert();

            CreateHCExaminationDynamicObject();
            //DP için kapatıldı.
            //AddPatientExaminationProcedure();
            if (IsOldAction != true)
            {
                if (SubEpisode.OpenSubEpisodeProtocol.Protocol.Type == ProtocolTypeEnum.Paid)
                {
                    foreach (SubActionProcedure sp in SubactionProcedures)
                    {
                        sp.AccountOperation(AccountOperationTimeEnum.PREPOST);
                    }
                }
            }

            #endregion PreInsert
        }

        public void MovePatientsChemoRadiotherapy()
        {
            var patientChemotherapyRadiotherapies = ChemotherapyRadiotherapy.GetPatientsChemotherapyRadiotherapies(this.ObjectContext, Episode.Patient.ObjectID);
            var chemoRadioObject = patientChemotherapyRadiotherapies.Where(t => t.CurrentStateDefID == ChemotherapyRadiotherapy.States.Request && t.CreatedAction == null).OrderByDescending(y => y.RequestDate).FirstOrDefault();

            if (chemoRadioObject != null)
            {
                chemoRadioObject.OldSubEpisode = chemoRadioObject.SubEpisode;
                chemoRadioObject.CreatedAction = chemoRadioObject.MasterAction;
                chemoRadioObject.MasterAction = this;
                chemoRadioObject.SubEpisode = SubEpisode;
                chemoRadioObject.Episode = this.Episode;
                foreach (var cureProtocol in chemoRadioObject.ChemoRadioCureProtocol)
                {
                    cureProtocol.SubEpisode = chemoRadioObject.SubEpisode;
                    cureProtocol.Episode = chemoRadioObject.Episode;
                    foreach (ChemoRadioCureProtocolDet cureProtocolDet in cureProtocol.ChemoRadioCureProtocolDet)
                    {
                        ChemoRadioCureProtocolDet newProcedure = new ChemoRadioCureProtocolDet();
                        newProcedure = (ChemoRadioCureProtocolDet)cureProtocolDet.Clone();
                        newProcedure.SubEpisode = chemoRadioObject.SubEpisode;
                        newProcedure.Episode = chemoRadioObject.Episode;
                        if(newProcedure.DrugMaterial != null)
                        {
                            StockActionDetail stockActionDetail = newProcedure.DrugMaterial.StockActionDetail;
                            Store store = newProcedure.DrugMaterial.StockActionDetail.StockAction.Store;
                            newProcedure.DrugMaterial.CurrentStateDefID = BaseTreatmentMaterial.States.Cancelled;
                            newProcedure.DrugMaterial.StockActionDetail = null;
                            cureProtocolDet.DrugMaterial.StockActionDetail = null;
                            ObjectContext.Update();

                            BaseTreatmentMaterial newMaterial = new BaseTreatmentMaterial(ObjectContext);
                            newMaterial.Store = store;
                            newMaterial.Eligible = newProcedure.DrugMaterial.Eligible;
                            newMaterial.Material = newProcedure.DrugMaterial.Material;
                            newMaterial.Amount = newProcedure.DrugMaterial.Amount;
                            newMaterial.StockActionDetail = stockActionDetail;
                            newMaterial.SubEpisode = chemoRadioObject.SubEpisode;
                            newMaterial.Episode = chemoRadioObject.Episode;
                            newProcedure.DrugMaterial = newMaterial;
                            cureProtocolDet.DrugMaterial.CurrentStateDefID = BaseTreatmentMaterial.States.Cancelled;

                        }
                        if(newProcedure.SolutionMaterial != null)
                        {
                            StockActionDetail stockActionDetail = newProcedure.SolutionMaterial.StockActionDetail;
                            Store store = newProcedure.SolutionMaterial.StockActionDetail.StockAction.Store;
                            newProcedure.SolutionMaterial.CurrentStateDefID = BaseTreatmentMaterial.States.Cancelled;
                            newProcedure.SolutionMaterial.StockActionDetail = null;
                            cureProtocolDet.SolutionMaterial.StockActionDetail = null;
                            ObjectContext.Update();

                            BaseTreatmentMaterial newMaterial = new BaseTreatmentMaterial(ObjectContext);
                            newMaterial.Store = store;
                            newMaterial.Eligible = newProcedure.SolutionMaterial.Eligible;
                            newMaterial.Material = newProcedure.SolutionMaterial.Material;
                            newMaterial.Amount = newProcedure.SolutionMaterial.Amount;
                            newMaterial.StockActionDetail = stockActionDetail;
                            newMaterial.SubEpisode = chemoRadioObject.SubEpisode;
                            newMaterial.Episode = chemoRadioObject.Episode;
                            newProcedure.SolutionMaterial = newMaterial;
                            cureProtocolDet.SolutionMaterial.CurrentStateDefID = BaseTreatmentMaterial.States.Cancelled;
                        }

                        cureProtocolDet.CurrentStateDefID = ChemoRadioCureProtocolDet.States.Cancelled;

                    }
                }
            }
            else
            {
                var activeChemotherapyRadiotherapy = patientChemotherapyRadiotherapies.Where(x => x.CurrentStateDefID == ChemotherapyRadiotherapy.States.DoctorPlanned 
                || x.CurrentStateDefID == ChemotherapyRadiotherapy.States.NurseApproved 
                ||(x.CurrentStateDefID == ChemotherapyRadiotherapy.States.Request && x.CreatedAction != null)).ToList();
                if (activeChemotherapyRadiotherapy.Count > 0 )
                {
                    throw new Exception("Hastanın Kemoterapi/Radyoterapi tedavisi için alınmış farklı bir kabulü vardır. Tedavi seansı sonlandırılmadan bu birime kabul alınamaz.");
                }
                throw new Exception("Kemoterapi/Radyoterapi isteği bulunmayan hastalara bu birime kabul alnamaz");
            }
        }

        protected override void PostInsert()
        {
            #region PostInsert

            base.PostInsert();

            if (ProcedureDoctor == null)
            {
                foreach (AuthorizedUser authorizedUser in AuthorizedUsers)
                {
                    ProcedureDoctor = (ResUser)authorizedUser.User;
                    break;
                }
            }

            if (PatientExaminationType != PatientExaminationEnum.HealthCommittee)
            {
                if (SubEpisode.LastActiveSubEpisodeProtocol != null && SubEpisode.LastActiveSubEpisodeProtocol.MedulaTedaviTipi?.tedaviTipiKodu == "14" && SubEpisode.LastActiveSubEpisodeProtocol.MedulaTedaviTuru.tedaviTuruKodu == "G")
                {
                    //AddDailyBedProcedure();
                    MovePatientsChemoRadiotherapy();
                }
                else
                {
                    AddPatientExaminationProcedure();
                    AddPatientExaminationParticipationProcedure();
                }

            }
            if (HasActiveQueueItem() == false)
            {
                IList<ExaminationQueueDefinition> myQueue = ExaminationQueueDefinition.GetQueueByResource(ObjectContext, MasterResource.ObjectID.ToString());
                if (myQueue.Count > 0)
                    CreateExaminationQueueItem(SubEpisode.PatientAdmission, myQueue[0], false);
            }

            /*** Asagıdaki kod ToExamination stebine gecirildi
            
            // Normal muayene ücreti oluşması için normal muayene procedürü atar
            PatientExaminationProcedure patientExaminationProcedure = new PatientExaminationProcedure(this,"509b6667-5799-408e-a69b-cf25439f1091");
            //Hasta Kabul sırasında özel muayene işaretlendi ise  Özel muayene procedureünü atar.
            if (this.IsSpecialExamination)
            {
                PatientExaminationProcedure spatientExaminationProcedure = new PatientExaminationProcedure(this,"4c5cca3d-ca3d-419a-8b97-09f2c85d0188");
            }
           
  
             ******/

            /* SMS İşlemleri -> Poliklinik hizmetlerine geç başlama */
            ExaminationRegister(this.ProcedureDoctor);

            #endregion PostInsert
        }

        protected override void PreUpdate()
        {
            #region PreUpdate

            base.PreUpdate();

            foreach (SingleNursingOrder nursingOrder in SingleNursingOrders)
            {
                if (nursingOrder.CurrentStateDefID == SingleNursingOrder.States.New)
                {
                    nursingOrder.FromResource = FromResource;
                    nursingOrder.MasterResource = MasterResource;
                    nursingOrder.Episode = Episode;
                    nursingOrder.Frequency = TTObjectClasses.FrequencyEnum.Q24H;
                    nursingOrder.AmountForPeriod = 1;
                    nursingOrder.RecurrenceDayAmount = 1;
                }
            }

            if (ProcessDate.HasValue == true && ProcessEndDate.HasValue == false)// && this.TreatmentResult != null)
                ProcessEndDate = Common.RecTime();

            if (((TransDef != null) && (TransDef.ToStateDefID == PatientExamination.States.Completed || TransDef.ToStateDefID == PatientExamination.States.ExaminationCompleted || TransDef.ToStateDefID == PatientExamination.States.ProcedureRequested)))
            {
                foreach (PatientExaminationProcedure patientExaminationProcedure in PatientExaminationProcedures.Where(x => x.CurrentStateDef.Status != StateStatusEnum.Cancelled))
                {
                    patientExaminationProcedure.SetPerformedDate();
                }

                foreach (HealthCommitteeExaminationProcedure healthCommitteeExaminationProcedure in HealthCommitteeExaminationProcedure.Where(x => x.CurrentStateDef.Status != StateStatusEnum.Cancelled))
                {
                    healthCommitteeExaminationProcedure.SetPerformedDate();
                }
            }

            //if (this.TransDef == null)
            //{
            //    if (this.CurrentStateDefID == PatientExamination.States.Examination)// && this.TreatmentResult != null)
            //    {

            //        this.CurrentStateDefID = PatientExamination.States.ExaminationCompleted;
            //    }
            //}



            #endregion PreUpdate
        }

        protected override void PostUpdate()
        {
            #region PostUpdate

            base.PostUpdate();
            CompleteMyUnCompletedAppoinments();
            /*
            if (this.PatientExaminationProcedures.Count > 0)
            {
                Guid muayeneGuid = ProcedureDefinition.ExaminationProcedureObjectId;
                Guid sameDayProtocolGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("DEFAULTSGKOUTPATIENTSAMEDAYPROTOCOL", "6514e4ec-5798-4a46-9ce3-5f6a92beaaf3"));
                Guid bulletinProtocolGuid = new Guid(TTObjectClasses.SystemParameter.GetParameterValue("DEFAULTBULLETINPROTOCOL", "af9fc8c0-3e55-434d-91e1-d758362fcba7"));

                foreach (PatientExaminationProcedure examinationProcedure in this.PatientExaminationProcedures)
                {
                    if (examinationProcedure.ProcedureObject.ObjectID.Equals(muayeneGuid))
                    {
                        foreach (AccountTransaction AccTrx in examinationProcedure.AccountTransactions)
                        {
                            if (AccTrx.SubEpisodeProtocol.Protocol.ObjectID.Equals(sameDayProtocolGuid))
                            {
                                if (AccTrx.CurrentStateDefID != AccountTransaction.States.Cancelled && AccTrx.Description.IndexOf("Aynı Gün Diğer Branş Muayenesi") == -1)
                                    AccTrx.Description += " (Aynı Gün Diğer Branş Muayenesi)";

                                examinationProcedure.ExtraDescription = "(Aynı Gün Diğer Branş Muayenesi)";
                            }
                            else if (AccTrx.SubEpisodeProtocol.Protocol.ObjectID.Equals(bulletinProtocolGuid))
                            {
                                // Vakabaşı anlaşmasının içindeki Normal Poliklinik Muayenesi "Medulaya Gönderilmeyecek" durumuna alınır
                                if (AccTrx.CurrentStateDefID == AccountTransaction.States.New)
                                    AccTrx.CurrentStateDefID = AccountTransaction.States.MedulaDontSend;
                            }
                        }
                    }
                }
            }
            */

            //Transition post'ta nedense çalışmıyor. O yüzden buraya taşıdım MC
            if (TransDef != null)
            {
                if (TransDef.ToStateDefID == PatientExamination.States.Cancelled || TransDef.ToStateDefID == PatientExamination.States.PatientNoShown)
                {

                    Cancel();
                    CancelMyExaminationQueueItems();
                    if (TransDef.ToStateDefID == PatientExamination.States.PatientNoShown && Episode.PatientExaminations.Count == 1)
                    {
                        if (Common.CurrentUser.Name.ToUpper() == "TTCOMM")  // Planlı görevde showbox hatası almamak için
                            SubEpisode.CancelSubEpisodeProtocols();
                        else
                            SubEpisode.CancelSubEpisodeProtocols(null, true);
                    }
                }
            }

            // PostTransition_FromExamination() 'e taşındı
            //if (this.CurrentStateDefID == PatientExamination.States.ExaminationCompleted || this.CurrentStateDefID == PatientExamination.States.Completed)
            //{
            //    if (this.SubEpisode != null && this.SendToENabiz())
            //    {
            //        new SendToENabiz(this.ObjectContext, this.SubEpisode, this.SubEpisode.ObjectID, this.SubEpisode.ObjectDef.Name, "103", Common.RecTime());
            //        new SendToENabiz(this.ObjectContext, this.SubEpisode, this.SubEpisode.ObjectID, this.SubEpisode.ObjectDef.Name, "106", Common.RecTime());
            //    }
            //}

            #endregion PostUpdate

            /* SMS İşlemleri -> Poliklinik hizmetlerine geç başlama */
            if (this.TransDef != null)
            {
                if (this.TransDef.ToStateDefID != States.Cancelled)//İşlemi iptal etme haricinde muayene işlemi yapıldıysa SMS kaydı false olacak
                {
                    if (this.HasMemberChanged("ProcedureDoctor"))//doktor değiştirildiyse
                    {
                        // Eski/değiştirilen Doktor için işlemler
                        //var oldDoctor = (ResUser)(((ITTObject)this.ProcedureDoctor).Original);
                        var oldDoctor = ((PatientExamination)((ITTObject)this).Original).ProcedureDoctor;

                        ExaminationCancelled(oldDoctor);
                        ExaminationRegister(this.ProcedureDoctor);
                    }
                    ExaminationDone(this.ProcedureDoctor);
                }
                else//muayene iptal ediliyorsa -> mevcut doktora ait kayıt varsa examination değiştirilir yoksa satır silinir
                {
                    if (this.HasMemberChanged("ProcedureDoctor"))//doktor değiştirildiyse eski doktorun kaydı disactive yapılır
                    {
                        // Eski/değiştirilen Doktor için işlemler
                        var oldDoctor = ((PatientExamination)((ITTObject)this).Original).ProcedureDoctor;

                        ExaminationCancelled(oldDoctor);
                        ExaminationRegister(this.ProcedureDoctor);
                    }
                    // Yeni set edilen doktor için işlemler
                    ExaminationCancelled(this.ProcedureDoctor);

                }
            }

        }

        protected void PreTransition_Completed2Examination()
        {
            // From State : Completed   To State : Examination
            #region PreTransition_Completed2Examination

            if (OlapDate == null)
                OlapDate = DateTime.Now;

            #endregion PreTransition_Completed2Examination
        }

        protected void PostTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
            #region PostTransition_Completed2Cancelled



            Cancel();
            CancelMyExaminationQueueItems();
            if (PatientExaminationType == PatientExaminationEnum.HealthCommittee
                && HCExaminationComponent != null
                && HCExaminationComponent.EStatusNotRepCommitteeObj != null
                && HCExaminationComponent.EDurumBildirirMuayeneId != null)
            {
                CancelEDurumBildirirKurulExamination();
            }
            #endregion PostTransition_Completed2Cancelled
        }

        protected void UndoTransition_Completed2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Completed   To State : Cancelled
            #region UndoTransition_Completed2Cancelled
            NoBackStateBack();
            #endregion UndoTransition_Completed2Cancelled
        }

        protected void PreTransition_Examination2Completed()
        {
            // From State : Examination   To State : Completed
            #region PreTransition_Examination2Completed

            //            foreach (PatientExaminationNursingOrder nursingOrder in this.NursingOrders)
            //            {
            //                if (nursingOrder.CurrentStateDefID == PatientExaminationNursingOrder.States.New)
            //                    throw new Exception ("'Hemşireye Talimatlar' sekmesi dolu olduğundan işlem tamamlanamaz. 'Hemşirelik Uygulamaları' adımına geçmelisiniz.");
            //            }
            //if (this.NursingOrders.Count > 0)
            //throw new Exception ("'Hemşireye Talimatlar' sekmesi dolu olduğundan işlem tamamlanamaz. 'Hemşirelik Uygulamaları' adımına geçmelisiniz.");

            //CheckForForensicMedicalExamination();

            #endregion PreTransition_Examination2Completed
        }

        protected void PostTransition_Examination2Completed()
        {
            // From State : Examination   To State : Completed
            #region PostTransition_Examination2Completed

            /* kpayi --- this.UpdateMedulaPatientParticipationToSentServer();*/
            // this.CheckAndCloseEpisode();

            if (SubEpisode != null && SubEpisode.PatientAdmission != null)
                SubEpisode.PatientAdmission.PAStatus = PAStatusEnum.MuayenesiSonlandı;
            if (IsOldAction != true)
            {
                if (SubEpisode.IsSGK == true)
                {
                    if (Episode.PatientStatus.Value == PatientStatusEnum.Outpatient)
                    {
                        if (Episode.InpatientAdmissions.Count == 0 || Episode.InpatientAdmissions.FirstOrDefault(dr => dr.CurrentStateDef.Status != StateStatusEnum.Cancelled) == null)
                        {
                            if (Episode != null && SubEpisode.PatientAdmission != null && SubEpisode.PatientAdmission.Sevkli != null && SubEpisode.PatientAdmission.Sevkli == true)
                            {
                                if (MutatDisiAracRaporId.Value == null)
                                    MutatDisiAracRaporId.GetNextValueFromDatabase(null, 0);
                                if (MedulaSevkKayitSync())
                                    TTUtils.InfoMessageService.Instance.ShowMessage(TTUtils.CultureService.GetText("M26860", "Sevkli hastanın kaydi medulaya bildirildi."));
                                else
                                    throw new Exception(TTUtils.CultureService.GetText("M26859", "Sevkli hastanın bilgilerinin medulaya kaydı sırasında hata oluştu!"));
                            }
                        }

                    }
                }

                ControlGreenAreaExamination();
            }

            #endregion PostTransition_Examination2Completed
        }

        protected void UndoTransition_Examination2Completed(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Examination   To State : Completed
            #region UndoTransition_Examination2Completed

            if (SubEpisode != null && SubEpisode.PatientAdmission != null)
                SubEpisode.PatientAdmission.PAStatus = PAStatusEnum.Sirada;

            if (EmergencyIntervention != null)
            {
                if (IsObservationTaken == true)
                    NoBackStateBack();
                else
                    EmergencyIntervention.CurrentStateDefID = EmergencyIntervention.States.Observation;
            }


            if (MuayeneGiris != null)
            {
                if (MuayeneGiris.CurrentStateDefID == MuayeneGiris.States.SentServer)
                    MuayeneGiris.CurrentStateDefID = MuayeneGiris.States.New;
            }
            //Episode un açılış tarihi 10 günden önceyse vaka açık hale gelir.
            //Yatan veya Taburcu hastada episode un durumunun Açık yapılması engellendi.
            if (Episode.PatientStatus == PatientStatusEnum.Outpatient)
            {
                if (SubEpisode.IsOpenedInTenDays() == true)
                    UndoCloseEpisode();
            }

            // Medula Sevk Kayıt işlemi iptal ediliyor
            if (SubEpisode.IsSGK == true)
            {
                bool devam = false;
                if (PatientAdmission != null && PatientAdmission.Sevkli != null && PatientAdmission.Sevkli == true)
                    devam = true;
                else
                {
                    if (SubEpisode.PatientAdmission != null && SubEpisode.PatientAdmission.Sevkli != null && SubEpisode.PatientAdmission.Sevkli == true)
                        devam = true;
                }

                if (devam)
                {
                    if (MedulaESevkNo != null)
                        MedulaESevkKayitIptalSync();
                    if (string.IsNullOrEmpty(MedulaMutatDisiAracRaporNo) == false && !MedulaMutatDisiAracRaporNo.Equals("0"))
                        MutatDisiAracRaporSilSync();
                }
            }


            #endregion UndoTransition_Examination2Completed
        }

        protected void PostTransition_Examination2Cancelled()
        {
            // From State : Examination   To State : Cancelled
            #region PostTransition_Examination2Cancelled

            if (SubEpisode != null && SubEpisode.PatientAdmission != null && SubEpisode.PatientAdmission.PAStatus != PAStatusEnum.KabulSilindi
                && SubEpisode.PatientAdmission.PAStatus != PAStatusEnum.IptalEdildi && PatientExaminationType != PatientExaminationEnum.HealthCommittee)
            {
                if (SubEpisode.PatientAdmission.CurrentStateDefID != PatientAdmission.States.Cancelled)
                    SubEpisode.PatientAdmission.PAStatus = PAStatusEnum.MuayeneyeGelmedi;
            }
            Cancel();
            CancelMyExaminationQueueItems();

            //kayıt kabul aşamasında iptal edildiği için buradaki kodu kapattım bg
            /* if (this.EmergencyIntervention != null)
                 this.EmergencyIntervention.CurrentStateDefID = EmergencyIntervention.States.Cancelled;*/

            #endregion PostTransition_Examination2Cancelled
        }

        protected void UndoTransition_Examination2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Examination   To State : Cancelled
            #region UndoTransition_Examination2Cancelled
            NoBackStateBack();
            #endregion UndoTransition_Examination2Cancelled
        }

        //protected void PostTransition_New2PatientNoShown()
        //{
        //    // From State : New   To State : PatientNoShown
        //    #region PostTransition_New2PatientNoShown
        //    this.Episode.PAStatus = PAStatusEnum.MuayeneyeGelmedi;
        //    this.CancelMyExaminationQueueItems();
        //    if (this.Episode.CurrentStateDefID == Episode.States.Open && this.Episode.PatientExaminations.Count == 1)
        //        this.Episode.CloseEpisode();


        //    #endregion PostTransition_New2PatientNoShown
        //}

        //protected void UndoTransition_New2PatientNoShown(TTObjectStateTransitionDef transitionDef)
        //{
        //    // From State : New   To State : PatientNoShown
        //    #region UndoTransition_New2PatientNoShown
        //    this.NoBackStateBack();
        //    #endregion UndoTransition_New2PatientNoShown
        //}
        protected void PostTransition_Examination2PatientNoShown()
        {
            // From State : New   To State : PatientNoShown
            #region PostTransition_Examination2PatientNoShown
            if (PatientExaminationType != PatientExaminationEnum.HealthCommittee)
            {
                if (SubEpisode != null && SubEpisode.PatientAdmission != null)
                    SubEpisode.PatientAdmission.PAStatus = PAStatusEnum.MuayeneyeGelmedi;
                if (SubEpisode.PatientAdmission.SEP != null && SubEpisode.PatientAdmission.SEP.SEPMaster != null)
                    SubEpisode.PatientAdmission.SEP.SEPMaster.deleteAllMedulaProvision();
            }
            CancelMyExaminationQueueItems();
            if (Episode.CurrentStateDefID == Episode.States.Open && Episode.PatientExaminations.Count == 1)
                Episode.CloseEpisode();


            #endregion PostTransition_Examination2PatientNoShown
        }

        protected void UndoTransition_Examination2PatientNoShown(TTObjectStateTransitionDef transitionDef)
        {
            // From State : New   To State : PatientNoShown
            #region UndoTransition_Examination2PatientNoShown
            NoBackStateBack();
            #endregion UndoTransition_Examination2PatientNoShown
        }
        protected void PreTransition_New2Examination()
        {
            // From State : New   To State : Examination
            #region PreTransition_New2Examination

            if (OlapDate == null)
                OlapDate = DateTime.Now;
            //Post Insert e taşındı. Doktor performansı düzenlemek gerekebilir.
            //this.AddPatientExaminationProcedure();

            if (!Paid())
                throw new TTUtils.TTException(TTUtils.CultureService.GetText("M25847", "Hastanın ödemesi gereken muayene bedeli mevcuttur, hastayı vezneye yönlendiriniz."));

            #endregion PreTransition_New2Examination
        }

        protected void PostTransition_FromExamination()
        {
            // From State : Examination   
            #region PostTransition_FromExamination

            CheckTriajAndChangeEmergencyInterventionState();
            //if (this.ProcessEndDate.HasValue == false && this.TreatmentResult != null)
            //    this.ProcessEndDate = Common.RecTime();
            foreach (PatientExaminationProcedure pep in PatientExaminationProcedures)
            {
                pep.AutoComplete();
            }
            if (SubEpisode != null && SubEpisode.PatientAdmission != null)
            {
                if (CurrentStateDefID == PatientExamination.States.ExaminationCompleted)
                    SubEpisode.PatientAdmission.PAStatus = PAStatusEnum.MuayenesiSonlandı;
                else if (CurrentStateDefID == PatientExamination.States.ProcedureRequested)
                    SubEpisode.PatientAdmission.PAStatus = PAStatusEnum.TetkikIstemDevam;
                else if (CurrentStateDefID == PatientExamination.States.Completed)
                    SubEpisode.PatientAdmission.PAStatus = PAStatusEnum.MuayenesiSonlandı;
            }

            if (SubEpisode != null && SendToENabiz())
            {
                new SendToENabiz(ObjectContext, SubEpisode, SubEpisode.ObjectID, SubEpisode.ObjectDef.Name, "103", Common.RecTime());
                new SendToENabiz(ObjectContext, SubEpisode, SubEpisode.ObjectID, SubEpisode.ObjectDef.Name, "106", Common.RecTime());
            }


            #endregion PostTransition_FromExamination
        }

        protected void PostTransition_ExaminationCompleted2ProcedureRequested()
        {
            #region PostTransition_ExaminationCompleted2ProcedureRequested

            if (SubEpisode != null && SubEpisode.PatientAdmission != null)
                SubEpisode.PatientAdmission.PAStatus = PAStatusEnum.TetkikIstemDevam;

            #endregion PostTransition_ExaminationCompleted2ProcedureRequested
        }

        #region Methods
        #region ICheckTreatmentMaterialIsEmpty Members
        public bool? GetIsTreatmentMaterialEmpty()
        {
            return IsTreatmentMaterialEmpty;
        }
        public void SetIsTreatmentMaterialEmpty(bool? value)
        {
            IsTreatmentMaterialEmpty = value;
        }

        public BaseTreatmentMaterial.ChildBaseTreatmentMaterialCollection GetTreatmentMaterials()
        {
            return TreatmentMaterials;
        }
        #endregion

        #region SMS İşlemleri

        public void ExaminationRegister(ResUser resUser)//Muayene Kayıt
        {
            var dateNow = Common.RecTime();
            BindingList<PatientExaminationDoctorInfo> doctorRecordForToday = PatientExaminationDoctorInfo.GetDoctorRecordForToday(ObjectContext, resUser.ObjectID);

            if (doctorRecordForToday.FirstOrDefault() != null)//Doktorun Bu güne ait kaydı varsa
            {
                doctorRecordForToday.FirstOrDefault().IsActiveFlag = true;
            }
            else//Doktorun Bu güne ait kaydı yoksa: ilk muayene kaydı ile kayıt oluşturuluyor
            {
                PatientExaminationDoctorInfo patientExaminationDoctor = new PatientExaminationDoctorInfo(ObjectContext);

                patientExaminationDoctor.ExaminationDate = Common.RecTime();
                patientExaminationDoctor.ExaminationFlag = false;//Muayene başladı mı?
                patientExaminationDoctor.IsSMSsendForChief = false;//Başhekim yardımcısına SMS Gönderildi mi?
                patientExaminationDoctor.IsSMSsendForDoctor = false;//Doktora SMS gönderildi mi?
                patientExaminationDoctor.IsSMSsendForResponsible = false;//İdari Sorumluya SMS gönderildi mi?
                patientExaminationDoctor.PatientExamination = this;
                patientExaminationDoctor.ResUser = resUser;
                patientExaminationDoctor.IsActiveFlag = true;//Sms işlemlerine dahil edilecek mi? true ise aktif
            }
            //using (var context = AtlasDbContextFactory.Instance.CreateDbContext())
            //{
            //    var doctorRecordForToday = context.PatientExaminationDoctorInfo.Where(p => p.ResUser.ObjectId == resUser.ObjectID && p.ExaminationDate.Value.Date == dateNow.Date).FirstOrDefault();


            //    if (doctorRecordForToday != null)//Doktorun Bu güne ait kaydı varsa
            //    {
            //        PatientExaminationDoctorInfo doctorRecordForTodayToSave = this.ObjectContext.GetObject<PatientExaminationDoctorInfo>(doctorRecordForToday.ObjectId);
            //        doctorRecordForTodayToSave.IsActiveFlag = true;
            //    }
            //    else//Doktorun Bu güne ait kaydı yoksa: ilk muayene kaydı ile kayıt oluşturuluyor
            //    {
            //        PatientExaminationDoctorInfo patientExaminationDoctor = new PatientExaminationDoctorInfo(ObjectContext);

            //        patientExaminationDoctor.ExaminationDate = Common.RecTime();
            //        patientExaminationDoctor.ExaminationFlag = false;//Muayene başladı mı?
            //        patientExaminationDoctor.IsSMSsendForChief = false;//Başhekim yardımcısına SMS Gönderildi mi?
            //        patientExaminationDoctor.IsSMSsendForDoctor = false;//Doktora SMS gönderildi mi?
            //        patientExaminationDoctor.IsSMSsendForResponsible = false;//İdari Sorumluya SMS gönderildi mi?
            //        patientExaminationDoctor.PatientExamination = this;
            //        patientExaminationDoctor.ResUser = resUser;
            //        patientExaminationDoctor.IsActiveFlag = true;//Sms işlemlerine dahil edilecek mi? true ise aktif


            //    }

            //}
        }

        public void ExaminationDone(ResUser resUser)//Muayene yapıldı
        {
            var dateNow = Common.RecTime();
            BindingList<PatientExaminationDoctorInfo> doctorRecordForToday = PatientExaminationDoctorInfo.GetDoctorRecordForToday(ObjectContext, resUser.ObjectID);

            if (doctorRecordForToday.Count > 0)
            {
                doctorRecordForToday.FirstOrDefault().ExaminationFlag = true;
            }
            else
            {
                var myInfo = ObjectContext.LocalQuery<PatientExaminationDoctorInfo>().Where(c => ((ITTObject)c).IsNew == true).ToArray();
                if (myInfo.Count() > 0)//Yeni oluşturulmuş kayıt -> doktor değişiminde oluşuyor
                {
                    myInfo.FirstOrDefault().ExaminationFlag = true;
                }
            }
        }

        public void ExaminationCancelled(ResUser resUser)//Muayene İptal Edildi
        {
            var dateNow = Common.RecTime();
            BindingList<PatientExaminationDoctorInfo> doctorRecordForToday = PatientExaminationDoctorInfo.GetDoctorRecordForToday(ObjectContext, resUser.ObjectID);
            BindingList<PatientExamination> doctorsDailyOpenExamination = PatientExamination.GetDoctorsDailyOpenExamination(ObjectContext, resUser.ObjectID);

            var doctorsExList = doctorsDailyOpenExamination.Where(x => x.CurrentStateDefID != PatientExamination.States.Cancelled && x.ObjectID != ObjectID);
            if (doctorRecordForToday.Count > 0 && doctorsExList.Count() > 0)//mevcut doktora ait kayıt varsa ve doktorun başka bekleyen iptal olmayan muayenesi varsa examination değiştirilir 
            {
                var examinationnotUnCompletedList = doctorsExList.Where(c => c.CurrentStateDefID == PatientExamination.States.Examination);
                var examinationnotCompletedList = doctorsExList.Where(c => c.CurrentStateDefID == PatientExamination.States.Completed || c.CurrentStateDefID == PatientExamination.States.ExaminationCompleted || c.CurrentStateDefID == PatientExamination.States.ProcedureRequested);

                doctorRecordForToday.FirstOrDefault().IsActiveFlag = true;
                doctorRecordForToday.FirstOrDefault().PatientExamination = (examinationnotUnCompletedList.Count() > 0) ? examinationnotUnCompletedList.FirstOrDefault() : doctorsExList.FirstOrDefault();
                doctorRecordForToday.FirstOrDefault().ExaminationFlag = (examinationnotCompletedList.Count() > 0) ? doctorRecordForToday.FirstOrDefault().ExaminationFlag : true;
            }
            else if (doctorRecordForToday.Count > 0 && doctorsExList.Count() == 0)//mevcut doktora ait kayıt varsa ama başka bekleyen muayenesi yoksa satır active false yapılır
            {
                doctorRecordForToday.FirstOrDefault().IsActiveFlag = false;
            }
        }

        #endregion SMS İşlemleri


        public virtual void CreateHCExaminationDynamicObject() // Sağlık Kurulu Ek alan objeleri için
        {
            if (PatientExaminationType == PatientExaminationEnum.HealthCommittee)
            {
                if (MasterAction is HealthCommittee)
                {
                    var _reason = ((HealthCommittee)MasterAction).HCRequestReason;

                    if (_reason != null && _reason.HCEReportType != null)
                    {

                        BaseHCExaminationDynamicObject hceBasedObject = null;
                        switch ((HCEDynamicReportTypeEnum)_reason.HCEReportType.Value)
                        {
                            case HCEDynamicReportTypeEnum.LowerExtremityReport://alt - üst Ektremite protez raporu birleştirildi
                                hceBasedObject = new LowerExtremity(ObjectContext);
                                break;
                                //case HCEDynamicReportTypeEnum.UpperExtremityReport:
                                //    hceBasedObject = new UpperExtremity(this.ObjectContext);
                                //    break;
                        }

                        if (hceBasedObject != null)
                        {
                            hceBasedObject.PatientExamination = this;
                        }
                    }

                }
            }

        }

        public bool CancelEDurumBildirirKurulExamination()
        {
            return EStatusNotRepCommitteeObj.DeleteEDurumBildirirKurulExamination(this, this.HCExaminationComponent.EStatusNotRepCommitteeObj, this.ObjectContext);
        }

        public void CheckTriajAndChangeEmergencyInterventionState()
        {
            if (EmergencyIntervention != null)
            {
                if (EmergencyIntervention.Triage == null || EmergencyIntervention.Triage.KODU == null)
                {
                    throw new Exception("Lütfen Triaj Kodu giriniz ");
                }
                else if (EmergencyIntervention.CurrentStateDefID == EmergencyIntervention.States.Triage)
                {
                    EmergencyIntervention.CurrentStateDefID = EmergencyIntervention.States.Observation;
                }
            }
        }

        public override ActionTypeEnum ActionType
        {
            get
            {
                if (PatientExaminationType == PatientExaminationEnum.Normal)
                    return ActionTypeEnum.PatientExamination;
                else if (PatientExaminationType == PatientExaminationEnum.Control)
                    return ActionTypeEnum.FollowUpExamination;
                else if (PatientExaminationType == PatientExaminationEnum.Emergency)
                    return ActionTypeEnum.EmergencyIntervention;
                else if (PatientExaminationType == PatientExaminationEnum.HealthCommittee)
                    return ActionTypeEnum.HealthCommitteeExamination;
                else if (PatientExaminationType == PatientExaminationEnum.Dental)
                    return ActionTypeEnum.DentalExamination;
                return ActionTypeEnum.PatientExamination;
            }
        }

        public List<AppointmentCarrier> AppointmentCarrierList
        {
            get
            {
                List<AppointmentCarrier> _appointmentList = new List<AppointmentCarrier>();
                TTObjectContext context = new TTObjectContext(false);
                AppointmentDefinition appDef = null;
                IList appDefList = AppointmentDefinition.GetAppointmentDefinitionByName(context, AppointmentDefinitionEnum.PatientExamination);
                if (appDefList.Count > 0)
                {
                    appDef = (AppointmentDefinition)appDefList[0];
                    foreach (AppointmentCarrier appCarrier in appDef.AppointmentCarriers)
                    {
                        _appointmentList.Add(appCarrier);
                    }
                }

                if (_appointmentList.Count == 0)
                {
                    AppointmentCarrier carrier = new AppointmentCarrier(context);
                    carrier.MasterResource = "ResSection";
                    carrier.SubResource = "ResUser";
                    carrier.RelationParentName = "";
                    carrier.UserTypes.Add(UserTypeEnum.Doctor);
                    carrier.UserTypes.Add(UserTypeEnum.Nurse);

                    _appointmentList.Add(carrier);
                }
                ClearAppointmentCarrierDynamicFields(_appointmentList);
                foreach (AppointmentCarrier appointmentCarrier in _appointmentList)
                {
                    appointmentCarrier.DefaultAppointmentDefinition = appDef;
                    appointmentCarrier.DefaultMasterResource = MasterResource;
                    appointmentCarrier.DefaultResource = ProcedureDoctor;
                    if (MasterResource != null)
                    {
                        appointmentCarrier.MasterResourceFilter = " OBJECTID = '" + MasterResource.ObjectID.ToString() + "'";
                    }
                    else
                    {
                        appointmentCarrier.MasterResourceFilter = "";
                    }
                    break;
                }
                return _appointmentList;
            }
        }

        #region IAppointmentDef Members
        public List<AppointmentCarrier> GetAppointmentCarrierList()
        {
            return AppointmentCarrierList;
        }
        #endregion

        public AppointmentTypeEnum NumaratorAppointmentType
        {
            get { return AppointmentTypeEnum.Examination; }
        }

        public Resource NumaratorAppointmentMasterResource
        {
            get { return MasterResource; }// İşlemin yapıuldığı Poliklinik aynı zamanada randevu verilecek üst kaynakdır
        }

        public Resource NumaratorAppointmentResource
        {
            get
            {
                if (ProcedureDoctor == null)
                {
                    TTObjectContext roContext = new TTObjectContext(true);
                    BindingList<TTObjectClasses.Appointment.GetMinNumaratorAppointmentResource_Class> minAppResource = Appointment.GetMinNumaratorAppointmentResource(roContext, MasterResource.ObjectID, Common.RecTime().Date, Common.RecTime().Date.AddDays(1));
                    if (minAppResource.Count > 0)
                    {
                        foreach (TTObjectClasses.Appointment.GetMinNumaratorAppointmentResource_Class minNumApp in minAppResource)
                        {
                            Resource resource = (Resource)roContext.GetObject(minNumApp.Resource.Value, typeof(Resource));
                            if (resource is ResUser)
                            {
                                ProcedureDoctor = (ResUser)resource;
                                break;
                            }
                        }
                    }

                    if (ProcedureDoctor == null)
                    {
                        IList<ResUser> userList = (IList<ResUser>)ResUser.GetByUserResourceAndUserType(roContext, UserTypeEnum.Doctor, MasterResource.ObjectID.ToString());
                        foreach (ResUser resUser in userList)
                        {
                            ProcedureDoctor = (ResUser)resUser;
                            break;
                        }
                    }
                }
                return ProcedureDoctor;
            }
            // işlemi yapan doktor aynı zamanda randevu verilecek kişidir
        }

        //        private void CreateNursingOrderDetailsAndCompleteOrder()
        //        {
        //            foreach(PatientExaminationNursingOrder examinationNursingOrder in this._NursingOrders)
        //            {
        //                if (examinationNursingOrder.CurrentStateDefID == PatientExaminationNursingOrder.States.New)
        //                {
        //                    examinationNursingOrder.CreateOrderDetails();
        //                    examinationNursingOrder.CurrentStateDefID = PatientExaminationNursingOrder.States.Planned;
        //                }
        //            }
        //        }



        public override void CompleteMyNewAppoinments()
        {
            if (TransDef != null)
            {
                foreach (Appointment app in GetMyNewAppointments())
                {
                    //if (this.TransDef.ToStateDef.Status == StateStatusEnum.CompletedUnsuccessfully || this.TransDef.ToStateDef.Status == StateStatusEnum.Cancelled || this.TransDef.ToStateDefID == PatientExamination.States.New)
                    if (TransDef.ToStateDef.Status == StateStatusEnum.CompletedUnsuccessfully || TransDef.ToStateDef.Status == StateStatusEnum.Cancelled || TransDef.ToStateDefID == PatientExamination.States.Examination)
                    {
                        app.CurrentStateDefID = Appointment.States.Cancelled;
                    }
                    else if (TransDef.ToStateDef.Status == StateStatusEnum.Uncompleted || TransDef.ToStateDef.Status == StateStatusEnum.CompletedSuccessfully)
                    {

                        app.CurrentStateDefID = Appointment.States.Completed;
                    }
                }
            }
        }

        public override void CompleteMyNewAppoinments(TTObjectStateTransitionDef transDef)
        {
            if (transDef != null)
            {
                foreach (Appointment app in GetMyNewAppointments())
                {
                    //if (transDef.ToStateDef.Status == StateStatusEnum.CompletedUnsuccessfully || transDef.ToStateDef.Status == StateStatusEnum.Cancelled || transDef.ToStateDefID == PatientExamination.States.New)
                    if (transDef.ToStateDef.Status == StateStatusEnum.CompletedUnsuccessfully || transDef.ToStateDef.Status == StateStatusEnum.Cancelled || transDef.ToStateDefID == PatientExamination.States.Examination)
                    {
                        app.CurrentStateDefID = Appointment.States.Cancelled;
                    }
                    if (transDef.ToStateDef.Status == StateStatusEnum.Uncompleted || transDef.ToStateDef.Status == StateStatusEnum.CompletedSuccessfully)
                    {

                        app.CurrentStateDefID = Appointment.States.Completed;
                    }
                }
            }
        }

        public override void CompleteMyUnCompletedAppoinments()
        {
            if (TransDef != null)
            {
                foreach (Appointment app in GetMyNewAppointments())
                {
                    if (TransDef.ToStateDef.Status == StateStatusEnum.CompletedUnsuccessfully || TransDef.ToStateDef.Status == StateStatusEnum.Cancelled || (PrevState != null && TransDef.ToStateDefID == PrevState.StateDefID))
                    {
                        app.CurrentStateDefID = Appointment.States.Cancelled;
                    }
                    if (TransDef.ToStateDef.Status == StateStatusEnum.Uncompleted || TransDef.ToStateDef.Status == StateStatusEnum.CompletedSuccessfully)
                    {
                        app.CurrentStateDefID = Appointment.States.Completed;
                    }
                }
                foreach (Appointment app in MyNotApprovedAppointments())
                {
                    if (TransDef.ToStateDef.Status == StateStatusEnum.CompletedUnsuccessfully || TransDef.ToStateDef.Status == StateStatusEnum.Cancelled || (PrevState != null && TransDef.ToStateDefID == PrevState.StateDefID))
                    {
                        app.CurrentStateDefID = Appointment.States.Cancelled;
                    }
                    if (TransDef.ToStateDef.Status == StateStatusEnum.Uncompleted || TransDef.ToStateDef.Status == StateStatusEnum.CompletedSuccessfully)
                    {
                        app.CurrentStateDefID = Appointment.States.Completed;
                    }
                }
            }
            else
            {
                foreach (Appointment app in GetMyNewAppointments())
                    app.CurrentStateDefID = Appointment.States.Completed;
                foreach (Appointment app in MyNotApprovedAppointments())
                    app.CurrentStateDefID = Appointment.States.Completed;
            }
        }


        public override void Cancel()
        {
            if (SubEpisode.IsInvoicedCompletely)
                throw new Exception("Faturalanmış işlem iptal edilemez.");

            ///<summary>
            ///Sağlık kurulu işlemi ilk adımda ise kayıt kabuldeki ilgili satır silinince ona ait muayeneyi de iptal etmeli.
            ///Diğer episodeactionları kontrol etmesine gerek yok
            ///</summary>
            if (PatientExaminationType != PatientExaminationEnum.HealthCommittee)//
            {
                if (SubEpisode.EpisodeActions != null && SubEpisode.EpisodeActions.Count > 1)
                {
                    foreach (EpisodeAction ea in SubEpisode.EpisodeActions)
                    {
                        if (!ea.ObjectID.Equals(ObjectID) && ea.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                        {
                            if (ea is EmergencyIntervention && ea.CurrentStateDefID == EmergencyIntervention.States.Triage)
                            {
                                ea.CurrentStateDefID = EmergencyIntervention.States.Cancelled;//Hasta gelmedilerde triage işlemi iptal edilsin
                                ea.Cancel();
                            }
                            else
                                throw new Exception("Bu işlemi iptal edebilmek için öncelikle alt vaka altındaki diğer işlemleri iptal etmeniz gerekmektedir.");
                        }
                    }
                }

                if (SubEpisode.SubActionProcedures != null && SubEpisode.SubActionProcedures.Count > 1)
                {
                    foreach (SubActionProcedure sp in SubEpisode.SubActionProcedures)
                    {
                        if (sp is SubactionProcedureFlowable && sp.IsCancelled == false)
                            throw new Exception("Bu işlemi iptal edebilmek için öncelikle alt vaka altındaki diğer hizmetleri iptal etmeniz gerekmektedir.");
                    }
                }
            }

            if (MuayeneGiris != null)
            {
                if (MuayeneGiris.CurrentStateDefID == MuayeneGiris.States.SentServer)
                    throw new Exception(SystemMessage.GetMessage(912));
            }
            foreach (SingleNursingOrder singleNursingOrder in SingleNursingOrders)
            {
                singleNursingOrder.Cancel();
            }

            bool setMainSpecialityNull = true;
            foreach (PatientExamination pe in Episode.PatientExaminations)
            {
                if (pe.CurrentStateDef.Status != StateStatusEnum.Cancelled && pe.ObjectID != ObjectID)
                {
                    setMainSpecialityNull = false;
                    break;
                }
            }
            if (Episode.InPatientTreatmentClinicApplications.Count > 0)
                setMainSpecialityNull = false;
            if (setMainSpecialityNull)
                Episode.MainSpeciality = null;

            /* kpayi --- this.CancelMedulaPatientParticipation(); */

            QuotaHistory quota = CheckIfQuotaReturn();
            if (quota != null)
            {
                ((ITTObject)quota).Delete();
                MasterResource.DailyQuota++;
                MasterResource.MonthlyQuota++;
            }
            base.Cancel();

        }
        public void SetResponsibleDoctorAsProcedureDoctor()
        {
            if (ProcedureDoctor != null && ProcedureDoctor != ResponsibleDoctor)
                ResponsibleDoctor = ProcedureDoctor;
        }

        public void SetPatientExaminationStatus()
        {
            if (PatientAdmission.AdmissionStatus == AdmissionStatusEnum.Acil)
                PatientExaminationType = PatientExaminationEnum.Emergency;
            else if (PatientAdmission.AdmissionStatus == AdmissionStatusEnum.DisKabulu)
                PatientExaminationType = PatientExaminationEnum.Dental;
            else if (PatientAdmission.AdmissionStatus == AdmissionStatusEnum.Kontrol)
                PatientExaminationType = PatientExaminationEnum.Control;
            else if (PatientAdmission.AdmissionStatus == AdmissionStatusEnum.SaglikKurulu)
                PatientExaminationType = PatientExaminationEnum.HealthCommittee;
            else if (PatientAdmission.AdmissionStatus == AdmissionStatusEnum.HizmetProtokol)
                PatientExaminationType = PatientExaminationEnum.Dispatch;
            else
                PatientExaminationType = PatientExaminationEnum.Normal;
        }

        // Muayene katılım payı prosedürünü oluşturur
        public void AddPatientExaminationParticipationProcedure()
        {
            if (IsOldAction == true)
                return;

            if (SubEpisode.PatientAdmission.AdmissionStatus != AdmissionStatusEnum.Normal) // Kontrol muayenesi için katılım payı oluşturulmaz
                return;

            if (SystemParameter.IsPatientExaminationParticipationControl)
            {
                SubEpisodeProtocol sep = SubEpisode.OpenSubEpisodeProtocol;

                if (sep == null)
                    throw new TTException(SystemMessage.GetMessage(663));

                if (sep.Payer.GetPatientParticipation == true || (sep.MedulaIstisnaiHal != null && sep.MedulaIstisnaiHal.Kodu == "9"
                    && sep.MedulaProvizyonTipi != null && sep.MedulaProvizyonTipi.provizyonTipiKodu == "N" && !string.IsNullOrEmpty(sep.MedulaTakipNo))) // Kurum tanımındaki "Hastaya Katılım Payı Hizmeti Oluşturulur" işaretli ise
                {
                    Guid muayeneKatılımPayıGuid = ProcedureDefinition.ExaminationParticipationProcedureObjectId;

                    foreach (PatientExaminationProcedure pep in PatientExaminationProcedures)
                    {
                        if (pep.CurrentStateDef.Status != StateStatusEnum.Cancelled && pep.ProcedureObject.ObjectID == muayeneKatılımPayıGuid) // Hizmet zaten varsa tekrar oluşturulmaz
                            return;
                    }

                    PatientExaminationProcedure examProc = new PatientExaminationProcedure(this, muayeneKatılımPayıGuid.ToString());
                    examProc.AccountOperation(AccountOperationTimeEnum.PREPOST);
                }
            }

            /*  Eski kontrol kodları kapatıldı (MDZ)
            // Acil hastalar (Hasta Grubu veya kabul sebebi acil olanlar) ve Portör Muayenesi için Muayene Katılım Payı oluşturulmayacak
            if (this.Episode.PatientGroup != PatientGroupEnum.Emergency && this.Episode.ReasonForAdmission.Type != AdmissionTypeEnum.Emergency && this.Episode.ReasonForAdmission.Type != AdmissionTypeEnum.PortorExamination && this.Episode.Patient.IsNewBorn != true)
            {
                // Tutuklu ve Adli Vakalarda da katılım payı alınmamalı
                if (this.Episode.ReasonForAdmission.Type != AdmissionTypeEnum.Arrested && this.Episode.ReasonForAdmission.Type != AdmissionTypeEnum.JudicialObservation && this.Episode.ReasonForAdmission.Type != AdmissionTypeEnum.JudicialObservationFileInvestigation && this.SubEpisode.PatientAdmission.Arrested != true)
                {
                    if (this.SubEpisode.PatientAdmission.ParticipationType != null)
                    {
                        foreach (PatientExamParticipDetail pgrid in this.SubEpisode.PatientAdmission.ParticipationType.Relationships)
                        {
                            if (this.SubEpisode.PatientAdmission.HaveRelationshipProperty()) // yakınlık derecesi varsa set edilir
                                relationshipDefinition = this.Episode.Relationship;

                            if (relationshipDefinition == null)
                            {
                                // Yakınlık derecesi hasta kabul forumunda yoksa Default yakınlık derecesini 'Kendisi' olarak atanır
                                Guid defaultRelationshipGuid = new Guid("{434014dc-596b-4c08-9e5e-76de439893dc}");
                                relationshipDefinition = (RelationshipDefinition)this._objectContext.GetObject(defaultRelationshipGuid, "RELATIONSHIPDEFINITION");
                            }

                            if (relationshipDefinition == pgrid.Relationship)
                            {
                                if (this.SubEpisode.PatientAdmission.ParticipationType.OnlyForDefinedUnits == true)
                                {
                                    foreach (PatientExamParticipUnit unit in this.SubEpisode.PatientAdmission.ParticipationType.Units)
                                    {
                                        if (unit.ResSection != null && this.MasterResource != null)
                                        {
                                            if (unit.ResSection.ObjectID == this.MasterResource.ObjectID)
                                            {
                                                hasParticipation = false;
                                                break;
                                            }
                                        }
                                    }
                                }
                                else
                                    hasParticipation = false;
                                break;
                            }
                        }
                    }
                }
            } */
        }

        // Normal muayene prosedürünü oluşturur
        public void AddPatientExaminationProcedure()
        {
            if (IsOldAction == true)
                return;

            // Acilden başlatılmış ise PatientExaminationProcedure ın oluşmaması için yapıldı NE
            if (EmergencyIntervention != null)
                return;
            // Dışarıdan gelen sevk ise PE procedure başlamamalı
            if (SubEpisode.PatientAdmission.AdmissionStatus == AdmissionStatusEnum.HizmetProtokol)
                return;

            Guid muayeneGuid;

            if (SubEpisode.PatientAdmission.AdmissionStatus == AdmissionStatusEnum.Kontrol)
                muayeneGuid = ProcedureDefinition.FollowUpExaminationProcedureObjectId;
            else
                muayeneGuid = ProcedureDefinition.ExaminationProcedureObjectId;

            foreach (PatientExaminationProcedure pep in PatientExaminationProcedures)
            {
                if (pep.CurrentStateDef.Status != StateStatusEnum.Cancelled && pep.ProcedureObject.ObjectID == muayeneGuid) // Hizmet zaten varsa tekrar oluşturulmaz
                    return;
            }

            PatientExaminationProcedure examProc = new PatientExaminationProcedure(this, muayeneGuid.ToString());

            //if (Episode.OpeningDate != null)   // Kontrol muayenesi için episode.openingdate i set etmek doğru olmadığından kapatıldı (MDZ)
            //    examProc.PricingDate = Episode.OpeningDate;

            examProc.AccountOperation(AccountOperationTimeEnum.PREPOST);

            if (SubEpisode.PatientAdmission.AdmissionStatus == AdmissionStatusEnum.Kontrol)
            {
                foreach (AccountTransaction accTrx in examProc.AccountTransactions)
                    accTrx.OzelDurum = OzelDurum.GetOzelDurum("1");
            }
        }
        public void AddDailyBedProcedure()
        {
            if (IsOldAction == true)
                return;

            Guid muayeneGuid = ProcedureDefinition.DailyBedProcedureObjectId;


            foreach (PatientExaminationProcedure pep in PatientExaminationProcedures)
            {
                if (pep.CurrentStateDef.Status != StateStatusEnum.Cancelled && pep.ProcedureObject.ObjectID == muayeneGuid) // Hizmet zaten varsa tekrar oluşturulmaz
                    return;
            }

            PatientExaminationProcedure examProc = new PatientExaminationProcedure(this, muayeneGuid.ToString());

            //if (Episode.OpeningDate != null)   // Kontrol muayenesi için episode.openingdate i set etmek doğru olmadığından kapatıldı (MDZ)
            //    examProc.PricingDate = Episode.OpeningDate;

            examProc.AccountOperation(AccountOperationTimeEnum.PREPOST);

        }
        /* kpayi --- public void AddMedulaPatientParticipation()
        {
            if (this.Episode.Patient.Foreign != true)
            {
                if (!this.Episode.IsMedulaPatientParticipationExists())
                {
                    this.MuayeneGiris = new MuayeneGiris(ObjectContext);
                    this.MuayeneGiris.HealthFacilityID = SystemParameter.GetSaglikTesisKodu();
                    this.MuayeneGiris.CurrentStateDefID = MuayeneGiris.States.New;

                    if (this.Episode.Patient.UniqueRefNo != null)
                        this.MuayeneGiris.muayeneGirisDVO.hastaTCKimlikNo = this.Episode.Patient.UniqueRefNo.ToString();

                    if (this.RequestDate != null)
                        this.MuayeneGiris.muayeneGirisDVO.muayeneTarihiDateTime = this.RequestDate;
                    else
                    {
                        if (this.Episode.OpeningDate != null)
                            this.MuayeneGiris.muayeneGirisDVO.muayeneTarihiDateTime = this.Episode.OpeningDate;
                    }

                    if (this.ID.Value.HasValue)
                        this.MuayeneGiris.muayeneGirisDVO.referansNo = this.ID.Value;

                    if (this.Episode.PatientGroup == PatientGroupEnum.GeneralAdmiral || this.Episode.PatientGroup == PatientGroupEnum.RetiredGeneral || this.Episode.PatientGroup == PatientGroupEnum.GeneralAdmiralFamily || this.Episode.PatientGroup == PatientGroupEnum.RetiredGeneralFamily)
                        this.MuayeneGiris.muayeneGirisDVO.gizliTutulsunmu = true;
                    else
                        this.MuayeneGiris.muayeneGirisDVO.gizliTutulsunmu = false;

                    this.MuayeneGiris.muayeneGirisDVO.saglikTesisKodu = SystemParameter.GetSaglikTesisKodu();
                }
            }
        }

        public void CancelMedulaPatientParticipation()
        {
            if (this.MuayeneGiris != null)
            {
                this.MuayeneGiris.CurrentStateDefID = MuayeneGiris.States.Cancelled;

                // Bu muayene iptal edildiği için, episode da başka muayene varsa ona MuayeneGiris oluşturmak gerekir
                this.Episode.AddOrCancelMedulaPatientParticipation();
            }
        }

        public void UpdateMedulaPatientParticipationToSentServer()
        {
            if (this.MuayeneGiris != null)
            {
                if (this.ID.Value.HasValue)
                    this.MuayeneGiris.muayeneGirisDVO.referansNo = this.ID.Value;

                if (this.MuayeneGiris.CurrentStateDefID == MuayeneGiris.States.New)
                    this.MuayeneGiris.CurrentStateDefID = MuayeneGiris.States.SentServer;
            }
        } */



        //        protected override List<OldActionPropertyObject> OldActionPropertyList()
        //        {
        //            List<OldActionPropertyObject> propertyList;
        //            if(base.OldActionPropertyList()==null)
        //                propertyList = new List<OldActionPropertyObject>();
        //            else
        //                propertyList = base.OldActionPropertyList();
        //            propertyList.Add(new OldActionPropertyObject("Protokol No",Common.ReturnObjectAsString(this.ProtocolNo)));
        //            propertyList.Add(new OldActionPropertyObject("Muayene Tarihi",Common.ReturnObjectAsString(this.ProcessDate)));
        //            propertyList.Add(new OldActionPropertyObject("Şikayeti",Common.ReturnObjectAsString(Complaint)));
        //            propertyList.Add(new OldActionPropertyObject("Hasta Dosyası",Common.ReturnObjectAsString(PatientFolder)));
        //            propertyList.Add(new OldActionPropertyObject("Fizik Muayene",Common.ReturnObjectAsString(PhysicalExamination)));
        //            return propertyList;
        //        }
        /* protected override List<List<List<OldActionPropertyObject>>> OldActionChildRelationList()
        {
            // Her bir gridi tutacak Liste
            List<List<List<OldActionPropertyObject>>> gridList;
            if(base.OldActionChildRelationList()==null)
                gridList=new List<List<List<OldActionPropertyObject>>>();
            else
                gridList=base.OldActionChildRelationList();
            gridList.Add(this.OldActionPreDiagnosisList());
            gridList.Add(this.OldActionSecDiagnosisList());
            return gridList;
        }*/

        protected override void BeforeSetSubEpisode(SubEpisode subEpisode)
        {
            base.BeforeSetSubEpisode(subEpisode);
            //    int countLimit = 0;
            //    string scount = "birden";
            //    int count = 0;

            //    foreach (PatientExamination pe in subEpisode.Episode.PatientExaminations)
            //    {
            //        if (pe.CurrentStateDef.Status != StateStatusEnum.Cancelled && pe.CurrentStateDef.Status != StateStatusEnum.CompletedUnsuccessfully)
            //        {
            //            count++;
            //            if (count > countLimit && this.PatientExaminationType != null && this.PatientExaminationType != PatientExaminationEnum.Emergency && this.PatientExaminationType != PatientExaminationEnum.HealthCommittee)
            //                //&& this.MasterAction != null && !(this.MasterAction is EmergencyIntervention) && !(this.MasterAction is HealthCommittee))
            //                throw new Exception(SystemMessage.GetMessageV2(702, scount.ToString()));
            //        }
            //    }
        }

        //TODO: Daha sonra değerlendirilecek.
        //        public void PrintTreatmentMaterialsReport()
        //        {
        //            if (this.CurrentStateDefID.Equals(PatientExamination.States.Completed) && this.TreatmentMaterials.Count > 1)
        //            {
        //                Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
        //                TTReportTool.PropertyCache<object> objectID = new TTReportTool.PropertyCache<object>();
        //                objectID.Add("VALUE", this.ObjectID.ToString());
        //                parameters.Add("TTOBJECTID", objectID);
        //                TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_TreatmentMaterialReport), true, 1, parameters);
        //            }
        //
        //        }



        public override void AddSpecialProcedure(ResUser procedureDoctor)
        {
            ProcedureDefinition specialProcedure = null;
            bool charge = true;
            bool delete = false;
            PatientExaminationProcedure spatientExaminationProcedure = null;
            if (procedureDoctor.Title != null)
            {

                IList titleProcList = TitleParticipationProcDef.GetByTitle(ObjectContext, (UserTitleEnum)procedureDoctor.Title);
                foreach (TitleParticipationProcDef titleProcDef in titleProcList)
                {
                    specialProcedure = titleProcDef.ProcedureObject;
                    break;
                }
            }

            foreach (PatientExaminationProcedure patientExaminationProcedure in PatientExaminationProcedures)
            {
                foreach (TitleParticipationProcDef procDef in TitleParticipationProcDef.GetTitleParticipationProcDefinitions(ObjectContext))
                {
                    if (patientExaminationProcedure.ProcedureObject == procDef.ProcedureObject)
                    {
                        if (specialProcedure == null)
                        {
                            ((ITTObject)patientExaminationProcedure).Cancel();
                            charge = false;
                        }
                        else
                        {
                            if (patientExaminationProcedure.ProcedureObject != specialProcedure)
                            {
                                ((ITTObject)patientExaminationProcedure).Cancel();
                                charge = true;
                            }
                            else
                                charge = false;
                        }
                    }
                }
            }

            if (specialProcedure != null && charge && SubEpisode != null && SubEpisode.OpenSubEpisodeProtocol != null && SubEpisode.OpenSubEpisodeProtocol.Protocol.SpecialExamination == true)
                spatientExaminationProcedure = new PatientExaminationProcedure(this, specialProcedure.ObjectID.ToString());
        }





        /*
         * MEDULA SEVK KAYIT IPTAL METODU
         * */

        public bool MedulaESevkKayitIptalSync()
        {

            try
            {
                SevkIslemleri.sevkIptalCevapDVO sevkIptalCevapDVO = SevkIslemleri.WebMethods.sevkKayitIptalSync(TTObjectClasses.Sites.SiteLocalHost, GetSevkKayitIptalDVO());
                if (sevkIptalCevapDVO != null)
                {
                    if (string.IsNullOrEmpty(sevkIptalCevapDVO.sonucKodu) == false)
                    {
                        if (sevkIptalCevapDVO.sonucKodu.Equals("0000"))
                        {
                            TTUtils.InfoMessageService.Instance.ShowMessage("Sevk Takip No: " + SubEpisode.PatientAdmission.SEP.MedulaTakipNo + " , E-Sevk No: " + MedulaESevkNo + " olan sevkin iptal işlemi başarı ile sonuçlandı.");
                            MedulaESevkNo = null;
                            return true;
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(sevkIptalCevapDVO.sonucMesaji) == false)
                                throw new Exception(TTUtils.CultureService.GetText("M26926", "Sonuç Mesajı :") + sevkIptalCevapDVO.sonucMesaji);
                            else
                                throw new Exception("Sonuç mesajı alanı boş! Sonuç Kodu: " + sevkIptalCevapDVO.sonucKodu);
                        }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(sevkIptalCevapDVO.sonucMesaji) == false)
                            throw new Exception(" Sonuç Mesajı :" + sevkIptalCevapDVO.sonucMesaji);
                        else
                            throw new Exception(TTUtils.CultureService.GetText("M26848", "Sevk bildirimi iptal işleminde hata var.Sonuç Kodu ve sonuç mesajı alanları boş!"));

                    }
                }
                else
                    throw new Exception("Medulaya sevk bildirimi iptal işlemi yapılamadı.Cevap dönmedi!");

            }
            catch (Exception e)
            {
                throw new Exception("Medula sevk bildirimi iptal işlemi sırasında hata oluştu! " + e.Message);
            }
        }

        /*
         * MEDULA SEVK KAYIT IPTAL DVO HAZIRLANMASI
         * */

        public SevkIslemleri.sevkKayitIptalDVO GetSevkKayitIptalDVO()
        {
            SevkIslemleri.sevkKayitIptalDVO sevkKayitIptalDVO = new SevkIslemleri.sevkKayitIptalDVO();

            if (Episode != null && SubEpisode != null && SubEpisode.FirstSubEpisodeProtocol != null
                && SubEpisode.FirstSubEpisodeProtocol.MedulaTakipNo != null && SubEpisode.FirstSubEpisodeProtocol.MedulaTakipNo != null
                && MedulaESevkNo != null)
            {
                sevkKayitIptalDVO.sevkTakipNo = SubEpisode.FirstSubEpisodeProtocol.MedulaTakipNo;
            }
            else
            {
                throw new Exception("Medulaya sevk bildirimi yapılmamış. Öncelikle bildirimi yapmalısınız!");
            }

            sevkKayitIptalDVO.saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();

            return sevkKayitIptalDVO;
        }



        /*
         * MEDULA MUTAT DIŞI ARAÇ RAPOR SIL METODU
         * */

        public bool MutatDisiAracRaporSilSync()
        {

            try
            {
                SevkIslemleri.mutatDisiIptalCevapDVO mutatDisiIptalCevapDVO = SevkIslemleri.WebMethods.mutatDisiAracRaporSilSync(TTObjectClasses.Sites.SiteLocalHost, GetMutatDisiRaporIptalDVO());
                if (mutatDisiIptalCevapDVO != null)
                {
                    if (string.IsNullOrEmpty(mutatDisiIptalCevapDVO.sonucKodu) == false)
                    {
                        if (mutatDisiIptalCevapDVO.sonucKodu.Equals("0000"))
                        {
                            TTUtils.InfoMessageService.Instance.ShowMessage("Mutat dışı araç rapor id: " + MedulaMutatDisiAracRaporNo + " olan raporun silme işlemi başarı ile sonuçlandı.");
                            MedulaMutatDisiAracRaporNo = null;
                            return true;
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(mutatDisiIptalCevapDVO.sonucMesaji) == false)
                                throw new Exception(TTUtils.CultureService.GetText("M26926", "Sonuç Mesajı :") + mutatDisiIptalCevapDVO.sonucMesaji);
                            else
                                throw new Exception("Sonuç mesajı alanı boş! Sonuç Kodu: " + mutatDisiIptalCevapDVO.sonucKodu);
                        }
                    }
                    else
                    {

                        if (string.IsNullOrEmpty(mutatDisiIptalCevapDVO.sonucMesaji) == false)
                            throw new Exception(TTUtils.CultureService.GetText("M26926", "Sonuç Mesajı :") + mutatDisiIptalCevapDVO.sonucMesaji);
                        else
                            throw new Exception(TTUtils.CultureService.GetText("M26931", "Sonuç mesajı ve Sonuç Kodu alanları boş!"));
                    }
                }
                else
                    throw new Exception("Medulaya mutat dışı araç rapor silme işlemi yapılamadı.Cevap dönmedi!");
            }
            catch (Exception e)
            {
                throw new Exception("Medulaya mutat dışı araç rapor silme işlemi sırasında hata oluştu! " + e.Message);
            }

        }

        /*
         * MEDULA MUTAT DIŞI RAPOR IPTAL DVO HAZIRLANMASI
         * */
        public SevkIslemleri.mutatDisiRaporIptalDVO GetMutatDisiRaporIptalDVO()
        {
            SevkIslemleri.mutatDisiRaporIptalDVO mutatDisiRaporIptalDVO = new SevkIslemleri.mutatDisiRaporIptalDVO();
            if (MedulaMutatDisiAracRaporNo != null && !MedulaMutatDisiAracRaporNo.Equals("0"))
            {
                mutatDisiRaporIptalDVO.raporID = Convert.ToInt32(MedulaMutatDisiAracRaporNo);
            }
            else
            {
                throw new Exception("Medulaya mutat dışı araç rapor kaydı yapılmamış. Öncelikle kayıt yapmalısınız!");
            }

            mutatDisiRaporIptalDVO.saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();

            return mutatDisiRaporIptalDVO;
        }





        /*
         * MEDULA SEVK KAYIT METODU
         * */

        public bool MedulaSevkKayitSync()
        {

            try
            {
                SevkIslemleri.sevkCevapDVO sevkCevapDVO = SevkIslemleri.WebMethods.sevkKayitSync(TTObjectClasses.Sites.SiteLocalHost, GetSevkKayitDVO());
                if (sevkCevapDVO != null)
                {
                    if (string.IsNullOrEmpty(sevkCevapDVO.sonucKodu) == false)
                    {
                        if (sevkCevapDVO.sonucKodu.Equals("0000"))
                        {
                            TTUtils.InfoMessageService.Instance.ShowMessage("E-sevk kayıt işlemi başarı ile sonuçlandı.  Sevk Takip No: " + sevkCevapDVO.sevkTakipNo + "  E-Sevk No: " + sevkCevapDVO.esevkNo.ToString());
                            MedulaESevkNo = sevkCevapDVO.esevkNo.ToString();
                            return true;
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(sevkCevapDVO.sonucMesaji) == false)
                                throw new Exception("E-sevk kayıt işleminde hata var: Sonuç Mesajı :" + sevkCevapDVO.sonucMesaji);
                            else
                                throw new Exception("E-sevk kayıt işleminde hata var");
                        }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(sevkCevapDVO.sonucMesaji) == false)
                            throw new Exception("E-sevk kayıt işleminde hata var:Sonuç Mesajı :" + sevkCevapDVO.sonucMesaji);
                        else
                            throw new Exception("E-sevk kayıt işleminde hata var");
                    }
                }
                else
                    throw new Exception("Medulaya e-sevk kayıt işlemi yapılamadı!");

            }
            catch (Exception e)
            {
                throw new Exception("Medulaya e-sevk kayıt işlemi sırasında sistem hatası oluştu! Hata: " + e.Message);
            }
            //return false;
        }


        /*
         * MEDULA SEVK KAYIT DVO HAZIRLANMASI
         * */

        public SevkIslemleri.sevkKayitDVO GetSevkKayitDVO()
        {

            SevkIslemleri.sevkKayitDVO sevkKayitDVO = new SevkIslemleri.sevkKayitDVO();

            // takip no
            if (Episode != null && SubEpisode != null && SubEpisode.FirstSubEpisodeProtocol != null && SubEpisode.FirstSubEpisodeProtocol.MedulaTakipNo != null)
                sevkKayitDVO.kabulTakipNo = SubEpisode.FirstSubEpisodeProtocol.MedulaTakipNo;
            else
                throw new Exception("Medulaya e-sevk  kayıt işleminde kabul takip no alanı dolu olmalıdır!");

            // donusVasitasi
            if (MedulaSevkDonusVasitasi != null && MedulaSevkDonusVasitasi.sevkVasitasiKodu != null)
                sevkKayitDVO.donusVasitasi = Convert.ToInt32(MedulaSevkDonusVasitasi.sevkVasitasiKodu);
            else
                throw new Exception("Medulaya e-sevk kayıt işleminde dönüş vasıtası alanı dolu olmalıdır!");

            //if (this.MedulaRefakatciDurumu != null && this.MedulaRefakatciDurumu.Value != null)
            if (MedulaRefakatciDurumu != null)
            {
                if (MedulaRefakatciDurumu.Value == true)
                    sevkKayitDVO.refakatci = "E";
                else
                    sevkKayitDVO.refakatci = "H";
            }
            else
                throw new Exception("Medulaya e-sevk kayıt işleminde refakatçi durumu alanı dolu olmalıdır!");

            //* ayrilisTarihi
            String ayrilisTarihi = Common.RecTime().ToShortDateString();
            if (string.IsNullOrEmpty(ayrilisTarihi) == false)
                sevkKayitDVO.ayrilisTarihi = ayrilisTarihi;
            else
                throw new Exception("Medulaya e-sevk kaydı yapılabilmesi için; XXXXXXden ayrılış tarihi dolu olmalıdır!");

            //raporId : Mutat dışı araç rapor numarası. Mutat dışı araç değilse 0 yollanacaktır.
            if (MedulaSevkDonusVasitasi != null && MedulaSevkDonusVasitasi.sevkVasitasiKodu != null)
            {
                if (!MedulaSevkDonusVasitasi.sevkVasitasiKodu.Equals("1") && !MedulaSevkDonusVasitasi.sevkVasitasiKodu.Equals("12"))
                {
                    if (MutatDisiAracRaporKaydetSync())
                    {
                        if (MedulaMutatDisiAracRaporNo != null)
                            sevkKayitDVO.raporId = Convert.ToInt64(MedulaMutatDisiAracRaporNo);
                        else
                            throw new Exception("Medulaya e-sevk kaydında öncelikle mutat dışı araç rapor kaydının yapılması gerekmektedir!");
                    }
                    else
                    {
                        throw new Exception("Medulaya e-sevk kaydında öncelikle mutat dışı araç rapor kaydının yapılması gerekmektedir!");
                    }
                }
                else
                {
                    MedulaMutatDisiAracRaporNo = "0";
                    sevkKayitDVO.raporId = Convert.ToInt64(MedulaMutatDisiAracRaporNo);
                }
            }

            //*tedaviTani -> SevkTaniDVO[]
            SevkIslemleri.sevkTaniDVO[] sevkTaniList = GetSevkTaniDVOList("Medulaya e-sevk kaydında");
            if (sevkTaniList != null)
                sevkKayitDVO.tedaviTani = sevkTaniList;
            else
                throw new Exception("Medulaya e-sevk kaydında hastaya ait tanı girilmiş olmalıdır!");

            // *sevkEdenDoktor   -> SevkDoktorDVO[]
            SevkIslemleri.sevkDoktorDVO[] sevkDoktorList = GetSevkDoktorDVOList("Medulaya e-sevk kaydında");
            if (sevkDoktorList != null)
                sevkKayitDVO.tedaviEdenDoktor = sevkDoktorList;
            else
                throw new Exception("Medulaya e-sevk kaydında tedavi eden doktorların bilgileri girilmiş olmalıdır!");

            // *sevkTedavi: SevkTedaviDVO[]
            SevkIslemleri.sevkTedaviDVO[] sevkTedaviList = GetSevkTedaviDVOList();
            if (sevkTedaviList != null)
                sevkKayitDVO.sevkTedavi = sevkTedaviList;
            else
                throw new Exception("Medulaya e-sevk kaydında sevk tedavi bilgileri girilmiş olmalıdır!");


            // *kullaniciTesisKodu
            sevkKayitDVO.saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();

            // getSevkKayitDVOXML(sevkKayitDVO);
            return sevkKayitDVO;

        }

        public static class XmlSerializer
        {
            public static string Serialize<T>(T item)
            {
                System.IO.MemoryStream memStream = new System.IO.MemoryStream();
                using (XmlTextWriter textWriter = new XmlTextWriter(memStream, Encoding.Unicode))
                {
                    textWriter.Formatting = Formatting.Indented;
                    System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
                    serializer.Serialize(textWriter, item);

                    memStream = textWriter.BaseStream as System.IO.MemoryStream;
                }
                if (memStream != null)
                    return Encoding.Unicode.GetString(memStream.ToArray());
                else
                    return null;
            }

            public static T Deserialize<T>(string xmlString)
            {
                if (string.IsNullOrEmpty(xmlString))
                    return default(T);

                using (System.IO.MemoryStream memStream = new System.IO.MemoryStream())
                {
                    using (XmlTextWriter textWriter = new XmlTextWriter(memStream, Encoding.Unicode))
                    {
                        memStream.Position = 0;
                        System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
                        return (T)serializer.Deserialize(memStream);
                    }
                }
            }
        }

        public void getSevkKayitDVOXML(SevkIslemleri.sevkKayitDVO sevkKayitDVO)
        {

            String s = PatientExamination.XmlSerializer.Serialize<TTObjectClasses.SevkIslemleri.sevkKayitDVO>(sevkKayitDVO);
            TTUtils.InfoMessageService.Instance.ShowMessage(s);
        }


        public void getMutatDisiAracRaporKaydetDVOXML(SevkIslemleri.mutatDisiRaporDVO mutatDisiRaporDVO)
        {
            String s = PatientExamination.XmlSerializer.Serialize<TTObjectClasses.SevkIslemleri.mutatDisiRaporDVO>(mutatDisiRaporDVO);
            TTUtils.InfoMessageService.Instance.ShowMessage(s);
        }

        public SevkIslemleri.sevkTaniDVO[] GetSevkTaniDVOList(string type)
        {
            List<SevkIslemleri.sevkTaniDVO> sevkTaniDVOList = null;
            if (Episode != null)
            {
                sevkTaniDVOList = new List<SevkIslemleri.sevkTaniDVO>();

                foreach (String diagnose in Episode.GetMyMedulaDiagnosisDefinitionICDCodes(Episode))
                {
                    SevkIslemleri.sevkTaniDVO sevkTaniDVO = new SevkIslemleri.sevkTaniDVO();
                    sevkTaniDVO.sevkTaniKodu = diagnose;
                    sevkTaniDVOList.Add(sevkTaniDVO);
                }
            }
            else
            {
                throw new Exception(type + " hastaya ait tanı girilmiş olmalıdır!");
            }
            return sevkTaniDVOList.ToArray();
        }

        public SevkIslemleri.sevkTedaviDVO[] GetSevkTedaviDVOList()
        {
            List<SevkIslemleri.sevkTedaviDVO> sevkTedaviDVOList = new List<SevkIslemleri.sevkTedaviDVO>();
            //if (this.Episode != null && this.Episode.PatientStatus != null && this.Episode.PatientStatus.Value != null)
            if (Episode != null && Episode.PatientStatus != null)
            {
                SevkIslemleri.sevkTedaviDVO sevkTedaviDVO = new SevkIslemleri.sevkTedaviDVO();

                sevkTedaviDVO.baslangicTarihi = Common.RecTime().ToShortDateString();
                sevkTedaviDVO.bitisTarihi = Common.RecTime().ToShortDateString();

                if (Episode.PatientStatus.Value == PatientStatusEnum.Inpatient)
                    sevkTedaviDVO.tedaviTuru = "Y";
                else if (Episode.PatientStatus.Value == PatientStatusEnum.Outpatient)
                    sevkTedaviDVO.tedaviTuru = "A";
                else if (Episode.PatientStatus.Value == PatientStatusEnum.Discharge || Episode.PatientStatus.Value == PatientStatusEnum.PreDischarge)
                    sevkTedaviDVO.tedaviTuru = "S";
                else
                    throw new Exception("Sevkte yapılan tedavi türü dolu olmalıdır!");
                sevkTedaviDVOList.Add(sevkTedaviDVO);
            }
            return sevkTedaviDVOList.ToArray();
        }

        public SevkIslemleri.sevkDoktorDVO[] GetSevkDoktorDVOList(string type)
        {
            List<SevkIslemleri.sevkDoktorDVO> sevkDoktorDVOList = null;
            if (ProcedureDoctor != null)
            {
                sevkDoktorDVOList = new List<SevkIslemleri.sevkDoktorDVO>();
                SevkIslemleri.sevkDoktorDVO sevkDoktorDVO = new SevkIslemleri.sevkDoktorDVO();
                // *doktorTescilNo
                if (ProcedureDoctor.DiplomaRegisterNo != null)
                    sevkDoktorDVO.doktorTescilNo = ProcedureDoctor.DiplomaRegisterNo;
                else
                    throw new Exception(type + " hastaya tedavi yapan doktorun tescil numarası dolu olmalıdır!");

                // *doktorTipi
                //if (this.ProcedureDoctor.Title != null )
                {
                    if (ProcedureDoctor.Title.Value.Equals(UserTitleEnum.DisDoctor) || ProcedureDoctor.Title.Value.Equals(UserTitleEnum.DocDisDoctor) || ProcedureDoctor.Title.Value.Equals(UserTitleEnum.ProfDisTabip) || ProcedureDoctor.Title.Value.Equals(UserTitleEnum.YrdDocDisDoctor))
                        sevkDoktorDVO.doktorTipi = "2";
                    else
                        sevkDoktorDVO.doktorTipi = "1";
                }
                //else
                //{
                //    throw new Exception(type + " sevk eden doktorun tipi dolu olmalıdır!");

                //}

                // *bransKodu
                if (ProcedureDoctor.ResourceSpecialities != null)
                {
                    String brans = getAnaUzmanlikBrans(ProcedureDoctor, type);
                    if (brans != null)
                        sevkDoktorDVO.bransKodu = brans;
                }
                else
                    throw new Exception(type + " sevkli hastaya tedavi yapan doktor'un ana uzmanlık dalı olan branş bilgisi girilmiş olmalıdır!");

                sevkDoktorDVOList.Add(sevkDoktorDVO);
            }
            else
                throw new Exception(TTUtils.CultureService.GetText("M26862", "Sevkli hastayı tedavi eden doktorlar dolu olmalıdır!"));

            if (sevkDoktorDVOList.Count <= 0)
                throw new Exception(TTUtils.CultureService.GetText("M26862", "Sevkli hastayı tedavi eden doktorlar dolu olmalıdır!"));

            return sevkDoktorDVOList.ToArray();
        }

        public String getAnaUzmanlikBrans(ResUser user, string type)
        {
            bool ctrl = false;
            foreach (ResourceSpecialityGrid resource in user.ResourceSpecialities)
            {
                if (resource.MainSpeciality != null && resource.MainSpeciality.Equals(true))
                {
                    if (resource.Speciality != null && resource.Speciality.Code != null)
                    {
                        ctrl = true;
                        return resource.Speciality.Code;
                    }
                }
            }
            if (!ctrl)
            {
                throw new Exception(type + " tedavi eden doktor'un ana uzmanlık dalı olan branş bilgisi girilmiş olmalıdır!");
            }
            return null;
        }

        /*
         * MEDULA MUTAT DIŞI ARAÇ RAPOR KAYDET METODU
         * */

        public bool MutatDisiAracRaporKaydetSync()
        {

            try
            {
                SevkIslemleri.mutatDisiRaporCevapDVO mutatDisiRaporCevapDVO = SevkIslemleri.WebMethods.mutatDisiAracRaporKaydetSync(TTObjectClasses.Sites.SiteLocalHost, GetMutatDisiRaporDVO());
                if (mutatDisiRaporCevapDVO != null)
                {
                    if (string.IsNullOrEmpty(mutatDisiRaporCevapDVO.sonucKodu) == false)
                    {
                        if (mutatDisiRaporCevapDVO.sonucKodu.Equals("0000"))
                        {
                            TTUtils.InfoMessageService.Instance.ShowMessage("Mutat dışı araç rapor bildirim işlemi başarı ile sonuçlandı. Rapor id: " + mutatDisiRaporCevapDVO.raporId);
                            MedulaMutatDisiAracRaporNo = mutatDisiRaporCevapDVO.raporId.ToString();
                            return true;
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(mutatDisiRaporCevapDVO.sonucMesaji) == false)
                                throw new Exception("Mutat dışı araç rapor bildiriminde hata var. Sonuç Mesajı :" + mutatDisiRaporCevapDVO.sonucMesaji);
                            else
                                throw new Exception("Mutat dışı araç rapor bildiriminde hata var.Sonuç mesajı alanı boş.Sonuç Kodu: " + mutatDisiRaporCevapDVO.sonucKodu);
                        }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(mutatDisiRaporCevapDVO.sonucMesaji) == false)
                            throw new Exception("Mutat dışı araç rapor bildiriminde hata var. Sonuç Mesajı :" + mutatDisiRaporCevapDVO.sonucMesaji);
                        else
                            throw new Exception("Medulaya mutat dışı araç rapor bildirimi yapılması sırasında hata oluştu! Sonuç Kodu alanı boş!");
                    }

                }
                else
                    throw new Exception("Medulaya mutat dışı araç rapor bildirimi yapılamadı.Cevap dönmedi!");

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            //return false;
        }


        /*
         * MEDULA MUTAT DIŞI RAPOR DVO HAZIRLANMASI
         * */

        public SevkIslemleri.mutatDisiRaporDVO GetMutatDisiRaporDVO()
        {

            SevkIslemleri.mutatDisiRaporDVO mutatDisiRaporDVO = new SevkIslemleri.mutatDisiRaporDVO();
            // *haksahibiTCNO
            if (Episode != null && Episode.Patient != null && Episode.Patient.UniqueRefNo != null)
                mutatDisiRaporDVO.haksahibiTCNO = Convert.ToInt64(Episode.Patient.UniqueRefNo);
            else
                throw new Exception("Medulaya mutat dışı rapor kaydı yapılırken sevk edilen hasta TC kimlik no alanı dolu olmalıdır!");

            // XXXXXX tarafından verilen rapor no
            // *raporNo
            TTObjectContext context = new TTObjectContext(true);
            PatientExamination patExa = (PatientExamination)context.GetObject(ObjectID, typeof(PatientExamination).Name);
            if (patExa.MutatDisiAracRaporId.Value != null)
                mutatDisiRaporDVO.raporNo = patExa.MutatDisiAracRaporId.Value.ToString();
            else
                throw new Exception("Medulaya mutat dışı rapor kaydı yapılırken XXXXXX tarafından üretilen rapor ID gönderilmelidir!");


            // *protokolNo
            if (Episode != null && Episode.HospitalProtocolNo != null && Episode.HospitalProtocolNo.Value != null)
                mutatDisiRaporDVO.protokolNo = Episode.HospitalProtocolNo.Value.ToString();
            else
                throw new Exception("Medulaya mutat dışı rapor kaydı yapılırken protokol numarası alanı dolu olmalıdır!");

            // *sevkVasitasi
            if (MedulaSevkDonusVasitasi != null && MedulaSevkDonusVasitasi.sevkVasitasiKodu != null)
                mutatDisiRaporDVO.sevkVasitasi = Convert.ToInt32(MedulaSevkDonusVasitasi.sevkVasitasiKodu);
            else
                throw new Exception("Medulaya mutat dışı rapor kaydı yapılırken sevk vasıtası alanı dolu olmalıdır!");

            // raporTarihi
            if (MutatDisiAracRaporTarihi != null)
                mutatDisiRaporDVO.raporTarihi = MutatDisiAracRaporTarihi.Value.ToShortDateString().ToString();
            else
                throw new Exception("Medulaya mutat dışı rapor kaydı yapılırken rapor tarihi alanı dolu olmalıdır!");

            // baslangicTarihi
            if (MutatDisiAracBaslangicTarihi != null)
                mutatDisiRaporDVO.baslangicTarihi = MutatDisiAracBaslangicTarihi.Value.ToShortDateString().ToString();
            else
                throw new Exception("Medulaya mutat dışı rapor kaydı yapılırken başlangıç tarihi alanı dolu olmalıdır!");

            // bitisTarihi
            if (MutatDisiAracBitisTarihi != null)
                mutatDisiRaporDVO.bitisTarihi = MutatDisiAracBitisTarihi.Value.ToShortDateString().ToString();
            else
                throw new Exception("Medulaya mutat dışı rapor kaydı yapılırken bitiş tarihi alanı dolu olmalıdır!");

            // refakatciGerekcesi
            if (MedulaRefakatciGerekcesi != null)
                mutatDisiRaporDVO.refakatciGerekcesi = MedulaRefakatciGerekcesi;

            // Mutat Dışı Araç Rapor Gerekçesi
            if (MutatDisiGerekcesi != null)
                mutatDisiRaporDVO.mutatDisiGerekcesi = MutatDisiGerekcesi;

            // *sevkTani
            SevkIslemleri.sevkTaniDVO[] sevkTaniList = GetSevkTaniDVOList("Medulaya mutat dışı araç rapor bildiriminde");
            if (sevkTaniList != null)
                mutatDisiRaporDVO.sevkTani = sevkTaniList;
            else
                throw new Exception("Medulaya mutat dışı araç rapor bildiriminde hastaya ait tanı girilmiş olmalıdır!");

            // sevkEdenDoktor
            SevkIslemleri.sevkDoktorDVO[] sevkDoktorList = GetMutatTasitSevkDoktorDVOList("Medulaya mutat dışı araç rapor bildiriminde");
            if (sevkDoktorList != null)
                mutatDisiRaporDVO.sevkEdenDoktor = sevkDoktorList;
            else
                throw new Exception("Medulaya mutat dışı araç rapor bildiriminde sevk eden doktorların bilgileri girilmiş olmalıdır!");

            // *kullaniciTesisKodu
            mutatDisiRaporDVO.saglikTesisKodu = TTObjectClasses.SystemParameter.GetSaglikTesisKodu();

            // getMutatDisiAracRaporKaydetDVOXML(mutatDisiRaporDVO);
            return mutatDisiRaporDVO;
        }

        /*
         * Sevk Eden Doktorların Ekrandaki Listeden Alınması
         * */

        public SevkIslemleri.sevkDoktorDVO[] GetMutatTasitSevkDoktorDVOList(string type)
        {
            List<SevkIslemleri.sevkDoktorDVO> sevkDoktorDVOList = null;
            if (DoctorsGrid != null)
            {
                sevkDoktorDVOList = new List<SevkIslemleri.sevkDoktorDVO>();

                foreach (DoctorGrid doctor in DoctorsGrid)
                {
                    SevkIslemleri.sevkDoktorDVO sevkDoktorDVO = new SevkIslemleri.sevkDoktorDVO();
                    // *doktorTescilNo
                    if (doctor.ResUser != null && doctor.ResUser.DiplomaRegisterNo != null)
                        sevkDoktorDVO.doktorTescilNo = doctor.ResUser.DiplomaRegisterNo;
                    else
                    {
                        throw new Exception(type + " sevk eden doktorun tescil numarası dolu olmalıdır!");
                        //sevkDoktorDVO.doktorTescilNo= "101730";
                    }

                    // *doktorTipi
                    //if (doctor.ResUser != null && doctor.ResUser.Title != null && doctor.ResUser.Title.Value != null)
                    if (doctor.ResUser != null && doctor.ResUser.Title != null)
                    {
                        if (doctor.ResUser.Title.Value.Equals(UserTitleEnum.DisDoctor) || doctor.ResUser.Title.Value.Equals(UserTitleEnum.DocDisDoctor) || doctor.ResUser.Title.Value.Equals(UserTitleEnum.ProfDisTabip) || doctor.ResUser.Title.Value.Equals(UserTitleEnum.YrdDocDisDoctor))
                            sevkDoktorDVO.doktorTipi = "2";
                        else
                            sevkDoktorDVO.doktorTipi = "1";
                    }
                    else
                    {
                        throw new Exception(type + " sevk eden doktorun tipi dolu olmalıdır!");
                        //TODO veriler doldurulacak
                        //sevkDoktorDVO.doktorTipi ="1";
                    }

                    // *bransKodu
                    if (doctor.ResUser != null && doctor.ResUser.ResourceSpecialities != null)
                    {
                        String brans = getAnaUzmanlikBrans(doctor.ResUser, type);
                        if (brans != null)
                            sevkDoktorDVO.bransKodu = brans;
                    }
                    else
                        throw new Exception(type + " sevk eden doktor'un ana uzmanlık dalı olan branş bilgisi girilmiş olmalıdır!");

                    sevkDoktorDVOList.Add(sevkDoktorDVO);
                }

            }
            else
                throw new Exception(type + " sevk eden doktor bilgisi girilmiş olmalıdır!");

            return sevkDoktorDVOList.ToArray();
        }

        //public void CheckForForensicMedicalExamination()
        //{
        //    Guid muayeneGuid = ProcedureDefinition.ExaminationProcedureObjectId;
        //    foreach (PatientExaminationForensicProcedure pefp in this.PatientExaminationForensicProcedure)
        //    {
        //        if (pefp.ProcedureObject is ForensicMedicalProcedureDefinition && ((ForensicMedicalProcedureDefinition)pefp.ProcedureObject).ISFORENSICMEDICALEXAMINATION == true)
        //        {
        //            foreach (PatientExaminationProcedure examinationProcedure in this.PatientExaminationProcedures)
        //            {
        //                if (examinationProcedure.ProcedureObject.ObjectID == muayeneGuid)
        //                {
        //                    foreach (AccountTransaction accountTransaction in examinationProcedure.AccountTransactions)
        //                    {
        //                        if (accountTransaction.CurrentStateDefID == AccountTransaction.States.New || accountTransaction.CurrentStateDefID == AccountTransaction.States.ToBeNew)
        //                            accountTransaction.CurrentStateDefID = AccountTransaction.States.Cancelled;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}


        public PatientExamination(EmergencyIntervention emergencyIntervention) : this(emergencyIntervention.ObjectContext)
        {
            SetMandatoryEpisodeActionProperties((EpisodeAction)emergencyIntervention, emergencyIntervention.MasterResource, emergencyIntervention.MasterResource, true);
            //this.CurrentStateDefID = PatientExamination.States.New;
            CurrentStateDefID = PatientExamination.States.Examination;
            EmergencyIntervention = emergencyIntervention;
            ProcedureSpeciality = emergencyIntervention.ProcedureSpeciality;
            DescriptionForWorkList = emergencyIntervention.DescriptionForWorkList;
            ProcedureDoctor = emergencyIntervention.ProcedureDoctor;

        }
        public PatientExamination(EpisodeAction masterAction, HospitalsUnitsGrid hospitalsUnit, EDisabledReport reportObj = null, EStatusNotRepCommitteeObj eStatusNotfReportObj = null) : this(masterAction.ObjectContext)
        {
            SetMandatoryEpisodeActionProperties(masterAction, (ResSection)hospitalsUnit.Unit, true);
            //this.CurrentStateDefID = PatientExamination.States.New;
            CurrentStateDefID = PatientExamination.States.Examination;
            ProcedureDoctor = hospitalsUnit.Doctor;
            ProcedureSpeciality = (hospitalsUnit.Unit.ResourceSpecialities != null || hospitalsUnit.Unit.ResourceSpecialities.Count > 0) ? hospitalsUnit.Unit.ResourceSpecialities[0].Speciality : null;

            HCExaminationComponent hcExamination = new HCExaminationComponent(ObjectContext);
            hcExamination.ReasonForExamination = ((HealthCommittee)masterAction).HCRequestReason.ReasonForExamination;
            HCExaminationComponent = hcExamination;
            PatientExaminationType = PatientExaminationEnum.HealthCommittee;
            MasterAction = masterAction;
            MasterResource = hospitalsUnit.Unit;
            FromResource = masterAction.MasterResource;
            PatientAdmission = masterAction.MasterAction is PatientAdmission ? (PatientAdmission)masterAction.MasterAction : masterAction.SubEpisode.PatientAdmission;
            if (PatientAdmission.EDisabledReport != null)
                hcExamination.EDisabledReport = PatientAdmission.EDisabledReport;
            else if (reportObj != null)
                hcExamination.EDisabledReport = reportObj;
            if (PatientAdmission.EStatusNotRepCommitteeObj != null)
                hcExamination.EStatusNotRepCommitteeObj = PatientAdmission.EStatusNotRepCommitteeObj;
            else if (eStatusNotfReportObj != null)
                hcExamination.EStatusNotRepCommitteeObj = eStatusNotfReportObj;
            bool setDescriptionForWorkList = false;
            if (!setDescriptionForWorkList)
            {
                if (Episode != null && (Episode.PatientStatus != PatientStatusEnum.Outpatient))
                {
                    DescriptionForWorkList = TTUtils.CultureService.GetText("M26794", "Sağlık Kurulu Muayenesi (Yatan)");
                    setDescriptionForWorkList = true;
                }
            }
            if (!setDescriptionForWorkList)
                DescriptionForWorkList = TTUtils.CultureService.GetText("M26793", "Sağlık Kurulu Muayenesi (Normal)");

            if (ProcedureSpeciality == null)
                throw new Exception(SystemMessage.GetMessageV3(640, new string[] { MasterResource.Name.ToString() }));
            bool chargeHCExaminationPrice = true;
            if (hospitalsUnit.Unit != null)
            {
                if (hospitalsUnit.Unit.NotChargeHCExaminationPrice == true)
                    chargeHCExaminationPrice = false;
            }

            if (chargeHCExaminationPrice)
            {
                string examinationProcedureGuid = ProcedureDefinition.ExaminationProcedureObjectId.ToString();
                if (hospitalsUnit.Unit is ResPoliclinic)
                {
                    if (((ResPoliclinic)hospitalsUnit.Unit).PoliclinicType == PoliclinicTypeEnum.DentalPoliclinic) // Diş Polikliniği ise
                        examinationProcedureGuid = ProcedureDefinition.DentalExaminationProcedureObjectId.ToString();
                }

                HealthCommitteeExaminationProcedure pProcedure = new HealthCommitteeExaminationProcedure(this, examinationProcedureGuid);
                pProcedure.AccountOperation(AccountOperationTimeEnum.PRE);

                bool patientPays = false;
                bool free = false;
                HealthCommittee healthCommittee = null;
                //if (masterAction is HealthCommitteeExaminationFromOtherDepartments)
                //{
                //    HealthCommitteeExaminationFromOtherDepartments hceFromOtherDepartments = (HealthCommitteeExaminationFromOtherDepartments)masterAction;
                //    healthCommittee = hceFromOtherDepartments.HCActionToBeLinked;
                //}
                //if (masterAction is HealthCommittee)
                healthCommittee = (HealthCommittee)masterAction;

                if (healthCommittee != null && healthCommittee.WhoPays == WhoPaysEnum.PatientPays)
                    patientPays = true;
                else if (healthCommittee != null && healthCommittee.WhoPays == WhoPaysEnum.Free)
                    free = true;

                foreach (AccountTransaction AccTrx in pProcedure.AccountTransactions)
                {
                    if (hospitalsUnit.Unit != null && !string.IsNullOrEmpty(hospitalsUnit.Unit.Name))
                        AccTrx.Description = AccTrx.Description + " (" + hospitalsUnit.Unit.Name + ")";

                    if (AccTrx.AccountPayableReceivable.Type == APRTypeEnum.PAYER)
                    {
                        if (patientPays || free)
                        {
                            if (patientPays)
                            {
                                AccTrx.TurnToPatientShare(false);
                                AccTrx.CurrentStateDefID = AccountTransaction.States.New;
                            }
                            else if (free)
                                AccTrx.InvoiceInclusion = false;
                        }
                        else if (SubEpisode.IsSGK)
                            AccTrx.CurrentStateDefID = AccountTransaction.States.MedulaDontSend;
                    }
                    else if (AccTrx.AccountPayableReceivable.Type == APRTypeEnum.PATIENT)
                    {
                        if (patientPays)
                        {
                            AccTrx.CurrentStateDefID = AccountTransaction.States.New;
                            AccTrx.InvoiceInclusion = false;
                        }
                        else if (free)
                            AccTrx.InvoiceInclusion = false;
                    }
                }

                if (hospitalsUnit.Unit != null && !string.IsNullOrEmpty(hospitalsUnit.Unit.Name))
                    pProcedure.ExtraDescription = "(" + hospitalsUnit.Unit.Name + ")";
            }
        }

        public void ControlGreenAreaExamination()
        {
            if (EmergencyIntervention != null)
            {
                if (EmergencyIntervention.NotCreateExaminationProcedure() == true)
                    return;
                Guid emergencyExaminationGuid = ProcedureDefinition.EmergencyExaminationProcedureObjectId;
                Guid greenAreaExaminationGuid = ProcedureDefinition.GreenAreaExaminationProcedureObjectId;

                if (IsGreenAreaExamination)
                {
                    bool greenAreaExaminationExists = false;
                    foreach (EmergencyInterventionProcedure proc in EmergencyIntervention.EmergencyInterventionProcedures)
                    {
                        if (proc.ProcedureObject.ObjectID.Equals(emergencyExaminationGuid))
                            proc.CancelMyAccountTransactions();
                        else if (proc.ProcedureObject.ObjectID.Equals(greenAreaExaminationGuid))
                        {
                            foreach (AccountTransaction accTrx in proc.AccountTransactions)
                            {
                                if (accTrx.CurrentStateDefID == AccountTransaction.States.Cancelled)
                                    accTrx.CurrentStateDefID = AccountTransaction.States.New;
                            }
                            greenAreaExaminationExists = true;
                        }
                    }

                    if (!greenAreaExaminationExists)
                    {
                        EmergencyInterventionProcedure emergencyExaminationProcedure = new EmergencyInterventionProcedure(EmergencyIntervention, greenAreaExaminationGuid.ToString());
                        emergencyExaminationProcedure.AccountOperation(AccountOperationTimeEnum.PREPOST);
                    }
                    /* kpayi ---EmergencyIntervention.ControlAndAddMedulaPatientParticipation(); */
                }
                else
                {
                    bool emergencyExaminationExists = false;
                    foreach (EmergencyInterventionProcedure proc in EmergencyIntervention.EmergencyInterventionProcedures)
                    {
                        if (proc.ProcedureObject.ObjectID.Equals(greenAreaExaminationGuid))
                            proc.CancelMyAccountTransactions();
                        else if (proc.ProcedureObject.ObjectID.Equals(emergencyExaminationGuid))
                        {
                            foreach (AccountTransaction accTrx in proc.AccountTransactions)
                            {
                                if (accTrx.CurrentStateDefID == AccountTransaction.States.Cancelled)
                                    accTrx.CurrentStateDefID = AccountTransaction.States.New;
                            }
                            emergencyExaminationExists = true;
                        }
                    }

                    if (!emergencyExaminationExists)
                    {
                        EmergencyInterventionProcedure emergencyExaminationProcedure = new EmergencyInterventionProcedure(EmergencyIntervention, emergencyExaminationGuid.ToString());
                        emergencyExaminationProcedure.AccountOperation(AccountOperationTimeEnum.PREPOST);
                    }
                    /* kpayi--- EmergencyIntervention.CancelMedulaPatientParticipation();*/
                }
            }
        }



        public override BaseAdditionalApplication CreateBaseAdditionalApplication()
        {
            return new PatientExaminationAdditionalApplication(ObjectContext);
        }

        /*public void CompleteMyExaminationProcedures()
        {
            foreach(PatientExaminationProcedure patientExaminationProcedure in this.PatientExaminationProcedures)
            {
                if(patientExaminationProcedure.CurrentStateDef.Status == StateStatusEnum.Uncompleted)
                    patientExaminationProcedure.CurrentStateDefID = PatientExaminationProcedure.States.Completed;
            }
        }*/

        #endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(PatientExamination).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == PatientExamination.States.Completed && toState == PatientExamination.States.Examination)
                PreTransition_Completed2Examination();
            else if (toState == PatientExamination.States.Completed)
                PreTransition_Examination2Completed();
            //else if (fromState == States.New && toState == States.Examination)
            //    PreTransition_New2Examination();

        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(PatientExamination).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == PatientExamination.States.Completed && toState == PatientExamination.States.Cancelled)
                PostTransition_Completed2Cancelled();
            else if (fromState == PatientExamination.States.ExaminationCompleted && toState == PatientExamination.States.Completed)
                PostTransition_Examination2Completed();
            else if (fromState == PatientExamination.States.ProcedureRequested && toState == PatientExamination.States.Completed)
                PostTransition_Examination2Completed();
            else if (fromState == PatientExamination.States.ExaminationCompleted && toState == PatientExamination.States.ProcedureRequested)
                PostTransition_ExaminationCompleted2ProcedureRequested();
            else if (fromState == PatientExamination.States.Examination)
            {
                if (toState == PatientExamination.States.Cancelled)
                    PostTransition_Examination2Cancelled();
                else if (toState == PatientExamination.States.PatientNoShown)
                    PostTransition_Examination2PatientNoShown();
                else
                    PostTransition_FromExamination();
            }
            //else if (fromState == States.New && toState == States.PatientNoShown)
            //    PostTransition_New2PatientNoShown();

        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(PatientExamination).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == PatientExamination.States.Completed && toState == PatientExamination.States.Cancelled)
                UndoTransition_Completed2Cancelled(transDef);
            else if (toState == PatientExamination.States.Completed)
                UndoTransition_Examination2Completed(transDef);
            else if (fromState == PatientExamination.States.Examination && toState == PatientExamination.States.Cancelled)
                UndoTransition_Examination2Cancelled(transDef);
            else if (fromState == PatientExamination.States.Examination && toState == PatientExamination.States.PatientNoShown)
                UndoTransition_Examination2PatientNoShown(transDef);
            //else if (fromState == States.New && toState == States.PatientNoShown)
            //    UndoTransition_New2PatientNoShown(transDef);
        }

        public override void SetPatientNoShown()
        {
            if (CurrentStateDefID != PatientExamination.States.Examination)
                throw new Exception("'Muayene' adımında olmayan işlem, 'Muayeneye Gelmedi' olarak değiştirilemez.");
            if (SubEpisode.IsDiagnosisExists())
                throw new Exception("Bu muayenenin alt vakasında tanı mevcut. İşlem 'Muayeneye Gelmedi' olarak değiştirilemez.");
            if (SubEpisode.PatientAdmission.PAStatus != PAStatusEnum.Sirada)
                throw new Exception("Hasta Kabul durumu 'Sırada' değil. İşlem 'Muayeneye Gelmedi' yapılamaz.");
            CurrentStateDefID = PatientExamination.States.PatientNoShown;
        }

    }
}