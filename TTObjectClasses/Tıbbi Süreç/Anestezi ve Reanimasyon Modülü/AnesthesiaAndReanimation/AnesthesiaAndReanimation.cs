
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
    /// Anestezi ve Reanimasyon İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
    public  partial class AnesthesiaAndReanimation : EpisodeActionWithDiagnosis, IReasonOfReject, IAllocateSpeciality, IWorkListEpisodeAction, IAppointmentWithoutResources, IStockOutCancel
    {
        public partial class AnesthesiaReportNQL_Class : TTReportNqlObject 
        {
        }

        public partial class OLAP_GetAnesthesiaOfSurgery_Class : TTReportNqlObject 
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

        protected override void PostInsert()
        {
#region PostInsert
            
            
            base.PostInsert();

#endregion PostInsert
        }

        protected override void PostUpdate()
        {
            #region PostUpdate
            base.PostUpdate();
            if (AnesthesiaEndDateTime != null)
                SetMySubActionProceduresPerformedDate();
            #endregion PostUpdate
        }

        protected void PostTransition_Request2Cancelled()
        {
            // From State : Request   To State : Cancelled
#region PostTransition_Request2Cancelled
            Cancel();
#endregion PostTransition_Request2Cancelled
        }

        protected void UndoTransition_Request2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Request   To State : Cancelled
#region UndoTransition_Request2Cancelled
            NoBackStateBack();
#endregion UndoTransition_Request2Cancelled
        }

        protected void PostTransition_AnesthesiaReport2Cancelled()
        {
            // From State : AnesthesiaReport   To State : Cancelled
#region PostTransition_AnesthesiaReport2Cancelled
            Cancel();
#endregion PostTransition_AnesthesiaReport2Cancelled
        }

        protected void UndoTransition_AnesthesiaReport2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : AnesthesiaReport   To State : Cancelled
#region UndoTransition_AnesthesiaReport2Cancelled
            NoBackStateBack();
#endregion UndoTransition_AnesthesiaReport2Cancelled
        }

        protected void PreTransition_AnesthesiaReport2Completed()
        {
            // From State : AnesthesiaReport   To State : Completed
            #region PreTransition_AnesthesiaReport2Completed
            if (IsOldAction != true)
            {
                if (AnesthesiaReportNo.Value == null)
                    AnesthesiaReportNo.GetNextValue(MasterResource.ObjectID.ToString(), Common.RecTime().Year);
            }
#endregion PreTransition_AnesthesiaReport2Completed
        }

        protected void PostTransition_AnesthesiaReport2Completed()
        {
            // From State : AnesthesiaReport   To State : Completed
#region PostTransition_AnesthesiaReport2Completed

            if(MainSurgery!=null)
            {
                MainSurgery.CheckAndComplete(this);

                //  this.CheckAnesthesiaTime();
            }
#endregion PostTransition_AnesthesiaReport2Completed
        }

        protected void UndoTransition_AnesthesiaReport2Completed(TTObjectStateTransitionDef transitionDef)
        {
            // From State : AnesthesiaReport   To State : Completed
#region UndoTransition_AnesthesiaReport2Completed
            
            
            if(MainSurgery!=null)
            {
                if(MainSurgery.CurrentStateDefID==Surgery.States.Completed )
                {
                    throw new TTUtils.TTException(SystemMessage.GetMessage(204));
                    //throw new Exception("Bağlı olduğu Ameliyat işlemi Tamam'  adımında iken işlem geri alınamaz.");
                }
            }
#endregion UndoTransition_AnesthesiaReport2Completed
        }

        protected void PostTransition_AnesthesiaExpend2AnesthesiaReport()
        {
            // From State : AnesthesiaExpend   To State : AnesthesiaReport
#region PostTransition_AnesthesiaExpend2AnesthesiaReport
            
            
            foreach(AppointmentWithoutResource appointmentWithoutResource in  AppointmentWithoutResources)
            {
                if(appointmentWithoutResource.CurrentStateDef.Status==StateStatusEnum.Uncompleted)
                {
                    appointmentWithoutResource.CurrentStateDefID=AppointmentWithoutResource.States.Completed;
                }
            }
#endregion PostTransition_AnesthesiaExpend2AnesthesiaReport
        }

        protected void PostTransition_AnesthesiaExpend2Cancelled()
        {
            // From State : AnesthesiaExpend   To State : Cancelled
#region PostTransition_AnesthesiaExpend2Cancelled
            Cancel();
#endregion PostTransition_AnesthesiaExpend2Cancelled
        }

        protected void UndoTransition_AnesthesiaExpend2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : AnesthesiaExpend   To State : Cancelled
