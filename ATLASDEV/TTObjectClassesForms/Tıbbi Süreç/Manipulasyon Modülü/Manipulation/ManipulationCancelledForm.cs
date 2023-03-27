
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
    /// Tıbbi/Cerrahi Uygulamalar
    /// </summary>
    public partial class ManipulationCancelledForm : EpisodeActionForm
    {
        override protected void BindControlEvents()
        {
            GridManipulations.CellValueChanged += new TTGridCellEventDelegate(GridManipulations_CellValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            GridManipulations.CellValueChanged -= new TTGridCellEventDelegate(GridManipulations_CellValueChanged);
            base.UnBindControlEvents();
        }

        private void GridManipulations_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region ManipulationCancelledForm_GridManipulations_CellValueChanged
   if (GridTreatmentMaterials.CurrentCell.OwningColumn.Name == "Material")
            {
                BaseTreatmentMaterial baseTreatmentMaterial = (BaseTreatmentMaterial)((ITTGridRow)GridTreatmentMaterials.Rows[rowIndex]).TTObject;

                if (baseTreatmentMaterial.Material is ConsumableMaterialDefinition)
                {
                    this.GridTreatmentMaterials.Rows[rowIndex].Cells["DistributionType"].Value = baseTreatmentMaterial.Material.StockCard.DistributionType.DistributionType.ToString();
                    this.GridTreatmentMaterials.Rows[rowIndex].Cells["UnitType"].Value = "-";
                    this.GridTreatmentMaterials.Rows[rowIndex].Cells["UseAmount"].Value = "-";
                }

                else if (baseTreatmentMaterial.Material is DrugDefinition)
                {

                    this.GridTreatmentMaterials.Rows[rowIndex].Cells["UnitType"].Value = ((DrugDefinition)baseTreatmentMaterial.Material).Unit.Name.ToString();
                    this.GridTreatmentMaterials.Rows[rowIndex].Cells["DistributionType"].Value = ((DrugDefinition)baseTreatmentMaterial.Material).StockCard.DistributionType.DistributionType.ToString();
                }
            }
#endregion ManipulationCancelledForm_GridManipulations_CellValueChanged
        }

        protected override void PreScript()
        {
#region ManipulationCancelledForm_PreScript
    base.PreScript();
#endregion ManipulationCancelledForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region ManipulationCancelledForm_PostScript
    base.PostScript(transDef);
#endregion ManipulationCancelledForm_PostScript

            }
                }
}