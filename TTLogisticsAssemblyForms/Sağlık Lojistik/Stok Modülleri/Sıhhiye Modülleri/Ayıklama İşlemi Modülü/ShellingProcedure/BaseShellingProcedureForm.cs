
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
    /// Ayıklama İşlemi
    /// </summary>
    public partial class BaseShellingProcedureForm : StockActionBaseForm
    {
        override protected void BindControlEvents()
        {
            ShellingProcedureOutMaterials.CellDoubleClick += new TTGridCellEventDelegate(ShellingProcedureOutMaterials_CellDoubleClick);
            ShellingProcedureOutMaterials.CellContentClick += new TTGridCellEventDelegate(ShellingProcedureOutMaterials_CellContentClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ShellingProcedureOutMaterials.CellDoubleClick -= new TTGridCellEventDelegate(ShellingProcedureOutMaterials_CellDoubleClick);
            ShellingProcedureOutMaterials.CellContentClick -= new TTGridCellEventDelegate(ShellingProcedureOutMaterials_CellContentClick);
            base.UnBindControlEvents();
        }

        private void ShellingProcedureOutMaterials_CellDoubleClick(Int32 rowIndex, Int32 columnIndex)
        {
#region BaseShellingProcedureForm_ShellingProcedureOutMaterials_CellDoubleClick
   CheckWhetherTheInventoryOfMaterial(rowIndex, columnIndex, ShellingProcedureOutMaterials);
#endregion BaseShellingProcedureForm_ShellingProcedureOutMaterials_CellDoubleClick
        }

        private void ShellingProcedureOutMaterials_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region BaseShellingProcedureForm_ShellingProcedureOutMaterials_CellContentClick
   if(ShellingProcedureOutMaterials.CurrentCell.OwningColumn.Name =="Detail")
                 this.ShowStockActionDetailForm((StockActionDetail)ShellingProcedureOutMaterials.CurrentCell.OwningRow.TTObject);
#endregion BaseShellingProcedureForm_ShellingProcedureOutMaterials_CellContentClick
        }
    }
}