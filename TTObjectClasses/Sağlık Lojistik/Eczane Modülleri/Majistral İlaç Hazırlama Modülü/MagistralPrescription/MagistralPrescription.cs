
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
    /// Eczacılık Bilimleri İstek
    /// </summary>
    public  partial class MagistralPrescription : EpisodeAction, IWorkListEpisodeAction
    {
        protected void PostTransition_Approval2Completed()
        {
            // From State : Approval   To State : Completed
#region PostTransition_Approval2Completed
            
            foreach (DrugOrderDetail drugOrderDetail in DrugOrder.DrugOrderDetails)
            {
                drugOrderDetail.CurrentStateDefID = DrugOrderDetail.States.Supply;
            }

#endregion PostTransition_Approval2Completed
        }

#region Methods
        public override ActionTypeEnum ActionType
        {
            get 
            {
                return ActionTypeEnum.MagistralPreparationPrescription;
            }
        }
        
#endregion Methods

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(MagistralPrescription).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == MagistralPrescription.States.Approval && toState == MagistralPrescription.States.Completed)
                PostTransition_Approval2Completed();
        }

    }
}