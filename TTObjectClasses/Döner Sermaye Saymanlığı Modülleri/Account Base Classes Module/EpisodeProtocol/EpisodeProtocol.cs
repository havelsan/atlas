
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
    /// Hasta epizotu ile anlaşmaların eşleşme bilgisini tutan sınıf
    /// </summary>
    public  partial class EpisodeProtocol : TTObject
    {
        public partial class GetXXXXXXEmployeeEPs_Class : TTReportNqlObject 
        {
        }

        public partial class GetByPayerAndDate_Class : TTReportNqlObject 
        {
        }

        public partial class GetEpisodeProtocols_Class : TTReportNqlObject 
        {
        }

        protected override void PreInsert()
        {
#region PreInsert
            base.PreInsert();
            throw new TTException("Don't create EpisodeProtocol.");
#endregion PreInsert
        }

        #region Methods
        //        private IList _invoiceTrxs;
        //        private IList _receiptTrxs;
        //        private IList _allTrxs;
        //        private IList _epTrxs;
        //        private IList _subActionProcTrxs;
        //        private IList _subActionMatTrxs;
        //        private List <SubActionProcedure> _packageSubActionProcedures = new List<SubActionProcedure>();
        //        
        //        public IList GetTransactionsForReceipt(AccountPayableReceivable apr)
        //        {
        //            _receiptTrxs = AccountTransaction.GetTransactionsForReceipt(this.ObjectContext, apr.ObjectID.ToString(), AccountTransaction.States.New.ToString(), this.ObjectID.ToString());
        //            return _receiptTrxs;
        //        }
        //        
        //        public IList GetTransactionsInsidePackage(PackageDefinition packageDefinition, AccountPayableReceivable apr)
        //        {
        //            _receiptTrxs = AccountTransaction.GetTransactionsInsidePackage(this.ObjectContext, packageDefinition.ObjectID.ToString(), this.ObjectID.ToString(), apr.ObjectID.ToString());
        //            return _receiptTrxs;
        //        }
        //        
        //        public IList GetTransactionsForInvoice(Guid accTrxState, AccountPayableReceivable apr)
        //        {
        //            _invoiceTrxs = AccountTransaction.GetTransactionsForInvoice(this.ObjectContext, accTrxState.ToString(), apr.ObjectID.ToString(), this.ObjectID.ToString());
        //            return _invoiceTrxs;
        //        }
        //        
        //        public IList GetAllTransactions()
        //        {
        //            _allTrxs = AccountTransaction.GetAllTransactionsByEP(this.ObjectContext, this.ObjectID.ToString());
        //            return _allTrxs;
        //        }
        //        
        //        public IList GetTransactions()
        //        {
        //            _allTrxs = AccountTransaction.GetTransactionsByEpisodeProtocol(this.ObjectContext, this.ObjectID.ToString());
        //            return _allTrxs;
        //        }
        //        
        //        public IList GetNewAndCancelledTransactions()
        //        {
        //            _allTrxs = AccountTransaction.GetNewAndCancelledTrxsByEP(this.ObjectContext, this.ObjectID.ToString());
        //            return _allTrxs;
        //        }
        //        
        //        public IList GetInvoicedSubActionProcedureTransactions()
        //        {
        //            _subActionProcTrxs = AccountTransaction.GetInvoicedSubActionProcedureTrxsByEpisodeProtocol(this.ObjectContext, this.ObjectID.ToString());
        //            return _subActionProcTrxs;
        //        }
        //        
        //public IList GetSubActionProcedureTransactions()
        //{
        //    IList _subActionProcTrxs = AccountTransaction.GetSubActionProcedureTransactionsBySEP(this.ObjectContext, this.ObjectID);
        //    return _subActionProcTrxs;
        //}
        //        
        //        public IList GetSubActionProcedureTrxs()
        //        {
        //            _subActionProcTrxs = AccountTransaction.GetSubActionProcedureTrxsByEpisodeProtocol(this.ObjectContext, this.ObjectID.ToString());
        //            return _subActionProcTrxs;
        //        }
        //
        //        public IList GetSubActionMaterialTransactions()
        //        {
        //            _subActionMatTrxs = AccountTransaction.GetSubActionMaterialTransactionsByEpisodeProtocol(this.ObjectContext, this.ObjectID.ToString());
        //            return _subActionMatTrxs;
        //        }
        //        
        //        public IList GetSubActionMaterialTrxs()
        //        {
        //            _subActionMatTrxs = AccountTransaction.GetSubActionMaterialTrxsByEpisodeProtocol(this.ObjectContext, this.ObjectID.ToString());
        //            return _subActionMatTrxs;
        //        }
        //
        //        public IList GetTransactionsExceptCancelledByEpisodeProtocol(AccountPayableReceivable apr)
        //        {
        //            _epTrxs = AccountTransaction.GetTransactionsExceptCancelledByEpisodeProtocol(this.ObjectContext, apr.ObjectID.ToString(), this.ObjectID.ToString());
        //            return _epTrxs;
        //        }
        //
        //        public IList GetPackagesInEP()
        //        {
        //            //PackageDefinition pack = null;
        //            foreach (AccountTransaction actrx in AccountTransactions)
        //            {
        //                if (actrx.CurrentStateDefID == AccountTransaction.States.New)
        //                {
        //                    if (actrx.SubActionProcedure != null)
        //                    {
        //                        /*
        //                        if (actrx.SubActionProcedure.ProcedureObject.PackageDefinition != null)
        //                        {
        //                            if (actrx.SubActionProcedure.ProcedureObject.PackageDefinition.Count > 0)
        //                                _packageSubActionProcedures.Add(actrx.SubActionProcedure);
        //                        } */
        //                        if (actrx.SubActionProcedure.PackageDefinition != null)
        //                            _packageSubActionProcedures.Add(actrx.SubActionProcedure);
        //                    }
        //                }
        //            }
        //            return _packageSubActionProcedures;
        //        }
        //        
        //        public override string ToString()
        //        {
        //            return this.ID + " " + this.Episode.OpeningDate;
        //        }
        //        
        //        public void UpdateDayLimit (int pDayLimit)
        //        {
        //            this.DayLimit = pDayLimit ;
        //        }
        //        
        //        public EpisodeProtocol PrepareEpisodeProtocolForRemoteMethod(bool withNewObjectID)// RemoteMetodla gönderilirken sorun çıkmamsı için Local Objelerle olan relationları boşaltır.
        //        {
        //            // Çağırılan yerde yeni Save Point Konulup sonra savepointe dönülmeli
        //            if(withNewObjectID)
        //            {
        //                EpisodeProtocol episodeProtocol = (EpisodeProtocol)this.Clone();
        //                //Diğer tarafda bilinmeyen nesne içeren tüm relationlar temizleniyor...
        //                
        //                foreach (TTObjectRelationDef def in this.ObjectDef.AllParentRelationDefs)
        //                {
        //                    if (!Common.IsBaseOfInheritedObject(def.ParentObjectDef,TTDefinitionManagement.TTObjectDefManager.Instance.ObjectDefs[typeof(TerminologyManagerDef).Name]))
        //                    {
        //                        System.Reflection.PropertyInfo propInfo = this.GetType().GetProperty(def.CodeName);
        //                        if (propInfo != null)
        //                        {
        //                            object obj = propInfo.GetValue(this, null);
        //                            propInfo.SetValue(episodeProtocol, null, null);
        //                        }
        //                    }
        //                }
        //                //...
        //                TTSequence.allowSetSequenceValue = true;
        //                episodeProtocol.ID.SetSequenceValue(0);
        //                return episodeProtocol;
        //            }
        //            else
        //            {
        //                return this;
        //            }
        //        }
        //        
        //        // Ãœcretli Hasta Anlaşması değilse Hasta Payı AccountTransaction ları iptal eder
        //        public void CancelPatientShareAccTrxs()
        //        {
        //            if(Protocol.Type != ProtocolTypeEnum.Paid)
        //            {
        //                foreach(AccountTransaction accTrx in AccountTransactions)
        //                {
        //                    if(accTrx.AccountPayableReceivable.Type == APRTypeEnum.PATIENT && accTrx.CurrentStateDefID == AccountTransaction.States.New)
        //                        accTrx.CurrentStateDefID = AccountTransaction.States.Cancelled;
        //                }
        //            }
        //        }
        //        
        //        // Medula için yapılan AccountTransaction ın miktarı 1 den fazla olamaz geliştirmesinden önce kullanılan AddAccountTransaction metodu
        //        /*
        //        public void AddAccountTransaction(AccountOwnerType accType, TTObject pObject, ManipulatedPrice mPricingDetail, PackageDefinition pPackageDefinition, AccountOperationTimeEnum accountingTimeType)
        //        {
        //            AccountTransaction accTrx = new AccountTransaction(this.ObjectContext);
        //            DateTime serverTime = TTObjectDefManager.ServerTime;
        //            if (pObject.ObjectDef.IsOfType("SUBACTIONPROCEDURE") == true)
        //            {
        //                SubActionProcedure mySubActionProc = (SubActionProcedure) pObject;
        //                Episode e = mySubActionProc.Episode;
        //                
        //                if(mySubActionProc.PricingDate == null)     // PricingDate boş ise, önce ActionDate set edilsin, ActionDate boş ise
        //                {                                           // serverTime set edilsin şeklinde istendi )
        //                    if(mySubActionProc.ActionDate != null)
        //                        mySubActionProc.PricingDate = mySubActionProc.ActionDate;
        //                    else
        //                        mySubActionProc.PricingDate = serverTime;
        //                }
        //                
        //                accTrx.SubActionProcedure = mySubActionProc;
        //                accTrx.Amount = mySubActionProc.Amount;
        //                accTrx.Description = mPricingDetail.Description;
        //                
        //                if(mySubActionProc.ExtraDescription != null)
        //                {
        //                    if(mySubActionProc.ExtraDescription.Trim() != "")
        //                        accTrx.Description = accTrx.Description + " " + mySubActionProc.ExtraDescription;
        //                }
        //                
        //                accTrx.ExternalCode = mPricingDetail.ExternalCode;
        //                accTrx.TransactionDate = mySubActionProc.PricingDate;
        //                accTrx.EpisodeProtocol = this;
        //                accTrx.PricingDetail = mPricingDetail.PricingDetailDefinition;
        //                
        //                if (accountingTimeType == AccountOperationTimeEnum.POST)
        //                    accTrx.CurrentStateDefID = AccountTransaction.States.ToBeNew;
        //                else if (accountingTimeType == AccountOperationTimeEnum.PRE)
        //                    accTrx.CurrentStateDefID = AccountTransaction.States.New;
        //                
        //                if (accType == AccountOwnerType.PAYER)
        //                {
        //                    // Hasta ve kurum payı 0 ise, AccTrx in hasta veya kurum payı olarak oluşacağına anlaşmasından karar veriliyor
        //                    if(mPricingDetail.PayerPrice == 0 && mPricingDetail.PatientPrice == 0 && this.Protocol.Type == ProtocolTypeEnum.Paid)
        //                        accTrx.AccountPayableReceivable = e.Patient.MyAPR();
        //                    else
        //                    {
        //                        this.Payer.ControlAndCreateAPR();
        //                        accTrx.AccountPayableReceivable = this.Payer.MyAPR();
        //                    }
        //                    accTrx.UnitPrice = mPricingDetail.PayerPrice;
        //                }
        //                else if (accType == AccountOwnerType.PATIENT)
        //                {
        //                    accTrx.AccountPayableReceivable = e.Patient.MyAPR();
        //                    accTrx.UnitPrice = mPricingDetail.PatientPrice;
        //                }
        //                // ücretli hastaya paket girilmediği için kurum payı kontrolü vardı, sonradan kaldırıldı.  (&& accType == AccountOwnerType.PAYER)
        //                if (pPackageDefinition != null)
        //                    accTrx.PackageDefinition = pPackageDefinition;
        //                
        //                mySubActionProc.AccountTransactions.Add(accTrx);
        //            }
        //            else if (pObject.ObjectDef.IsOfType("SUBACTIONMATERIAL") == true)
        //            {
        //                SubActionMaterial mySubActionMat = (SubActionMaterial) pObject;
        //                Episode e = mySubActionMat.Episode;
        //                
        //                if(mySubActionMat.PricingDate == null)     // PricingDate boş ise, önce ActionDate set edilsin, ActionDate boş ise
        //                {                                          // serverTime set edilsin şeklinde istendi )
        //                    if(mySubActionMat.ActionDate != null)
        //                        mySubActionMat.PricingDate = mySubActionMat.ActionDate;
        //                    else
        //                        mySubActionMat.PricingDate = serverTime;
        //                }
        //                
        //                accTrx.SubActionMaterial = mySubActionMat;
        //                
        //                // Eski malzemelerin Medulaya Hizmet Kaydı yapılabilmesi çalışması sırasında kapatıldı
        //                //if(mySubActionMat.SubActionMatPricingDet.Count == 0)
        //                accTrx.Amount = mySubActionMat.Amount;
        //                //else
        //                //    accTrx.Amount = mySubActionMat.SubActionMatPricingDet[0].Amount ;
        //                
        //                accTrx.PricingDetail = mPricingDetail.PricingDetailDefinition;
        //                accTrx.Description = mPricingDetail.Description;
        //                
        //                if(mySubActionMat.UBBCode != null)
        //                {
        //                    if(mySubActionMat.UBBCode.Trim() != "")
        //                        accTrx.Description = accTrx.Description + " (UBB Kodu:" + mySubActionMat.UBBCode + ")";
        //                }
        //                
        //                if(accTrx.PricingDetail != null)
        //                {
        //                    if(accTrx.PricingDetail.DiscountPercent != null)
        //                    {
        //                        if(accTrx.PricingDetail.DiscountPercent > 0)
        //                            accTrx.Description = accTrx.Description + " (%" + (accTrx.PricingDetail.DiscountPercent * 100) + " İNDİRİM)";
        //                    }
        //                }
        //                
        //                // İlaçlar için barkodu dolu ise, accTrx.ExternalCode barkod ile set edilir
        //                if(mySubActionMat.Material != null && mySubActionMat.Material is DrugDefinition && !string.IsNullOrEmpty(mySubActionMat.Material.Barcode))
        //                    accTrx.ExternalCode = mySubActionMat.Material.Barcode;
        //                
        //                // accTrx.ExternalCode boş kalmış ise, fiyatın kodu ile set edilir
        //                if(string.IsNullOrEmpty(accTrx.ExternalCode))
        //                    accTrx.ExternalCode = mPricingDetail.ExternalCode;
        //                
        //                accTrx.TransactionDate = mySubActionMat.PricingDate;
        //                accTrx.EpisodeProtocol = this;
        //                
        //                if (accountingTimeType == AccountOperationTimeEnum.POST)
        //                    accTrx.CurrentStateDefID = AccountTransaction.States.ToBeNew;
        //                else if (accountingTimeType == AccountOperationTimeEnum.PRE)
        //                    accTrx.CurrentStateDefID = AccountTransaction.States.New;
        //                
        //                if (accType == AccountOwnerType.PAYER)
        //                {
        //                    // Hasta ve kurum payı 0 ise, AccTrx in hasta veya kurum payı olarak oluşacağına anlaşmasından karar veriliyor
        //                    if(mPricingDetail.PayerPrice == 0 && mPricingDetail.PatientPrice == 0 && this.Protocol.Type == ProtocolTypeEnum.Paid)
        //                        accTrx.AccountPayableReceivable = e.Patient.MyAPR();
        //                    else
        //                    {
        //                        this.Payer.ControlAndCreateAPR();
        //                        accTrx.AccountPayableReceivable = this.Payer.MyAPR();
        //                    }
        //                    accTrx.UnitPrice = mPricingDetail.PayerPrice;
        //                }
        //                else if (accType == AccountOwnerType.PATIENT)
        //                {
        //                    accTrx.AccountPayableReceivable = e.Patient.MyAPR();
        //                    accTrx.UnitPrice = mPricingDetail.PatientPrice;
        //                }
        //                
        //                // ücretli hastaya paket girilmediği için kurum payı kontrolü vardı, sonradan kaldırıldı.  (&& accType == AccountOwnerType.PAYER)
        //                if (pPackageDefinition != null)
        //                    accTrx.PackageDefinition = pPackageDefinition;
        //                
        //                // "Birim Fiyat Böleni" veya "Miktar Çarpanı" olan ve fiyat tanımından ücretlenen ilaçlar için accTrx.UnitPrice ve accTrx.Amount değiştirilir
        //                if(accTrx.PricingDetail != null)
        //                {
        //                    DrugDefinition drug = mySubActionMat.Material as DrugDefinition;
        //                    if (drug != null)
        //                    {
        //                        if(accTrx.UnitPrice.HasValue && drug.AccTrxUnitPriceDivider.HasValue && drug.AccTrxUnitPriceDivider.Value != 0)
        //                            accTrx.UnitPrice = accTrx.UnitPrice / drug.AccTrxUnitPriceDivider.Value;
        //
        //                        if (accTrx.Amount.HasValue && drug.AccTrxAmountMultiplier.HasValue && drug.AccTrxAmountMultiplier.Value != 0)
        //                            accTrx.Amount = accTrx.Amount * drug.AccTrxAmountMultiplier.Value;
        //                    }
        //                }
        //                
        //                mySubActionMat.AccountTransactions.Add(accTrx);
        //            }
        //        }
        //         */
        //        
        //        public class AddAccountTransactionParameter
        //        {
        //            public double Amount { get; set; }
        //            public DateTime? TransactionDate { get; set; }
        //            
        //            public AddAccountTransactionParameter()
        //            {
        //                Amount = 1;
        //            }
        //            
        //            public AddAccountTransactionParameter(double amount)
        //            {
        //                Amount = amount;
        //            }
        //            
        //            public AddAccountTransactionParameter(double amount, DateTime transactionDate)
        //            {
        //                Amount = amount;
        //                TransactionDate = transactionDate;
        //            }
        //        }
        //        
        //        public void AddAccountTransaction(AccountOwnerType accType, TTObject pObject, ManipulatedPrice mPricingDetail, PackageDefinition pPackageDefinition, AccountOperationTimeEnum accountingTimeType)
        //        {
        //            if(accType == AccountOwnerType.PAYER && Episode.IsMedulaEpisode()) // Kurum payı ve medula episode u ise
        //            {
        //                if (pObject.ObjectDef.IsOfType("SUBACTIONPROCEDURE") == true)
        //                {
        //                    SubActionProcedure sp = (SubActionProcedure) pObject;
        //                    List<AddAccountTransactionParameter> addAccountTransactionParameterList = new List<AddAccountTransactionParameter>();
        //                    sp.SetAmountAndDateListForAddAccountTransaction(ref addAccountTransactionParameterList);
        //                    if (addAccountTransactionParameterList.Count > 0)
        //                    {
        //                        foreach (AddAccountTransactionParameter addAccountTransactionParameter in addAccountTransactionParameterList)
        //                            AddAccountTransaction(accType, pObject, mPricingDetail, pPackageDefinition, accountingTimeType, addAccountTransactionParameter.Amount, addAccountTransactionParameter.TransactionDate);
        //                        
        //                        sp.AccTrxsMultipliedByAmount = true;
        //                        return;
        //                    }
        //                }
        //                else if (pObject.ObjectDef.IsOfType("SUBACTIONMATERIAL") == true)
        //                {
        //                    SubActionMaterial sm = (SubActionMaterial) pObject;
        //                    List<AddAccountTransactionParameter> addAccountTransactionParameterList = new List<AddAccountTransactionParameter>();
        //                    sm.SetAmountAndDateListForAddAccountTransaction(ref addAccountTransactionParameterList);
        //                    if (addAccountTransactionParameterList.Count > 0)
        //                    {
        //                        foreach (AddAccountTransactionParameter addAccountTransactionParameter in addAccountTransactionParameterList)
        //                            AddAccountTransaction(accType, pObject, mPricingDetail, pPackageDefinition, accountingTimeType, addAccountTransactionParameter.Amount, addAccountTransactionParameter.TransactionDate);
        //                        
        //                        sm.AccTrxsMultipliedByAmount = true;
        //                        return;
        //                    }
        //                }
        //            }
        //            
        //            AddAccountTransaction(accType, pObject, mPricingDetail, pPackageDefinition, accountingTimeType, null, null);
        //        }
        //        
        //        public void AddAccountTransaction(AccountOwnerType accType, TTObject pObject, ManipulatedPrice mPricingDetail, PackageDefinition pPackageDefinition, AccountOperationTimeEnum accountingTimeType, double? amount, DateTime? transactionDate)
        //        {
        //            AccountTransaction accTrx = new AccountTransaction(this.ObjectContext);
        //            DateTime serverTime = TTObjectDefManager.ServerTime;
        //            if (pObject.ObjectDef.IsOfType("SUBACTIONPROCEDURE") == true)
        //            {
        //                SubActionProcedure mySubActionProc = (SubActionProcedure) pObject;
        //                Episode e = mySubActionProc.Episode;
        //                
        //                if(mySubActionProc.PricingDate == null)     // PricingDate boş ise, önce ActionDate set edilsin, ActionDate boş ise
        //                {                                           // serverTime set edilsin şeklinde istendi )
        //                    if(mySubActionProc.ActionDate != null)
        //                        mySubActionProc.PricingDate = mySubActionProc.ActionDate;
        //                    else
        //                        mySubActionProc.PricingDate = serverTime;
        //                }
        //                
        //                accTrx.SubActionProcedure = mySubActionProc;
        //
        //                if (amount.HasValue)
        //                    accTrx.Amount = amount.Value;
        //                else
        //                    accTrx.Amount = mySubActionProc.Amount;
        //
        //                accTrx.Description = mPricingDetail.Description;
        //                
        //                if(mySubActionProc.ExtraDescription != null)
        //                {
        //                    if(mySubActionProc.ExtraDescription.Trim() != "")
        //                        accTrx.Description = accTrx.Description + " " + mySubActionProc.ExtraDescription;
        //                }
        //                
        //                accTrx.ExternalCode = mPricingDetail.ExternalCode;
        //
        //                if (transactionDate.HasValue)
        //                    accTrx.TransactionDate = transactionDate.Value;
        //                else
        //                    accTrx.TransactionDate = mySubActionProc.PricingDate;
        //
        //                accTrx.EpisodeProtocol = this;
        //                accTrx.PricingDetail = mPricingDetail.PricingDetailDefinition;
        //                
        //                if (accountingTimeType == AccountOperationTimeEnum.POST)
        //                    accTrx.CurrentStateDefID = AccountTransaction.States.ToBeNew;
        //                else if (accountingTimeType == AccountOperationTimeEnum.PRE)
        //                    accTrx.CurrentStateDefID = AccountTransaction.States.New;
        //                
        //                if (accType == AccountOwnerType.PAYER)
        //                {
        //                    // Hasta ve kurum payı 0 ise, AccTrx in hasta veya kurum payı olarak oluşacağına anlaşmasından karar veriliyor
        //                    if(mPricingDetail.PayerPrice == 0 && mPricingDetail.PatientPrice == 0 && this.Protocol.Type == ProtocolTypeEnum.Paid)
        //                        accTrx.AccountPayableReceivable = e.Patient.MyAPR();
        //                    else
        //                    {
        //                        this.Payer.ControlAndCreateAPR();
        //                        accTrx.AccountPayableReceivable = this.Payer.MyAPR();
        //                    }
        //                    accTrx.UnitPrice = mPricingDetail.PayerPrice;
        //                }
        //                else if (accType == AccountOwnerType.PATIENT)
        //                {
        //                    accTrx.AccountPayableReceivable = e.Patient.MyAPR();
        //                    accTrx.UnitPrice = mPricingDetail.PatientPrice;
        //                }
        //                // ücretli hastaya paket girilmediği için kurum payı kontrolü vardı, sonradan kaldırıldı.  (&& accType == AccountOwnerType.PAYER)
        //                if (pPackageDefinition != null)
        //                    accTrx.PackageDefinition = pPackageDefinition;
        //                
        //                mySubActionProc.AccountTransactions.Add(accTrx);
        //            }
        //            else if (pObject.ObjectDef.IsOfType("SUBACTIONMATERIAL") == true)
        //            {
        //                SubActionMaterial mySubActionMat = (SubActionMaterial) pObject;
        //                Episode e = mySubActionMat.Episode;
        //                
        //                if(mySubActionMat.PricingDate == null)     // PricingDate boş ise, önce ActionDate set edilsin, ActionDate boş ise
        //                {                                          // serverTime set edilsin şeklinde istendi )
        //                    if(mySubActionMat.ActionDate != null)
        //                        mySubActionMat.PricingDate = mySubActionMat.ActionDate;
        //                    else
        //                        mySubActionMat.PricingDate = serverTime;
        //                }
        //                
        //                accTrx.SubActionMaterial = mySubActionMat;
        //
        //                if (amount.HasValue)
        //                    accTrx.Amount = amount.Value;
        //                else
        //                    accTrx.Amount = mySubActionMat.Amount;
        //                
        //                accTrx.PricingDetail = mPricingDetail.PricingDetailDefinition;
        //                accTrx.Description = mPricingDetail.Description;
        //                
        //                if(mySubActionMat.UBBCode != null)
        //                {
        //                    if(mySubActionMat.UBBCode.Trim() != "")
        //                        accTrx.Description = accTrx.Description + " (UBB Kodu:" + mySubActionMat.UBBCode + ")";
        //                }
        //                
        //                if(accTrx.PricingDetail != null)
        //                {
        //                    if(accTrx.PricingDetail.DiscountPercent != null)
        //                    {
        //                        if(accTrx.PricingDetail.DiscountPercent > 0)
        //                            accTrx.Description = accTrx.Description + " (%" + (accTrx.PricingDetail.DiscountPercent * 100) + " İNDİRİM)";
        //                    }
        //                }
        //                
        //                // İlaçlar için barkodu dolu ise, accTrx.ExternalCode barkod ile set edilir
        //                if(mySubActionMat.Material != null && mySubActionMat.Material is DrugDefinition && !string.IsNullOrEmpty(mySubActionMat.Material.Barcode))
        //                    accTrx.ExternalCode = mySubActionMat.Material.Barcode;
        //                
        //                // accTrx.ExternalCode boş kalmış ise, fiyatın kodu ile set edilir
        //                if(string.IsNullOrEmpty(accTrx.ExternalCode))
        //                    accTrx.ExternalCode = mPricingDetail.ExternalCode;
        //
        //                if (transactionDate.HasValue)
        //                    accTrx.TransactionDate = transactionDate.Value;
        //                else
        //                    accTrx.TransactionDate = mySubActionMat.PricingDate;
        //
        //                accTrx.EpisodeProtocol = this;
        //                
        //                if (accountingTimeType == AccountOperationTimeEnum.POST)
        //                    accTrx.CurrentStateDefID = AccountTransaction.States.ToBeNew;
        //                else if (accountingTimeType == AccountOperationTimeEnum.PRE)
        //                    accTrx.CurrentStateDefID = AccountTransaction.States.New;
        //                
        //                if (accType == AccountOwnerType.PAYER)
        //                {
        //                    // Hasta ve kurum payı 0 ise, AccTrx in hasta veya kurum payı olarak oluşacağına anlaşmasından karar veriliyor
        //                    if(mPricingDetail.PayerPrice == 0 && mPricingDetail.PatientPrice == 0 && this.Protocol.Type == ProtocolTypeEnum.Paid)
        //                        accTrx.AccountPayableReceivable = e.Patient.MyAPR();
        //                    else
        //                    {
        //                        this.Payer.ControlAndCreateAPR();
        //                        accTrx.AccountPayableReceivable = this.Payer.MyAPR();
        //                    }
        //                    accTrx.UnitPrice = mPricingDetail.PayerPrice;
        //                }
        //                else if (accType == AccountOwnerType.PATIENT)
        //                {
        //                    accTrx.AccountPayableReceivable = e.Patient.MyAPR();
        //                    accTrx.UnitPrice = mPricingDetail.PatientPrice;
        //                }
        //                
        //                // ücretli hastaya paket girilmediği için kurum payı kontrolü vardı, sonradan kaldırıldı.  (&& accType == AccountOwnerType.PAYER)
        //                if (pPackageDefinition != null)
        //                    accTrx.PackageDefinition = pPackageDefinition;
        //                
        //                // "Birim Fiyat Böleni" veya "Miktar Çarpanı" olan ve fiyat tanımından ücretlenen ilaçlar için accTrx.UnitPrice ve accTrx.Amount değiştirilir
        //                if(accTrx.PricingDetail != null)
        //                {
        //                    DrugDefinition drug = mySubActionMat.Material as DrugDefinition;
        //                    if (drug != null)
        //                    {
        //                        if(accTrx.UnitPrice.HasValue && drug.AccTrxUnitPriceDivider.HasValue && drug.AccTrxUnitPriceDivider.Value != 0)
        //                            accTrx.UnitPrice = accTrx.UnitPrice / drug.AccTrxUnitPriceDivider.Value;
        //
        //                        if (accTrx.Amount.HasValue && drug.AccTrxAmountMultiplier.HasValue && drug.AccTrxAmountMultiplier.Value != 0)
        //                            accTrx.Amount = accTrx.Amount * drug.AccTrxAmountMultiplier.Value;
        //                    }
        //                }
        //                
        //                mySubActionMat.AccountTransactions.Add(accTrx);
        //            }
        //        }

        #endregion Methods

    }
}