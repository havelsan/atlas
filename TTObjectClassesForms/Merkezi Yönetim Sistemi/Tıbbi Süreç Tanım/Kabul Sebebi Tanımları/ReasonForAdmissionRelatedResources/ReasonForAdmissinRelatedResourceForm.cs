
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
    /// Kabul Sebepleri Kaynak Tanımları
    /// </summary>
    public partial class ReasonForAdmissinRelatedResourceForm : TTForm
    {
        override protected void BindControlEvents()
        {
            ActionType.SelectedIndexChanged += new TTControlEventDelegate(ActionType_SelectedIndexChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ActionType.SelectedIndexChanged -= new TTControlEventDelegate(ActionType_SelectedIndexChanged);
            base.UnBindControlEvents();
        }

        private void ActionType_SelectedIndexChanged()
        {
#region ReasonForAdmissinRelatedResourceForm_ActionType_SelectedIndexChanged
   if(this._ReasonForAdmissionRelatedResources.ProcedureDefinitions.Count>0){
                this._ReasonForAdmissionRelatedResources.ProcedureDefinitions.DeleteChildren();
            }
            SetProcedureDefinitionFilter();
#endregion ReasonForAdmissinRelatedResourceForm_ActionType_SelectedIndexChanged
        }

        protected override void PreScript()
        {
#region ReasonForAdmissinRelatedResourceForm_PreScript
    base.PreScript();
           SetProcedureDefinitionFilter();
#endregion ReasonForAdmissinRelatedResourceForm_PreScript

            }
            
#region ReasonForAdmissinRelatedResourceForm_Methods
        public void SetProcedureDefinitionFilter(){
            string procuderDefNames = "";
            if(this._ReasonForAdmissionRelatedResources.ActionType!= null)
                procuderDefNames = TTObjectClasses.ProcedureDefinition.GetProcedureDefinitionNames((ActionTypeEnum)this._ReasonForAdmissionRelatedResources.ActionType);
            string filter="1=2";
            if(procuderDefNames!="")
                filter=" THIS.OBJECTDEFNAME IN("+ procuderDefNames +")";
            ((ITTListBoxColumn)this.ProcedureDefinitions.Columns["ProcedureDefinition"]).ListFilterExpression =  filter;
        }
        
#endregion ReasonForAdmissinRelatedResourceForm_Methods
    }
}