//$22DAB572
using System;
using System.Linq;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;
using TTDefinitionManagement;
using TTUtils;
using TTDataDictionary;
using System.Collections.Generic;
using System.ComponentModel;

namespace Core.Controllers
{
    public partial class ExtendExpirationDateServiceController
    {
        partial void PostScript_ExtendExpDateNewForm(ExtendExpDateNewFormViewModel viewModel, ExtendExpirationDate extendExpirationDate, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            if (viewModel.TempOuttableLots != null)
            {
                foreach (TempOuttableLot tempOuttableLot in viewModel.TempOuttableLots)
                {

                    foreach (ExtendExpirationDateDetail extendExpirationDateDetailsImported in extendExpirationDate.ExtendExpirationDateDetails)
                    {

                        if (extendExpirationDateDetailsImported.CurrentExpirationDate != null)
                        {
                            BindingList<Stock> stocks = Stock.GetStoreMaterial(extendExpirationDate.ObjectContext, extendExpirationDateDetailsImported.StockAction.Store.ObjectID, extendExpirationDateDetailsImported.Material.ObjectID);
                            if (stocks.Count == 1)
                            {
                                Stock materialStock = stocks[0];
                                BindingList<StockTransaction.LOTOutableStockTransactions_Class> outableStockTransactions = StockTransaction.LOTOutableStockTransactions(materialStock.ObjectID);
                                foreach (StockTransaction.LOTOutableStockTransactions_Class outLot in outableStockTransactions)
                                {
                                    if (outLot.ExpirationDate == tempOuttableLot.ExpirationDate && outLot.LotNo == tempOuttableLot.LotNo)
                                    {
                                        OuttableLot outtableLot = new OuttableLot(extendExpirationDate.ObjectContext);
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

        partial void AfterContextSaveScript_ExtendExpDateNewForm(ExtendExpDateNewFormViewModel viewModel, ExtendExpirationDate extendExpirationDate, TTDefinitionManagement.TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            string sonucMesaji = string.Empty;
            if (viewModel._ExtendExpirationDate.CurrentStateDefID == ExtendExpirationDate.States.Completed)
            {
                if (TTObjectClasses.SystemParameter.GetParameterValue("SENDTOMKYSFORAFTERCONTEXT", "TRUE") == "TRUE")
                {
                   
                    sonucMesaji = extendExpirationDate.SendUpdateMessageToMKYS(Common.CurrentResource.MkysPassword);
                    TTUtils.InfoMessageService.Instance.ShowMessage(sonucMesaji);
                }
            }

        }
    }
}

namespace Core.Models
{
    public partial class ExtendExpDateNewFormViewModel
    {
        //public TTObjectClasses.OuttableLot[] OuttableLots
        //{
        //    get;
        //    set;
        //}

        public List<TempOuttableLot> TempOuttableLots
        {
            get;
            set;
        }
    }

    public class TempOuttableLot
    {
        public Currency? Amount
        {
            get;
            set;
        }

        /// <summary>
        /// Kalan Miktar
        /// </summary>
        public Currency? RestAmount
        {
            get;
            set;
        }

        /// <summary>
        /// Son Kullanma Tarihi
        /// </summary>
        public DateTime? ExpirationDate
        {
            get;
            set;
        }

        /// <summary>
        /// Lot Nu.
        /// </summary>
        public string LotNo
        {
            get;
            set;
        }

        public bool? isUse
        {
            get;
            set;
        }

        public string StockActionDetailOutID

        {
            get;
            set;
        }
    }
}