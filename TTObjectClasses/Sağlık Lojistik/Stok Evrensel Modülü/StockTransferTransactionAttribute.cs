
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
    public partial class StockTransferTransactionAttribute : TTAttributeInstance
    {
        public override void Run(AttributeWhenEnum when)
        {
#region Body
            if (TTObjectClasses.SystemParameter.IsWorkWithOutStock == false)
            {
                Store useStore = Interface.GetStore();
                if (useStore == null)
                    throw new Exception(SystemMessage.GetMessage(521));

                Store destinationStore = Interface.GetDestinationStore();
                if (destinationStore == null)
                    throw new Exception(SystemMessage.GetMessage(521));

                foreach (StockActionDetail stockActionDetail in Interface.GetStockActionOutDetails())
                {
                    if (stockActionDetail.Status == StockActionDetailStatusEnum.New)
                    {
                        Stock fromStock = useStore.GetStock(stockActionDetail.Material);
                        Stock toStock = destinationStore.GetStock(stockActionDetail.Material);
                        if (stockTransactionDef.DoOperation(fromStock, toStock, stockActionDetail))
                            stockActionDetail.Status = StockActionDetailStatusEnum.Completed;
                        else
                            throw new Exception(SystemMessage.GetMessage(522));
                    }
                    else if (stockActionDetail.Status == StockActionDetailStatusEnum.Cancelled)
                    {
                        if(stockActionDetail.Material.JoinedMaterial != null)
                            throw new TTException(TTUtils.CultureService.GetText("M25397", "Değiş işlemi yapılmış eski malzeme bulunduğu için bu işlemi iptal edemezsiniz./r/nMalzeme :")+ stockActionDetail.Material.Name);

                        foreach (StockTransaction stockTransaction in stockActionDetail.StockTransactions.Select(string.Empty, "INOUT"))
                        {
                            if (stockTransaction.CurrentStateDefID.Equals(StockTransaction.States.Cancelled) == false)
                            {
                                foreach (FixedAssetTransaction fixedAssetTransaction in stockTransaction.FixedAssetTransactions)
                                    ((ITTObject)fixedAssetTransaction).Cancel();
                                ((ITTObject)stockTransaction).Cancel();
                            }
                        }
                        IList stockCollectedTransactios = stockActionDetail.StockCollectedTrxs.Select(string.Empty);
                        if (stockCollectedTransactios.Count > 0)
                            foreach (ITTObject ittObject in stockCollectedTransactios)
                            ittObject.Delete();

                        //Reçete iptali için yapıldı. SS
                        if (stockActionDetail.StockAction is IBasePrescriptionTransaction)
                        {
                            foreach (StockTransaction stockTransaction in stockActionDetail.StockTransactions.Select("INOUT = 1", "INOUT"))
                            {
                                foreach (PrescriptionPaperOutDetail prescriptionPaperOutDetail in ((StockActionDetailOut)stockActionDetail).PrescriptionPaperOutDetails)
                                {
                                    if (prescriptionPaperOutDetail.PrescriptionPaper.Stock == stockTransaction.Stock)
                                    {
                                        prescriptionPaperOutDetail.PrescriptionPaper.Stock = stockActionDetail.StockTransactions.Select("INOUT = 2", "INOUT")[0].Stock;
                                    }
                                    else
                                        throw new TTException(TTUtils.CultureService.GetText("M25318", "Bu işlemde kullanılmış reçeteler bulunduğundan iptal edemezsiniz"));
                                }
                            }
                        }
                    }
                    else
                    {
                        throw new Exception(SystemMessage.GetMessage(523));
                    }
                }
            }
#endregion Body
        }

        public override void Check(TTAttribute attribute)
        {
#region CheckBody
        
#endregion CheckBody
        }
    }
}