
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
    public  partial class CreatePresDetailAction : BaseAction, IWorkListBaseAction
    {
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        override protected void RunSetMemberValueScript(string memberName, object newValue)
        {
            switch (memberName)
            {
                case "MATERIAL":
                    {
                        Material value = (Material)newValue;
#region MATERIAL_SetParentScript
                        Amount = 0;
                        Amount = ((Currency)value.StockInheld((Store)MainStoreDefinition));
#endregion MATERIAL_SetParentScript
                    }
                    break;

                default:
                    base.RunSetMemberValueScript(memberName, newValue);
                    break;

            }
        }

        protected void PreTransition_New2Completed()
        {
            // From State : New   To State : Completed
#region PreTransition_New2Completed
            

            if ((int)Amount != PresActionDetails.Count)
                throw new TTException(TTUtils.CultureService.GetText("M25506", "Doğru sayıda detay girmediniz. Malzeme Mevcudu :")+ Amount.ToString() + TTUtils.CultureService.GetText("M25062", "\r\nGirilen Detay :")+ PresActionDetails.Count.ToString());

#endregion PreTransition_New2Completed
        }

        protected void PostTransition_New2Completed()
        {
            // From State : New   To State : Completed
#region PostTransition_New2Completed
            
            
            IList stocks =  ObjectContext.QueryObjects("STOCK","MATERIAL = " + ConnectionManager.GuidToString(Material.ObjectID) + "AND STORE = " + ConnectionManager.GuidToString(MainStoreDefinition.ObjectID));
            if (stocks.Count > 0)
            {
                Stock stock = ((Stock)stocks[0]);
                if ((int)stock.Inheld != PresActionDetails.Count)
                    throw new TTException(TTUtils.CultureService.GetText("M25506", "Doğru sayıda detay girmediniz. Malzeme Mevcudu :")+ stock.Inheld + TTUtils.CultureService.GetText("M25062", "\r\nGirilen Detay :")+ PresActionDetails.Count.ToString());
                
                foreach (PresActionDetail presActionDetail in PresActionDetails)
                {
                    PrescriptionPaper prescriptionPaper = new PrescriptionPaper(ObjectContext);
                    prescriptionPaper.SerialNo = presActionDetail.SerialNo;
                    prescriptionPaper.VolumeNo = presActionDetail.VolumeNo;
                    prescriptionPaper.Stock = stock;
                    prescriptionPaper.CurrentStateDefID = PrescriptionPaper.States.Usable;
                }
            }
            

#endregion PostTransition_New2Completed
        }

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(CreatePresDetailAction).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == CreatePresDetailAction.States.New && toState == CreatePresDetailAction.States.Completed)
                PreTransition_New2Completed();
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(CreatePresDetailAction).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == CreatePresDetailAction.States.New && toState == CreatePresDetailAction.States.Completed)
                PostTransition_New2Completed();
        }

    }
}