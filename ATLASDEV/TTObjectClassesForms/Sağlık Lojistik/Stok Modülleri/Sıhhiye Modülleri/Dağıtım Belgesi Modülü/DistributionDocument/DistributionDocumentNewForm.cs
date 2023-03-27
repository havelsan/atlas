
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
    /// Dağıtım Belgesi
    /// </summary>
    public partial class DistributionDocumentNewForm : BaseDistributionDocumentForm
    {
        override protected void BindControlEvents()
        {
            AutoDistributionButton.Click += new TTControlEventDelegate(AutoDistributionButton_Click);
            ChooseProductsFromTheTree.Click += new TTControlEventDelegate(ChooseProductsFromTheTree_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            AutoDistributionButton.Click -= new TTControlEventDelegate(AutoDistributionButton_Click);
            ChooseProductsFromTheTree.Click -= new TTControlEventDelegate(ChooseProductsFromTheTree_Click);
            base.UnBindControlEvents();
        }


        private void AutoDistributionButton_Click()
        {

          // List<DistributionDocumentMaterial> mat = this._StockAction.AutoDistributionCreate(_DistributionDocument.Store, _DistributionDocument.DestinationStore);

            if (this._DistributionDocument.DistributionDocumentMaterials.Count > 0)
            {
                this.DistributionDocumentMaterials.ReadOnly = true;
                
            }
        }


        private void ChooseProductsFromTheTree_Click()
        {
#region DistributionDocumentNewForm_ChooseProductsFromTheTree_Click
   MultiSelectForm multiSelectForm = new MultiSelectForm();
            IList productTreeDefinitions = this._DistributionDocument.ObjectContext.QueryObjects(typeof(ProductTreeDefinition).Name, "");
            foreach (ProductTreeDefinition productTreeDefinition in productTreeDefinitions)
                multiSelectForm.AddMSItem(productTreeDefinition.Material.Name, productTreeDefinition.ObjectID.ToString(), productTreeDefinition);

            multiSelectForm.GetMSItem(this, "Ürünü Seçiniz...");
            if (multiSelectForm.MSSelectedItemObject != null)
            {
                ProductTreeDefinition productTreeDefinition = multiSelectForm.MSSelectedItemObject as ProductTreeDefinition;
                if (productTreeDefinition != null)
                {
                    string retValue = InputForm.GetText("Üretilecek İlaç/Malzeme miktarını giriniz...");
                    if (string.IsNullOrEmpty(retValue) == false)
                    {
                        double? amount = 0;
                        if (DoubleType.TryConvertFrom(retValue, true, out amount) == false)
                            throw new TTException(SystemMessage.GetMessageV3(1192, new string[] {retValue.ToString()}));

                        foreach (ProductTreeDetail productTreeDetail in productTreeDefinition.ProductTreeDetails)
                        {
                            DistributionDocumentMaterial distributionDocumentMaterial = this._DistributionDocument.DistributionDocumentMaterials.AddNew();
                            distributionDocumentMaterial.Material = productTreeDetail.ConsumableMaterial;
                            double coefficient = productTreeDetail.Amount.Value / productTreeDefinition.SampleAmount.Value;
                            distributionDocumentMaterial.AcceptedAmount = amount * coefficient;
                            distributionDocumentMaterial.StockLevelType = TTObjectClasses.StockLevelType.NewStockLevel;
                        }
                        ChooseProductsFromTheTree.Enabled = false;
                    }
                }
            }
#endregion DistributionDocumentNewForm_ChooseProductsFromTheTree_Click
        }

        protected override void PreScript()
        {
#region DistributionDocumentNewForm_PreScript
    base.PreScript();
           

            this.DropStateButton(DistributionDocument.States.Completed);
            SelectStoreUsage(SelectStoreUsageEnum.UseMainStores, SelectStoreUsageEnum.UseUserResources);
            MaterialDistributionDocumentMaterial.ListFilterExpression = "STOCKS.STORE=" + ConnectionManager.GuidToString(this._DistributionDocument.Store.ObjectID) + " AND STOCKS.INHELD > 0";

            if (_DistributionDocument.Store is MainStoreDefinition)
            {
                _DistributionDocument.MKYS_TeslimEden = ((MainStoreDefinition)_DistributionDocument.Store).GoodsAccountant.Name;
                _DistributionDocument.MKYS_TeslimEdenObjID = ((MainStoreDefinition)_DistributionDocument.Store).GoodsAccountant.ObjectID;
            }
            if (_DistributionDocument.DestinationStore is SubStoreDefinition)
            {
                _DistributionDocument.MKYS_TeslimAlan = ((SubStoreDefinition)_DistributionDocument.DestinationStore).StoreResponsible.Name;
                _DistributionDocument.MKYS_TeslimAlanObjID = ((SubStoreDefinition)_DistributionDocument.DestinationStore).StoreResponsible.ObjectID;
            }
            /*if (_DistributionDocument.StockActionSignDetails.Count == 0)
            {
                StockActionSignDetail stockActionSignDetail = _DistributionDocument.StockActionSignDetails.AddNew();
                stockActionSignDetail.SignUserType = SignUserTypeEnum.TeslimEden;
                if (_DistributionDocument.Store is MainStoreDefinition)
                    stockActionSignDetail.SignUser = ((MainStoreDefinition)_DistributionDocument.Store).GoodsAccountant;

                stockActionSignDetail = _DistributionDocument.StockActionSignDetails.AddNew();
                stockActionSignDetail.SignUserType = SignUserTypeEnum.TeslimAlan;
                if (_DistributionDocument.DestinationStore is SubStoreDefinition)
                    stockActionSignDetail.SignUser = ((SubStoreDefinition)_DistributionDocument.DestinationStore).StoreResponsible;

               
            }*/
            _DistributionDocument.SetMKYSProperties();

            ChooseProductsFromTheTree.Visible = false;
            if (TTObjectClasses.SystemParameter.GetSite().ObjectID == Sites.SiteOrduIlac)
            {
                //DescriptionAndSignTabControl.Size = new Size(DescriptionAndSignTabControl.Size.Width - ChooseProductsFromTheTree.Size.Width - 10, DescriptionAndSignTabControl.Size.Height);
                ChooseProductsFromTheTree.Visible = true;
            }
#endregion DistributionDocumentNewForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region DistributionDocumentNewForm_PostScript
    base.PostScript(transDef);
#endregion DistributionDocumentNewForm_PostScript

            }
            
#region DistributionDocumentNewForm_ClientSideMethods
        protected override void BarcodeRead(string value)
        {
            base.BarcodeRead(value);
            string barcode = Common.PrepareBarcode(value);
            Material material = null;
            IBindingList materials = _DistributionDocument.ObjectContext.QueryObjects("MATERIAL", "BARCODE='" + barcode + "'");
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
                Currency? getAmount = 0;
                string retGetAmount = InputForm.GetText("İstenen Miktarı Giriniz.");
                if (string.IsNullOrEmpty(retGetAmount) == false)
                {
                    if (CurrencyType.TryConvertFrom(retGetAmount, false, out getAmount) == false)
                        throw new TTException(SystemMessage.GetMessageV3(1192, new string[] { retGetAmount.ToString() }));
                }

                DistributionDocumentMaterial returningDocument = _DistributionDocument.DistributionDocumentMaterials.AddNew();
                returningDocument.Material = material;
                returningDocument.AcceptedAmount = getAmount;
                returningDocument.Amount = getAmount;
                returningDocument.StockLevelType = TTObjectClasses.StockLevelType.NewStockLevel;
            }
        }
        
#endregion DistributionDocumentNewForm_ClientSideMethods
    }
}