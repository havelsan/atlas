
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
    public partial class DiagnosisActionSuggestionForm : TerminologyManagerDefForm
    {
        override protected void BindControlEvents()
        {
            ProcedureDefinition.SelectedObjectChanged += new TTControlEventDelegate(ProcedureDefinition_SelectedObjectChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ProcedureDefinition.SelectedObjectChanged -= new TTControlEventDelegate(ProcedureDefinition_SelectedObjectChanged);
            base.UnBindControlEvents();
        }

        private void ProcedureDefinition_SelectedObjectChanged()
        {
            var procedureDefinition = this.ProcedureDefinition.SelectedObject;
            // <-- Automatically generated part.
            ActionTypeEnum? actionType = null;
            if (procedureDefinition != null)
            {
               if( procedureDefinition is IProcedureRequestDefinition)
                {
                    actionType = ((IProcedureRequestDefinition)procedureDefinition).GetActionTypeEnum();
                }
            }
            if (actionType != null)
            {
                this.ActionType.ReadOnly = true;
                this._DiagnosisActionSuggestion.ActionType = actionType;
            }
            else
            {
                this.ActionType.ReadOnly = false;
                this.ActionType.ControlValue = null;
            }
            // Automatically generated part. -->
        }

        protected override void PreScript()
        {
            // <-- Automatically generated part.
            base.PreScript();
            if (((ITTObject)this._DiagnosisActionSuggestion).IsNew == true)
                this._DiagnosisActionSuggestion.IsActive = true;
            // Automatically generated part. -->
        }
    }
}

