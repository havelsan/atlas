
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
    /// Diğer XXXXXX(ler)den Sağlık Kurulu Muayenesi
    /// </summary>
    public  partial class HealthCommitteeExaminationFromOtherHospitals : BaseHealthCommitteeExamination, IWorkListEpisodeAction, IAllocateSpeciality
    {
        public partial class GetHCEFOHByMasterAction_Class : TTReportNqlObject 
        {
        }

        public partial class GetHCEFOHByDate_Class : TTReportNqlObject 
        {
        }

        public partial class GetCurrentHCEFromOtherHospital_Class : TTReportNqlObject 
        {
        }

        public partial class OLAP_SaglikKuruluSevk_Class : TTReportNqlObject 
        {
        }

        public partial class GetHCEFOHForTransferReport_Class : TTReportNqlObject 
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

        protected void UndoTransition_TransferDocumentConstitution2DecisionRegistration(TTObjectStateTransitionDef transitionDef)
        {
            // From State : TransferDocumentConstitution   To State : DecisionRegistration
#region UndoTransition_TransferDocumentConstitution2DecisionRegistration
            
            NoBackStateBack();

#endregion UndoTransition_TransferDocumentConstitution2DecisionRegistration
        }

        protected void PostTransition_Resulted2Cancelled()
        {
            // From State : Resulted   To State : Cancelled
#region PostTransition_Resulted2Cancelled
            
            CheckMasterActionPrivilege();

#endregion PostTransition_Resulted2Cancelled
        }

        protected void UndoTransition_DecisionRegistration2Cancelled(TTObjectStateTransitionDef transitionDef)
        {
            // From State : DecisionRegistration   To State : Cancelled
#region UndoTransition_DecisionRegistration2Cancelled
            
            NoBackStateBack();

#endregion UndoTransition_DecisionRegistration2Cancelled
        }

        protected void PostTransition_DecisionRegistration2Resulted()
        {
            // From State : DecisionRegistration   To State : Resulted
#region PostTransition_DecisionRegistration2Resulted
            
            
            
            // Muayeneye Gönderilen XXXXXX
            if(!String.IsNullOrEmpty(SourceObjectID))
            {
                if(Doctor == null)
                    throw new TTException(SystemMessage.GetMessage(1052));
                else
                {
                    DrName = Doctor.Name;
                    DrEmploymentRecordID = Doctor.EmploymentRecordID;
                    DrSpeciality = Doctor.GetSpeciality();
                    
                    if (Doctor.Title.HasValue)
                        DrTitle += TTObjectClasses.Common.GetDescriptionOfDataTypeEnum(Doctor.Title.Value);
                    
                    if (Doctor.Rank != null)
                        DrTitle += " " + Doctor.Rank.ShortName;
                }
                
                if(ReportNo.Value == null)
                    ReportNo.GetNextValue(MasterResource.ObjectID.ToString(), Common.RecTime().Year);
            }

#endregion PostTransition_DecisionRegistration2Resulted
        }

        protected void UndoTransition_DecisionRegistration2Resulted(TTObjectStateTransitionDef transitionDef)
        {
            // From State : DecisionRegistration   To State : Resulted
#region UndoTransition_DecisionRegistration2Resulted
            
            //this.CheckMasterActionPrivilege();
            NoBackStateBack();

#endregion UndoTransition_DecisionRegistration2Resulted
        }

#region Methods
        public HealthCommitteeExaminationFromOtherHospitals(TTObjectContext objectContext, EpisodeAction episodeAction) : this(objectContext)
        {
            ActionDate = Common.RecTime();
            MasterResource = episodeAction.MasterResource;
            FromResource = episodeAction.MasterResource;
            CurrentStateDefID = HealthCommitteeExaminationFromOtherHospitals.States.New;
            Episode = episodeAction.Episode;
        }
        
        
        
        /// <summary>
        /// Fork işlemleri için kullanılır.
        /// </summary>
        /// <param name="episodeAction"></param>
        /// <param name="masterResource"></param>
        /// <param name="hospital"></param>
        public HealthCommitteeExaminationFromOtherHospitals(EpisodeAction masterAction, HospitalsUnitsGrid hospitalsUnits):this(masterAction.ObjectContext)
        {
            CurrentStateDefID = HealthCommitteeExaminationFromOtherHospitals.States.New;
            RequestExplanation = hospitalsUnits.Explanation;
            //this.Hospital = hospitalsUnits.Hospital;
            //this.Hospitals = hospitalsUnits.Hospitals;
            Unit = hospitalsUnits.Unit as ResDepartment;
           // this.ReferableResource = hospitalsUnits.ReferableResource;
            Speciality = hospitalsUnits.Speciality;
            
            if(masterAction is HealthCommittee)
                ReasonForExamination = ((HealthCommittee)masterAction).HCRequestReason.ReasonForExamination;
            
            if(masterAction is HealthCommitteeExaminationFromOtherDepartments)
            {
                HealthCommitteeExaminationFromOtherDepartments masterAction2= (HealthCommitteeExaminationFromOtherDepartments)masterAction;
                SetMandatoryEpisodeActionProperties(masterAction2.HCActionToBeLinked , (ResSection)hospitalsUnits.Unit,true);
            }
            else
            {
                SetMandatoryEpisodeActionProperties(masterAction, (ResSection)hospitalsUnits.Unit,true);
            }
            
            //if(hospitalsUnits.ReferableResource != null && hospitalsUnits.ReferableResource.ReferableHospital != null && hospitalsUnits.ReferableResource.ReferableHospital.ResOtherHospital != null)
            //    this.MasterResource = (ResSection)hospitalsUnits.ReferableResource.ReferableHospital.ResOtherHospital;
        }
        
        protected override void OnConstruct()
        {
            base.OnConstruct();
            ITTObject pObj = (ITTObject)this;
            if(pObj.IsNew)
            {
                DocumentNumber.GetNextValue(Common.RecTime().Year);
                //this.ReportNo.GetNextValue(Common.RecTime().Year);
            }
        }
        

        
        private void CheckMasterActionPrivilege()
        {
            if(MasterAction != null && MasterAction is HealthCommittee)
            {
                HealthCommittee pMaster = MasterAction as HealthCommittee;
                if(!pMaster.IsCancelled)
                {
                    if(!pMaster.CurrentStateDefID.Equals(HealthCommittee.States.CommitteeAcceptance))
                    {
                        throw new Exception(SystemMessage.GetMessage(641));
                    }
                }
            }
        }
        
       

        /*
        public void RunSendHealthCommitteeExaminationFromOtherHospitals()
        {
            if(this.Hospitals != null)
            {
                if(this.Hospitals is ResOtherHospital)
                {
                    if(((ResOtherHospital)this.Hospitals).Site != null)
                    {
                        Guid savePoint = this.ObjectContext.BeginSavePoint();
                        String messageString = "";
                        try
                        {
                            List<DiagnosisGrid> diagnosisList = new List<DiagnosisGrid>();
                            foreach (DiagnosisGrid dg in this.Episode.Diagnosis)
                            {
                                diagnosisList.Add(dg.PrepareDiagnosisGridForRemoteMethod(true));
                            }
                            Sites localSite = TTObjectClasses.SystemParameter.GetSite();
                            TTMessage message = HealthCommitteeExaminationFromOtherHospitals.RemoteMethods.SendHealthCommitteeExaminationFromOtherHospitals(((ResOtherHospital)this.Hospitals).Site.ObjectID, this.Episode.Patient, this.Episode.PrepareEpisodeForRemoteMethod(true), this.SubEpisode.PatientAdmission.PreparePatientAdmissionForRemoteMethod(true), (HealthCommitteeExaminationFromOtherHospitals)this.PrepareEpisodeActionForRemoteMethod(true), diagnosisList,localSite,this.ObjectID,this.Episode.GetMyEpisodeProtocolForRemoteMethod());
                            messageString = message.MessageID.ToString();
                        }
                        finally
                        {
                            this.ObjectContext.RollbackSavePoint(savePoint);
                            this.MessageID = messageString;
                            this.ObjectContext.Save();
                        }
                    }
                }
            }
        }
        
        public void RunReturnHealthCommitteeExaminationFromOtherHospitals()
        {
            if(this.Hospitals != null)
            {
                if(this.Hospitals is ResOtherHospital)
                {
                    if(((ResOtherHospital)this.Hospitals).Site != null)
                    {
                        Guid savePoint = this.ObjectContext.BeginSavePoint();
                        String messageString = "";
                        try
                        {
                            // Geriye gönderilirken yalnız Muayenede konulan tanılar geriye gönderiliyor
                            List<DiagnosisGrid> diagnosisList = new List<DiagnosisGrid>();
                            foreach (DiagnosisGrid dg in this.Diagnosis)
                            {
                                if(dg.ResponsibleUser!=null)
                                    diagnosisList.Add(dg.PrepareDiagnosisGridForRemoteMethod(true));
                            }
                            
                            List<HCExaminationFromOtherHospitals_MatterSliceAnectodeGrid> msaList = new List<HCExaminationFromOtherHospitals_MatterSliceAnectodeGrid>();
                            foreach (HCExaminationFromOtherHospitals_MatterSliceAnectodeGrid msaGrid in this.MatterSliceAnectodes)
                            {
                                msaList.Add((HCExaminationFromOtherHospitals_MatterSliceAnectodeGrid)msaGrid.PrepareMatterSliceAnectodeGridForRemoteMethod(true));
                            }
                            
                            List<SpecialityDefinition> specialityList = new List<SpecialityDefinition>();
                            if(this.DrSpeciality != null)
                                specialityList.Add(this.DrSpeciality);
                            
                            TTMessage message = HealthCommitteeExaminationFromOtherHospitals.RemoteMethods.ReturnHealthCommitteeExaminationFromOtherHospitals(this.RequesterHospital.Site.ObjectID, (HealthCommitteeExaminationFromOtherHospitals)this.PrepareEpisodeActionForRemoteMethod(true), diagnosisList, msaList, specialityList);
                            messageString = message.MessageID.ToString();
                        }
                        catch(Exception ex)
                        {
                            throw ex;
                        }
                        finally
                        {
                            this.ObjectContext.RollbackSavePoint(savePoint);
                            if(this.CurrentStateDefID != HealthCommitteeExaminationFromOtherHospitals.States.Cancelled)
                                this.MessageID = messageString;
                            this.ObjectContext.Save();
                        }
                    }
                }
            }
        }
        */
        
#endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(HealthCommitteeExaminationFromOtherHospitals).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == HealthCommitteeExaminationFromOtherHospitals.States.Resulted && toState == HealthCommitteeExaminationFromOtherHospitals.States.Cancelled)
                PostTransition_Resulted2Cancelled();
            else if (fromState == HealthCommitteeExaminationFromOtherHospitals.States.DecisionRegistration && toState == HealthCommitteeExaminationFromOtherHospitals.States.Resulted)
                PostTransition_DecisionRegistration2Resulted();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(HealthCommitteeExaminationFromOtherHospitals).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == HealthCommitteeExaminationFromOtherHospitals.States.TransferDocumentConstitution && toState == HealthCommitteeExaminationFromOtherHospitals.States.DecisionRegistration)
                UndoTransition_TransferDocumentConstitution2DecisionRegistration(transDef);
            else if (fromState == HealthCommitteeExaminationFromOtherHospitals.States.DecisionRegistration && toState == HealthCommitteeExaminationFromOtherHospitals.States.Cancelled)
                UndoTransition_DecisionRegistration2Cancelled(transDef);
            else if (fromState == HealthCommitteeExaminationFromOtherHospitals.States.DecisionRegistration && toState == HealthCommitteeExaminationFromOtherHospitals.States.Resulted)
                UndoTransition_DecisionRegistration2Resulted(transDef);
        }

    }
}