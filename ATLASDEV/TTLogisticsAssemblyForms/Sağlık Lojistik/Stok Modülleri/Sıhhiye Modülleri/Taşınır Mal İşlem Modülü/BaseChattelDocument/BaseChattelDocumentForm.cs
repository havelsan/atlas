
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
    public partial class BaseChattelDocumentForm : StockActionBaseForm
    {
        override protected void BindControlEvents()
        {

            base.BindControlEvents();
            TTTeslimAlanButon.Click += new TTControlEventDelegate(TTTeslimAlanButon_Click);
            TTTeslimEdenButon.Click += new TTControlEventDelegate(TTTeslimEdenButon_Click);
        }

        override protected void UnBindControlEvents()
        {
            base.UnBindControlEvents();
            TTTeslimAlanButon.Click += new TTControlEventDelegate(TTTeslimAlanButon_Click);
            TTTeslimEdenButon.Click += new TTControlEventDelegate(TTTeslimEdenButon_Click);
        }


        private void TTTeslimAlanButon_Click()
        {
            #region TTTeslimAlanButon_Click
            TTObjectContext context = new TTObjectContext(false);
            BindingList<ResUser> resUser = ResUser.GetAllUser(context, "WHERE ISACTIVE = 1 ");
            ResUser selectedPersonel = null;

            MultiSelectForm multiSelectForm = new MultiSelectForm();
            foreach (ResUser user in resUser)
            {
                multiSelectForm.AddMSItem(user.Name, user.ObjectID.ToString(), user);
            }
            string key = multiSelectForm.GetMSItem(this.ParentForm, "Teslim Alan Personel Seçin");

            if (string.IsNullOrEmpty(key))
                InfoBox.Show("Herhangibir Personel Seçilmedi.", MessageIconEnum.ErrorMessage);
            else
            {
                selectedPersonel = multiSelectForm.MSSelectedItemObject as ResUser;
                this.MKYS_TeslimAlan.Text = selectedPersonel.Name.ToString();
                _BaseChattelDocument.MKYS_TeslimAlanObjID = selectedPersonel.ObjectID;
            }
            #endregion TTTeslimAlanButon_Click
        }
        private void TTTeslimEdenButon_Click()
        {
            #region TTTeslimEdenButon_Click
            TTObjectContext context = new TTObjectContext(false);
            BindingList<ResUser> resUser = ResUser.GetAllUser(context, "WHERE ISACTIVE = 1 ");
            ResUser selectedPersonel = null;

            MultiSelectForm multiSelectForm = new MultiSelectForm();
            foreach (ResUser user in resUser)
            {
                multiSelectForm.AddMSItem(user.Name, user.ObjectID.ToString(), user);
            }
            string key = multiSelectForm.GetMSItem(this.ParentForm, "Teslim Eden Personeli Seçin");

            if (string.IsNullOrEmpty(key))
                InfoBox.Show("Herhangibir Personel Seçilmedi.", MessageIconEnum.ErrorMessage);
            else
            {
                selectedPersonel = multiSelectForm.MSSelectedItemObject as ResUser;
                this.MKYS_TeslimEden.Text = selectedPersonel.Name.ToString();
                _BaseChattelDocument.MKYS_TeslimEdenObjID = selectedPersonel.ObjectID;
            }
            #endregion TTTeslimEdenButon_Click
        }



        protected override void PreScript()
        {
            #region BaseChattelDocumentForm_PreScript
            base.PreScript();

           /* if (_BaseChattelDocument.StockActionSignDetails.Count == 0)
            {
                StockActionSignDetail stockActionSignDetail = _BaseChattelDocument.StockActionSignDetails.AddNew();
                stockActionSignDetail.SignUserType = SignUserTypeEnum.TeslimAlan;
                if (_BaseChattelDocument.DestinationStore != null)
                    if (_BaseChattelDocument.DestinationStore is MainStoreDefinition)
                        stockActionSignDetail.SignUser = ((MainStoreDefinition)_BaseChattelDocument.DestinationStore).GoodsAccountant;

                stockActionSignDetail = _BaseChattelDocument.StockActionSignDetails.AddNew();
                stockActionSignDetail.SignUserType = SignUserTypeEnum.TeslimEden;
                if (_BaseChattelDocument.Store is MainStoreDefinition)
                    stockActionSignDetail.SignUser = ((MainStoreDefinition)_BaseChattelDocument.Store).GoodsAccountant;


                //stockActionSignDetail.SignUserType = SignUserTypeEnum.MalSaymani;
                //if (_BaseChattelDocument.Store is MainStoreDefinition)
                //    stockActionSignDetail.SignUser = ((MainStoreDefinition)_BaseChattelDocument.Store).GoodsAccountant;

                //stockActionSignDetail = _BaseChattelDocument.StockActionSignDetails.AddNew();
                //stockActionSignDetail.SignUserType = SignUserTypeEnum.MalSorumlusu;
                //if (_BaseChattelDocument.Store is MainStoreDefinition)
                //    stockActionSignDetail.SignUser = ((MainStoreDefinition)_BaseChattelDocument.Store).GoodsResponsible;

                //stockActionSignDetail = _BaseChattelDocument.StockActionSignDetails.AddNew();
                //stockActionSignDetail.SignUserType = SignUserTypeEnum.HesapSorumlusu;
                //if (_BaseChattelDocument.Store is MainStoreDefinition)
                //{
                //    if (((MainStoreDefinition)_BaseChattelDocument.Store).AccountManager != null)
                //    {
                //        stockActionSignDetail.SignUser = ((MainStoreDefinition)_BaseChattelDocument.Store).AccountManager;
                //    }
                //    else
                //    {
                //        ResUser user = TTUser.CurrentUser.UserObject as ResUser;
                //        if (user.SelectedSecMasterResource.ResourceUsers.Count > 0)
                //            stockActionSignDetail.SignUser = user.SelectedSecMasterResource.ResourceUsers[0].User;
                //    }
                //}
            }*/
            #endregion BaseChattelDocumentForm_PreScript

        }

        #region BaseChattelDocumentForm_Methods
        public Double CalculateTotalPrice()
        {
            double totalPrice = 0;
            foreach (StockActionDetailIn inDet in _BaseChattelDocument.StockActionDetails)
            {
                if (inDet.Amount == null || inDet.UnitPrice == null)
                    continue;
                totalPrice += Convert.ToDouble(inDet.Amount) * Convert.ToDouble(inDet.UnitPrice);
            }
            return totalPrice;
        }

        public List<double> CalcFinalPrice(List<double> prices)
        {
            foreach (StockActionDetailIn inDet in _BaseChattelDocument.StockActionDetails)
            {
                if (inDet.TotalPriceNotDiscount == null || inDet.TotalDiscountAmount == null)
                    continue;
                prices[0] += Convert.ToDouble(inDet.TotalPriceNotDiscount);
                prices[1] += Convert.ToDouble(inDet.TotalDiscountAmount);

            }

            prices[2] = prices[0] - prices[1];
            return prices;
        }





        #endregion BaseChattelDocumentForm_Methods
    }
}