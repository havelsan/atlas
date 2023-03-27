
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



using TTStorageManager;
using System.Runtime.Versioning;


namespace TTObjectClasses
{
    /// <summary>
    /// Sayım Tartı Çizelgesinden İlk Giriş
    /// </summary>
    public  partial class STCFirstInAction : BaseAction, IWorkListBaseAction
    {
#region Methods
        public void CreateStockFirstIn(TTObjectContext objectContext , Dictionary<Guid, STCAction> stActions, MainStoreDefinition mainStore )
        {
            StockFirstIn stockFirstIn = new StockFirstIn(objectContext);
            stockFirstIn.CurrentStateDefID = StockFirstIn.States.New;
            stockFirstIn.Store = mainStore;
            stockFirstIn.IsEntryOldMaterial = true;
            foreach (KeyValuePair<Guid, STCAction> stcValue in stActions)
            {
                STCAction stc = stcValue.Value ;
                double totalAmount = 0;
                Queue<DCAction> demirbaslar = new Queue<DCAction>();
                if(stc.Material.StockCard.StockMethod == StockMethodEnum.SerialNumbered)
                {
                    foreach (DCAction  demirbasCizelgesi in stc.DCActions.Select(string.Empty))
                        demirbaslar.Enqueue(demirbasCizelgesi);
                }
                if (stc.YeniMevcut > 0 || stc.MuvakkatenVerilen > 0)
                {
                    StockFirstInDetail stockFirstInDetail = stockFirstIn.StockFirstInDetails.AddNew();
                    CreateStockFirstInDetail(objectContext, stc, StockLevelType.NewStockLevel, ref demirbaslar, ref stockFirstInDetail);
                    totalAmount += stockFirstInDetail.Amount.Value;
                }
                if (stc.KullanilmisMevcut > 0)
                {
                    StockFirstInDetail stockFirstInDetail = stockFirstIn.StockFirstInDetails.AddNew();
                    CreateStockFirstInDetail(objectContext, stc, StockLevelType.UsedStockLevel, ref demirbaslar, ref stockFirstInDetail);
                    totalAmount += stockFirstInDetail.Amount.Value;
                }
                if (stc.HEKMevcut > 0)
                {
                    StockFirstInDetail stockFirstInDetail = stockFirstIn.StockFirstInDetails.AddNew();
                    CreateStockFirstInDetail(objectContext, stc, StockLevelType.HekStockLevel, ref demirbaslar, ref stockFirstInDetail);
                    totalAmount += stockFirstInDetail.Amount.Value;
                }
                stc.IsFirstIn = true;
            }

            stockFirstIn.Update();
            stockFirstIn.CurrentStateDefID = StockFirstIn.States.Completed;
            try
            {
                objectContext.Save();
            }
            catch (Exception ex)
            {
                TTUtils.InfoMessageService.Instance.ShowMessage(ex.Message);
            }
        }

        private void CreateStockFirstInDetail(TTObjectContext objectContext,STCAction stc,StockLevelType stockLevelType,ref Queue<DCAction> demirbaslar,ref StockFirstInDetail stockFirstInDetail)
        {
            double amount = 0;
            if (stockLevelType.ObjectID.Equals(StockLevelType.NewStockLevel.ObjectID))
                amount = stc.YeniMevcut.Value + stc.MuvakkatenVerilen.Value;
            else if (stockLevelType.ObjectID.Equals(StockLevelType.UsedStockLevel.ObjectID))
                amount = stc.KullanilmisMevcut.Value;
            else if (stockLevelType.ObjectID.Equals(StockLevelType.HekStockLevel.ObjectID))
                amount = stc.HEKMevcut.Value;
            else
                throw new TTException(TTUtils.CultureService.GetText("M25907", "Hatalı veri tipi."));

            Material material = stc.Material ;
            stockFirstInDetail.Material = material;
            stockFirstInDetail.Amount = amount;
            stockFirstInDetail.VatRate = 0;
            if (stc.ToplamTutar > 0 && stc.Toplam > 0)
                stockFirstInDetail.UnitPrice = stc.ToplamTutar / (Currency)stc.Toplam;
            else
                stockFirstInDetail.UnitPrice = 0;

            stockFirstInDetail.StockLevelType = stockLevelType;
            stockFirstInDetail.Status = StockActionDetailStatusEnum.New;
            if (stc.Material.StockCard.StockMethod == StockMethodEnum.SerialNumbered)
            {
                if (material is FixedAssetDefinition)
                {
                    foreach(DCAction dc in stc.DCActions)
                    {
                        FixedAssetInDetail fixedAssetInDetail = new FixedAssetInDetail(objectContext);
                        fixedAssetInDetail.Description = stc.Material.Name ;
                        fixedAssetInDetail.Frequency = dc.Frekans;
                        fixedAssetInDetail.GuarantyEndDate = dc.GarantiBitisTarihi;
                        fixedAssetInDetail.GuarantyStartDate = dc.GarantiBaslangicTarihi;
                        fixedAssetInDetail.Mark = dc.Marka;
                        fixedAssetInDetail.Model = dc.Model;
                        fixedAssetInDetail.Power = dc.Guc;
                        fixedAssetInDetail.ProductionDate = dc.ImalTarihi;
                        fixedAssetInDetail.SerialNumber = dc.SeriNumarasi;
                        fixedAssetInDetail.Status = FixedAssetStatusEnum.New;
                        fixedAssetInDetail.Voltage = dc.Voltaj;
                        fixedAssetInDetail.StockActionDetail = stockFirstInDetail;
                        fixedAssetInDetail.SetNewFixedAssetSerialNumber();
                        dc.FixedAssetNO = fixedAssetInDetail.FixedAssetNO;
                    }
                }
            }
            if(stc.Material.StockCard.StockMethod == StockMethodEnum.ExpirationDated )
                stockFirstInDetail.ExpirationDate = Common.GetLastDayOfMounth((DateTime)stc.SKTarihi);
            if (stc.Material.StockCard.StockMethod == StockMethodEnum.LotUsed)
                stockFirstInDetail.LotNo = "-";
            stc.IsFirstIn = true;
        }
        
#endregion Methods

    }
}