
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
    /// El Senedi İade Belgesi
    /// </summary>
    public partial class VoucherReturnDocumentNewForm : BaseVoucherReturnDocumentForm
    {
        protected override void PreScript()
        {
#region VoucherReturnDocumentNewForm_PreScript
    base.PreScript();

            if (this._VoucherReturnDocument.CurrentStateDefID == VoucherReturnDocument.States.New)
            {
                this.DropStateButton(VoucherReturnDocument.States.Completed);
                ((ITTListBoxColumn)((ITTGridColumn)this.StockActionOutDetails.Columns["Material"])).ListFilterExpression = "STOCKS.STORE='" + this._VoucherReturnDocument.Store.ObjectID.ToString() + "' AND STOCKS.INHELD>0";
            }

            if (_VoucherReturnDocument.StockActionSignDetails.Count == 0)
            {
                StockActionSignDetail stockActionSignDetail = _VoucherReturnDocument.StockActionSignDetails.AddNew();
                stockActionSignDetail.SignUserType = SignUserTypeEnum.TeslimAlan;
                if (_VoucherReturnDocument.DestinationStore is SubStoreDefinition)
                    stockActionSignDetail.SignUser = ((SubStoreDefinition)_VoucherReturnDocument.DestinationStore).StoreResponsible ;
                
                stockActionSignDetail = _VoucherReturnDocument.StockActionSignDetails.AddNew();
                stockActionSignDetail.SignUserType = SignUserTypeEnum.TeslimEden ;
                if (_VoucherReturnDocument.Store is RoomStoreDefinition)
                    stockActionSignDetail.SignUser = ((RoomStoreDefinition)_VoucherReturnDocument.Store).StoreResponsible;
           }
#endregion VoucherReturnDocumentNewForm_PreScript

            }
            
#region VoucherReturnDocumentNewForm_ClientSideMethods
        protected override void BarcodeRead(string value)
        {
            base.BarcodeRead(value);
            Material material = null;
            IBindingList materials = _VoucherReturnDocument.ObjectContext.QueryObjects("MATERIAL", "BARCODE='" + value + "'");
            if (materials.Count == 0)
                InfoBox.Show(value + " UBB/Barkodlu malzeme bulunamadı.", MessageIconEnum.ErrorMessage);
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
                    InfoBox.Show("Herhangi bir malzeme seçilmedi.", MessageIconEnum.ErrorMessage);
                else
                    material = multiSelectForm.MSSelectedItemObject as Material;
            }

            if (material != null)
            {
                //Sarf edilecek miktar giri?i
                string retAmount = InputForm.GetText("İade Miktarını Giriniz.");
                Currency? amount = 0;
                if (string.IsNullOrEmpty(retAmount) == false)
                {
                    if (CurrencyType.TryConvertFrom(retAmount, false, out amount) == false)
                        throw new TTException(SystemMessage.GetMessageV3(1192, new string[] { retAmount.ToString() }));
                }
                VoucherReturnDocumentMaterial returningDocument = _VoucherReturnDocument.VoucherReturnDocumentMaterials.AddNew();
                returningDocument.Material = material;
                returningDocument.RequireAmount = amount;
            }
        }
        
#endregion VoucherReturnDocumentNewForm_ClientSideMethods
    }
}