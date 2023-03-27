using Org.BouncyCastle.Bcpg.OpenPgp;
using System;
using System.Collections.Generic;
using TTDataDictionary;

namespace Core.Models
{
    public class MkysIntegrationViewModel
    {
        public bool hasRoleSendToMkys { get; set; }
        public bool hasRoleCompareToMkys { get; set; }
        public bool hasRoleMkysDocumentsFromInstitutions { get; set; }
        public bool hasRoleMkysEndOfYearCensus { get; set; }

        public List<DocumentRecordLogGridItem> DocumentRecordLogGridListItem
        {
            get;
            set;
        }

        public ActiveAccountingTerm ActiveAccountingTerm
        {
            get;
            set;
        }

        public List<StockActionDetailView> StockActionDetailViews
        {
            get;
            set;
        }

        public List<StockActionMkysCompareItem> StockActionMkysCompareItems
        {
            get;
            set;
        }

        public List<ReceivedDataFromMkys> receivedDataSource
        {
            get;
            set;
        }

    }

    public class ActiveAccountingTerm
    {
        public Guid? AccountingTerm
        {
            get;
            set;
        }

        public string Desciption
        {
            get;
            set;
        }
    }

    public class DocumentRecordLogGridItem
    {
        public Guid ObjectID { get; set; }
        public string Subject
        {
            get;
            set;
        }

        public long DocumentRecordLogNumber
        {
            get;
            set;
        }

        public TTObjectClasses.DocumentTransactionTypeEnum DocumentTransactionType
        {
            get;
            set;
        }

        public DateTime DocumentDateTime
        {
            get;
            set;
        }

        public int? ReceiptNumber
        {
            get;
            set;
        }

        public Guid? StockAction
        {
            get;
            set;
        }

        public string StockActionID
        {
            get;
            set;
        }

        public string MKYSResultMsg
        {
            get;
            set;
        }
        public TTObjectClasses.MKYSControlEnum MKYSControlType
        {
            get;
            set;
        }
        public TTObjectClasses.MKYS_EButceTurEnum BudgetTypeName { get; set; }
    }

    public class StockActionMkysCompareItem
    {
        public List<StockActionDetailView> StockActionDetailViews
        {
            get;
            set;
        }

        public string StockActionID
        {
            get;
            set;
        }

        public string StockActionName
        {
            get;
            set;
        }

        public DateTime StockActionTransactionDate
        {
            get;
            set;
        }

        public MkysCompareResultColorEnum colorEnum
        {
            get;
            set;
        }

        public bool IsFaild
        {
            get;
            set;
        }
    }

    public class StockActionDetailView
    {
        public List<CompareTaskItem> CompareTaskItems
        {
            get;
            set;
        }

        public int StokHareketID
        {
            get;
            set;
        }

        public int AyniyatMakbuzID
        {
            get;
            set;
        }

        public int MalzemeKayitID
        {
            get;
            set;
        }

        public string Material
        {
            get;
            set;
        }
    }

    public class CompareTaskItem
    {
        public string Subject
        {
            get;
            set;
        }

        public string MkysValue
        {
            get;
            set;
        }

        public string MyValue
        {
            get;
            set;
        }

        public bool Result
        {
            get;
            set;
        }
    }

    public enum MkysCompareResultColorEnum
    {
        red = 0,
        blue = 1
    }

    public class InputFor_ChattelDocumentCreate
    {
        public List<ReceivedDataFromMkys> SelectedReceivedDataItems
        {
            get;
            set;
        }

       public TTObjectClasses.Store Store { get; set; }
    }

    public class ReceivedDataFromMkys
    {
        public TTObjectClasses.MkysServis.kurumlardanGelenDevirItem kurumlardanGelenDevirItem
        {
            get;
            set;
        }

        public string turu;
        public System.Nullable<int> cikisBelgeNo;
        public System.Nullable<System.DateTime> cikisBelgeTarihi;
        public string gonderenBirimAdi;
        public string gonderenButceTuruAdi;
        public string gonderenDepoAdi;
        public string hareketTuru;
        public System.Nullable<int> gonderenBirimID;
        public int birimDepoID;
        public System.Nullable<int> islemKayitNo;
        public int devirGerceklestiMi;
        public List<TTObjectClasses.MkysServis.devirFisiItem> details
        {
            get;
            set;
        }
    }
}