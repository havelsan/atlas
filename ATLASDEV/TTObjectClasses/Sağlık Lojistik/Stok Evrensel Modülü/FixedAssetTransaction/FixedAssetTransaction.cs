
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
    /// Demirbaş Hareket
    /// </summary>
    public  partial class FixedAssetTransaction : TTObject
    {
        
                    
        protected void PostTransition_Completed2Cancelled()
        {
            // From State : Completed   To State : Cancelled
#region PostTransition_Completed2Cancelled
            
            





            switch (StockTransaction.StockTransactionDefinition.TransactionType)
            {
                case TransactionTypeEnum.In:
                    {
                        if (FixedAsset.Stock.ObjectID.Equals(StockTransaction.Stock.ObjectID))
                        {
                           // FixedAssetTransaction.RemoteMethods.DeleteFixedAssetMaterialDef(Sites.SiteMerkezSagKom, this.FixedAsset.ObjectID);
                          //  FixedAssetTransaction.RemoteMethods.DeleteFixedAssetMaterialDef(Sites.SiteSihhiIkmal, this.FixedAsset.ObjectID);
                            //((ITTObject)this.FixedAsset).Delete();
                        }
                        else
                        {
                            if (FixedAsset.Stock != null)
                                throw new TTException("Bu işlemin detayında girilen demirbaş malzeme bu depoda bulunmuyor\r\nDemribaş Seri Numarası: " + FixedAsset.SerialNumber + "\r\nBulunduğu Depo: " + FixedAsset.Stock.Store.Name);
                            else
                                throw new TTException("Bu işlemin detayında girilen demirbaş malzemenin depo bilgisi bulunamadı.\r\nDemribaş Seri Numarası: " + FixedAsset.SerialNumber);
                        }
                    }
                    break;
                case TransactionTypeEnum.Out:
                    {
                        FixedAsset.Stock = StockTransaction.Stock;
                    }
                    break;
                case TransactionTypeEnum.Transfer:
                    {
                        if (FixedAsset.Stock.ObjectID.Equals(StockTransaction.Stock.ObjectID))
                        {
                            Stock stock = null;
                            IList outTrxs = StockTransaction.StockActionDetail.StockTransactions.Select("INOUT = 2");
                            if (outTrxs.Count > 0)
                            {
                                stock = ((StockTransaction)outTrxs[0]).Stock;
                            }
                            if (stock != null)
                                FixedAsset.Stock = stock;
                        }
                        else
                        {
                            if (FixedAsset.Stock != null)
                                throw new TTException("Bu işlemin detayında girilen demirbaş malzeme bu depoda bulunmuyor\r\nDemribaş Seri Numarası: " + FixedAsset.SerialNumber + "\r\nBulunduğu Depo: " + FixedAsset.Stock.Store.Name);
                            else
                                throw new TTException("Bu işlemin detayında girilen demirbaş malzemenin depo bilgisi bulunamadı.\r\nDemribaş Seri Numarası: " + FixedAsset.SerialNumber);
                        }
                    }
                    break;
                case TransactionTypeEnum.ChangeStockLevel:
                case TransactionTypeEnum.Consumption:
                case TransactionTypeEnum.MergeStock:
                case TransactionTypeEnum.Production:
                case TransactionTypeEnum.Nothing:
                    break;

            }   
     


#endregion PostTransition_Completed2Cancelled
        }

        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(FixedAssetTransaction).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == FixedAssetTransaction.States.Completed && toState == FixedAssetTransaction.States.Cancelled)
                PostTransition_Completed2Cancelled();
        }

    }
}