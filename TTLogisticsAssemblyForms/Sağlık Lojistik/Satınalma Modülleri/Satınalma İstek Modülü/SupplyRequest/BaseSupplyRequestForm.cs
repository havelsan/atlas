
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
    /// Tedarik Talep Form
    /// </summary>
    public partial class BaseSupplyRequest : StockActionBaseForm
    {
        override protected void BindControlEvents()
        {
            this.SupplyRequestDetails.CellValueChanged += new TTGridCellEventDelegate(SupplyRequestDetails_CellValueChanged);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            this.SupplyRequestDetails.CellValueChanged -= new TTGridCellEventDelegate(SupplyRequestDetails_CellValueChanged);
            base.UnBindControlEvents();
        }

        private void SupplyRequestDetails_CellValueChanged(Int32 rowIndex, Int32 columnIndex)
        {
            #region SupplyRequestNewForm_SupplyRequestDetails_CellValueChanged
            SupplyRequestDetail detail = (SupplyRequestDetail)SupplyRequestDetails.CurrentCell.OwningRow.TTObject;
            if (SupplyRequestDetails.CurrentCell.OwningColumn.Name == "MaterialSupplyRequestDetail")
            {
                detail.DetailDescription = detail.Material.Name;
                //if (detail.Material.StockCard.PurchaseGroup != null)
                //{
                //    detail.PurchaseGroup = detail.Material.StockCard.PurchaseGroup;
                //}
                //else
                //{
                //    throw new Exception("Malzeme stok kartýnda istek kalemi tanýmlý deðildir!");
                //}

                if (detail.Material.StockCard.DistributionType != null)
                {
                    detail.DistributionType = detail.Material.StockCard.DistributionType;
                }
                else
                {
                    throw new Exception("Malzeme stok kartýnda ölçü birimi tanýmlý deðildir!");
                }


            }


            if (SupplyRequestDetails.CurrentCell.OwningColumn.Name == "SupplyRequestStatusSupplyRequestDetail" && _SupplyRequest.CurrentStateDefID == SupplyRequest.States.Approval)
            {

                if (detail.SupplyRequestStatus == SupplyRequestStatusEnum.RequestCompleted || detail.SupplyRequestStatus == SupplyRequestStatusEnum.SupplyWithExcess || detail.SupplyRequestStatus == SupplyRequestStatusEnum.AccountingApproval)
                {
                    throw new Exception("Sadece Ýstek Ýptal Edildi ve Ýstek durumu seçilebilir!");
                }
            }

            #endregion SupplyRequestNewForm_SupplyRequestDetails_CellValueChanged
        }


        protected override void PreScript()
        {
            #region BaseSupplyRequestForm_PreScript()





            #endregion BaseSupplyRequestForm_PreScript()
        }

    }
}