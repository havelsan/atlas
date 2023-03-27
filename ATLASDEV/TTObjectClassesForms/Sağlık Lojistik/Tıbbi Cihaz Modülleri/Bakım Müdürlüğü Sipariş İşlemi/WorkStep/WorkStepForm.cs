
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
    /// Yardımcı Atölye İş İstek
    /// </summary>
    public partial class WorkStepForm : TTForm
    {
        override protected void BindControlEvents()
        {
            tttoolstrip1.ItemClicked += new TTToolStripItemClicked(tttoolstrip1_ItemClicked);
            chkOrderCompleted.CheckedChanged += new TTControlEventDelegate(chkOrderCompleted_CheckedChanged);
            UsedConsumedMaterails.CellValueChanged += new TTGridCellEventDelegate(UsedConsumedMaterails_CellValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            tttoolstrip1.ItemClicked -= new TTToolStripItemClicked(tttoolstrip1_ItemClicked);
            chkOrderCompleted.CheckedChanged -= new TTControlEventDelegate(chkOrderCompleted_CheckedChanged);
            UsedConsumedMaterails.CellValueChanged -= new TTGridCellEventDelegate(UsedConsumedMaterails_CellValueChanged);
            base.UnBindControlEvents();
        }

        private void tttoolstrip1_ItemClicked(ITTToolStripItem item)
        {
#region WorkStepForm_tttoolstrip1_ItemClicked
   Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
            TTReportTool.PropertyCache<object> objectID = new TTReportTool.PropertyCache<object>();
            objectID.Add("VALUE", _WorkStep.ObjectID.ToString());
            parameters.Add("TTOBJECTID", objectID);
            TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_WorkCard), true, 1, parameters);
#endregion WorkStepForm_tttoolstrip1_ItemClicked
        }

        private void chkOrderCompleted_CheckedChanged()
        {
#region WorkStepForm_chkOrderCompleted_CheckedChanged
   this.SetStateButtons((bool)chkOrderCompleted.Value);
#endregion WorkStepForm_chkOrderCompleted_CheckedChanged
        }

        private void UsedConsumedMaterails_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region WorkStepForm_UsedConsumedMaterails_CellValueChanged
   if (UsedConsumedMaterails.CurrentCell.OwningColumn.Name == "Material")
            {
                int CurRow = UsedConsumedMaterails.CurrentCell.RowIndex;
                if (UsedConsumedMaterails.CurrentCell.Value != null)
                {
                    if(_WorkStep.WorkShop.Store != null)
                    {
                        Store workShopstore = (Store)_WorkStep.ObjectContext.GetObject((Guid)_WorkStep.WorkShop.Store.ObjectID,"STORE");
                        UsedConsumedMaterails.Rows[CurRow].Cells["Store"].Value = workShopstore.ObjectID ;
                    }
                    else
                    {
                      throw new TTUtils.TTException(SystemMessage.GetMessage(966));
                    }
                }
            }
#endregion WorkStepForm_UsedConsumedMaterails_CellValueChanged
        }

        protected override void PreScript()
        {
#region WorkStepForm_PreScript
    base.PreScript();
            this.SetStateButtons((bool)chkOrderCompleted.Value);
#endregion WorkStepForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region WorkStepForm_PostScript
    foreach (UsedConsumedMaterail usedMaterial in _WorkStep.UsedConsumedMaterails)
            {
                usedMaterial.CurrentStateDefID = UsedConsumedMaterail.States.New;
            }
#endregion WorkStepForm_PostScript

            }
            
#region WorkStepForm_Methods
        public void DropAllStateButtons()
        {
            this.DropStateButton(WorkStep.States.SupplyOfMaterial );
            this.DropStateButton(WorkStep.States.Completed);
        }

        public void SetStateButtons(bool orderCompleted)
        {
            DropAllStateButtons();
            if (orderCompleted)
            {
                this.AddStateButton(WorkStep.States.Completed);
            }
            else
            {
                this.AddStateButton(WorkStep.States.SupplyOfMaterial);
            }
        }
        
#endregion WorkStepForm_Methods
    }
}