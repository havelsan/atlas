
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
    /// Diyaliz Uygulamaları
    /// </summary>
    public partial class DialysisOrderDetailCancelledForm : SubactionProcedureFlowableForm
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
#region DialysisOrderDetailCancelledForm_PreScript
    base.PreScript();
            
            int index = 0;
            this.tttextboxDescription.Text = string.Empty;
            //TODO:pnlControls!
            //TextBox pDescriptionBox = (TextBox)this.pnlControls.Controls["tttextboxDescription"];
            //pDescriptionBox.ScrollBars= ScrollBars.Vertical;

            if (this._DialysisOrderDetail.GetStateHistory().Count > 1)
            {
                index = this._DialysisOrderDetail.GetStateHistory().Count-1;
                if(this._DialysisOrderDetail.GetStateHistory()[index].IsUndo == true || this._DialysisOrderDetail.CurrentStateDefID != DialysisOrderDetail.States.Execution)
                {
                    this.tttextboxDescription.Text = this.GetFullCompletedAppointmentDescription(this._DialysisOrderDetail);
                }
                else
                {
                    this.tttextboxDescription.Text = this.GetFullAppointmentDescription(this._DialysisOrderDetail);
                }
            }
            else
            {
                this.tttextboxDescription.Text = this.GetFullAppointmentDescription(this._DialysisOrderDetail);
            }
#endregion DialysisOrderDetailCancelledForm_PreScript

            }
                }
}