#region UndoTransition_AnesthesiaExpend2Cancelled
            NoBackStateBack();
#endregion UndoTransition_AnesthesiaExpend2Cancelled
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



       protected void PostTransition_SurgeryAnestesia2Cancelled()
        {
            // From State : SurgeryAnestesia   To State : Cancelled
#region PostTransition_SurgeryAnestesia2Cancelled
            Cancel();
#endregion PostTransition_SurgeryAnestesia2Cancelled
        }

        protected void UndoTransition_SurgeryAnestesia2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : SurgeryAnestesia   To State : Cancelled
#region UndoTransition_SurgeryAnestesia2Cancelled
            NoBackStateBack();
#endregion UndoTransition_SurgeryAnestesia2Cancelled
        }

        protected void PreTransition_SurgeryAnestesia2Completed()
        {
            // From State : SurgeryAnestesia   To State : Completed
#region PreTransition_SurgeryAnestesia2Completed
            
            
            
            if (AnesthesiaReportNo.Value==null)
                AnesthesiaReportNo.GetNextValue(MasterResource.ObjectID.ToString(), Common.RecTime().Year);

#endregion PreTransition_SurgeryAnestesia2Completed
        }

        protected void PostTransition_SurgeryAnestesia2Completed()
        {
            // From State : SurgeryAnestesia   To State : Completed
#region PostTransition_SurgeryAnestesia2Completed    
            if(MainSurgery!=null)
            {
              MainSurgery.CheckAndComplete(this);
            }
           // FireIntensiveCareAfterSurgery();
#endregion PostTransition_SurgeryAnestesia2Completed
        }

        protected void UndoTransition_SurgeryAnestesia2Completed(TTObjectStateTransitionDef transitionDef)
        {
            // From State : SurgeryAnestesia   To State : Completed
#region UndoTransition_SurgeryAnestesia2Completed
            
            
            if(MainSurgery!=null)
            {
                if(MainSurgery.CurrentStateDefID==Surgery.States.Completed )
                {
                    throw new TTUtils.TTException(SystemMessage.GetMessage(204));
                    //throw new Exception("Bağlı olduğu Ameliyat işlemi  'Tamam'  adımıında iken işlem geri alınamaz.");
                }
            }
#endregion UndoTransition_SurgeryAnestesia2Completed
        }

        protected void PostTransition_ReturnedToDoctor2Cancelled()
        {
            // From State : ReturnedToDoctor   To State : Cancelled
#region PostTransition_ReturnedToDoctor2Cancelled
            Cancel();
#endregion PostTransition_ReturnedToDoctor2Cancelled
        }

        protected void UndoTransition_ReturnedToDoctor2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : ReturnedToDoctor   To State : Cancelled
#region UndoTransition_ReturnedToDoctor2Cancelled
            NoBackStateBack();
#endregion UndoTransition_ReturnedToDoctor2Cancelled
        }

        protected void PreTransition_RequestAcception2AnesthesiaExpend()
        {
            // From State : RequestAcception   To State : AnesthesiaExpend
#region PreTransition_RequestAcception2AnesthesiaExpend
            
            
            if(PlannedAnesthesiaDate!=null)
            {
                AppointmentWithoutResource appointmentWithoutResource=new AppointmentWithoutResource(ObjectContext);
                appointmentWithoutResource.CurrentStateDefID=AppointmentWithoutResource.States.New;
                appointmentWithoutResource.AppDateTime=Convert.ToDateTime(PlannedAnesthesiaDate);
                WorkListDate=Convert.ToDateTime(PlannedAnesthesiaDate);
                AppointmentWithoutResources.Add(appointmentWithoutResource);
            }
            else
            {
                string[] hataParamList = new string[] { "'Anestezi Uygulama Tarihi'" };
                throw new TTUtils.TTException(SystemMessage.GetMessageV3(95, hataParamList));
                //throw new Exception ("Anestezi Uygulama Tarihi boş geçilemez");
            }
#endregion PreTransition_RequestAcception2AnesthesiaExpend
        }

        protected void PostTransition_RequestAcception2Cancelled()
        {
            // From State : RequestAcception   To State : Cancelled
#region PostTransition_RequestAcception2Cancelled
            Cancel();
#endregion PostTransition_RequestAcception2Cancelled
        }

        protected void UndoTransition_RequestAcception2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : RequestAcception   To State : Cancelled
