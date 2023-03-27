
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
    /// Akıbet Raporu
    /// </summary>
    public  partial class SituationReport : EpisodeAction, IWorkListEpisodeAction
    {
        protected void UndoTransition_ConstitutionofSituationReport2Completed(TTObjectStateTransitionDef transitionDef)
        {
            // From State : ConstitutionofSituationReport   To State : Completed
#region UndoTransition_ConstitutionofSituationReport2Completed
            
            NoBackStateBack();
#endregion UndoTransition_ConstitutionofSituationReport2Completed
        }

#region Methods
        public override ActionTypeEnum ActionType
        {
            get
            {
                return ActionTypeEnum.SituationReport;
            }
        }

        protected override void BeforeSetSubEpisode(SubEpisode subEpisode)
        {
            base.BeforeSetSubEpisode(subEpisode);

            foreach (EpisodeAction pEAction in subEpisode.Episode.EpisodeActions)
            {
                if(pEAction is HealthCommittee && !pEAction.IsCancelled)
                {
                    //bulunan ilk sağlık kurulunu getir
                    //TODO:Burası sonra düzeltilmeli, ilk SK değil de ilgili SK olmalı...YY
                    HealthCommitteeAction = (HealthCommittee)pEAction;
                    break;
                }
            }
        }
        
#endregion Methods

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(SituationReport).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == SituationReport.States.ConstitutionofSituationReport && toState == SituationReport.States.Completed)
                UndoTransition_ConstitutionofSituationReport2Completed(transDef);
        }

    }
}