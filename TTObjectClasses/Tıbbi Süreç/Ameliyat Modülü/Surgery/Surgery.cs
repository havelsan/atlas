
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
using Newtonsoft.Json;

namespace TTObjectClasses
{
    /// <summary>
    /// Ameliyat  İşlemlerinin Gerçekleştirildiği  Temel Nesnedir
    /// </summary>
    public partial class Surgery : EpisodeActionWithDiagnosis, IAppointmentWithoutResources, IWorkListEpisodeAction, ITreatmentMaterialCollection, ICreateSubEpisode, IStockOutCancel
    {
        public partial class OLAP_GetSurgeryByDate_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetSurgery10Day_Class : TTReportNqlObject
        {
        }

        public partial class SurgeryReportNQL_Class : TTReportNqlObject
        {
        }

        public partial class SurgeryPatientByDateNQL_Class : TTReportNqlObject
        {
        }

        public partial class DirectPurchaseExpenditureInfoNQL_Class : TTReportNqlObject
        {
        }

        public partial class SurgeryCountQuery_Class : TTReportNqlObject
        {
        }

        public partial class InCompleteSurgeryPatientListNQL_Class : TTReportNqlObject
        {
        }


        protected override void PostInsert()
        {
            #region PostInsert

            base.PostInsert();



            //SetMandotoryFieldsOfMainSurgeryProcedure();
            #endregion PostInsert
        }

        protected override void PreUpdate()
        {
            base.PreUpdate();

            if (SurgeryReport != null && !string.IsNullOrEmpty(Common.GetTextOfRTFString(SurgeryReport.ToString())))
            {
                if (IsOldAction != true)
                {
                    if (SurgeryReportNo.Value == null)
                        SurgeryReportNo.GetNextValue(FromResource.ObjectID.ToString(), Common.RecTime().Year);
                    if (SurgeryReportDate == null)
                    {
                        SurgeryReportDate = Common.RecTime();
                    }
                }
            }


        }

        protected override void PostUpdate()
        {
            #region PostUpdate
            base.PostUpdate();
            if (!HasMemberChanged("SurgeryStatusDefinition") && !HasMemberChanged("SurgeryStatusDefinitionTime"))//Ameliyat durumu iş listesinden güncellendiğinde ameliyatın mevcut haliyle güncellenmesi yeterli olduğu için tüm kontroller kapatıldı.
            {
                // Planlanan Anestezi tarihini set eder
                if (AnesthesiaAndReanimation != null && PlannedSurgeryDate != null)
                {
                    AnesthesiaAndReanimation.PlannedAnesthesiaDate = PlannedSurgeryDate;
                }         // Planlanan Anestezi tarihini set eder
                if (SurgeryEndTime != null)
                {
                    CheckSurgeryTime();
                    SetMySubActionProceduresPerformedDate();
                }
                //SetMandotoryFieldsOfMainSurgeryProcedure();

                // Ameliyat veya Kesi Bilgisi değiştirilirse Medulaya gidecek kesi bilgisinin tekrar hesaplanması için
                //if (this.CurrentStateDefID == Surgery.States.Surgery || this.CurrentStateDefID == Surgery.States.WaitingForSubSurgeries)
                //{
                //this.SetMedulaAyniFarkliKesiOfSurgeryProcedures();
                //}

            }
            #endregion PostUpdate
        }



        protected void PostTransition_Surgery2WaitingForSubSurgeries()
        {
            // From State : Surgery   To State : WaitingForSubSurgeries
            #region PostTransition_Surgery2WaitingForSubSurgeries
            CheckDirectPurchaseGridToComplete();
            ControlAndCreateAnesthesiaAndNewBornProcedure();

            //NotifyAndSendSMSDoctors();
            #endregion PostTransition_Surgery2WaitingForSubSurgeries
        }

        protected void UndoTransition_Surgery2WaitingForSubSurgeries(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Surgery  To State : WaitingForSubSurgeries
            #region UndoTransition_Surgery2WaitingForSubSurgeries
            ControlAndCancelAnesthesiaAndNewBornProcedure();
            #endregion UndoTransition_Surgery2WaitingForSubSurgeries
        }

        protected void PostTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
            #region PostTransition_Completed2Cancelled
            Cancel();
            #endregion PostTransition_Completed2Cancelled
        }

