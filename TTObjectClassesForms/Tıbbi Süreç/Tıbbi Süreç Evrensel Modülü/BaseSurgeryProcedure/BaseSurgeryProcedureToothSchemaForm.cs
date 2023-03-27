
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
    public partial class BaseSurgeryProcedureToothSchema : TTForm
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
#region BaseSurgeryProcedureToothSchema_PreScript
    base.PreScript();
            // TODO pnlButtons!
            //this.cmdCancel.Visible = false;
            GetToothNumbers();
#endregion BaseSurgeryProcedureToothSchema_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region BaseSurgeryProcedureToothSchema_PostScript
    base.PostScript(transDef);
            SetToothNumbers();
#endregion BaseSurgeryProcedureToothSchema_PostScript

            }
            
#region BaseSurgeryProcedureToothSchema_Methods
        public List<string> ToothNumbersList = new List<string>();

        private void GetToothNumbers()
        {
            BaseSurgeryProcedure surgeryProcedure = this._ttObject as BaseSurgeryProcedure;
            if(surgeryProcedure != null && !string.IsNullOrEmpty(surgeryProcedure.ToothNumber))
            {
                string[] toothNumbers = surgeryProcedure.ToothNumber.Split(',');
                foreach (string toothNumber in toothNumbers)
                {
                    Control control = Controls.Find("ch" + toothNumber, true)[0];
                    if (control.GetType().Equals(typeof(TTCheckBox)))
                    {
                        TTCheckBox chkbox = (TTCheckBox)control;
                        if (chkbox != null)
                            chkbox.Checked = true;
                    }
                }
            }
        }

        private void SetToothNumbers()
        {
            BaseSurgeryProcedure surgeryProcedure = this._ttObject as BaseSurgeryProcedure;
            if (surgeryProcedure != null)
            {
                string toothNumbers = string.Empty;
                FillToothNumbersList(Controls);

                foreach (string toothNumber in ToothNumbersList)
                    toothNumbers += toothNumber + ",";

                if (!string.IsNullOrEmpty(toothNumbers))
                    surgeryProcedure.ToothNumber = toothNumbers.Substring(0, toothNumbers.Length - 1);
                else
                    surgeryProcedure.ToothNumber = string.Empty;
            }
        }

        private void FillToothNumbersList(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control.HasChildren)
                    FillToothNumbersList(control.Controls);

                if (control.GetType().Equals(typeof(TTCheckBox)) && control.Name.StartsWith("ch") && ((TTCheckBox)control).Checked)
                {
                    TTCheckBox chkbox = (TTCheckBox)control;
                    ToothNumbersList.Add(chkbox.Name.Substring(2, chkbox.Name.Length - 2));
                }
            }
        }
        
#endregion BaseSurgeryProcedureToothSchema_Methods
    }
}