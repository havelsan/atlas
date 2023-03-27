using System;
using System.Collections.Generic;
using System.Linq;
using TTDataDictionary;
using TTObjectClasses;

namespace Core.Models
{
    public class InvoicePaymentFormModel
    {
        public InvoicePaymentModel InvoicePayment
        {
            get;
            set;
        }

        public List<InvoicePaymentDetailModel> InvoicePaymentDetailList
        {
            get;
            set;
        }

        public InvoicePaymentFormModel()
        {
            this.InvoicePayment = new InvoicePaymentModel();
            this.InvoicePaymentDetailList = new List<InvoicePaymentDetailModel>();
        }
    }

    public class InvoicePaymentModel
    {
        public Guid? PIPObjectId
        {
            get;
            set;
        }

        public listboxObject Payer
        {
            get;
            set;
        }

        public DateTime? CreateDate
        {
            get;
            set;
        }

        public string Username
        {
            get;
            set;
        }

        public Guid? BankAccount
        {
            get;
            set;
        }

        public DateTime? DecountDate
        {
            get;
            set;
        }

        public string DecountNo
        {
            get;
            set;
        }

        public decimal TotalPrice
        {
            get;
            set;
        }

        public decimal PaymentPrice
        {
            get;
            set;
        }

        public decimal Deduction
        {
            get;
            set;
        }

        public decimal InvoicePrice
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public string CancelDescription
        {
            get;
            set;
        }

        public Guid CurrentStateDefID
        {
            get;
            set;
        }

        public InvoicePaymentModel()
        {
            Payer = new listboxObject();
        //BankAccount = new listboxObject();
        }
    }

    public class InvoicePaymentDetailModel
    {
        public Guid InvoiceCollectionDetailID
        {
            get;
            set;
        }

        public Guid ICDCurrentStateDefID
        {
            get;
            set;
        }

        public string PatientName
        {
            get;
            set;
        }

        public string UniqueRefNo
        {
            get;
            set;
        }

        public string EpisodeID
        {
            get;
            set;
        }

        public string InvoiceDate
        {
            get;
            set;
        }

        public string InvoiceNo
        {
            get;
            set;
        }

        public decimal InvoicePrice
        {
            get;
            set;
        }

        public decimal InvoiceRestPrice
        {
            get;
            set;
        }

        public decimal Payment
        {
            get;
            set;
        }

        public decimal Deduction
        {
            get;
            set;
        }

        public Guid? PayerObjectID
        {
            get;
            set;
        }

        public string PayerName
        {
            get;
            set;
        }

        public string TermName
        {
            get;
            set;
        }

        public bool IsTermOpen
        {
            get;
            set;
        }

        public string StatusDisplayText
        {
            get;
            set;
        }
    }
}