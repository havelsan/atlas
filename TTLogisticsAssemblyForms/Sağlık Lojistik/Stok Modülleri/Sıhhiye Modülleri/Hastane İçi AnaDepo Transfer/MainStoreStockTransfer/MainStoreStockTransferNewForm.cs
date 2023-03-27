
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
    public partial class MainStoreStockTransferNewForm : BaseMainStoreStockTransferForm
    {
        protected override void PreScript()
        {
            #region MainStoreStockTransferNewForm_PreScript
            base.PreScript();
            SelectStoreUsage(SelectStoreUsageEnum.UseMainStoreResources, SelectStoreUsageEnum.UseMainStores);
            #endregion MainStoreStockTransferNewForm_PreScript
        }

        protected override void ClientSidePreScript()
        {
            #region MainStoreStockTransferNewForm_ClientSidePreScript()
            base.ClientSidePreScript();

            MultiSelectForm mSelectForm = new MultiSelectForm();
            mSelectForm.AddMSItem("Týbbi Sarf", "Týbbi Sarf", MKYS_EMalzemeGrupEnum.tibbiSarf);
            mSelectForm.AddMSItem("Ýlaç", "Ýlaç", MKYS_EMalzemeGrupEnum.ilac);
            mSelectForm.AddMSItem("Týbbi Cihaz", "Týbbi Cihaz", MKYS_EMalzemeGrupEnum.tibbiCihaz);
            mSelectForm.AddMSItem("Diðer", "Diðer", MKYS_EMalzemeGrupEnum.diger);

            string mkey = mSelectForm.GetMSItem(this, "Giriþ Yapýlacak Malzeme Grubunu Seçiniz", true);
            if (string.IsNullOrEmpty(mkey))
                throw new TTException(SystemMessage.GetMessageV2(369, "Malzeme grubu seçilmeden iþleme devam edemezsiniz."));
            _MainStoreStockTransfer.MKYS_EMalzemeGrup = (MKYS_EMalzemeGrupEnum)mSelectForm.MSSelectedItemObject;

            

            if (_MainStoreStockTransfer.MKYS_EMalzemeGrup == MKYS_EMalzemeGrupEnum.tibbiSarf)
                MaterialMainStoreStockTransferMat.ListFilterExpression = "OBJECTDEFID =" + ConnectionManager.GuidToString(new Guid("58d34696-808e-47de-87e0-1f001d0928a7"));

            if (_MainStoreStockTransfer.MKYS_EMalzemeGrup == MKYS_EMalzemeGrupEnum.ilac)
                MaterialMainStoreStockTransferMat.ListFilterExpression = "OBJECTDEFID =" + ConnectionManager.GuidToString(new Guid("65a2337c-bc3c-4c6b-9575-ad47fa7a9a89"));

            if (_MainStoreStockTransfer.MKYS_EMalzemeGrup == MKYS_EMalzemeGrupEnum.tibbiCihaz)
                MaterialMainStoreStockTransferMat.ListFilterExpression = "OBJECTDEFID =" + ConnectionManager.GuidToString(new Guid("f38f2111-0ee4-4b9f-9707-a63ac02d29f4"));




            _MainStoreStockTransfer.MKYS_ETedarikTuru = (MKYS_ETedarikTurEnum)((int)MkysServis.ETedarikTurID.ambarlarArasiDevir);
            _MainStoreStockTransfer.MKYS_EAlimYontemi = MKYS_EAlimYontemiEnum.bos;
            _MainStoreStockTransfer.MKYS_CikisStokHareketTuru = MKYS_ECikisStokHareketTurEnum.ckAmbarlarArasiDevir;

            if (_MainStoreStockTransfer.Store is MainStoreDefinition)
            {
                _MainStoreStockTransfer.MKYS_TeslimEden = ((MainStoreDefinition)_MainStoreStockTransfer.Store).GoodsAccountant.Name;
                _MainStoreStockTransfer.MKYS_TeslimEdenObjID = ((MainStoreDefinition)_MainStoreStockTransfer.Store).GoodsAccountant.ObjectID;
            }
                if (_MainStoreStockTransfer.DestinationStore is MainStoreDefinition)
            {
                _MainStoreStockTransfer.MKYS_TeslimAlan = ((MainStoreDefinition)_MainStoreStockTransfer.DestinationStore).GoodsAccountant.Name;
                _MainStoreStockTransfer.MKYS_TeslimAlanObjID = ((MainStoreDefinition)_MainStoreStockTransfer.DestinationStore).GoodsAccountant.ObjectID;
            }


            /* if (_MainStoreStockTransfer.StockActionSignDetails.Count == 0)
            {
                StockActionSignDetail stockActionSignDetail = _MainStoreStockTransfer.StockActionSignDetails.AddNew();
                stockActionSignDetail.SignUserType = SignUserTypeEnum.TeslimEden;
                if (_MainStoreStockTransfer.Store is MainStoreDefinition)
                    stockActionSignDetail.SignUser = ((MainStoreDefinition)_MainStoreStockTransfer.Store).GoodsAccountant;

                stockActionSignDetail = _MainStoreStockTransfer.StockActionSignDetails.AddNew();
                stockActionSignDetail.SignUserType = SignUserTypeEnum.TeslimAlan;
                if (_MainStoreStockTransfer.DestinationStore is MainStoreDefinition)
                    stockActionSignDetail.SignUser = ((MainStoreDefinition)_MainStoreStockTransfer.DestinationStore).GoodsAccountant;
            }*/






            #endregion MainStoreStockTransferNewForm_ClientSidePreScript()
        }

    }
}