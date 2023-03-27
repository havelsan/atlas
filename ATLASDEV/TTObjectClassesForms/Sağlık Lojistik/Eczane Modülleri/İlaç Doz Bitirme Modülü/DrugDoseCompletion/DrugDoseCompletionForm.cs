
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

using SmartCardWrapper;

using TTStorageManager;
using System.Runtime.Versioning;
using System.Windows.Forms;
using TTVisual;
namespace TTFormClasses
{
    /// <summary>
    /// İlaç Doz Bitirme
    /// </summary>
    public partial class DrugDoseCompletionForm : TTForm
    {
        override protected void BindControlEvents()
        {
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
        }

        protected override void PreScript()
        {
#region DrugDoseCompletionForm_PreScript
    base.PreScript();

            DrugDoseCompletion drugDoseCompletion = _DrugDoseCompletion;
            BindingList<DrugOrderTransaction.GetDrugOrderTransactionByEpisodeRQ_Class> myDrugOrderTransaction = DrugOrderTransaction.GetDrugOrderTransactionByEpisodeRQ(_DrugDoseCompletion.Episode.ObjectID);

            //IList myDrugOrderTransactions = drugDoseCompletion.ObjectContext.QueryObjects("DRUGORDERTRANSACTION", "DRUGORDER.EPISODE.OBJECTID = '" + _DrugDoseCompletion.Episode.ObjectID.ToString() + "' AND INOUT = 1");

            foreach (DrugOrderTransaction.GetDrugOrderTransactionByEpisodeRQ_Class drugOrderTransaction in myDrugOrderTransaction)
            {
                cmdOK.Visible = false;
                DrugDefinition drugDefinition = (DrugDefinition)_DrugDoseCompletion.ObjectContext.GetObject((Guid)drugOrderTransaction.Drugdefinition, "DRUGDEFINITION");
                bool drugType = DrugOrder.GetDrugUsedType(drugDefinition);
                if (!drugType)
                {
                    double restDose = 0;
                    DrugOrder order = (DrugOrder)_DrugDoseCompletion.ObjectContext.GetObject((Guid)drugOrderTransaction.Drugorder, "DRUGORDER");
                    restDose = DrugOrderTransaction.GetRestDose(order);
                    if (restDose > 0)
                    {
                        DrugOrder drugOrder = order;
                        DrugDoseCompletionDetail drugDoseCompletionDetail = new DrugDoseCompletionDetail(drugDoseCompletion.ObjectContext);
                        drugDoseCompletionDetail.Amount = restDose;
                        drugDoseCompletionDetail.Day = drugOrder.Day;
                        drugDoseCompletionDetail.DoseAmount = drugOrder.DoseAmount;
                        drugDoseCompletionDetail.DrugOrder = drugOrder;
                        drugDoseCompletionDetail.Episode = drugOrder.Episode;
                        drugDoseCompletionDetail.Frequency = drugOrder.Frequency;
                        drugDoseCompletionDetail.FromResource = drugOrder.FromResource;
                        drugDoseCompletionDetail.Material = drugOrder.Material;
                        drugDoseCompletionDetail.UsageNote = drugOrder.UsageNote;
                        drugDoseCompletionDetail.DrugDoseCompletion = drugDoseCompletion;
                        drugDoseCompletionDetail.CurrentStateDefID = DrugDoseCompletionDetail.States.Planned;
                        drugDoseCompletionDetail.Update();
                        drugDoseCompletionDetail.CurrentStateDefID = DrugDoseCompletionDetail.States.UseRestDose;
                    }
                }
            }
#endregion DrugDoseCompletionForm_PreScript

            }
                }
}