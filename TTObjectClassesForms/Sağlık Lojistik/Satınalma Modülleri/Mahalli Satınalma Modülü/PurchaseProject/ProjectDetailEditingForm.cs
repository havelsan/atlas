
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
    public partial class ProjectDetailEditingForm : TTForm
    {
        override protected void BindControlEvents()
        {
            cmdExclude.Click += new TTControlEventDelegate(cmdExclude_Click);
            cmdAdd.Click += new TTControlEventDelegate(cmdAdd_Click);
            DetailsGrid2.CellContentClick += new TTGridCellEventDelegate(DetailsGrid2_CellContentClick);
            AvailableProjectsGrid.CellContentClick += new TTGridCellEventDelegate(AvailableProjectsGrid_CellContentClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdExclude.Click -= new TTControlEventDelegate(cmdExclude_Click);
            cmdAdd.Click -= new TTControlEventDelegate(cmdAdd_Click);
            DetailsGrid2.CellContentClick -= new TTGridCellEventDelegate(DetailsGrid2_CellContentClick);
            AvailableProjectsGrid.CellContentClick -= new TTGridCellEventDelegate(AvailableProjectsGrid_CellContentClick);
            base.UnBindControlEvents();
        }

        private void cmdExclude_Click()
        {
#region ProjectDetailEditingForm_cmdExclude_Click
   if (_PurchaseProject.TempPurchaseProjectDetMerge != null)
            {
                ArrayList aList = new ArrayList();
                foreach (ITTGridRow row in DetailsGrid2.Rows)
                {
                    if (Convert.ToBoolean(row.Cells[Selected2.Name].Value) == true)
                        aList.Add((PurchaseProjectDetail)row.TTObject);
                }

                foreach (PurchaseProjectDetail pDet in aList)
                {
                    this.TransferProjectDetail(pDet, _PurchaseProject.TempPurchaseProjectDetMerge);
                }
            }
#endregion ProjectDetailEditingForm_cmdExclude_Click
        }

        private void cmdAdd_Click()
        {
#region ProjectDetailEditingForm_cmdAdd_Click
   ArrayList aList = new ArrayList();
            foreach (ITTGridRow row in DetailsGrid.Rows)
            {
                if (Convert.ToBoolean(row.Cells[Selected.Name].Value) == true)
                    aList.Add((PurchaseProjectDetail)row.TTObject);
            }

            foreach (PurchaseProjectDetail pDet in aList)
            {
                this.TransferProjectDetail(pDet, _PurchaseProject);
            }
#endregion ProjectDetailEditingForm_cmdAdd_Click
        }

        private void DetailsGrid2_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region ProjectDetailEditingForm_DetailsGrid2_CellContentClick
   if (DetailsGrid2.CurrentCell.OwningColumn == DetailsGrid2.Columns[Delete2.Name])
            {
                PurchaseProjectDetail ppd = (PurchaseProjectDetail)DetailsGrid2.CurrentCell.OwningRow.TTObject;
                if (ppd.ContractDetail != null || ppd.PurchaseOrderDetails.Count > 0)
                    throw new TTUtils.TTException(SystemMessage.GetMessage(32));
                ppd.DemandDetails.ClearChildren();
                ppd.CurrentStateDefID = PurchaseProjectDetail.States.Cancelled;
                _PurchaseProject.ObjectContext.Update();
                DetailsGrid2.RefreshRows();
            }
#endregion ProjectDetailEditingForm_DetailsGrid2_CellContentClick
        }

        private void AvailableProjectsGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region ProjectDetailEditingForm_AvailableProjectsGrid_CellContentClick
   if (AvailableProjectsGrid.CurrentCell.OwningColumn.Name == "ProjectNo" && string.IsNullOrEmpty(AvailableProjectsGrid.CurrentCell.Value.ToString()) == false)
            {
                Guid pGuid = new Guid(AvailableProjectsGrid.CurrentCell.OwningRow.Cells["ProjectGuid"].Value.ToString());
                PurchaseProject purchaseProject = (PurchaseProject)_PurchaseProject.ObjectContext.GetObject(pGuid, "PURCHASEPROJECT");
                _PurchaseProject.TempPurchaseProjectDetMerge = purchaseProject;
            }
#endregion ProjectDetailEditingForm_AvailableProjectsGrid_CellContentClick
        }

        protected override void PreScript()
        {
#region ProjectDetailEditingForm_PreScript
    base.PreScript();

            this.DropStateButton(PurchaseProject.States.Canceled);
            this.GetAvailableProjects();
#endregion ProjectDetailEditingForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region ProjectDetailEditingForm_PostScript
    base.PostScript(transDef);

            _PurchaseProject.SetActCount();
#endregion ProjectDetailEditingForm_PostScript

            }
            
