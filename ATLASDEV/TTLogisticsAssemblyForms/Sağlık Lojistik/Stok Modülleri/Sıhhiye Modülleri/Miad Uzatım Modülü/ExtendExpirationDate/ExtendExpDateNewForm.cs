
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
    public partial class ExtendExpDateNewForm : BaseExtendExpDateForm
    {
        protected override void PreScript()
        {
            #region ExtendExpDateNewForm_PreScript
            base.PreScript();
            SelectStoreUsage(SelectStoreUsageEnum.UseMainStoreResources, SelectStoreUsageEnum.Nothing);
            #endregion ExtendExpDateNewForm_PreScript
        }
        protected override void ClientSidePreScript()
        {
            #region ExtendExpDateNewForm_ClientSidePreScript
            base.ClientSidePreScript();


            this.MaterialExtendExpirationDateDetail.ListFilterExpression = "STOCKS.STORE= " + ConnectionManager.GuidToString(this._ExtendExpirationDate.Store.ObjectID) + " AND STOCKS.INHELD > 0" + "AND STOCKCARD.STOCKMETHOD = 1";

            if (_ExtendExpirationDate.Store is MainStoreDefinition)
            {
                _ExtendExpirationDate.MKYS_TeslimEden = ((MainStoreDefinition)_ExtendExpirationDate.Store).GoodsAccountant.Name;
                _ExtendExpirationDate.MKYS_TeslimEdenObjID = ((MainStoreDefinition)_ExtendExpirationDate.Store).GoodsAccountant.ObjectID;
                _ExtendExpirationDate.MKYS_TeslimAlan = ((MainStoreDefinition)_ExtendExpirationDate.DestinationStore).GoodsAccountant.Name;
                _ExtendExpirationDate.MKYS_TeslimAlanObjID = ((MainStoreDefinition)_ExtendExpirationDate.DestinationStore).GoodsAccountant.ObjectID;
            }
           

            //MultiSelectForm mSelectForm = new MultiSelectForm();
            //mSelectForm.AddMSItem("Týbbi Sarf", "Týbbi Sarf", MKYS_EMalzemeGrupEnum.tibbiSarf);
            //mSelectForm.AddMSItem("Ýlaç", "Ýlaç", MKYS_EMalzemeGrupEnum.ilac);
            //mSelectForm.AddMSItem("Týbbi Cihaz", "Týbbi Cihaz", MKYS_EMalzemeGrupEnum.tibbiCihaz);
            //mSelectForm.AddMSItem("Diðer", "Diðer", MKYS_EMalzemeGrupEnum.diger);

            //string mkey = mSelectForm.GetMSItem(this, "Malzeme Grubunu Seçiniz", true);
            //if (string.IsNullOrEmpty(mkey))
            //    throw new TTException(SystemMessage.GetMessage(369, "Malzeme grubu seçilmeden iþleme devam edemezsiniz."));
            //this._ExtendExpirationDate.MKYS_EMalzemeGrup = (MKYS_EMalzemeGrupEnum)mSelectForm.MSSelectedItemObject;


            //if (this._ExtendExpirationDate.MKYS_EMalzemeGrup == MKYS_EMalzemeGrupEnum.tibbiSarf)
            //    MaterialExtendExpirationDateDetail.ListFilterExpression = "OBJECTDEFID =" + ConnectionManager.GuidToString(new Guid("58d34696-808e-47de-87e0-1f001d0928a7"));

            //if (this._ExtendExpirationDate.MKYS_EMalzemeGrup == MKYS_EMalzemeGrupEnum.ilac)
            //    MaterialExtendExpirationDateDetail.ListFilterExpression = "OBJECTDEFID =" + ConnectionManager.GuidToString(new Guid("65a2337c-bc3c-4c6b-9575-ad47fa7a9a89"));

            //if (this._ExtendExpirationDate.MKYS_EMalzemeGrup == MKYS_EMalzemeGrupEnum.tibbiCihaz)
            //    MaterialExtendExpirationDateDetail.ListFilterExpression = "OBJECTDEFID =" + ConnectionManager.GuidToString(new Guid("f38f2111-0ee4-4b9f-9707-a63ac02d29f4"));



            #endregion ExtendExpDateNewForm_ClientSidePreScript

        }

    }
}