
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
    /// İmha Edilenler
    /// </summary>
    public partial class ShellingProcedureMaterialOutForm : BaseStockActionDetailOutForm
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
#region ShellingProcedureMaterialOutForm_PreScript
    base.PreScript();

            if (_ShellingProcedureMaterialOut.ShellingProcedure.CurrentStateDefID == ShellingProcedure.States.New)
                tttabcontrol1.HideTabPage(InMaterialTabpage);

            if (_ShellingProcedureMaterialOut.ShellingProcedure.CurrentStateDefID != ShellingProcedure.States.New)
                FixedAssetDetails.ReadOnly = true;

            if (_ShellingProcedureMaterialOut.ShellingProcedure.CurrentStateDefID == ShellingProcedure.States.SortingClassification)
                InMaterials.Required = true;
#endregion ShellingProcedureMaterialOutForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region ShellingProcedureMaterialOutForm_PostScript
    base.PostScript(transDef);

            if (transDef == null)
                foreach (ShellingProcedureMaterialIn shellingProcedureMaterialIn in _ShellingProcedureMaterialOut.InMaterials)
                    if (shellingProcedureMaterialIn.ShellingProcedure == null)
                        shellingProcedureMaterialIn.ShellingProcedure = _ShellingProcedureMaterialOut.ShellingProcedure;
#endregion ShellingProcedureMaterialOutForm_PostScript

            }
                }
}