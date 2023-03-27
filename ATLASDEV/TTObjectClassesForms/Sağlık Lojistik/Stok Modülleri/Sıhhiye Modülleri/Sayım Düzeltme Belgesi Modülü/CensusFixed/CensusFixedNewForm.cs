
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
    /// Sayım Düzeltme Belgesi
    /// </summary>
    public partial class CensusFixedNewForm : BaseCensusFixedForm
    {
        protected override void PreScript()
        {
#region CensusFixedNewForm_PreScript
    base.PreScript();

            this.DropStateButton(CensusFixed.States.Completed);

            this._CensusFixed.MKYS_CikisStokHareketTuru = MKYS_ECikisStokHareketTurEnum.ckSayimNoksani;
            this._CensusFixed.MKYS_ETedarikTuru = MKYS_ETedarikTurEnum.sayimFazlasi;
            

            MultiSelectForm mSelectForm = new MultiSelectForm();
            mSelectForm.AddMSItem("Tıbbi Sarf", "Tıbbi Sarf", MKYS_EMalzemeGrupEnum.tibbiSarf);
            mSelectForm.AddMSItem("İlaç", "İlaç", MKYS_EMalzemeGrupEnum.ilac);
            mSelectForm.AddMSItem("Tıbbi Cihaz", "Tıbbi Cihaz", MKYS_EMalzemeGrupEnum.tibbiCihaz);
            mSelectForm.AddMSItem("Diğer", "Diğer", MKYS_EMalzemeGrupEnum.diger);

            string mkey = mSelectForm.GetMSItem(this, "Malzeme Grubunu Seçiniz", true);
            if (string.IsNullOrEmpty(mkey))
                throw new TTException(SystemMessage.GetMessage(369));
            this._CensusFixed.MKYS_EMalzemeGrup = (MKYS_EMalzemeGrupEnum)mSelectForm.MSSelectedItemObject;


            if (this._CensusFixed.MKYS_EMalzemeGrup == MKYS_EMalzemeGrupEnum.tibbiSarf)
            {
                Material.ListFilterExpression = "OBJECTDEFID =" + ConnectionManager.GuidToString(new Guid("58d34696-808e-47de-87e0-1f001d0928a7"));
                MaterialOut.ListFilterExpression = "OBJECTDEFID =" + ConnectionManager.GuidToString(new Guid("58d34696-808e-47de-87e0-1f001d0928a7"));
            }
            if (this._CensusFixed.MKYS_EMalzemeGrup == MKYS_EMalzemeGrupEnum.ilac)
            {
                Material.ListFilterExpression = "OBJECTDEFID =" + ConnectionManager.GuidToString(new Guid("65a2337c-bc3c-4c6b-9575-ad47fa7a9a89"));
                MaterialOut.ListFilterExpression = "OBJECTDEFID =" + ConnectionManager.GuidToString(new Guid("65a2337c-bc3c-4c6b-9575-ad47fa7a9a89"));
            }
            if (this._CensusFixed.MKYS_EMalzemeGrup == MKYS_EMalzemeGrupEnum.tibbiCihaz)
            {
                Material.ListFilterExpression = "OBJECTDEFID =" + ConnectionManager.GuidToString(new Guid("f38f2111-0ee4-4b9f-9707-a63ac02d29f4"));
                MaterialOut.ListFilterExpression = "OBJECTDEFID =" + ConnectionManager.GuidToString(new Guid("f38f2111-0ee4-4b9f-9707-a63ac02d29f4"));
            }




            if (_CensusFixed.Store is MainStoreDefinition)
            {
                _CensusFixed.MKYS_TeslimEden = ((MainStoreDefinition)_CensusFixed.Store).GoodsAccountant.Name;
                _CensusFixed.MKYS_TeslimEdenObjID = ((MainStoreDefinition)_CensusFixed.Store).GoodsAccountant.ObjectID;
                _CensusFixed.MKYS_TeslimAlan = ((MainStoreDefinition)_CensusFixed.DestinationStore).GoodsAccountant.Name;
                _CensusFixed.MKYS_TeslimAlanObjID = ((MainStoreDefinition)_CensusFixed.DestinationStore).GoodsAccountant.ObjectID;
            }











            if (string.IsNullOrEmpty(_CensusFixed.Description))
            {
                _CensusFixed.Description = _CensusFixed.TransactionDate.Value.ToShortDateString() + " tarihinde yapılan sayım neticesi ile stok kayıt kartlarında kayıtlı bulunan mevcutlar arasındaki farktan dolayı yukarıdaki düzeltmenin yapılması gerektiğini beyan ederim.";
            }

           /* if (_CensusFixed.StockActionSignDetails.Count == 0)
            {
                StockActionSignDetail stockActionSignDetail = _CensusFixed.StockActionSignDetails.AddNew();
                stockActionSignDetail.SignUserType = SignUserTypeEnum.MalSaymani;
                if (_CensusFixed.Store is MainStoreDefinition)
                    stockActionSignDetail.SignUser = ((MainStoreDefinition)_CensusFixed.Store).GoodsAccountant;

                stockActionSignDetail = _CensusFixed.StockActionSignDetails.AddNew();
                stockActionSignDetail.SignUserType = SignUserTypeEnum.MalSorumlusu;
                if (_CensusFixed.Store is MainStoreDefinition)
                    stockActionSignDetail.SignUser = ((MainStoreDefinition)_CensusFixed.Store).GoodsResponsible;

                stockActionSignDetail = _CensusFixed.StockActionSignDetails.AddNew();
                stockActionSignDetail.SignUserType = SignUserTypeEnum.HesapSorumlusu;
                if (_CensusFixed.Store is MainStoreDefinition)
                {
                    if (((MainStoreDefinition)_CensusFixed.Store).AccountManager != null)
                    {
                        stockActionSignDetail.SignUser = ((MainStoreDefinition)_CensusFixed.Store).AccountManager;
                    }
                    else
                    {
                        ResUser user = TTUser.CurrentUser.UserObject as ResUser;
                        if (user.SelectedSecMasterResource.ResourceUsers.Count > 0)
                            stockActionSignDetail.SignUser = user.SelectedSecMasterResource.ResourceUsers[0].User;
                    }
                }

                stockActionSignDetail = _CensusFixed.StockActionSignDetails.AddNew();
                stockActionSignDetail.SignUserType = SignUserTypeEnum.BirlikXXXXXXi;
                stockActionSignDetail.SignUser = null;
            }*/


            if (this._CensusFixed.CurrentStateDefID == CensusFixed.States.New)
                MaterialOut.ListFilterExpression = "STOCKS.STORE = " + ConnectionManager.GuidToString(this._CensusFixed.Store.ObjectID) + " AND STOCKS.INHELD > 0";
#endregion CensusFixedNewForm_PreScript

            }
            
        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
#region CensusFixedNewForm_PostScript
    base.PostScript(transDef);

            if (this._CensusFixed.CurrentStateDefID == CensusFixed.States.New && transDef != null)
                if (this._CensusFixed.CensusFixedInMaterials.Count == 0 && this._CensusFixed.CensusFixedOutMaterials.Count == 0)
                    throw new TTUtils.TTException("Sayım Düzeltme Belgesi en az bir tane Arttırılanlar yada Eksiltilenler içermelidir");


            string errorMessage = string.Empty;
            foreach (CensusFixedMaterialIn censusFixedMaterialIn in _CensusFixed.CensusFixedInMaterials)
            {
                if (censusFixedMaterialIn.CensusAmount <= censusFixedMaterialIn.CardAmount)
                {
                    if (string.IsNullOrEmpty(errorMessage))
                        errorMessage = "Sayılan Miktar, Stok Kayıt Kart Nevi'nden küçük olamaz.\r\n";
                    errorMessage += "İlaç/Malzeme : " + censusFixedMaterialIn.Material.StockCard.NATOStockNO + " " + censusFixedMaterialIn.Material.Name + "\r\nSayılan Miktar : " + censusFixedMaterialIn.CensusAmount + "\r\nStok Kayıt Kart Nevi : " + censusFixedMaterialIn.CardAmount;
                }
            }

            if (string.IsNullOrEmpty(errorMessage) == false)
                throw new TTException(errorMessage);

            errorMessage = string.Empty;
            foreach (CensusFixedMaterialOut censusFixedMaterialOut in _CensusFixed.CensusFixedOutMaterials)
            {
                if (censusFixedMaterialOut.CensusAmount >= censusFixedMaterialOut.CardAmount)
                {
                    if (string.IsNullOrEmpty(errorMessage))
                        errorMessage = "Sayılan Miktar, Stok Kayıt Kart Nevi'nden büyük olamaz.\r\n";
                    errorMessage += "İlaç/Malzeme : " + censusFixedMaterialOut.Material.StockCard.NATOStockNO + " " + censusFixedMaterialOut.Material.Name + "\r\nSayılan Miktar : " + censusFixedMaterialOut.CensusAmount + "\r\nStok Kayıt Kart Nevi : " + censusFixedMaterialOut.CardAmount;
                }
            }

            if (string.IsNullOrEmpty(errorMessage) == false)
                throw new TTException(errorMessage);
#endregion CensusFixedNewForm_PostScript

            }
                }
}