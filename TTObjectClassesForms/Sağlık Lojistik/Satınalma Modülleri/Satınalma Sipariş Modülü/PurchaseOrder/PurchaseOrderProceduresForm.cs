
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
    /// Teslimat Prodesürleri
    /// </summary>
    public partial class PurchaseOrderProceduresForm : TTForm
    {
        override protected void BindControlEvents()
        {
            DocumentsGrid.CellContentClick += new TTGridCellEventDelegate(DocumentsGrid_CellContentClick);
            InternalDocsGrid.CellContentClick += new TTGridCellEventDelegate(InternalDocsGrid_CellContentClick);
            cmdPrintReport.Click += new TTControlEventDelegate(cmdPrintReport_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            DocumentsGrid.CellContentClick -= new TTGridCellEventDelegate(DocumentsGrid_CellContentClick);
            InternalDocsGrid.CellContentClick -= new TTGridCellEventDelegate(InternalDocsGrid_CellContentClick);
            cmdPrintReport.Click -= new TTControlEventDelegate(cmdPrintReport_Click);
            base.UnBindControlEvents();
        }

        private void DocumentsGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region PurchaseOrderProceduresForm_DocumentsGrid_CellContentClick
   if(DocumentsGrid.CurrentCell == null)
                return;
            
            BaseCorrespondence bc = (BaseCorrespondence)DocumentsGrid.CurrentCell.OwningRow.TTObject;
            switch (DocumentsGrid.CurrentCell.OwningColumn.Name)
            {
                case "Show":
                    TTForm frm = TTForm.GetEditForm(bc);
                    if (frm != null)
                        frm.ShowEdit(this, bc);
                    break;
                case "Print":
                    bc.ObjectContext.Save();
                    //TODO: Daha sonra değerlendirilecek.
                    //bc.Print();
                    break;
                case "Delete":
                    bc.CurrentStateDefID = BaseCorrespondence.States.Cancelled;
                    bc.Update();
                    DocumentsGrid.RefreshRows();
                    break;
                default:
                    break;
            }
#endregion PurchaseOrderProceduresForm_DocumentsGrid_CellContentClick
        }

        private void InternalDocsGrid_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region PurchaseOrderProceduresForm_InternalDocsGrid_CellContentClick
   if(InternalDocsGrid.CurrentCell == null)
                return;
            
            InternalCorrespondenceKIMK bc = (InternalCorrespondenceKIMK)InternalDocsGrid.CurrentCell.OwningRow.TTObject;
            
            switch (InternalDocsGrid.CurrentCell.OwningColumn.Name)
            {
                case "Show2":
                    TTForm frm = TTForm.GetEditForm(bc);
                    if (frm != null)
                        frm.ShowEdit(this, bc);
                    break;
                case "Print2":
                    bc.ObjectContext.Save();
                    //TODO:Daha sonra değerlendirilecek
                    //bc.Print();
                    break;
                case "Delete2":
                    bc.CurrentStateDefID = InternalCorrespondenceKIMK.States.Cancelled;
                    bc.Update();
                    InternalDocsGrid.RefreshRows();
                    break;
                default:
                    break;
            }
#endregion PurchaseOrderProceduresForm_InternalDocsGrid_CellContentClick
        }

        private void cmdPrintReport_Click()
        {
#region PurchaseOrderProceduresForm_cmdPrintReport_Click
   string mainType;
            
            MultiSelectForm pForm = new MultiSelectForm();
            pForm.AddMSItem("Karargah İçi", "Karargah İçi");
            pForm.AddMSItem("Karargah Dışı", "Karargah Dışı");
            mainType = pForm.GetMSItem(this, "Yazı Türü");
            pForm.ClearMSItems();
            if(mainType == "Karargah Dışı")
            {
                pForm.AddMSItem("Teminat İadesi", "Teminat İadesi");
                pForm.AddMSItem("İhtarname İsteği", "İhtarname İsteği");
                pForm.AddMSItem("İhtarname", "İhtarname");
                pForm.AddMSItem("Red Edilen Malzeme", "Red Edilen Malzeme");
                pForm.AddMSItem("Teminatın Hazineye İrad Kaydı", "Teminatın Hazineye İrad Kaydı");
                BaseCorrespondence bc = new BaseCorrespondence(_PurchaseOrder.ObjectContext);
                bc.CurrentStateDefID = BaseCorrespondence.States.New;
                bc.PurchaseOrder = _PurchaseOrder;
                bc.Subject = pForm.GetMSItem(this, "Konu");
                
                TTForm frm = TTForm.GetEditForm(bc);
                if (frm != null)
                    frm.ShowEdit(this.FindForm(), bc);
            }
            else if(mainType == "Karargah İçi")
            {
                pForm.AddMSItem("Teminat İadesi", "Teminat İadesi");
                pForm.AddMSItem("İhtarname İsteği", "İhtarname İsteği");
                pForm.AddMSItem("Muayene Muhtırası Hk.", "Muayene Muhtırası Hk.");
                InternalCorrespondenceKIMK ic = new InternalCorrespondenceKIMK(_PurchaseOrder.ObjectContext);
                ic.CurrentStateDefID = InternalCorrespondenceKIMK.States.New;
                ic.PurchaseOrder = _PurchaseOrder;
                ic.Subject = pForm.GetMSItem(this, "Konu");
                TTForm frm = TTForm.GetEditForm(ic);
                if (frm != null)
                    frm.ShowEdit(this.FindForm(), ic);
            }
            else
            {
                return;
            }
#endregion PurchaseOrderProceduresForm_cmdPrintReport_Click
        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region PurchaseOrderProceduresForm_PostScript
    base.PostScript(transDef);
            
            if(_PurchaseOrder.TransDef == null)
                return;
            
            if(_PurchaseOrder.TransDef.ToStateDefID == PurchaseOrder.States.Cancelled)
            {
                string msg = _PurchaseOrder.CheckActiveExaminations();
                if(string.IsNullOrEmpty(msg) == false)
                    throw new TTUtils.TTException(SystemMessage.GetMessage(61) + msg);
            }
            else if(_PurchaseOrder.TransDef.ToStateDefID == PurchaseOrder.States.Completed)
            {
                if (_PurchaseOrder.CheckCompletability() == false)
                    throw new TTUtils.TTException(SystemMessage.GetMessage(62));
            }
#endregion PurchaseOrderProceduresForm_PostScript

            }
            
#region PurchaseOrderProceduresForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
//            ArrayList printList = new ArrayList();
//            BaseCorrespondence bc = (BaseCorrespondence)_PurchaseOrder.BaseCorrespondences[0];
//            
//            foreach(DistributionPlace dp in bc.DistributionPlaces)
//            {
//                printList.Add(dp.DistributionLine);
//            }
//            
//            foreach(Info info in bc.Infos)
//            {
//                printList.Add(info.InfoLine);
//            }
//            
//            foreach(string s in printList)
//            {
//                Dictionary<string, TTReportTool.PropertyCache<object>> parameters = new Dictionary<string, TTReportTool.PropertyCache<object>>();
//                
//                TTReportTool.PropertyCache<object> objID = new TTReportTool.PropertyCache<object>();
//                objID.Add("VALUE", bc.ObjectID.ToString());
//                TTReportTool.PropertyCache<object> to = new TTReportTool.PropertyCache<object>();
//                to.Add("VALUE", s);
//                
//                parameters.Add("TTOBJECTID",objID);
//                parameters.Add("TO",to);
//                
//                TTReportTool.TTReport.PrintReport(typeof(TTReportClasses.I_NonMilitaryCorrespondence), true, 1, parameters);
//            }
        }
        
#endregion PurchaseOrderProceduresForm_Methods
    }
}