        protected void UndoTransition_Completed2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Completed   To State : Cancelled
            #region UndoTransition_Completed2Cancelled
            NoBackStateBack();
            #endregion UndoTransition_Completed2Cancelled
        }



        protected void PostTransition_Surgery2Completed()
        {
            // From State : Surgery   To State : Completed
            #region PostTransition_Surgery2Completed
            CheckDirectPurchaseGridToComplete();
            ControlAndCreateAnesthesiaAndNewBornProcedure();

            //NotifyAndSendSMSDoctors();
            #endregion PostTransition_Surgery2Completed
        }

        protected void PostTransition_WaitingForSubSurgeries2Completed()
        {
            // From State : WaitingForSubSurgeries   To State : Completed
            #region PostTransition_WaitingForSubSurgeries2Completed
            ControlAndCreateAnesthesiaAndNewBornProcedure();
            #endregion PostTransition_WaitingForSubSurgeries2Completed
        }

        protected void UndoTransition_Surgery2Completed(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Surgery  To State : Completed
            #region UndoTransition_Surgery2Completed
            ControlAndCancelAnesthesiaAndNewBornProcedure();
            #endregion UndoTransition_Surgery2Completed
        }

        protected void UndoTransition_WaitingForSubSurgeries2Completed(TTObjectStateTransitionDef transitionDef)
        {
            // From State : WaitingForSubSurgeries  To State : Completed
            #region UndoTransition_WaitingForSubSurgeries2Completed
            ControlAndCancelAnesthesiaAndNewBornProcedure();
            #endregion UndoTransition_WaitingForSubSurgeries2Completed
        }


        protected void PostTransition_Surgery2Cancelled()
        {
            // From State : Surgery   To State : Cancelled
            #region PostTransition_Surgery2Cancelled
            Cancel();
            #endregion PostTransition_Surgery2Cancelled
        }

        protected void UndoTransition_Surgery2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Surgery   To State : Cancelled
            #region UndoTransition_Surgery2Cancelled
            NoBackStateBack();
            #endregion UndoTransition_Surgery2Cancelled
        }

        protected void PostTransition_Surgery2Rejected()
        {
            // From State : Surgery   To State : Rejected
            #region PostTransition_Surgery2Rejected

            if (AnesthesiaAndReanimation != null)
            {
                CancelAnesthesiaAndReanimation();
            }
            if (SurgeryExtension != null)
            {
                RejectSurgeryExtension();
            }
            //Ameliyat sarfdan Stepbackle bu adıma geldi ise ve fire dilmiş ek ameliyatlar varsa iptal edilir
            CancelSubSurgeries();
            #endregion PostTransition_Surgery2Rejected
        }

        protected void UndoTransition_Surgery2Rejected(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Surgery   To State : Rejected
            #region UndoTransition_Surgery2Rejected
            NoBackStateBack();
            //anestezide iptal edilen procedüreler geri alınamıyor diye commentlendi
            //            if(this.AnesthesiaAndReanimation!=null)
            //            {
            //                if(this.AnesthesiaAndReanimation.IsCancelled)
            //                {
            //                    ((ITTObject)this.AnesthesiaAndReanimation).UndoLastTransition();
            //                }
            //            }

            #endregion UndoTransition_Surgery2Rejected
        }



        protected void PostTransition_Surgery2SurgeryRequest()
        {
            // From State : Surgery   To State : SurgeryRequest
            #region PostTransition_Surgery2SurgeryRequest
            CancelSubSurgeries();
            IsDelayedSurgery = true;
            #endregion PostTransition_Surgery2SurgeryRequest
        }

        protected void PostTransition_WaitingForSubSurgeries2Cancelled()
        {
            // From State : WaitingForSubSurgeries   To State : Cancelled
            #region PostTransition_WaitingForSubSurgeries2Cancelled
            Cancel();
            #endregion PostTransition_WaitingForSubSurgeries2Cancelled
        }

        protected void UndoTransition_WaitingForSubSurgeries2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : WaitingForSubSurgeries   To State : Cancelled
            #region UndoTransition_WaitingForSubSurgeries2Cancelled
            NoBackStateBack();
            #endregion UndoTransition_WaitingForSubSurgeries2Cancelled
        }

        protected void UndoTransition_SurgeryRequest2Surgery(TTObjectStateTransitionDef transitionDef)
        {
            // From State : SurgeryRequest   To State : Surgery
            #region PostTransition_SurgeryRequest2Surgery
            CancelSubSurgeries();
            #endregion PostTransition_SurgeryRequest2Surgery
        }

        protected void PostTransition_SurgeryRequest2Cancelled()
        {
            // From State : SurgeryRequest   To State : Cancelled
            #region PostTransition_SurgeryRequest2Cancelled
            Cancel();
            #endregion PostTransition_SurgeryRequest2Cancelled
        }

        protected void UndoTransition_SurgeryRequest2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : SurgeryRequest   To State : Cancelled
            #region UndoTransition_SurgeryRequest2Cancelled
            NoBackStateBack();
            #endregion UndoTransition_SurgeryRequest2Cancelled
        }

        protected void PostTransition_SurgeryRequest2Surgery()
        {
            // From State : SurgeryRequest   To State : Surgery
            #region PostTransition_SurgeryRequest2Surgery
            //FireIntensiveCareAfterSurgery(); 
            //FireAnesthesiaAndReanimation();// SurgeryServiceController e taşındı

            #endregion PostTransition_SurgeryRequest2Surgery
        }

        #region Methods
        #region IStockOutCancel Members
        public BaseTreatmentMaterial.ChildBaseTreatmentMaterialCollection GetTreatmentMaterials()
        {
            return TreatmentMaterials;
        }
        #endregion
        public Surgery(TTObjectContext objectContext, EpisodeAction episodeAction)
            : this(objectContext)
        {
            ActionDate = Common.RecTime();
            //this.MasterResource = episodeAction.MasterResource;
            FromResource = episodeAction.MasterResource;
            MasterAction = episodeAction;
            CurrentStateDefID = Surgery.States.SurgeryRequest;
            Episode = episodeAction.Episode;
        }


        //public void SetMandotoryFieldsOfMainSurgeryProcedure()
        //{
        //    foreach (var mainSurgeryProcedure in this.MainSurgeryProcedures)
        //    {
        //        if (mainSurgeryProcedure.Surgery == null)
        //            mainSurgeryProcedure.Surgery = this;
        //    }
        //}

        public override ActionTypeEnum ActionType
        {
            get
            {
                return ActionTypeEnum.Surgery;
            }
        }


        public void MainSurgeryProceduresIsResquired()
        {
            if (MainSurgeryProcedures.Count < 1)
            {
                throw new Exception(SystemMessage.GetMessage(619));
            }
        }


        public DateTime GetProperSurgeryDateOrRecTime()
        {
            if (SurgeryStartTime != null)
                return (DateTime)SurgeryStartTime;
            else if (PlannedSurgeryDate != null)
                return (DateTime)PlannedSurgeryDate;
            return Common.RecTime();
        }


        public static double GetSUTPointByProcedureObjectId(Guid procedureObjId)
        {
            TTObjectContext readOnlyObjectContext = new TTObjectContext(true);
            ProcedureDefinition procedureDef = (ProcedureDefinition)readOnlyObjectContext.GetObject(procedureObjId, "ProcedureDefinition");
            return ProcedureDefinition.GetSUTPoint(procedureDef);
        }

        // SurgeryPersonel PreInsertune taşındı
        //public void FireSubSurgeries()
        //{

        //    foreach (SurgeryParticipantDepartment participantDepartment in this.ParticipantDepartmants)
        //    {
        //        if (participantDepartment.SubSurgery == null)
        //        {
        //            if (this.CurrentStateDefID == Surgery.States.Completed)
        //            {
        //                throw new Exception("Ameliyata katılan birimlere yeni bir birim eklendi . Lütfen ekranı Önce 'Kaydet' daha sonra 'Kaydet/Tamamla' butonuna basınız");
        //            }

        //            SubSurgery subSurgery = new SubSurgery(this, participantDepartment.Department, participantDepartment.ResponsibleDoctor);
        //            participantDepartment.SubSurgery = subSurgery;


        //        }
        //        else
        //        {
        //            if (participantDepartment.SubSurgery.FromResource.ObjectID != participantDepartment.Department.ObjectID)
        //            {
        //                //Cancel edildiğinde participantDepartment.SubSurgery =null yapılır dolayısı ile yeni bir subsurgery başlatılır.
        //                ((ITTObject)participantDepartment.SubSurgery).Cancel();
        //            }
        //            else
        //            {
        //                participantDepartment.SubSurgery.ProcedureDoctor = participantDepartment.ResponsibleDoctor;
        //            }
        //        }
        //    }
        //}


        public bool HasNewSubSurgeries()
        {
            //foreach (SurgeryParticipantDepartment participantDepartment in this.ParticipantDepartmants)
            //{
            //    if (participantDepartment.SubSurgery == null)
            //    {
            //        return true;
            //    }
            //}
            //return false;
            if (IsOldAction == true)
                return false;// Aktarılan veride SubSurgery başlatılmaz

            foreach (SurgeryPersonnel surgeryPersonnel in AllSurgeryPersonnels.Where(c => c.Personnel.ObjectID != ProcedureDoctor.ObjectID))//Sorumlu cerrah harici eklenen doktorlar için subSurgery açılsın.
            {
                if (surgeryPersonnel.IfNeedNewSubSurgeryGetMasterResource() != null)
                {
                    return true;
                }
            }
            return false;
        }

        public void CheckSurgeryPersonelRoles()
        {
            if (IsOldAction != true)
            {
                if (AllSurgeryPersonnels.Count < 1)
                {
                    throw new Exception(TTUtils.CultureService.GetText("M25358", "Cerahi Ekip Girmeden Amaliyat Tamamlanamaz"));
                }

                var surgeryDoctor = AllSurgeryPersonnels.FirstOrDefault(dr => dr.Role == SurgeryRoleEnum.Surgeon1);
                if (surgeryDoctor == null)
                    throw new Exception(TTUtils.CultureService.GetText("M25359", "Cerrahi Ekip alanından girilen kullanıcılardan en az biri  'Ameliyatı Yapan Cerrah' olarak seçilmeli"));
            }
        }

        public override void Cancel()
        {
            base.Cancel();
            CancelAnesthesiaAndReanimation();
            CancelSurgeryExtension();
            CancelSubSurgeries();
            CancelIntensiveCareAfterSurgeries();
            //CancelSurgeryDirectPuchase();
        }
        public void CancelSubSurgeries()
        {
            foreach (SubSurgery subSurgery in SubSurgeries)
            {
                if (subSurgery.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                {
                    if (string.IsNullOrEmpty(subSurgery.ReasonOfCancel))
                    {
                        subSurgery.ReasonOfCancel = ReasonOfCancel;
                    }
                    ((ITTObject)subSurgery).Cancel();
                }
            }
        }
        public void CancelAnesthesiaAndReanimation()
        {
            if (AnesthesiaAndReanimation != null)
            {
                if (AnesthesiaAndReanimation.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                {
                    AnesthesiaAndReanimation.CancelledBySurgery = true;
                    if (string.IsNullOrEmpty(AnesthesiaAndReanimation.ReasonOfCancel))
                    {
                        AnesthesiaAndReanimation.ReasonOfCancel = ReasonOfCancel;
                    }
                    ((ITTObject)AnesthesiaAndReanimation).Cancel();
                }
            }
        }

        public void CancelSurgeryExtension()
        {
            if (SurgeryExtension != null)
            {
                if (SurgeryExtension.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                {
                    SurgeryExtension.CancelledBySurgery = true;
                    if (string.IsNullOrEmpty(SurgeryExtension.ReasonOfCancel))
                    {
                        SurgeryExtension.ReasonOfCancel = ReasonOfCancel;
                    }
                    ((ITTObject)SurgeryExtension).Cancel();
                }
            }
        }


        public void RejectSurgeryExtension()
        {
            if (SurgeryExtension != null)
            {
                if (SurgeryExtension.CurrentStateDefID != SurgeryExtension.States.Application)
                {
                    SurgeryExtension.CancelledBySurgery = true;
                    SurgeryExtension.CurrentStateDefID = SurgeryExtension.States.Rejected;
                }
            }
        }



        public void CancelIntensiveCareAfterSurgeries()
        {
            foreach (IntensiveCareAfterSurgery intCareAfterSurgery in IntensiveCareAfterSurgeries)
            {
                if (intCareAfterSurgery.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                {
                    if (string.IsNullOrEmpty(intCareAfterSurgery.ReasonOfCancel))
                    {
                        intCareAfterSurgery.ReasonOfCancel = ReasonOfCancel;
                    }
                    ((ITTObject)intCareAfterSurgery).Cancel();
                }
            }
        }


        //public void CancelSurgeryDirectPuchase()
        //{
        //    foreach (DirectPurchaseGrid directPurchaseGrid in this.DirectPurchaseGrids)
        //    {

        //        if(directPurchaseGrid.DirectMaterialSupplyAction.CurrentStateDef.Status != StateStatusEnum.Cancelled)
        //        {
        //            ((ITTObject)directPurchaseGrid.DirectMaterialSupplyAction).Cancel();
        //        }
        //    }
        //}

        public override void SetMySubActionProceduresPerformedDate()
        {
            foreach (SubActionProcedure subactionProcedure in SubactionProcedures.Where(x => x.CurrentStateDef.Status != StateStatusEnum.Cancelled))
            {
                subactionProcedure.SetPerformedDate();
            }
        }

        public class AscSurgeryProcedureComparer : IComparer<SurgeryProcedure>
        {
            #region IComparer<LotoItem> Members
            public int Compare(SurgeryProcedure x, SurgeryProcedure y)
            {
                double xSUTPoint = 0;
                double ySUTPoint = 0;

                if (x.PackageProcedureObject != null)
                    xSUTPoint = x.PackageProcedureObject.GetSUTPoint();   // Paket ise paket hizmetin SUT Puanı kullanılır
                else
                    xSUTPoint = x.ProcedureObject.GetSUTPoint();          // Paket değilse hizmetin SUT Puanı kullanılır

                if (y.PackageProcedureObject != null)
                    ySUTPoint = y.PackageProcedureObject.GetSUTPoint();   // Paket ise paket hizmetin SUT Puanı kullanılır
                else
                    ySUTPoint = y.ProcedureObject.GetSUTPoint();          // Paket değilse hizmetin SUT Puanı kullanılır

                return (ySUTPoint.CompareTo(xSUTPoint));    // Azalan sıra ile sıralayan Compare
            }
            #endregion
        }

        public void CreateAnesthesiaAndNewBornProcedure()
        {
            if (IsOldAction != true)
            {
                if (SurgeryProcedures.Count == 0)
                    throw new TTException(TTUtils.CultureService.GetText("M25934", "Hiç ameliyat hizmeti girilmemiştir."));

                List<Surgery.SurgeryProcedureDiscountPercent> surgeryProcedureDiscountPercentList = new List<Surgery.SurgeryProcedureDiscountPercent>();
                double anesthesiaSUTPoint = 0;

                FillSurgeryProcedureDiscountPercentList(ref surgeryProcedureDiscountPercentList, ref anesthesiaSUTPoint);

                string anesthesiaProcObjectID = string.Empty;
                string newBornExtraProcObjectID = string.Empty;
                int patientAgeByDay = Episode.Patient.AgeByDayBySpecificDate(SurgeryStartTime.Value);

                // Ameliyat yeni doğana yapılıyorsa farklı anestezi kodları oluşmalı
                if (anesthesiaSUTPoint < 150)
                {
                    if (patientAgeByDay < 28) // Yeni Doğan
                    {
                        anesthesiaProcObjectID = SystemParameter.GetParameterValue("AnesthesiaNewBornEGroup", "");
                        newBornExtraProcObjectID = SystemParameter.GetParameterValue("NewBornExtraProcedureEGroup", "");
                    }
                    else if (SurgeryProcedures.Count == 1)
                        anesthesiaProcObjectID = SystemParameter.GetParameterValue("AnesthesiaEGroup", "");
                    else
                        anesthesiaProcObjectID = SystemParameter.GetParameterValue("AnesthesiaEGroupMultipleOperation", "");
                }
                else if (anesthesiaSUTPoint >= 150 && anesthesiaSUTPoint < 300)
                {
                    if (patientAgeByDay < 28)
                    {
                        anesthesiaProcObjectID = SystemParameter.GetParameterValue("AnesthesiaNewBornDGroup", "");
                        newBornExtraProcObjectID = SystemParameter.GetParameterValue("NewBornExtraProcedureDGroup", "");
                    }
                    else if (SurgeryProcedures.Count == 1)
                        anesthesiaProcObjectID = SystemParameter.GetParameterValue("AnesthesiaDGroup", "");
                    else
                        anesthesiaProcObjectID = SystemParameter.GetParameterValue("AnesthesiaDGroupMultipleOperation", "");
                }
                else if (anesthesiaSUTPoint >= 300 && anesthesiaSUTPoint < 500)
                {
                    if (patientAgeByDay < 28)
                    {
                        anesthesiaProcObjectID = SystemParameter.GetParameterValue("AnesthesiaNewBornCGroup", "");
                        newBornExtraProcObjectID = SystemParameter.GetParameterValue("NewBornExtraProcedureCGroup", "");
                    }
                    else if (SurgeryProcedures.Count == 1)
                        anesthesiaProcObjectID = SystemParameter.GetParameterValue("AnesthesiaCGroup", "");
                    else
                        anesthesiaProcObjectID = SystemParameter.GetParameterValue("AnesthesiaCGroupMultipleOperation", "");
                }
                else if (anesthesiaSUTPoint >= 500 && anesthesiaSUTPoint < 900)
                {
                    if (patientAgeByDay < 28)
                    {
                        anesthesiaProcObjectID = SystemParameter.GetParameterValue("AnesthesiaNewBornBGroup", "");
                        newBornExtraProcObjectID = SystemParameter.GetParameterValue("NewBornExtraProcedureBGroup", "");
                    }
                    else if (SurgeryProcedures.Count == 1)
                        anesthesiaProcObjectID = SystemParameter.GetParameterValue("AnesthesiaBGroup", "");
                    else
                        anesthesiaProcObjectID = SystemParameter.GetParameterValue("AnesthesiaBGroupMultipleOperation", "");
                }
                else if (anesthesiaSUTPoint >= 900 && anesthesiaSUTPoint < 2000)
                {
                    if (patientAgeByDay < 28)
                    {
                        anesthesiaProcObjectID = SystemParameter.GetParameterValue("AnesthesiaNewBornA3Group", "");
                        newBornExtraProcObjectID = SystemParameter.GetParameterValue("NewBornExtraProcedureA3Group", "");
                    }
                    else if (SurgeryProcedures.Count == 1)
                        anesthesiaProcObjectID = SystemParameter.GetParameterValue("AnesthesiaA3Group", "");
                    else
                        anesthesiaProcObjectID = SystemParameter.GetParameterValue("AnesthesiaA3GroupMultipleOperation", "");
                }
                else if (anesthesiaSUTPoint >= 2000 && anesthesiaSUTPoint < 3000)
                {
                    if (patientAgeByDay < 28)
                    {
                        anesthesiaProcObjectID = SystemParameter.GetParameterValue("AnesthesiaNewBornA2Group", "");
                        newBornExtraProcObjectID = SystemParameter.GetParameterValue("NewBornExtraProcedureA2Group", "");
                    }
                    else if (SurgeryProcedures.Count == 1)
                        anesthesiaProcObjectID = SystemParameter.GetParameterValue("AnesthesiaA2Group", "");
                    else
                        anesthesiaProcObjectID = SystemParameter.GetParameterValue("AnesthesiaA2GroupMultipleOperation", "");
                }
                else if (anesthesiaSUTPoint >= 3000 && anesthesiaSUTPoint <= 5000)
                {
                    if (patientAgeByDay < 28)
                    {
                        anesthesiaProcObjectID = SystemParameter.GetParameterValue(TTUtils.CultureService.GetText("M25183", "AnesthesiaNewBornA1Group"), "");
                        newBornExtraProcObjectID = SystemParameter.GetParameterValue("NewBornExtraProcedureA1Group", "");
                    }
                    else if (SurgeryProcedures.Count == 1)
                        anesthesiaProcObjectID = SystemParameter.GetParameterValue("AnesthesiaA1Group", "");
                    else
                        anesthesiaProcObjectID = SystemParameter.GetParameterValue("AnesthesiaA1GroupMultipleOperation", "");
                }
                else if (anesthesiaSUTPoint > 5000)  // 5000 den büyük bikaç ameliyat için eklendi, SUT ta açıklama olmadığı için burda da max fiyatlı anestezi hizmeti kullanıldı
                {
                    if (patientAgeByDay < 28)
                    {
                        anesthesiaProcObjectID = SystemParameter.GetParameterValue(TTUtils.CultureService.GetText("M25183", "AnesthesiaNewBornA1Group"), "");
                        newBornExtraProcObjectID = SystemParameter.GetParameterValue("NewBornExtraProcedureA1Group", "");
                    }
                    else if (SurgeryProcedures.Count == 1)
                        anesthesiaProcObjectID = SystemParameter.GetParameterValue("AnesthesiaA1Group", "");
                    else
                        anesthesiaProcObjectID = SystemParameter.GetParameterValue("AnesthesiaA1GroupMultipleOperation", "");
                }

                if (string.IsNullOrEmpty(anesthesiaProcObjectID))
                    throw new TTException(TTUtils.CultureService.GetText("M25180", "Anestezi hizmetine ulaşılamadı. Sistem parametrelerini kontrol ediniz."));

                if (patientAgeByDay < 28 && string.IsNullOrEmpty(newBornExtraProcObjectID))
                    throw new TTException(TTUtils.CultureService.GetText("M27232", "Yeni doğan ek hizmetine ulaşılamadı. Sistem parametrelerini kontrol ediniz."));

                // Yenidoğan ek hizmeti oluşturulur
                if (patientAgeByDay < 28)
                {
                    bool surgeryNewBornProcedureExists = false;
                    foreach (SurgeryNewBornProcedure newBornProc in SurgeryNewBornProcedures) // Hizmet varsa tekrar oluşturulmasın kontrolü
                    {
                        if (!newBornProc.IsCancelled)
                        {
                            if (newBornProc.ProcedureObject.ObjectID == Guid.Parse(newBornExtraProcObjectID))
                                surgeryNewBornProcedureExists = true;
                            else
                                ((ITTObject)newBornProc).Cancel();
                        }
                    }

                    if (!surgeryNewBornProcedureExists)
                    {
                        SurgeryNewBornProcedure newBornExtraProc = new SurgeryNewBornProcedure(ObjectContext);
                        newBornExtraProc.ActionDate = Common.RecTime();
                        newBornExtraProc.Amount = 1;
                        newBornExtraProc.CurrentStateDefID = SurgeryNewBornProcedure.States.Completed;
                        newBornExtraProc.ProcedureObject = (ProcedureDefinition)ObjectContext.GetObject(Guid.Parse(newBornExtraProcObjectID), typeof(ProcedureDefinition));
                        newBornExtraProc.PricingDate = SurgeryStartTime;
                        newBornExtraProc.CreationDate = SurgeryStartTime;

                        // Ana ameliyat seçilir, yoksa puanı en büyük olan seçilir, o da yoksa herhangi bir ameliyat seçilir
                        Surgery.SurgeryProcedureDiscountPercent surgeryProcedureDiscountPercent = null;
                        if (surgeryProcedureDiscountPercentList.Count > 0)
                        {
                            surgeryProcedureDiscountPercent = surgeryProcedureDiscountPercentList.FirstOrDefault(x => x.IncisionCode == "2");
                            if (surgeryProcedureDiscountPercent == null)
                                surgeryProcedureDiscountPercent = surgeryProcedureDiscountPercentList.OrderByDescending(x => x.SUTPoint).FirstOrDefault();
                            if (surgeryProcedureDiscountPercent == null)
                                surgeryProcedureDiscountPercent = surgeryProcedureDiscountPercentList[0];
                        }

                        if (surgeryProcedureDiscountPercent != null)
                            newBornExtraProc.SurgeryProcedure = surgeryProcedureDiscountPercent.surgeryProcedure;

                        if (newBornExtraProc.SurgeryProcedure != null)
                            newBornExtraProc.Position = newBornExtraProc.SurgeryProcedure.Position;
                        else
                            newBornExtraProc.Position = SurgeryLeftRight.AllTheSame;

                        SurgeryNewBornProcedures.Add(newBornExtraProc);
                        newBornExtraProc.SetPerformedDate();  // Episodeaction set edildikten sonra çalışması gerektiği için buraya yazıldı
                    }
                }

                // Anestezi hizmeti oluşturulur 
                if (AnesthesiaAndReanimation != null)
                {
                    bool anesthesiaProcedureExists = false;
                    foreach (AnesthesiaProcedure anesthesiaProc in AnesthesiaAndReanimation.AnaesthesiaAndReanimationAnesthesiaProcedures) // Hizmet varsa tekrar oluşturulmasın kontrolü
                    {
                        if (!anesthesiaProc.IsCancelled)
                        {
                            if (anesthesiaProc.ProcedureObject.ObjectID == Guid.Parse(anesthesiaProcObjectID))
                                anesthesiaProcedureExists = true;
                            else
                                ((ITTObject)anesthesiaProc).Cancel();
                        }
                    }

                    if (!anesthesiaProcedureExists)
                    {
                        AnesthesiaProcedure anestesiaProc = new AnesthesiaProcedure(ObjectContext);
                        anestesiaProc.ActionDate = Common.RecTime();
                        anestesiaProc.Amount = 1;
                        anestesiaProc.AnaesthesiaAndReanimation = AnesthesiaAndReanimation;
                        anestesiaProc.CurrentStateDefID = AnesthesiaProcedure.States.Completed;
                        anestesiaProc.ProcedureObject = AnesthesiaDefinition.GetByObjectID(new TTObjectContext(true), anesthesiaProcObjectID.ToString())[0];
                        anestesiaProc.CreationDate = AnesthesiaAndReanimation.AnesthesiaStartDateTime != null ? AnesthesiaAndReanimation.AnesthesiaStartDateTime : SurgeryStartTime;
                        anestesiaProc.PricingDate = anestesiaProc.CreationDate; // Anestezinin faturaya çıkacak tarihi, Anestezi Başlama Tarihi olsun
                                                                                //Artık  ProcedureDoctor2 yok AnestesiaResponsibleDoctors var
                                                                                //if (this.AnesthesiaAndReanimation.ProcedureDoctor2 != null)
                                                                                //    anestesiaProc.ProcedureDoctor2 = AnesthesiaAndReanimation.ProcedureDoctor2;
                        AnesthesiaAndReanimation.AnaesthesiaAndReanimationAnesthesiaProcedures.Add(anestesiaProc);
                        anestesiaProc.SetPerformedDate();// Episodeactionı set edildikten sonra çalışmasıgerektiğ içöin buraya yazıldı

                        // Ameliyatın anestezi puan bilgileri set edilir (Şimdilik formda gösterilmiyor diye kapatıldı - Mustafa)
                        //this.SurgeryTotalPoint = anesthesiaBUTPoint;
                        //this.SurgeryAnesthesiaPoint = anestesiaProc.ProcedureObject.GetSUTPoint();
                    }
                }
            }
        }

        // Ameliyat ücretlendikten sonra oluşan
        public void CancelAnesthesiaAndNewBornProcedure()
        {
            // Anestezi iptal edilir
            if (AnesthesiaAndReanimation != null)
            {
                foreach (AnesthesiaProcedure anesthesiaProc in AnesthesiaAndReanimation.AnaesthesiaAndReanimationAnesthesiaProcedures)
                    if (!anesthesiaProc.IsCancelled)
                        ((ITTObject)anesthesiaProc).Cancel();
            }

            // Yenidoğan ek hizmeti iptal edilir
            foreach (SurgeryNewBornProcedure newBornProc in SurgeryNewBornProcedures)
                if (!newBornProc.IsCancelled)
                    ((ITTObject)newBornProc).Cancel();
        }


        public class SurgeryProcedureDiscountPercent
        {
            public SurgeryProcedure surgeryProcedure;
            public double discountPercentage;
            public double packageDiscountPercentage;
            public double SUTPoint;
            public string IncisionCode;

            public SurgeryProcedureDiscountPercent()
            {
                discountPercentage = 1;
                packageDiscountPercentage = 1;
                SUTPoint = 0;
            }

            public SurgeryProcedureDiscountPercent(SurgeryProcedure procedure)
            {
                surgeryProcedure = procedure;
                discountPercentage = 1;
                packageDiscountPercentage = 1;
                SUTPoint = 0;
            }
        }

        // Kesi bilgisi güncellendiğinde fiyatları yeniden hesaplayan metod
        public void AccountingOperation()
        {
            if (IsOldAction != true)
            {
                List<Surgery.SurgeryProcedureDiscountPercent> surgeryProcedureDiscountPercentList = new List<Surgery.SurgeryProcedureDiscountPercent>();
                double anesthesiaSUTPoint = 0;

                FillSurgeryProcedureDiscountPercentList(ref surgeryProcedureDiscountPercentList, ref anesthesiaSUTPoint);

                //SurgeryProcedure ve SurgeryPackageProcedure ler yeni indirim bilgileri ile yeniden ücretlendirilir
                foreach (Surgery.SurgeryProcedureDiscountPercent surgeryProcedureDiscountPercent in surgeryProcedureDiscountPercentList)
                {
                    SurgeryProcedure sp = surgeryProcedureDiscountPercent.surgeryProcedure;

                    if (sp.Amount.HasValue == false) // SurgeryProcedure ler ilk oluşurken burdan geçtiğinde amount boşsa 1 yapsın 
                        sp.Amount = 1;

                    double? discountPercent = null;

                    if (SurgeryStartTime.HasValue)
                    {
                        sp.PricingDate = SurgeryStartTime;    // Ameliyatların faturaya çıkacak tarihi, Ameliyat Başlama Tarihi olsun
                        sp.CreationDate = SurgeryStartTime;
                    }

                    if (surgeryProcedureDiscountPercent.discountPercentage != 1)
                        discountPercent = (1 - surgeryProcedureDiscountPercent.discountPercentage) * 100;

                    if (sp.AccountTransactions.Count == 0)
                    {
                        sp.DiscountPercent = discountPercent;
                        sp.AccountOperation(AccountOperationTimeEnum.PREPOST);
                    }
                    else if (sp.DiscountPercent != discountPercent)
                    {
                        sp.DiscountPercent = discountPercent;
                        sp.ChangeMyProtocol(SubEpisode.OpenSubEpisodeProtocol);
                    }

                    sp.SetIncisionAndDateOfAccountTransactions();

                    // SurgeryPackageProcedure tekrar hesaplanır
                    double? packageDiscountPercent = null;
                    if (surgeryProcedureDiscountPercent.packageDiscountPercentage != 1)
                        packageDiscountPercent = (1 - surgeryProcedureDiscountPercent.packageDiscountPercentage) * 100;

                    sp.CreatePackageProcedure(packageDiscountPercent, true);
                }
            }
        }

        public void FillSurgeryProcedureDiscountPercentList(ref List<Surgery.SurgeryProcedureDiscountPercent> surgeryProcedureDiscountPercentList, ref double anesthesiaSUTPoint)
        {
            const double sameIncisionPercentage = 0.3;             // Aynı kesi P siz ise %30 
            const double sameIncisionPackagePercentage = 0.25;     // Aynı kesi P li  ise %25
            const double differentClinicCodePercentage = 0.25;     // Farklı klinik kod ise ilave %25
            const double differentIncisionPercentage = 0.5;        // Farklı kesi %50 (P li veya P siz farketmez)

            foreach (SurgeryProcedure sp in SurgeryProcedures)
            {
                if (sp.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                {
                    if (sp.AyniFarkliKesi == null)
                        throw new TTException(sp.ProcedureObject.Code + " " + sp.ProcedureObject.Name + " ameliyatının kesi bilgisi boş bırakılamaz.");

                    if (sp.PackageProcedureObject == null)
                        sp.PackageProcedureObject = sp.ProcedureObject.MyPackageProcedure(); // Ameliyatın Paket kodu varsa burada set edilir

                    // 1 Aynı seans + aynı kesi
                    // 2 Ana Ameliyat (Farklı seans + farklı kesi)
                    // 3 Aynı seansta + farklı kesi
                    // 4 Aynı seansta + farklı kesi + farklı klinik kod
                    // 5 Aynı seansta + aynı kesi + farklı klinik kod
                    Surgery.SurgeryProcedureDiscountPercent surgeryProcedureDiscountPercent = new Surgery.SurgeryProcedureDiscountPercent(sp);
                    surgeryProcedureDiscountPercent.IncisionCode = sp.AyniFarkliKesi.ayniFarkliKesiKodu;

                    if (sp.AyniFarkliKesi.ayniFarkliKesiKodu.Equals("2") == false) // Ana ameliyat değilse
                    {
                        if (sp.AyniFarkliKesi.ayniFarkliKesiKodu.Equals("1") || sp.AyniFarkliKesi.ayniFarkliKesiKodu.Equals("5")) // Aynı kesi
                        {
                            surgeryProcedureDiscountPercent.discountPercentage = sameIncisionPercentage;
                            surgeryProcedureDiscountPercent.packageDiscountPercentage = sameIncisionPackagePercentage;
                        }
                        else if (sp.AyniFarkliKesi.ayniFarkliKesiKodu.Equals("3") || sp.AyniFarkliKesi.ayniFarkliKesiKodu.Equals("4")) // Farklı kesi
                        {
                            surgeryProcedureDiscountPercent.discountPercentage = differentIncisionPercentage;
                            surgeryProcedureDiscountPercent.packageDiscountPercentage = differentIncisionPercentage;
                        }

                        // Farklı klinik kod ise orana %25 ilave edilir
                        if (sp.AyniFarkliKesi.ayniFarkliKesiKodu.Equals("4") || sp.AyniFarkliKesi.ayniFarkliKesiKodu.Equals("5"))
                        {
                            surgeryProcedureDiscountPercent.discountPercentage += differentClinicCodePercentage;
                            surgeryProcedureDiscountPercent.packageDiscountPercentage += differentClinicCodePercentage;
                        }
                    }

                    double SUTPoint = sp.ProcedureObject.GetSUTPoint();
                    surgeryProcedureDiscountPercent.SUTPoint = SUTPoint;

                    anesthesiaSUTPoint += SUTPoint * surgeryProcedureDiscountPercent.discountPercentage;
                    surgeryProcedureDiscountPercentList.Add(surgeryProcedureDiscountPercent);
                }
            }
        }

        // Kesi bilgisi güncellendiğinde fiyatları yeniden hesaplayan metod
        // Puanlara göre azalan sıralayan versiyon, artık kullanılmıyor !!!
        //public void AccountingOperation()
        //{
        //    if (this.IsOldAction != true)
        //    {
        //        List<SurgeryProcedure> sortedSurgeryList = new List<SurgeryProcedure>();  // Aynı seansları tutacak puana göre azalan sıralı liste
        //        List<double> discountPercentageList = new List<double>();                 // P siz ameliyatların indirim oranı listesi
        //        List<double> discountPercentagePackageList = new List<double>();          // P li ameliyatların indirim oranı listesi
        //        double anesthesiaSUTPoint = 0;

        //        GetSortedSurgeryAndDiscountListsForPricing(ref sortedSurgeryList, ref discountPercentageList, ref discountPercentagePackageList, ref anesthesiaSUTPoint);

        //        //SurgeryProcedure ve SurgeryPackageProcedure ler yeni indirim bilgileri ile yeniden ücretlendirilir
        //        for (int k = 0; k < sortedSurgeryList.Count; k++)
        //        {
        //            SurgeryProcedure sp = (SurgeryProcedure)sortedSurgeryList[k];
        //            double? discountPercent = null;

        //            if (SurgeryStartTime.HasValue)
        //            {
        //                sp.PricingDate = SurgeryStartTime;    // Ameliyatların faturaya çıkacak tarihi, Ameliyat Başlama Tarihi olsun
        //                sp.CreationDate = SurgeryStartTime;
        //            }

        //            if ((double)discountPercentageList[k] != 1)
        //                discountPercent = (double)((1 - (double)discountPercentageList[k]) * 100);

        //            if (sp.AccountTransactions.Count == 0)
        //            {
        //                sp.DiscountPercent = discountPercent;
        //                sp.AccountOperation(AccountOperationTimeEnum.PREPOST);
        //            }
        //            else if (sp.DiscountPercent != discountPercent)
        //            {
        //                sp.DiscountPercent = discountPercent;
        //                sp.ChangeMyProtocol(SubEpisode.OpenSubEpisodeProtocol);
        //            }

        //            sp.SetIncisionAndDateOfAccountTransactions();

        //            // SurgeryPackageProcedure tekrar hesaplanır
        //            double? packageDiscountPercent = null;
        //            if ((double)discountPercentagePackageList[k] != 1)
        //                packageDiscountPercent = (double)((1 - (double)discountPercentagePackageList[k]) * 100);

        //            sp.CreatePackageProcedure(packageDiscountPercent, true);
        //        }
        //    }
        //}

        //public void GetSortedSurgeryAndDiscountListsForPricing(ref List<SurgeryProcedure> sortedSurgeryList, ref List<double> discountPercentageList, ref List<double> discountPercentagePackageList, ref double anesthesiaSUTPoint)
        //{
        //    List<double> surgeryPointList = new List<double>();

        //    const double sameIncisionPercentage = 0.3;             // Aynı kesi P siz ise %30 
        //    const double sameIncisionPackagePercentage = 0.25;     // Aynı kesi P li  ise %25
        //    const double differentClinicCodePercentage = 0.25;     // Farklı klinik kod ise ilave %25
        //    const double differentIncisionPercentage = 0.5;        // Farklı kesi %50 (P li veya P siz farketmez)

        //    foreach (SurgeryProcedure sp in SurgeryProcedures)
        //    {
        //        if (sp.CurrentStateDef.Status != StateStatusEnum.Cancelled)
        //        {
        //            if (sp.AyniFarkliKesi == null)
        //                throw new TTException(sp.ProcedureObject.Code + " " + sp.ProcedureObject.Name + " ameliyatının kesi bilgisi boş bırakılamaz.");

        //            if (sp.PackageProcedureObject == null)
        //                sp.PackageProcedureObject = sp.ProcedureObject.MyPackageProcedure(); // Ameliyatın Paket kodu varsa burada set edilir

        //            sortedSurgeryList.Add(sp);
        //        }
        //    }

        //    sortedSurgeryList.Sort(new AscSurgeryProcedureComparer());  // Aynı seans olan ameliyatlar puanına göre sıralanır

        //    for (int j = 0; j < sortedSurgeryList.Count; j++)
        //        surgeryPointList.Add((double)((SurgeryProcedure)sortedSurgeryList[j]).ProcedureObject.GetSUTPoint());

        //    // 1 Aynı seans + aynı kesi
        //    // 2 Farklı seans + farklı kesi
        //    // 3 Aynı seansta + farklı kesi
        //    // 4 Aynı seansta + farklı kesi + farklı klinik kod
        //    // 5 Aynı seansta + aynı kesi + farklı klinik kod
        //    double percentage;
        //    double percentagePackage;
        //    for (int i = 0; i < sortedSurgeryList.Count; i++)
        //    {
        //        if (i == 0) // && differentSessionSurgeryList.Count == 0)
        //        {
        //            percentage = 1;
        //            percentagePackage = 1;
        //        }
        //        else
        //        {   // Aynı kesi
        //            if (((SurgeryProcedure)sortedSurgeryList[i]).AyniFarkliKesi.ayniFarkliKesiKodu.Equals("1") || ((SurgeryProcedure)sortedSurgeryList[i]).AyniFarkliKesi.ayniFarkliKesiKodu.Equals("5"))
        //            {
        //                percentage = sameIncisionPercentage;
        //                percentagePackage = sameIncisionPackagePercentage;
        //            }
        //            else // Farklı kesi
        //            {
        //                percentage = differentIncisionPercentage;
        //                percentagePackage = differentIncisionPercentage;
        //            }

        //            // Farklı klinik kod ise orana %25 ilave edilir
        //            if (((SurgeryProcedure)sortedSurgeryList[i]).AyniFarkliKesi.ayniFarkliKesiKodu.Equals("4") || ((SurgeryProcedure)sortedSurgeryList[i]).AyniFarkliKesi.ayniFarkliKesiKodu.Equals("5"))
        //            {
        //                percentage += differentClinicCodePercentage;
        //                percentagePackage += differentClinicCodePercentage;
        //            }
        //        }

        //        anesthesiaSUTPoint += (double)(surgeryPointList[i] * percentage);
        //        discountPercentageList.Add(percentage);
        //        discountPercentagePackageList.Add(percentagePackage);
        //    }
        //}

        protected override List<EpisodeAction.OldActionPropertyObject> OldActionPropertyList()
        {
            List<EpisodeAction.OldActionPropertyObject> propertyList = base.OldActionPropertyList();
            if (propertyList == null)
                propertyList = new List<EpisodeAction.OldActionPropertyObject>();

            //            propertyList.Add(new OldActionPropertyObject("Protokol No",Common.ReturnObjectAsString(this.ProtocolNo)));
            //            propertyList.Add(new OldActionPropertyObject("Ameliyatı Tarihi",Common.ReturnObjectAsString(SurgeryStartTime)));
            //            propertyList.Add(new OldActionPropertyObject("Rapor No",Common.ReturnObjectAsString(SurgeryReportNo)));
            //            propertyList.Add(new OldActionPropertyObject("Rapor Tarihi",Common.ReturnObjectAsString(SurgeryReportDate)));
            //            propertyList.Add(new OldActionPropertyObject("Rapor ",Common.ReturnObjectAsString(SurgeryReport)));
            if (ProcedureDoctor != null)
                propertyList.Add(new EpisodeAction.OldActionPropertyObject("Sorumlu Doktor ", Common.ReturnObjectAsString(ProcedureDoctor.Name)));
            //            if(this.ProcedureSpeciality!=null)
            //                propertyList.Add(new OldActionPropertyObject("Uzmanlık Dalı",Common.ReturnObjectAsString(this.ProcedureSpeciality.Name)));
            //
            return propertyList;
        }


        protected override List<List<List<EpisodeAction.OldActionPropertyObject>>> OldActionChildRelationList()
        {
            List<List<List<EpisodeAction.OldActionPropertyObject>>> gridList;
            if (base.OldActionChildRelationList() == null)
                gridList = new List<List<List<EpisodeAction.OldActionPropertyObject>>>();
            else
                gridList = base.OldActionChildRelationList();
            //            // Ameliyat İşlemleri
            //            List<List<OldActionPropertyObject>> gridMainSurgeryProceduresRowList=new List<List<OldActionPropertyObject>>();
            //            foreach(SurgeryProcedure Procedure in MainSurgeryProcedures)
            //            {
            //                List<OldActionPropertyObject> gridMainSurgeryProceduresRowColumnList=new List<OldActionPropertyObject>();
            //                gridMainSurgeryProceduresRowColumnList.Add(new OldActionPropertyObject("İşlem Tarihi",Common.ReturnObjectAsString(Procedure.ActionDate)));
            //                gridMainSurgeryProceduresRowColumnList.Add(new OldActionPropertyObject("Ameliyat İşlemi",Common.ReturnObjectAsString(Procedure.ProcedureObject.Name)));
            //                gridMainSurgeryProceduresRowList.Add(gridMainSurgeryProceduresRowColumnList);
            //            }
            //            gridList.Add(gridMainSurgeryProceduresRowList);
            //
            //            // Ameliyata Katılan Diğer Birimler
            //            List<List<OldActionPropertyObject>> gridParticipantDepartmantsRowList=new List<List<OldActionPropertyObject>>();
            //            foreach(SurgeryParticipantDepartment department in this.ParticipantDepartmants)
            //            {
            //                List<OldActionPropertyObject> gridParticipantDepartmantsRowColumnList=new List<OldActionPropertyObject>();
            //                gridParticipantDepartmantsRowColumnList.Add(new OldActionPropertyObject("Ameliyata Katılan Diğer Birimler",Common.ReturnObjectAsString(department.Department.Name)));
            //                if(department.ResponsibleDoctor!=null)
            //                    gridParticipantDepartmantsRowColumnList.Add(new OldActionPropertyObject("Sorumlu Cerrah",Common.ReturnObjectAsString(department.ResponsibleDoctor.Name)));
            //                gridParticipantDepartmantsRowList.Add(gridParticipantDepartmantsRowColumnList);
            //            }
            //            gridList.Add(gridParticipantDepartmantsRowList);
            //
            // Ameliyat Ekibi
            List<List<EpisodeAction.OldActionPropertyObject>> gridPersonnelsRowList = new List<List<EpisodeAction.OldActionPropertyObject>>();
            foreach (SurgeryPersonnel Personnel in AllSurgeryPersonnels)
            {
                List<EpisodeAction.OldActionPropertyObject> gridPersonnelsRowColumnList = new List<EpisodeAction.OldActionPropertyObject>();
                if (Personnel.Personnel != null)
                    gridPersonnelsRowColumnList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M25155", "Ameliyat Ekibi"), Common.ReturnObjectAsString(Personnel.Personnel.Name)));
                gridPersonnelsRowColumnList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M25735", "Görevi"), Common.ReturnObjectAsString(Personnel.Role)));
                gridPersonnelsRowList.Add(gridPersonnelsRowColumnList);
            }
            gridList.Add(gridPersonnelsRowList);

            return gridList;
        }

        public void FireIntensiveCareAfterSurgery()
        {
            // anestezi reanimasyon modülüne taşındı
            //            if(this.IntensiveCareAfterSurgeries.Count<1)
            //            {
            //                IntensiveCareAfterSurgery  intensiveCareAfterSurgery = new IntensiveCareAfterSurgery(this,(ResSection)this.MasterResource);
            //            }
        }

        //private ResSection anesthesiaAndReanimationMasterResource;

        //public ResSection AnesthesiaAndReanimationMasterResource
        //{
        //    get
        //    {
        //        return anesthesiaAndReanimationMasterResource;
        //    }
        //    set
        //    {
        //        anesthesiaAndReanimationMasterResource = value;
        //    }
        //}

        public void FireAnesthesiaAndReanimation(ResSection anesthesiaAndReanimationMasterResource)
        {
            bool fire = false;
            if (AnesthesiaAndReanimation == null)
            {
                fire = true;
            }
            else if (AnesthesiaAndReanimation.IsCancelled)
            {
                fire = true;
            }
            if (fire)
            {
                //                ResSection masterResource=GetSelectedAcionDefualtMasterResource(this.ObjectContext,ActionTypeEnum.AnesthesiaAndReanimation,"Anestezi İsteği Yapılacak Birimi seçiniz");
                //                if(masterResource!=null)
                if (anesthesiaAndReanimationMasterResource != null)
                {
                    AnesthesiaAndReanimation anesthesiaAndReanimation = new AnesthesiaAndReanimation(ObjectContext, (Surgery)this, (ResSection)anesthesiaAndReanimationMasterResource);
                }
                else
                {
                    throw new Exception(SystemMessage.GetMessage(624));

                }
            }
        }

        public void FireSurgeryExtension()
        {
            bool fire = false;
            if (SurgeryExtension == null)
            {
                fire = true;
            }
            else if (SurgeryExtension.IsCancelled)
            {
                fire = true;
            }
            if (fire)
            {
                SurgeryExtension surgeryExtension = new SurgeryExtension(ObjectContext, (Surgery)this);
            }
        }

        // Tüm SurgeryProcedure lerin AyniFarkliKesi bilgisini set eder
        public void SetMedulaAyniFarkliKesiOfSurgeryProcedures()
        {
            foreach (SurgeryProcedure sp in SurgeryProcedures)
                sp.SetMedulaAyniFarkliKesi();
        }

        public override SubEpisodeStatusEnum GetSubEpisodePatientStatus()
        {
            return SubEpisodeStatusEnum.Daily;
        }

        // Yeni SubEpisode oluşturulmasına karar veren metod
        public override bool IsNewSubEpisodeNeeded()
        {
            if (base.IsNewSubEpisodeNeeded() == false)
                return false;

            if (Episode.PatientStatus == PatientStatusEnum.Outpatient && SubEpisode.IsSGK == true && IsMedulaProvisionNecessaryProcedureExists() == true)
                return Episode.Patient.SuitableToCreateNewDailySubEpisode(GetSubEpisodeSpeciality());

            return false;
        }

        // SEP in değiştirilmesi gereken propertyleri varsa bu metodda set edilmeli
        public override void FillLocalSEPProperties(ref SubEpisodeProtocol sep)
        {
            // Aşağıdaki 3 alan formda kalacak mı ? Bilinmediği için kapatıldı şimdilik (MDZ)

            //Tedavi Tipi (Zorunlu)
            //if (this.MedulaProvision != null && this.MedulaProvision.TedaviTipi != null && this.MedulaProvision.TedaviTipi.tedaviTipiKodu != null)
            //    provizyonGirisDVO.tedaviTipi = this.MedulaProvision.TedaviTipi.tedaviTipiKodu;

            //Takip Tipi (Zorunlu)
            //if (this.MedulaProvision != null && this.MedulaProvision.TakipTipi != null && this.MedulaProvision.TakipTipi.takipTipiKodu != null)
            //    provizyonGirisDVO.takipTipi = this.MedulaProvision.TakipTipi.takipTipiKodu;

            //Brans Kodu (Zorunlu)
            //if (this.MedulaProvision != null && this.MedulaProvision.Brans != null && this.MedulaProvision.Brans.bransKodu != null)
            //    provizyonGirisDVO.bransKodu = this.MedulaProvision.Brans.bransKodu;

            //SubEpisodeProtocol parentSEP = this.Episode.GetFirstSEP();
            //if (parentSEP != null)
            //    subEpisodeProtocol.ParentSEP = parentSEP;
        }

        public void SurgeryPersonnelIsResquired()
        {

            string errorString = "";
            foreach (SurgeryProcedure sP in MainSurgeryProcedures)
            {
                if (sP.ProcedureDoctor == null)
                {
                    errorString = sP.ProcedureObject.Name + " ameliyatı için Sorumlu Cerrah girmediniz \n ";
                }
                if (errorString != "")
                {
                    throw new Exception(errorString);
                }
            }
        }


        public void CheckSurgeryTime()
        {
            if (SurgeryStartTime == null)
                throw new Exception("'Ameliyatı Başlatma Tarih/Saat' Alanı boş olamaz");
            if (SurgeryEndTime == null)
                throw new Exception("'Ameliyatı Bitirme Tarih/Saat' Alanı boş olamaz");

            var RecTime = Common.RecTime();

            if (RecTime < SurgeryStartTime)
            {
                throw new Exception("'Ameliyatı Başlatma Tarih/Saat' , ileri tarihli olamaz ");
            }

            if (RecTime < SurgeryEndTime)
            {
                throw new Exception("'Ameliyatı Bitirme Tarih/Saat' , ileri tarihli olamaz ");
            }

            if (SurgeryEndTime <= SurgeryStartTime)
            // if(Common.DateDiff(0,Convert.ToDateTime(this.AnesthesiaEndDateTime),Convert.ToDateTime(this.AnesthesiaStartDateTime),false)<0)
            {
                string[] hataParamList = new string[] { "'Ameliyat Bitiş Tarihi'", "'Ameliyat Başlama Tarihi'" };//{0} , {1} ' ne eşit veya ondan küçük olamaz.
                                                                                                                 //TODO hata kodu eklenip üstteki throw açılacak.
                                                                                                                 //throw new TTUtils.TTException(SystemMessage.GetMessage(202, hataParamList));
                throw new Exception("'Ameliyat Başlama Tarihi' , 'Ameliyat Bitiş Tarihi'ne eşit ya da sonra olamaz. ");
            }
            if (AnesthesiaAndReanimation != null)
            {
                CheckSurgeryAndAnesthesiaTime();
            }

        }

        public void CheckSurgeryAndAnesthesiaTime()
        {

            if (SurgeryStartTime <= AnesthesiaAndReanimation.AnesthesiaStartDateTime)
            //if(Common.DateDiff(0,Convert.ToDateTime(this.MainSurgery.SurgeryStartTime),Convert.ToDateTime(this.AnesthesiaStartDateTime),false)<0)
            {
                string[] hataParamList = new string[] { "'Ameliyat Başlama Tarihi'", "'Anestezi Başlama Tarihi'" };//{0} , {1} ' ne eşit veya ondan küçük olamaz.
                throw new TTUtils.TTException(SystemMessage.GetMessageV3(202, hataParamList));
                //throw new Exception("'Anestezi Başlama Tarihi' , 'Ameliyat Başlama Tarihinden' sonra olamaz. ");
            }

            if (AnesthesiaAndReanimation.AnesthesiaEndDateTime <= SurgeryEndTime)
            //if(Common.DateDiff(0,Convert.ToDateTime(this.AnesthesiaEndDateTime),Convert.ToDateTime(this.MainSurgery.SurgeryEndTime),false)>0)
            {
                string[] hataParamList = new string[] { "'Anestezi Bitiş Tarihi'", "'Ameliyat Bitiş Tarihi'" };//{0} , {1} ' ne eşit veya ondan küçük olamaz.
                throw new TTUtils.TTException(SystemMessage.GetMessageV3(206, hataParamList));
                // throw new Exception("'Anestezi Bitiş Tarihi' , 'Ameliyat Bitiş Tarihinden' önce olamaz. ");
            }

            if (AnesthesiaAndReanimation.AnesthesiaStartDateTime >= SurgeryEndTime)

            //if(Common.DateDiff(0,Convert.ToDateTime(this.AnesthesiaStartDateTime),Convert.ToDateTime(this.MainSurgery.SurgeryEndTime),false)<0)
            {
                string[] hataParamList = new string[] { "'Anestezi Başlama Tarihi'", "'Ameliyat Bitiş Tarihi'" };//{0} , {1} ' ne eşit veya ondan küçük olamaz.
                                                                                                                 //TODO hata kodu eklenip üstteki throw açılacak.
                                                                                                                 //throw new TTUtils.TTException(SystemMessage.GetMessage(206, hataParamList));
                throw new Exception("'Anestezi Başlama Tarihi' , 'Ameliyat Bitiş Tarihi'ne eşit ya da sonra olamaz. ");
            }

        }

        public void CheckCesareanAndFireBirthReport()
        {
            bool found = false;
            string cesarean = TTObjectClasses.SystemParameter.GetParameterValue("SezaryenButCode", "619930").Trim();
            string cesareanMultiplePregnancy = TTObjectClasses.SystemParameter.GetParameterValue("SezaryenCogulGebelikButCode", "619929").Trim();
            foreach (SurgeryProcedure sp in SurgeryProcedures)
            {

                foreach (ProcedurePriceDefinition pp in sp.ProcedureObject.ProcedurePrice)
                {
                    if (pp.PricingDetail != null)
                    {
                        if (pp.PricingDetail.ExternalCode.Trim() == cesarean || pp.PricingDetail.ExternalCode.Trim() == cesareanMultiplePregnancy)
                        {
                            found = true;
                            break;
                        }
                    }
                }
            }
            if (found)
            {
                CreateNewBirthReportRequest();
            }
        }



        public bool HasUncompletedLinkedAction(EpisodeAction checkedByEpisodeAction)
        {

            foreach (SubSurgery subSurgery in SubSurgeries)
            {
                if (subSurgery.CurrentStateDef.Status == StateStatusEnum.Uncompleted && checkedByEpisodeAction.ObjectID != subSurgery.ObjectID)
                {
                    return true;
                }
            }

            if (AnesthesiaAndReanimation != null)
            {
                if (AnesthesiaAndReanimation.CurrentStateDef.Status == StateStatusEnum.Uncompleted && checkedByEpisodeAction.ObjectID != AnesthesiaAndReanimation.ObjectID)
                {
                    return true;
                }
            }

            if (SurgeryExtension != null)
            {
                if (SurgeryExtension.CurrentStateDef.Status == StateStatusEnum.Uncompleted && checkedByEpisodeAction.ObjectID != SurgeryExtension.ObjectID)
                {
                    return true;
                }
            }
            return false;
        }

        // Anesteziyi ücretlendirmek  için checkedByEpisodeAction hariç tüm  ameliyat ve ek ameliyatların ameliyat adımından ilerletilip ilerletilmediğini kontrol eder
        public bool HasUncompletedSurgery(EpisodeAction checkedByEpisodeAction)
        {
            if (checkedByEpisodeAction.ObjectID != ObjectID)
            {
                if (CurrentStateDefID != Surgery.States.Completed && CurrentStateDefID != Surgery.States.WaitingForSubSurgeries)
                    return true;
            }

            foreach (SubSurgery subSurgery in SubSurgeries)
            {
                if (subSurgery.CurrentStateDef.Status == StateStatusEnum.Uncompleted && checkedByEpisodeAction.ObjectID != subSurgery.ObjectID)
                {
                    return true;
                }
            }

            return false;
        }

        public void ControlAndCreateAnesthesiaAndNewBornProcedure()
        {
            if (!HasUncompletedSurgery(this))
            {
                //AccountingOperation();
                CreateAnesthesiaAndNewBornProcedure();
            }
        }

        public void ControlAndCancelAnesthesiaAndNewBornProcedure()
        {
            if (!HasUncompletedSurgery(this))
                CancelAnesthesiaAndNewBornProcedure();
        }

        public void CheckAndComplete(EpisodeAction completedByEpisodeAction)
        {
            if (this != null)
            {
                if ((!HasUncompletedLinkedAction(completedByEpisodeAction)) && CurrentStateDefID == Surgery.States.WaitingForSubSurgeries)
                    CurrentStateDefID = Surgery.States.Completed;
            }
        }

        public void NotifyAndSendSMSDoctors()
        {
            if (IsOldAction != true)
            {
                List<string> doctorlist = new List<string>();
                string messageText = "";

                UserMessage userMessage = new UserMessage();
                string hospitalShortName = SystemParameter.GetParameterValue("HOSPITALSHORTNAME", "");
                int sendSurgerySMSorNotification = Convert.ToInt32(SystemParameter.GetParameterValue("SENDSURGERYSMSORNOTIFICATION", "-1"));//yatış doktoruna uyarı mı sms mi gitsin

                bool sendSMSToSurgeryTeam = Convert.ToBoolean(SystemParameter.GetParameterValue("SENDSMSTOSURGERYTEAM", "FALSE"));//Ameliyat işlemi yapan diğer doktorlara da sms ve uyarı gitsin

                bool sendSMS = (sendSurgerySMSorNotification == (int)SendSurgerySMSORNotEnum.SendSMS || sendSurgerySMSorNotification == (int)SendSurgerySMSORNotEnum.SendSMSandNotification) ? true : false;

                if (this.MasterAction != null && this.MasterAction is InPatientPhysicianApplication && ((InPatientPhysicianApplication)this.MasterAction).ProcedureDoctor != null)
                {
                    ResUser doctor = ((InPatientPhysicianApplication)this.MasterAction).ProcedureDoctor;

                    doctorlist.Add(doctor.ObjectID.ToString());

                    messageText += "Sayın Doktor" + ", ";
                    messageText += DateTime.Now.ToString("dd MMMM yyyy") + " tarihinde ";
                    messageText += SubEpisode.ProtocolNo + " kabul numaralı ";
                    messageText += Episode.Patient != null ? ("'" + Episode.Patient.FullName + "' hastası için ") : "";
                    messageText += "ameliyat işlemi tamamlanmıştır.";
                    List<ResUser> users = new List<ResUser> { doctor };
                    if (doctor.PhoneNumber != null && sendSMS)
                        userMessage.SendSMSPerson(users, messageText, SMSTypeEnum.SurgeryCompletedSMS);

                }

                if (sendSMSToSurgeryTeam)
                {

                    var surgeryProcs = SurgeryProcedures.Where(x => x.SurgeryResponsibleDoctors != null && x.SurgeryResponsibleDoctors.Count > 0).ToList();
                    var responsibleDoctorList = surgeryProcs.SelectMany(x => x.SurgeryResponsibleDoctors).Select(x => x.ResponsibleDoctor).ToList();
                    var procedureDoctorList = surgeryProcs.Where(x => x.ProcedureDoctor != null).Select(x => x.ProcedureDoctor).ToList();

                    if (responsibleDoctorList.Count > 0)
                        doctorlist.AddRange(responsibleDoctorList.Select(x => x.ObjectID.ToString()));

                    if (sendSMS)
                    {
                        userMessage.SendSMSPerson(responsibleDoctorList.Where(x => !string.IsNullOrEmpty(x.PhoneNumber)).ToList(), messageText, SMSTypeEnum.SurgeryCompletedSMS);
                        userMessage.SendSMSPerson(procedureDoctorList.Where(x => !string.IsNullOrEmpty(x.PhoneNumber)).ToList(), messageText, SMSTypeEnum.SurgeryCompletedSMS);
                    }

                    //    foreach (var item in SurgeryProcedures)
                    //    {
                    //        if (item.SurgeryResponsibleDoctors != null)
                    //        {
                    //            foreach (var item2 in item.SurgeryResponsibleDoctors)
                    //            {
                    //                doctorlist.Add(item2.ResponsibleDoctor.ObjectID.ToString());

                    //                if (item2.ResponsibleDoctor.PhoneNumber != null && sendSMS)
                    //                    userMessage.SendSMSPerson(item2.ResponsibleDoctor, messageText);

                    //                //messageText += "Sayın " + item2.ResponsibleDoctor.Name + ", ";
                    //                //messageText += DateTime.Now.ToString("dd MMMM yyyy") + " tarihinde ";
                    //                //messageText += SubEpisode.ProtocolNo + " kabul numaralı ";
                    //                //messageText += Episode.Patient != null ? ("'" + Episode.Patient.FullName + "' hastası için ") : "";
                    //                //messageText += "ameliyat işlemi tamamlanmıştır.";
                    //            }


                    //        }
                    //        else if (item.ProcedureDoctor != null)
                    //        {
                    //            doctorlist.Add(item.ProcedureDoctor.ObjectID.ToString());

                    //            if (item.ProcedureDoctor.PhoneNumber != null && sendSMS)
                    //                userMessage.SendSMSPerson(ProcedureDoctor, messageText);

                    //            //messageText += "Sayın " + item.ProcedureDoctor.Name + ", ";
                    //            //messageText += DateTime.Now.ToString("dd MMMM yyyy") + " tarihinde ";
                    //            //messageText += SubEpisode.ProtocolNo + " kabul numaralı ";
                    //            //messageText += Episode.Patient != null ? ("'" + Episode.Patient.FullName + "' hastası için ") : "";
                    //            //messageText += "ameliyat işlemi tamamlanmıştır.";
                    //        }


                    //    }
                }


                if (doctorlist.Count > 0 && (sendSurgerySMSorNotification == (int)SendSurgerySMSORNotEnum.SendNotification || sendSurgerySMSorNotification == (int)SendSurgerySMSORNotEnum.SendSMSandNotification))
                {
                    doctorlist = doctorlist.Distinct().ToList();

                    TTUtils.AtlasNotificationContainer atlasNotification = new TTUtils.AtlasNotificationContainer();
                    atlasNotification.users = doctorlist;
                    atlasNotification.notificationType = TTUtils.AtlasNotificationType.Info;
                    atlasNotification.contentType = TTUtils.AtlasContentType.Notification;

                    atlasNotification.content = messageText;
                    string notificationStr = JsonConvert.SerializeObject(atlasNotification);

                    TTUtils.AtlasSignalRHubFactory.Instance.HandleUserNotification(notificationStr);
                }
            }
        }


        #endregion Methods



        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(Surgery).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;



            if (fromState == Surgery.States.SurgeryRequest && toState == Surgery.States.Surgery)
                PostTransition_SurgeryRequest2Surgery();
            else if (fromState == Surgery.States.SurgeryRequest && toState == Surgery.States.Cancelled)
                PostTransition_SurgeryRequest2Cancelled();
            else if (fromState == Surgery.States.Surgery && toState == Surgery.States.SurgeryRequest)
                PostTransition_Surgery2SurgeryRequest();
            else if (fromState == Surgery.States.Surgery && toState == Surgery.States.Completed)
                PostTransition_Surgery2Completed();
            else if (fromState == Surgery.States.Surgery && toState == Surgery.States.WaitingForSubSurgeries)
                PostTransition_Surgery2WaitingForSubSurgeries();
            else if (fromState == Surgery.States.Surgery && toState == Surgery.States.Rejected)
                PostTransition_Surgery2Rejected();
            else if (fromState == Surgery.States.Surgery && toState == Surgery.States.Cancelled)
                PostTransition_Surgery2Cancelled();
            else if (fromState == Surgery.States.WaitingForSubSurgeries && toState == Surgery.States.Completed)
                PostTransition_WaitingForSubSurgeries2Completed();
            else if (fromState == Surgery.States.WaitingForSubSurgeries && toState == Surgery.States.Cancelled)
                PostTransition_WaitingForSubSurgeries2Cancelled();
            else if (fromState == Surgery.States.Completed && toState == Surgery.States.Cancelled)
                PostTransition_Completed2Cancelled();

        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(Surgery).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == Surgery.States.SurgeryRequest && toState == Surgery.States.Cancelled)
                UndoTransition_SurgeryRequest2Cancelled(transDef);
            else if (fromState == Surgery.States.SurgeryRequest && toState == Surgery.States.Surgery)
                UndoTransition_SurgeryRequest2Surgery(transDef);
            else if (fromState == Surgery.States.Surgery && toState == Surgery.States.Cancelled)
                UndoTransition_Surgery2Cancelled(transDef);
            else if (fromState == Surgery.States.Surgery && toState == Surgery.States.Rejected)
                UndoTransition_Surgery2Rejected(transDef);
            else if (fromState == Surgery.States.Surgery && toState == Surgery.States.Completed)
                UndoTransition_Surgery2Completed(transDef);
            else if (fromState == Surgery.States.Surgery && toState == Surgery.States.WaitingForSubSurgeries)
                UndoTransition_Surgery2WaitingForSubSurgeries(transDef);
            else if (fromState == Surgery.States.WaitingForSubSurgeries && toState == Surgery.States.Completed)
                UndoTransition_WaitingForSubSurgeries2Completed(transDef);
            else if (fromState == Surgery.States.WaitingForSubSurgeries && toState == Surgery.States.Cancelled)
                UndoTransition_WaitingForSubSurgeries2Cancelled(transDef);
            else if (fromState == Surgery.States.Completed && toState == Surgery.States.Cancelled)
                UndoTransition_Completed2Cancelled(transDef);

        }

    }
}