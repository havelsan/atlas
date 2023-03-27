
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
    public partial class PlannedMedicalActionOrderForm : BasePlannedMedicalActionOrderForm
    {
        override protected void BindControlEvents()
        {
            btnContinue.Click += new TTControlEventDelegate(btnContinue_Click);
            OrderDetails.CellValueChanged += new TTGridCellEventDelegate(OrderDetails_CellValueChanged);
            OrderDetails.CellContentClick += new TTGridCellEventDelegate(OrderDetails_CellContentClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            btnContinue.Click -= new TTControlEventDelegate(btnContinue_Click);
            OrderDetails.CellValueChanged -= new TTGridCellEventDelegate(OrderDetails_CellValueChanged);
            OrderDetails.CellContentClick -= new TTGridCellEventDelegate(OrderDetails_CellContentClick);
            base.UnBindControlEvents();
        }

        private void btnContinue_Click()
        {
#region PlannedMedicalActionOrderForm_btnContinue_Click
   this.CreateNewPlannedMedicalActionRequest();
#endregion PlannedMedicalActionOrderForm_btnContinue_Click
        }

        private void OrderDetails_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
#region PlannedMedicalActionOrderForm_OrderDetails_CellValueChanged
   ITTGridCell changedCell = OrderDetails.Rows[rowIndex].Cells[columnIndex];
            if (changedCell.OwningColumn.Name == DrAnesteziTescilNo.Name)
            {
                if(changedCell.Value != null)
                {
                    PlannedMedicalActionOrderDetail obj=(PlannedMedicalActionOrderDetail)changedCell.OwningRow.TTObject;
                    TTObjectContext context = _PlannedMedicalActionOrder.ObjectContext;
                    ResUser user = (ResUser)context.GetObject(new Guid(changedCell.Value.ToString()), typeof(ResUser));
                    obj.DrAnesteziTescilNo = user.DiplomaRegisterNo;
                }
                
                
            }
#endregion PlannedMedicalActionOrderForm_OrderDetails_CellValueChanged
        }

        private void OrderDetails_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
            #region PlannedMedicalActionOrderForm_OrderDetails_CellContentClick
            //TODO:ShowEdit!
            //if (((ITTGridCell)OrderDetails.CurrentCell).OwningColumn.Name == "CokluOzelDurum")
            //{
            //    PlannedMedicalActionOrderDetail_CokluOzelDurumForm codf = new PlannedMedicalActionOrderDetail_CokluOzelDurumForm();
            //    PlannedMedicalActionOrderDetail inp = (PlannedMedicalActionOrderDetail)OrderDetails.CurrentCell.OwningRow.TTObject;
            //    codf.ShowEdit(this.FindForm(), inp);
            //}
            var a = 1;
            #endregion PlannedMedicalActionOrderForm_OrderDetails_CellContentClick
        }

        protected override void PreScript()
        {
#region PlannedMedicalActionOrderForm_PreScript
    base.PreScript();
            if(this._PlannedMedicalActionOrder.CurrentStateDefID != PlannedMedicalActionOrder.States.Aborted)
            {
                this.labelReasonOfAbort.Visible = false;
                this.ReasonOfAbort.Visible = false;
            }
            
            if (this._PlannedMedicalActionOrder.CurrentStateDefID == PlannedMedicalActionOrder.States.Therapy)
            {
                if (this._PlannedMedicalActionOrder.PrevState.StateDefID != PlannedMedicalActionOrder.States.ApprovalForAbort)
                {
                    this.labelAbortRequestDescription.Visible = false;
                    this.AbortRequestDescription.Visible = false;
                    this.labelDoctorReturnDescription.Visible = false;
                    this.DoctorReturnDescription.Visible = false;
                }
            }
            
            if (this._PlannedMedicalActionOrder.CurrentStateDefID == PlannedMedicalActionOrder.States.ApprovalForAbort)
            {
                if(this._PlannedMedicalActionOrder.PrevState.PrevState.StateDefID != PlannedMedicalActionOrder.States.ApprovalForAbort)
                {
                    this.labelDoctorReturnDescription.Visible = false;
                    this.DoctorReturnDescription.Visible = false;
                }
            }
            bool found=false;
            foreach (PlannedMedicalActionOrderDetail pOrderDetail in this._PlannedMedicalActionOrder.OrderDetails)
            {
                if (pOrderDetail.CurrentStateDefID == PlannedMedicalActionOrderDetail.States.Execution)
                {
                    found=true;
                }
            }
            if (found)
            {
                this.DropStateButton(PlannedMedicalActionOrder.States.Completed);
            }
            else
            {
                this.DropStateButton(PlannedMedicalActionOrder.States.ApprovalForAbort);
            }
            if(this._PlannedMedicalActionOrder.CurrentStateDefID!=PlannedMedicalActionOrder.States.ApprovalForAbort)
            {
                btnContinue.Visible=false;
            }
#endregion PlannedMedicalActionOrderForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region PlannedMedicalActionOrderForm_PostScript
    base.PostScript(transDef);
#endregion PlannedMedicalActionOrderForm_PostScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region PlannedMedicalActionOrderForm_ClientSidePostScript
    if(transDef!=null)
            {
                
                if (transDef.ToStateDefID == PlannedMedicalActionOrder.States.Completed)
                {
                    if (this.ProcedureDoctor == null || this.ProcedureDoctor.SelectedObject == null)
                        throw new TTUtils.TTException("İstek yapan tabip bilgisini giriniz!");
                }

                StringEntryForm rtfForm = new StringEntryForm();
                if(transDef.ToStateDefID==PlannedMedicalActionOrder.States.Aborted)
                {
                    if(PlannedAction.HasOrderDetailOnGivenState(PlannedMedicalActionOrderDetail.States.Execution,_PlannedMedicalActionOrder))
                        {
                            string result = ShowBox.Show(ShowBoxTypeEnum.Message,"&Evet,&Hayır","E,H","Uyarı","Uyarı","Kürü sonlandırırsanız, tamamlanmamış planlı tıbbi işlem uygulamaları iptal edilir. Devam etmek istediğinize emin misiniz?", 1);
                            if (result == "H")
                                throw new Exception("Kürü sonlandırmaktan vazgeçildi.");
                        }
                }
                else if(transDef.ToStateDefID == PlannedMedicalActionOrder.States.ApprovalForAbort)
                {
                    string result = ShowBox.Show(ShowBoxTypeEnum.Message,"&Evet,&Hayır","E,H","Uyarı","Uyarı","İşlem hekime iade edilecektir. Hekim, işlemi durdurma yetkisine sahiptir. Devam etmek istediğinize emin misiniz?", 1);
                    if (result == "H")
                        throw new Exception("Hekime iade etmekten vazgeçildi.");
                    this.templateRTF.Rtf = rtfForm.ShowAndGetStringForm("Hekime İade Sebebi");
                    this.AbortRequestDescription.Text = this.AbortRequestDescription.Text + "\r\n" + Common.RecTime().ToString() + " " + this.templateRTF.Text;
                }
                else if(transDef.ToStateDefID == PlannedMedicalActionOrder.States.Therapy)
                {
                    this.templateRTF.Rtf = rtfForm.ShowAndGetStringForm("Tedavi Devam İstek Sebebi");
                    this.DoctorReturnDescription.Text = this.DoctorReturnDescription.Text + "\r\n" + Common.RecTime().ToString() + " " + this.templateRTF.Text;
                }
                
            }
            base.ClientSidePostScript(transDef);
#endregion PlannedMedicalActionOrderForm_ClientSidePostScript

        }
    }
}