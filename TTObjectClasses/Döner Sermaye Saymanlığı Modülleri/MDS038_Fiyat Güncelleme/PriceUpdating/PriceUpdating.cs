
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
    /// Fiyat Güncelleme
    /// </summary>
    public  partial class PriceUpdating : AccountAction, IWorkListBaseAction
    {
        protected void PostTransition_New2Completed()
        {
            // From State : New   To State : Completed
#region PostTransition_New2Completed
            
            /*
            foreach(PriceUpdatingSubActionProcedure subActProc in this._PriceUpdatingProcedures)
            {
                if(subActProc.UpdateProcedurePrice == true)
                    subActProc.SubActionProcedure.ChangeMyPriceList(subActProc.EpisodeProtocol,this.PricingList);
            }
            
            foreach(PriceUpdatingSubActionMaterial subActMat in this._PriceUpdatingMaterials)
            {
                if(subActMat.UpdateMaterialPrice == true)
                    subActMat.SubActionMaterial.ChangeMyPriceList(subActMat.EpisodeProtocol,this.PricingList);
            }
            */

#endregion PostTransition_New2Completed
        }

        protected void UndoTransition_New2Completed(TTObjectStateTransitionDef transitionDef)
        {
            // From State : New   To State : Completed
#region UndoTransition_New2Completed
            NoBackStateBack();
#endregion UndoTransition_New2Completed
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(PriceUpdating).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == PriceUpdating.States.New && toState == PriceUpdating.States.Completed)
                PostTransition_New2Completed();
        }

        protected void UndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(PriceUpdating).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == PriceUpdating.States.New && toState == PriceUpdating.States.Completed)
                UndoTransition_New2Completed(transDef);
        }

    }
}