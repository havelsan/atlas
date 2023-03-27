
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
    /// İlaç Doz Bitirme
    /// </summary>
    public  partial class DrugDoseCompletion : EpisodeAction
    {
        protected void PostTransition_New2Completed()
        {
            // From State : New   To State : Completed
#region PostTransition_New2Completed
            


            DrugDoseCompletion drugDoseCompletion = this;
            TTObjectContext readonlyContext = new TTObjectContext(true);
            foreach (DrugDoseCompletionDetail drugDoseCompletionDetail in drugDoseCompletion.DrugDoseCompletionDetails)
            {
                if (drugDoseCompletionDetail.DrugDone == true)
                {
                    bool completed = false;
                    IList drugOrderDetails = readonlyContext.QueryObjects("DRUGORDERDETAIL", "MATERIAL = " + ConnectionManager.GuidToString(drugDoseCompletionDetail.Material.ObjectID) + " AND EPISODE =" + ConnectionManager.GuidToString(Episode.ObjectID));
                    foreach (DrugOrderDetail detail in drugOrderDetails)
                    {
                        if (detail.CurrentStateDefID != DrugOrderDetail.States.Apply && detail.CurrentStateDefID != DrugOrderDetail.States.Request && detail.CurrentStateDefID != DrugOrderDetail.States.Cancel)
                        {
                            completed = true;
                        }
                    }
                    if (completed)
                    {
                        DrugOrderTransaction drugOrderTransaction = new DrugOrderTransaction(drugDoseCompletion.ObjectContext);
                        drugOrderTransaction.Amount = drugDoseCompletionDetail.Amount;
                        drugOrderTransaction.DrugOrder = drugDoseCompletionDetail.DrugOrder;
                        /*drugOrderTransaction.DrugOrderDetail = drugDoseCompletionDetail;
                        drugOrderTransaction.InOut = 2;
                        drugOrderTransaction.Volume = drugDoseCompletionDetail.Amount;*/
                        drugDoseCompletionDetail.CurrentStateDefID = DrugDoseCompletionDetail.States.Apply;
                    }
                    else
                    {
                        throw new Exception(SystemMessage.GetMessageV2(977, drugDoseCompletionDetail.Material.Name.ToString()));
                        //drugDoseCompletionDetail.CurrentStateDefID = DrugDoseCompletionDetail.States.Cancel;
                    }
                }
            }


#endregion PostTransition_New2Completed
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(DrugDoseCompletion).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == DrugDoseCompletion.States.New && toState == DrugDoseCompletion.States.Completed)
                PostTransition_New2Completed();
        }

    }
}