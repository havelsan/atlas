
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
    /// TITUBB Ürün Malzeme Eşleştirme
    /// </summary>
    public partial class ProductMaterialMatchActionNewForm : TTForm
    {
        override protected void BindControlEvents()
        {
            cmdClear.Click += new TTControlEventDelegate(cmdClear_Click);
            WithOutBarcode.CheckedChanged += new TTControlEventDelegate(WithOutBarcode_CheckedChanged);
            cmdMatch.Click += new TTControlEventDelegate(cmdMatch_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdClear.Click -= new TTControlEventDelegate(cmdClear_Click);
            WithOutBarcode.CheckedChanged -= new TTControlEventDelegate(WithOutBarcode_CheckedChanged);
            cmdMatch.Click -= new TTControlEventDelegate(cmdMatch_Click);
            base.UnBindControlEvents();
        }

        private void cmdClear_Click()
        {
#region ProductMaterialMatchActionNewForm_cmdClear_Click
   _ProductMaterialMatchAction.Product = null;
            _ProductMaterialMatchAction.Material = null;
            this.tttextbox5.Text = string.Empty;
            this.textFirmName.Text = string.Empty;
            this.textIdentityNumber.Text = string.Empty;
            _ProductMaterialMatchAction.MatchReasonWithBarcode = null;
#endregion ProductMaterialMatchActionNewForm_cmdClear_Click
        }

        private void WithOutBarcode_CheckedChanged()
        {
#region ProductMaterialMatchActionNewForm_WithOutBarcode_CheckedChanged
   if(_ProductMaterialMatchAction.WithOutBarcode == true && _ProductMaterialMatchAction.Product != null)
            {
                InfoBox.Show("TITUBB ürünü bulunmuş malzeme için barkodsuz malzeme işaretleyemezsiniz",MessageIconEnum.ErrorMessage);
                _ProductMaterialMatchAction.WithOutBarcode = false;
            }
            if(_ProductMaterialMatchAction.WithOutBarcode == true && string.IsNullOrEmpty(this.tttextbox5.Text)== false)
            {
                InfoBox.Show("Barkodu okutulmuş malzeme için barkodsuz malzeme işaretleyemezsiniz",MessageIconEnum.ErrorMessage);
                _ProductMaterialMatchAction.WithOutBarcode = false;
            }
#endregion ProductMaterialMatchActionNewForm_WithOutBarcode_CheckedChanged
        }

        private void cmdMatch_Click()
        {
#region ProductMaterialMatchActionNewForm_cmdMatch_Click
   bool checkMatch = true;
            if (_ProductMaterialMatchAction.WithOutBarcode.HasValue && (bool)_ProductMaterialMatchAction.WithOutBarcode == true)
            {
                if (_ProductMaterialMatchAction.Material == null)
                {
                    InfoBox.Show("Eski malzeme seçmediniz.", MessageIconEnum.ErrorMessage);
                    checkMatch = false;
                }
                
                MatchReasonDefinition reason = null;
                MultiSelectForm pMSForm = new MultiSelectForm();
                IList matchReasonList = _ProductMaterialMatchAction.ObjectContext.QueryObjects("MATCHREASONDEFINITION", "WITHBARCODE = 0");
                foreach (MatchReasonDefinition matchReasonDefinition in matchReasonList)
                    pMSForm.AddMSItem(matchReasonDefinition.Reason, matchReasonDefinition.ObjectID.ToString(), matchReasonDefinition);

                string sKey = pMSForm.GetMSItem(this, "Neden seçiniz.", true, true, false, false, true, true);
                if (!string.IsNullOrEmpty(sKey))
                    reason = (MatchReasonDefinition)pMSForm.MSSelectedItemObject;
                else
                {
                    InfoBox.Show("Malzemenin barkodsuz olma nedenini seçmediniz.", MessageIconEnum.ErrorMessage);
                    checkMatch = false;
                }

                if (checkMatch)
                {
                    ProductMaterialMatchDetail productMaterialMatchDetail = new ProductMaterialMatchDetail(_ProductMaterialMatchAction.ObjectContext);
                    productMaterialMatchDetail.Material = _ProductMaterialMatchAction.Material;
                    productMaterialMatchDetail.MatchReasonDefinition = reason;
                    productMaterialMatchDetail.ProductMaterialMatchAction = _ProductMaterialMatchAction;

                    _ProductMaterialMatchAction.Material = null;
                    //Application.DoEvents();
                }
            }
            else
            {
                
                if (_ProductMaterialMatchAction.Material == null)
                {
                    InfoBox.Show("Eski malzeme seçmediniz.", MessageIconEnum.ErrorMessage);
                    checkMatch = false;
                }

                if (_ProductMaterialMatchAction.Product == null && string.IsNullOrEmpty(this.tttextbox5.Text))
                {
                    InfoBox.Show("Malzemenin barkodunu okutmalısınız.", MessageIconEnum.ErrorMessage);
                    checkMatch = false;
                }

                if (checkMatch)
                {
                    if ((bool)_ProductMaterialMatchAction.CheckedMaterial(_ProductMaterialMatchAction.Product, _ProductMaterialMatchAction.Material, _ProductMaterialMatchAction))
                    {
                        ProductMaterialMatchDetail productMaterialMatchDetail = new ProductMaterialMatchDetail(_ProductMaterialMatchAction.ObjectContext);
                        productMaterialMatchDetail.Material = _ProductMaterialMatchAction.Material;
                        if (_ProductMaterialMatchAction.Product != null)
                            productMaterialMatchDetail.Product = _ProductMaterialMatchAction.Product;
                        if (string.IsNullOrEmpty(this.tttextbox5.Text) == false)
                            productMaterialMatchDetail.Barcode = this.tttextbox5.Text;
                        if(_ProductMaterialMatchAction.MatchReasonWithBarcode != null)
                            productMaterialMatchDetail.MatchReasonDefinition = _ProductMaterialMatchAction.MatchReasonWithBarcode;
                        productMaterialMatchDetail.ProductMaterialMatchAction = _ProductMaterialMatchAction;


                        _ProductMaterialMatchAction.Product = null;
                        _ProductMaterialMatchAction.Material = null;
                        this.tttextbox5.Text = string.Empty;
                        this.textFirmName.Text = string.Empty;
                        this.textIdentityNumber.Text = string.Empty;
                        _ProductMaterialMatchAction.MatchReasonWithBarcode = null;
                    }
                }
            }
#endregion ProductMaterialMatchActionNewForm_cmdMatch_Click
        }

        protected override void PreScript()
        {
#region ProductMaterialMatchActionNewForm_PreScript
    base.PreScript();
#endregion ProductMaterialMatchActionNewForm_PreScript

            }
            
        protected override void ClientSidePreScript()
        {
#region ProductMaterialMatchActionNewForm_ClientSidePreScript
    base.ClientSidePreScript();
            
            List<Store> selectableStore = new List<Store>();
            foreach (UserResource userResource in Common.CurrentResource.UserResources)
            {
                if (userResource.Resource.EnabledType == ResourceEnableType.BothInpatientAndOutPatient || userResource.Resource.EnabledType == ResourceEnableType.InPatient || userResource.Resource.EnabledType == ResourceEnableType.OutPatient || userResource.Resource.EnabledType == ResourceEnableType.Secmaster)
                    if (userResource.Resource.Store != null)
                {
                    if (selectableStore.Contains(userResource.Resource.Store) == false)
                        selectableStore.Add(userResource.Resource.Store);
                }
            }

            if (selectableStore.Count == 1)
            {
                _ProductMaterialMatchAction.Store = selectableStore[0];
            }
            else
            {
                MultiSelectForm mSelectForm = new MultiSelectForm();
                foreach (Store store in selectableStore)
                    mSelectForm.AddMSItem(store.Name, store.ObjectID.ToString(), store);

                string mkey = mSelectForm.GetMSItem(this, "İlgili Depoyu Seçiniz", true);
                if (string.IsNullOrEmpty(mkey))
                    throw new TTException(SystemMessage.GetMessageV2(249, "İşlemin yapılacağı depo seçilmeden işleme devam edemezsiniz."));
                _ProductMaterialMatchAction.Store = mSelectForm.MSSelectedItemObject as Store;
            }
            Material.ListFilterExpression = "STOCKS.STORE= " + ConnectionManager.GuidToString(this._ProductMaterialMatchAction.Store.ObjectID) + " AND STOCKS.INHELD > 0 AND OBJECTDEFID IN('58d34696-808e-47de-87e0-1f001d0928a7')";
#endregion ProductMaterialMatchActionNewForm_ClientSidePreScript

        }

#region ProductMaterialMatchActionNewForm_ClientSideMethods
        protected override void BarcodeRead(string value)
        {
            base.BarcodeRead(value);
            string barcode = Common.PrepareBarcode(value);
            _ProductMaterialMatchAction.WithOutBarcode = false;
            IList products = _ProductMaterialMatchAction.ObjectContext.QueryObjects("PRODUCTDEFINITION", "PRODUCTNUMBER ='" + barcode + "'");
            if (products.Count > 0)
            {
                if (products.Count == 1)
                {
                    _ProductMaterialMatchAction.Product = (ProductDefinition)products[0];
                    textIdentityNumber.Text = ((ProductDefinition)products[0]).Firm.IdentityNumber.ToString();
                    textFirmName.Text = ((ProductDefinition)products[0]).Firm.Name;
                }
                else
                {
                    MultiSelectForm pMSForm = new MultiSelectForm();
                    foreach (ProductDefinition productDefinition in products)
                        pMSForm.AddMSItem(productDefinition.ProductNumber + " - " + productDefinition.Firm.Name, productDefinition.ObjectID.ToString(), productDefinition);

                    string sKey = pMSForm.GetMSItem(this, "Malzemenin firmasını seçiniz.", true, true, false, false, true, true);
                    if (!string.IsNullOrEmpty(sKey))
                    {
                        _ProductMaterialMatchAction.Product = (ProductDefinition)pMSForm.MSSelectedItemObject;
                        textIdentityNumber.Text = ((ProductDefinition)products[0]).Firm.IdentityNumber.ToString();
                        textFirmName.Text = ((ProductDefinition)products[0]).Firm.Name;
                    }
                }
            }
            else
            {
                InfoBox.Show("Okutmuş olduğunuz barkodun TITUBB veri tabanında kaydı bulunmamaktadır.", MessageIconEnum.ErrorMessage);
                this.tttextbox5.Text = barcode;
                
                MultiSelectForm pMSForm = new MultiSelectForm();
                IList matchReasonList = _ProductMaterialMatchAction.ObjectContext.QueryObjects("MATCHREASONDEFINITION", "WITHBARCODE = 1");

                foreach (MatchReasonDefinition matchReasonDefinition in matchReasonList)
                    pMSForm.AddMSItem(matchReasonDefinition.Reason, matchReasonDefinition.ObjectID.ToString(), matchReasonDefinition);

                string sKey = pMSForm.GetMSItem(this, "Neden seçiniz.", true, true, false, false, true, true);
                if (!string.IsNullOrEmpty(sKey))
                    _ProductMaterialMatchAction.MatchReasonWithBarcode = (MatchReasonDefinition)pMSForm.MSSelectedItemObject;
            }


        }
        
#endregion ProductMaterialMatchActionNewForm_ClientSideMethods
    }
}