
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
    /// Minör Tıbbı Uygulama İşlemlerinin Gerçekleştirildiği Nesnedir
    /// </summary>
    public  partial class MinorManipulation : Manipulation, IAllocateSpeciality
    {
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

        protected override void PostUpdate()
        {
#region PostUpdate
            base.PostUpdate();
            CheckIfSubEpisodeDiagnosisExists();
#endregion PostUpdate
        }

        protected void PostTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
#region PostTransition_Completed2Cancelled
            
            base.Cancel();

#endregion PostTransition_Completed2Cancelled
        }

        protected void PostTransition_RequestAcception2Completed()
        {
            // From State : RequestAcception   To State : Completed
#region PostTransition_RequestAcception2Completed
            

            SetMySubActionProceduresPerformedDate();
#endregion PostTransition_RequestAcception2Completed
        }

#region Methods
        public override ActionTypeEnum ActionType
        {
            get {
                return ActionTypeEnum.MinorManipulation;
            }
        }
        
        public override void SetMasterResource(Episode episode, bool notSetNull)
        {
            base.SetMasterResource(episode, notSetNull);
            ResUser currentUser = (ResUser)Common.CurrentUser.UserObject;
            if(currentUser.SelectedOutPatientResource != null)
            {
                if(MasterResource ==  null || currentUser.SelectedOutPatientResource.ObjectID != MasterResource.ObjectID)
                {
                    MasterResource = currentUser.SelectedOutPatientResource;
                }
            }
        }
        
#endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(MinorManipulation).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == MinorManipulation.States.Completed && toState == MinorManipulation.States.Cancelled)
                PostTransition_Completed2Cancelled();
            else if (fromState == MinorManipulation.States.RequestAcception && toState == MinorManipulation.States.Completed)
                PostTransition_RequestAcception2Completed();
        }

    }
}