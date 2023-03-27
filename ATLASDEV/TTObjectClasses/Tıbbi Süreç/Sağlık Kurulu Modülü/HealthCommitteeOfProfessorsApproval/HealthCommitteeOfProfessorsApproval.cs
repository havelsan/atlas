
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
    /// Profesörler Sağlık Kurulu Onay İşlemi
    /// </summary>
    public  partial class HealthCommitteeOfProfessorsApproval : BaseHealthCommitteeExamination, IWorkListEpisodeAction
    {
        protected void UndoTransition_Request2Approval(TTObjectStateTransitionDef transitionDef)
        {
            // From State : Request   To State : Approval
#region UndoTransition_Request2Approval
            
            NoBackStateBack();
#endregion UndoTransition_Request2Approval
        }

        protected void PostTransition_Approval2HCPSecretary()
        {
            // From State : Approval   To State : HCPSecretary
#region PostTransition_Approval2HCPSecretary
            //this.ReturnDescriptionInput();//Kaldırılmalı...YY
#endregion PostTransition_Approval2HCPSecretary
        }

#region Methods
        public HealthCommitteeOfProfessorsApproval(EpisodeAction masterAction, HospitalsUnitsGrid hospitalsUnits):this(masterAction.ObjectContext)
        {
            CurrentStateDefID = HealthCommitteeOfProfessorsApproval.States.Request;                        
            SetMandatoryEpisodeActionProperties(masterAction, (ResSection)hospitalsUnits.Unit, true);
        }
        
        public override ActionTypeEnum ActionType
        {
            get
            {
                return ActionTypeEnum.HealthCommitteeOfProfessorsApproval;
            }
        }

        protected override void BeforeSetSubEpisode(SubEpisode subEpisode)
        {
            base.BeforeSetSubEpisode(subEpisode);
            ArrayList healthCommitteeActionList = new ArrayList();
            foreach(EpisodeAction episodeAction in subEpisode.Episode.EpisodeActions){
                if(episodeAction is HealthCommitteeOfProfessors && episodeAction.CurrentStateDef.Status != StateStatusEnum.Cancelled)
                {
                    HealthCommitteeOfProfessors healthCommitteeEA= (HealthCommitteeOfProfessors) episodeAction;
                    //if(healthCommitteeEA.CurrentStateDefID == HealthCommitteeOfProfessors.States.Request)
                    //{
                        healthCommitteeActionList.Add(healthCommitteeEA);
                    //}
                }
            }
            
            if(healthCommitteeActionList.Count == 0)
            {
                throw new TTException(SystemMessage.GetMessage(709));
            }
            else
            {
                if(healthCommitteeActionList.Count >= 1)
                {
                    foreach(HealthCommitteeOfProfessors healthCommittee in healthCommitteeActionList)
                    {
                        HCPApprovalAction =  healthCommittee;
                    }
                }
            }
        }
        
#endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(HealthCommitteeOfProfessorsApproval).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == HealthCommitteeOfProfessorsApproval.States.Approval && toState == HealthCommitteeOfProfessorsApproval.States.HCPSecretary)
                PostTransition_Approval2HCPSecretary();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(HealthCommitteeOfProfessorsApproval).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == HealthCommitteeOfProfessorsApproval.States.Request && toState == HealthCommitteeOfProfessorsApproval.States.Approval)
                UndoTransition_Request2Approval(transDef);
        }

    }
}