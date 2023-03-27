
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
    /// Dış XXXXXXlerden Konsültasyon
    /// </summary>
    public partial class ConsultationFromOtherHospital : EpisodeActionWithDiagnosis, IReasonOfReject, IWorkListEpisodeAction, IAllocateSpeciality, INumaratorAppointment
    {
        public partial class GetConsultationFromOtherHospitalInfo_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetConsultationsToOtherHospitals_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetConsultationFromOtherHospitalNew_Class : TTReportNqlObject
        {
        }

        #region INumaratorAppointment Members
        public List<AppointmentCarrier> GetAppointmentCarrierList()
        {
            return AppointmentCarrierList;
        }

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

        protected override void PostInsert()
        {
            #region PostInsert
            base.PostInsert();

            #endregion PostInsert
        }

        protected void UndoTransition_Approval2ConsultationInOtherHospital(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Approval   To State : ConsultationInOtherHospital
            #region UndoTransition_Approval2ConsultationInOtherHospital
            NoBackStateBack();
            #endregion UndoTransition_Approval2ConsultationInOtherHospital
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

        protected void PostTransition_ConsultationInOtherHospital2Cancelled()
        {
            // From State : ConsultationInOtherHospital   To State : Cancelled
            #region PostTransition_ConsultationInOtherHospital2Cancelled
            Cancel();
            CancelMyExaminationQueueItems();
            #endregion PostTransition_ConsultationInOtherHospital2Cancelled
        }

        protected void UndoTransition_ConsultationInOtherHospital2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : ConsultationInOtherHospital   To State : Cancelled
            #region UndoTransition_ConsultationInOtherHospital2Cancelled
            NoBackStateBack();
            #endregion UndoTransition_ConsultationInOtherHospital2Cancelled
        }

        protected void PreTransition_ConsultationInOtherHospital2ResultEntry()
        {
            // From State : ConsultationInOtherHospital   To State : ResultEntry
            #region PreTransition_ConsultationInOtherHospital2ResultEntry

            if (OlapDate == null)
                OlapDate = DateTime.Now;
            #endregion PreTransition_ConsultationInOtherHospital2ResultEntry
        }

        protected void PostTransition_ConsultationInOtherHospital2ResultEntry()
        {
            // From State : ConsultationInOtherHospital   To State : ResultEntry
            #region PostTransition_ConsultationInOtherHospital2ResultEntry

            CompleteMyExaminationQueueItems();
            #endregion PostTransition_ConsultationInOtherHospital2ResultEntry
        }

        protected void PostTransition_ResultEntry2Completed()
        {
            // From State : ResultEntry   To State : Completed
            #region PostTransition_ResultEntry2Completed

            //            if (!String.IsNullOrEmpty(this.SourceObjectID))
            //                RunReturnConsultationFromOtherHospital();

            #endregion PostTransition_ResultEntry2Completed
        }

        protected void UndoTransition_ResultEntry2Completed(TTObjectStateTransitionDef transitionDef)
        {
            // From State : ResultEntry   To State : Completed
            #region UndoTransition_ResultEntry2Completed
            NoBackStateBack();
            #endregion UndoTransition_ResultEntry2Completed
        }

        protected void PostTransition_ResultEntry2Cancelled()
        {
            // From State : ResultEntry   To State : Cancelled
            #region PostTransition_ResultEntry2Cancelled
            Cancel();
            #endregion PostTransition_ResultEntry2Cancelled
        }

        protected void UndoTransition_ResultEntry2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : ResultEntry   To State : Cancelled
            #region UndoTransition_ResultEntry2Cancelled
            NoBackStateBack();
            #endregion UndoTransition_ResultEntry2Cancelled
        }

        protected void PostTransition_InsertedIntoQueue2Cancelled()
        {
            // From State : InsertedIntoQueue   To State : Cancelled
            #region PostTransition_InsertedIntoQueue2Cancelled

            Cancel();
            CancelMyExaminationQueueItems();
            #endregion PostTransition_InsertedIntoQueue2Cancelled
        }

        protected void UndoTransition_InsertedIntoQueue2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : InsertedIntoQueue   To State : Cancelled
            #region UndoTransition_InsertedIntoQueue2Cancelled

            NoBackStateBack();
            #endregion UndoTransition_InsertedIntoQueue2Cancelled
        }

        protected void PreTransition_InsertedIntoQueue2ResultEntry()
        {
            // From State : InsertedIntoQueue   To State : ResultEntry
            #region PreTransition_InsertedIntoQueue2ResultEntry

            if (OlapDate == null)
                OlapDate = DateTime.Now;

            #endregion PreTransition_InsertedIntoQueue2ResultEntry
        }

        protected void PostTransition_InsertedIntoQueue2ResultEntry()
        {
            // From State : InsertedIntoQueue   To State : ResultEntry
            #region PostTransition_InsertedIntoQueue2ResultEntry

            CompleteMyExaminationQueueItems();
            #endregion PostTransition_InsertedIntoQueue2ResultEntry
        }

        #region Methods
        public ConsultationFromOtherHospital(TTObjectContext objectContext, EpisodeAction episodeAction) : this(objectContext)
        {

            ActionDate = Common.RecTime();
            MasterResource = episodeAction.MasterResource;
            FromResource = episodeAction.MasterResource;
            //Episodeun AfterSetinde  this.InPatientPhysicianApplication==null kontrolü olduğu için SetMandatoryEpisodeActionProperties()kullanılmadı.
            //this.SetMandatoryEpisodeActionProperties((EpisodeAction)inPatientPhysicianApplication,inPatientPhysicianApplication.MasterResource,inPatientPhysicianApplication.MasterResource,false);
            CurrentStateDefID = ConsultationFromOtherHospital.States.Request;
            Episode = episodeAction.Episode;
            ProcedureSpeciality = episodeAction.ProcedureSpeciality;
            MasterAction = episodeAction;

        }

        public ConsultationFromOtherHospital(TTObjectContext objectContext, SubactionProcedureFlowable subactionProcedureFlowable) : this(objectContext)
        {
            ActionDate = Common.RecTime();
            MasterResource = subactionProcedureFlowable.MasterResource;
            FromResource = subactionProcedureFlowable.MasterResource;
            //Episodeun AfterSetinde  this.InPatientPhysicianApplication==null kontrolü olduğu için SetMandatoryEpisodeActionProperties()kullanılmadı.
            //this.SetMandatoryEpisodeActionProperties((EpisodeAction)inPatientPhysicianApplication,inPatientPhysicianApplication.MasterResource,inPatientPhysicianApplication.MasterResource,false);
            CurrentStateDefID = ConsultationFromOtherHospital.States.Request;
            Episode = subactionProcedureFlowable.Episode;
            ProcedureSpeciality = subactionProcedureFlowable.ProcedureSpeciality;
            MasterAction = subactionProcedureFlowable.EpisodeAction;
        }

        public List<AppointmentCarrier> AppointmentCarrierList
        {
            get
            {
                List<AppointmentCarrier> _appointmentList = new List<AppointmentCarrier>();
                TTObjectContext objectContext = new TTObjectContext(false);
                AppointmentDefinition appDef = null;
                IList appDefList = AppointmentDefinition.GetAppointmentDefinitionByName(objectContext, AppointmentDefinitionEnum.ConsultationProcedure);
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
                    AppointmentCarrier carrier = new AppointmentCarrier(objectContext);
                    carrier.MasterResource = "ResSection";
                    carrier.SubResource = "ResUser";
                    carrier.RelationParentName = "";
                    carrier.UserTypes.Add(UserTypeEnum.Doctor);
                    carrier.UserTypes.Add(UserTypeEnum.Dentist);
                    carrier.UserTypes.Add(UserTypeEnum.Dietician);
                    carrier.UserTypes.Add(UserTypeEnum.Psychologist);
                    carrier.AppointmentDefinition = appDef;
                    _appointmentList.Add(carrier);
                }
                //her app carrier listenin başında çağırılmalı.
                ClearAppointmentCarrierDynamicFields(_appointmentList);
                foreach (AppointmentCarrier appointmentCarrier in _appointmentList)
                {
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
        public override ActionTypeEnum ActionType
        {
            get
            {
                return ActionTypeEnum.ConsultationFromOtherHospital;
            }
        }

        public override void Cancel()
        {
            if (OriginalStateDef.StateDefID.Equals(ConsultationFromOtherHospital.States.ResultEntry) || OriginalStateDef.StateDefID.Equals(ConsultationFromOtherHospital.States.ConsultationInOtherHospital) || OriginalStateDef.StateDefID.Equals(ConsultationFromOtherHospital.States.Completed))
            {
                if (SourceObjectID == null)
                {//İşlem bu XXXXXXden başlatıldıysa bu statelerde iptal yapılamaz
                    NoCancel();
                }
            }
            base.Cancel();
        }

        public void RunSendConsultationFromOtherHospital()
        {
            //TODO: Remote metodlar destekleneceği zaman açılabilir.
            //            if(this.RequestedReferableHospital!=null)
            //            {
            //                if(this.RequestedReferableHospital.ResOtherHospital!=null)
            //                {
            //                    if(this.RequestedReferableHospital.ResOtherHospital.Site!=null)
            //                    {
            //                        Guid savePoint = this.ObjectContext.BeginSavePoint();
            //                        String messageString="";
            //                        try
            //                        {
            //                            List<DiagnosisGrid> diagnosisList = new List<DiagnosisGrid>();
            //                            
            //                            foreach (DiagnosisGrid dg in this.Episode.Diagnosis)
            //                            {
            //                                diagnosisList.Add(dg.PrepareDiagnosisGridForRemoteMethod(true));
            //                            }
            //
            //                            List<MedulaProvision> medulaProvisionList = new List<MedulaProvision>();
            //
            //                            //Aynı tesis kodlu XXXXXXler için konsultasyon istendiğinde varda birlikte Medula takipi de gönderilir
            //                            if (this.RequestedReferableHospital.ResOtherHospital.Site.MedulaSiteCode != null && this.RequestedReferableHospital.ResOtherHospital.Site.MedulaSiteCode.ToString() == SystemParameter.GetSaglikTesisKodu().ToString())
            //                            {
            //                                if (this.Episode.IsMedulaEpisode() )
            //                                {
            //                                    if (this.SubEpisode != null && this.SubEpisode.MdlProvision.Count > 0)
            //                                    {
            //                                        medulaProvisionList.Add(this.SubEpisode.MdlProvision[0].PrepareMedulaProvisionForRemoteMethod(true));
            //                                    }
            //                                    else if (this.Episode != null && this.Episode.MedulaProvisions.Count > 0)
            //                                    {
            //                                        medulaProvisionList.Add(this.Episode.MedulaProvisions[0].PrepareMedulaProvisionForRemoteMethod(true));
            //                                    }
            //                                }
            //                            }
            //                            
            //                            Sites localSite = TTObjectClasses.SystemParameter.GetSite();
            //                            TTMessage message = ConsultationFromOtherHospital.Remo teMethods.SendConsultationFromOtherHospital(this.RequestedReferableHospital.ResOtherHospital.Site.ObjectID, this.Episode.Patient, this.Episode.PrepareEpisodeForRemoteMethod(true), this.SubEpisode.PatientAdmission.PreparePatientAdmissionForRemoteMethod(true), (ConsultationFromOtherHospital)this.PrepareEpisodeActionForRemoteMethod(true), diagnosisList,localSite,this.ObjectID,this.Episode.GetMyEpisodeProtocolForRemoteMethod(),medulaProvisionList);
            //                            messageString=message.MessageID.ToString();
            //                        }
            //                        finally
            //                        {
            //                            this.ObjectContext.RollbackSavePoint(savePoint);
            //                            this.MessageID = messageString;
            //                            this.ObjectContext.Save();
            //                        }
            //                    }
            //                }
            //            }

        }

        public void RunReturnConsultationFromOtherHospital()
        {
            //TODO: Remote metodlar destekleneceği zaman açılabilir.
            //            if(this.RequestedReferableHospital.ResOtherHospital!=null)
            //            {
            //                if(this.RequestedReferableHospital.ResOtherHospital.Site!=null)
            //                {
            //                    Guid savePoint = this.ObjectContext.BeginSavePoint();
            //                    String messageString="";
            //                    try
            //                    {
            //
            //                        List<DiagnosisGrid> diagnosisList = new List<DiagnosisGrid>();
            //                        foreach (DiagnosisGrid dg in this.Diagnosis)// Geriye gönderilirken yalnız Consultasyonda konulan tanılar geriye gönderiliyor.
            //                        {
            //                            if(dg.ResponsibleUser!=null)
            //                                diagnosisList.Add(dg.PrepareDiagnosisGridForRemoteMethod(true));
            //                        }
            //
            //                        List<TreatmentMaterialShadow> treatmentMaterialList = new List<TreatmentMaterialShadow>();
            //                        foreach (BaseTreatmentMaterial treatmentMaterial in this.TreatmentMaterials)
            //                        {
            //                            TreatmentMaterialShadow treatmentMaterialShadow = new TreatmentMaterialShadow(this.ObjectContext);
            //                            if(treatmentMaterial.Material.Name != null )
            //                                treatmentMaterialShadow.TreatmentMaterialName = treatmentMaterial.Material.Name;
            //                            if(treatmentMaterial.Amount !=null )
            //                                treatmentMaterialShadow.TreatmentMaterialAmount = treatmentMaterial.Amount.ToString();
            //                            treatmentMaterialList.Add(treatmentMaterialShadow);
            //                        }
            //                        
            //                        
            //                        TTMessage message = ConsultationFromOtherHospital.Remo teMethods.ReturnConsultationFromOtherHospital(this.RequesterHospital.Site.ObjectID, (ConsultationFromOtherHospital)this.PrepareEpisodeActionForRemoteMethod(true), diagnosisList, treatmentMaterialList);
            //                        //ConsultationFromOtherHospital consultationFromOtherHospital = (ConsultationFromOtherHospital)objectContext.GetObject(this.ObjectID,"ConsultationFromOtherHospital");
            //                        //consultationFromOtherHospital.MessageID = message.MessageID.ToString();
            //                        messageString=message.MessageID.ToString();
            //                    }
            //                    catch(Exception ex)
            //                    {
            //                        throw ex;
            //                    }
            //                    finally
            //                    {
            //                        this.ObjectContext.RollbackSavePoint(savePoint);
            //                        this.MessageID = messageString;
            //                        this.ObjectContext.Save();
            //                    }
            //                }
            //            }
        }

        public override EpisodeAction PrepareEpisodeActionForRemoteMethod(bool withNewObjectID)
        {
            ConsultationFromOtherHospital cons = (ConsultationFromOtherHospital)base.PrepareEpisodeActionForRemoteMethod(withNewObjectID);

            if (withNewObjectID)
            {
                cons.RequesterDoctor = null;
                cons.RequesterResource = null;
            }
            return cons;

        }
        protected override List<EpisodeAction.OldActionPropertyObject> OldActionPropertyList()
        {
            List<EpisodeAction.OldActionPropertyObject> propertyList = base.OldActionPropertyList();
            //-------------------------------------
            propertyList.Add(new EpisodeAction.OldActionPropertyObject(TTUtils.CultureService.GetText("M20566", "Protokol No"), Common.ReturnObjectAsString(ProtocolNo)));
            //            propertyList.Add(new OldActionPropertyObject("İşlem Tarihi",Common.ReturnObjectAsString(ActionDate)));
            //            if(ConsultedSubject != null)
            //                propertyList.Add(new OldActionPropertyObject("Danışılan Konu",Common.ReturnObjectAsString(ConsultedSubject.ConsultedSubject)));
            //            if(RequesterHospital != null)
            //                propertyList.Add(new OldActionPropertyObject("İstek Yapan XXXXXX",Common.ReturnObjectAsString(RequesterHospital.Name)));
            //
            //            if(String.IsNullOrEmpty(RequesterResourceName))
            //            {
            //                if(RequesterResource != null)
            //                    propertyList.Add(new OldActionPropertyObject("İstek Yapan Birim",Common.ReturnObjectAsString(RequesterResource.Name)));
            //            }
            //            else
            //                propertyList.Add(new OldActionPropertyObject("İstek Yapan Birim",Common.ReturnObjectAsString(RequesterResourceName)));

            //            if(String.IsNullOrEmpty(RequesterDoctorName))
            //            {
            //                if(RequesterDoctor != null)
            //                    propertyList.Add(new OldActionPropertyObject("İstek Yapan Doktor",Common.ReturnObjectAsString(RequesterDoctor.Name)));
            //            }
            //            else
            //                propertyList.Add(new OldActionPropertyObject("İstek Yapan Doktor",Common.ReturnObjectAsString(RequesterDoctorName)));

            //            if(String.IsNullOrEmpty(ConsultedDoctorName))
            //            {
            //                if(ProcedureDoctor != null)
            //                    propertyList.Add(new OldActionPropertyObject("Konsültasyonu Yapan Doktor",Common.ReturnObjectAsString(ProcedureDoctor.Name)));
            //            }
            //            else
            //                propertyList.Add(new OldActionPropertyObject("Konsültasyonu Yapan Doktor",Common.ReturnObjectAsString(ConsultedDoctorName)));

            //  propertyList.Add(new OldActionPropertyObject("Anamnez ve Bulgular ",Common.ReturnObjectAsString(Symptom)));
            //  propertyList.Add(new OldActionPropertyObject("İstek Açıklaması ",Common.ReturnObjectAsString(RequestDescription)));

            //            if(RequestedReferableHospital != null)
            //                propertyList.Add(new OldActionPropertyObject("İstek Yapılan XXXXXX XXXXXX",Common.ReturnObjectAsString(RequestedReferableHospital.ResHospital.Name)));
            //            if(RequestedReferableResource != null)
            //                propertyList.Add(new OldActionPropertyObject("İstek Yapılan XXXXXX XXXXXX Birimi",Common.ReturnObjectAsString(RequestedReferableResource.ResourceName)));
            //            if(RequestedExternalHospital != null)
            //                propertyList.Add(new OldActionPropertyObject("İstek Yapılan Dış XXXXXX",Common.ReturnObjectAsString(RequestedExternalHospital.Name)));
            //            if(RequestedExternalDepartment != null)
            //                propertyList.Add(new OldActionPropertyObject("İstek Yapılan Dış XXXXXX Birimi",Common.ReturnObjectAsString(RequestedExternalDepartment.Name)));

            //   propertyList.Add(new OldActionPropertyObject("Konsültasyon Sonucu ve Öneriler",Common.ReturnObjectAsString(ConsultationResultAndOffers)));
            //---------------------------------------
            return propertyList;
        }

        //        protected override List<List<List<OldActionPropertyObject>>> OldActionChildRelationList()
        //        {
        //            List<List<List<OldActionPropertyObject>>> gridList;
        //            if(base.OldActionChildRelationList()==null)
        //                gridList=new List<List<List<OldActionPropertyObject>>>();
        //            else
        //                gridList=base.OldActionChildRelationList();
        //
        //            gridList.Add(this.OldActionSecDiagnosisList());
        //            return gridList;
        //        }



        public AppointmentTypeEnum NumaratorAppointmentType
        {
            get { return AppointmentTypeEnum.Consultation; }
        }

        public Resource NumaratorAppointmentMasterResource
        {
            get { return MasterResource; }// İşlemin yapıldığı Poliklinik aynı zamanada randevu verilecek üst kaynakdır
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

        #endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(ConsultationFromOtherHospital).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == ConsultationFromOtherHospital.States.ConsultationInOtherHospital && toState == ConsultationFromOtherHospital.States.ResultEntry)
                PreTransition_ConsultationInOtherHospital2ResultEntry();
            else if (fromState == ConsultationFromOtherHospital.States.InsertedIntoQueue && toState == ConsultationFromOtherHospital.States.ResultEntry)
                PreTransition_InsertedIntoQueue2ResultEntry();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(ConsultationFromOtherHospital).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == ConsultationFromOtherHospital.States.Completed && toState == ConsultationFromOtherHospital.States.Cancelled)
                PostTransition_Completed2Cancelled();
            else if (fromState == ConsultationFromOtherHospital.States.ConsultationInOtherHospital && toState == ConsultationFromOtherHospital.States.Cancelled)
                PostTransition_ConsultationInOtherHospital2Cancelled();
            else if (fromState == ConsultationFromOtherHospital.States.ConsultationInOtherHospital && toState == ConsultationFromOtherHospital.States.ResultEntry)
                PostTransition_ConsultationInOtherHospital2ResultEntry();
            else if (fromState == ConsultationFromOtherHospital.States.ResultEntry && toState == ConsultationFromOtherHospital.States.Completed)
                PostTransition_ResultEntry2Completed();
            else if (fromState == ConsultationFromOtherHospital.States.ResultEntry && toState == ConsultationFromOtherHospital.States.Cancelled)
                PostTransition_ResultEntry2Cancelled();
            else if (fromState == ConsultationFromOtherHospital.States.InsertedIntoQueue && toState == ConsultationFromOtherHospital.States.Cancelled)
                PostTransition_InsertedIntoQueue2Cancelled();
            else if (fromState == ConsultationFromOtherHospital.States.InsertedIntoQueue && toState == ConsultationFromOtherHospital.States.ResultEntry)
                PostTransition_InsertedIntoQueue2ResultEntry();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(ConsultationFromOtherHospital).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == ConsultationFromOtherHospital.States.Approval && toState == ConsultationFromOtherHospital.States.ConsultationInOtherHospital)
                UndoTransition_Approval2ConsultationInOtherHospital(transDef);
            else if (fromState == ConsultationFromOtherHospital.States.Completed && toState == ConsultationFromOtherHospital.States.Cancelled)
                UndoTransition_Completed2Cancelled(transDef);
            else if (fromState == ConsultationFromOtherHospital.States.ConsultationInOtherHospital && toState == ConsultationFromOtherHospital.States.Cancelled)
                UndoTransition_ConsultationInOtherHospital2Cancelled(transDef);
            else if (fromState == ConsultationFromOtherHospital.States.ResultEntry && toState == ConsultationFromOtherHospital.States.Completed)
                UndoTransition_ResultEntry2Completed(transDef);
            else if (fromState == ConsultationFromOtherHospital.States.ResultEntry && toState == ConsultationFromOtherHospital.States.Cancelled)
                UndoTransition_ResultEntry2Cancelled(transDef);
            else if (fromState == ConsultationFromOtherHospital.States.InsertedIntoQueue && toState == ConsultationFromOtherHospital.States.Cancelled)
                UndoTransition_InsertedIntoQueue2Cancelled(transDef);
        }

    }
}