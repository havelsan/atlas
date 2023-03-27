
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
    /// İade Belgesi
    /// </summary>
    public partial class ReturningDocumentForm : BaseReturningDocumentForm
    {

        protected override void ClientSidePreScript()
        {
            #region ReturningDocumentForm_ClientSidePreScript
            base.ClientSidePreScript();


            MultiSelectForm mSelectForm = new MultiSelectForm();
            mSelectForm.AddMSItem("Tıbbi Sarf", "Tıbbi Sarf", MKYS_EMalzemeGrupEnum.tibbiSarf);
            mSelectForm.AddMSItem("İlaç", "İlaç", MKYS_EMalzemeGrupEnum.ilac);
            mSelectForm.AddMSItem("Tıbbi Cihaz", "Tıbbi Cihaz", MKYS_EMalzemeGrupEnum.tibbiCihaz);
            mSelectForm.AddMSItem("Diğer", "Diğer", MKYS_EMalzemeGrupEnum.diger);

            string mkey = mSelectForm.GetMSItem(this, "Giriş Yapılacak Malzeme Grubunu Seçiniz", true);
            if (string.IsNullOrEmpty(mkey))
                throw new TTException(SystemMessage.GetMessageV2(369, "Malzeme grubu seçilmeden işleme devam edemezsiniz."));
           _ReturningDocument.MKYS_EMalzemeGrup = (MKYS_EMalzemeGrupEnum)mSelectForm.MSSelectedItemObject;


            if (_ReturningDocument.MKYS_EMalzemeGrup == MKYS_EMalzemeGrupEnum.tibbiSarf)
                Material.ListFilterExpression = "OBJECTDEFID =" + ConnectionManager.GuidToString(new Guid("58d34696-808e-47de-87e0-1f001d0928a7"));

            if (_ReturningDocument.MKYS_EMalzemeGrup == MKYS_EMalzemeGrupEnum.ilac)
                Material.ListFilterExpression = "OBJECTDEFID =" + ConnectionManager.GuidToString(new Guid("65a2337c-bc3c-4c6b-9575-ad47fa7a9a89"));

            if (_ReturningDocument.MKYS_EMalzemeGrup == MKYS_EMalzemeGrupEnum.tibbiCihaz)
                Material.ListFilterExpression = "OBJECTDEFID =" + ConnectionManager.GuidToString(new Guid("f38f2111-0ee4-4b9f-9707-a63ac02d29f4"));



            #endregion ReturningDocumentForm_ClientSidePreScript

        }



        protected override void PreScript()
        {
#region ReturningDocumentForm_PreScript
    base.PreScript();
            this.DropStateButton(ReturningDocument.States.Completed);
            SelectStoreUsage(SelectStoreUsageEnum.UseUserResources, SelectStoreUsageEnum.UseMainStores);

            if (this._ReturningDocument.CurrentStateDefID == ReturningDocument.States.New)
                Material.ListFilterExpression = "STOCKS.STORE= " + ConnectionManager.GuidToString(this._ReturningDocument.Store.ObjectID) + " AND STOCKS.INHELD > 0";

            if (_ReturningDocument.Store is MainStoreDefinition)
            {
                _ReturningDocument.MKYS_TeslimEden = ((MainStoreDefinition)_ReturningDocument.Store).GoodsAccountant.Name;
                _ReturningDocument.MKYS_TeslimEdenObjID = ((MainStoreDefinition)_ReturningDocument.Store).GoodsAccountant.ObjectID;
            }
            if (_ReturningDocument.DestinationStore is SubStoreDefinition)
            {
                _ReturningDocument.MKYS_TeslimAlan = ((SubStoreDefinition)_ReturningDocument.DestinationStore).StoreResponsible.Name;
                _ReturningDocument.MKYS_TeslimAlanObjID = ((SubStoreDefinition)_ReturningDocument.DestinationStore).StoreResponsible.ObjectID;
            }
            /* if (_ReturningDocument.StockActionSignDetails.Count == 0)
             {
                 StockActionSignDetail stockActionSignDetail = _ReturningDocument.StockActionSignDetails.AddNew();
                 stockActionSignDetail.SignUserType = SignUserTypeEnum.TeslimEden;
                 if (_ReturningDocument.Store is MainStoreDefinition)
                     stockActionSignDetail.SignUser = ((MainStoreDefinition)_ReturningDocument.Store).GoodsAccountant;

                 stockActionSignDetail = _ReturningDocument.StockActionSignDetails.AddNew();
                 stockActionSignDetail.SignUserType = SignUserTypeEnum.TeslimAlan;
                 if (_ReturningDocument.DestinationStore is SubStoreDefinition)
                     stockActionSignDetail.SignUser = ((SubStoreDefinition)_ReturningDocument.DestinationStore).StoreResponsible;
             }*/



            ChooseProductsFromTheTree.Visible = false;
            if (TTObjectClasses.SystemParameter.GetSite().ObjectID == Sites.SiteOrduIlac)
            {
                //DescriptionAndSignTabControl.Size = new Size(DescriptionAndSignTabControl.Size.Width - ChooseProductsFromTheTree.Size.Width - 10, DescriptionAndSignTabControl.Size.Height);
                ChooseProductsFromTheTree.Visible = true;
            }
#endregion ReturningDocumentForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region ReturningDocumentForm_PostScript
    base.PostScript(transDef);

    _ReturningDocument.CheckStockCardCardNofCount(30);
#endregion ReturningDocumentForm_PostScript

            }
            
#region ReturningDocumentForm_ClientSideMethods
        protected override void BarcodeRead(string value)
        {
            base.BarcodeRead(value);
            string barcode = Common.PrepareBarcode(value);
            Material material = null;
            IBindingList materials = _ReturningDocument.ObjectContext.QueryObjects("MATERIAL", "BARCODE='" + barcode + "'");
            if (materials.Count == 0)
                InfoBox.Show(barcode + " UBB/Barkodlu malzeme bulunamadı.", MessageIconEnum.ErrorMessage);
            else if (materials.Count == 1)
                material = (Material)materials[0];
            else
            {
                MultiSelectForm multiSelectForm = new MultiSelectForm();
                foreach (Material m in materials)
                {
                    multiSelectForm.AddMSItem(m.Name , m.Name, m);
                }
                string key = multiSelectForm.GetMSItem(ParentForm, "Malzeme seçin");

                if (string.IsNullOrEmpty(key))
                    InfoBox.Show("Herhangibir malzeme seçilmedi.", MessageIconEnum.ErrorMessage);
                else
                    material = multiSelectForm.MSSelectedItemObject as Material;
            }

            if (material != null)
            {
                
                string retAmount = InputForm.GetText("İade Edilecek Miktarı Giriniz.");
                Currency? amount = 0;
                if (string.IsNullOrEmpty(retAmount) == false)
                {
                    if (CurrencyType.TryConvertFrom(retAmount, false, out amount) == false)
                        throw new TTException(SystemMessage.GetMessageV3(1192, new string[] { retAmount.ToString() }));
                }

                ReturningDocumentMaterial returningDocument = _ReturningDocument.ReturningDocumentMaterials.AddNew();
                returningDocument.Material = material;
                returningDocument.RequireAmount = amount;
                returningDocument.Amount = amount;
                returningDocument.StockLevelType = TTObjectClasses.StockLevelType.NewStockLevel;

                
            }
        }
        
#endregion ReturningDocumentForm_ClientSideMethods
    }
}