
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
    public partial class EpisodeActionTemplateForm : TTDefinitionForm
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
#region EpisodeActionTemplateForm_ActionType_SelectedIndexChanged
   if(this._EpisodeActionTemplate.ProcedureDefinitions.Count > 0)
                this._EpisodeActionTemplate.ProcedureDefinitions.DeleteChildren();
            
            SetProcedureDefinitionFilter();
#endregion EpisodeActionTemplateForm_ActionType_SelectedIndexChanged
        }

        protected override void PreScript()
        {
#region EpisodeActionTemplateForm_PreScript
    base.PreScript();
            SetProcedureDefinitionFilter();
#endregion EpisodeActionTemplateForm_PreScript

            }
            
#region EpisodeActionTemplateForm_Methods
        public void SetProcedureDefinitionFilter(){
            string procuderDefNames = "";
            if(this._EpisodeActionTemplate.ActionType!= null)
                procuderDefNames = TTObjectClasses.ProcedureDefinition.GetProcedureDefinitionNames((ActionTypeEnum)this._EpisodeActionTemplate.ActionType);
            string filter="1=2";
            if(procuderDefNames!="")
                filter=" THIS.OBJECTDEFNAME IN("+ procuderDefNames +")";
            ((ITTListBoxColumn)this.ProcedureDefinitions.Columns["ProcedureDefinition"]).ListFilterExpression =  filter;
        }
        
#endregion EpisodeActionTemplateForm_Methods
    }
}