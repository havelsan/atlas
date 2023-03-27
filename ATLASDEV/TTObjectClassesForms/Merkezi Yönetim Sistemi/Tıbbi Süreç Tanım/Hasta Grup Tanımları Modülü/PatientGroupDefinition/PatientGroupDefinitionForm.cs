
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
    /// Hasta Grup Tanımı
    /// </summary>
    public partial class PatientGroupDefinitionForm : TerminologyManagerDefForm
    {
        override protected void BindControlEvents()
        {
            RequiredMedulaProvision.CheckedChanged += new TTControlEventDelegate(RequiredMedulaProvision_CheckedChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            RequiredMedulaProvision.CheckedChanged -= new TTControlEventDelegate(RequiredMedulaProvision_CheckedChanged);
            base.UnBindControlEvents();
        }

        private void RequiredMedulaProvision_CheckedChanged()
        {
#region PatientGroupDefinitionForm_RequiredMedulaProvision_CheckedChanged
   if(this.RequiredMedulaProvision.Value==true)
                MedulaRequrements.Enabled=true;
            else
                MedulaRequrements.Enabled=false;
#endregion PatientGroupDefinitionForm_RequiredMedulaProvision_CheckedChanged
        }

        protected override void PreScript()
        {
#region PatientGroupDefinitionForm_PreScript
    base.PreScript();

    if (TTObjectClasses.SystemParameter.IsMedulaIntegration)
    {
        this.RequiredMedulaProvision.Visible = true;
        this.MedulaRequrements.Visible = true;
        if (this.RequiredMedulaProvision.Value == true)
            MedulaRequrements.Enabled = true;
        else
            MedulaRequrements.Enabled = false;
    }
    else
    {
        this.RequiredMedulaProvision.Visible = false;
        this.MedulaRequrements.Visible = false;
    }
#endregion PatientGroupDefinitionForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region PatientGroupDefinitionForm_PostScript
    base.PostScript(transDef);
            BindingList<PatientGroupDefinition.GetPatientGroupDefinition_Class> definitionList=PatientGroupDefinition.GetPatientGroupDefinition("WHERE PATIENTGROUPENUM=" + this._PatientGroupDefinition.PatientGroupEnum.GetHashCode() );
            if (definitionList.Count>0 && ((definitionList[0].ObjectID).ToString()!=this._PatientGroupDefinition.ObjectID.ToString()))
                throw new Exception(SystemMessage.GetMessageV3(1274,new string[] {this._PatientGroupDefinition.PatientGroupEnum.ToString()}));
#endregion PatientGroupDefinitionForm_PostScript

            }
                }
}