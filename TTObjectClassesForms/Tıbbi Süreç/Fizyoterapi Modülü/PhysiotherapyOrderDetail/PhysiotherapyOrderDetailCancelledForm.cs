
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
    /// Fizyoterapi Uygulaması
    /// </summary>
    public partial class PhysiotherapyOrderDetailCancelledForm : SubactionProcedureFlowableForm
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
#region PhysiotherapyOrderDetailCancelledForm_PreScript
    base.PreScript();
            
            int index = 0;
            this.tttextboxDescription.Text = string.Empty;
            //TextBox pDescriptionBox = (TextBox)this.pnlControls.Controls["tttextboxDescription"];
            //pDescriptionBox.ScrollBars= ScrollBars.Vertical;
            
            if (this._PhysiotherapyOrderDetail.GetStateHistory().Count > 1)
            {
                index = this._PhysiotherapyOrderDetail.GetStateHistory().Count-1;
                if(this._PhysiotherapyOrderDetail.GetStateHistory()[index].IsUndo == true || this._PhysiotherapyOrderDetail.CurrentStateDefID != PhysiotherapyOrderDetail.States.Execution)
                {
                    this.tttextboxDescription.Text = this.GetFullCompletedAppointmentDescription(this._PhysiotherapyOrderDetail);
                }
                else
                {
                    this.tttextboxDescription.Text = this.GetFullAppointmentDescription(this._PhysiotherapyOrderDetail);
                }
            }
            else
            {
                this.tttextboxDescription.Text = this.GetFullAppointmentDescription(this._PhysiotherapyOrderDetail);
            }
#endregion PhysiotherapyOrderDetailCancelledForm_PreScript

            }
                }
}