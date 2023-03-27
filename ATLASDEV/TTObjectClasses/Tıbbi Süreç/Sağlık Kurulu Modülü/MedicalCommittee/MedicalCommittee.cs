
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
    /// Tıbbi Kurul İşlemlerinin Gerçekleştirildiği Temel Nesnedir
    /// </summary>
    public partial class MedicalCommittee : EpisodeActionWithDiagnosis, IAppointmentDef, IWorkListEpisodeAction
    {
        public partial class GetCurrentMedicalCommittee_Class : TTReportNqlObject
        {
        }

        protected void PostTransition_Acceptance2Committee()
        {
            // From State : Acceptance   To State : Committee
            #region PostTransition_Acceptance2Committee

            IList<ResUser> users = new List<ResUser>();
            foreach (MedicalCommitteeMemberOfMedicalCommitteeGrid pGrid in MemberOfMedicalCommittee)
                users.Add(pGrid.Doctor);

            string subject = TTUtils.CultureService.GetText("M27101", "Tıbbi Kurul");
            string body = MeetingTime.Value.Date.ToString("dd/MM/yyyy") + " tarihinde " + MeetingTime.Value.Hour.ToString() + ":" + MeetingTime.Value.Minute.ToString() + " saatinde " + MeetingRoom + "' de Tıbbi Kurul toplantısı yapılacaktır.";
            UserMessage.SendMessageV2(ObjectContext, users, subject, body, true);
            #endregion PostTransition_Acceptance2Committee
        }

        #region Methods

        public List<AppointmentCarrier> AppointmentCarrierList
        {
            get
            {
                List<AppointmentCarrier> _appointmentList = new List<AppointmentCarrier>();
                TTObjectContext context = new TTObjectContext(false);
                AppointmentDefinition appDef = null;
                IList appDefList = AppointmentDefinition.GetAppointmentDefinitionByName(context, AppointmentDefinitionEnum.MedicalCommittee);
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
                return ActionTypeEnum.MedicalCommittee;
            }
        }

        #endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(MedicalCommittee).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == MedicalCommittee.States.Acceptance && toState == MedicalCommittee.States.Committee)
                PostTransition_Acceptance2Committee();
        }

    }
}