using System;
using System.Collections.Generic;
using TTObjectClasses;
using static TTObjectClasses.SubEpisodeProtocol;

namespace Core.Models
{
    public class TermInformationModel
    {
        public Guid? Term
        {
            get;
            set;
        }

        public int? GSSDocumentNo
        {
            get;
            set;
        }

        public int? TempProtDocumentNo
        {
            get;
            set;
        }

        public bool Approved
        {
            get;
            set;
        }

        public DateTime? ApproveDate
        {
            get;
            set;
        }

        public string ApproveUser
        {
            get;
            set;
        }

        public decimal MedulaTotal
        {
            get;
            set;
        }

        public decimal MedulaBKKTotal
        {
            get;
            set;
        }

        public decimal MedulaNetTotal
        {
            get;
            set;
        }

        public decimal MedulaGocIdaresiTotal
        {
            get;
            set;
        }

        public decimal HBYSSEPTotal
        {
            get;
            set;
        }

        public decimal HBYSAccTrxTotal
        {
            get;
            set;
        }
    }

    public class InvoiceAccountancyFormViewModel
    {
        public TermInformationModel TermInformation
        {
            get;
            set;
        }

        public List<InvoiceTerm.SEPInformationModel> SEPInformationList;

        public InvoiceAccountancyFormViewModel()
        {
            TermInformation = new TermInformationModel();
            SEPInformationList = new List<InvoiceTerm.SEPInformationModel>();
        }
    }

    public class MIFModel
    {
        public MIFInfo MIFInfo
        {
            get;
            set;
        }

        public List<InvoiceTerm.MIFPayer> MIFPayers;

        public MIFModel()
        {
            MIFInfo = new MIFInfo();
            MIFPayers = new List<InvoiceTerm.MIFPayer>();
        }
    }

    public class MIFInfo
    {
        public Guid? TermObjectID
        {
            get;
            set;
        }

        public int? MIFType
        {
            get;
            set;
        }

        public Guid? MIFObjectID
        {
            get;
            set;
        }

        public string MIFName
        {
            get;
            set;
        }

        //public DateTime? CreateDate
        //{
        //    get;
        //    set;
        //}
        //public string CreateUser
        //{
        //    get;
        //    set;
        //}
    }
}