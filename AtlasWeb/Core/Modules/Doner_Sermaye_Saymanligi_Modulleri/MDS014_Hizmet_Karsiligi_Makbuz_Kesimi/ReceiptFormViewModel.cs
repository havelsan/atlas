//$D3510794
using System;
using System.Linq;
using System.Net.Http;
using System.ComponentModel;
using TTInstanceManagement;
using Core.Models;
using TTObjectClasses;

using Infrastructure.Filters;
using Infrastructure.Helpers;
using Microsoft.AspNetCore.Mvc;
using TTDefinitionManagement;
using TTStorageManager.Security;
using TTDataDictionary;
using TTUtils;
using System.Collections.Generic;
using DevExpress.Utils.Serializing;

namespace Core.Controllers
{
    public partial class ReceiptServiceController : Controller
    {
        partial void PreScript_ReceiptForm(ReceiptFormViewModel viewModel, Receipt receipt, TTObjectContext objectContext)
        {
            if (((ITTObject)receipt).IsNew)
            {
                Guid? selectedEpisodeObjectID = viewModel.GetSelectedEpisodeID();
                if (selectedEpisodeObjectID.HasValue)
                {
                    Episode episode = objectContext.GetObject<Episode>(selectedEpisodeObjectID.Value);
                    viewModel._Receipt.Episode = episode;
                    viewModel.Episodes = objectContext.LocalQuery<Episode>().ToArray();
                }

                viewModel._Receipt.PrepareNewReceipt();
                ContextToViewModel(viewModel, objectContext);
                //viewModel.AccountTransactions = objectContext.LocalQuery<AccountTransaction>().ToArray();
                viewModel.ReceiptProcedureAccTrxMatch = viewModel.GRIDReceiptProceduresGridList.ToDictionary(x => x.ObjectID, x => x.AccountTransactionObjectID);
                viewModel.AdvanceDocs = objectContext.LocalQuery<AdvanceDocument>().Where(x => x.Used == false && x.CurrentStateDefID == AdvanceDocument.States.Paid).ToArray();
            }
            else
            {
                viewModel.HasRoleToChangePaymentTpye = TTUser.CurrentUser.HasRole(TTRoleNames.Muhasebe_Yetkilisi_Odeme_Tipi_Guncelleme) || TTUser.CurrentUser.IsPowerUser || TTUser.CurrentUser.IsSuperUser;
                viewModel.RemainderOfMoney = receipt.RemainderOfMoney;
                viewModel.MoneyPaid = receipt.MoneyPaid;
                var dailyRateDef = receipt.DailyRateDefinition;
                if (dailyRateDef != null)
                {
                    viewModel.DailyRateDefinition = dailyRateDef.ObjectID;
                    viewModel.SelectedCurrencyTypeDefinition = dailyRateDef.CurrencyType.ObjectID;
                    viewModel.ConvertedTotalPayment = receipt.ConvertedTotalPayment;
                    var selectedCurrencyRate = DailyRateDefinition.GetDailyRateDefinitions(objectContext, " WHERE OBJECTID = '" + dailyRateDef.ObjectID + "'", null)[0];
                    viewModel.SelectedCurrencyRate = new DailyRateDefinitionsDTO
                    {
                        Currencyratetypename = selectedCurrencyRate.Currencyratetypename,
                        Currencytypename = selectedCurrencyRate.Currencytypename,
                        DailyRate = selectedCurrencyRate.DailyRate.Value,
                        ObjectID = selectedCurrencyRate.ObjectID.Value,
                        Qref = selectedCurrencyRate.Qref,
                        RateDate = selectedCurrencyRate.RateDate.Value
                    };
                }
            }
        }

        partial void PostScript_ReceiptForm(ReceiptFormViewModel viewModel, Receipt receipt, TTObjectStateTransitionDef transDef, TTObjectContext objectContext)
        {
            CurrencyTypeDefinition currencyType = objectContext.GetObject<CurrencyTypeDefinition>(viewModel.SelectedCurrencyTypeDefinition);
            if (currencyType != null && currencyType.Qref != "TL" && (viewModel.MoneyPaid.HasValue && viewModel.MoneyPaid.Value <= 0) || viewModel.MoneyPaid == null)
                throw new TTException("Dövizle yapılan ödemelerde Alınan Tutar (yani hastadan alınan döviz) miktarını girmek zorunludur.");

            //if (viewModel.AccountTransactions != null)
            //{
            //    foreach (AccountTransaction item in viewModel.AccountTransactions)
            //    {
            //        objectContext.AddObject(item);
            //    }
            //}

            if(viewModel.ReceiptProcedureAccTrxMatch != null)
            {
                foreach (var item in viewModel.ReceiptProcedureAccTrxMatch)
                {
                    receipt.ReceiptProcedures.FirstOrDefault(x => x.ObjectID == item.Key).AccountTransactionObjectID = item.Value;
                }
            }

            if (viewModel.AdvanceDocs != null)
            {
                foreach (AdvanceDocument item in viewModel.AdvanceDocs)
                {
                    objectContext.AddObject(item);
                }
            }

            receipt.RemainderOfMoney = viewModel.RemainderOfMoney;
            receipt.MoneyPaid = viewModel.MoneyPaid;
            receipt["DAILYRATEDEFINITION"] = viewModel.DailyRateDefinition;
            receipt.CurrencyType = viewModel.SelectedCurrencyTypeDefinition;
            receipt.ConvertedTotalPayment = viewModel.ConvertedTotalPayment;
        }
    }
}

namespace Core.Models
{
    public partial class ReceiptFormViewModel
    {
        public AccountTransaction[] AccountTransactions
        {
            get;
            set;
        }

        public AdvanceDocument[] AdvanceDocs
        {
            get;
            set;
        }
        public bool HasRoleToChangePaymentTpye { get; set; }
        public Currency? RemainderOfMoney { get; set; }
        public Currency? MoneyPaid { get; set; }
        public Currency? ConvertedTotalPayment { get; set; }
        public Guid DailyRateDefinition { get; set; }
        public Guid SelectedCurrencyTypeDefinition { get; set; }
        public DailyRateDefinitionsDTO SelectedCurrencyRate { get; set; }
        public Dictionary<Guid, Guid> ReceiptProcedureAccTrxMatch { get; set; }
    }

    public class DailyRateDefinitionsDTO
    {
        public Currency DailyRate;
        public DateTime RateDate;
        public string Currencytypename;
        public string Qref;
        public string Currencyratetypename;
        public Guid ObjectID;
    }
}