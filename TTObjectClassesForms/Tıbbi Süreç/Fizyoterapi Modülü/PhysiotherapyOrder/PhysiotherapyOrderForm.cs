
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
    /// Fizyoterapi
    /// </summary>
    public partial class PhysiotherapyOrderForm : BasePhysiotherapyOrderForm
    {
        override protected void BindControlEvents()
        {
            btnContinue.Click += new TTControlEventDelegate(btnContinue_Click);
            
            //OrderDetails.CellContentClick += new TTGridCellEventDelegate(OrderDetails_CellContentClick);
            //OrderDetails.CellDoubleClick += new TTGridCellEventDelegate(OrderDetails_CellDoubleClick);
            //OrderDetails.CellValueChanged += new TTGridCellEventDelegate(OrderDetails_CellValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            btnContinue.Click -= new TTControlEventDelegate(btnContinue_Click);
            //OrderDetails.CellContentClick -= new TTGridCellEventDelegate(OrderDetails_CellContentClick);
            //OrderDetails.CellDoubleClick -= new TTGridCellEventDelegate(OrderDetails_CellDoubleClick);
            //OrderDetails.CellValueChanged -= new TTGridCellEventDelegate(OrderDetails_CellValueChanged);
            base.UnBindControlEvents();
        }

        private void btnContinue_Click()
        {
#region PhysiotherapyOrderForm_btnContinue_Click
   this.CreateNewPhysiotherapyRequest();
#endregion PhysiotherapyOrderForm_btnContinue_Click
        }

        private void OrderDetails_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
            #region PhysiotherapyOrderForm_OrderDetails_CellContentClick
            //TODO:ShowEdit!
            //if (((ITTGridCell)OrderDetails.CurrentCell).OwningColumn.Name == "cokluOzelDurum")
            //         {
            //             PhysiotherapyCokluOzelDurum pcod = new PhysiotherapyCokluOzelDurum();
            //             pcod.ShowEdit(this.FindForm(), this._PhysiotherapyOrder);
            //         }

            // Dr. Anestezi Tescil No'da Dr. adlarını listeler 
            //            if (((ITTGridCell)OrderDetails.CurrentCell).OwningColumn.Name == "drAnesteziTescilNo")
            //            {
            //                ResUser resUser=(ResUser) this.TTListBoxDrAnesteziTescilNo.SelectedObject;
            //                _DentalExamination.DrAnesteziTescilNo= (resUser.DiplomaRegisterNo == null)? null : resUser.DiplomaRegisterNo.ToString();
            //                //_DentalExamination.DrAnesteziTescilNo = _DentalExamination.ResUser.DiplomaRegisterNo.ToString();
            //            }
            var a = 1;
#endregion PhysiotherapyOrderForm_OrderDetails_CellContentClick
        }

        private void OrderDetails_CellDoubleClick(Int32 rowIndex, Int32 columnIndex)
        {
#region PhysiotherapyOrderForm_OrderDetails_CellDoubleClick
   //
            //            if (rowIndex< this.OrderDetails.Rows.Count && rowIndex>-1)
            //            {
            //                PhysiotherapyOrderDetail orderDetail = (PhysiotherapyOrderDetail)((ITTGridRow)this.OrderDetails.Rows[rowIndex]).TTObject;
            //                if(orderDetail!=null)
            //                {
            //                    TTForm frm = TTForm.GetEditForm(orderDetail);
            //                    if (frm == null)
            //                    {
            //                        MessageBox.Show(orderDetail.CurrentStateDef.Name + " isimli adım için form tanımı yapılmadığından işlem açılamamaktadır");
            //                    }
            //                    else
            //                    {
            //                        frm.ObjectUpdated += new ObjectUpdatedDelegate(ShowAction_ObjectUpdated);
            //                        frm.ShowEdit(this.FindForm(),orderDetail);
            //                    }
            //                    //                Guid actionID =(Guid) this._PhysiotherapyOrder.OrderDetails[this.OrderDetails.CurrentCell.RowIndex].ObjectID;
            //                    //                TTObjectContext objectContext = new TTObjectContext(false);
            //                    //                try
            //                    //                {
            //                    //                    PhysiotherapyOrderDetail  orderDetail = (PhysiotherapyOrderDetail)(objectContext.GetObject(actionID, typeof(PhysiotherapyOrderDetail)));
            //                    //                    TTForm frm = TTForm.GetEditForm(orderDetail);
            //                    //                    if (frm == null)
            //                    //                    {
            //                    //                        MessageBox.Show(orderDetail.CurrentStateDef.Name + " isimli adım için form tanımı yapılmadığından işlem açılamamaktadır");
            //                    //                    }
            //                    //                    frm.ObjectUpdated += new ObjectUpdatedDelegate(ShowAction_ObjectUpdated);
            //                    //                    frm.ShowEdit(this.FindForm(),orderDetail);
            //                    //                }
            //                    //                catch (System.Exception ex)
            //                    //                {
            //                    //                    MessageBox.Show(ex.ToString());
            //                    //                }
            //                    //                finally
            //                    //                {
            //                    //                    objectContext.Dispose();
            //                    //                }
            //                }
            //
#endregion PhysiotherapyOrderForm_OrderDetails_CellDoubleClick
        }

        private void OrderDetails_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region PhysiotherapyOrderForm_OrderDetails_CellValueChanged
   // MT Griddeki DrAnesteziTescilNo seçildiğinde doktor adı listesi açılır
            //ITTGridCell changedCell = OrderDetails.Rows[rowIndex].Cells[columnIndex];
            
            //if (changedCell.OwningColumn.Name == this.drAnesteziTescilNo.Name)
            //{
            //    if(changedCell.Value != null)
            //    {
            //        PhysiotherapyOrderDetail obj = (PhysiotherapyOrderDetail)changedCell.OwningRow.TTObject;
            //        TTObjectContext context = this._PhysiotherapyOrder.ObjectContext;
            //        ResUser user = (ResUser)context.GetObject(new Guid(changedCell.Value.ToString()), typeof(ResUser));
            //        obj.drAnesteziTescilNo = user.DiplomaRegisterNo;
            //    }
            //}
