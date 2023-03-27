
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
    /// Profesörler Sağlık Kurulu İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
    public partial class HealthCommitteeOfProfessors : BaseHealthCommittee, IPatientWorkList, IAppointmentDef, IWorkListEpisodeAction
    {
        public partial class GetHealthCommitteeOfProfessors_Class : TTReportNqlObject
        {
        }

        public partial class GetAllHealthCommitteeOfProfessors_Class : TTReportNqlObject
        {
        }

        protected void PostTransition_SecretaryRegistration2CommitteeExamination()
        {
            // From State : SecretaryRegistration   To State : CommitteeExamination
            #region PostTransition_SecretaryRegistration2CommitteeExamination
            CheckHospitalsUnitsGridForFork();
            #endregion PostTransition_SecretaryRegistration2CommitteeExamination
        }

        protected void PostTransition_RequestApproval2DeanApproval()
        {
            // From State : RequestApproval   To State : DeanApproval
            #region PostTransition_RequestApproval2DeanApproval

            CheckUnCompletedApproval();
            #endregion PostTransition_RequestApproval2DeanApproval
        }

        protected void UndoTransition_RequestApproval2DeanApproval(TTObjectStateTransitionDef transitionDef)
        {
            // From State : RequestApproval   To State : DeanApproval
            #region UndoTransition_RequestApproval2DeanApproval

            NoBackStateBack();
            #endregion UndoTransition_RequestApproval2DeanApproval
        }

        protected void PostTransition_PCommitteeAcceptance2Cancelled()
        {
            // From State : PCommitteeAcceptance   To State : Cancelled
            #region PostTransition_PCommitteeAcceptance2Cancelled

            CheckUnCompletedExamination();
            #endregion PostTransition_PCommitteeAcceptance2Cancelled
        }

        protected void PostTransition_PCommitteeAcceptance2ReportOutputForSignature()
        {
            // From State : PCommitteeAcceptance   To State : ReportOutputForSignature
            #region PostTransition_PCommitteeAcceptance2ReportOutputForSignature


            IList<MemberOfHealthCommitteeDefinition> currentDefs = (IList<MemberOfHealthCommitteeDefinition>)MemberOfHealthCommitteeDefinition.GetMemberDefinitions(ObjectContext);

            if (currentDefs.Count == 0)
                throw new Exception(SystemMessage.GetMessageV2(1005, DateTime.Today.Date.ToShortDateString()));
            else
                MemberOfHealthCommitteeOfProf = currentDefs[0];

            #endregion PostTransition_PCommitteeAcceptance2ReportOutputForSignature
        }

        protected void PostTransition_DeanApproval2Rejected()
        {
            // From State : DeanApproval   To State : Rejected
            #region PostTransition_DeanApproval2Rejected

            CheckUnCompletedExamination();
            #endregion PostTransition_DeanApproval2Rejected
        }

        protected void PostTransition_DeanApproval2Request()
        {
            // From State : DeanApproval   To State : Request
            #region PostTransition_DeanApproval2Request
            ReturnApprovalActions();
            //this.ReturnDescriptionInput();//Kaldırılmalı...YY
            #endregion PostTransition_DeanApproval2Request
        }

        protected void PostTransition_ReportOutputForSignature2Cancelled()
        {
            // From State : ReportOutputForSignature   To State : Cancelled
            #region PostTransition_ReportOutputForSignature2Cancelled

            CheckUnCompletedExamination();
            #endregion PostTransition_ReportOutputForSignature2Cancelled
        }

        protected void UndoTransition_ReportOutputForSignature2ReportApproval(TTObjectStateTransitionDef transitionDef)
        {
            // From State : ReportOutputForSignature   To State : ReportApproval
            #region UndoTransition_ReportOutputForSignature2ReportApproval

            NoBackStateBack();
            #endregion UndoTransition_ReportOutputForSignature2ReportApproval
        }

        protected void PostTransition_CommitteeExamination2WaitingForSignature()
        {
            // From State : CommitteeExamination   To State : WaitingForSignature
            #region PostTransition_CommitteeExamination2WaitingForSignature

            CheckUnCompletedExamination();
            #endregion PostTransition_CommitteeExamination2WaitingForSignature
        }

        protected void UndoTransition_CommitteeExamination2WaitingForSignature(TTObjectStateTransitionDef transitionDef)
        {
            // From State : CommitteeExamination   To State : WaitingForSignature
            #region UndoTransition_CommitteeExamination2WaitingForSignature

            CheckUnCompletedExamination();
            #endregion UndoTransition_CommitteeExamination2WaitingForSignature
        }

        protected void PostTransition_CommitteeExamination2Cancelled()
        {
            // From State : CommitteeExamination   To State : Cancelled
            #region PostTransition_CommitteeExamination2Cancelled

            CheckUnCompletedExamination();
            #endregion PostTransition_CommitteeExamination2Cancelled
        }

        protected void UndoTransition_ReportApproval2DeanReportApproval(TTObjectStateTransitionDef transitionDef)
        {
            // From State : ReportApproval   To State : DeanReportApproval
            #region UndoTransition_ReportApproval2DeanReportApproval

            NoBackStateBack();
            #endregion UndoTransition_ReportApproval2DeanReportApproval
        }

        protected void PostTransition_ReportApproval2Rejected()
        {
            // From State : ReportApproval   To State : Rejected
            #region PostTransition_ReportApproval2Rejected

            CheckUnCompletedExamination();
            #endregion PostTransition_ReportApproval2Rejected
        }

        protected void PostTransition_Request2RequestApproval()
        {
            // From State : Request   To State : RequestApproval
            #region PostTransition_Request2RequestApproval

            if (HospitalsUnits.Count == 0)
                throw new Exception(SystemMessage.GetMessage(504));

            CheckApprovalActionsForFire();
            #endregion PostTransition_Request2RequestApproval
        }

        protected void UndoTransition_Request2RequestApproval(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Request   To State : RequestApproval
            #region UndoTransition_Request2RequestApproval


            bool bFound = false;
            foreach (EpisodeAction pAction in LinkedActions)
            {
                if (pAction is HealthCommitteeOfProfessorsApproval && !pAction.CurrentStateDefID.Equals(HealthCommitteeOfProfessorsApproval.States.Completed))
                {
                    bFound = true;
                    break;
                }
            }

            if (bFound)
                throw new Exception(SystemMessage.GetMessageV2(1006, LinkedActions.Count.ToString()));
            #endregion UndoTransition_Request2RequestApproval
        }

        protected void PostTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
            #region PostTransition_Completed2Cancelled

            CheckUnCompletedExamination();
            #endregion PostTransition_Completed2Cancelled
        }

        protected void PostTransition_DeanReportApproval2Rejected()
        {
            // From State : DeanReportApproval   To State : Rejected
            #region PostTransition_DeanReportApproval2Rejected

            CheckUnCompletedExamination();
            #endregion PostTransition_DeanReportApproval2Rejected
        }

        #region Methods
        public HealthCommitteeOfProfessors(TTObjectContext objectContext, EpisodeAction episodeAction) : this(objectContext)
        {
            ActionDate = DateTime.Now;
            FromResource = episodeAction.MasterResource;
            CurrentStateDefID = HealthCommitteeOfProfessors.States.Request;
            Episode = episodeAction.Episode;
        }

        public List<AppointmentCarrier> AppointmentCarrierList
        {
            get
            {
                List<AppointmentCarrier> _appointmentList = new List<AppointmentCarrier>();
                TTObjectContext context = new TTObjectContext(false);
                AppointmentDefinition appDef = null;
                IList appDefList = AppointmentDefinition.GetAppointmentDefinitionByName(context, AppointmentDefinitionEnum.HealthCommitteeOfProfessors);
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
                    carrier.MasterResource = "ResHealthCommittee";
                    carrier.SubResource = "ResDepartment";
                    carrier.RelationParentName = "ResHealthCommittee";

                    _appointmentList.Add(carrier);
                }
                ClearAppointmentCarrierDynamicFields(_appointmentList);
                return _appointmentList;
            }
        }

        #region IAppointmentDef Members
        public List<AppointmentCarrier> GetAppointmentCarrierList()
        {
            return AppointmentCarrierList;
        }
        #endregion

        public override ActionTypeEnum ActionType
        {
            get
            {
                return ActionTypeEnum.HealthCommitteeOfProfessors;
            }
        }

        /// <summary>
        /// HospitalsUnits içindeki her bir satırın SK Muayenesi olarak fork edilmesini sağlar.
        /// </summary>
        protected void CheckHospitalsUnitsGridForFork()
        {
            ArrayList arrList = EpisodeAction.GetLinkedEpisodeActions(this);
            foreach (BaseHealthCommittee_HospitalsUnitsGrid hospitalUnit in _HospitalsUnits)
            {
                bool bFound = false;
                foreach (EpisodeAction eaction in arrList)
                {
                    HealthCommitteeExamination exam = eaction as HealthCommitteeExamination;
                    if (exam != null && eaction.MasterResource.ObjectID.Equals(hospitalUnit.Unit.ObjectID))
                    {
                        bFound = true;
                        break;
                    }
                }

                if (!bFound)
                    EpisodeAction.ForkHealthCommitteeExamination((HospitalsUnitsGrid)hospitalUnit,this);
            }
        }

        protected void FireApprovalActions(HospitalsUnitsGrid hospitalsUnits)
        {
            HealthCommitteeOfProfessorsApproval approval = new HealthCommitteeOfProfessorsApproval((EpisodeAction)this, hospitalsUnits);
        }

        protected void CheckApprovalActionsForFire()
        {
            ArrayList arrList = EpisodeAction.GetLinkedEpisodeActions(this);
            foreach (BaseHealthCommittee_HospitalsUnitsGrid hospitalUnit in _HospitalsUnits)
            {
                bool bFound = false;
                foreach (EpisodeAction eaction in arrList)
                {
                    HealthCommitteeOfProfessorsApproval approval = eaction as HealthCommitteeOfProfessorsApproval;
                    if (approval != null && eaction.MasterResource.ObjectID.Equals(hospitalUnit.Unit.ObjectID))
                    {
                        bFound = true;
                        break;
                    }
                }

                if (!bFound)
                    FireApprovalActions((HospitalsUnitsGrid)hospitalUnit);
            }
        }

        private void ReturnApprovalActions()
        {
            ArrayList arrList = EpisodeAction.GetLinkedEpisodeActions(this);
            foreach (EpisodeAction eaction in arrList)
            {
                if (eaction is HealthCommitteeOfProfessorsApproval)
                {
                    HealthCommitteeOfProfessorsApproval approval = (HealthCommitteeOfProfessorsApproval)eaction;
                    if (approval.CurrentStateDefID.Equals(HealthCommitteeOfProfessorsApproval.States.Completed))
                    {
                        ITTObject pObject = (ITTObject)approval;
                        pObject.UndoLastTransition();
                    }
                }
            }
        }

        private void CheckUnCompletedExamination()
        {
            bool bFound = false;
            ArrayList arrList = EpisodeAction.GetLinkedEpisodeActions(this);
            foreach (EpisodeAction eaction in arrList)
            {
                if (eaction is HealthCommitteeExamination && !eaction.IsCancelled)
                {
                    HealthCommitteeExamination exam = (HealthCommitteeExamination)eaction;
                    if (!exam.CurrentStateDefID.Equals(HealthCommitteeExamination.States.Completed))
                    {
                        bFound = true;
                        break;
                    }
                }

                if (eaction is HealthCommitteeExaminationFromOtherDepartments && !eaction.IsCancelled)
                {
                    HealthCommitteeExaminationFromOtherDepartments exam = (HealthCommitteeExaminationFromOtherDepartments)eaction;
                    if (!exam.CurrentStateDefID.Equals(HealthCommitteeExaminationFromOtherDepartments.States.Acceptance))
                    {
                        bFound = true;
                        break;
                    }
                }
            }

            if (bFound)
                throw new Exception(SystemMessage.GetMessage(501));
        }

        private void CheckUnCompletedApproval()
        {
            bool bFound = false;
            ArrayList arrList = EpisodeAction.GetLinkedEpisodeActions(this);
            foreach (EpisodeAction eaction in arrList)
            {
                if (eaction is HealthCommitteeOfProfessorsApproval && !eaction.CurrentStateDefID.Equals(HealthCommitteeOfProfessorsApproval.States.Rejected))
                {
                    HealthCommitteeOfProfessorsApproval approval = (HealthCommitteeOfProfessorsApproval)eaction;
                    if (!approval.CurrentStateDefID.Equals(HealthCommitteeOfProfessorsApproval.States.Completed))
                    {
                        bFound = true;
                        break;
                    }
                }
            }

            if (bFound)
                throw new Exception(SystemMessage.GetMessage(1007));
        }

        //        protected override List<OldActionPropertyObject> OldActionPropertyList()
        //        {
        //            List<OldActionPropertyObject> propertyList;
        //            if(base.OldActionPropertyList()==null)
        //                propertyList = new List<OldActionPropertyObject>();
        //            else
        //                propertyList = base.OldActionPropertyList();
        //            propertyList.Add(new OldActionPropertyObject("Protokol No",Common.ReturnObjectAsString(this.ProtocolNo)));
        //            propertyList.Add(new OldActionPropertyObject("Rapor No",Common.ReturnObjectAsString(ReportNo)));
        //            propertyList.Add(new OldActionPropertyObject("Rapor Tarihi",Common.ReturnObjectAsString(ReportDate)));
        //            propertyList.Add(new OldActionPropertyObject("Rapor ",Common.ReturnObjectAsString(Report)));
        //            propertyList.Add(new OldActionPropertyObject("Karar ",Common.ReturnObjectAsString(Decision)));
        //            if(ProcedureDoctor!=null)
        //                propertyList.Add(new OldActionPropertyObject("Sorumlu Doktor ",Common.ReturnObjectAsString(ProcedureDoctor.Name)));
        //            if(this.ProcedureSpeciality!=null)
        //                propertyList.Add(new OldActionPropertyObject("Uzmanlık Dalı",Common.ReturnObjectAsString(this.ProcedureSpeciality.Name)));
        //            
        //            return propertyList;
        //        }
        //        
        //        
        //        protected override List<List<List<OldActionPropertyObject>>> OldActionChildRelationList()
        //        {
        //            List<List<List<OldActionPropertyObject>>> gridList;
        //            if(base.OldActionChildRelationList()==null)
        //                gridList=new List<List<List<OldActionPropertyObject>>>();
        //            else
        //                gridList=base.OldActionChildRelationList();
        //            // Madde Dilim Fıkra
        //            List<List<OldActionPropertyObject>> gridMainSurgeryProceduresRowList=new List<List<OldActionPropertyObject>>();
        //            foreach(HealthCommitteeOfProfessors_MatterSliceAnectodeGrid theGrid in this.MatterSliceAnectodes)
        //            {
        //                List<OldActionPropertyObject> gridMainSurgeryProceduresRowColumnList=new List<OldActionPropertyObject>();
        //                gridMainSurgeryProceduresRowColumnList.Add(new OldActionPropertyObject("Madde",Common.ReturnObjectAsString(theGrid.Matter)));
        //                gridMainSurgeryProceduresRowColumnList.Add(new OldActionPropertyObject("Dilim",Common.ReturnObjectAsString(theGrid.Slice)));
        //                gridMainSurgeryProceduresRowColumnList.Add(new OldActionPropertyObject("Fıkra",Common.ReturnObjectAsString(theGrid.Anectode)));
        //                gridMainSurgeryProceduresRowList.Add(gridMainSurgeryProceduresRowColumnList);
        //            }
        //            gridList.Add(gridMainSurgeryProceduresRowList);
        //            
        //            return gridList;
        //        }

        #endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(HealthCommitteeOfProfessors).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == HealthCommitteeOfProfessors.States.SecretaryRegistration && toState == HealthCommitteeOfProfessors.States.CommitteeExamination)
                PostTransition_SecretaryRegistration2CommitteeExamination();
            else if (fromState == HealthCommitteeOfProfessors.States.RequestApproval && toState == HealthCommitteeOfProfessors.States.DeanApproval)
                PostTransition_RequestApproval2DeanApproval();
            else if (fromState == HealthCommitteeOfProfessors.States.PCommitteeAcceptance && toState == HealthCommitteeOfProfessors.States.Cancelled)
                PostTransition_PCommitteeAcceptance2Cancelled();
            else if (fromState == HealthCommitteeOfProfessors.States.PCommitteeAcceptance && toState == HealthCommitteeOfProfessors.States.ReportOutputForSignature)
                PostTransition_PCommitteeAcceptance2ReportOutputForSignature();
            else if (fromState == HealthCommitteeOfProfessors.States.DeanApproval && toState == HealthCommitteeOfProfessors.States.Rejected)
                PostTransition_DeanApproval2Rejected();
            else if (fromState == HealthCommitteeOfProfessors.States.DeanApproval && toState == HealthCommitteeOfProfessors.States.Request)
                PostTransition_DeanApproval2Request();
            else if (fromState == HealthCommitteeOfProfessors.States.ReportOutputForSignature && toState == HealthCommitteeOfProfessors.States.Cancelled)
                PostTransition_ReportOutputForSignature2Cancelled();
            else if (fromState == HealthCommitteeOfProfessors.States.CommitteeExamination && toState == HealthCommitteeOfProfessors.States.WaitingForSignature)
                PostTransition_CommitteeExamination2WaitingForSignature();
            else if (fromState == HealthCommitteeOfProfessors.States.CommitteeExamination && toState == HealthCommitteeOfProfessors.States.Cancelled)
                PostTransition_CommitteeExamination2Cancelled();
            else if (fromState == HealthCommitteeOfProfessors.States.ReportApproval && toState == HealthCommitteeOfProfessors.States.Rejected)
                PostTransition_ReportApproval2Rejected();
            else if (fromState == HealthCommitteeOfProfessors.States.Request && toState == HealthCommitteeOfProfessors.States.RequestApproval)
                PostTransition_Request2RequestApproval();
            else if (fromState == HealthCommitteeOfProfessors.States.Completed && toState == HealthCommitteeOfProfessors.States.Cancelled)
                PostTransition_Completed2Cancelled();
            else if (fromState == HealthCommitteeOfProfessors.States.DeanReportApproval && toState == HealthCommitteeOfProfessors.States.Rejected)
                PostTransition_DeanReportApproval2Rejected();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(HealthCommitteeOfProfessors).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == HealthCommitteeOfProfessors.States.RequestApproval && toState == HealthCommitteeOfProfessors.States.DeanApproval)
                UndoTransition_RequestApproval2DeanApproval(transDef);
            else if (fromState == HealthCommitteeOfProfessors.States.ReportOutputForSignature && toState == HealthCommitteeOfProfessors.States.ReportApproval)
                UndoTransition_ReportOutputForSignature2ReportApproval(transDef);
            else if (fromState == HealthCommitteeOfProfessors.States.CommitteeExamination && toState == HealthCommitteeOfProfessors.States.WaitingForSignature)
                UndoTransition_CommitteeExamination2WaitingForSignature(transDef);
            else if (fromState == HealthCommitteeOfProfessors.States.ReportApproval && toState == HealthCommitteeOfProfessors.States.DeanReportApproval)
                UndoTransition_ReportApproval2DeanReportApproval(transDef);
            else if (fromState == HealthCommitteeOfProfessors.States.Request && toState == HealthCommitteeOfProfessors.States.RequestApproval)
                UndoTransition_Request2RequestApproval(transDef);
        }

    }
}