
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
    public partial class ArgeProjectOwnerForm : ArgeProjectAcdComApprovalForm
    {
        override protected void BindControlEvents()
        {
            btnAddDocument.Click += new TTControlEventDelegate(btnAddDocument_Click);
            ConsumableMaterials.CellValueChanged += new TTGridCellEventDelegate(ConsumableMaterials_CellValueChanged);
            ProjectReport.CellDoubleClick += new TTGridCellEventDelegate(ProjectReport_CellDoubleClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            btnAddDocument.Click -= new TTControlEventDelegate(btnAddDocument_Click);
            ConsumableMaterials.CellValueChanged -= new TTGridCellEventDelegate(ConsumableMaterials_CellValueChanged);
            ProjectReport.CellDoubleClick -= new TTGridCellEventDelegate(ProjectReport_CellDoubleClick);
            base.UnBindControlEvents();
        }

        private void btnAddDocument_Click()
        {
#region ArgeProjectOwnerForm_btnAddDocument_Click
   //System.Windows.Forms.OpenFileDialog openFileDialog = new OpenFileDialog();
   //         openFileDialog.ShowDialog();
   //         string fileName = @openFileDialog.FileName;
   //         System.IO.FileStream fileStream = new System.IO.FileStream(fileName, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.Read);
   //         long len;
   //         len = fileStream.Length;
   //         Byte[] fileAsByte = new Byte[len];
   //         fileStream.Read(fileAsByte, 0, fileAsByte.Length);
   //         ProjectDocument pDoc = this._ArgeProject.Documents.AddNew();
   //         pDoc.Title = fileName;
   //         pDoc.Content = fileAsByte;
#endregion ArgeProjectOwnerForm_btnAddDocument_Click
        }

        private void ConsumableMaterials_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region ArgeProjectOwnerForm_ConsumableMaterials_CellValueChanged
   if(columnIndex==3)
            {
                this._ArgeProject.CalcConsumableCosts();
                this._ArgeProject.CalcTotalCosts();
                this.TotalOtherCosts.Text = this._ArgeProject.CalcConsumableCosts().ToString();
                this.TotalCosts.Text = this._ArgeProject.CalcTotalCosts().ToString();
            }
#endregion ArgeProjectOwnerForm_ConsumableMaterials_CellValueChanged
        }

        private void ProjectReport_CellDoubleClick(Int32 rowIndex, Int32 columnIndex)
        {
        }

        protected override void PreScript()
        {
#region ArgeProjectOwnerForm_PreScript
    base.PreScript();
            //if(this._ArgeProject.CurrentStateDefID != null && this._ArgeProject.CurrentStateDefID.Equals(ArgeProject.States.AdvisorApproval))
            //    this._ArgeProject.AdditionalTimeDemand = new AdditionalTimeDemand(this._ArgeProject.ObjectContext);
#endregion ArgeProjectOwnerForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region ArgeProjectOwnerForm_PostScript
    base.PostScript(transDef);
        foreach (ConsumableMaterialDetail cmd in this._ArgeProject.ConsumableMaterials)
        {
            StockOut stockOut = new StockOut(this._ArgeProject.ObjectContext);
            stockOut.CurrentStateDefID = StockOut.States.New;
            stockOut.Store = cmd.Store;

            StockOutMaterial stockOutMaterial = new StockOutMaterial(this._ArgeProject.ObjectContext);
            stockOutMaterial.Amount = cmd.Amount;
            stockOutMaterial.Material = cmd.Material;
            stockOutMaterial.StockLevelType = StockLevelType.NewStockLevel;
            stockOutMaterial.StockAction = stockOut;
            cmd.StockOut = stockOut;
            stockOut.Update();
            stockOut.CurrentStateDefID = StockOut.States.Completed;
        }
#endregion ArgeProjectOwnerForm_PostScript

            }
                }
}