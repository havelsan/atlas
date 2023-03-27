
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
    public partial class StockOutTransactionAttribute : TTAttributeInstance
    {
        public override void Run(AttributeWhenEnum when)
        {
#region Body
            if (TTObjectClasses.SystemParameter.IsWorkWithOutStock == false)
            {
                Store useStore = Interface.GetStore();
                if (useStore == null)
                    throw new Exception(SystemMessage.GetMessage(521));
                string errorMsg = string.Empty;
                bool error = false;

                foreach (StockActionDetail stockActionDetail in Interface.GetStockActionOutDetails())
                {
                    if (stockActionDetail.Status == StockActionDetailStatusEnum.New)
                    {
                        Stock stock = useStore.GetStock(stockActionDetail.Material);
                        if (stockTransactionDef.DoOperation(stock, null, stockActionDetail))
                        {
                            stockActionDetail.Status = StockActionDetailStatusEnum.Completed;
                            StockAction stockAction = stockActionDetail.StockAction ;
                            if (stockAction is IChattelDocumentOutputWithAccountancy)
                            {
                                if (((IChattelDocumentOutputWithAccountancy)stockAction).GetAccountancy().GetAccountancyMilitaryUnit() != null)
                                {
                                    Guid miliratyUnitGuid = ((IChattelDocumentOutputWithAccountancy)stockAction).GetAccountancy().GetAccountancyMilitaryUnit().GetObjectID();
                                    TTObjectContext readOnlyContext = new TTObjectContext(true);
                                    MilitaryUnit militaryUnit = (MilitaryUnit)readOnlyContext.GetObject(miliratyUnitGuid, typeof(MilitaryUnit));
                                    if (militaryUnit.IsSupported.HasValue)
                                    {
                                        if ((bool)militaryUnit.IsSupported)
                                        {
                                            if (stockActionDetail.AddInvoiceDetails() == false)
                                            {
                                                if (stockActionDetail.Material is ConsumableMaterialDefinition || stockActionDetail.Material is DrugDefinition)
                                                {
                                                    if (stockActionDetail.InvoiceDate == null)
                                                    {
                                                        foreach (StockActionDetail detail in Interface.GetStockActionOutDetails())
                                                        {
                                                            Stock clearStock = useStore.GetStock(detail.Material);
                                                            if (clearStock._outableStockTransactions != null)
                                                                clearStock._outableStockTransactions.Clear();
                                                        }
                                                        //error = true;
                                                        if (errorMsg == String.Empty)
                                                            errorMsg = stockActionDetail.Material.Name;
                                                        else
                                                            errorMsg = errorMsg + "\r\n" + stockActionDetail.Material.Name + " isimli malzemenin alış tarihini giriniz";
                                                        //throw new Exception(stockActionDetail.Material.Name + " isimli malzemenin alış tarihini giriniz");
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                            throw new Exception(SystemMessage.GetMessage(522));
                    }
                    else if (stockActionDetail.Status == StockActionDetailStatusEnum.Cancelled)
                    {
                        if(stockActionDetail.Material.JoinedMaterial != null)
                            throw new TTException(TTUtils.CultureService.GetText("M25397", "Değiş işlemi yapılmış eski malzeme bulunduğu için bu işlemi iptal edemezsiniz./r/nMalzeme :")+ stockActionDetail.Material.Name);

                        foreach (StockTransaction stockTransaction in stockActionDetail.StockTransactions.Select(string.Empty))
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
                            foreach (PrescriptionPaperOutDetail prescriptionPaperOutDetail in ((StockActionDetailOut)stockActionDetail).PrescriptionPaperOutDetails)
                                prescriptionPaperOutDetail.PrescriptionPaper.CurrentStateDefID = PrescriptionPaper.States.Usable;
                        }
                    }
                    else if (stockActionDetail.Status == StockActionDetailStatusEnum.Deleted)
                    {
                        // bir işlem yapılmayacak.SS
                    }
                    else
                    {
                        throw new Exception(SystemMessage.GetMessage(523));
                    }
                }

                if (error)
                {
                    errorMsg = errorMsg + " isimli malzemenin(lerin) alış tarihini giriniz";
                    throw new TTException(errorMsg);
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