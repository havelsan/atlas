
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
    /// Durum Takip
    /// </summary>
    public partial class ExternalSupplyTrackingForm : TTForm
    {
        override protected void BindControlEvents()
        {
            ProjectsGrid.CellContentClick += new TTGridCellEventDelegate(ProjectsGrid_CellContentClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            ProjectsGrid.CellContentClick -= new TTGridCellEventDelegate(ProjectsGrid_CellContentClick);
            base.UnBindControlEvents();
        }

        private void ProjectsGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region ExternalSupplyTrackingForm_ProjectsGrid_CellContentClick
   if(ProjectsGrid.CurrentCell == null)
                return;
            
            Guid guid = new Guid(ProjectsGrid.CurrentCell.OwningRow.Cells["clmGUID"].Value.ToString());
            if(ProjectsGrid.CurrentCell.OwningColumn.Name == "cmdCheck")
            {
                PurchaseProject pp = (PurchaseProject)_SupplyTracking.ObjectContext.GetObject(guid, "PURCHASEPROJECT");
                if(pp.LBMessageID == null)
                    throw new TTUtils.TTException("Lojistik Daire İletişim Bilgisine Ulaşılamıyor");
            }
            else
            //if(ProjectsGrid.CurrentCell.OwningColumn.Name == "clmProjectNo")
            {
                _SupplyTracking.TmpPurchaseProject = null;
                _SupplyTracking.TmpPurchaseOrder = null;
                _SupplyTracking.TmpContract = null;
                PurchaseProject purchaseProject = (PurchaseProject)_SupplyTracking.ObjectContext.GetObject(guid, "PURCHASEPROJECT");
                _SupplyTracking.TmpPurchaseProject = purchaseProject;
            }
#endregion ExternalSupplyTrackingForm_ProjectsGrid_CellContentClick
        }

        protected override void PreScript()
        {
#region ExternalSupplyTrackingForm_PreScript
    base.PreScript();
            
            IList list = PurchaseProject.GetProjectsOnLBState((TTObjectContext)_SupplyTracking.ObjectContext);
            foreach(PurchaseProject purchaseProject in list)
            {
                ITTGridRow gridRow = ProjectsGrid.Rows.Add();
                gridRow.Cells["clmProjectNo"].Value = purchaseProject.PurchaseProjectNO;
                gridRow.Cells["clmConfirmNo"].Value = purchaseProject.ConfirmNO;
                gridRow.Cells["clmGUID"].Value = purchaseProject.ObjectID;
            }
#endregion ExternalSupplyTrackingForm_PreScript

            }
                }
}