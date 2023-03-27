
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
    /// Hemşireye Emirler
    /// </summary>
    public partial class NursingOrderForm : TTForm
    {
        override protected void BindControlEvents()
        {
            OrderDetails.CellDoubleClick += new TTGridCellEventDelegate(OrderDetails_CellDoubleClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            OrderDetails.CellDoubleClick -= new TTGridCellEventDelegate(OrderDetails_CellDoubleClick);
            base.UnBindControlEvents();
        }

        private void OrderDetails_CellDoubleClick(Int32 rowIndex, Int32 columnIndex)
        {
#region NursingOrderForm_OrderDetails_CellDoubleClick
   //Çift tıklanan NursingOrderDetail ın formunu açar.
//            if (this.OrderDetails.Rows.Count > rowIndex && rowIndex>-1)
//            {
//                NursingOrderDetailForm nursingOrderDetailForm = new NursingOrderDetailForm();
//                NursingOrderDetail nursingOrderDetail =(NursingOrderDetail) ((ITTGridRow)this.OrderDetails.Rows[rowIndex]).TTObject;
//                if(nursingOrderDetail!=null)
//                    nursingOrderDetailForm.ShowEdit(this.FindForm(),nursingOrderDetail);
//            }
#endregion NursingOrderForm_OrderDetails_CellDoubleClick
        }

        protected override void PreScript()
        {
#region NursingOrderForm_PreScript
    if (this.ProcedureObject.SelectedObjectID==null|| this.RecurrenceDayAmount==null || this.AmountForPeriod == null )
            {
                this.ProcedureObject.Enabled=true;
                this.PeriodStartTime.Enabled=true;
                this.Frequency.Enabled=true;
                this.RecurrenceDayAmount.Enabled=true;
                this.AmountForPeriod.Enabled=true;
            }
            else
            {
                this.ProcedureObject.Enabled=false;
                this.PeriodStartTime.Enabled=false;
                this.Frequency.Enabled=false;
                this.RecurrenceDayAmount.Enabled=false;
                this.AmountForPeriod.Enabled=false;
            }
            

//            if (this.OrderDetails.Rows.Count>0)
//            {
//                int count=this.OrderDetails.Rows.Count-1;
//                for ( int i=0;i<count;i++)
//                {
//                    NursingOrderDetail orderDetail = (NursingOrderDetail)this._NursingOrder.OrderDetails[i];
//                    if(orderDetail.IsCancelled)
//                    {
//                        this.OrderDetails.Rows[i].Cells["State"].Value="İptal Edildi";
//                    }
//                    else
//                    {
//                        if(orderDetail.CurrentStateDefID==NursingOrderDetail.States.Execution)
//                            this.OrderDetails.Rows[i].Cells["State"].Value="Yeni";
//                        else if(orderDetail.CurrentStateDefID==NursingOrderDetail.States.Completed)
//                            this.OrderDetails.Rows[i].Cells["State"].Value="Uygulandı";
//                        else if(orderDetail.CurrentStateDefID==NursingOrderDetail.States.Cancelled)
//                            this.OrderDetails.Rows[i].Cells["State"].Value="Uygulanmadı";
//                    }
//                }
//            }
#endregion NursingOrderForm_PreScript

            }
            
        protected override void ClientSidePostScript(TTObjectStateTransitionDef transDef)
        {
#region NursingOrderForm_ClientSidePostScript
    base.ClientSidePostScript(transDef);
         
            if(transDef!=null)
            {
                if(transDef.ToStateDef.Status==StateStatusEnum.Cancelled)
                {
                    StringEntryForm frm = new StringEntryForm();
                    this._NursingOrder.ReasonOfCancel=frm.ShowAndGetStringForm("İşlem İptal Sebebi");
                }
            }
#endregion NursingOrderForm_ClientSidePostScript

        }
    }
}