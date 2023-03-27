using System;
using System.Collections.Generic;
using System.Linq;
using TTDataDictionary;
using TTObjectClasses;

namespace Core.Models
{
    public class InvoicePaymentSearchFormModel
    {
        public InvoicePaymentSearchModel InvoicePaymentSearchModel
        {
            get;
            set;
        }

        public InvoicePaymentSearchResultModel InvoicePaymentSearchResultModel
        {
            get;
            set;
        }

        public listboxObject newPaymentPayer
        {
            get;
            set;
        }

        public string newPaymentUniqueID
        {
            get;
            set;
        }

        public string newPaymentInvoiceNo
        {
            get;
            set;
        }

        public string newPaymentControlTotalPayment
        {
            get;
            set;
        }

        public InvoicePaymentSearchFormModel()
        {
            this.InvoicePaymentSearchModel = new InvoicePaymentSearchModel();
            this.InvoicePaymentSearchResultModel = new InvoicePaymentSearchResultModel();
            this.newPaymentPayer = new listboxObject();
        }

        public object newPaymentPayerType { get; set; }
        public object newPaymentTerm { get; set; }
        public int newPaymentRemainingPaymentTime { get; set; }
    }

    public class InvoicePaymentSearchModel
    {
        public Guid? Term
        {
            get;
            set;
        }

        public string State
        {
            get;
            set;
        }

        public Guid? Payer
        {
            get;
            set;
        }

        public Guid? BankAccount
        {
            get;
            set;
        }

        public Guid? User
        {
            get;
            set;
        }

        public DateTime? FirstDecountDate
        {
            get;
            set;
        }

        public DateTime? LastDecountDate
        {
            get;
            set;
        }

        public string FirstPrice
        {
            get;
            set;
        }

        public string LastPrice
        {
            get;
            set;
        }

        public string DecountNo
        {
            get;
            set;
        }

        public string PatientUniqueRefNo
        {
            get;
            set;
        }

        public string InvoiceNo
        {
            get;
            set;
        }

        public DateTime? LastPaymentDate { get; set; }

        public InvoicePaymentSearchModel()
        {
            //Payer = new listboxObject();
        }
    }

    public class GetInvoiceCollectionFromPayer_Input
    {
        public Guid? payerObjectID { get; set; }
        public Guid? termObjectID { get; set; }
        public Guid? payerType { get; set; }
        public int? remainingPaymentTime { get; set; }
        public DateTime? lastPaymentDate { get; set; }
    }

    public class InvoicePaymentSearchResultModel
    {
        public Guid? ObjectID
        {
            get;
            set;
        }

        public string Payer
        {
            get;
            set;
        }

        public string StateDisplayText
        {
            get;
            set;
        }

        public string DecountNo
        {
            get;
            set;
        }

        public DateTime? DecountDate
        {
            get;
            set;
        }

        public string TotalPrice
        {
            get;
            set;
        }

        public string Deduction
        {
            get;
            set;
        }
    }
}