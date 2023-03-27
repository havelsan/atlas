
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
    public partial class BaseSupplyRequestPoolForm
    {
        override protected void BindControlEvents()
        {
            this.SupplyRequestPoolDetails.CellValueChanged += new TTGridCellEventDelegate(SupplyRequestPoolDetails_CellValueChanged);
            this.SupplyRequestPoolDetails.CellContentClick += new TTGridCellEventDelegate(SupplyRequestPoolDetails_CellContentClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            this.SupplyRequestPoolDetails.CellValueChanged -= new TTGridCellEventDelegate(SupplyRequestPoolDetails_CellValueChanged);
            this.SupplyRequestPoolDetails.CellContentClick -= new TTGridCellEventDelegate(SupplyRequestPoolDetails_CellContentClick);
            base.UnBindControlEvents();
        }

        private void SupplyRequestPoolDetails_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
           
            if (SupplyRequestPoolDetails.CurrentCell.OwningColumn.Name == "ExcessAmountSupplyRequestPoolDetail")
            {
                SupplyRequestPoolDetail det = (SupplyRequestPoolDetail)SupplyRequestPoolDetails.CurrentCell.OwningRow.TTObject;
                if (det.ExcessAmount != null)
                {
                    det.PurchaseAmount = det.PurchaseAmount - det.ExcessAmount;
                    if (det.PurchaseAmount <= 0)
                    {
                        det.PurchaseAmount = 0;
                        det.SupplyRqstPlDetStatus = SupplyRqstPlDetStatusEnum.SupplyWithExcess;
                    }
                }
                else
                {
                    det.PurchaseAmount = det.Amount;
                    det.SupplyRqstPlDetStatus = SupplyRqstPlDetStatusEnum.ToBeSent;
                }
            }
          
        }

        private void SupplyRequestPoolDetails_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {


            if (SupplyRequestPoolDetails.CurrentCell.OwningColumn.Name == "SupplyRequestPoolDetailBtn")
            {
                SupplyRqstPlDetailForm detailForm = new SupplyRqstPlDetailForm();
                detailForm.ShowReadOnly(this, ((SupplyRequestPoolDetail)SupplyRequestPoolDetails.CurrentCell.OwningRow.TTObject));
            }

            if (SupplyRequestPoolDetails.CurrentCell.OwningColumn.Name == "MKYSExcessQueryBtn")
            {
                MKYSExcessForm detailForm = new MKYSExcessForm();
                detailForm.ShowEdit(this, ((SupplyRequestPoolDetail)SupplyRequestPoolDetails.CurrentCell.OwningRow.TTObject));
            }

           

        }


        #region BaseSupplyRequestPoolForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);
            if (transDef != null)
            {
                if (transDef.ToStateDefID == SupplyRequestPool.States.Approval)
                {
                    foreach (SupplyRequestPoolDetail poolDet in _SupplyRequestPool.SupplyRequestPoolDetails)
                    {
                        foreach (SupplyRequestDetail det in poolDet.SupplyRequestDetails)
                        {
                            det.SupplyRequestStatus = SupplyRequestStatusEnum.AccountingApproval;
                        }
                    }
                }


                if (transDef.ToStateDefID == SupplyRequestPool.States.Completed)
                {
                    foreach (SupplyRequestPoolDetail poolDet in _SupplyRequestPool.SupplyRequestPoolDetails)
                    {
                        if (poolDet.SupplyRqstPlDetStatus == SupplyRqstPlDetStatusEnum.ToBeSent)
                            poolDet.SupplyRqstPlDetStatus = SupplyRqstPlDetStatusEnum.Sent;

                        foreach (SupplyRequestDetail det in poolDet.SupplyRequestDetails)
                        {
                            if (poolDet.SupplyRqstPlDetStatus == SupplyRqstPlDetStatusEnum.Cancelled)
                                det.SupplyRequestStatus = SupplyRequestStatusEnum.RequestCancelled;

                            if (poolDet.SupplyRqstPlDetStatus == SupplyRqstPlDetStatusEnum.SupplyWithExcess)
                                det.SupplyRequestStatus = SupplyRequestStatusEnum.SupplyWithExcess;

                            if (poolDet.SupplyRqstPlDetStatus == SupplyRqstPlDetStatusEnum.Sent)
                                det.SupplyRequestStatus = SupplyRequestStatusEnum.RequestCompleted;
                        }
                    }
                }

            }

            _SupplyRequestPool.ObjectContext.Save();
        }
        #endregion BaseSupplyRequestPoolForm_Methods




    }
}