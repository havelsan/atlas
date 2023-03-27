using System;
using System.Collections.Generic;
using System.Linq;
using TTDataDictionary;
using TTObjectClasses;

namespace Core.Models
{
    //Form'a dönecek model
    public class CashOfficePatientFormViewModel
    {
        public List<CashOfficeWorkListResultModel> CashOfficeWorkListResultModel
        {
            get;
            set;
        }

        public CashOfficePatientSearchModel CashOfficePatientSearchModel
        {
            get;
            set;
        }

        public CashOfficePatientDetailModel CashOfficePatientDetailModel
        {
            get;
            set;
        }

        public List<CashOfficePatientResultModel> CashOfficePatientResultModel
        {
            get;
            set;
        }

        public PatientOldDebtFormModel PatientOldDebtFormModel { get; set; }

        public Dictionary<string, bool> Roles = new Dictionary<string, bool>();
        public CashOfficePatientFormViewModel()
        {
            CashOfficeWorkListResultModel = new List<CashOfficeWorkListResultModel>();
            CashOfficePatientSearchModel = new CashOfficePatientSearchModel();
            CashOfficePatientDetailModel = new CashOfficePatientDetailModel();
            CashOfficePatientResultModel = new List<CashOfficePatientResultModel>();
            PatientOldDebtFormModel = new PatientOldDebtFormModel();
        }
    }

    //Hasta arama kriteri sunucuya gönderilecek model
    public class CashOfficePatientSearchModel
    {
        public long? EpisodeID
        {
            get;
            set;
        }

        public string TCNo
        {
            get;
            set;
        }

        public string FirstName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public DateTime? ApplicationStartDate
        {
            get;
            set;
        }

        public DateTime? ApplicationEndDate
        {
            get;
            set;
        }

        public Guid? SelectedPayerDefinition
        {
            get;
            set;
        }

        public PatientDebtTypeEnum SelectedDebtType
        {
            get;
            set;
        }

        public Guid? SelectedBuilding
        {
            get;
            set;
        }
    }

    //Hasta detay bilgilerinin doldurulacağı model
    public class CashOfficePatientDetailModel
    {
        public string EpisodeID
        {
            get;
            set;
        }

        public string FullName
        {
            get;
            set;
        }

        public string BirthDate
        {
            get;
            set;
        }

        public string FatherName
        {
            get;
            set;
        }

        public string MotherName
        {
            get;
            set;
        }

        public string TCNo
        {
            get;
            set;
        }

        public string ServiceName
        {
            get;
            set;
        }

        public Currency ServiceTotal
        {
            get;
            set;
        }

        public Currency BackPrice
        {
            get;
            set;
        }

        public Currency TotalReceiptPayment
        {
            get;
            set;
        }

        public Currency? AdvancePayment
        {
            get;
            set;
        }

        public Currency RemainingDebt
        {
            get;
            set;
        }

        public Currency BondTotal
        {
            get;
            set;
        }

        public string PayerProtocol { get; set; }
        public string MedulaSigortaliTuru { get; set; }
    }

    //Episode - Hasta bilgilerinin doldurulacağı model
    public class CashOfficePatientResultModel
    {
        public Guid ObjectID;
        public Guid PatientObjectID;
        public string EpisodeID;
        public string FullName;
        public Currency? TotalDebt;
        public string TCNo;
        public DateTime? Date
        {
            get;
            set;
        }
    }

    //Seçilen episode'a ait vezne işlemlerinin doldurulacağı model olarak CashOfficeWorkListResultModel.cs i kullan

    #region Eski hasta borcu
    public class PatientOldDebtFormModel
    {
        public PaymentTypeEnum PaymentType { get; set; }
        public Currency? TotalPrice { get; set; }
        public Guid PatientObjectID { get; set; }
        public DateTime Date { get; set; }
        public string DocumentNo { get; set; }
        public string PayeeName { get; set; }
        public List<PatientOldDebtTransactionDebtModel> Transactions { get; set; }

    }

    public class PatientOldDebtTransactionDebtModel
    {
        public string ProcedureCode { get; set; }
        public string ProcedureName { get; set; }
        public string ProcedureType { get; set; }
        public Currency? TransactionDebt { get; set; }
    }
    #endregion Eski hasta borcu
}