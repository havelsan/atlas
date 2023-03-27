
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
    public partial class GrantMaterialNewForm : BaseGrantMaterialForm
    {

        protected override void ClientSidePreScript()
        {
            #region GrantMaterialNewForm_ClientSidePreScript
            base.ClientSidePreScript();


            MultiSelectForm mSelectForm = new MultiSelectForm();
            mSelectForm.AddMSItem("Týbbi Sarf", "Týbbi Sarf", MKYS_EMalzemeGrupEnum.tibbiSarf);
            mSelectForm.AddMSItem("Ýlaç", "Ýlaç", MKYS_EMalzemeGrupEnum.ilac);
            mSelectForm.AddMSItem("Týbbi Cihaz", "Týbbi Cihaz", MKYS_EMalzemeGrupEnum.tibbiCihaz);
            mSelectForm.AddMSItem("Diðer", "Diðer", MKYS_EMalzemeGrupEnum.diger);

            string mkey = mSelectForm.GetMSItem(this, "Giriþ Yapýlacak Malzeme Grubunu Seçiniz", true);
            if (string.IsNullOrEmpty(mkey))
                throw new TTException(SystemMessage.GetMessageV2(369, "Malzeme grubu seçilmeden iþleme devam edemezsiniz."));
            _GrantMaterial.MKYS_EMalzemeGrup = (MKYS_EMalzemeGrupEnum)mSelectForm.MSSelectedItemObject;


            if (_GrantMaterial.MKYS_EMalzemeGrup == MKYS_EMalzemeGrupEnum.tibbiSarf)
                MaterialGrantMaterialDetail.ListFilterExpression = "OBJECTDEFID =" + ConnectionManager.GuidToString(new Guid("58d34696-808e-47de-87e0-1f001d0928a7"));

            if (_GrantMaterial.MKYS_EMalzemeGrup == MKYS_EMalzemeGrupEnum.ilac)
                MaterialGrantMaterialDetail.ListFilterExpression = "OBJECTDEFID =" + ConnectionManager.GuidToString(new Guid("65a2337c-bc3c-4c6b-9575-ad47fa7a9a89"));

            if (_GrantMaterial.MKYS_EMalzemeGrup == MKYS_EMalzemeGrupEnum.tibbiCihaz)
                MaterialGrantMaterialDetail.ListFilterExpression = "OBJECTDEFID =" + ConnectionManager.GuidToString(new Guid("f38f2111-0ee4-4b9f-9707-a63ac02d29f4"));

            this._GrantMaterial.MKYS_EAlimYontemi = MKYS_EAlimYontemiEnum.bos;
            this._GrantMaterial.MKYS_ETedarikTuru = MKYS_ETedarikTurEnum.bagisVeYardim;


            if (_GrantMaterial.Store is MainStoreDefinition)
            {
                _GrantMaterial.MKYS_TeslimAlan = ((MainStoreDefinition)_GrantMaterial.Store).GoodsAccountant.Name;
                _GrantMaterial.MKYS_TeslimAlanObjID = ((MainStoreDefinition)_GrantMaterial.Store).GoodsAccountant.ObjectID;
            }

            #endregion GrantMaterialNewForm_ClientSidePreScript

        }

        protected override void PreScript()
        {
            #region GrantMaterialNewForm_PreScript
            base.PreScript();
            this.DropStateButton(ReturningDocument.States.Completed);
            SelectStoreUsage(SelectStoreUsageEnum.UseMainStoreResources, SelectStoreUsageEnum.Nothing);
            #endregion GrantMaterialNewForm_PreScript
        }

    }
}