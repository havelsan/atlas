
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
    /// Diş Tedavi İstek
    /// </summary>
    public partial class DentalTreatmentRequest : BaseDentalEpisodeAction, IAppointmentDef, IWorkListEpisodeAction, IAllocateSpeciality, ICreateSubEpisode
    {
        public partial class OLAP_GetCancelledDentalTreatmentResuest_Class : TTReportNqlObject
        {
        }

        public partial class OLAP_GetDentalTreatmentResuest_Class : TTReportNqlObject
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

        protected void PreTransition_Appointment2Treatment()
        {
            // From State : Appointment   To State : Treatment
            #region PreTransition_Appointment2Treatment
            CreateDentalTreatments();
            #endregion PreTransition_Appointment2Treatment
        }

        protected void UndoTransition_Appointment2Treatment(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Appointment   To State : Treatment
            #region UndoTransition_Appointment2Treatment
            NoBackStateBack();
            #endregion UndoTransition_Appointment2Treatment
        }

        protected void UndoTransition_RequestAcception2Appointment(TTObjectStateTransitionDef transitionDef)
        {
            // From State : RequestAcception   To State : Appointment
            #region UndoTransition_RequestAcception2Appointment
            NoBackStateBack();
            #endregion UndoTransition_RequestAcception2Appointment
        }

        protected void PreTransition_RequestAcception2Treatment()
        {
            // From State : RequestAcception   To State : Treatment
            #region PreTransition_RequestAcception2Treatment

            CreateDentalTreatments();
            #endregion PreTransition_RequestAcception2Treatment
        }

        protected void UndoTransition_RequestAcception2Treatment(TTObjectStateTransitionDef transitionDef)
        {
            // From State : RequestAcception   To State : Treatment
            #region UndoTransition_RequestAcception2Treatment
            NoBackStateBack();
            #endregion UndoTransition_RequestAcception2Treatment
        }

        protected void PreTransition_Treatment2Completed()
        {
            // From State : Treatment   To State : Completed
            #region PreTransition_Treatment2Completed

            CheckDentalTreatmentIsCompleted();
            #endregion PreTransition_Treatment2Completed
        }

        protected void PostTransition_Request2RequestAcception()
        {
            // From State : Request   To State : RequestAcception
            #region PostTransition_Request2RequestAcception

            SplitWithDepartmentsOfDentalTreatments();
            #endregion PostTransition_Request2RequestAcception
        }

        protected void UndoTransition_Request2RequestAcception(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Request   To State : RequestAcception
            #region UndoTransition_Request2RequestAcception
            NoBackStateBack();
            #endregion UndoTransition_Request2RequestAcception
        }

        #region Methods

        public List<AppointmentCarrier> AppointmentCarrierList
        {
            get
            {
                List<AppointmentCarrier> _appointmentList = new List<AppointmentCarrier>();
                TTObjectContext context = new TTObjectContext(false);
                AppointmentDefinition appDef = null;
                IList appDefList = AppointmentDefinition.GetAppointmentDefinitionByName(context, AppointmentDefinitionEnum.DentalTreatmentRequest);
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
                return ActionTypeEnum.DentalTreatmentRequest;
            }
        }
        public DentalTreatmentRequest(TTObjectContext objectContext, EpisodeAction episodeAction, TTObjectClasses.ResSection masterResource)
            : this(objectContext)
        {
            ActionDate = Common.RecTime();
            MasterAction = episodeAction;
            MasterResource = masterResource;
            FromResource = episodeAction.MasterResource;
            Episode = episodeAction.Episode;
            CurrentStateDefID = DentalTreatmentRequest.States.Request;
            Update();
            CurrentStateDefID = DentalTreatmentRequest.States.RequestAcception;
        }
        private void SplitWithDepartmentsOfDentalTreatments()
        {
            int sTCount = 0;
            ArrayList suggestedTreatmentArray = new ArrayList();
            //SuggestedTreatmentsa girilen her bir satırdaki departmentlar bir ArrayListe doldurulur(bir departement yalnızbir kez eklenir)
            foreach (DentalTreatmentRequestSuggestedTreatment st in SuggestedTreatments)
            {
                if (st.SuggestedTreatmentProcedure != null)
                {
                    if (suggestedTreatmentArray.Contains(st.Department) == false)
                    {
                        suggestedTreatmentArray.Add(st.Department);
                    }
                }
            }
            sTCount = suggestedTreatmentArray.Count;
            // Eğer yalnızca bir tip Department var ise yeni DentalTreatmentRequest fire edilmesine gerek yok.
            if (sTCount > 1)
            {
                sTCount--;
                //Array lise doldurulan birimlerin her biri için bir diş tedavi fire edilir içinde dönülür.
                for (int k = 0; k <= sTCount; k++)
                {
                    DentalTreatmentRequest dentalTreatmentRequest = new DentalTreatmentRequest(ObjectContext, this, (TTObjectClasses.ResSection)suggestedTreatmentArray[k]);
                    //Tedavi Önerileri fire edilen diş tedaviye atanır.
                    foreach (DentalTreatmentRequestSuggestedTreatment st in SuggestedTreatments)
                    {
                        if (st.Department == (TTObjectClasses.ResSection)suggestedTreatmentArray[k])
                        {
                            DentalTreatmentRequestSuggestedTreatment dentalTreatmentRequestSuggestedTreatment = new DentalTreatmentRequestSuggestedTreatment(ObjectContext, (DentalTreatmentRequestSuggestedTreatment)st);
                            dentalTreatmentRequest.SuggestedTreatments.Add(dentalTreatmentRequestSuggestedTreatment);
                        }
                    }
                }
                Cancel();
            }
        }

        private void CreateDentalTreatments()
        {
            foreach (DentalTreatmentRequestSuggestedTreatment dentalTreatmentRequestSuggestedTreatment in SuggestedTreatments)
            {
                if (dentalTreatmentRequestSuggestedTreatment.SuggestedTreatmentProcedure != null)
                {

                    if (dentalTreatmentRequestSuggestedTreatment.CurrentStateDefID != DentalExaminationSuggestedTreatment.States.Cancelled)
                    {
                        DentalTreatmentProcedure dentalTreatment = new DentalTreatmentProcedure(ObjectContext, dentalTreatmentRequestSuggestedTreatment);
                        DentalTreatments.Add(dentalTreatment);
                    }
                }
            }
        }
        private void CheckDentalTreatmentIsCompleted()
        {
            foreach (DentalTreatmentProcedure dentalTreatment in DentalTreatments)
            {
                //YAPILACAKLAR//Buraya Cancelled da eklenmeli
                if (dentalTreatment.CurrentStateDef.Status == StateStatusEnum.Uncompleted)
                {
                    throw new TTException(SystemMessage.GetMessage(1190));
                }
            }
        }

        public override List<int> AllowedMedulaTedaviTipi()
        {
            List<int> typeList = new List<int>();
            typeList.Add(9);//Ağız Protez Tedavisi
            typeList.Add(13);//Diş Tedavisi
            return typeList;
        }

        #endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(DentalTreatmentRequest).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == DentalTreatmentRequest.States.Appointment && toState == DentalTreatmentRequest.States.Treatment)
                PreTransition_Appointment2Treatment();
            else if (fromState == DentalTreatmentRequest.States.RequestAcception && toState == DentalTreatmentRequest.States.Treatment)
                PreTransition_RequestAcception2Treatment();
            else if (fromState == DentalTreatmentRequest.States.Treatment && toState == DentalTreatmentRequest.States.Completed)
                PreTransition_Treatment2Completed();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(DentalTreatmentRequest).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == DentalTreatmentRequest.States.Request && toState == DentalTreatmentRequest.States.RequestAcception)
                PostTransition_Request2RequestAcception();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(DentalTreatmentRequest).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == DentalTreatmentRequest.States.Appointment && toState == DentalTreatmentRequest.States.Treatment)
                UndoTransition_Appointment2Treatment(transDef);
            else if (fromState == DentalTreatmentRequest.States.RequestAcception && toState == DentalTreatmentRequest.States.Appointment)
                UndoTransition_RequestAcception2Appointment(transDef);
            else if (fromState == DentalTreatmentRequest.States.RequestAcception && toState == DentalTreatmentRequest.States.Treatment)
                UndoTransition_RequestAcception2Treatment(transDef);
            else if (fromState == DentalTreatmentRequest.States.Request && toState == DentalTreatmentRequest.States.RequestAcception)
                UndoTransition_Request2RequestAcception(transDef);
        }

    }
}