#region ProjectDetailEditingForm_Methods
        public void GetAvailableProjects()
        {
            IList list = _PurchaseProject.ObjectContext.QueryObjects("PURCHASEPROJECT", "CURRENTSTATEDEFID = '90f3b1ba-4b23-47d9-94c6-6632146c93d9' AND OBJECTID <> '" + _PurchaseProject.ObjectID + "'");
            foreach (PurchaseProject purchaseProject in list)
            {
                ITTGridRow gridRow = AvailableProjectsGrid.Rows.Add();
                gridRow.Cells["ProjectNo"].Value = purchaseProject.PurchaseProjectNO;
                gridRow.Cells["ProjectGuid"].Value = purchaseProject.ObjectID;
            }
        }

        public void TransferProjectDetail(PurchaseProjectDetail sourcePurchaseProjectDetail, PurchaseProject targetPurchaseProject)
        {
            bool existingDetail = false;
            PurchaseProjectDetail targetPurchaseProjectDetail = null;
            foreach (PurchaseProjectDetail ppd in targetPurchaseProject.PurchaseProjectDetails)
            {
                if (ppd.PurchaseItemDef == sourcePurchaseProjectDetail.PurchaseItemDef && ppd.CurrentStateDefID != PurchaseProjectDetail.States.Cancelled)
                {
                    targetPurchaseProjectDetail = ppd;
                    existingDetail = true;
                    break;
                }
            }

            PurchaseProject tmpProject = sourcePurchaseProjectDetail.PurchaseProject;

            if (existingDetail)
            {
                targetPurchaseProjectDetail.Amount += sourcePurchaseProjectDetail.Amount;
                targetPurchaseProjectDetail.RequestedAmount += sourcePurchaseProjectDetail.RequestedAmount;

                ArrayList aList = new ArrayList();
                foreach (DemandDetail dd in sourcePurchaseProjectDetail.DemandDetails)
                {
                    aList.Add(dd);
                }
                foreach (DemandDetail demandDetail in aList)
                {
                    demandDetail.PurchaseProjectDetail = targetPurchaseProjectDetail;
                }
                sourcePurchaseProjectDetail.CurrentStateDefID = PurchaseProjectDetail.States.Cancelled;
            }
            else
            {
                sourcePurchaseProjectDetail.PurchaseProject = targetPurchaseProject;
            }

            PurchaseProjectGroup pGroup = null;
            foreach (PurchaseProjectGroup ppg in targetPurchaseProject.PurchaseProjectGroups)
            {
                if ((bool)ppg.GroupExcluded)
                {
                    pGroup = ppg;
                    break;
                }
            }
            if (pGroup != null)
                sourcePurchaseProjectDetail.PurchaseProjectGroup = pGroup;
            else
                throw new TTUtils.TTException(SystemMessage.GetMessage(33));

            targetPurchaseProject.SetOrderNOs();

            if (tmpProject.PurchaseProjectDetails.Count == 0)
                tmpProject.CurrentStateDefID = PurchaseProject.States.Canceled;
            else
                tmpProject.SetOrderNOs();

            _PurchaseProject.ObjectContext.Update();
            DetailsGrid.RefreshRows();
            DetailsGrid2.RefreshRows();
        }
        
#endregion ProjectDetailEditingForm_Methods
    }
}