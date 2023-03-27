
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
    /// Normal Doğum
    /// </summary>
    public partial class RegularObstetric : EpisodeActionWithDiagnosis
    {
        protected void PostTransition_New2Cancelled()
        {
            // From State : New   To State : Cancelled
            #region PostTransition_New2Cancelled

            Cancel();

            #endregion PostTransition_New2Cancelled
        }

        protected void PostTransition_RegularObstetricProcedures2Completed()
        {
            // From State : RegularObstetricProcedures   To State : Completed
            #region PostTransition_RegularObstetricProcedures2Completed


            foreach (var Subactionprocedure in SubactionProcedures)
            {
                if (Subactionprocedure.ProcedureDoctor == null)
                    throw new TTUtils.TTException(SystemMessage.GetMessage(994));//'İşlemi yapan Doktor' alanın boş kalamaz.
            }
            SetMySubActionProceduresPerformedDate();
            #endregion PostTransition_RegularObstetricProcedures2Completed
        }

        protected void PostTransition_RegularObstetricProcedures2Cancelled()
        {
            // From State : RegularObstetricProcedures   To State : Cancelled
            #region PostTransition_RegularObstetricProcedures2Cancelled

            Cancel();


            #endregion PostTransition_RegularObstetricProcedures2Cancelled
        }

        protected void PostTransition_RegularObstetricProcedures2CesareanOperationRequested()
        {
            // From State : RegularObstetricProcedures   To State : CesareanOperationRequested
            #region PostTransition_RegularObstetricProcedures2CesareanOperationRequested

            Cancel();
            MainSurgeryProcedure msp = new MainSurgeryProcedure(ObjectContext);
            msp.ProcedureObject = ObjectContext.GetObject<ProcedureDefinition>(ProcedureDefinition.CesaseanProcedureObjectID);
            msp.Position = SurgeryLeftRight.Left;
            msp.IncisionType = IncisionType.Incision1;
            Surgery cesareanOp = new Surgery(ObjectContext, (EpisodeAction)this);
            cesareanOp.MainSurgeryProcedures.Add(msp);

            #endregion PostTransition_RegularObstetricProcedures2CesareanOperationRequested
        }

        #region Methods

        public RegularObstetric(TTObjectContext objectContext, EpisodeAction _episodeAction)
           : this(objectContext)
        {
            //EpisodeAction _episodeAction = objectContext.GetObject<EpisodeAction>(episodeAction.ObjectID);

            SetMandatoryEpisodeActionProperties(_episodeAction, _episodeAction.MasterResource, true);

            CurrentStateDefID = RegularObstetric.States.New;
            if (_episodeAction.SubEpisode.StarterEpisodeAction != null && _episodeAction.SubEpisode.StarterEpisodeAction.ProcedureDoctor != null)
                ProcedureDoctor = _episodeAction.SubEpisode.StarterEpisodeAction.ProcedureDoctor;
            else if (_episodeAction.ProcedureDoctor != null)
                ProcedureDoctor = _episodeAction.ProcedureDoctor;
        }

        public override ActionTypeEnum ActionType
        {
            get
            {
                return ActionTypeEnum.Obstetrics;
            }
        }

        public override void Cancel()
        {
            base.Cancel();
            foreach (SubActionProcedure subactionProcedure in SubactionProcedures)
            {
                subactionProcedure.Cancel();
            }
        }

        #endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(RegularObstetric).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == RegularObstetric.States.New && toState == RegularObstetric.States.Cancelled)
                PostTransition_New2Cancelled();
            //else if (fromState == States.RegularObstetricProcedures && toState == States.Completed)
            //    PostTransition_RegularObstetricProcedures2Completed();
            //else if (fromState == States.RegularObstetricProcedures && toState == States.Cancelled)
            //    PostTransition_RegularObstetricProcedures2Cancelled();
            //else if (fromState == States.RegularObstetricProcedures && toState == States.CesareanOperationRequested)
            //    PostTransition_RegularObstetricProcedures2CesareanOperationRequested();
        }

    }
}