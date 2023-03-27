//$452BEEED
using System;
using System.Linq;
using Core.Models;
using Infrastructure.Filters;
using Infrastructure.Models;
using TTInstanceManagement;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using TTDataDictionary;
using System.Collections.Generic;
using System.ComponentModel;

namespace Core.Controllers
{
    public partial class ExtendExpDateOutServiceController
    {
        partial void PostScript_ExtendExpDateOutForm(ExtendExpDateOutFormViewModel viewModel, ExtendExpDateOut extendExpDateOut, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (viewModel.TempOuttableLots != null)
            {
                foreach (TempOuttableLot tempOuttableLot in viewModel.TempOuttableLots)
                {

                    foreach (ExtendExpDateOutDetail extendExpirationDateDetailsImported in extendExpDateOut.ExtendExpDateOutDetails)
                    {

                        if (extendExpirationDateDetailsImported.OutExpirationDate != null)
                        {
                            BindingList<Stock> stocks = Stock.GetStoreMaterial(extendExpDateOut.ObjectContext, extendExpirationDateDetailsImported.StockAction.Store.ObjectID, extendExpirationDateDetailsImported.Material.ObjectID);
                            if (stocks.Count == 1)
                            {
                                Stock materialStock = stocks[0];
                                BindingList<StockTransaction.LOTOutableStockTransactions_Class> outableStockTransactions = StockTransaction.LOTOutableStockTransactions(materialStock.ObjectID);
                                foreach (StockTransaction.LOTOutableStockTransactions_Class outLot in outableStockTransactions)
                                {
                                    if (outLot.ExpirationDate == tempOuttableLot.ExpirationDate && outLot.LotNo == tempOuttableLot.LotNo)
                                    {
                                        OuttableLot outtableLot = new OuttableLot(extendExpDateOut.ObjectContext);
                                        outtableLot.LotNo = outLot.LotNo;
                                        if (outLot.ExpirationDate == null)
                                            outtableLot.ExpirationDate = DateTime.MinValue;
                                        else
                                            outtableLot.ExpirationDate = outLot.ExpirationDate;
                                        outtableLot.RestAmount = CurrencyType.ConvertFrom(outLot.Restamount);
                                        outtableLot.Amount = CurrencyType.ConvertFrom(outLot.Restamount);
                                        outtableLot.isUse = true;
                                        outtableLot.StockActionDetailOut = extendExpirationDateDetailsImported;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        partial void AfterContextSaveScript_ExtendExpDateOutForm(ExtendExpDateOutFormViewModel viewModel, ExtendExpDateOut extendExpDateOut, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            string sonucMesaji = string.Empty;
            if (viewModel._ExtendExpDateOut.CurrentStateDefID == ExtendExpDateOut.States.Completed)
            {
                if (TTObjectClasses.SystemParameter.GetParameterValue("SENDTOMKYSFORAFTERCONTEXT", "TRUE") == "TRUE")
                {

                    sonucMesaji = extendExpDateOut.SendUpdateMessageToMKYS(Common.CurrentResource.MkysPassword);
                    TTUtils.InfoMessageService.Instance.ShowMessage(sonucMesaji);
                }
            }
        }
    }
}

namespace Core.Models
{
    public partial class ExtendExpDateOutFormViewModel: BaseViewModel
    {
        public List<TempOuttableLot> TempOuttableLots
        {
            get;
            set;
        }
    }
}
