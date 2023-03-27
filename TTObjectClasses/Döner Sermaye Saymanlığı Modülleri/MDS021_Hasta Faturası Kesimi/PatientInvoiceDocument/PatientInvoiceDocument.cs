
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
    /// Hasta Faturası Dökümanı
    /// </summary>
    public  partial class PatientInvoiceDocument : AccountDocument
    {
#region Methods
        public void Cancel()
        {
            if (CurrentStateDefID != PatientInvoiceDocument.States.Cancelled)
            {
                foreach (PatientInvoiceDocumentGroup invGroup in PatientInvoiceDocumentGroups )
                {
                    foreach (PatientInvoiceDocumentDetail invDetail in invGroup.PatientInvoiceDocumentDetails)
                    {
                        invDetail.AccountTrxDocument[0].AccountTransaction.CurrentStateDefID = AccountTransaction.States.Paid;
                        invDetail.CurrentStateDefID = PatientInvoiceDocumentDetail.States.Cancelled;
                        
                        // Paketin içindeki AccTrx leri de Ödendi durumuna almak için
                        if(invDetail.AccountTrxDocument[0].AccountTransaction.SubActionProcedure != null)
                        {
                            if(invDetail.AccountTrxDocument[0].AccountTransaction.SubActionProcedure.PackageDefinition != null)
                            {
                                foreach(AccountTransaction accTrx in invDetail.AccountTrxDocument[0].AccountTransaction.SubEpisodeProtocol.GetTransactionsInsidePackage(invDetail.AccountTrxDocument[0].AccountTransaction.SubActionProcedure.PackageDefinition, PatientInvoice[0].Episode.Patient.MyAPR()))
                                {
                                    if(accTrx.CurrentStateDefID == AccountTransaction.States.Invoiced)
                                        accTrx.CurrentStateDefID = AccountTransaction.States.Paid;
                                }
                            }
                        }
                    }
                }
                CurrentStateDefID = PatientInvoiceDocument.States.Cancelled;
            }
        }
        
#endregion Methods

    }
}