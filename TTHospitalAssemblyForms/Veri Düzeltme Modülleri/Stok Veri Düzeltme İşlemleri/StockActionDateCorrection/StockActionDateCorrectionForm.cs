
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
    /// <summary>
    /// Belge Tarihi Güncelleme (Devir için)
    /// </summary>
    public partial class StockActionDateCorrectionForm : BaseDataCorrectionForm
    {
        override protected void BindControlEvents()
        {
            cmdUpdate.Click += new TTControlEventDelegate(cmdUpdate_Click);
            cmdList.Click += new TTControlEventDelegate(cmdList_Click);
            base.BindControlEvents();
        }

        override protected void UnBindControlEvents()
        {
            cmdUpdate.Click -= new TTControlEventDelegate(cmdUpdate_Click);
            cmdList.Click -= new TTControlEventDelegate(cmdList_Click);
            base.UnBindControlEvents();
        }

        private void cmdUpdate_Click()
        {
#region StockActionDateCorrectionForm_cmdUpdate_Click
   DateTime changeDate = (DateTime)_StockActionDateCorrection.ChangeTransactionDate.Value;
            string log  = string.Empty ;
            string oldDate = string.Empty;
            foreach (DateCorrectionDetail dateCorrectionDetail in _StockActionDateCorrection.DateCorrectionDetails)
            {
                if ((bool)dateCorrectionDetail.ChangeTransaction)
                {
                    oldDate = dateCorrectionDetail.StockTransaction.TransactionDate.ToString() ;
                    _StockActionDateCorrection.ChangeDate(dateCorrectionDetail.StockTransaction, changeDate);
                    log = log + dateCorrectionDetail.ChangeStockActionID.ToString() + " numaralı işlemin işlem tarihi "+ oldDate + " iken " + changeDate.ToString() + " olarak güncellenmiştir.\r\n";
                }
            }
            this.TransactionList(_StockActionDateCorrection);
            this.cmdUpdate.Enabled = false;
            this.ChangeTransactionDate.ReadOnly = true;
             _StockActionDateCorrection.UpdateLog = log;
#endregion StockActionDateCorrectionForm_cmdUpdate_Click
        }

        private void cmdList_Click()
        {
#region StockActionDateCorrectionForm_cmdList_Click
   this.TransactionList(_StockActionDateCorrection);
            this.Material.ReadOnly = true;
            this.cmdList.Enabled = false;
#endregion StockActionDateCorrectionForm_cmdList_Click
        }

        protected override void PreScript()
        {
#region StockActionDateCorrectionForm_PreScript
    base.PreScript();
#endregion StockActionDateCorrectionForm_PreScript

            }
            
        protected override void ClientSidePreScript()
        {
#region StockActionDateCorrectionForm_ClientSidePreScript
    base.ClientSidePreScript();
              MainStoreDefinition mainStore = CommonForm.SelectResourceDependentMainStoreDefinition(this);
            if (mainStore == null)
                throw new Exception(SystemMessage.GetMessage(713));

            AccountingTerm term = mainStore.Accountancy.GetHalfOpenAccountingTerm();

            if (term == null)
                throw new TTException(SystemMessage.GetMessage(1149));
           
            _StockActionDateCorrection.AccountingTerm = term;
            _StockActionDateCorrection.MainStoreDefinition = mainStore;
#endregion StockActionDateCorrectionForm_ClientSidePreScript

        }

#region StockActionDateCorrectionForm_Methods
        public void TransactionList(StockActionDateCorrection stockActionDateCorrection)
        {
            stockActionDateCorrection.DateCorrectionDetails.DeleteChildren();
            Stock mStock ;
            IBindingList fStocks = Stock.GetStockFromStoreAndMaterial(stockActionDateCorrection.ObjectContext, stockActionDateCorrection.Material.ObjectID, stockActionDateCorrection.MainStoreDefinition.ObjectID);
            if (fStocks.Count > 0)
            {
                if (fStocks.Count == 1)
                {
                    Guid stockGuid = (Guid)((Stock.GetStockFromStoreAndMaterial_Class)fStocks[0]).ObjectID ;
                    mStock = (Stock)stockActionDateCorrection.ObjectContext.GetObject(stockGuid, "STOCK");
                }
                else
                    throw new TTException("Hatalı Stock bulunmuştur. Bilgi işleme haber veriniz.");
            }
            else
                throw new TTException("Seçilen malzemenin hiçbir hareketi bulunmamaktadır.");
            
            if (mStock != null)
            {
                AccountingTerm previousTerm = stockActionDateCorrection.MainStoreDefinition.Accountancy.GetPreviousAccountingTerm(((DateTime)stockActionDateCorrection.AccountingTerm.StartDate).AddDays(-1));
                stockActionDateCorrection.OldStockCensusInheld = 0;
                stockActionDateCorrection.OldStockCensusConsigned = 0;
                if(previousTerm != null)
                {
                    IBindingList prevCensusDetail = StockCensusDetail.GetCensusDetail(stockActionDateCorrection.ObjectContext, previousTerm.ObjectID, mStock.ObjectID);
                    if(prevCensusDetail.Count> 0)
                    {
                        StockCensusDetail oldStockCensusDetail = (StockCensusDetail)prevCensusDetail[0] ;
                        stockActionDateCorrection.OldStockCensusInheld = oldStockCensusDetail.Inheld;
                        stockActionDateCorrection.OldStockCensusConsigned = oldStockCensusDetail.Consigned;
                    }
                }
                IBindingList stockTransactions = StockTransaction.GetStockTransactionsByStockAccountingTerm(stockActionDateCorrection.ObjectContext, mStock.ObjectID, stockActionDateCorrection.AccountingTerm.ObjectID);
                Currency consigned = (Currency)stockActionDateCorrection.OldStockCensusConsigned;
                Currency inheld = (Currency)stockActionDateCorrection.OldStockCensusInheld;

                foreach (StockTransaction transaction in stockTransactions)
                {
                    DateCorrectionDetail dateCorrectionDetail = new DateCorrectionDetail(stockActionDateCorrection.ObjectContext);
                    dateCorrectionDetail.Amount = transaction.Amount;
                    dateCorrectionDetail.ChangeTransaction = false;
                    dateCorrectionDetail.ChangeStockActionID = transaction.StockActionDetail.StockAction.StockActionID.Value;
                    dateCorrectionDetail.StockTransaction = transaction;

                    switch (transaction.MaintainLevelCode)
                    {
                        case MaintainLevelCodeEnum.DecreaseConsigned:
                            consigned = consigned - (Currency)transaction.Amount;
                            break;
                        case MaintainLevelCodeEnum.DecreaseInheld :
                            inheld = inheld - (Currency)transaction.Amount;
                            break;
                        case MaintainLevelCodeEnum.DecreaseInheld__IncreaseConsigned:
                            inheld  = inheld  - (Currency)transaction.Amount;
                            consigned = consigned + (Currency)transaction.Amount;
                            break;
                        case MaintainLevelCodeEnum.IncreaseConsigned :
                            consigned = consigned + (Currency)transaction.Amount;
                            break;
                        case MaintainLevelCodeEnum.IncreaseInheld:
                            inheld  = inheld + (Currency)transaction.Amount;
                            break;
                        case MaintainLevelCodeEnum.IncreaseInheld__DecreaseConsigned:
                            inheld  = inheld  + (Currency)transaction.Amount;
                            consigned  = consigned - (Currency)transaction.Amount;
                            break;
                        case MaintainLevelCodeEnum.Nothing:
                            break;
                        case MaintainLevelCodeEnum.ReturnInheld:
                            break;
                        default:
                            throw new Exception(SystemMessage.GetMessage(542));
                    }
                    dateCorrectionDetail.ChangeConsigned = consigned;
                    dateCorrectionDetail.ChangeInheld = inheld;
                    dateCorrectionDetail.StockActionDateCorrection = stockActionDateCorrection;
                }
            }
        }
        
#endregion StockActionDateCorrectionForm_Methods
    }
}