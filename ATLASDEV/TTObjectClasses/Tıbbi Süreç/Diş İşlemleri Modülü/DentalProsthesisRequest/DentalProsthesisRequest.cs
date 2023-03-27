
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
    /// Diş Protez İstek  İşlemlerinin Gerçekleştiği Temel Nesnedir
    /// </summary>
    public partial class DentalProsthesisRequest : BaseDentalEpisodeAction, IAllocateSpeciality, IAppointmentDef, IWorkListEpisodeAction, ICreateSubEpisode
    {
        public partial class OLAP_GetCancelledDentalProsthesisRequest_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetDentalProsthesisRequest_Class : TTReportNqlObject
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

        protected void PostTransition_Request2RequestAcception()
        {
            // From State : Request   To State : RequestAcception
            #region PostTransition_Request2RequestAcception

            SplitWithDepartmentsOfDentalProsthesis();
            #endregion PostTransition_Request2RequestAcception
        }

        protected void UndoTransition_Request2RequestAcception(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Request   To State : RequestAcception
            #region UndoTransition_Request2RequestAcception
            NoBackStateBack();
            #endregion UndoTransition_Request2RequestAcception
        }

        protected void UndoTransition_RequestAcception2Appointment(TTObjectStateTransitionDef transitionDef)
        {
            // From State : RequestAcception   To State : Appointment
            #region UndoTransition_RequestAcception2Appointment
            NoBackStateBack();
            #endregion UndoTransition_RequestAcception2Appointment
        }

        protected void PreTransition_RequestAcception2Procedure()
        {
            // From State : RequestAcception   To State : Procedure
            #region PreTransition_RequestAcception2Procedure
            CreateDentalProsthesis();
            #endregion PreTransition_RequestAcception2Procedure
        }

        protected void UndoTransition_RequestAcception2Procedure(TTObjectStateTransitionDef transitionDef)
        {
            // From State : RequestAcception   To State : Procedure
            #region UndoTransition_RequestAcception2Procedure
            NoBackStateBack();
            #endregion UndoTransition_RequestAcception2Procedure
        }

        protected void PreTransition_Procedure2Completed()
        {
            // From State : Procedure   To State : Completed
            #region PreTransition_Procedure2Completed

            // CheckDentalProsthesisIsCompleted();

            CheckCompleteDentalProsthesis();

            #endregion PreTransition_Procedure2Completed
        }

        protected void PreTransition_Appointment2Procedure()
        {
            // From State : Appointment   To State : Procedure
            #region PreTransition_Appointment2Procedure
            CreateDentalProsthesis();
            #endregion PreTransition_Appointment2Procedure
        }

        protected void UndoTransition_Appointment2Procedure(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Appointment   To State : Procedure
            #region UndoTransition_Appointment2Procedure
            NoBackStateBack();
            #endregion UndoTransition_Appointment2Procedure
        }

        #region Methods

        public List<AppointmentCarrier> AppointmentCarrierList
        {
            get
            {
                List<AppointmentCarrier> _appointmentList = new List<AppointmentCarrier>();
                TTObjectContext context = new TTObjectContext(false);
                AppointmentDefinition appDef = null;
                IList appDefList = AppointmentDefinition.GetAppointmentDefinitionByName(context, AppointmentDefinitionEnum.DentalProsthesisRequest);
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
                    _appointmentList.Add(carrier);
                }

                ClearAppointmentCarrierDynamicFields(_appointmentList);
                foreach (AppointmentCarrier appointmentCarrier in _appointmentList)
                {
                    if (ProcedureSpeciality != null)
                    {
                        string resources = "";
                        foreach (ResourceSpecialityGrid rSpeciality in ProcedureSpeciality.ResourceSpecialities)
                        {
                            if (resources == "")
                            {
                                resources = "'" + rSpeciality.Resource.ObjectID.ToString() + "'";
                            }
                            else
                            {
                                resources = resources + ",'" + rSpeciality.Resource.ObjectID.ToString() + "'";
                            }
                        }
                        appointmentCarrier.MasterResourceFilter = " OBJECTID IN (" + resources + ")";
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

        public override ActionTypeEnum ActionType
        {
            get
            {
                return ActionTypeEnum.DentalProsthesisRequest;
            }
        }

        public override List<int> AllowedMedulaTedaviTipi()
        {
            List<int> typeList = new List<int>();
            typeList.Add(9);//Ağız Protez Tedavisi
            typeList.Add(13);//Diş Tedavisi
            return typeList;
        }
        public DentalProsthesisRequest(TTObjectContext objectContext, EpisodeAction episodeAction, TTObjectClasses.ResSection masterResource) : this(objectContext)
        {
            ActionDate = Common.RecTime();
            MasterAction = episodeAction;
            MasterResource = masterResource;
            FromResource = episodeAction.MasterResource;
            Episode = episodeAction.Episode;
            CurrentStateDefID = DentalProsthesisRequest.States.Request;
            Update();
            //YAPILACAKLAR//Advancestep yapıldığında işlem "RequestAcception" stepine ilerletilecek//YAPILDI
            CurrentStateDefID = DentalProsthesisRequest.States.RequestAcception;
        }
        private void SplitWithDepartmentsOfDentalProsthesis()
        {
            int sPCount = 0;
            ArrayList suggestedProsthesistArray = new ArrayList();
            //Önerilen Proteze girilen her bir satırdaki departmentlar bir ArrayListe doldurulur(bir department yalnız bir kez eklenir)
            foreach (DentalProsthesisRequestSuggestedProsthesis sp in SuggestedProsthesis)
            {
                if (sp.SuggestedProsthesisProcedure != null)
                {
                    if (suggestedProsthesistArray.Contains(sp.Department) == false)
                    {
                        suggestedProsthesistArray.Add(sp.Department);
                    }
                }
            }
            sPCount = suggestedProsthesistArray.Count;
            // Eğer yalnızca bir tip Department var ise yeni DentalProtesisRequest fire edilmesine gerek yok.
            if (sPCount > 1)
            {
                sPCount--;
                //Array lise doldurulan birimlerin her biri için bir diş protez fire edilir .
                for (int k = 0; k <= sPCount; k++)
                {
                    DentalProsthesisRequest dentalProsthesisRequest = new DentalProsthesisRequest(ObjectContext, this, (TTObjectClasses.ResSection)suggestedProsthesistArray[k]);
                    //Önerilen Protezler fire edilen diş proteze atanır.
                    foreach (DentalProsthesisRequestSuggestedProsthesis sp in SuggestedProsthesis)
                    {
                        if (sp.Department == (TTObjectClasses.ResSection)suggestedProsthesistArray[k])
                        {
                            DentalProsthesisRequestSuggestedProsthesis dentalProsthesisRequestSuggestedProsthesis = new DentalProsthesisRequestSuggestedProsthesis(ObjectContext, (DentalProsthesisRequestSuggestedProsthesis)sp);
                            dentalProsthesisRequest.SuggestedProsthesis.Add(dentalProsthesisRequestSuggestedProsthesis);
                        }
                    }
                }
                // Farklı departmanlar içeren DentalProsthesisRequest departmanlarına ayrıldıktan sonra iptal edilir
                Cancel();
            }
        }

        private void CreateDentalProsthesis()
        {
            foreach (DentalProsthesisRequestSuggestedProsthesis dentalProsthesisRequestSuggestedProsthesis in SuggestedProsthesis)
            {
                if (dentalProsthesisRequestSuggestedProsthesis.SuggestedProsthesisProcedure != null)
                {
                    DentalProsthesisProcedure dentalProsthesis = new DentalProsthesisProcedure(ObjectContext, dentalProsthesisRequestSuggestedProsthesis);
                    DentalProsthesis.Add(dentalProsthesis);
                }
            }
        }
        private void CheckDentalProsthesisIsCompleted()
        {
            foreach (DentalProsthesisProcedure dentalProthesis in DentalProsthesis)
            {
                if (dentalProthesis.CurrentStateDef.Status == StateStatusEnum.Uncompleted)
                {
                    throw new TTException(SystemMessage.GetMessage(725));
                }
            }
        }
        private void CheckCompleteDentalProsthesis()
        {
            foreach (DentalProsthesisProcedure dentalProthesis in DentalProsthesis)
            {
                if (dentalProthesis.CurrentStateDefID == DentalProsthesisProcedure.States.ProtesisProcedure)
                {
                    dentalProthesis.CurrentStateDefID = DentalProsthesisProcedure.States.Completed;
                }
                else if (dentalProthesis.CurrentStateDef.Status == StateStatusEnum.Uncompleted)
                {
                    throw new TTException(SystemMessage.GetMessageV2(726, dentalProthesis.CurrentStateDef.DisplayText.ToString()));
                }
            }
        }

        #endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(DentalProsthesisRequest).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == DentalProsthesisRequest.States.RequestAcception && toState == DentalProsthesisRequest.States.Procedure)
                PreTransition_RequestAcception2Procedure();
            else if (fromState == DentalProsthesisRequest.States.Procedure && toState == DentalProsthesisRequest.States.Completed)
                PreTransition_Procedure2Completed();
            else if (fromState == DentalProsthesisRequest.States.Appointment && toState == DentalProsthesisRequest.States.Procedure)
                PreTransition_Appointment2Procedure();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(DentalProsthesisRequest).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == DentalProsthesisRequest.States.Request && toState == DentalProsthesisRequest.States.RequestAcception)
                PostTransition_Request2RequestAcception();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(DentalProsthesisRequest).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == DentalProsthesisRequest.States.Request && toState == DentalProsthesisRequest.States.RequestAcception)
                UndoTransition_Request2RequestAcception(transDef);
            else if (fromState == DentalProsthesisRequest.States.RequestAcception && toState == DentalProsthesisRequest.States.Appointment)
                UndoTransition_RequestAcception2Appointment(transDef);
            else if (fromState == DentalProsthesisRequest.States.RequestAcception && toState == DentalProsthesisRequest.States.Procedure)
                UndoTransition_RequestAcception2Procedure(transDef);
            else if (fromState == DentalProsthesisRequest.States.Appointment && toState == DentalProsthesisRequest.States.Procedure)
                UndoTransition_Appointment2Procedure(transDef);
        }

    }
}