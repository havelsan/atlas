
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
    public partial class SupplyRequestNewForm
    {
        override protected void BindControlEvents()
        {

            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {

            base.UnBindControlEvents();
        }

        protected override void ClientSidePreScript()
        {
            #region SupplyRequestNewForm_ClientSidePreScript()
            base.ClientSidePreScript();

            MultiSelectForm mSelectForm = new MultiSelectForm();
            mSelectForm.AddMSItem("Boþ", "Boþ", SupplyRequestTypeEnum.None);
            mSelectForm.AddMSItem("Ýlaç", "Ýlaç", SupplyRequestTypeEnum.Ilac);
            mSelectForm.AddMSItem("Sarf Malzeme", "Sarf Malzeme", SupplyRequestTypeEnum.sarfMalzeme);
            mSelectForm.AddMSItem("Demirbaþ", "Demirbaþ", SupplyRequestTypeEnum.demirbas);
            mSelectForm.AddMSItem("Hizmet", "Hizmet", SupplyRequestTypeEnum.hizmet);
            mSelectForm.AddMSItem("Diðer", "Diðer", SupplyRequestTypeEnum.diger);


            string mkey = mSelectForm.GetMSItem(this, "Malzeme/Hizmet istek alým türünü seçiniz. ", true);
            if (string.IsNullOrEmpty(mkey))
                throw new TTException(SystemMessage.GetMessageV2(369, "Ýstek alým türünü seçmeden iþleme devam edemezsiniz."));
            _SupplyRequest.RequestType = (SupplyRequestTypeEnum)mSelectForm.MSSelectedItemObject;


            if (_SupplyRequest.RequestType == SupplyRequestTypeEnum.demirbas || _SupplyRequest.RequestType == SupplyRequestTypeEnum.Ilac || _SupplyRequest.RequestType == SupplyRequestTypeEnum.sarfMalzeme)
            {
                PurchaseGroupSupplyRequestDetail.ListFilterExpression = "ISMATERIAL = 1";

                if (_SupplyRequest.RequestType == SupplyRequestTypeEnum.demirbas)
                    MaterialSupplyRequestDetail.ListFilterExpression = "OBJECTDEFID =" + ConnectionManager.GuidToString(new Guid("f38f2111-0ee4-4b9f-9707-a63ac02d29f4"));
                if (_SupplyRequest.RequestType == SupplyRequestTypeEnum.Ilac)
                    MaterialSupplyRequestDetail.ListFilterExpression = "OBJECTDEFID =" + ConnectionManager.GuidToString(new Guid("65a2337c-bc3c-4c6b-9575-ad47fa7a9a89"));
                if (_SupplyRequest.RequestType == SupplyRequestTypeEnum.sarfMalzeme)
                    MaterialSupplyRequestDetail.ListFilterExpression = "OBJECTDEFID =" + ConnectionManager.GuidToString(new Guid("58d34696-808e-47de-87e0-1f001d0928a7"));

            }
            else if (_SupplyRequest.RequestType == SupplyRequestTypeEnum.hizmet)
                PurchaseGroupSupplyRequestDetail.ListFilterExpression = "ISMATERIAL <> 1";

            else
                throw new TTException(SystemMessage.GetMessageV2(369, "Ýstek alým türünü Demirbaþ,Ýlaç,Sarf Malzeme ve ya hizmet alýmý seçilmeli."));


            #endregion SupplyRequestNewForm_ClientSidePreScript()
        }

        protected override void PreScript()
        {
            #region SupplyRequestNewForm_PreScript
            SelectStoreUsage(SelectStoreUsageEnum.UseRoomStores, SelectStoreUsageEnum.UseMainStores);

            this._SupplyRequest.SignUser = ((SubStoreDefinition)this.Store).StoreResponsible;

            #endregion SupplyRequestNewForm_PreScript
        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
            base.PostScript(transDef);

            List<SupplyRequestDetail> tempDetList = new List<SupplyRequestDetail>();
            foreach (SupplyRequestDetail detIn in _SupplyRequest.SupplyRequestDetails)
            {
                tempDetList.Add(detIn);
            }
            int i = 0;
            foreach (SupplyRequestDetail tempDet in tempDetList)
            {
                foreach (SupplyRequestDetail det in _SupplyRequest.SupplyRequestDetails)
                {
                    if (tempDet.Material == det.Material)
                        i++;
                }

                if (i > 1)
                {
                    throw new Exception(tempDet.Material.Name + " istek malzeme türünden" + i.ToString() + " kadar istek girilmiþtir. Ayný istek malzemesinden 1'den fazla istek yapýlmamalýdýr!");
                }

                i = 0;
            }


        }


    }
}