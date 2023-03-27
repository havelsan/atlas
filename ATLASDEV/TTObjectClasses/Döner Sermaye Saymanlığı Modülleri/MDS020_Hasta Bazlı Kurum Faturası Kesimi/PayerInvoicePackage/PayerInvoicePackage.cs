
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
    /// Kurum Faturası Paket Hizmet Kalemleri
    /// </summary>
    public  partial class PayerInvoicePackage : TTObject
    {
#region Methods
        public IList GetIncludedAccountTransactions(EpisodeProtocol ep)
        {
            List<AccountTransaction> includedAccountTransactions = new List<AccountTransaction>();
            
            /* TODO:SEP
            foreach (AccountTransaction accTrx in ep.GetTransactionsForInvoice(AccountTransaction.States.New, ep.Payer.MyAPR()))
            {
                if (accTrx.PackageDefinition != null)
                {
                    if (accTrx.PackageDefinition == this.PackageAccountTransaction[0].SubActionProcedure.PackageDefinition)
                        includedAccountTransactions.Add(accTrx);
                }
            }
            
            foreach (AccountTransaction accTrx in ep.GetTransactionsForInvoice(AccountTransaction.States.ToBeNew, ep.Payer.MyAPR()))
            {
                if (accTrx.PackageDefinition != null)
                {
                    if (accTrx.PackageDefinition == this.PackageAccountTransaction[0].SubActionProcedure.PackageDefinition)
                        includedAccountTransactions.Add(accTrx);
                }
            }
            */
            
            return includedAccountTransactions;
        }
        
#endregion Methods

    }
}