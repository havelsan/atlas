
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
    public partial class ArgeProjectNewForm : TTForm
    {
        override protected void BindControlEvents()
        {
            gridOtherCost.RowValidating += new TTGridCellCancelEventDelegate(gridOtherCost_RowValidating);
            gridOtherCost.RowLeave += new TTGridCellEventDelegate(gridOtherCost_RowLeave);
            gridOtherCost.CellValueChanged += new TTGridCellEventDelegate(gridOtherCost_CellValueChanged);
            gridDutyCost.CellValueChanged += new TTGridCellEventDelegate(gridDutyCost_CellValueChanged);
            ReagentCosts.CellValueChanged += new TTGridCellEventDelegate(ReagentCosts_CellValueChanged);
            ExperimentalRepeatCountProjectPreAssement.TextChanged += new TTControlEventDelegate(ExperimentalRepeatCountProjectPreAssement_TextChanged);
            ControllerRepeatCountProjectPreAssement.TextChanged += new TTControlEventDelegate(ControllerRepeatCountProjectPreAssement_TextChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            gridOtherCost.RowValidating -= new TTGridCellCancelEventDelegate(gridOtherCost_RowValidating);
            gridOtherCost.RowLeave -= new TTGridCellEventDelegate(gridOtherCost_RowLeave);
            gridOtherCost.CellValueChanged -= new TTGridCellEventDelegate(gridOtherCost_CellValueChanged);
            gridDutyCost.CellValueChanged -= new TTGridCellEventDelegate(gridDutyCost_CellValueChanged);
            ReagentCosts.CellValueChanged -= new TTGridCellEventDelegate(ReagentCosts_CellValueChanged);
            ExperimentalRepeatCountProjectPreAssement.TextChanged -= new TTControlEventDelegate(ExperimentalRepeatCountProjectPreAssement_TextChanged);
            ControllerRepeatCountProjectPreAssement.TextChanged -= new TTControlEventDelegate(ControllerRepeatCountProjectPreAssement_TextChanged);
            base.UnBindControlEvents();
        }

        private void gridOtherCost_RowValidating(Int32 rowIndex, Int32 columnIndex, CancelEventArgs e)
        {
        }

        private void gridOtherCost_RowLeave(Int32 rowIndex, Int32 columnIndex)
        {
        }

        private void gridOtherCost_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region ArgeProjectNewForm_gridOtherCost_CellValueChanged
   if(columnIndex==2)
            {
                this._ArgeProject.CalcOtherCosts();
                this._ArgeProject.CalcTotalCosts();
                this.TotalOtherCosts.Text = this._ArgeProject.CalcOtherCosts().ToString();
                this.TotalCosts.Text = this._ArgeProject.CalcTotalCosts().ToString();
            }
#endregion ArgeProjectNewForm_gridOtherCost_CellValueChanged
        }

        private void gridDutyCost_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region ArgeProjectNewForm_gridDutyCost_CellValueChanged
   if(columnIndex==3)
            {
                this._ArgeProject.CalcDutyCosts();
                this._ArgeProject.CalcTotalCosts();
                this.TotalDutyCosts.Text = this._ArgeProject.CalcDutyCosts().ToString();
                this.TotalCosts.Text = this._ArgeProject.CalcTotalCosts().ToString();
            }
#endregion ArgeProjectNewForm_gridDutyCost_CellValueChanged
        }

        private void ReagentCosts_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region ArgeProjectNewForm_ReagentCosts_CellValueChanged
   if(columnIndex==6)
            {
                this._ArgeProject.CalcReagentCosts();
                this._ArgeProject.CalcTotalCosts();
                this.TotalReagentCosts.Text = this._ArgeProject.CalcReagentCosts().ToString();
                this.TotalCosts.Text = this._ArgeProject.CalcTotalCosts().ToString();
            }
#endregion ArgeProjectNewForm_ReagentCosts_CellValueChanged
        }

        private void ExperimentalRepeatCountProjectPreAssement_TextChanged()
        {
#region ArgeProjectNewForm_ExperimentalRepeatCountProjectPreAssement_TextChanged
   int experimantalReagentCount = string.IsNullOrEmpty(this.ExperimantalReagentCountProjectPreAssement.Text) ? 1 : Convert.ToInt32(this.ExperimantalReagentCountProjectPreAssement.Text);
            int experimentalRepeatCount = string.IsNullOrEmpty(this.ExperimentalRepeatCountProjectPreAssement.Text) ? 1 : Convert.ToInt32(this.ExperimentalRepeatCountProjectPreAssement.Text);
            this.ExperimentalTotalReagentCountProjectPreAssement.Text = (experimantalReagentCount * experimentalRepeatCount).ToString();
#endregion ArgeProjectNewForm_ExperimentalRepeatCountProjectPreAssement_TextChanged
        }

        private void ControllerRepeatCountProjectPreAssement_TextChanged()
        {
#region ArgeProjectNewForm_ControllerRepeatCountProjectPreAssement_TextChanged
   int controllerReagentCount=string.IsNullOrEmpty(this.ControllerReagentCountProjectPreAssement.Text)?1:Convert.ToInt32(this.ControllerReagentCountProjectPreAssement.Text);
            int controllerRepeatCount = string.IsNullOrEmpty(this.ControllerRepeatCountProjectPreAssement.Text) ? 1 : Convert.ToInt32(this.ControllerRepeatCountProjectPreAssement.Text);
            this.ControllerTotalReagentCountProjectPreAssement.Text = (controllerReagentCount * controllerRepeatCount).ToString();
#endregion ArgeProjectNewForm_ControllerRepeatCountProjectPreAssement_TextChanged
        }

        protected override void PreScript()
        {
#region ArgeProjectNewForm_PreScript
    base.PreScript();
    this.txtProjectStatus.Text = this._ArgeProject.CurrentStateDef.Description;

    this.Participiants.Columns[2].Required = false;
    this.Participiants.Columns[3].Required = false;
        
    if (this._ArgeProject.PreAssesment == null && this._ArgeProject.CurrentStateDefID != null && this._ArgeProject.CurrentStateDefID.Equals(ArgeProject.States.New))
                this._ArgeProject.PreAssesment = new ProjectPreAssement(this._ArgeProject.ObjectContext);
#endregion ArgeProjectNewForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region ArgeProjectNewForm_PostScript
    base.PostScript(transDef);
#endregion ArgeProjectNewForm_PostScript

            }
                }
}