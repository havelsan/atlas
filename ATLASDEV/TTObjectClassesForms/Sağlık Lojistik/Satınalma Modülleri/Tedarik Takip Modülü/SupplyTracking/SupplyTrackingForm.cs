
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
    /// Tedarik Takip Modülü
    /// </summary>
    public partial class SupplyTrackingForm : TTForm
    {
        override protected void BindControlEvents()
        {
            cmdFirePurchaseOrder.Click += new TTControlEventDelegate(cmdFirePurchaseOrder_Click);
            ProjectsGrid.CellContentClick += new TTGridCellEventDelegate(ProjectsGrid_CellContentClick);
            cmdListExternals.Click += new TTControlEventDelegate(cmdListExternals_Click);
            cmdSeachByProject.Click += new TTControlEventDelegate(cmdSeachByProject_Click);
            txt1ProjectNo.TextChanged += new TTControlEventDelegate(txt1ProjectNo_TextChanged);
            txt1ConfirmNo.TextChanged += new TTControlEventDelegate(txt1ConfirmNo_TextChanged);
            cmdSearchByState.Click += new TTControlEventDelegate(cmdSearchByState_Click);
            cmdSeachByItem.Click += new TTControlEventDelegate(cmdSeachByItem_Click);
            txt3Supplier.SelectedObjectChanged += new TTControlEventDelegate(txt3Supplier_SelectedObjectChanged);
            txt3ContractNo.TextChanged += new TTControlEventDelegate(txt3ContractNo_TextChanged);
            cmdSeachByContract.Click += new TTControlEventDelegate(cmdSeachByContract_Click);
            txt3DecisionNo.TextChanged += new TTControlEventDelegate(txt3DecisionNo_TextChanged);
            txt4Supplier.SelectedObjectChanged += new TTControlEventDelegate(txt4Supplier_SelectedObjectChanged);
            txt4DeliveryStartDate.ValueChanged += new TTControlEventDelegate(txt4DeliveryStartDate_ValueChanged);
            txt4OrderNo.TextChanged += new TTControlEventDelegate(txt4OrderNo_TextChanged);
            cmdSeachByOrder.Click += new TTControlEventDelegate(cmdSeachByOrder_Click);
            txt4OrderStartDate.ValueChanged += new TTControlEventDelegate(txt4OrderStartDate_ValueChanged);
            cmdSearchByMasterResource.Click += new TTControlEventDelegate(cmdSearchByMasterResource_Click);
            PurchaseItemsGrid.CellContentClick += new TTGridCellEventDelegate(PurchaseItemsGrid_CellContentClick);
            OrdersGrid.CellContentClick += new TTGridCellEventDelegate(OrdersGrid_CellContentClick);
            ContractsGrid.CellContentClick += new TTGridCellEventDelegate(ContractsGrid_CellContentClick);
            cmdCheckAll1.Click += new TTControlEventDelegate(cmdCheckAll1_Click);
            cmdUncheckAll1.Click += new TTControlEventDelegate(cmdUncheckAll1_Click);
            cmdCheckAll2.Click += new TTControlEventDelegate(cmdCheckAll2_Click);
            cmdUncheckAll2.Click += new TTControlEventDelegate(cmdUncheckAll2_Click);
            cmdFireExamination.Click += new TTControlEventDelegate(cmdFireExamination_Click);
            cmdFireCheque.Click += new TTControlEventDelegate(cmdFireCheque_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdFirePurchaseOrder.Click -= new TTControlEventDelegate(cmdFirePurchaseOrder_Click);
            ProjectsGrid.CellContentClick -= new TTGridCellEventDelegate(ProjectsGrid_CellContentClick);
            cmdListExternals.Click -= new TTControlEventDelegate(cmdListExternals_Click);
            cmdSeachByProject.Click -= new TTControlEventDelegate(cmdSeachByProject_Click);
            txt1ProjectNo.TextChanged -= new TTControlEventDelegate(txt1ProjectNo_TextChanged);
            txt1ConfirmNo.TextChanged -= new TTControlEventDelegate(txt1ConfirmNo_TextChanged);
            cmdSearchByState.Click -= new TTControlEventDelegate(cmdSearchByState_Click);
            cmdSeachByItem.Click -= new TTControlEventDelegate(cmdSeachByItem_Click);
            txt3Supplier.SelectedObjectChanged -= new TTControlEventDelegate(txt3Supplier_SelectedObjectChanged);
            txt3ContractNo.TextChanged -= new TTControlEventDelegate(txt3ContractNo_TextChanged);
            cmdSeachByContract.Click -= new TTControlEventDelegate(cmdSeachByContract_Click);
            txt3DecisionNo.TextChanged -= new TTControlEventDelegate(txt3DecisionNo_TextChanged);
            txt4Supplier.SelectedObjectChanged -= new TTControlEventDelegate(txt4Supplier_SelectedObjectChanged);
            txt4DeliveryStartDate.ValueChanged -= new TTControlEventDelegate(txt4DeliveryStartDate_ValueChanged);
            txt4OrderNo.TextChanged -= new TTControlEventDelegate(txt4OrderNo_TextChanged);
            cmdSeachByOrder.Click -= new TTControlEventDelegate(cmdSeachByOrder_Click);
            txt4OrderStartDate.ValueChanged -= new TTControlEventDelegate(txt4OrderStartDate_ValueChanged);
            cmdSearchByMasterResource.Click -= new TTControlEventDelegate(cmdSearchByMasterResource_Click);
            PurchaseItemsGrid.CellContentClick -= new TTGridCellEventDelegate(PurchaseItemsGrid_CellContentClick);
            OrdersGrid.CellContentClick -= new TTGridCellEventDelegate(OrdersGrid_CellContentClick);
            ContractsGrid.CellContentClick -= new TTGridCellEventDelegate(ContractsGrid_CellContentClick);
            cmdCheckAll1.Click -= new TTControlEventDelegate(cmdCheckAll1_Click);
            cmdUncheckAll1.Click -= new TTControlEventDelegate(cmdUncheckAll1_Click);
            cmdCheckAll2.Click -= new TTControlEventDelegate(cmdCheckAll2_Click);
            cmdUncheckAll2.Click -= new TTControlEventDelegate(cmdUncheckAll2_Click);
            cmdFireExamination.Click -= new TTControlEventDelegate(cmdFireExamination_Click);
            cmdFireCheque.Click -= new TTControlEventDelegate(cmdFireCheque_Click);
            base.UnBindControlEvents();
        }

        private void cmdFirePurchaseOrder_Click()
        {
#region SupplyTrackingForm_cmdFirePurchaseOrder_Click
   ArrayList contractDetails = new ArrayList();
            foreach(ITTGridRow row in ContractDetailsGrid.Rows)
            {
                if(Convert.ToBoolean(row.Cells[clm5Check.Name].Value) == true)
                    contractDetails.Add((ContractDetail)row.TTObject);
            }
            
            if(contractDetails.Count == 0)
                InfoBox.Show("En az bir kalem seçiniz");
            else
            {
                TTObjectContext context = new TTObjectContext(false);
                Contract contract = ((ContractDetail)contractDetails[0]).Contract;
                PurchaseOrder po = new PurchaseOrder(context);
                po.Contract = contract;
                po.CurrentStateDefID = PurchaseOrder.States.New;
                po.PurchaseProject = contract.PurchaseProject;
                po.Supplier = contract.Supplier;
                
                //Her kaleme restamount bulalım
                double restAmount = 0;
                PurchaseOrderDetail pod;
                foreach(ContractDetail cd in contractDetails)
                {
                    po.AddDetailFromContractDetail(cd, context);
                }
                TTForm frm = TTForm.GetEditForm((TTObject)po);
                DialogResult dialog = frm.ShowEdit(this.FindForm(),po);
                if(dialog == DialogResult.OK)
                {
                    context.Save();
                    this.Close();
                }
                else
                    context.Dispose();
            }
#endregion SupplyTrackingForm_cmdFirePurchaseOrder_Click
        }

        private void ProjectsGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region SupplyTrackingForm_ProjectsGrid_CellContentClick
   if (ProjectsGrid.CurrentCell != null)
            {
                _SupplyTracking.TmpPurchaseProject = null;
                _SupplyTracking.TmpPurchaseOrder = null;
                _SupplyTracking.TmpContract = null;
                Guid guid = new Guid(ProjectsGrid.CurrentCell.OwningRow.Cells["clmGUID"].Value.ToString());
                PurchaseProject purchaseProject = (PurchaseProject)_SupplyTracking.ObjectContext.GetObject(guid, "PURCHASEPROJECT");
                _SupplyTracking.TmpPurchaseProject = purchaseProject;
            }
#endregion SupplyTrackingForm_ProjectsGrid_CellContentClick
        }

        private void cmdListExternals_Click()
        {
#region SupplyTrackingForm_cmdListExternals_Click
   ExternalSupplyTrackingForm estf = new ExternalSupplyTrackingForm();
            estf.ShowEdit(this.FindForm(), _SupplyTracking);
#endregion SupplyTrackingForm_cmdListExternals_Click
        }

        private void cmdSeachByProject_Click()
        {
#region SupplyTrackingForm_cmdSeachByProject_Click
   this.ClearGrids();
            string projectNo = txt1ProjectNo.Text;
            string confirmNo = txt1ConfirmNo.Text;
            bool includeActives = (bool)chkActives.Value;
            bool includeCompleteds = (bool)chkCompleteds.Value;

            BindingList<PurchaseProject> projectList;
            if(string.IsNullOrEmpty(projectNo) && string.IsNullOrEmpty(confirmNo))
                projectList = PurchaseProject.GetAllProjects(_SupplyTracking.ObjectContext);
            else
            {
                if(string.IsNullOrEmpty(projectNo) == false)
                    projectList = PurchaseProject.GetPurchaseProjectByProjectNo(_SupplyTracking.ObjectContext, Convert.ToInt32(projectNo));
                else
                    projectList = PurchaseProject.GetPurchaseProjectByConfirmNo(_SupplyTracking.ObjectContext, confirmNo);
            }
            bool addRow = false;
            
            
            if(projectList.Count > 0)
            {
                foreach(PurchaseProject purchaseProject in projectList)
                {
                    if(purchaseProject.PurchaseTypeMatPro == PurchaseTypeEnum_Material_Procedure.MaterialProcurement)
                    {
                        if (purchaseProject.CurrentStateDefID == PurchaseProject.States.Completed && includeCompleteds)
                            addRow = true;
                        if (purchaseProject.CurrentStateDefID != PurchaseProject.States.Completed && includeActives)
                            addRow = true;
                        
                        if(addRow)
                            this.AddProjectRow(purchaseProject);
                        
                        addRow = false;
                    }
                }
            }
            else
            {
                InfoBox.Show("Bu kriterlere uygun dosya bulunamadı");
            }
#endregion SupplyTrackingForm_cmdSeachByProject_Click
        }

        private void txt1ProjectNo_TextChanged()
        {
#region SupplyTrackingForm_txt1ProjectNo_TextChanged
   if(string.IsNullOrEmpty(txt1ProjectNo.Text))
            {
                txt1ConfirmNo.ReadOnly = false;
                chkActives.ReadOnly = false;
                chkCompleteds.ReadOnly = false;
            }
            else
            {
                txt1ConfirmNo.ReadOnly = true;
                chkActives.ReadOnly = true;
                chkCompleteds.ReadOnly = true;
            }
#endregion SupplyTrackingForm_txt1ProjectNo_TextChanged
        }

        private void txt1ConfirmNo_TextChanged()
        {
#region SupplyTrackingForm_txt1ConfirmNo_TextChanged
   if(string.IsNullOrEmpty(txt1ConfirmNo.Text))
            {
                txt1ProjectNo.ReadOnly = false;
                chkActives.ReadOnly = false;
                chkCompleteds.ReadOnly = false;
            }
            else
            {
                txt1ProjectNo.ReadOnly = true;
                chkActives.ReadOnly = true;
                chkCompleteds.ReadOnly = true;
            }
#endregion SupplyTrackingForm_txt1ConfirmNo_TextChanged
        }

        private void cmdSearchByState_Click()
        {
#region SupplyTrackingForm_cmdSearchByState_Click
   SupplyTrackingByStateForm frm = new SupplyTrackingByStateForm();
            frm.ShowEdit(this.FindForm(), _SupplyTracking);
#endregion SupplyTrackingForm_cmdSearchByState_Click
        }

        private void cmdSeachByItem_Click()
        {
#region SupplyTrackingForm_cmdSeachByItem_Click
   if(txt2PItem.SelectedValue != null)
            {
                this.ClearGrids();
                PurchaseItemDef purchaseItemDef = (PurchaseItemDef)txt2PItem.SelectedObject;
                BindingList<PurchaseProject> projectList;
                projectList = PurchaseProject.GetAllProjects(_SupplyTracking.ObjectContext);
                ArrayList pList = new ArrayList();
                
                foreach(PurchaseProject purchaseProject in projectList)
                {
                    foreach(PurchaseProjectDetail purchaseProjectDetail in purchaseProject.PurchaseProjectDetails)
                    {
                        if(purchaseProjectDetail.PurchaseItemDef.ObjectID == purchaseItemDef.ObjectID)
                        {
                            if(!pList.Contains(purchaseProject))
                                pList.Add(purchaseProject);
                        }
                    }
                }
                
                if(pList.Count > 0)
                {
                    foreach(PurchaseProject pp in pList)
                    {
                        if(pp.PurchaseTypeMatPro == PurchaseTypeEnum_Material_Procedure.MaterialProcurement)
                        {
                            this.AddProjectRow(pp);
                        }
                    }
                }
                else
                {
                    InfoBox.Show("Bu satınalma kalemini kapsayan bir dosya bulunamadı");
                }
            }
#endregion SupplyTrackingForm_cmdSeachByItem_Click
        }

        private void txt3Supplier_SelectedObjectChanged()
        {
#region SupplyTrackingForm_txt3Supplier_SelectedObjectChanged
   if(txt3Supplier.SelectedObject == null)
            {
                txt3ContractNo.ReadOnly = false;
                txt3DecisionNo.ReadOnly = false;
            }
            else
            {
                txt3ContractNo.ReadOnly = true;
                txt3DecisionNo.ReadOnly = true;
            }
#endregion SupplyTrackingForm_txt3Supplier_SelectedObjectChanged
        }

        private void txt3ContractNo_TextChanged()
        {
#region SupplyTrackingForm_txt3ContractNo_TextChanged
   if(string.IsNullOrEmpty(txt3ContractNo.Text))
            {
                txt3DecisionNo.ReadOnly = false;
                txt3Supplier.ReadOnly = false;
            }
            else
            {
                txt3DecisionNo.ReadOnly = true;
                txt3Supplier.ReadOnly = true;
                txt3Supplier.SelectedObject = null;
            }
#endregion SupplyTrackingForm_txt3ContractNo_TextChanged
        }

        private void cmdSeachByContract_Click()
        {
#region SupplyTrackingForm_cmdSeachByContract_Click
   this.ClearGrids();
            string contractNo = txt3ContractNo.Text;
            string decisionNo = txt3DecisionNo.Text;
            ArrayList pList = new ArrayList();
            Supplier supplier = (Supplier)txt3Supplier.SelectedObject;
            
            if(txt3Supplier.SelectedObject != null)
            {
                BindingList<Contract> contracts;
                contracts = Contract.GetActiveContracts(_SupplyTracking.ObjectContext);
                if(contracts.Count == 0)
                {
                    InfoBox.Show("Bu firmaya ait aktif sipariş bulunamadı");
                    return;
                }
                
                foreach(Contract con in contracts)
                {
                    if(con.Supplier.ObjectID == supplier.ObjectID && con.PurchaseProject.PurchaseTypeMatPro == PurchaseTypeEnum_Material_Procedure.MaterialProcurement)
                        this.AddProjectRow(con.PurchaseProject);
                }
                return;
            }
            
            if(!string.IsNullOrEmpty(contractNo))
            {
                Contract tmpContract = null;
                BindingList<Contract> contractList;
                contractList = Contract.GetContractByNo(_SupplyTracking.ObjectContext, contractNo);
                if(contractList.Count > 1)
                    throw new TTUtils.TTException("Aynı numaralı iki sözleşme bulundu. Sistem yöneticisini arayınız");
                else if(contractList.Count == 1)
                {
                    Contract contract = (Contract)contractList[0];
                    if(supplier != null && contract.PurchaseProject.PurchaseTypeMatPro == PurchaseTypeEnum_Material_Procedure.MaterialProcurement)
                    {
                        if(supplier.ObjectID == contract.Supplier.ObjectID)
                            tmpContract = contract;
                    }
                    else
                        tmpContract = contract;
                }
                
                if(tmpContract != null)
                {
                    this.AddProjectRow(tmpContract.PurchaseProject);
                    _SupplyTracking.TmpPurchaseProject = tmpContract.PurchaseProject;
                    foreach(ITTGridRow row in ContractsGrid.Rows)
                    {
                        if(row.Cells["clm3ContractNo"].Value.ToString() == tmpContract.ContractNo)
                            ((TTGrid)ContractsGrid).Rows[row.Index].DefaultCellStyle.BackColor = System.Drawing.Color.SkyBlue;
                    }
                }
                else
                {
                    InfoBox.Show("Bu kriterlere uygun kayıt bulunamadı");
                }
            }
            else
            {
                BindingList<PurchaseProject> projectList;
                projectList = PurchaseProject.GetAllProjects(_SupplyTracking.ObjectContext);
                
                foreach(PurchaseProject pp in projectList)
                {
                    if(pp.PurchaseTypeMatPro == PurchaseTypeEnum_Material_Procedure.MaterialProcurement)
                    {
                        foreach(PurchaseProjectDetail ppd in pp.PurchaseProjectDetails)
                        {
                            if(ppd.ConclusionNO == decisionNo)
                            {
                                this.AddProjectRow(pp);
                                _SupplyTracking.TmpPurchaseProject = pp;
                                break;
                            }
                        }
                    }
                }
                
                if(_SupplyTracking.TmpPurchaseProject != null)
                {
                    foreach(ITTGridRow row in PurchaseItemsGrid.Rows)
                    {
                        if(((PurchaseProjectDetail)row.TTObject).ConclusionNO == decisionNo)
                            ((TTGrid)PurchaseItemsGrid).Rows[row.Index].DefaultCellStyle.BackColor = System.Drawing.Color.SkyBlue;
                    }
                }
                else
                {
                    InfoBox.Show("Bu kriterlere uygun kayıt bulunamadı");
                }
            }
#endregion SupplyTrackingForm_cmdSeachByContract_Click
        }

        private void txt3DecisionNo_TextChanged()
        {
#region SupplyTrackingForm_txt3DecisionNo_TextChanged
   if(string.IsNullOrEmpty(txt3DecisionNo.Text))
            {
                txt3ContractNo.ReadOnly = false;
                txt3Supplier.ReadOnly = false;
            }
            else
            {
                txt3ContractNo.ReadOnly = true;
                txt3Supplier.ReadOnly = true;
                txt3Supplier.SelectedObject = null;
            }
#endregion SupplyTrackingForm_txt3DecisionNo_TextChanged
        }

        private void txt4Supplier_SelectedObjectChanged()
        {
#region SupplyTrackingForm_txt4Supplier_SelectedObjectChanged
   if(txt4Supplier.SelectedObject == null)
                txt4OrderNo.ReadOnly = true;
            else
                txt4OrderNo.ReadOnly = false;
#endregion SupplyTrackingForm_txt4Supplier_SelectedObjectChanged
        }

        private void txt4DeliveryStartDate_ValueChanged()
        {
#region SupplyTrackingForm_txt4DeliveryStartDate_ValueChanged
            if(txt4DeliveryStartDate.NullableValue.HasValue)
            {
                txt4OrderNo.ReadOnly = true;
                txt4OrderStartDate.ReadOnly = true;
                txt4DeliveryEndDate.ReadOnly = false;
            }
            else
            {
                txt4OrderNo.ReadOnly = false;
                txt4OrderStartDate.ReadOnly = false;
                txt4DeliveryEndDate.ReadOnly = true;
            }
#endregion SupplyTrackingForm_txt4DeliveryStartDate_ValueChanged
        }

        private void txt4OrderNo_TextChanged()
        {
#region SupplyTrackingForm_txt4OrderNo_TextChanged
   if(string.IsNullOrEmpty(txt4OrderNo.Text))
            {
                txt4DeliveryStartDate.ReadOnly = false;
                txt4OrderStartDate.ReadOnly = false;
                txt4Supplier.ReadOnly = false;
            }
            else
            {
                txt4DeliveryStartDate.ReadOnly = true;
                txt4OrderStartDate.ReadOnly = true;
                txt4Supplier.SelectedObject = null;
                txt4Supplier.ReadOnly = true;
            }
#endregion SupplyTrackingForm_txt4OrderNo_TextChanged
        }

        private void cmdSeachByOrder_Click()
        {
#region SupplyTrackingForm_cmdSeachByOrder_Click
   this.ClearGrids();
            
            BindingList<PurchaseOrder> orderList;
            int orderNo = 0;
            DateTime deliveryStart;
            DateTime deliveryEnd;
            DateTime orderStart;
            DateTime orderEnd;
            
            if(!string.IsNullOrEmpty(txt4OrderNo.Text))
                orderNo = Convert.ToInt32(txt4OrderNo.Text);
            
            Supplier supplier = (Supplier)txt4Supplier.SelectedObject;
            
            if(orderNo != 0)
            {
                orderList = PurchaseOrder.GetOrderByOrderNo(_SupplyTracking.ObjectContext, orderNo);
                if(orderList.Count > 1)
                    throw new TTUtils.TTException("Aynı numaralı iki sipariş bulundu. Sistem yöneticisini arayınız");
                else if(orderList.Count == 1)
                {
                    PurchaseOrder po = (PurchaseOrder)orderList[0];
                    if(po.PurchaseProject.PurchaseTypeMatPro != PurchaseTypeEnum_Material_Procedure.MaterialProcurement)
                        return;
                    this.AddProjectRow(po.PurchaseProject);
                    _SupplyTracking.TmpPurchaseProject = po.PurchaseProject;
                    _SupplyTracking.TmpPurchaseOrder = po;
                    _SupplyTracking.TmpContract = po.Contract;
                }
                else
                    InfoBox.Show("Bu kriterlere uygun kayıt bulunamadı");
            }
            else
            {
                if(txt4OrderStartDate.NullableValue.HasValue)
                {
                    orderStart = Convert.ToDateTime(txt4OrderStartDate.Text);
                    if(txt4OrderEndDate.NullableValue.HasValue)
                    {
                        orderEnd = Convert.ToDateTime(txt4OrderEndDate.Text);
                        orderList = PurchaseOrder.GetOrdersByOrderDate(_SupplyTracking.ObjectContext, orderStart, orderEnd);
                        SetResults(orderList, supplier);
                    }
                    else
                        InfoBox.Show("Bitiş tarihi girmediniz");
                }
                else if(txt4DeliveryStartDate.NullableValue.HasValue)
                {
                    deliveryStart = Convert.ToDateTime(txt4DeliveryStartDate.Text);
                    if(txt4DeliveryEndDate.NullableValue.HasValue)
                    {
                        deliveryEnd = Convert.ToDateTime(txt4DeliveryEndDate.Text);
                        orderList = PurchaseOrder.GetOrdersByDueDate(_SupplyTracking.ObjectContext, deliveryStart, deliveryEnd);
                        SetResults(orderList, supplier);
                    }
                    else
                        InfoBox.Show("Bitiş tarihi girmediniz");
                }
                else
                {
                    if(supplier == null)
                        InfoBox.Show("Hiçbir arama kriteri girmediniz");
                    else
                    {
                        orderList = PurchaseOrder.GetAllOrdersByFirm(_SupplyTracking.ObjectContext, supplier.ObjectID.ToString());
                        SetResults(orderList, supplier);
                    }
                }
            }
        }
        
        public void SetResults(BindingList<PurchaseOrder> list, Supplier supp)
        {
            PurchaseOrder lastOrder = null;
            
            foreach(PurchaseOrder po in list)
            {
                if(po.PurchaseProject.PurchaseTypeMatPro == PurchaseTypeEnum_Material_Procedure.MaterialProcurement)
                {
                    if(supp == null || po.Contract.Supplier == supp)
                    {
                        this.AddProjectRow(po.PurchaseProject);
                        lastOrder = po;
                    }
                }
            }
            
            if(lastOrder != null)
            {
                _SupplyTracking.TmpPurchaseProject = lastOrder.PurchaseProject;
                _SupplyTracking.TmpPurchaseOrder = lastOrder;
                _SupplyTracking.TmpContract = lastOrder.Contract;
            }
#endregion SupplyTrackingForm_cmdSeachByOrder_Click
        }

        private void txt4OrderStartDate_ValueChanged()
        {
#region SupplyTrackingForm_txt4OrderStartDate_ValueChanged
            if(txt4OrderStartDate.NullableValue.HasValue)
            {
                txt4OrderNo.ReadOnly = true;
                txt4DeliveryStartDate.ReadOnly = true;
                txt4OrderEndDate.ReadOnly = false;
            }
            else
            {
                txt4OrderNo.ReadOnly = false;
                txt4DeliveryStartDate.ReadOnly = false;
                txt4OrderEndDate.ReadOnly = true;
            }
#endregion SupplyTrackingForm_txt4OrderStartDate_ValueChanged
        }

        private void cmdSearchByMasterResource_Click()
        {
#region SupplyTrackingForm_cmdSearchByMasterResource_Click
   this.ClearGrids();

            if(txt5MasterResource.SelectedObject == null)
            {
                InfoBox.Show("Birim seçiniz");
                return;
            }
            
            BindingList<PurchaseProject> projectList;
            projectList = PurchaseProject.GetAllProjects(_SupplyTracking.ObjectContext);
            
            List<Guid> resources = new List<Guid>();
            List<PurchaseProject> relatedProjects = new List<PurchaseProject>();

            if(projectList.Count > 0)
            {
                foreach(PurchaseProject purchaseProject in projectList)
                {
                    //if(purchaseProject.PurchaseTypeMatPro == PurchaseTypeEnum_Material_Procedure.MaterialProcurement)
                    //{
                    resources.Clear();
                    foreach (PurchaseProjectDetail ppd in purchaseProject.PurchaseProjectDetails)
                    {
                        foreach (DemandDetail dd in ppd.DemandDetails)
                        {
                            if(resources.Contains(dd.Demand.MasterResource.ObjectID) == false)
                                resources.Add(dd.Demand.MasterResource.ObjectID);
                        }
                    }
                    
                    if (resources.Contains((Guid)txt5MasterResource.SelectedObjectID) && relatedProjects.Contains(purchaseProject) == false)
                        relatedProjects.Add(purchaseProject);
                    //}
                }
                
                foreach(PurchaseProject pp in relatedProjects)
                    this.AddProjectRow(pp);
            }
            else
            {
                InfoBox.Show("Bu kriterlere uygun dosya bulunamadı");
            }
#endregion SupplyTrackingForm_cmdSearchByMasterResource_Click
        }

        private void PurchaseItemsGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region SupplyTrackingForm_PurchaseItemsGrid_CellContentClick
   PurchaseProjectDetail ppd = (PurchaseProjectDetail)PurchaseItemsGrid.CurrentCell.OwningRow.TTObject;
            foreach(Contract c in ppd.PurchaseProject.Contracts)
            {
                if(c.CurrentStateDefID != Contract.States.Cancelled)
                {
                    foreach(ContractDetail cd in c.ContractDetails)
                    {
                        if(cd.PurchaseItemDef.ObjectID == ppd.PurchaseItemDef.ObjectID)
                        {
                            _SupplyTracking.TmpContract = c;
                            break;
                        }
                    }
                }
            }
            
            Color defaultCellBackColor = ((TTGrid)ProjectsGrid).Rows[0].DefaultCellStyle.BackColor;
            if(_SupplyTracking.TmpContract != null)
            {
                foreach(ITTGridRow row in ContractsGrid.Rows)
                {
                    if(((Contract)row.TTObject).ObjectID == _SupplyTracking.TmpContract.ObjectID)
                    {
                        ((TTGrid)ContractsGrid).Rows[row.Index].DefaultCellStyle.BackColor = System.Drawing.Color.SkyBlue;
                        foreach(ITTGridRow detRow in ContractDetailsGrid.Rows)
                        {
                            if(((ContractDetail)detRow.TTObject).PurchaseItemDef.ObjectID == ppd.PurchaseItemDef.ObjectID)
                                ((TTGrid)ContractDetailsGrid).Rows[detRow.Index].DefaultCellStyle.BackColor = System.Drawing.Color.SkyBlue;
                            else
                                ((TTGrid)ContractDetailsGrid).Rows[detRow.Index].DefaultCellStyle.BackColor = defaultCellBackColor;
                        }
                    }
                    else
                        ((TTGrid)ContractsGrid).Rows[row.Index].DefaultCellStyle.BackColor = defaultCellBackColor;
                }
            }
#endregion SupplyTrackingForm_PurchaseItemsGrid_CellContentClick
        }

        private void OrdersGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region SupplyTrackingForm_OrdersGrid_CellContentClick
   if(OrdersGrid.CurrentCell != null)
            {
                _SupplyTracking.TmpPurchaseOrder = (PurchaseOrder)OrdersGrid.CurrentCell.OwningRow.TTObject;
                
                if(OrdersGrid.CurrentCell.OwningColumn.Name == "clm4cmdShowOrder")
                {
                    TTObjectContext oc = new TTObjectContext(false);
                    TTObject ttObject = oc.GetObject(OrdersGrid.CurrentCell.OwningRow.TTObject.ObjectID,OrdersGrid.CurrentCell.OwningRow.TTObject.ObjectDef);
                    try
                    {
                        //TTObject ttObject = OrdersGrid.CurrentCell.OwningRow.TTObject;
                        TTForm frm = TTForm.GetEditForm(ttObject);
                        if (frm != null)
                        {
                            DialogResult dialog = frm.ShowEdit(this, ttObject);
                            if(dialog == DialogResult.OK)
                            {
                                //_SupplyTracking.ObjectContext.Save();
                                oc.Save();
                                ((ITTObject)_SupplyTracking.TmpPurchaseOrder).Refresh();
                                foreach(PurchaseOrderDetail pod in _SupplyTracking.TmpPurchaseOrder.PurchaseOrderDetails)
                                {
                                    ((ITTObject)pod).Refresh();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        oc.Dispose();
                        InfoBox.Show(ex);
                    }
                }
            }
#endregion SupplyTrackingForm_OrdersGrid_CellContentClick
        }

        private void ContractsGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region SupplyTrackingForm_ContractsGrid_CellContentClick
   if (ContractsGrid.CurrentCell!= null)
            {
                Contract contract = (Contract)ContractsGrid.CurrentCell.OwningRow.TTObject;
                _SupplyTracking.TmpContract = contract;
                
                if(ContractsGrid.CurrentCell.OwningColumn.Name == "cml3cmdShowContract")
                {
                    
                    TTObject ttObject = ContractsGrid.CurrentCell.OwningRow.TTObject;
                    ContractForm frm = new ContractForm();
                    if (frm != null)
                    {
                        frm.ShowEdit(this, ttObject);
                    }
                }
            }
#endregion SupplyTrackingForm_ContractsGrid_CellContentClick
        }

        private void cmdCheckAll1_Click()
        {
#region SupplyTrackingForm_cmdCheckAll1_Click
   ContractDetailsGrid.RefreshRows();
            foreach (ITTGridRow row in ContractDetailsGrid.Rows)
                row.Cells[clm5Check.Name].Value = true;
#endregion SupplyTrackingForm_cmdCheckAll1_Click
        }

        private void cmdUncheckAll1_Click()
        {
#region SupplyTrackingForm_cmdUncheckAll1_Click
   ContractDetailsGrid.RefreshRows();
            foreach (ITTGridRow row in ContractDetailsGrid.Rows)
                row.Cells[clm5Check.Name].Value = false;
#endregion SupplyTrackingForm_cmdUncheckAll1_Click
        }

        private void cmdCheckAll2_Click()
        {
#region SupplyTrackingForm_cmdCheckAll2_Click
   OrderDetailsGrid.RefreshRows();
            foreach (ITTGridRow row in OrderDetailsGrid.Rows)
                row.Cells[clm6Check.Name].Value = true;
#endregion SupplyTrackingForm_cmdCheckAll2_Click
        }

        private void cmdUncheckAll2_Click()
        {
#region SupplyTrackingForm_cmdUncheckAll2_Click
   OrderDetailsGrid.RefreshRows();
            foreach (ITTGridRow row in OrderDetailsGrid.Rows)
                row.Cells[clm6Check.Name].Value = false;
#endregion SupplyTrackingForm_cmdUncheckAll2_Click
        }

        private void cmdFireExamination_Click()
        {
#region SupplyTrackingForm_cmdFireExamination_Click
   string errStr = null;
            List<PurchaseOrderDetail> orderDetails = new List<PurchaseOrderDetail>();
            foreach (ITTGridRow row in OrderDetailsGrid.Rows)
            {
                if (Convert.ToBoolean(row.Cells[clm6Check.Name].Value) == true)
                    orderDetails.Add((PurchaseOrderDetail)row.TTObject);
            }

            if (orderDetails.Count == 0)
                errStr += "En az bir kalem seçiniz";

            foreach (PurchaseOrderDetail pod in orderDetails)
            {
                if (pod.Status != OrderDetailStatusEnum.IlkTeslimBekleniyor)
                    errStr += pod.PurchaseItemDef.ItemName + " - sipariş durumu muayene başlatmaya uygun değil";
            }

            if (string.IsNullOrEmpty(errStr))
            {
                TTObjectContext context = new TTObjectContext(false);
                PurchaseExamination purchaseExamination = new PurchaseExamination(context);
                purchaseExamination.CurrentStateDefID = PurchaseExamination.States.TemporaryAdmissionRegistry;
                purchaseExamination.Contract = orderDetails[0].PurchaseOrder.Contract;
                purchaseExamination.ManuelEntry = false;

                foreach (PurchaseOrderDetail pod in orderDetails)
                {
                    PurchaseExaminationDetail ped = new PurchaseExaminationDetail(context);
                    ped.PurchaseExamination = purchaseExamination;
                    ped.Amount = pod.Amount;
                    ped.PurchaseItemDef = pod.PurchaseItemDef;
                    ped.UnitPrice = pod.ContractDetail.UnitPrice;
                    ped.Material = pod.ContractDetail.Material;

                }
                TTForm frm = TTForm.GetEditForm((TTObject)purchaseExamination);
                DialogResult dialog = frm.ShowEdit(this.FindForm(), purchaseExamination);
                if (dialog == DialogResult.OK)
                {
                    context.Save();
                    this.Close();
                }
                else
                    context.Dispose();
            }
            else
                InfoBox.Show("Aşağıdaki hatalar tespit edildi\n" + errStr);
#endregion SupplyTrackingForm_cmdFireExamination_Click
        }

        private void cmdFireCheque_Click()
        {
#region SupplyTrackingForm_cmdFireCheque_Click
   //            string errStr = null;
//            List<PurchaseOrderDetail> orderDetails = new List<PurchaseOrderDetail>();
//            foreach (ITTGridRow row in OrderDetailsGrid.Rows)
//            {
//                if (Convert.ToBoolean(row.Cells[clm6Check.Name].Value) == true)
//                    orderDetails.Add((PurchaseOrderDetail)row.TTObject);
//            }
//
//            if (orderDetails.Count == 0)
//                errStr += "En az bir kalem seçiniz";
//
//            foreach (PurchaseOrderDetail pod in orderDetails)
//            {
//                if (pod.Status != OrderDetailStatusEnum.KurusluKesilecek)
//                    errStr += pod.PurchaseItemDef.ItemName + " - sipariş durumu kuruşlu kesmeye uygun değil";
//            }
//
//            if (string.IsNullOrEmpty(errStr))
//            {
//                TTObjectContext context = new TTObjectContext(false);
//                ChequeDocument chequeDocument = new ChequeDocument(context);
//                chequeDocument.CurrentStateDefID = ChequeDocument.States.New;
//                chequeDocument.InputMethod = InputMethodEnum.Order;
//                chequeDocument.ContractNumber = orderDetails[0].PurchaseOrder.Contract.ContractNo;
//                chequeDocument.ConclusionNumber = orderDetails[0].PurchaseOrder.Contract.ConclusionNo;
//                chequeDocument.Supplier = orderDetails[0].PurchaseOrder.Supplier;
//                MainStoreDefinition mainStore = CommonForm.SelectAllMainStoreDefinition(this);
//                if (mainStore == null)
//                {
//                    InfoBox.Show("Ana Depo Seçmeden İşleme Devam Edilemez", "Hata", MessageIconEnum.ErrorMessage);
//                    context.Dispose();
//                    return;
//                }
//                    
//                chequeDocument.Store = mainStore;
//                foreach (PurchaseOrderDetail pod in orderDetails)
//                {
//                    ChequeDocumentMaterial cdm = new ChequeDocumentMaterial(context);
//                    cdm.StockAction = (StockAction)chequeDocument;
//                    cdm.Material = pod.ContractDetail.Material;
//                    cdm.Amount = pod.Amount;
//                    cdm.UnitPrice = pod.ContractDetail.UnitPrice;
//                }
//                TTForm frm = TTForm.GetEditForm((TTObject)chequeDocument);
//                DialogResult dialog = frm.ShowEdit(this.FindForm(), chequeDocument);
//                if (dialog == DialogResult.OK)
//                {
//                    context.Save();
//                    this.Close();
//                }
//                else
//                    context.Dispose();
//            }
//            else
//                InfoBox.Show("Aşağıdaki hatalar tespit edildi\n" + errStr);
#endregion SupplyTrackingForm_cmdFireCheque_Click
        }

        protected override void PreScript()
        {
#region SupplyTrackingForm_PreScript
    base.PreScript();
            
            txt4OrderEndDate.Enabled = false;
            txt4DeliveryEndDate.Enabled = false;
            this.cmdOK.Visible = false;
            this.DropStateButton(SupplyTracking.States.Completed);
#endregion SupplyTrackingForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region SupplyTrackingForm_PostScript
    base.PostScript(transDef);
            
            this.ClearGrids();
#endregion SupplyTrackingForm_PostScript

            }
            
#region SupplyTrackingForm_Methods
        public void ClearGrids()
        {
            ProjectsGrid.Rows.Clear();
            _SupplyTracking.TmpPurchaseProject = null;
            _SupplyTracking.TmpContract = null;
            _SupplyTracking.TmpPurchaseOrder = null;
        }
        
        public void AddProjectRow(PurchaseProject purchaseProject)
        {
            ITTGridRow row = ProjectsGrid.Rows.Add();
            row.Cells["clmProjectNo"].Value = purchaseProject.PurchaseProjectNO;
            row.Cells["clmConfirmNo"].Value = purchaseProject.ConfirmNO;
            row.Cells["clmState"].Value = purchaseProject.CurrentStateDef.Description;
            row.Cells["clmGUID"].Value = purchaseProject.ObjectID;
        }
        
#endregion SupplyTrackingForm_Methods
    }
}