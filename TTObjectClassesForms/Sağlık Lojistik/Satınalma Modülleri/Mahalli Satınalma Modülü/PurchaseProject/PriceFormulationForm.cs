
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
    public partial class PriceFormulationForm : TTForm
    {
        override protected void BindControlEvents()
        {
            PurchaseProjectDetailItems.CellValueChanged += new TTGridCellEventDelegate(PurchaseProjectDetailItems_CellValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            PurchaseProjectDetailItems.CellValueChanged -= new TTGridCellEventDelegate(PurchaseProjectDetailItems_CellValueChanged);
            base.UnBindControlEvents();
        }

        private void PurchaseProjectDetailItems_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
        }

        protected override void PreScript()
        {
#region PriceFormulationForm_PreScript
    base.PreScript();

            if (PriceFormulationCommision.Rows.Count > 0)
                return;

            int type = Convert.ToInt32(CommisionTypeEnum.PriceFormulationCommision);

            IList commision = CommisionDefinition.GetCommisionByType(_PurchaseProject.ObjectContext, type);
            if (commision.Count > 0)
            {
                CommisionDefinition cd = (CommisionDefinition)commision[0];
                foreach (CommisionDefinitionMember cdm in cd.CommisionDefinitionMembers)
                {
                    PriceFormulationCommisionMember pm = new PriceFormulationCommisionMember(_PurchaseProject.ObjectContext);
                    pm.PurchaseProject = _PurchaseProject;
                    pm.PrimeBackup = true;
                    pm.ResUser = cdm.ResUser;
                }
            }
#endregion PriceFormulationForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region PriceFormulationForm_PostScript
    base.PostScript(transDef);
#endregion PriceFormulationForm_PostScript

            }
            
#region PriceFormulationForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);
        }
        
#endregion PriceFormulationForm_Methods
    }
}