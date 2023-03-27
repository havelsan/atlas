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
    /// Ortez Protez  İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
    public partial class OrthesisProsthesisRequest : EpisodeActionWithDiagnosis, IAppointmentDef, IWorkListEpisodeAction
    {
        public partial class GetOrthesisProsthesisRequest_Class : TTReportNqlObject
        {
        }

        protected override void PreInsert()
        {
            #region PreInsert
            base.PreInsert();
            IgnoreEpisodeStateOnUpdate = true;

            #endregion PreInsert
        }

        protected void PostTransition_HealthCommittee2Rejected()
        {
            // From State : HealthCommittee   To State : Rejected
            #region PostTransition_HealthCommittee2Rejected
            CancelAccountTransactionsForOrthesisProsthesis();
            #endregion PostTransition_HealthCommittee2Rejected
        }

        protected void UndoTransition_HealthCommittee2Rejected(TTObjectStateTransitionDef transitionDef)
        {
            // From State : HealthCommittee   To State : Rejected
            #region UndoTransition_HealthCommittee2Rejected
            NoBackStateBack();
            #endregion UndoTransition_HealthCommittee2Rejected
        }

        protected void PostTransition_HealthCommittee2HealthCommitteeApproval()
        {
            // From State : HealthCommittee   To State : HealthCommitteeApproval
            #region PostTransition_HealthCommittee2HealthCommitteeApproval
            FireHealthCommittee();
            #endregion PostTransition_HealthCommittee2HealthCommitteeApproval
        }

        protected void UndoTransition_HealthCommittee2HealthCommitteeApproval(TTObjectStateTransitionDef transitionDef)
        {
            // From State : HealthCommittee   To State : HealthCommitteeApproval
            #region UndoTransition_HealthCommittee2HealthCommitteeApproval
            NoBackStateBack();
            #endregion UndoTransition_HealthCommittee2HealthCommitteeApproval
        }

        protected void PostTransition_FinancialDepartmentControl2RequestAcception()
        {
            // From State : FinancialDepartmentControl   To State : RequestAcception
            #region PostTransition_FinancialDepartmentControl2RequestAcception
            if (OrthesisProsthesisProcedures.Count > 1)
                SplitOrthesisProsthesisProcedures(OrthesisProsthesisRequest.States.RequestAcception, false);
            #endregion PostTransition_FinancialDepartmentControl2RequestAcception
        }

        protected void UndoTransition_Procedure2ControlApproval(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Procedure   To State : ControlApproval
            #region UndoTransition_Procedure2ControlApproval
            NoBackStateBack();
            #endregion UndoTransition_Procedure2ControlApproval
        }

        protected void UndoTransition_Procedure2Appointment(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Procedure   To State : Appointment
            #region UndoTransition_Procedure2Appointment
            NoBackStateBack();
            #endregion UndoTransition_Procedure2Appointment
        }

        protected void PostTransition_Procedure2RequestAcception()
        {
            // From State : Procedure   To State : RequestAcception
            #region PostTransition_Procedure2RequestAcception
            //this.SetCancelledProcedures();
            #endregion PostTransition_Procedure2RequestAcception
        }

        protected void PostTransition_Procedure2Cancelled()
        {
            // From State : Procedure   To State : Cancelled
            #region PostTransition_Procedure2Cancelled
            Cancel();
            #endregion PostTransition_Procedure2Cancelled
        }

        protected void PreTransition_DoctorApproval2Completed()
        {
            // From State : DoctorApproval   To State : Completed
            #region PreTransition_DoctorApproval2Completed
            if (OrthesisProsthesisRequest.UnCompletedLinkedActions(this).Count > 0)
            {
                throw new Exception(SystemMessage.GetMessageV2(625, Common.ArrayListToString(OrthesisProsthesisRequest.UnCompletedLinkedActions(this)).ToString()));
            }
            #endregion PreTransition_DoctorApproval2Completed
        }

        protected void PostTransition_DoctorApproval2Completed()
        {
            // From State : DoctorApproval   To State : Completed
            #region PostTransition_DoctorApproval2Completed
            UpdateMyPayerAccTrxStatesToMedulaDontSend();
            #endregion PostTransition_DoctorApproval2Completed
        }

        protected void PostTransition_DoctorApproval2Cancelled()
        {
            // From State : DoctorApproval   To State : Cancelled
            #region PostTransition_DoctorApproval2Cancelled
            Cancel();
            #endregion PostTransition_DoctorApproval2Cancelled
        }

        protected void PostTransition_RequestReturn2Rejected()
        {
            // From State : RequestReturn   To State : Rejected
            #region PostTransition_RequestReturn2Rejected
            CancelAccountTransactionsForOrthesisProsthesis();
            #endregion PostTransition_RequestReturn2Rejected
        }

        protected void UndoTransition_RequestReturn2Rejected(TTObjectStateTransitionDef transitionDef)
        {
            // From State : RequestReturn   To State : Rejected
            #region UndoTransition_RequestReturn2Rejected
            NoBackStateBack();
            #endregion UndoTransition_RequestReturn2Rejected
        }

        protected void PostTransition_HealthCommitteeWithThreeSpecialistApproval2Rejected()
        {
            // From State : HealthCommitteeWithThreeSpecialistApproval   To State : Rejected
            #region PostTransition_HealthCommitteeWithThreeSpecialistApproval2Rejected
            CancelAccountTransactionsForOrthesisProsthesis();
            #endregion PostTransition_HealthCommitteeWithThreeSpecialistApproval2Rejected
        }

        protected void UndoTransition_HealthCommitteeWithThreeSpecialistApproval2Rejected(TTObjectStateTransitionDef transitionDef)
        {
            // From State : HealthCommitteeWithThreeSpecialistApproval   To State : Rejected
            #region UndoTransition_HealthCommitteeWithThreeSpecialistApproval2Rejected
            NoBackStateBack();
            #endregion UndoTransition_HealthCommitteeWithThreeSpecialistApproval2Rejected
        }

        protected void PostTransition_HealthCommitteeWithThreeSpecialist2HealthCommitteeWithThreeSpecialistApproval()
        {
            // From State : HealthCommitteeWithThreeSpecialist   To State : HealthCommitteeWithThreeSpecialistApproval
            #region PostTransition_HealthCommitteeWithThreeSpecialist2HealthCommitteeWithThreeSpecialistApproval
            FireHealthCommitteeWithThreeSpecialist();
            #endregion PostTransition_HealthCommitteeWithThreeSpecialist2HealthCommitteeWithThreeSpecialistApproval
        }

        protected void UndoTransition_HealthCommitteeWithThreeSpecialist2HealthCommitteeWithThreeSpecialistApproval(TTObjectStateTransitionDef transitionDef)
        {
            // From State : HealthCommitteeWithThreeSpecialist   To State : HealthCommitteeWithThreeSpecialistApproval
            #region UndoTransition_HealthCommitteeWithThreeSpecialist2HealthCommitteeWithThreeSpecialistApproval
            //Step back yapılmsaı için fire edilen tüm işlemlerin iptal edilmesi gereklidir.  
            NoBackStateBack();
            #endregion UndoTransition_HealthCommitteeWithThreeSpecialist2HealthCommitteeWithThreeSpecialistApproval
        }

        protected void PostTransition_HealthCommitteeWithThreeSpecialist2Rejected()
        {
            // From State : HealthCommitteeWithThreeSpecialist   To State : Rejected
            #region PostTransition_HealthCommitteeWithThreeSpecialist2Rejected
            CancelAccountTransactionsForOrthesisProsthesis();
            #endregion PostTransition_HealthCommitteeWithThreeSpecialist2Rejected
        }

        protected void UndoTransition_HealthCommitteeWithThreeSpecialist2Rejected(TTObjectStateTransitionDef transitionDef)
        {
            // From State : HealthCommitteeWithThreeSpecialist   To State : Rejected
            #region UndoTransition_HealthCommitteeWithThreeSpecialist2Rejected
            NoBackStateBack();
            #endregion UndoTransition_HealthCommitteeWithThreeSpecialist2Rejected
        }

        protected void PostTransition_RequestAcception2HealthCommittee()
        {
            // From State : RequestAcception   To State : HealthCommittee
            #region PostTransition_RequestAcception2HealthCommittee
            ReasonForExaminationDefinition Examdef = Common.ReasonForExaminationByType(ObjectContext, ReasonForExaminationTypeEnum.OrthesisProsthesisHealthCommittee);
            if (Examdef != null)
            {
                ReasonForExamination = Examdef;
            }
            else
            {
                throw new Exception(SystemMessage.GetMessage(626));
            }
            #endregion PostTransition_RequestAcception2HealthCommittee
        }

        protected void PostTransition_RequestAcception2RequestReturn()
        {
            // From State : RequestAcception   To State : RequestReturn
            #region PostTransition_RequestAcception2RequestReturn
            //this.SetCancelledProcedures();
            #endregion PostTransition_RequestAcception2RequestReturn
        }

        protected void PostTransition_RequestAcception2HealthCommitteeWithThreeSpecialist()
        {
            // From State : RequestAcception   To State : HealthCommitteeWithThreeSpecialist
            #region PostTransition_RequestAcception2HealthCommitteeWithThreeSpecialist
            if (Common.ReasonForExaminationByType(ObjectContext, ReasonForExaminationTypeEnum.OrthesisProsthesisHealthCommitteeWithThreeSpecialist) != null)
            {
                ReasonForExamination = Common.ReasonForExaminationByType(ObjectContext, ReasonForExaminationTypeEnum.OrthesisProsthesisHealthCommitteeWithThreeSpecialist);
            }
            else
            {
                throw new Exception(SystemMessage.GetMessage(627));
            }
            #endregion PostTransition_RequestAcception2HealthCommitteeWithThreeSpecialist
        }

        protected void UndoTransition_RequestAcception2Appointment(TTObjectStateTransitionDef transitionDef)
        {
            // From State : RequestAcception   To State : Appointment
            #region UndoTransition_RequestAcception2Appointment
            NoBackStateBack();
            #endregion UndoTransition_RequestAcception2Appointment
        }

        protected void PostTransition_RequestAcception2Cancelled()
        {
            // From State : RequestAcception   To State : Cancelled
            #region PostTransition_RequestAcception2Cancelled
            Cancel();
            #endregion PostTransition_RequestAcception2Cancelled
        }

        protected void PostTransition_Pricing2Cancelled()
        {
            Cancel();
        }

        protected void PostTransition_TechnicianSelection2Cancelled()
        {
            Cancel();
        }

        protected void PostTransition_Request2Pricing()
        {
            if (IsInRequest.Value)
                PrintOrthesisProsthesisReport();
        }

        protected void PostTransition_Pricing2TechnicianSelection()
        {
            if (OrthesisProsthesisProcedures.Any(x => !x.PayRatio.HasValue))
                throw new TTException(TTUtils.CultureService.GetText("M99999", "Ödeme Oranı boş olamaz."));

            //AccountingOperation(); // Ücretlendirmeler artık OrthesisProsthesisProcedure ün PostInsert ve PostUpdate inde yapılacağı için burdan kaldırıldı )
        }

        protected void PostTransition_TechnicianSelection2Pricing()
        {
            //artık işlemleri iptal edip yeniden faturalandıracak
            //IsCashierOrInvoiceOpDone();
            //CancelAccountTransactionsForOrthesisProsthesis();
        }

        protected void PostTransition_Procedure2Pricing()
        {
            //artık işlemleri iptal edip yeniden faturalandıracak
            //IsCashierOrInvoiceOpDone();
            //CancelAccountTransactionsForOrthesisProsthesis();
        }

        protected void PostTransition_Procedure2ControlApproval()
        {
            //teknisyen işlemi yapıp başteknisyene gönderdiği zaman performdate set etsin
            SetMySubActionProceduresPerformedDate();
        }

        protected void PostTransition_ControlApproval2Procedure()
        {
            foreach (SubActionProcedure subactionProcedure in OrthesisProsthesisProcedures.Where(x => x.CurrentStateDef.Status != StateStatusEnum.Cancelled))
            {
                subactionProcedure.PerformedDate = null;
            }
        }

        protected void PostTransition_HealthCommitteeApproval2Rejected()
        {
            // From State : HealthCommitteeApproval   To State : Rejected
            #region PostTransition_HealthCommitteeApproval2Rejected
            CancelAccountTransactionsForOrthesisProsthesis();
            #endregion PostTransition_HealthCommitteeApproval2Rejected
        }

        protected void UndoTransition_HealthCommitteeApproval2Rejected(TTObjectStateTransitionDef transitionDef)
        {
            // From State : HealthCommitteeApproval   To State : Rejected
            #region UndoTransition_HealthCommitteeApproval2Rejected
            NoBackStateBack();
            #endregion UndoTransition_HealthCommitteeApproval2Rejected
        }

        protected void PostTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
            #region PostTransition_Completed2Cancelled
            Cancel();
            #endregion PostTransition_Completed2Cancelled
        }

        protected void PostTransition_Request2FinancialDepartmentControl()
        {
            // From State : Request   To State : FinancialDepartmentControl
            #region PostTransition_Request2FinancialDepartmentControl
            PrintOrthesisProsthesisReport();
            #endregion PostTransition_Request2FinancialDepartmentControl
        }

        protected void PreTransition_Request2RequestAcception()
        {
            // From State : Request   To State : RequestAcception
            #region PreTransition_Request2RequestAcception
            //            OrthesisProsthesisProcedure pProcedure = new OrthesisProsthesisProcedure(this, SystemParameter.GetParameterValue("ORTHESISPROSTHESISPROCEDURECODE", "742E390C-501E-4CA1-8FBF-139155FF93FB"));
            #endregion PreTransition_Request2RequestAcception
        }

        protected void PreTransition_Request2Pricing()
        {
            //if (this.RequestDate != null)
            //{
            //    AppointmentWithoutResource appointmentWithoutResource = new AppointmentWithoutResource(this.ObjectContext);
            //    appointmentWithoutResource.CurrentStateDefID = AppointmentWithoutResource.States.New;
            //    appointmentWithoutResource.AppDateTime = Convert.ToDateTime(this.RequestDate);
            //    this.WorkListDate = Convert.ToDateTime(this.RequestDate);
            //    this.AppointmentWithoutResources.Add(appointmentWithoutResource);
            //}
            //else
            //{
            //    string[] hataParamList = new string[] { "'İstek  Tarihi'" };
            //    throw new TTUtils.TTException(SystemMessage.GetMessageV3(95, hataParamList));
            //    //throw new Exception ("Anestezi Uygulama Tarihi boş geçilemez");
            //}
        }

        protected void PostTransition_Request2RequestAcception()
        {
            // From State : Request   To State : RequestAcception
            #region PostTransition_Request2RequestAcception
            //if (this.OrthesisProsthesisProcedures.Count > 1)
            //    this.SplitOrthesisProsthesisProcedures(OrthesisProsthesisRequest.States.RequestAcception, true);
            //if (this.IsInRequest.Value)
            //    this.PrintOrthesisProsthesisReport();
            //foreach (OrthesisProsthesisProcedure pProc in this.OrthesisProsthesisProcedures)
            //{
            //    OrtesisProsthesisDefinition pDef = pProc.ProcedureObject as OrtesisProsthesisDefinition;
            //    if (pDef != null && pDef.HealthCommitteeType.Value == OrthesisProsthesisHCType.HealthCommittee && pProc.IsRequestReport.HasValue && pProc.IsRequestReport.Value)
            //        this.FireHealthCommittee(pProc);
            //    else if (pDef != null && pDef.HealthCommitteeType.Value == OrthesisProsthesisHCType.HealthCommitteeWithThreeSpecialist && pProc.IsRequestReport.HasValue && pProc.IsRequestReport.Value)
            //        this.FireHealthCommitteeWithThreeSpecialist(pProc);
            //}
            //this.UpdateMyPayerAccTrxStatesToMedulaDontSend();
            #endregion PostTransition_Request2RequestAcception
        }

        protected void UndoTransition_Request2RequestAcception(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Request   To State : RequestAcception
            #region UndoTransition_Request2RequestAcception
            NoBackStateBack();
            #endregion UndoTransition_Request2RequestAcception
        }

        protected void PostTransition_TechnicianSelection2Procedure()
        {
            if (OrthesisProsthesisProcedures.Count > 1)
                SplitOrthesisProsthesisProcedures(OrthesisProsthesisRequest.States.Procedure, true);
            else
                setAuthorizedUzer(0);
            //foreach (OrthesisProsthesisProcedure pProc in this.OrthesisProsthesisProcedures)
            //{
            //    OrtesisProsthesisDefinition pDef = pProc.ProcedureObject as OrtesisProsthesisDefinition;
            //    if (pDef != null && pDef.HealthCommitteeType.Value == OrthesisProsthesisHCType.HealthCommittee && pProc.IsRequestReport.HasValue && pProc.IsRequestReport.Value)
            //        this.FireHealthCommittee(pProc);
            //    else if (pDef != null && pDef.HealthCommitteeType.Value == OrthesisProsthesisHCType.HealthCommitteeWithThreeSpecialist && pProc.IsRequestReport.HasValue && pProc.IsRequestReport.Value)
            //        this.FireHealthCommitteeWithThreeSpecialist(pProc);
            //}
            //foreach (AppointmentWithoutResource appointmentWithoutResource in this.AppointmentWithoutResources)
            //{
            //    if (appointmentWithoutResource.CurrentStateDef.Status == StateStatusEnum.Uncompleted)
            //    {
            //        appointmentWithoutResource.CurrentStateDefID = AppointmentWithoutResource.States.Completed;
            //    }
            //}
            UpdateMyPayerAccTrxStatesToMedulaDontSend();
        }

        protected void PostTransition_Request2Cancelled()
        {
            // From State : Request   To State : Cancelled
            #region PostTransition_Request2Cancelled
            Cancel();
            #endregion PostTransition_Request2Cancelled
        }

        protected void PostTransition_ControlApproval2Completed()
        {
            // From State : ControlApproval   To State : Completed
            #region PostTransition_ControlApproval2Completed
            UpdateMyPayerAccTrxStatesToMedulaDontSend();
            #endregion PostTransition_ControlApproval2Completed
        }

        protected void PostTransition_Completed2ControlApproval()
        {
            #region PostTransition_Completed2ControlApproval
            //this.UpdateMyPayerAccTrxStatesToMedulaDontSend();

            //şu an ihtiyaç yok gibi ama gerekirse fatura iptal ile ilgili işlemlerin eklenmesi gerekebilir.
            #endregion PostTransition_Completed2ControlApproval
        }

        protected void PostTransition_ControlApproval2Cancelled()
        {
            // From State : ControlApproval   To State : Cancelled
            #region PostTransition_ControlApproval2Cancelled
            Cancel();
            #endregion PostTransition_ControlApproval2Cancelled
        }

        protected void PostTransition_Appointment2Cancelled()
        {
            // From State : Appointment   To State : Cancelled
            #region PostTransition_Appointment2Cancelled
            Cancel();
            #endregion PostTransition_Appointment2Cancelled
        }

        #region Methods
        public enum RetiredEmployedData : byte
        {
            Retired,
            Employed
        }

        protected override void OnConstruct()
        {
            base.OnConstruct();
            ITTObject pObject = (ITTObject)this;
            if (pObject.IsNew)
            {
            }
        }

        public List<AppointmentCarrier> AppointmentCarrierList
        {
            get
            {
                List<AppointmentCarrier> _appointmentList = new List<AppointmentCarrier>();
                TTObjectContext context = new TTObjectContext(false);
                AppointmentDefinition appDef = null;
                IList appDefList = AppointmentDefinition.GetAppointmentDefinitionByName(context, AppointmentDefinitionEnum.OrthesisProsthesisRequest);
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
                    carrier.MasterResource = "ResPoliclinic";
                    carrier.SubResource = "ResUser";
                    carrier.RelationParentName = "";
                    carrier.UserTypes.Add(UserTypeEnum.Technician);
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
                return ActionTypeEnum.OrthesisProsthesisRequest;
            }
        }

        //public static void FillHospitalsUnitsGridDueToReasonForExamination(OrthesisProsthesisRequest orthesisProsthesisRequest)
        //{
        //    if (orthesisProsthesisRequest.MyReasonForExamination() != null)
        //    {
        //        foreach (HospitalsUnitsDefinitionGrid hospitalsUnitsDefinitionGrid in orthesisProsthesisRequest.MyReasonForExamination().HospitalsUnits)
        //        {
        //            if (orthesisProsthesisRequest.IsHospitalsUnitsAllowedToBeAppended(hospitalsUnitsDefinitionGrid) == true)
        //            {
        //                orthesisProsthesisRequest.AddHospitalsUnits(hospitalsUnitsDefinitionGrid);
        //            }
        //        }
        //    }
        //}
        protected override ReasonForExaminationDefinition MyReasonForExamination()
        {
            return ReasonForExamination;
        }

        //protected override void AddHospitalsUnits(HospitalsUnitsDefinitionGrid hospitalsUnitsDefinitionGrid)
        //{
        //    OrthesisProsthesisHospitalsUnitsGrid hospitalsUnitsGrid = new OrthesisProsthesisHospitalsUnitsGrid(this.ObjectContext);
        //    hospitalsUnitsGrid.Hospital = hospitalsUnitsDefinitionGrid.ExaminationHospital;
        //    hospitalsUnitsGrid.Unit = hospitalsUnitsDefinitionGrid.ExaminationDepartment as ResSection;
        //    this._HospitalsUnits.Add(hospitalsUnitsGrid);
        //}
        protected void FireHealthCommittee()
        {
            foreach (OrthesisProsthesisProcedure orthesisProsthesisProcedure in OrthesisProsthesisProcedures)
            {
                HealthCommittee healthCommittee = new HealthCommittee(orthesisProsthesisProcedure);
                break;
            }
        }

        protected void FireHealthCommittee(OrthesisProsthesisProcedure procedure)
        {
            HealthCommittee healthCommittee = new HealthCommittee(procedure);
        }

        protected void FireHealthCommitteeWithThreeSpecialist()
        {
            foreach (OrthesisProsthesisProcedure orthesisProsthesisProcedure in OrthesisProsthesisProcedures)
            {
                HealthCommitteeWithThreeSpecialist healthCommitteeWithThreeSpecialist = new HealthCommitteeWithThreeSpecialist(orthesisProsthesisProcedure);
                break;
            }
        }

        protected void FireHealthCommitteeWithThreeSpecialist(OrthesisProsthesisProcedure procedure)
        {
            HealthCommitteeWithThreeSpecialist healthCommitteeWithThreeSpecialist = new HealthCommitteeWithThreeSpecialist(procedure);
        }

        private void SplitOrthesisProsthesisProcedures(Guid entryState, bool isInRequest)
        {
            while (OrthesisProsthesisProcedures.Count > 1)
            {
                OrthesisProsthesisRequest theRequest = new OrthesisProsthesisRequest(ObjectContext);
                theRequest.CurrentStateDefID = OrthesisProsthesisRequest.States.TechnicianSelection;
                theRequest.SetMandatoryEpisodeActionProperties(this, MasterResource, FromResource, false);
                theRequest.SubEpisode = SubEpisode;
                theRequest.RequestDate = RequestDate;
                theRequest.ProcedureSpeciality = ProcedureSpeciality;
                theRequest.ProcedureDoctor = ProcedureDoctor;
                theRequest.TotalDescription = TotalDescription;
                theRequest.FinancialDepartmentNot = FinancialDepartmentNot;
                theRequest.ChiefTechnicianNote = ChiefTechnicianNote;
                theRequest.TechnicianNote = TechnicianNote;
                theRequest.Image = Image;
                theRequest.IsInRequest = isInRequest;
                int tempCount = OrthesisProsthesisProcedures.Count - 1;
                theRequest.RequesterUsr = RequesterUsr;
                //if (this.OrthesisProsthesisProcedures[tempCount].Technician != null)
                //{
                //    setAuthorizedUzer(tempCount);
                //}

                OrthesisProsthesisProcedures[tempCount].OrthesisProsthesisRequest = theRequest;
                theRequest.Update();
                theRequest.CurrentStateDefID = entryState;
            }

            if (OrthesisProsthesisProcedures.Count == 1)
            {
                if (OrthesisProsthesisProcedures[0].Technician != null)
                {
                    setAuthorizedUzer(0);
                }
            }
        }

        private void setAuthorizedUzer(int index)
        {
            if (OrthesisProsthesisProcedures[0].Technician != null)
            {
                AuthorizedUser au = new AuthorizedUser(ObjectContext);
                au.User = (ResUser)OrthesisProsthesisProcedures[index].Technician;
                AuthorizedUsers.Add(au);

                OrthesisProsthesisProcedures[0].ProcedureByUser = au.User;
            }
        }

        //public RetiredEmployedData GetIfRetiredOrEmployed()
        //{
        //    PatientAdmission pa = this.SubEpisode.PatientAdmission.insu;
        //    //TODO:HEMŞİRE EMEKLİSİ, HEMŞİRE E AİLESİ, GAZIOHAL, GAZIOHALAILE, VAZIFEMALULU, eklenecek....YY
        //    //sonra geliştirilmeli BB
        //    //            if(pa is PA_RetiredOfficer || pa is PA_RetiredNoncommissionedOfficer ||
        //    //               pa is PA_RetiredExpertNonCom || pa is PA_RetiredMilitaryCivilOfficial || pa is PA_RetiredOfficerFamily ||
        //    //               pa is PA_RetiredNoncommissionedOfficerFamily || pa is PA_RetiredExpertNonComFamily ||
        //    //               pa is PA_RetiredMilitaryCivilOfficialFamily || pa is PA_CivilianConsignment ||
        //    //               pa is PA_PaidCivilian || pa is PA_PatientWithGreenCard || pa is PA_MartyrFamily || pa is PA_RetiredGeneral ||
        //    //               pa is PA_RetiredGeneralFamily || pa is PA_RetiredCivilian)
        //    //                return RetiredEmployedData.Retired;
        //    //            else
        //    return RetiredEmployedData.Employed;
        //}
        private void PrintOrthesisProsthesisReport()
        {
            int nCount = 1;
            foreach (OrthesisProsthesisProcedure theRow in OrthesisProsthesisProcedures)
            {
                if (theRow.IsPrintReport != null && theRow.IsPrintReport.Value)
                {
                    //EMEKLİLER ve SİVİL için 2 nüsha ÇALIŞANLAR(XXXXXX Personel ve yakınları) için 1 nüsha
                    Dictionary<string, TTReportTool.PropertyCache<string>> parameters = new Dictionary<string, TTReportTool.PropertyCache<string>>();
                    TTReportTool.PropertyCache<string> cache = new TTReportTool.PropertyCache<string>();
                    cache.Add("VALUE", ObjectID.ToString());
                    TTReportTool.PropertyCache<string> cache2 = new TTReportTool.PropertyCache<string>();
                    cache2.Add("VALUE", theRow.ObjectID.ToString());
                    parameters.Add("TTOBJECTID", cache);
                    parameters.Add("PROCEDUREID", cache2);
                    //TODO: sonra burası açılacak AfterCommit yapıldığında
                    //TTReportTool.TTReport.PrintReport("OrthesisProsthesisRequestInTransition", true, nCount, parameters);
                }
            }
        }

        public override void Cancel()
        {
            base.Cancel();
            foreach (BaseAction linkAction in LinkedActions)
            {
                if (linkAction.CurrentStateDef.Status == StateStatusEnum.Cancelled)
                    ((ITTObject)linkAction).Cancel();
            }

            MakingDirectPurchaseMaterialsUnUsed();
        }

        public void CancelAccountTransactionsForOrthesisProsthesis()
        {
            foreach (SubActionProcedure subactionProcedure in SubactionProcedures)
            {
                subactionProcedure.CancelMyAccountTransactions();
            }
        }

        // SGK'lı hastaların Ortez-Protez işlemlerinin medulaya gitmemesi istendiği için
        // kurum payı olan AccountTransaction ları "Medulaya Gönderilmeyecek" durumuna alınır
        public void UpdateMyPayerAccTrxStatesToMedulaDontSend()
        {
            if (SubEpisode.IsSGK)
            {
                foreach (SubActionProcedure sp in SubactionProcedures)
                {
                    foreach (AccountTransaction accTrx in sp.AccountTransactions)
                    {
                        if (accTrx.AccountPayableReceivable.Type == APRTypeEnum.PAYER)
                        {
                            if (accTrx.CurrentStateDefID == AccountTransaction.States.New || accTrx.CurrentStateDefID == AccountTransaction.States.ToBeNew)
                            {
                                accTrx.CurrentStateDefID = AccountTransaction.States.MedulaDontSend;
                            }
                        }
                    }
                }
            }
        }

        [TTStorageManager.Attributes.TTRequiredRoles(TTRoleNames.Ortez_Protez_Prosedur_R, TTRoleNames.Ortez_Protez_Prosedur_RU, TTRoleNames.Ortez_Protez_Prosedur_RUW, TTRoleNames.Ortez_Protez_Istek_Kabulu_R, TTRoleNames.Ortez_Protez_Istek_Kabulu_RU, TTRoleNames.Ortez_Protez_Istek_Kabulu_RUW, TTRoleNames.Ortez_Protez_Reddedildi_R, TTRoleNames.Ortez_Protez_Kontrol_Onayi_RW)]
        public static void MakingDirectPurchaseHasUsed(OrthesisProsthesisRequest orthesisProsthesisRequest)
        {
            foreach (SurgeryDirectPurchaseGrid surgeryDirectPurchaseGrid in orthesisProsthesisRequest.OrthesisProsthesisRequest_OPDirectPurchaseGrids)
            {
                surgeryDirectPurchaseGrid.DPADetailFirmPriceOffer.DirectPurchaseActionDetail.HasUsed = true;
            }

            foreach (CodelessMaterialDirectPurchaseGrid codelessMaterialDirectPurchaseGrid in orthesisProsthesisRequest.OPRequest_CodelessMaterialDirectPurchaseGrids)
            {
                codelessMaterialDirectPurchaseGrid.DPADetailFirmPriceOffer.DirectPurchaseActionDetail.HasUsed = true;
            }
        }

        public static void CreateSubActionMatPricingDet(OrthesisProsthesisRequest orthesisProsthesisRequest)
        {
            foreach (SurgeryDirectPurchaseGrid sdg in orthesisProsthesisRequest.OrthesisProsthesisRequest_OPDirectPurchaseGrids)
            {
                SubActionMatPricingDet titubbPrice = new SubActionMatPricingDet(orthesisProsthesisRequest.ObjectContext);
                titubbPrice.PatientPrice = 0;
                titubbPrice.SubActionMaterial = sdg;
                if (sdg.DPADetailFirmPriceOffer != null && sdg.DPADetailFirmPriceOffer.OfferedSUTCode != null)
                {
                    titubbPrice.ExternalCode = sdg.DPADetailFirmPriceOffer.OfferedSUTCode.SUTCode;
                    titubbPrice.Description = sdg.DPADetailFirmPriceOffer.OfferedSUTCode.SUTName;
                    titubbPrice.PayerPrice = sdg.DPADetailFirmPriceOffer.OfferedSUTCode.SUTPrice;
                }

                titubbPrice.ProductDefinition = sdg.DPADetailFirmPriceOffer.OfferedSUTCode.Product;
            }
        }

        public void MakingDirectPurchaseMaterialsUnUsed()
        {
            foreach (SurgeryDirectPurchaseGrid sdg in OrthesisProsthesisRequest_OPDirectPurchaseGrids)
            {
                if (sdg.DPADetailFirmPriceOffer != null && sdg.DPADetailFirmPriceOffer.DirectPurchaseActionDetail != null)
                    sdg.DPADetailFirmPriceOffer.DirectPurchaseActionDetail.HasUsed = false;
            }
        }

        public override void SetMyPropertiesByMasterAction(EpisodeAction episodeAction)
        {
            //this = episodeAction;
            //this.ActionDate = Common.RecTime().Date;
            // this.MasterResource = (ResSection)episodeAction.MasterResource;
            FromResource = (ResSection)episodeAction.MasterResource;
            Episode = (Episode)episodeAction.Episode;
        }

        /// <summary>
        /// Kullanici Doktor ise islemi Yapan Doktor Olarak Atar
        /// </summary>
        public override void SetProcedureDoctorAsCurrentResource()
        {
            if (CurrentStateDef.Status == StateStatusEnum.Uncompleted)
            {
                if (ProcedureDoctor == null && Common.CurrentResource.TakesPerformanceScore == true)
                {
                    IList userResources = UserResource.GetByUserAndResource(ObjectContext, Common.CurrentResource.ObjectID, MasterResource.ObjectID);
                    if (userResources.Count > 0)
                        ProcedureDoctor = Common.CurrentResource;
                }
            }
        }

        #endregion Methods
        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(OrthesisProsthesisRequest).Name)
                return;
            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;
            if (fromState == OrthesisProsthesisRequest.States.DoctorApproval && toState == OrthesisProsthesisRequest.States.Completed)
                PreTransition_DoctorApproval2Completed();
            else if (fromState == OrthesisProsthesisRequest.States.Request && toState == OrthesisProsthesisRequest.States.RequestAcception)
                PreTransition_Request2RequestAcception();
            else if (fromState == OrthesisProsthesisRequest.States.Request && toState == OrthesisProsthesisRequest.States.Pricing)
                PreTransition_Request2Pricing();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(OrthesisProsthesisRequest).Name)
                return;
            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;
            if (fromState == OrthesisProsthesisRequest.States.HealthCommittee && toState == OrthesisProsthesisRequest.States.Rejected)
                PostTransition_HealthCommittee2Rejected();
            else if (fromState == OrthesisProsthesisRequest.States.HealthCommittee && toState == OrthesisProsthesisRequest.States.HealthCommitteeApproval)
                PostTransition_HealthCommittee2HealthCommitteeApproval();
            else if (fromState == OrthesisProsthesisRequest.States.FinancialDepartmentControl && toState == OrthesisProsthesisRequest.States.RequestAcception)
                PostTransition_FinancialDepartmentControl2RequestAcception();
            else if (fromState == OrthesisProsthesisRequest.States.Procedure && toState == OrthesisProsthesisRequest.States.RequestAcception)
                PostTransition_Procedure2RequestAcception();
            else if (fromState == OrthesisProsthesisRequest.States.Procedure && toState == OrthesisProsthesisRequest.States.Cancelled)
                PostTransition_Procedure2Cancelled();
            else if (fromState == OrthesisProsthesisRequest.States.DoctorApproval && toState == OrthesisProsthesisRequest.States.Completed)
                PostTransition_DoctorApproval2Completed();
            else if (fromState == OrthesisProsthesisRequest.States.DoctorApproval && toState == OrthesisProsthesisRequest.States.Cancelled)
                PostTransition_DoctorApproval2Cancelled();
            else if (fromState == OrthesisProsthesisRequest.States.RequestReturn && toState == OrthesisProsthesisRequest.States.Rejected)
                PostTransition_RequestReturn2Rejected();
            else if (fromState == OrthesisProsthesisRequest.States.HealthCommitteeWithThreeSpecialistApproval && toState == OrthesisProsthesisRequest.States.Rejected)
                PostTransition_HealthCommitteeWithThreeSpecialistApproval2Rejected();
            else if (fromState == OrthesisProsthesisRequest.States.HealthCommitteeWithThreeSpecialist && toState == OrthesisProsthesisRequest.States.HealthCommitteeWithThreeSpecialistApproval)
                PostTransition_HealthCommitteeWithThreeSpecialist2HealthCommitteeWithThreeSpecialistApproval();
            else if (fromState == OrthesisProsthesisRequest.States.HealthCommitteeWithThreeSpecialist && toState == OrthesisProsthesisRequest.States.Rejected)
                PostTransition_HealthCommitteeWithThreeSpecialist2Rejected();
            else if (fromState == OrthesisProsthesisRequest.States.RequestAcception && toState == OrthesisProsthesisRequest.States.HealthCommittee)
                PostTransition_RequestAcception2HealthCommittee();
            else if (fromState == OrthesisProsthesisRequest.States.RequestAcception && toState == OrthesisProsthesisRequest.States.RequestReturn)
                PostTransition_RequestAcception2RequestReturn();
            else if (fromState == OrthesisProsthesisRequest.States.RequestAcception && toState == OrthesisProsthesisRequest.States.HealthCommitteeWithThreeSpecialist)
                PostTransition_RequestAcception2HealthCommitteeWithThreeSpecialist();
            else if (fromState == OrthesisProsthesisRequest.States.RequestAcception && toState == OrthesisProsthesisRequest.States.Cancelled)
                PostTransition_RequestAcception2Cancelled();
            else if (fromState == OrthesisProsthesisRequest.States.HealthCommitteeApproval && toState == OrthesisProsthesisRequest.States.Rejected)
                PostTransition_HealthCommitteeApproval2Rejected();
            else if (fromState == OrthesisProsthesisRequest.States.Completed && toState == OrthesisProsthesisRequest.States.Cancelled)
                PostTransition_Completed2Cancelled();
            else if (fromState == OrthesisProsthesisRequest.States.Request && toState == OrthesisProsthesisRequest.States.FinancialDepartmentControl)
                PostTransition_Request2FinancialDepartmentControl();
            else if (fromState == OrthesisProsthesisRequest.States.Request && toState == OrthesisProsthesisRequest.States.RequestAcception)
                PostTransition_Request2RequestAcception();
            else if (fromState == OrthesisProsthesisRequest.States.Request && toState == OrthesisProsthesisRequest.States.Cancelled)
                PostTransition_Request2Cancelled();
            else if (fromState == OrthesisProsthesisRequest.States.ControlApproval && toState == OrthesisProsthesisRequest.States.Completed)
                PostTransition_ControlApproval2Completed();
            else if (fromState == OrthesisProsthesisRequest.States.ControlApproval && toState == OrthesisProsthesisRequest.States.Cancelled)
                PostTransition_ControlApproval2Cancelled();
            else if (fromState == OrthesisProsthesisRequest.States.Appointment && toState == OrthesisProsthesisRequest.States.Cancelled)
                PostTransition_Appointment2Cancelled();
            else if (fromState == OrthesisProsthesisRequest.States.TechnicianSelection && toState == OrthesisProsthesisRequest.States.Procedure)
                PostTransition_TechnicianSelection2Procedure();
            else if (fromState == OrthesisProsthesisRequest.States.Pricing && toState == OrthesisProsthesisRequest.States.Cancelled)
                PostTransition_Pricing2Cancelled();
            else if (fromState == OrthesisProsthesisRequest.States.TechnicianSelection && toState == OrthesisProsthesisRequest.States.Cancelled)
                PostTransition_TechnicianSelection2Cancelled();
            else if (fromState == OrthesisProsthesisRequest.States.Request && toState == OrthesisProsthesisRequest.States.Pricing)
                PostTransition_Request2Pricing();
            else if (fromState == OrthesisProsthesisRequest.States.Pricing && toState == OrthesisProsthesisRequest.States.TechnicianSelection)
                PostTransition_Pricing2TechnicianSelection();
            else if (fromState == OrthesisProsthesisRequest.States.TechnicianSelection && toState == OrthesisProsthesisRequest.States.Pricing)
                PostTransition_TechnicianSelection2Pricing();
            else if (fromState == OrthesisProsthesisRequest.States.Procedure && toState == OrthesisProsthesisRequest.States.Pricing)
                PostTransition_Procedure2Pricing();
            else if (fromState == OrthesisProsthesisRequest.States.Procedure && toState == OrthesisProsthesisRequest.States.ControlApproval)
                PostTransition_Procedure2ControlApproval();
            else if (fromState == OrthesisProsthesisRequest.States.ControlApproval && toState == OrthesisProsthesisRequest.States.Procedure)
                PostTransition_ControlApproval2Procedure();
            else if (fromState == OrthesisProsthesisRequest.States.Completed && toState == OrthesisProsthesisRequest.States.ControlApproval)
                PostTransition_Completed2ControlApproval();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(OrthesisProsthesisRequest).Name)
                return;
            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;
            if (fromState == OrthesisProsthesisRequest.States.HealthCommittee && toState == OrthesisProsthesisRequest.States.Rejected)
                UndoTransition_HealthCommittee2Rejected(transDef);
            else if (fromState == OrthesisProsthesisRequest.States.HealthCommittee && toState == OrthesisProsthesisRequest.States.HealthCommitteeApproval)
                UndoTransition_HealthCommittee2HealthCommitteeApproval(transDef);
            else if (fromState == OrthesisProsthesisRequest.States.Procedure && toState == OrthesisProsthesisRequest.States.ControlApproval)
                UndoTransition_Procedure2ControlApproval(transDef);
            else if (fromState == OrthesisProsthesisRequest.States.Procedure && toState == OrthesisProsthesisRequest.States.Appointment)
                UndoTransition_Procedure2Appointment(transDef);
            else if (fromState == OrthesisProsthesisRequest.States.RequestReturn && toState == OrthesisProsthesisRequest.States.Rejected)
                UndoTransition_RequestReturn2Rejected(transDef);
            else if (fromState == OrthesisProsthesisRequest.States.HealthCommitteeWithThreeSpecialistApproval && toState == OrthesisProsthesisRequest.States.Rejected)
                UndoTransition_HealthCommitteeWithThreeSpecialistApproval2Rejected(transDef);
            else if (fromState == OrthesisProsthesisRequest.States.HealthCommitteeWithThreeSpecialist && toState == OrthesisProsthesisRequest.States.HealthCommitteeWithThreeSpecialistApproval)
                UndoTransition_HealthCommitteeWithThreeSpecialist2HealthCommitteeWithThreeSpecialistApproval(transDef);
            else if (fromState == OrthesisProsthesisRequest.States.HealthCommitteeWithThreeSpecialist && toState == OrthesisProsthesisRequest.States.Rejected)
                UndoTransition_HealthCommitteeWithThreeSpecialist2Rejected(transDef);
            else if (fromState == OrthesisProsthesisRequest.States.RequestAcception && toState == OrthesisProsthesisRequest.States.Appointment)
                UndoTransition_RequestAcception2Appointment(transDef);
            else if (fromState == OrthesisProsthesisRequest.States.HealthCommitteeApproval && toState == OrthesisProsthesisRequest.States.Rejected)
                UndoTransition_HealthCommitteeApproval2Rejected(transDef);
            else if (fromState == OrthesisProsthesisRequest.States.Request && toState == OrthesisProsthesisRequest.States.RequestAcception)
                UndoTransition_Request2RequestAcception(transDef);
        }

        public static ArrayList UnCompletedLinkedActions(OrthesisProsthesisRequest orthesisProsthesisRequest)
        {
            ArrayList unCompletedLinkedActions = new ArrayList();
            foreach (BaseAction action in orthesisProsthesisRequest.LinkedActions)
            {
                if (action.CurrentStateDef.Status == StateStatusEnum.Uncompleted)
                {
                    unCompletedLinkedActions.Add(action);
                }
            }

            return unCompletedLinkedActions;
        }

        //public void AccountingOperation()
        //{
        //    foreach (OrthesisProsthesisProcedure opp in OrthesisProsthesisProcedures)
        //        opp.AccountOperation();
        //}

        public void IsCashierOrInvoiceOpDone()
        {
            if (IsAllowedToCancel() == false)
                throw new TTException(TTUtils.CultureService.GetText("M26642", "Ortez Protez işlemi için hasta ödemesi veya faturalama işlemi yapılmıştır. Ödeme/Faturalama iptal edildikten sonra tekrar deneyiniz."));
        }

        public override void FillLocalSEPProperties(ref SubEpisodeProtocol sep)
        {
            if (sep != null)
            {
                if (sep.IsSGKAll)
                {
                    string sgkOPPayerObjectID = SystemParameter.GetParameterValue("SGKORTHESISPROSTHESISPAYERDEFINITION", "6317ad68-9496-410a-b890-84da68d3f67c");
                    PayerDefinition sgkOPPayer = ObjectContext.GetObject<PayerDefinition>(new Guid(sgkOPPayerObjectID), false);

                    if (sgkOPPayer == null)
                        throw new TTException(TTUtils.CultureService.GetText("M26872", "SGK Ortez Protez kurumu bulunamadı.Sistem parametrelerini kontrol ediniz.(Bknz: SGKORTHESISPROSTHESISPAYERDEFINITION)"));

                    sep.Payer = sgkOPPayer;

                    sep.SEPMaster = null;
                    sep.SetSEPMaster();   // Kurum SGK Ortez Protez kurumu olacağı için yeni SEPMaster oluşmalı ve mevcut SEP lerden ayrılmalı
                }
            }
        }

        public override bool IsNewSubEpisodeNeeded()
        {
            if(SubEpisode.StarterEpisodeAction is OrthesisProsthesisRequest)
            {
                if (SubEpisode.OpenSubEpisodeProtocol != null)
                    return false;
            }

            return true;
        }

        //ortez protez için 101 paketi yollamasın
        public override bool Sent101Package()
        {
            return false;
        }
    }
}