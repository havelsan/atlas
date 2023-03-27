
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
    /// Diyaliz 
    /// </summary>
    public partial class DialysisOrderForm : BaseDialysisOrderForm
    {
        override protected void BindControlEvents()
        {
            OrderDetails.CellDoubleClick += new TTGridCellEventDelegate(OrderDetails_CellDoubleClick);
            OrderDetails.CellValueChanged += new TTGridCellEventDelegate(OrderDetails_CellValueChanged);
            OrderDetails.CellContentClick += new TTGridCellEventDelegate(OrderDetails_CellContentClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            OrderDetails.CellDoubleClick -= new TTGridCellEventDelegate(OrderDetails_CellDoubleClick);
            OrderDetails.CellValueChanged -= new TTGridCellEventDelegate(OrderDetails_CellValueChanged);
            OrderDetails.CellContentClick -= new TTGridCellEventDelegate(OrderDetails_CellContentClick);
            base.UnBindControlEvents();
        }

        private void OrderDetails_CellDoubleClick(Int32 rowIndex, Int32 columnIndex)
        {
#region DialysisOrderForm_OrderDetails_CellDoubleClick
   //            if (this.OrderDetails.CurrentCell.RowIndex < this._DialysisOrder.OrderDetails.Count)
//            {
//                DialysisOrderDetail orderDetail = (DialysisOrderDetail)this._DialysisOrder.OrderDetails[this.OrderDetails.CurrentCell.RowIndex];
//                TTForm frm = TTForm.GetEditForm(orderDetail);
//                if (frm == null)
//                {
//                    MessageBox.Show(orderDetail.CurrentStateDef.Name + " isimli adım için form tanımı yapılmadığından işlem açılamamaktadır");
//                }
//                else
//                {
//                    frm.ObjectUpdated += new ObjectUpdatedDelegate(ShowAction_ObjectUpdated);
//                    frm.ShowEdit(this.FindForm(),orderDetail);
//                }
//            }
#endregion DialysisOrderForm_OrderDetails_CellDoubleClick
        }

        private void OrderDetails_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region DialysisOrderForm_OrderDetails_CellValueChanged
   ITTGridCell changedCell = OrderDetails.Rows[rowIndex].Cells[columnIndex];
            if (changedCell.OwningColumn.Name == DrAnesteziTescilNo.Name)
            {
                if(changedCell.Value != null)
                {
                    DialysisOrderDetail obj=(DialysisOrderDetail)changedCell.OwningRow.TTObject;
                    TTObjectContext context = _DialysisOrder.ObjectContext;
                    ResUser user = (ResUser)context.GetObject(new Guid(changedCell.Value.ToString()), typeof(ResUser));
                    obj.DrAnesteziTescilNo = user.DiplomaRegisterNo;
                }
                
                
            }
#endregion DialysisOrderForm_OrderDetails_CellValueChanged
        }

        private void OrderDetails_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
            #region DialysisOrderForm_OrderDetails_CellContentClick
            //TODO:ShowEdit!
            //if ((((ITTGridCell)OrderDetails.CurrentCell).OwningColumn != null) && (((ITTGridCell)OrderDetails.CurrentCell).OwningColumn.Name == "CokluOzelDurum"))
            //         {
            //             DialysisOrderDetail_CokluOzelDurumForm codf = new DialysisOrderDetail_CokluOzelDurumForm();
            //             DialysisOrderDetail inp = (DialysisOrderDetail)OrderDetails.CurrentCell.OwningRow.TTObject;
            //             codf.ShowEdit(this.FindForm(), inp);
            //         }
            var a = 1;
            #endregion DialysisOrderForm_OrderDetails_CellContentClick
        }

        protected override void PreScript()
        {
#region DialysisOrderForm_PreScript
    base.PreScript();
            
            if(this._DialysisOrder.CurrentStateDefID != DialysisOrder.States.Aborted)
            {
                this.labelReasonOfAbort.Visible = false;
                this.ReasonOfAbort.Visible = false;
            }
            
            if (this._DialysisOrder.CurrentStateDefID == DialysisOrder.States.Therapy)
            {
                if (this._DialysisOrder.PrevState.StateDefID != DialysisOrder.States.ApprovalForAbort)
                {
                    this.labelAbortRequestDescription.Visible = false;
                    this.AbortRequestDescription.Visible = false;
                    this.labelDoctorReturnDescription.Visible = false;
                    this.DoctorReturnDescription.Visible = false;
                }
            }
            
            if (this._DialysisOrder.CurrentStateDefID == DialysisOrder.States.RequestAcception)
            {
                this.DropStateButton(DialysisOrder.States.Rejected);
            }
            
            if (this._DialysisOrder.CurrentStateDefID == DialysisOrder.States.ApprovalForAbort)
            {
                if(this._DialysisOrder.PrevState.PrevState.StateDefID != DialysisOrder.States.ApprovalForAbort)
                {
                    this.labelDoctorReturnDescription.Visible = false;
                    this.DoctorReturnDescription.Visible = false;
                }
            }
            
            bool found=false;
            foreach (DialysisOrderDetail dOrderDetail in this._DialysisOrder.OrderDetails)
            {
                if (dOrderDetail.CurrentStateDefID == DialysisOrderDetail.States.Execution)
                {
                    found=true;
                }
            }
            if (found)
            {
                this.DropStateButton(DialysisOrder.States.Completed);
            }
            else
            {
                this.DropStateButton(DialysisOrder.States.ApprovalForAbort);
            }
#endregion DialysisOrderForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region DialysisOrderForm_PostScript
    base.PostScript(transDef);
#endregion DialysisOrderForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region DialysisOrderForm_ClientSidePostScript
    if(transDef!=null)
            {
                StringEntryForm rtfForm = new StringEntryForm();
                if(transDef.ToStateDefID==DialysisOrder.States.Aborted)
                {
                    if(PlannedAction.HasOrderDetailOnGivenState(DialysisOrderDetail.States.Execution, _DialysisOrder))
                    {
                        string result = ShowBox.Show(ShowBoxTypeEnum.Message,"&Evet,&Hayır","E,H","Uyarı","Uyarı","Kürü sonlandırırsanız, tamamlanmamış diyaliz uygulamaları iptal edilir. Devam etmek istediğinize emin misiniz?", 1);
                        if (result == "H")
                            throw new Exception("Kürü sonlandırmaktan vazgeçildi.");
                    }
                }
                else if(transDef.ToStateDefID == DialysisOrder.States.ApprovalForAbort)
                {
                    string result = ShowBox.Show(ShowBoxTypeEnum.Message,"&Evet,&Hayır","E,H","Uyarı","Uyarı","İşlem hekime iade edilecektir. Hekim, işlemi durdurma yetkisine sahiptir. Devam etmek istediğinize emin misiniz?", 1);
                    if (result == "H")
                        throw new Exception("Hekime iade etmekten vazgeçildi.");
                    this.templateRTF.Rtf = rtfForm.ShowAndGetStringForm("Hekime İade Sebebi");
                    this.AbortRequestDescription.Text = this.AbortRequestDescription.Text + "\r\n" + Common.RecTime().ToString() + " " + this.templateRTF.Text;
                }
                else if(transDef.ToStateDefID == DialysisOrder.States.Therapy)
                {
                    this.templateRTF.Rtf = rtfForm.ShowAndGetStringForm("Tedavi Devam İstek Sebebi");
                    this.DoctorReturnDescription.Text = this.DoctorReturnDescription.Text + "\r\n" + Common.RecTime().ToString() + " " + this.templateRTF.Text;
                }
            }
            
            base.ClientSidePostScript(transDef);
#endregion DialysisOrderForm_ClientSidePostScript

        }

#region DialysisOrderForm_Methods
        //        void ShowAction_ObjectUpdated(TTObject ttObject)
//        {
//            
//            OnObjectUpdated(ttObject);
//            //orderdetailler update olunca hepsi  bittiyse kür sonlandır butonu kalkması için ama çalışmıyor
//            //            bool found=false;
//            //            foreach (DialysisOrderDetail dOrderDetail in this._DialysisOrder.OrderDetails)
//            //            {
//            //                if (dOrderDetail.CurrentStateDefID == DialysisOrderDetail.States.Execution)
//            //                {
//            //                    found=true;
//            //                }
//            //            }
//            //            if (found==false)
//            //            {
//            //                this.DropStateButton(DialysisOrderDetail.States.Aborted);
//            //            }
//            
//        }
        
#endregion DialysisOrderForm_Methods
    }
}