
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
    /// Anestezi ve Reanimasyon
    /// </summary>
    public partial class AnesthesiaExpentForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            GridAnesthesiaExpends.CellValueChanged += new TTGridCellEventDelegate(GridAnesthesiaExpends_CellValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            GridAnesthesiaExpends.CellValueChanged -= new TTGridCellEventDelegate(GridAnesthesiaExpends_CellValueChanged);
            base.UnBindControlEvents();
        }

        private void GridAnesthesiaExpends_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
            #region AnesthesiaExpentForm_GridAnesthesiaExpends_CellValueChanged
            if (GridAnesthesiaExpends.CurrentCell.OwningColumn.Name == "SMStore")
            {
                BaseTreatmentMaterial treatmentMaterial = (BaseTreatmentMaterial)((ITTGridRow)this.GridAnesthesiaExpends.Rows[rowIndex]).TTObject;
                if (treatmentMaterial != null)
                {
                    SMMaterial.ListFilterExpression = " STOCKS.INHELD > 0 AND STOCKS.STORE = " + ConnectionManager.GuidToString(treatmentMaterial.Store.ObjectID);
                }
            }
            #endregion AnesthesiaExpentForm_GridAnesthesiaExpends_CellValueChanged
        }

        protected override void PreScript()
        {
            #region AnesthesiaExpentForm_PreScript
            base.PreScript();
            this.DropStateButton(AnesthesiaAndReanimation.States.Cancelled);

            if (this._AnesthesiaAndReanimation.MainSurgery == null)
            {
                if (this.TabSubaction.TabPages.Contains(this.SurgeryInfo))
                {
                    this.TabSubaction.TabPages.RemoveAt(this.SurgeryInfo.DisplayIndex);

                }
            }
            this.SetTreatmentMaterialListFilter((TTObjectDef)TTObjectDefManager.Instance.ObjectDefs["AnesthesiaAndReanimationTreatmentMaterial"], (ITTGridColumn)this.GridAnesthesiaExpends.Columns["SMMaterial"]);
            #endregion AnesthesiaExpentForm_PreScript

        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
            #region AnesthesiaExpentForm_PostScript
            base.PostScript(transDef);
            this._AnesthesiaAndReanimation.CheckAnesthesiaTime();
            foreach (BaseTreatmentMaterial treatmentMaterial in _AnesthesiaAndReanimation.TreatmentMaterials)
            {
                if (treatmentMaterial.StockActionDetail == null && treatmentMaterial.Store == null)
                    treatmentMaterial.Store = this._EpisodeAction.MasterResource.Store;
            }
            #endregion AnesthesiaExpentForm_PostScript

        }

    }
      
}