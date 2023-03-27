
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
    /// Fatura Tahsilat
    /// </summary>
    public partial class PayerInvoicePayment : AccountAction
    {
        protected void PostTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(PayerInvoicePayment).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            //Cancel
            if (toState == PayerInvoicePayment.States.Cancelled)
                Cancel();
        }

        public void Cancel()
        {
            List<InvoiceCollection> ICList = new List<InvoiceCollection>();
            foreach (PayerInvoicePaymentDetail pipDetail in PIPDetails.Select(""))
            {
                pipDetail.ICD.Payment -= pipDetail.Payment;
                pipDetail.ICD.Deduction -= pipDetail.Deduction;

                if ((pipDetail.ICD.Payment + pipDetail.ICD.Deduction) > 0)
                    pipDetail.ICD.CurrentStateDefID = InvoiceCollectionDetail.States.PartialPaid;
                else
                    pipDetail.ICD.CurrentStateDefID = InvoiceCollectionDetail.States.Invoiced;

                if (!ICList.Contains(pipDetail.ICD.InvoiceCollection))
                    ICList.Add(pipDetail.ICD.InvoiceCollection);
            }

            foreach (InvoiceCollection ic in ICList)
                ic.SetStateAfterInvoicePayment();
        }
    }
}