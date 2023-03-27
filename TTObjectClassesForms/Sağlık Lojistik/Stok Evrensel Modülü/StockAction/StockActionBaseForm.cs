
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
    public partial class StockActionBaseForm : ActionForm
    {
        protected override void PreScript()
        {
            #region StockActionBaseForm_PreScript
            base.PreScript();

            if (TTObjectClasses.SystemParameter.IsWorkWithOutStock == true)
            {
                if (this._StockAction is KSchedule == false)
                    throw new Exception(SystemMessage.GetMessage(1233));
            }
            #endregion StockActionBaseForm_PreScript

        }

        protected override void PostScript(TTObjectStateTransitionDef transDef)
        {
            #region StockActionBaseForm_PostScript
            base.PostScript(transDef);

            if (transDef != null)
            {
                //                if (_StockAction.StockActionInDetails.Count > 0)
                //                {
                //                    if (_StockAction is IChattelDocumentInputWithAccountancy || _StockAction is IChattelDocumentWithPurchase || _StockAction is ICensusFixed || _StockAction is IConsignedCensusFixed)
                //                    {
                //                        CheckExpirationDateRequired();
                //                        CheckLotNoRequired() ;
                //                    }
                //                }

                string errMsg = string.Empty;
                foreach (StockActionDetail stockActionDetail in _StockAction.StockActionDetails)
                {
                    if (stockActionDetail.Material != null)
                    {
                        if (stockActionDetail.Material.StockCard == null)
                            errMsg += "\r\n" + stockActionDetail.Material.Name;
                    }
                }
                if (string.IsNullOrEmpty(errMsg) == false)
                    throw new Exception(SystemMessage.GetMessageV3(1234, new string[] { errMsg.ToString() }));
            }
            #endregion StockActionBaseForm_PostScript

        }

        #region StockActionBaseForm_Methods
        protected virtual void CheckExpirationDateRequired()
        {

            string errorMessage = String.Empty;
            foreach (StockActionDetailIn stockActionDetailIn in _StockAction.StockActionInDetails)
                if (stockActionDetailIn.Material.StockCard.StockMethod == StockMethodEnum.ExpirationDated && stockActionDetailIn.ExpirationDate.HasValue == false)
                    errorMessage += stockActionDetailIn.Material.StockCard.NATOStockNO + " " + stockActionDetailIn.Material.Name + "\r\n";

            if (string.IsNullOrEmpty(errorMessage) == false)
                throw new Exception(SystemMessage.GetMessageV3(1235, new string[] { errorMessage.ToString() }));
        }

        protected virtual void CheckLotNoRequired()
        {

            string errorMessage = String.Empty;
            foreach (StockActionDetailIn stockActionDetailIn in _StockAction.StockActionInDetails)
                if (stockActionDetailIn.Material.StockCard.StockMethod == StockMethodEnum.LotUsed && string.IsNullOrEmpty(stockActionDetailIn.LotNo))
                    errorMessage += stockActionDetailIn.Material.StockCard.NATOStockNO + " " + stockActionDetailIn.Material.Name + "\r\n";

            if (string.IsNullOrEmpty(errorMessage) == false)
                throw new Exception("Aşağıdaki malzemelere Lot numarası girilmesi zorunludur.\r\n" + errorMessage);
        }




        protected virtual void CheckWhetherTheInventoryOfMaterial(Int32 rowIndex, Int32 columnIndex, ITTGrid controlledGrid)
        {
            //            if (columnIndex == -1)
            //            {
            //                if (controlledGrid.Rows.Count > 0 && rowIndex <= controlledGrid.Rows.Count - 1)
            //                {
            //                    ITTGridRow currentRow = controlledGrid.Rows[rowIndex];
            //                    if (currentRow.TTObject != null)
            //                    {
            //                        StockActionDetail stockActionDetail = currentRow.TTObject as StockActionDetail;
            //                        if (stockActionDetail.Material is FixedAssetDefinition == false)
            //                        {
            //                            if((bool)stockActionDetail.Material.isUseQRCode == false)
            //                                throw new Exception(SystemMessage.GetMessage(1236));
            //                        }
            //                        else
            //                        {
            //                            if (stockActionDetail.Material.StockCard.StockMethod != StockMethodEnum.SerialNumbered)
            //                            {
            //                                if((bool)stockActionDetail.Material.isUseQRCode == false)
            //                                    throw new Exception(SystemMessage.GetMessage(1237));
            //                            }
            //                        }
            //                    }
            //                }
            //                else
            //                {
            //                    throw new Exception(SystemMessage.GetMessage(1236));
            //                }
            //            }
        }

        protected override void AfterContextSavedScript(TTObjectStateTransitionDef transDef)
        {
            base.AfterContextSavedScript(transDef);

            _StockAction.AutoDocumentNumberOperation();

            // Eğer FixedAssetMaterialDef oluşturuluyorsa Sağlık XXXXXX ve Sihhi İkmal 'e gönderilmesini sağlar.
            //            if (transDef != null && transDef.BaseTransDef != null)
            //            {
            //                if (transDef.BaseTransDef.ToStateDefID == StockAction.States.Completed || transDef.BaseTransDef.ToStateDefID == new Guid("59902f62-50e7-406f-972f-8394bc6b86e9"))
            //                {
            //                    foreach (StockActionDetail stockActionDetail in _StockAction.StockActionDetails)
            //                    {
            //                        if (stockActionDetail.Material.StockCard.StockMethod == StockMethodEnum.SerialNumbered)
            //                        {
            //                            if (stockActionDetail.FixedAssetDetails.Count > 0 && stockActionDetail.FixedAssetDetails[0] is FixedAssetInDetail)
            //                            {
            //                                foreach (StockTransaction stockTransaction in stockActionDetail.StockTransactions)
            //                                {
            //                                    foreach (FixedAssetTransaction fixedAssetTransaction in stockTransaction.FixedAssetTransactions)
            //                                    {
            //                                        TTObjectContext context = new TTObjectContext(false);
            //                                        List<Sites> targetSites = new List<Sites>();
            //                                        targetSites.Add(Sites.AllSites[Sites.SiteSihhiIkmal]);
            //                                        targetSites.Add(Sites.AllSites[Sites.SiteMerkezSagKom]);
            //                                        FixedAssetMaterialDefinition sendFixedAssetMaterialDefinition = (FixedAssetMaterialDefinition)context.GetObject(fixedAssetTransaction.FixedAsset.ObjectID, typeof(FixedAssetMaterialDefinition).Name);
            //                                        sendFixedAssetMaterialDefinition.Stock = null;
            //                                        sendFixedAssetMaterialDefinition.Resource = null;
            //                                        sendFixedAssetMaterialDefinition.ResUser = null;
            //
            //                                        FixedAssetMaterialDefinitionDetail sendFixedAssetMaterialDefinitionDetail = null;
            //                                        if (fixedAssetTransaction.FixedAsset.FixedAssetMaterialDefDetail != null)
            //                                            sendFixedAssetMaterialDefinitionDetail = (FixedAssetMaterialDefinitionDetail)context.GetObject(fixedAssetTransaction.FixedAsset.FixedAssetMaterialDefDetail.ObjectID, typeof(FixedAssetMaterialDefinitionDetail).Name);
            //
            //                                        foreach (Sites sites in targetSites)
            //                                        {
            //                                            FixedAssetMaterialDefinition.RemoteMethods.SendFixedAssetMaterialDefinition(sites.ObjectID, sendFixedAssetMaterialDefinition, sendFixedAssetMaterialDefinitionDetail);
            //                                        }
            //                                        context.Dispose();
            //                                    }
            //                                }
            //                            }
            //                        }
            //                    }
            //                }
            //            }
        }
        public void SelectStoreUsage(SelectStoreUsageEnum storeUsageEnum, SelectStoreUsageEnum destinationStoreUsageEnum)
        {
            switch (storeUsageEnum)
            {
                case SelectStoreUsageEnum.Nothing:
                    _StockAction.Store = null;
                    break;
                case SelectStoreUsageEnum.UseTentativeStoreResources:
                    List<TentativeStoreDefinition> selectableTentativeStores = new List<TentativeStoreDefinition>();
                    foreach (UserResource userResource in Common.CurrentResource.UserResources)
                    {
                        if (userResource.Resource.EnabledType == ResourceEnableType.BothInpatientAndOutPatient || userResource.Resource.EnabledType == ResourceEnableType.InPatient || userResource.Resource.EnabledType == ResourceEnableType.OutPatient || userResource.Resource.EnabledType == ResourceEnableType.Secmaster)
                            if (userResource.Resource.Store != null && userResource.Resource.Store is TentativeStoreDefinition)
                                if (selectableTentativeStores.Contains((TentativeStoreDefinition)userResource.Resource.Store) == false)
                                    selectableTentativeStores.Add((TentativeStoreDefinition)userResource.Resource.Store);
                    }

                    if (selectableTentativeStores.Count == 1)
                    {
                        _StockAction.Store = selectableTentativeStores[0];
                    }
                    else
                    {
                        MultiSelectForm mSelectForm = new MultiSelectForm();
                        foreach (TentativeStoreDefinition tentativeStore in selectableTentativeStores)
                            mSelectForm.AddMSItem(tentativeStore.Name, tentativeStore.ObjectID.ToString(), tentativeStore);

                        string mkey = mSelectForm.GetMSItem(this, "İlgili Muvakkat Depoyu Seçiniz", true);
                        if (string.IsNullOrEmpty(mkey))
                            throw new TTException(SystemMessage.GetMessageV2(369, "İşlemin yapılacağı muvakkat depo seçilmeden işleme devam edemezsiniz."));
                        _StockAction.Store = mSelectForm.MSSelectedItemObject as TentativeStoreDefinition;
                    }
                    break;
                case SelectStoreUsageEnum.UseTentativeStores:
                    IList tentativeStores = TentativeStoreDefinition.GetAllTentativeStores(_StockAction.ObjectContext);
                    if (tentativeStores.Count == 0)
                        throw new TTException(SystemMessage.GetMessageV2(370, "İşlemin yapılacağı muvakkat depo bulunamadığından işleme devam edemezsiniz."));
                    if (tentativeStores.Count == 1)
                    {
                        _StockAction.Store = (TentativeStoreDefinition)tentativeStores[0];
                    }
                    else
                    {
                        MultiSelectForm mSelectForm = new MultiSelectForm();
                        foreach (TentativeStoreDefinition tentativeStore in tentativeStores)
                            mSelectForm.AddMSItem(tentativeStore.Name, tentativeStore.ObjectID.ToString(), tentativeStore);

                        string mkey = mSelectForm.GetMSItem(this, "İlgili  Muvakkat Depoyu Seçiniz", true);
                        if (string.IsNullOrEmpty(mkey))
                            throw new TTException(SystemMessage.GetMessageV2(369, "İşlemin yapılacağı muvakkat depo seçilmeden işleme devam edemezsiniz."));
                        _StockAction.Store = mSelectForm.MSSelectedItemObject as TentativeStoreDefinition;
                    }
                    break;
                case SelectStoreUsageEnum.UseMainStoreResources:
                    List<MainStoreDefinition> selectableMainStores = new List<MainStoreDefinition>();
                    foreach (UserResource userResource in Common.CurrentResource.UserResources)
                    {
                        if (userResource.Resource.EnabledType == ResourceEnableType.BothInpatientAndOutPatient || userResource.Resource.EnabledType == ResourceEnableType.InPatient || userResource.Resource.EnabledType == ResourceEnableType.OutPatient || userResource.Resource.EnabledType == ResourceEnableType.Secmaster)
                            if (userResource.Resource.Store != null && userResource.Resource.Store is MainStoreDefinition)
                                if (selectableMainStores.Contains((MainStoreDefinition)userResource.Resource.Store) == false)
                                    selectableMainStores.Add((MainStoreDefinition)userResource.Resource.Store);
                    }

                    if (selectableMainStores.Count == 1)
                    {
                        _StockAction.Store = selectableMainStores[0];
                    }
                    else
                    {
                        MultiSelectForm mSelectForm = new MultiSelectForm();
                        foreach (MainStoreDefinition mainStore in selectableMainStores)
                            mSelectForm.AddMSItem(mainStore.Name, mainStore.ObjectID.ToString(), mainStore);

                        string mkey = mSelectForm.GetMSItem(this, "İlgili Ana Depoyu Seçiniz", true);
                        if (string.IsNullOrEmpty(mkey))
                            throw new TTException(SystemMessage.GetMessageV2(371, "İşlemin yapılacağı ana depo seçilmeden işleme devam edemezsiniz."));
                        _StockAction.Store = mSelectForm.MSSelectedItemObject as MainStoreDefinition;
                    }
                    break;
                case SelectStoreUsageEnum.UseMainStores:
                    IList mainStores = MainStoreDefinition.GetAllMainStores(_StockAction.ObjectContext);
                    if (mainStores.Count == 0)
                    {
                        throw new TTException(SystemMessage.GetMessageV2(372, "İşlemin yapılacağı ana depo bulunamadığından işleme devam edemezsiniz."));
                    }
                    if (mainStores.Count == 1)
                    {
                        _StockAction.Store = (MainStoreDefinition)mainStores[0];
                    }
                    else
                    {
                        MultiSelectForm mSelectForm = new MultiSelectForm();
                        foreach (MainStoreDefinition mainStore in mainStores)
                            mSelectForm.AddMSItem(mainStore.Name, mainStore.ObjectID.ToString(), mainStore);

                        string mkey = mSelectForm.GetMSItem(this, "İlgili Ana Depoyu Seçiniz", true);
                        if (string.IsNullOrEmpty(mkey))
                            throw new TTException(SystemMessage.GetMessageV2(371, "İşlemin yapılacağı ana depo seçilmeden işleme devam edemezsiniz."));
                        _StockAction.Store = mSelectForm.MSSelectedItemObject as MainStoreDefinition;
                    }
                    break;
                case SelectStoreUsageEnum.UseUserResource:
                    _StockAction.Store = Common.CurrentResource.Store;
                    break;
                case SelectStoreUsageEnum.UseUserResources:
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
                        _StockAction.Store = selectableStore[0];
                    }
                    else
                    {
                        MultiSelectForm mSelectForm = new MultiSelectForm();
                        foreach (Store store in selectableStore)
                            mSelectForm.AddMSItem(store.Name, store.ObjectID.ToString(), store);

                        string mkey = mSelectForm.GetMSItem(this, "İlgili Depoyu Seçiniz", true);
                        if (string.IsNullOrEmpty(mkey))
                            throw new TTException(SystemMessage.GetMessageV2(249, "İşlemin yapılacağı depo seçilmeden işleme devam edemezsiniz."));
                        _StockAction.Store = mSelectForm.MSSelectedItemObject as Store;
                    }
                    break;
                case SelectStoreUsageEnum.UseInPatientUserResource:
                    selectableStore = new List<Store>();
                    foreach (UserResource userResource in Common.CurrentResource.UserResources)
                    {
                        if (userResource.Resource.EnabledType == ResourceEnableType.InPatient)
                            if (userResource.Resource.Store != null)
                                if (selectableStore.Contains(userResource.Resource.Store) == false)
                                    selectableStore.Add(userResource.Resource.Store);
                    }

                    if (selectableStore.Count == 1)
                        _StockAction.Store = selectableStore[0];
                    else
                    {
                        MultiSelectForm mSelectForm = new MultiSelectForm();
                        foreach (Store store in selectableStore)
                            mSelectForm.AddMSItem(store.Name, store.ObjectID.ToString(), store);

                        string mkey = mSelectForm.GetMSItem(this, "İlgili Depoyu Seçiniz", true);
                        if (string.IsNullOrEmpty(mkey))
                            throw new TTException(SystemMessage.GetMessageV2(249, "İşlemin yapılacağı depo seçilmeden işleme devam edemezsiniz."));
                        _StockAction.Store = mSelectForm.MSSelectedItemObject as Store;

                    }
                    break;
                case SelectStoreUsageEnum.UseOutPatientUserResource:
                    selectableStore = new List<Store>();
                    foreach (UserResource userResource in Common.CurrentResource.UserResources)
                    {
                        if (userResource.Resource.EnabledType == ResourceEnableType.OutPatient)
                            if (userResource.Resource.Store != null)
                                if (selectableStore.Contains(userResource.Resource.Store) == false)
                                    selectableStore.Add(userResource.Resource.Store);
                    }

                    if (selectableStore.Count == 1)
                        _StockAction.Store = selectableStore[0];
                    else
                    {
                        MultiSelectForm mSelectForm = new MultiSelectForm();
                        foreach (Store store in selectableStore)
                            mSelectForm.AddMSItem(store.Name, store.ObjectID.ToString(), store);

                        string mkey = mSelectForm.GetMSItem(this, "İlgili Depoyu Seçiniz", true);
                        if (string.IsNullOrEmpty(mkey))
                            throw new TTException(SystemMessage.GetMessageV2(249, "İşlemin yapılacağı depo seçilmeden işleme devam edemezsiniz."));
                        _StockAction.Store = mSelectForm.MSSelectedItemObject as Store;
                    }
                    break;
                case SelectStoreUsageEnum.UseSecMasterUserResource:
                    selectableStore = new List<Store>();
                    foreach (UserResource userResource in Common.CurrentResource.UserResources)
                    {
                        if (userResource.Resource.EnabledType == ResourceEnableType.Secmaster)
                            if (userResource.Resource.Store != null)
                                if (selectableStore.Contains(userResource.Resource.Store) == false)
                                    selectableStore.Add(userResource.Resource.Store);
                    }

                    if (selectableStore.Count == 1)
                    {
                        _StockAction.Store = selectableStore[0];
                    }
                    else
                    {
                        MultiSelectForm mSelectForm = new MultiSelectForm();
                        foreach (Store store in selectableStore)
                            mSelectForm.AddMSItem(store.Name, store.ObjectID.ToString(), store);

                        string mkey = mSelectForm.GetMSItem(this, "İlgili Depoyu Seçiniz", true);
                        if (string.IsNullOrEmpty(mkey))
                            throw new TTException(SystemMessage.GetMessageV2(249, "İşlemin yapılacağı depo seçilmeden işleme devam edemezsiniz."));
                        _StockAction.Store = mSelectForm.MSSelectedItemObject as Store;
                    }
                    break;
                case SelectStoreUsageEnum.UseSelectedInPatientUserResource:
                case SelectStoreUsageEnum.UseSelectedOutPatientUserResource:
                case SelectStoreUsageEnum.UseSelectedSecMasterUserResource:
                    ResSection resSection = null;
                    if (storeUsageEnum == SelectStoreUsageEnum.UseSelectedInPatientUserResource)
                        resSection = Common.CurrentResource.SelectedInPatientResource;
                    if (storeUsageEnum == SelectStoreUsageEnum.UseSelectedOutPatientUserResource)
                        resSection = Common.CurrentResource.SelectedOutPatientResource;
                    if (storeUsageEnum == SelectStoreUsageEnum.UseSelectedSecMasterUserResource)
                        resSection = Common.CurrentResource.SelectedSecMasterResource;
                    if (resSection == null || resSection.Store == null)
                        throw new Exception(SystemMessage.GetMessageV2(373, "Kullanıcının oda deposu bulunmamaktadır"));

                    _StockAction.Store = resSection.Store;
                    break;
                case SelectStoreUsageEnum.UseRoomStores:
                    List<Store> selectableRoomStore = new List<Store>();
                    foreach (UserResource userResource in Common.CurrentResource.UserResources)
                    {
                        if (userResource.Resource.Store is RoomStoreDefinition)
                        {
                            if (selectableRoomStore.Contains((Store)userResource.Resource.Store) == false)
                            {
                                selectableRoomStore.Add((Store)userResource.Resource.Store);
                            }
                        }
                        if (userResource.Resource.Store is PharmacyStoreDefinition)
                        {
                            if (((PharmacyStoreDefinition)userResource.Resource.Store).UnitStoreDefinition != null)
                            {
                                if (selectableRoomStore.Contains((Store)userResource.Resource.Store) == false)
                                {
                                    selectableRoomStore.Add((Store)userResource.Resource.Store);
                                }
                            }
                        }
                    }
                    if (selectableRoomStore.Count == 1)
                        _StockAction.Store = selectableRoomStore[0];
                    else
                    {
                        MultiSelectForm mSelectForm = new MultiSelectForm();
                        foreach (Store store in selectableRoomStore)
                            mSelectForm.AddMSItem(store.Name, store.ObjectID.ToString(), store);

                        string mkey = mSelectForm.GetMSItem(this, "İlgili Depoyu Seçiniz", true);
                        if (string.IsNullOrEmpty(mkey))
                            throw new TTException(SystemMessage.GetMessageV2(249, "İşlemin yapılacağı depo seçilmeden işleme devam edemezsiniz."));
                        _StockAction.Store = mSelectForm.MSSelectedItemObject as Store;
                    }
                    break;
                case SelectStoreUsageEnum.UseRoomStoreParentSubStore:
                    List<Store> selectableParentStore = new List<Store>();
                    foreach (UserResource userResource in Common.CurrentResource.UserResources)
                    {
                        if (userResource.Resource.Store is RoomStoreDefinition)
                        {
                            Store sStore = ((Store)((RoomStoreDefinition)userResource.Resource.Store).ParentStore);
                            if (sStore != null)
                            {
                                if (selectableParentStore.Contains(sStore) == false)
                                    selectableParentStore.Add(sStore);
                            }
                        }
                        if (userResource.Resource.Store is PharmacyStoreDefinition)
                        {
                            if (((PharmacyStoreDefinition)userResource.Resource.Store).UnitStoreDefinition != null)
                            {
                                Store sStore = ((Store)((PharmacyStoreDefinition)userResource.Resource.Store).UnitStoreDefinition);
                                if (sStore != null)
                                {
                                    if (selectableParentStore.Contains(sStore) == false)
                                        selectableParentStore.Add(sStore);
                                }
                            }
                        }
                        //}
                    }
                    if (selectableParentStore.Count == 1)
                        _StockAction.Store = selectableParentStore[0];
                    else
                    {
                        MultiSelectForm mSelectForm = new MultiSelectForm();
                        foreach (Store store in selectableParentStore)
                            mSelectForm.AddMSItem(store.Name, store.ObjectID.ToString(), store);

                        string mkey = mSelectForm.GetMSItem(this, "İlgili Depoyu Seçiniz", true);
                        if (string.IsNullOrEmpty(mkey))
                            throw new TTException(SystemMessage.GetMessageV2(249, "İşlemin yapılacağı depo seçilmeden işleme devam edemezsiniz."));
                        _StockAction.Store = mSelectForm.MSSelectedItemObject as Store;
                    }
                    break;
                case SelectStoreUsageEnum.UseUnitStoreResources:

                    List<IUnitStoreDefinition> selectableUnitStores = new List<IUnitStoreDefinition>();
                    foreach (UserResource userResource in Common.CurrentResource.UserResources)
                    {
                        if (userResource.Resource.EnabledType == ResourceEnableType.BothInpatientAndOutPatient || userResource.Resource.EnabledType == ResourceEnableType.InPatient || userResource.Resource.EnabledType == ResourceEnableType.OutPatient || userResource.Resource.EnabledType == ResourceEnableType.Secmaster)
                            if (userResource.Resource.Store != null && userResource.Resource.Store is IUnitStoreDefinition)
                                if (selectableUnitStores.Contains((IUnitStoreDefinition)userResource.Resource.Store) == false)
                                    selectableUnitStores.Add((IUnitStoreDefinition)userResource.Resource.Store);
                    }

                    if (selectableUnitStores.Count == 1)
                    {
                        _StockAction.Store = (Store)selectableUnitStores[0];
                    }
                    else
                    {
                        MultiSelectForm mSelectForm = new MultiSelectForm();
                        foreach (IUnitStoreDefinition unitStore in selectableUnitStores)
                            mSelectForm.AddMSItem(unitStore.GetName(), unitStore.GetObjectID().ToString(), unitStore);

                        string mkey = mSelectForm.GetMSItem(this, "İlgili Birlik Deposunu Seçiniz", true);
                        if (string.IsNullOrEmpty(mkey))
                            throw new TTException(SystemMessage.GetMessageV2(371, "İşlemin yapılacağı birlik deposu seçilmeden işleme devam edemezsiniz."));
                        _StockAction.Store = mSelectForm.MSSelectedItemObject as Store;
                    }
                    break;
                default:
                    throw new Exception(SystemMessage.GetMessageV2(374, "Tanımsız kriter işlem yapılamaz."));
            }

            switch (destinationStoreUsageEnum)
            {
                case SelectStoreUsageEnum.Nothing:
                    _StockAction.DestinationStore = null;
                    break;
                case SelectStoreUsageEnum.UseMainStoreResources:
                    List<MainStoreDefinition> selectableMainStores = new List<MainStoreDefinition>();
                    foreach (UserResource userResource in Common.CurrentResource.UserResources)
                    {
                        if (userResource.Resource.EnabledType == ResourceEnableType.BothInpatientAndOutPatient || userResource.Resource.EnabledType == ResourceEnableType.InPatient || userResource.Resource.EnabledType == ResourceEnableType.OutPatient || userResource.Resource.EnabledType == ResourceEnableType.Secmaster)
                            if (userResource.Resource.Store != null && userResource.Resource.Store is MainStoreDefinition)
                                if (selectableMainStores.Contains((MainStoreDefinition)userResource.Resource.Store) == false)
                                    selectableMainStores.Add((MainStoreDefinition)userResource.Resource.Store);
                    }

                    if (selectableMainStores.Count == 1)
                    {
                        _StockAction.DestinationStore = selectableMainStores[0];
                    }
                    else
                    {
                        MultiSelectForm mSelectForm = new MultiSelectForm();
                        foreach (MainStoreDefinition mainStore in selectableMainStores)
                            mSelectForm.AddMSItem(mainStore.Name, mainStore.ObjectID.ToString(), mainStore);

                        string mkey = mSelectForm.GetMSItem(this, "İlgili Ana Depoyu Seçiniz", true);
                        if (string.IsNullOrEmpty(mkey))
                            throw new TTException(SystemMessage.GetMessageV2(371, "İşlemin yapılacağı ana depo seçilmeden işleme devam edemezsiniz."));
                        _StockAction.DestinationStore = mSelectForm.MSSelectedItemObject as MainStoreDefinition;
                    }
                    break;
                case SelectStoreUsageEnum.UseMainStores:
                    // Bağlı Birlikler için Tüketim Üretim Elde Edilenler belgesi çalışması için yapıldı.SS
                    if (_StockAction is ProductionConsumptionDocument && _StockAction.Store is IUnitStoreDefinition)
                    {
                        break;
                    }

                    IList mainStores = MainStoreDefinition.GetAllMainStores(_StockAction.ObjectContext);




                    if (mainStores.Count == 0)
                        throw new TTException(SystemMessage.GetMessageV2(372, "İşlemin yapılacağı ana depo bulunamadığından işleme devam edemezsiniz."));

                    if (mainStores.Count == 1)
                    {
                        _StockAction.DestinationStore = (MainStoreDefinition)mainStores[0];
                    }
                    else
                    {
                        MultiSelectForm mSelectForm = new MultiSelectForm();
                        foreach (MainStoreDefinition mainStore in mainStores)
                        {
                            if ( mainStore.ObjectID != _StockAction.Store.ObjectID) //((MainStoreDefinition)(mainStore)).MKYS_ButceTuru == ((MainStoreDefinition)(_StockAction.Store)).MKYS_ButceTuru &&
                                mSelectForm.AddMSItem(mainStore.Name, mainStore.ObjectID.ToString(), mainStore);
                        }

                        string mkey = mSelectForm.GetMSItem(this, "İlgili Ana Depoyu Seçiniz", true);
                        if (string.IsNullOrEmpty(mkey))
                            throw new TTException(SystemMessage.GetMessageV2(371, "İşlemin yapılacağı ana depo seçilmeden işleme devam edemezsiniz."));
                        _StockAction.DestinationStore = mSelectForm.MSSelectedItemObject as MainStoreDefinition;
                    }
                    break;
                case SelectStoreUsageEnum.UseUserResource:
                    _StockAction.DestinationStore = Common.CurrentResource.Store;
                    break;
                case SelectStoreUsageEnum.UseUserResources:
                    List<Store> selectableStore = new List<Store>();
                    foreach (UserResource userResource in Common.CurrentResource.UserResources)
                    {
                        if (userResource.Resource.EnabledType == ResourceEnableType.BothInpatientAndOutPatient || userResource.Resource.EnabledType == ResourceEnableType.InPatient || userResource.Resource.EnabledType == ResourceEnableType.OutPatient || userResource.Resource.EnabledType == ResourceEnableType.Secmaster)
                            if (userResource.Resource.Store != null)
                                if (selectableStore.Contains(userResource.Resource.Store) == false)
                                    selectableStore.Add(userResource.Resource.Store);
                    }

                    if (selectableStore.Count == 1)
                        _StockAction.DestinationStore = selectableStore[0];
                    else
                    {
                        MultiSelectForm mSelectForm = new MultiSelectForm();
                        foreach (Store store in selectableStore)
                            mSelectForm.AddMSItem(store.Name, store.ObjectID.ToString(), store);

                        string mkey = mSelectForm.GetMSItem(this, "İlgili Depoyu Seçiniz", true);
                        if (string.IsNullOrEmpty(mkey))
                            throw new TTException(SystemMessage.GetMessageV2(249, "İşlemin yapılacağı depo seçilmeden işleme devam edemezsiniz."));
                        _StockAction.DestinationStore = mSelectForm.MSSelectedItemObject as Store;
                    }
                    break;
                case SelectStoreUsageEnum.UseInPatientUserResource:
                    selectableStore = new List<Store>();
                    foreach (UserResource userResource in Common.CurrentResource.UserResources)
                    {
                        if (userResource.Resource.EnabledType == ResourceEnableType.InPatient)
                            if (userResource.Resource.Store != null)
                                if (selectableStore.Contains(userResource.Resource.Store) == false)
                                    selectableStore.Add(userResource.Resource.Store);
                    }

                    if (selectableStore.Count == 1)
                        _StockAction.DestinationStore = selectableStore[0];
                    else
                    {
                        MultiSelectForm mSelectForm = new MultiSelectForm();
                        foreach (Store store in selectableStore)
                            mSelectForm.AddMSItem(store.Name, store.ObjectID.ToString(), store);

                        string mkey = mSelectForm.GetMSItem(this, "İlgili Depoyu Seçiniz", true);
                        if (string.IsNullOrEmpty(mkey))
                            throw new TTException(SystemMessage.GetMessageV2(249, "İşlemin yapılacağı depo seçilmeden işleme devam edemezsiniz."));
                        _StockAction.DestinationStore = mSelectForm.MSSelectedItemObject as Store;
                    }
                    break;
                case SelectStoreUsageEnum.UseOutPatientUserResource:
                    selectableStore = new List<Store>();
                    foreach (UserResource userResource in Common.CurrentResource.UserResources)
                    {
                        if (userResource.Resource.EnabledType == ResourceEnableType.OutPatient)
                            if (userResource.Resource.Store != null)
                                if (selectableStore.Contains(userResource.Resource.Store) == false)
                                    selectableStore.Add(userResource.Resource.Store);
                    }

                    if (selectableStore.Count == 1)
                        _StockAction.DestinationStore = selectableStore[0];
                    else
                    {
                        MultiSelectForm mSelectForm = new MultiSelectForm();
                        foreach (Store store in selectableStore)
                            mSelectForm.AddMSItem(store.Name, store.ObjectID.ToString(), store);

                        string mkey = mSelectForm.GetMSItem(this, "İlgili Depoyu Seçiniz", true);
                        if (string.IsNullOrEmpty(mkey))
                            throw new TTException(SystemMessage.GetMessageV2(249, "İşlemin yapılacağı depo seçilmeden işleme devam edemezsiniz."));
                        _StockAction.DestinationStore = mSelectForm.MSSelectedItemObject as Store;
                    }
                    break;
                case SelectStoreUsageEnum.UseSecMasterUserResource:
                    selectableStore = new List<Store>();
                    foreach (UserResource userResource in Common.CurrentResource.UserResources)
                    {
                        if (userResource.Resource.EnabledType == ResourceEnableType.Secmaster)
                            if (userResource.Resource.Store != null)
                                if (selectableStore.Contains(userResource.Resource.Store) == false)
                                    selectableStore.Add(userResource.Resource.Store);
                    }

                    if (selectableStore.Count == 1)
                        _StockAction.DestinationStore = selectableStore[0];
                    else
                    {
                        MultiSelectForm mSelectForm = new MultiSelectForm();
                        foreach (Store store in selectableStore)
                            mSelectForm.AddMSItem(store.Name, store.ObjectID.ToString(), store);

                        string mkey = mSelectForm.GetMSItem(this, "İlgili Depoyu Seçiniz", true);
                        if (string.IsNullOrEmpty(mkey))
                            throw new TTException(SystemMessage.GetMessageV2(249, "İşlemin yapılacağı depo seçilmeden işleme devam edemezsiniz."));
                        _StockAction.DestinationStore = mSelectForm.MSSelectedItemObject as Store;
                    }
                    break;
                case SelectStoreUsageEnum.UseSelectedInPatientUserResource:
                case SelectStoreUsageEnum.UseSelectedOutPatientUserResource:
                case SelectStoreUsageEnum.UseSelectedSecMasterUserResource:
                    ResSection resSection = null;
                    if (destinationStoreUsageEnum == SelectStoreUsageEnum.UseSelectedInPatientUserResource)
                        resSection = Common.CurrentResource.SelectedInPatientResource;
                    if (destinationStoreUsageEnum == SelectStoreUsageEnum.UseSelectedOutPatientUserResource)
                        resSection = Common.CurrentResource.SelectedOutPatientResource;
                    if (destinationStoreUsageEnum == SelectStoreUsageEnum.UseSelectedSecMasterUserResource)
                        resSection = Common.CurrentResource.SelectedSecMasterResource;
                    if (resSection == null || resSection.Store == null)
                        throw new Exception(SystemMessage.GetMessageV2(373, "Kullanıcının oda deposu bulunmamaktadır"));

                    _StockAction.DestinationStore = resSection.Store;
                    break;
                case SelectStoreUsageEnum.UseRoomStoreParentSubStore:
                    if (_StockAction.Store is RoomStoreDefinition)
                        _StockAction.DestinationStore = ((RoomStoreDefinition)_StockAction.Store).ParentStore;
                    else if (_StockAction.Store is PharmacyStoreDefinition)
                        _StockAction.DestinationStore = ((PharmacyStoreDefinition)_StockAction.Store).UnitStoreDefinition;
                    break;
                case SelectStoreUsageEnum.UseRoomStores:
                    List<Store> selectableRoomStore = new List<Store>();
                    IList roomStores = RoomStoreDefinition.GetParentStoreByRoomStore(_StockAction.ObjectContext, _StockAction.Store.ObjectID);
                    IList pharmacyStores = PharmacyStoreDefinition.GetPharmacyByUnitStore(_StockAction.ObjectContext, _StockAction.Store.ObjectID);
                    foreach (RoomStoreDefinition rstore in roomStores)
                    {
                        if (selectableRoomStore.Contains(rstore) == false)
                            selectableRoomStore.Add(rstore);
                    }
                    foreach (Store pstore in pharmacyStores)
                    {
                        if (selectableRoomStore.Contains(pstore) == false)
                            selectableRoomStore.Add(pstore);
                    }

                    if (selectableRoomStore.Count == 1)
                        _StockAction.DestinationStore = selectableRoomStore[0];
                    else
                    {
                        MultiSelectForm mSelectForm = new MultiSelectForm();
                        foreach (Store store in selectableRoomStore)
                            mSelectForm.AddMSItem(store.Name, store.ObjectID.ToString(), store);

                        string mkey = mSelectForm.GetMSItem(this, "İlgili Depoyu Seçiniz", true);
                        if (string.IsNullOrEmpty(mkey))
                            throw new TTException(SystemMessage.GetMessageV2(249, "İşlemin yapılacağı depo seçilmeden işleme devam edemezsiniz."));
                        _StockAction.DestinationStore = mSelectForm.MSSelectedItemObject as Store;
                    }
                    break;
                default:
                    throw new Exception(SystemMessage.GetMessageV2(374, "Tanımsız kriter işlem yapılamaz."));
                    //break;
            }
        }

        #endregion StockActionBaseForm_Methods

        #region StockActionBaseForm_ClientSideMethods
        public void ShowStockActionDetailForm(StockActionDetail stockActionDetail)
        {
            TTForm frm = TTForm.GetEditForm(stockActionDetail);
            if (frm == null)
                return;
            try
            {
                if (stockActionDetail.ObjectContext.IsReadOnly)
                    frm.ShowReadOnly(this, stockActionDetail);
                else
                    frm.ShowEdit(this, stockActionDetail);
            }
            catch (Exception ex)
            {
                InfoBox.Alert(ex);
            }
        }

        #endregion StockActionBaseForm_ClientSideMethods
    }
}