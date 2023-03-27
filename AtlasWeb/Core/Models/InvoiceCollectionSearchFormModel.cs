using System;
using System.Collections.Generic;
using System.Linq;
using TTDataDictionary;
using TTObjectClasses;

namespace Core.Models
{
    public class InvoiceCollectionSearchFormModel
    {
        public InvoiceCollectionSearchModel InvoiceCollectionSearchModel
        {
            get;
            set;
        }

        public InvoiceCollectionDetailModelDto InvoiceCollectionDetailModelDto
        {
            get;
            set;
        }

        public InvoiceCollectionSearchFormModel()
        {
            this.InvoiceCollectionSearchModel = new InvoiceCollectionSearchModel();
            this.InvoiceCollectionDetailModelDto = new InvoiceCollectionDetailModelDto();
        }
    }

    public class InvoiceCollectionSearchModel
    {
        public Guid? TedaviTuru
        {
            get;
            set;
        }

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

        public DateTime? ICFirstDate
        {
            get;
            set;
        }

        public DateTime? ICLastDate
        {
            get;
            set;
        }

        public DateTime? ICPostFirstDate
        {
            get;
            set;
        }

        public DateTime? ICPostLastDate
        {
            get;
            set;
        }

        public string ICFirstPrice
        {
            get;
            set;
        }

        public string ICLastPrice
        {
            get;
            set;
        }

        public string ICNo
        {
            get;
            set;
        }

        public string ICPostNo
        {
            get;
            set;
        }

        public InvoiceCollectionSearchModel()
        {
        //this.Payer = new listboxObject();
        }
    }

    public class listboxObject
    {
        public listboxObject(Guid? _objectID, string _name, string _code)
        {
            this.ObjectID = _objectID;
            this.Name = _name;
            this.Code = _code;
        }

        public listboxObject()
        {
            this.ObjectID = new Guid();
            this.Name = "";
            this.Code = "";
        }

        public Guid? ObjectID
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Code
        {
            get;
            set;
        }
    }

    public class InvoiceCollectionSearchResultModel
    {
        public Guid? ObjectID
        {
            get;
            set;
        }

        public long ? No
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public listboxObject Payer
        {
            get;
            set;
        }

        public string StateDisplayText
        {
            get;
            set;
        }

        public DateTime? Date
        {
            get;
            set;
        }

        public int InvoiceCount
        {
            get;
            set;
        }

        public string InvoicePrice
        {
            get;
            set;
        }

        public string PaymentPrice
        {
            get;
            set;
        }

        public string Deduction
        {
            get;
            set;
        }
        public string TermName
        {
            get;
            set;
        }
        public DateTime? LastPaymentDate { get; set; }
    }

    public class InvoiceCollectionDetailModelDto
    {
        public string HizmetToplami
        {
            get;
            set;
        }

        public string IlacToplami
        {
            get;
            set;
        }

        public string SarfToplami
        {
            get;
            set;
        }

        public InvoiceCollectionDetailListDto[] InvoiceCollectionDetailList
        {
            get;
            set;
        }
    }

    public class InvoiceCollectionDetailListDto
    {
        public DateTime? CreateDate
        {
            get;
            set;
        }

        public string PatientName
        {
            get;
            set;
        }
    }
}