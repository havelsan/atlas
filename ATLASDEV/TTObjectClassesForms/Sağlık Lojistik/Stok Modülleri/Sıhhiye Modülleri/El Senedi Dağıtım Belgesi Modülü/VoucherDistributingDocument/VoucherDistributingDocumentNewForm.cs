
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
    /// El Senedi Dağıtım Belgesi
    /// </summary>
    public partial class VoucherDistributingDocumentNewForm : BaseVoucherDistributingDocumentForm
    {
        override protected void BindControlEvents()
        {
            StockActionOutDetails.CellContentClick += new TTGridCellEventDelegate(StockActionOutDetails_CellContentClick);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            StockActionOutDetails.CellContentClick -= new TTGridCellEventDelegate(StockActionOutDetails_CellContentClick);
            base.UnBindControlEvents();
        }

        private void StockActionOutDetails_CellContentClick(Int32 rowIndex, Int32 columnIndex)
        {
#region VoucherDistributingDocumentNewForm_StockActionOutDetails_CellContentClick
   if(StockActionOutDetails.CurrentCell.OwningColumn.Name =="Detail")
                this.ShowStockActionDetailForm((StockActionDetail)StockActionOutDetails.CurrentCell.OwningRow.TTObject);
#endregion VoucherDistributingDocumentNewForm_StockActionOutDetails_CellContentClick
        }

        protected override void PreScript()
        {
#region VoucherDistributingDocumentNewForm_PreScript
    base.PreScript();
            ((ITTListBoxColumn)((ITTGridColumn)this.StockActionOutDetails.Columns[Material.Name])).ListFilterExpression = "STOCKS.STORE=" + ConnectionManager.GuidToString(this._VoucherDistributingDocument.Store.ObjectID) + " AND STOCKS.INHELD > 0";
            this.DropStateButton(VoucherDistributingDocument.States.Completed);

            if (_VoucherDistributingDocument.StockActionSignDetails.Count == 0)
            {
                StockActionSignDetail stockActionSignDetail = _VoucherDistributingDocument.StockActionSignDetails.AddNew();
                stockActionSignDetail.SignUserType = SignUserTypeEnum.TeslimEden;
                if (_VoucherDistributingDocument.Store is SubStoreDefinition)
                    stockActionSignDetail.SignUser = ((SubStoreDefinition )_VoucherDistributingDocument.Store).StoreResponsible;

                stockActionSignDetail = _VoucherDistributingDocument.StockActionSignDetails.AddNew();
                stockActionSignDetail.SignUserType = SignUserTypeEnum.TeslimAlan;
                if (_VoucherDistributingDocument.DestinationStore is RoomStoreDefinition)
                    stockActionSignDetail.SignUser = ((RoomStoreDefinition)_VoucherDistributingDocument.DestinationStore).StoreResponsible;
            }
#endregion VoucherDistributingDocumentNewForm_PreScript

            }
            
#region VoucherDistributingDocumentNewForm_ClientSideMethods
        protected override void BarcodeRead(string value)
        {
            base.BarcodeRead(value);
            Material material = null;
            IBindingList materials = _VoucherDistributingDocument.ObjectContext.QueryObjects("MATERIAL", "BARCODE='" + value + "'");
            if (materials.Count == 0)
                InfoBox.Show(value + " UBB/Barkodlu malzeme bulunamad?.", MessageIconEnum.ErrorMessage);
            else if (materials.Count == 1)
                material = (Material)materials[0];
            else
            {
                MultiSelectForm multiSelectForm = new MultiSelectForm();
                foreach (Material m in materials)
                {
                    multiSelectForm.AddMSItem(m.Name, m.Name, m);
                }
                string key = multiSelectForm.GetMSItem(ParentForm, "Malzeme seçin");

                if (string.IsNullOrEmpty(key))
                    InfoBox.Show("Herhangibir malzeme seçilmedi.", MessageIconEnum.ErrorMessage);
                else
                    material = multiSelectForm.MSSelectedItemObject as Material;
            }

            if (material != null)
            {
                //Sarf edilecek miktar giri?i
                string retAmount = InputForm.GetText("İstenen Miktarı Giriniz.");
                Currency? amount = 0;
                if (string.IsNullOrEmpty(retAmount) == false)
                {
                    if (CurrencyType.TryConvertFrom(retAmount, false, out amount) == false)
                        throw new TTException(SystemMessage.GetMessageV3(1192, new string[] { retAmount.ToString() }));
                }
                VoucherDistributingDocumentMaterial returningDocument = _VoucherDistributingDocument.VoucherDistributingDocumentMaterials.AddNew();
                returningDocument.Material = material;
                returningDocument.RequireMaterial = amount;
            }
        }
        
#endregion VoucherDistributingDocumentNewForm_ClientSideMethods
    }
}