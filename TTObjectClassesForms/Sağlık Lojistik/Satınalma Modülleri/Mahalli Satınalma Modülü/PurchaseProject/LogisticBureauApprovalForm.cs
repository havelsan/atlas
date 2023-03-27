
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
    public partial class LogisticBureauApprovalForm : TTForm
    {
        override protected void BindControlEvents()
        {
            PurchaseProjectDetailsGrid.CellContentClick += new TTGridCellEventDelegate(PurchaseProjectDetailsGrid_CellContentClick);
            TransferItemsGrid.CellContentClick += new TTGridCellEventDelegate(TransferItemsGrid_CellContentClick);
            cmdPrintTransferOrders.Click += new TTControlEventDelegate(cmdPrintTransferOrders_Click);
            cmdPrepareTransferOrder.Click += new TTControlEventDelegate(cmdPrepareTransferOrder_Click);
            cmdApproveAll.Click += new TTControlEventDelegate(cmdApproveAll_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            PurchaseProjectDetailsGrid.CellContentClick -= new TTGridCellEventDelegate(PurchaseProjectDetailsGrid_CellContentClick);
            TransferItemsGrid.CellContentClick -= new TTGridCellEventDelegate(TransferItemsGrid_CellContentClick);
            cmdPrintTransferOrders.Click -= new TTControlEventDelegate(cmdPrintTransferOrders_Click);
            cmdPrepareTransferOrder.Click -= new TTControlEventDelegate(cmdPrepareTransferOrder_Click);
            cmdApproveAll.Click -= new TTControlEventDelegate(cmdApproveAll_Click);
            base.UnBindControlEvents();
        }

        private void PurchaseProjectDetailsGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region LogisticBureauApprovalForm_PurchaseProjectDetailsGrid_CellContentClick
   if (columnIndex == PurchaseProjectDetailsGrid.Columns[Details.Name].Index)
            {
                PurchaseProject myProject = _PurchaseProject;
                LogisticBureauAnalyseDetails lbad = new LogisticBureauAnalyseDetails();
                lbad.ShowEdit(this.FindForm(), myProject.PurchaseProjectDetails[PurchaseProjectDetailsGrid.CurrentCell.RowIndex]);
            }
#endregion LogisticBureauApprovalForm_PurchaseProjectDetailsGrid_CellContentClick
        }

        private void TransferItemsGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region LogisticBureauApprovalForm_TransferItemsGrid_CellContentClick
   if (TransferItemsGrid.CurrentCell == null)
                return;

            ItemTransfer iT = (ItemTransfer)TransferItemsGrid.CurrentCell.OwningRow.TTObject;
            _PurchaseProject.TempItemTransfer = iT;

            if (TransferItemsGrid.CurrentCell.OwningColumn.Name == "cmdDetail")
            {
                ItemTransferForm itForm = new ItemTransferForm();
                itForm.ShowEdit(this.FindForm(), iT);
            }
#endregion LogisticBureauApprovalForm_TransferItemsGrid_CellContentClick
        }

        private void cmdPrintTransferOrders_Click()
        {
#region LogisticBureauApprovalForm_cmdPrintTransferOrders_Click
   _PurchaseProject.ObjectContext.Save();

            Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();

            TTReportTool.PropertyCache<object> objID = new TTReportTool.PropertyCache<object>();
            objID.Add("VALUE", _PurchaseProject.ObjectID.ToString());

            parameters.Add("TTOBJECTID", objID);

            TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_TertipEmri), true, 1, parameters);
#endregion LogisticBureauApprovalForm_cmdPrintTransferOrders_Click
        }

        private void cmdPrepareTransferOrder_Click()
        {
#region LogisticBureauApprovalForm_cmdPrepareTransferOrder_Click
   if (_PurchaseProject.ItemTransfers.Count > 0)
                _PurchaseProject.ItemTransfers.DeleteChildren();

            ArrayList accList = new ArrayList();
            ArrayList lbAppDetList = new ArrayList();
            foreach (PurchaseProjectDetail ppd in _PurchaseProject.PurchaseProjectDetails)
            {
                if (ppd.CurrentStateDefID != PurchaseProjectDetail.States.Cancelled)
                {
                    foreach (LBApproveDetail lbapp in ppd.LBApproveDetails)
                    {
                        if (lbapp.ApproveType == LBApproveDetailTypeEnum.CounterBalance && lbapp.Amount > 0)
                        {
                            lbAppDetList.Add(lbapp);
                            if (accList.Contains(lbapp.Accountancy) == false)
                                accList.Add(lbapp.Accountancy);
                        }
                    }
                }
            }

            foreach (Accountancy acc in accList)
            {
                ItemTransfer iT = new ItemTransfer(_PurchaseProject.ObjectContext);
                iT.Accountancy = acc;
                iT.PurchaseProject = _PurchaseProject;
                foreach (LBApproveDetail lbDet in lbAppDetList)
                {
                    if (lbDet.Accountancy.ObjectID == acc.ObjectID)
                    {
                        ItemTransferDetail iTDet = new ItemTransferDetail(_PurchaseProject.ObjectContext);
                        iTDet.ItemTransfer = iT;
                        iTDet.PurchaseItemDef = lbDet.PurchaseProjectDetail.PurchaseItemDef;
                        iTDet.Amount = lbDet.Amount;
                    }
                }
            }

            TransferItemsGrid.RefreshRows();
#endregion LogisticBureauApprovalForm_cmdPrepareTransferOrder_Click
        }

        private void cmdApproveAll_Click()
        {
#region LogisticBureauApprovalForm_cmdApproveAll_Click
   bool dirty = false;
            foreach (PurchaseProjectDetail ppd in _PurchaseProject.PurchaseProjectDetails)
            {
                if (ppd.LBApproveDetails.Count > 0)
                {
                    dirty = false;
                    foreach (LBApproveDetail lbApp in ppd.LBApproveDetails)
                    {
                        if (lbApp.Amount != 0)
                        {
                            dirty = true;
                            break;
                        }
                    }

                    if (!dirty)
                    {
                        foreach (LBApproveDetail lbApp in ppd.LBApproveDetails)
                        {
                            if (lbApp.ApproveType == LBApproveDetailTypeEnum.Internal)
                            {
                                lbApp.Amount = ppd.RequestedAmount;
                                ppd.Amount = ppd.RequestedAmount;
                                ppd.CancelledAmount = 0;
                            }
                        }
                    }
                }
            }
#endregion LogisticBureauApprovalForm_cmdApproveAll_Click
        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region LogisticBureauApprovalForm_PostScript
    base.PostScript(transDef);

            if (_PurchaseProject.ResponsibleProcurementUnitDef != null)
            {
                if (_PurchaseProject.ResponsibleProcurementUnitDef.MilitaryUnit == null)
                    throw new TTUtils.TTException(SystemMessage.GetMessage(24));
                if (_PurchaseProject.ResponsibleProcurementUnitDef.MilitaryUnit.Site == null)
                    throw new TTUtils.TTException(SystemMessage.GetMessage(505) + "\r\n" + _PurchaseProject.ResponsibleProcurementUnitDef.MilitaryUnit.ToString());
                //                if (_PurchaseProject.ResponsibleProcurementUnitDef.MilitaryUnit.Site.ResHospital.Count == 0)
                //                    throw new TTUtils.TTException(SystemMessage.GetMessage(25));
            }
#endregion LogisticBureauApprovalForm_PostScript

            }
                }
}