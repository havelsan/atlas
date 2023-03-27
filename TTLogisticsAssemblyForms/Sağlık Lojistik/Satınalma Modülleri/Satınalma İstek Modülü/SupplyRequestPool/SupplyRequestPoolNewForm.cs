
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
    public partial class SupplyRequestPoolNewForm : BaseSupplyRequestPoolForm
    {
        protected override void ClientSidePreScript()
        {
            #region SupplyRequestPoolNewForm_ClientSidePreScript()
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
            _SupplyRequestPool.RequestType = (SupplyRequestTypeEnum)mSelectForm.MSSelectedItemObject;


            if (_SupplyRequestPool.RequestType == SupplyRequestTypeEnum.demirbas || _SupplyRequestPool.RequestType == SupplyRequestTypeEnum.Ilac || _SupplyRequestPool.RequestType == SupplyRequestTypeEnum.sarfMalzeme)
                BaseMaterialGroupSupplyRequestPoolDetail.ListFilterExpression = "ISMATERIAL = 1";

            else if (_SupplyRequestPool.RequestType == SupplyRequestTypeEnum.hizmet)
                BaseMaterialGroupSupplyRequestPoolDetail.ListFilterExpression = "ISMATERIAL <> 1";

            else
                throw new TTException(SystemMessage.GetMessageV2(369, "Ýstek alým türünü Demirbaþ,Ýlaç,Sarf Malzeme ve ya hizmet alýmý seçilmeli."));



            BindingList<SupplyRequestDetail> supplyRequestDetails = SupplyRequestDetail.GetSupplyReqDetsByStoreAndDemandType(_SupplyRequestPool.ObjectContext, _SupplyRequestPool.Store.ObjectID, _SupplyRequestPool.RequestType.Value);

            bool poolDetExists = false;
            bool innerDetailExists = false;
            foreach (SupplyRequestDetail det in supplyRequestDetails)
            {
                foreach (SupplyRequestPoolDetail poolDet in _SupplyRequestPool.SupplyRequestPoolDetails)
                {

                    foreach (SupplyRequestDetail innerDetail in poolDet.SupplyRequestDetails)
                    {
                        if (det.ObjectID == innerDetail.ObjectID)
                            innerDetailExists = true;
                    }

                    if (det.Material == poolDet.Material && innerDetailExists == false)
                    {
                        poolDet.TotalRequestAmount += det.RequestAmount;
                        poolDet.Amount += det.PurchaseAmount;
                        poolDet.PurchaseAmount += det.PurchaseAmount;
                        poolDet.SupplyRequestDetails.Add(det);
                        poolDetExists = true;
                        break;
                    }

                    innerDetailExists = false;
                }

                if (!poolDetExists)
                {
                    SupplyRequestPoolDetail poolDetail = new SupplyRequestPoolDetail(_SupplyRequestPool.ObjectContext);
                    poolDetail.TotalRequestAmount = det.RequestAmount;
                    poolDetail.Amount = det.PurchaseAmount;
                    poolDetail.DistributionType = det.Material.StockCard.DistributionType;
                    poolDetail.PurchaseAmount = det.PurchaseAmount;
                    poolDetail.ExcessAmount = 0;
                    //poolDetail.PurchaseGroup = det.PurchaseGroup;
                    poolDetail.Material = det.Material;
                    poolDetail.SupplyRequestDetails.Add(det);
                    poolDetail.SupplyRequestPool = _SupplyRequestPool;

                }


                poolDetExists = false;
            }

            #endregion SupplyRequestPoolNewForm_ClientSidePreScript()
        }

        protected override void PreScript()
        {
            #region SupplyRequestPoolNewForm_PreScript
            SelectStoreUsage(SelectStoreUsageEnum.UseMainStores, SelectStoreUsageEnum.Nothing);

            this._SupplyRequestPool.SignUser = ((MainStoreDefinition)(this._SupplyRequestPool.Store)).AccountManager;
            #endregion SupplyRequestPoolNewForm_PreScript
        }

        #region SupplyRequestPoolNewForm_Methods
        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);
            if (transDef != null)
            {
                if (transDef.ToStateDefID == SupplyRequestPool.States.Approval)
                {
                    foreach (SupplyRequestPoolDetail poolDet in _SupplyRequestPool.SupplyRequestPoolDetails)
                    {
                        foreach (SupplyRequestDetail det in poolDet.SupplyRequestDetails)
                        {
                            det.SupplyRequestStatus = SupplyRequestStatusEnum.AccountingApproval;
                        }
                    }
                }


                if (transDef.ToStateDefID == SupplyRequestPool.States.Completed)
                {
                    foreach (SupplyRequestPoolDetail poolDet in _SupplyRequestPool.SupplyRequestPoolDetails)
                    {
                        if (poolDet.SupplyRqstPlDetStatus == SupplyRqstPlDetStatusEnum.ToBeSent)
                            poolDet.SupplyRqstPlDetStatus = SupplyRqstPlDetStatusEnum.Sent;

                        foreach (SupplyRequestDetail det in poolDet.SupplyRequestDetails)
                        {
                            if (poolDet.SupplyRqstPlDetStatus == SupplyRqstPlDetStatusEnum.Cancelled)
                                det.SupplyRequestStatus = SupplyRequestStatusEnum.RequestCancelled;

                            if (poolDet.SupplyRqstPlDetStatus == SupplyRqstPlDetStatusEnum.SupplyWithExcess)
                                det.SupplyRequestStatus = SupplyRequestStatusEnum.SupplyWithExcess;

                            if (poolDet.SupplyRqstPlDetStatus == SupplyRqstPlDetStatusEnum.Sent)
                                det.SupplyRequestStatus = SupplyRequestStatusEnum.RequestCompleted;
                        }
                    }
                }

            }

            _SupplyRequestPool.ObjectContext.Save();
        }
        #endregion SupplyRequestPoolNewForm_Methods
    }
}