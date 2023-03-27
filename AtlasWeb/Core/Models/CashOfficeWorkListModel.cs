using System;
using System.Collections.Generic;
using System.Linq;
using TTDataDictionary;
using TTDefinitionManagement;
using TTObjectClasses;

namespace Core.Models
{
    public class CashOfficeWorkListFormViewModel
    {
        public CashOfficeWorkListResultModel CashOfficeWorkListResultModel
        {
            get;
            set;
        }

        public CashOfficeWorkListSearchModel CashOfficeWorkListSearchModel
        {
            get;
            set;
        }

        //public bool HasNewMainCashOfficeRole;
        //public bool HasNewBankDecountPaymentRole;
        public Dictionary<string, bool> Roles = new Dictionary<string, bool>();
        public CashOfficeWorkListFormViewModel()
        {
            CashOfficeWorkListResultModel = new CashOfficeWorkListResultModel();
            CashOfficeWorkListSearchModel = new CashOfficeWorkListSearchModel();
        }
    }

    public class CashOfficeWorkListResultModel
    {
        public Guid ObjectID
        {
            get;
            set;
        }

        public string ObjectDefName
        {
            get;
            set;
        }

        public DateTime? Date
        {
            get;
            set;
        }

        public string State
        {
            get;
            set;
        }

        public string OperationType
        {
            get;
            set;
        }

        public string Id
        {
            get;
            set;
        }

        public string ReceiptNo
        {
            get;
            set;
        }

        public Currency? PaymentPrice
        {
            get;
            set;
        }

        public string UniqueRefNo
        {
            get;
            set;
        }

        public string PatientFullName
        {
            get;
            set;
        }

        public long ? EpisodeID
        {
            get;
            set;
        }

        public string CashierName
        {
            get;
            set;
        }

        public Guid? EpisodeObjectID
        {
            get;
            set;
        }
    }

    public class CashOfficeWorkListSearchModel
    {
        public DateTime? StartDate
        {
            get;
            set;
        }

        public DateTime? EndDate
        {
            get;
            set;
        }

        public StateStatusEnum? State
        {
            get;
            set;
        }

        public List<Guid> SelectedOperationTypeListItems
        {
            get;
            set;
        }

        public int ? Id
        {
            get;
            set;
        }

        public string ReceiptNo
        {
            get;
            set;
        }

        public string UniqueRefNo
        {
            get;
            set;
        }

        public string CashierName
        {
            get;
            set;
        }

        public Guid? CashierObjID
        {
            get;
            set;
        }

        public Guid? CashOfficeID
        {
            get;
            set;
        }

        public PatientStatusEnum? PatientStatus
        {
            get;
            set;
        }

        public BondWorkListSearchModel BondSearchModel
        {
            get;
            set;
        }
    }

    public class BondWorkListSearchModel
    {
        //Senet kriterleri
        public DateTime? BondDetailStartDate
        {
            get;
            set;
        }

        public DateTime? BondDetailEndDate
        {
            get;
            set;
        }

        public BondNotificationStatusEnum? SelectedNotificationStatus
        {
            get;
            set;
        }

        public List<string> SelectedBondStates = new List<string>();
        public bool BondDetailExpired
        {
            get;
            set;
        }

        public DateTime? BondFirstNotStartDate
        {
            get;
            set;
        }

        public DateTime? BondFirstNotEndDate
        {
            get;
            set;
        }

        public DateTime? BondSecondNotStartDate
        {
            get;
            set;
        }

        public DateTime? BondSecondNotEndDate
        {
            get;
            set;
        }
    }
}