#endregion PhysiotherapyOrderForm_OrderDetails_CellValueChanged
        }

        protected override void PreScript()
        {
#region PhysiotherapyOrderForm_PreScript
    base.PreScript();
            //if (this._PhysiotherapyOrder.CurrentStateDefID != PhysiotherapyOrder.States.Aborted)
            //{
            //    this.labelReasonOfAbort.Visible = false;
            //    this.ReasonOfAbort.Visible = false;
            //}

            //if (this._PhysiotherapyOrder.CurrentStateDefID == PhysiotherapyOrder.States.Therapy)
            //{
            //    if (this._PhysiotherapyOrder.PrevState.StateDefID != PhysiotherapyOrder.States.ApprovalForAbort)
            //    {
            //        this.labelAbortRequestDescription.Visible = false;
            //        this.AbortRequestDescription.Visible = false;
            //        this.labelDoctorReturnDescription.Visible = false;
            //        this.DoctorReturnDescription.Visible = false;
            //    }
            //}

            //if (this._PhysiotherapyOrder.CurrentStateDefID == PhysiotherapyOrder.States.ApprovalForAbort)
            //{
            //    if (this._PhysiotherapyOrder.PrevState.PrevState.StateDefID != PhysiotherapyOrder.States.ApprovalForAbort)
            //    {
            //        this.labelDoctorReturnDescription.Visible = false;
            //        this.DoctorReturnDescription.Visible = false;
            //    }
            //}
            //bool found = false;
            //foreach (PhysiotherapyOrderDetail pOrderDetail in this._PhysiotherapyOrder.OrderDetails)
            //{
            //    if (pOrderDetail.CurrentStateDefID == PhysiotherapyOrderDetail.States.Execution)
            //    {
            //        found = true;
            //    }
            //}
            //if (found)
            //{
            //    this.DropStateButton(PhysiotherapyOrder.States.Completed);
            //}
            //else
            //{
            //    this.DropStateButton(PhysiotherapyOrder.States.ApprovalForAbort);
            //}
            //if (this._PhysiotherapyOrder.CurrentStateDefID != PhysiotherapyOrder.States.ApprovalForAbort)
            //{
            //    btnContinue.Visible = false;
            //}
#endregion PhysiotherapyOrderForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region PhysiotherapyOrderForm_PostScript
    base.PostScript(transDef);
#endregion PhysiotherapyOrderForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region PhysiotherapyOrderForm_ClientSidePostScript
    if (transDef != null)
            {
                StringEntryForm rtfForm = new StringEntryForm();
                //if (transDef.ToStateDefID == PhysiotherapyOrder.States.Aborted)
                //{
                //    if(PlannedAction.HasOrderDetailOnGivenState(PhysiotherapyOrderDetail.States.Execution, _PhysiotherapyOrder))
                //    {
                //        string result = ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Uyarı", "Kürü sonlandırırsanız, tamamlanmamış fizyoterapi uygulamaları iptal edilir. Devam etmek istediğinize emin misiniz?", 1);
                //        if (result == "H")
                //            throw new Exception("Kürü sonlandırmaktan vazgeçildi.");
                //    }
                //}
                //else if (transDef.ToStateDefID == PhysiotherapyOrder.States.ApprovalForAbort)
                //{
                //    string result = ShowBox.Show(ShowBoxTypeEnum.Message, "&Evet,&Hayır", "E,H", "Uyarı", "Uyarı", "İşlem hekime iade edilecektir. Hekim, işlemi durdurma yetkisine sahiptir. Devam etmek istediğinize emin misiniz?", 1);
                //    if (result == "H")
                //        throw new Exception("Hekime iade etmekten vazgeçildi.");
                //    this.templateRTF.Rtf = rtfForm.ShowAndGetStringForm("Hekime İade Sebebi");
                //    this.AbortRequestDescription.Text = this.AbortRequestDescription.Text + "\r\n" + Common.RecTime().ToString() + " " + this.templateRTF.Text;
                //}
                //else if (transDef.ToStateDefID == PhysiotherapyOrder.States.Therapy)
                //{
                //    this.templateRTF.Rtf = rtfForm.ShowAndGetStringForm("Tedavi Devam İstek Sebebi");
                //    this.DoctorReturnDescription.Text = this.DoctorReturnDescription.Text + "\r\n" + Common.RecTime().ToString() + " " + this.templateRTF.Text;
                //}
                //else if (transDef.ToStateDefID == PhysiotherapyOrder.States.Cancelled)
                //{
                //    bool isThereCompleted = false;
                //    if(PlannedAction.HasOrderDetailOnGivenState(PhysiotherapyOrderDetail.States.Completed, _PhysiotherapyOrder))
                //    {
                //        throw new Exception("Tamamlanmış uygulaması bulunan fizyoterapi emrini iptal edemezsiniz! ");
                //    }
                //}
            }
            
            base.ClientSidePostScript(transDef);
#endregion PhysiotherapyOrderForm_ClientSidePostScript

        }

#region PhysiotherapyOrderForm_Methods
        //        void ShowAction_ObjectUpdated(TTObject ttObject)
        //        {
        //            OnObjectUpdated(ttObject);
        //            bool found=false;
        //            foreach (PhysiotherapyOrderDetail pOrderDetail in this._PhysiotherapyOrder.OrderDetails)
        //            {
        //                if (pOrderDetail.CurrentStateDefID == PhysiotherapyOrderDetail.States.Execution)
        //                {
        //                    found=true;
        //                }
        //            }
        //            if (found==false)
        //            {
        //                this.DropStateButton(PhysiotherapyOrder.States.Aborted);
        //            }
        //
        //        }



        //
        
#endregion PhysiotherapyOrderForm_Methods
    }
}