#region UndoTransition_RequestAcception2Cancelled
            NoBackStateBack();
#endregion UndoTransition_RequestAcception2Cancelled
        }

        protected void UndoTransition_RequestAcception2SurgeryAnestesia(TTObjectStateTransitionDef transitionDef)
        {
            // From State : RequestAcception   To State : SurgeryAnestesia
#region UndoTransition_RequestAcception2SurgeryAnestesia
            
            
            if(MainSurgery!=null)
            {
                if(MainSurgery.CurrentStateDefID!=Surgery.States.SurgeryRequest &&  MainSurgery.CurrentStateDefID!=Surgery.States.Surgery)
                {
                    throw new TTUtils.TTException(SystemMessage.GetMessage(203));
                     // throw new Exception("Bağlı olduğu ameliyat işlemi 'Ameliyat' adımına geri alınmadan Bu işlem geri alınamaz.Bu işlem geri alınamaz.\r\n" +
                     //       "Bu işlem geri alındığı taktirde bütünlük bozulması yaratabilir.\r\n"+
                     //       "Lütfen sistem yöneticinize danışmadan geri alma işlemini yapmayınız.");
                }
            }
#endregion UndoTransition_RequestAcception2SurgeryAnestesia
        }

        #region Methods
        #region IStockOutCancel Members
        public BaseTreatmentMaterial.ChildBaseTreatmentMaterialCollection GetTreatmentMaterials()
        {
            return TreatmentMaterials;
        }
        #endregion
        public override ActionTypeEnum ActionType
        {
            get
            {
                return ActionTypeEnum.AnesthesiaAndReanimation;
            }
        }
        public AnesthesiaAndReanimation(TTObjectContext objectContext,Surgery surgery,ResSection masterResource) : this(objectContext)
        {
            IsOldAction = surgery.IsOldAction;
            SetMandatoryEpisodeActionProperties((EpisodeAction)surgery,masterResource,surgery.FromResource,true);
            surgery.AnesthesiaAndReanimation=this;
            MainSurgery=surgery;
            RequestNote=surgery.NotesToAnesthesia;
            PlannedAnesthesiaDate=surgery.PlannedSurgeryDate;
            RequestDate = Common.RecTime();
            CurrentStateDefID = AnesthesiaAndReanimation.States.SurgeryAnestesia;

            
        }

        public override void SetMySubActionProceduresPerformedDate()
        {
            foreach (SubActionProcedure subactionProcedure in SubactionProcedures.Where(x => x.CurrentStateDef.Status != StateStatusEnum.Cancelled))
            {
                subactionProcedure.SetPerformedDate();
            }
        }



        public override void Cancel()
        {
            if(MainSurgery==null)
            {
                base.Cancel();
            }
            else if (CancelledBySurgery==true)
            {
                base.Cancel();
            }
            else
            {
                throw new TTUtils.TTException(SystemMessage.GetMessage(205));
                //throw new Exception("Ameliyat için istenen anestezi ve reanimasyon işlemleri Ameliyat işlemi iptal edilmeden iptal edilemez.");
            }
            
        }

        
        
        
        protected override List<EpisodeAction.OldActionPropertyObject> OldActionPropertyList()
        {
            List<EpisodeAction.OldActionPropertyObject> propertyList = base.OldActionPropertyList();
            //            propertyList.Add(new OldActionPropertyObject("Protokol No",Common.ReturnObjectAsString(this.ProtocolNo)));
            //            propertyList.Add(new OldActionPropertyObject("Anestezi Başlama Tarihi",Common.ReturnObjectAsString(AnesthesiaStartDateTime)));
            //            propertyList.Add(new OldActionPropertyObject("Anestezi Bitiş Tarihi",Common.ReturnObjectAsString(AnesthesiaEndDateTime)));
            //            propertyList.Add(new OldActionPropertyObject("Anestezi Tekniği",Common.ReturnObjectAsString(AnesthesiaTechnique)));
            //            propertyList.Add(new OldActionPropertyObject("Rapor No",Common.ReturnObjectAsString(AnesthesiaReport)));
            //            propertyList.Add(new OldActionPropertyObject("Rapor Tarihi",Common.ReturnObjectAsString(AnesthesiaReportDate)));
            //            propertyList.Add(new OldActionPropertyObject("Rapor ",Common.ReturnObjectAsString(AnesthesiaReport)));
            if(MainSurgery!=null)
            {
                propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M10847", "Ameliyat Tarihi"),Common.ReturnObjectAsString(MainSurgery.SurgeryStartTime)));
                if(MainSurgery.ProcedureSpeciality!=null)
                    propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M25162", "Ameliyatı Gerçekleştiren Uzmanlık Dalı"),Common.ReturnObjectAsString(MainSurgery.ProcedureSpeciality.Name)));
            }
            
            return propertyList;
        }
        //        protected override List<List<List<OldActionPropertyObject>>> OldActionChildRelationList()
        //        {
        //            List<List<List<OldActionPropertyObject>>> gridList=base.OldActionChildRelationList();
        //            // Anestezi İşlemi
        //            List<List<OldActionPropertyObject>> gridProcedureRowList=new List<List<OldActionPropertyObject>>();
        //            foreach(AnesthesiaProcedure Procedure in this.AnaesthesiaAndReanimationAnesthesiaProcedures)
        //            {
        //                // her bir satyry için kolonlary ta?yyan Liste
        //                List<OldActionPropertyObject> gridProcedureRowColumnList=new List<OldActionPropertyObject>();
        //                gridProcedureRowColumnList.Add(new OldActionPropertyObject("İşlem Tarihi",Common.ReturnObjectAsString(Procedure.ActionDate)));
        //                gridProcedureRowColumnList.Add(new OldActionPropertyObject("Anestezi İşlemi",Common.ReturnObjectAsString(Procedure.ProcedureObject.Name)));
        //                gridProcedureRowList.Add(gridProcedureRowColumnList);
        //            }
        //            gridList.Add(gridProcedureRowList);
        //
        //            // İstek Yapan işlemler
        //            List<List<OldActionPropertyObject>> gridRequestedProcedureRowList=new List<List<OldActionPropertyObject>>();
        //            foreach(AnesthesiaAndReanimationRequestedProcedure requestedProcedure in this.RequestedProcedure)
        //            {
        //                // her bir satyry için kolonlary ta?yyan Liste
        //                List<OldActionPropertyObject> gridRequestedProcedureRowColumnList=new List<OldActionPropertyObject>();
        //                gridRequestedProcedureRowColumnList.Add(new OldActionPropertyObject("Anestezi Gerektiren İşlem",Common.ReturnObjectAsString(requestedProcedure.Procedure.Name)));
        //
        //
        //                gridRequestedProcedureRowList.Add(gridRequestedProcedureRowColumnList);
        //            }
        //            gridList.Add(gridRequestedProcedureRowList);
        //
        //            // Anestezi Ekibi
        //            //            List<List<OldActionPropertyObject>> gridPersonnelsRowList=new List<List<OldActionPropertyObject>>();
        //            //            foreach(AnesthesiaPersonnel Personnel in this.AnesthesiaPersonnels)
        //            //            {
        //            //                // her bir satyry için kolonlary ta?yyan Liste
        //            //                List<OldActionPropertyObject> gridPersonnelsRowColumnList=new List<OldActionPropertyObject>();
        //            //                gridPersonnelsRowColumnList.Add(new OldActionPropertyObject("Anstezi Ekibi",Common.ReturnObjectAsString(Personnel.AnesthesiaPersonnel.Name)));
        //            //                gridPersonnelsRowColumnList.Add(new OldActionPropertyObject("Görevi",Common.ReturnObjectAsString(Personnel.Role)));
        //            //                gridPersonnelsRowList.Add(gridPersonnelsRowColumnList);
        //            //            }
        //            //            gridList.Add(gridPersonnelsRowList);
        //
        //            return gridList;
        //        }
        public void CheckAnesthesiaTime()
        {
            // Bu kontrol SurgeryFormda yapılır           
            //if(this.MainSurgery!=null)
            //{
            //    if(this.MainSurgery.SurgeryEndTime==null ||this.MainSurgery.SurgeryStartTime==null)
            //    {
            //        string[] hataParamList = new string[] { "Ameliyat Bilgileri tabındaki 'Ameliyat Başlama Tarihi' ve  'Ameliyat Bitiş Tarihi' alanları " };
            //        throw new TTUtils.TTException(SystemMessage.GetMessageV3(95, hataParamList));
            //        //throw new Exception("Ameliyat Bilgileri tabındaki 'Ameliyat Başlama Tarihi' ve  'Ameliyat Bitiş Tarihi' alanları boş geçilemez");

            //    }
            //    else if(this.MainSurgery.SurgeryEndTime < this.MainSurgery.SurgeryStartTime)

            //    //else if(Common.DateDiff(0,Convert.ToDateTime(this.MainSurgery.SurgeryEndTime),Convert.ToDateTime(this.MainSurgery.SurgeryStartTime),false)<0)
            //    {
            //        string[] hataParamList = new string[] { "'Ameliyat Bitiş Tarihi'", "'Ameliyat Başlama Tarihi'" };//{0} , {1} ' ne eşit veya ondan küçük olamaz.
            //        throw new TTUtils.TTException(SystemMessage.GetMessageV3(202, hataParamList));
            //        //throw new Exception("'Ameliyat Başlama Tarihi' , 'Ameliyat Bitiş Tarihin'den sonra olamaz. ");
            //    }
            //}

            if (AnesthesiaStartDateTime == null)
                throw new Exception("'Anestezi Başlatma Tarih/Saat' Alanı boş olamaz");
            if (AnesthesiaEndDateTime == null)
                throw new Exception("'Anestezi Bitirme Tarih/Saat' Alanı boş olamaz");

            var RecTime = Common.RecTime();

            if (RecTime < AnesthesiaStartDateTime)
            {
                throw new Exception("'Anestezi Başlama Tarihi' , ileri tarihli olamaz ");
            }

            if (RecTime < AnesthesiaEndDateTime)
            {
                throw new Exception("'Anestezi Bitiş Tarihi' , ileri tarihli olamaz ");
            }

            if (AnesthesiaEndDateTime <= AnesthesiaStartDateTime)
            {
                string[] hataParamList = new string[] { "'Anestezi Bitiş Tarihi'", "'Anestezi Başlama Tarihi'" };//{0} , {1} ' ne eşit veya ondan küçük olamaz.
                                                                                                                 //TODO hata kodu eklenip üstteki throw açılacak.
                                                                                                                 //throw new TTUtils.TTException(SystemMessage.GetMessage(202, hataParamList));
                throw new Exception("'Anestezi Başlama Tarihi' , 'Anestezi Bitiş Tarihi'ne eşit ya da sonra olamaz. ");
            }
            if (MainSurgery != null)
            {
                MainSurgery.CheckSurgeryAndAnesthesiaTime();
            }
        }
        

        public bool IsSurgeryDelay()
        {
            if(MainSurgery!=null)
            {
                if(MainSurgery.CurrentStateDefID == Surgery.States.SurgeryRequest)// ameliyat ertelendiyse yenide bekliyordur
                {
                    DateTime lastDateNewStep=Convert.ToDateTime("01.01.1000");
                    DateTime lastDateSurgeryStep=Convert.ToDateTime("01.01.1000");
                    
                    foreach(TTObjectState objectState in MainSurgery.GetStateHistory())
                    {
                        if(objectState.StateDefID == Surgery.States.SurgeryRequest)
                        {
                            if(lastDateNewStep<objectState.BranchDate)
                            {
                                lastDateNewStep=objectState.BranchDate;
                            }
                        }
                        else if(objectState.StateDefID == Surgery.States.Surgery)
                        {
                            if(lastDateSurgeryStep<objectState.BranchDate)
                            {
                                lastDateSurgeryStep=objectState.BranchDate;
                            }
                        }

                    }
                    if( lastDateSurgeryStep<lastDateNewStep )
                        return true;
                }
            }
            return false;
        }
        
        public void FireIntensiveCareAfterSurgery()
        {
            //Eğer Anestezi ve Reanimasyon işleminin oluşturduğu Derlenme işlemleri arasında state i cancelled dan farklı olan varsa return etsin. Tekrar oluşturmasın.
            foreach(IntensiveCareAfterSurgery intensiveCareAfterSurgery in IntensiveCareAfterSurgeries)
            {
                if(intensiveCareAfterSurgery.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                    return;
            }
            
            bool found = false;
            foreach(IntensiveCareAfterSurgery inCareAfterSurgery in Episode.IntensiveCareAfterSurgeries)
            {
                if (inCareAfterSurgery.CurrentStateDefID == IntensiveCareAfterSurgery.States.Procedure)
                {
                    found = true;
                    break;
                }
            }
            if (found)
            {
                throw new Exception(SystemMessage.GetMessage(1004));
            }
            else
            {
                IntensiveCareAfterSurgery intensiveCareAfterSurgery = new IntensiveCareAfterSurgery(this, (ResSection)MasterResource);
            }
        }

        public bool IsSecondDoctorNeededByGILPoint()
        {
            int totalGil = 0;
            foreach(var anestesiaProcedure in AnaesthesiaAndReanimationAnesthesiaProcedures)
            {
                if (anestesiaProcedure.ProcedureObject is AnesthesiaDefinition && ((AnesthesiaDefinition)anestesiaProcedure.ProcedureObject).GILPoint != null)
                {
                    totalGil +=(int)((AnesthesiaDefinition)anestesiaProcedure.ProcedureObject).GILPoint;
                }
            }

            if (totalGil > 1500)
                return true;

            return false;
        }

        public void ArrangeProcedureDoctorAndAddContext(Boolean OnlyOneProcedureDoctor, TTObjectClasses.ResUser[] SelectedResponsibleDoctorList)
        {
            if (OnlyOneProcedureDoctor)
            {
                if (ProcedureDoctor == null)
                {
                    string[] hataParamList = new string[] { "'Sorumlu Anestezi Uzmanı'" };
                    throw new TTUtils.TTException(SystemMessage.GetMessageV3(95, hataParamList));
                }
                var selectedResponsibleDoctorList = new List<ResUser>();
                selectedResponsibleDoctorList.Add(ProcedureDoctor);
                SelectedResponsibleDoctorList = selectedResponsibleDoctorList.ToArray();

            }
            int doctorCount = SelectedResponsibleDoctorList.Count();
            int oldDoctorCount = AnesthesiaResponsibleDoctors.Count;

            while (doctorCount < oldDoctorCount)
            {
                ((ITTObject)AnesthesiaResponsibleDoctors[oldDoctorCount - 1]).Delete();
                oldDoctorCount--;
            }

            doctorCount = 0;
            oldDoctorCount = AnesthesiaResponsibleDoctors.Count - 1;
            foreach (var responsibleDoctor in SelectedResponsibleDoctorList)
            {
                if (doctorCount == 0 && !OnlyOneProcedureDoctor)
                { ProcedureDoctor = responsibleDoctor; }

                // eskiden girilenin doktor sayısı yeni girilene eşitse yada büyükse günceller
                if (doctorCount <= oldDoctorCount)
                {
                    AnesthesiaResponsibleDoctors[doctorCount].ResponsibleDoctor = responsibleDoctor;
                }
                else // eskiden girilenin doktor sayısı yeni girilenden küçükse yeni yaratır
                {
                    AnesthesiaResponsibleDoctor anesthesiaResponsibleDoctors = new AnesthesiaResponsibleDoctor(ObjectContext);
                    anesthesiaResponsibleDoctors.ResponsibleDoctor = responsibleDoctor;
                    AnesthesiaResponsibleDoctors.Add(anesthesiaResponsibleDoctors);
                }
                doctorCount++;
            }


            if (ProcedureDoctor == null)
            {
                string[] hataParamList = new string[] { "'Sorumlu Anestezi Uzmanı'" };
                throw new TTUtils.TTException(SystemMessage.GetMessageV3(95, hataParamList));
            }
        }
        #endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(AnesthesiaAndReanimation).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == AnesthesiaAndReanimation.States.AnesthesiaReport && toState == AnesthesiaAndReanimation.States.Completed)
                PreTransition_AnesthesiaReport2Completed();
            else if (fromState == AnesthesiaAndReanimation.States.SurgeryAnestesia && toState == AnesthesiaAndReanimation.States.Completed)
                PreTransition_SurgeryAnestesia2Completed();
            else if (fromState == AnesthesiaAndReanimation.States.RequestAcception && toState == AnesthesiaAndReanimation.States.AnesthesiaExpend)
                PreTransition_RequestAcception2AnesthesiaExpend();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(AnesthesiaAndReanimation).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == AnesthesiaAndReanimation.States.Request && toState == AnesthesiaAndReanimation.States.Cancelled)
                PostTransition_Request2Cancelled();
            else if (fromState == AnesthesiaAndReanimation.States.AnesthesiaReport && toState == AnesthesiaAndReanimation.States.Cancelled)
                PostTransition_AnesthesiaReport2Cancelled();
            else if (fromState == AnesthesiaAndReanimation.States.AnesthesiaReport && toState == AnesthesiaAndReanimation.States.Completed)
                PostTransition_AnesthesiaReport2Completed();
            else if (fromState == AnesthesiaAndReanimation.States.AnesthesiaExpend && toState == AnesthesiaAndReanimation.States.AnesthesiaReport)
                PostTransition_AnesthesiaExpend2AnesthesiaReport();
            else if (fromState == AnesthesiaAndReanimation.States.AnesthesiaExpend && toState == AnesthesiaAndReanimation.States.Cancelled)
                PostTransition_AnesthesiaExpend2Cancelled();
            else if (fromState == AnesthesiaAndReanimation.States.Completed && toState == AnesthesiaAndReanimation.States.Cancelled)
                PostTransition_Completed2Cancelled();
            else if (fromState == AnesthesiaAndReanimation.States.SurgeryAnestesia && toState == AnesthesiaAndReanimation.States.Cancelled)
                PostTransition_SurgeryAnestesia2Cancelled();
            else if (fromState == AnesthesiaAndReanimation.States.SurgeryAnestesia && toState == AnesthesiaAndReanimation.States.Completed)
                PostTransition_SurgeryAnestesia2Completed();
            else if (fromState == AnesthesiaAndReanimation.States.ReturnedToDoctor && toState == AnesthesiaAndReanimation.States.Cancelled)
                PostTransition_ReturnedToDoctor2Cancelled();
            else if (fromState == AnesthesiaAndReanimation.States.RequestAcception && toState == AnesthesiaAndReanimation.States.Cancelled)
                PostTransition_RequestAcception2Cancelled();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(AnesthesiaAndReanimation).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == AnesthesiaAndReanimation.States.Request && toState == AnesthesiaAndReanimation.States.Cancelled)
                UndoTransition_Request2Cancelled(transDef);
            else if (fromState == AnesthesiaAndReanimation.States.AnesthesiaReport && toState == AnesthesiaAndReanimation.States.Cancelled)
                UndoTransition_AnesthesiaReport2Cancelled(transDef);
            else if (fromState == AnesthesiaAndReanimation.States.AnesthesiaReport && toState == AnesthesiaAndReanimation.States.Completed)
                UndoTransition_AnesthesiaReport2Completed(transDef);
            else if (fromState == AnesthesiaAndReanimation.States.AnesthesiaExpend && toState == AnesthesiaAndReanimation.States.Cancelled)
                UndoTransition_AnesthesiaExpend2Cancelled(transDef);
            else if (fromState == AnesthesiaAndReanimation.States.Completed && toState == AnesthesiaAndReanimation.States.Cancelled)
                UndoTransition_Completed2Cancelled(transDef);
            else if (fromState == AnesthesiaAndReanimation.States.SurgeryAnestesia && toState == AnesthesiaAndReanimation.States.Cancelled)
                UndoTransition_SurgeryAnestesia2Cancelled(transDef);
            else if (fromState == AnesthesiaAndReanimation.States.SurgeryAnestesia && toState == AnesthesiaAndReanimation.States.Completed)
                UndoTransition_SurgeryAnestesia2Completed(transDef);
            else if (fromState == AnesthesiaAndReanimation.States.ReturnedToDoctor && toState == AnesthesiaAndReanimation.States.Cancelled)
                UndoTransition_ReturnedToDoctor2Cancelled(transDef);
            else if (fromState == AnesthesiaAndReanimation.States.RequestAcception && toState == AnesthesiaAndReanimation.States.Cancelled)
                UndoTransition_RequestAcception2Cancelled(transDef);
            else if (fromState == AnesthesiaAndReanimation.States.RequestAcception && toState == AnesthesiaAndReanimation.States.SurgeryAnestesia)
                UndoTransition_RequestAcception2SurgeryAnestesia(transDef);
        }

    }
}