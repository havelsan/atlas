
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AccountDocumentGroup")] 

    /// <summary>
    /// Finansal Döküman Grupları
    /// </summary>
    public  partial class AccountDocumentGroup : TTObject
    {
        public class AccountDocumentGroupList : TTObjectCollection<AccountDocumentGroup> { }
                    
        public class ChildAccountDocumentGroupCollection : TTObject.TTChildObjectCollection<AccountDocumentGroup>
        {
            public ChildAccountDocumentGroupCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAccountDocumentGroupCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Grup Açıklaması
    /// </summary>
        public string GroupDescription
        {
            get { return (string)this["GROUPDESCRIPTION"]; }
            set { this["GROUPDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Grup Kodu
    /// </summary>
        public string GroupCode
        {
            get { return (string)this["GROUPCODE"]; }
            set { this["GROUPCODE"] = value; }
        }

    /// <summary>
    /// Finansal Döküman türleriyle ilişki
    /// </summary>
        public AccountDocument AccountDocument
        {
            get { return (AccountDocument)((ITTObject)this).GetParent("ACCOUNTDOCUMENT"); }
            set { this["ACCOUNTDOCUMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateAccountDocumentDetailsCollectionViews()
        {
            _ReceiptDocumentDetails = new ReceiptDocumentDetail.ChildReceiptDocumentDetailCollection(_AccountDocumentDetails, "ReceiptDocumentDetails");
            _AdvanceBackDocumentDetails = new AdvanceBackDocumentDetail.ChildAdvanceBackDocumentDetailCollection(_AccountDocumentDetails, "AdvanceBackDocumentDetails");
            _AdvanceDocumentDetails = new AdvanceDocumentDetail.ChildAdvanceDocumentDetailCollection(_AccountDocumentDetails, "AdvanceDocumentDetails");
            _CashOfficeReceiptDocumentDetails = new CashOfficeReceiptDocumentDetail.ChildCashOfficeReceiptDocumentDetailCollection(_AccountDocumentDetails, "CashOfficeReceiptDocumentDetails");
            _DebenturePaymentDocumentDetails = new DebenturePaymentDocumentDetail.ChildDebenturePaymentDocumentDetailCollection(_AccountDocumentDetails, "DebenturePaymentDocumentDetails");
            _ReceiptBackDocumentDetails = new ReceiptBackDocumentDetail.ChildReceiptBackDocumentDetailCollection(_AccountDocumentDetails, "ReceiptBackDocumentDetails");
            _PatientInvoiceDocumentDetails = new PatientInvoiceDocumentDetail.ChildPatientInvoiceDocumentDetailCollection(_AccountDocumentDetails, "PatientInvoiceDocumentDetails");
            _CollectedInvoiceDocumentDetails = new CollectedInvoiceDocumentDetail.ChildCollectedInvoiceDocumentDetailCollection(_AccountDocumentDetails, "CollectedInvoiceDocumentDetails");
            _MainCashOfficeBackDocumentDetails = new MainCashOfficeBackDocumentDetail.ChildMainCashOfficeBackDocumentDetailCollection(_AccountDocumentDetails, "MainCashOfficeBackDocumentDetails");
            _PayerAdvancePaymentDocumentDetails = new PayerAdvancePaymentDocumentDetail.ChildPayerAdvancePaymentDocumentDetailCollection(_AccountDocumentDetails, "PayerAdvancePaymentDocumentDetails");
            _GeneralInvoiceDocumentDetails = new GeneralInvoiceDocumentDetail.ChildGeneralInvoiceDocumentDetailCollection(_AccountDocumentDetails, "GeneralInvoiceDocumentDetails");
            _CashOfficeClosingDocumentDetails = new CashOfficeClosingDocumentDetail.ChildCashOfficeClosingDocumentDetailCollection(_AccountDocumentDetails, "CashOfficeClosingDocumentDetails");
            _PayerPaymentDocumentDetails = new PayerPaymentDocumentDetail.ChildPayerPaymentDocumentDetailCollection(_AccountDocumentDetails, "PayerPaymentDocumentDetails");
            _SubCashOfficeReceiptDocumentDetails = new SubCashOfficeReceiptDocDet.ChildSubCashOfficeReceiptDocDetCollection(_AccountDocumentDetails, "SubCashOfficeReceiptDocumentDetails");
            _GeneralReceiptDocumentDetails = new GeneralReceiptDocumentDetail.ChildGeneralReceiptDocumentDetailCollection(_AccountDocumentDetails, "GeneralReceiptDocumentDetails");
        }

        virtual protected void CreateAccountDocumentDetailsCollection()
        {
            _AccountDocumentDetails = new AccountDocumentDetail.ChildAccountDocumentDetailCollection(this, new Guid("896ee883-ebcb-4b96-b524-25c0814de06b"));
            CreateAccountDocumentDetailsCollectionViews();
            ((ITTChildObjectCollection)_AccountDocumentDetails).GetChildren();
        }

        protected AccountDocumentDetail.ChildAccountDocumentDetailCollection _AccountDocumentDetails = null;
    /// <summary>
    /// Child collection for Finansal Döküman Gruplarıyla ilişki
    /// </summary>
        public AccountDocumentDetail.ChildAccountDocumentDetailCollection AccountDocumentDetails
        {
            get
            {
                if (_AccountDocumentDetails == null)
                    CreateAccountDocumentDetailsCollection();
                return _AccountDocumentDetails;
            }
        }

        private ReceiptDocumentDetail.ChildReceiptDocumentDetailCollection _ReceiptDocumentDetails = null;
        public ReceiptDocumentDetail.ChildReceiptDocumentDetailCollection ReceiptDocumentDetails
        {
            get
            {
                if (_AccountDocumentDetails == null)
                    CreateAccountDocumentDetailsCollection();
                return _ReceiptDocumentDetails;
            }            
        }

        private AdvanceBackDocumentDetail.ChildAdvanceBackDocumentDetailCollection _AdvanceBackDocumentDetails = null;
        public AdvanceBackDocumentDetail.ChildAdvanceBackDocumentDetailCollection AdvanceBackDocumentDetails
        {
            get
            {
                if (_AccountDocumentDetails == null)
                    CreateAccountDocumentDetailsCollection();
                return _AdvanceBackDocumentDetails;
            }            
        }

        private AdvanceDocumentDetail.ChildAdvanceDocumentDetailCollection _AdvanceDocumentDetails = null;
        public AdvanceDocumentDetail.ChildAdvanceDocumentDetailCollection AdvanceDocumentDetails
        {
            get
            {
                if (_AccountDocumentDetails == null)
                    CreateAccountDocumentDetailsCollection();
                return _AdvanceDocumentDetails;
            }            
        }

        private CashOfficeReceiptDocumentDetail.ChildCashOfficeReceiptDocumentDetailCollection _CashOfficeReceiptDocumentDetails = null;
        public CashOfficeReceiptDocumentDetail.ChildCashOfficeReceiptDocumentDetailCollection CashOfficeReceiptDocumentDetails
        {
            get
            {
                if (_AccountDocumentDetails == null)
                    CreateAccountDocumentDetailsCollection();
                return _CashOfficeReceiptDocumentDetails;
            }            
        }

        private DebenturePaymentDocumentDetail.ChildDebenturePaymentDocumentDetailCollection _DebenturePaymentDocumentDetails = null;
        public DebenturePaymentDocumentDetail.ChildDebenturePaymentDocumentDetailCollection DebenturePaymentDocumentDetails
        {
            get
            {
                if (_AccountDocumentDetails == null)
                    CreateAccountDocumentDetailsCollection();
                return _DebenturePaymentDocumentDetails;
            }            
        }

        private ReceiptBackDocumentDetail.ChildReceiptBackDocumentDetailCollection _ReceiptBackDocumentDetails = null;
        public ReceiptBackDocumentDetail.ChildReceiptBackDocumentDetailCollection ReceiptBackDocumentDetails
        {
            get
            {
                if (_AccountDocumentDetails == null)
                    CreateAccountDocumentDetailsCollection();
                return _ReceiptBackDocumentDetails;
            }            
        }

        private PatientInvoiceDocumentDetail.ChildPatientInvoiceDocumentDetailCollection _PatientInvoiceDocumentDetails = null;
        public PatientInvoiceDocumentDetail.ChildPatientInvoiceDocumentDetailCollection PatientInvoiceDocumentDetails
        {
            get
            {
                if (_AccountDocumentDetails == null)
                    CreateAccountDocumentDetailsCollection();
                return _PatientInvoiceDocumentDetails;
            }            
        }

        private CollectedInvoiceDocumentDetail.ChildCollectedInvoiceDocumentDetailCollection _CollectedInvoiceDocumentDetails = null;
        public CollectedInvoiceDocumentDetail.ChildCollectedInvoiceDocumentDetailCollection CollectedInvoiceDocumentDetails
        {
            get
            {
                if (_AccountDocumentDetails == null)
                    CreateAccountDocumentDetailsCollection();
                return _CollectedInvoiceDocumentDetails;
            }            
        }

        private MainCashOfficeBackDocumentDetail.ChildMainCashOfficeBackDocumentDetailCollection _MainCashOfficeBackDocumentDetails = null;
        public MainCashOfficeBackDocumentDetail.ChildMainCashOfficeBackDocumentDetailCollection MainCashOfficeBackDocumentDetails
        {
            get
            {
                if (_AccountDocumentDetails == null)
                    CreateAccountDocumentDetailsCollection();
                return _MainCashOfficeBackDocumentDetails;
            }            
        }

        private PayerAdvancePaymentDocumentDetail.ChildPayerAdvancePaymentDocumentDetailCollection _PayerAdvancePaymentDocumentDetails = null;
        public PayerAdvancePaymentDocumentDetail.ChildPayerAdvancePaymentDocumentDetailCollection PayerAdvancePaymentDocumentDetails
        {
            get
            {
                if (_AccountDocumentDetails == null)
                    CreateAccountDocumentDetailsCollection();
                return _PayerAdvancePaymentDocumentDetails;
            }            
        }

        private GeneralInvoiceDocumentDetail.ChildGeneralInvoiceDocumentDetailCollection _GeneralInvoiceDocumentDetails = null;
        public GeneralInvoiceDocumentDetail.ChildGeneralInvoiceDocumentDetailCollection GeneralInvoiceDocumentDetails
        {
            get
            {
                if (_AccountDocumentDetails == null)
                    CreateAccountDocumentDetailsCollection();
                return _GeneralInvoiceDocumentDetails;
            }            
        }

        private CashOfficeClosingDocumentDetail.ChildCashOfficeClosingDocumentDetailCollection _CashOfficeClosingDocumentDetails = null;
        public CashOfficeClosingDocumentDetail.ChildCashOfficeClosingDocumentDetailCollection CashOfficeClosingDocumentDetails
        {
            get
            {
                if (_AccountDocumentDetails == null)
                    CreateAccountDocumentDetailsCollection();
                return _CashOfficeClosingDocumentDetails;
            }            
        }

        private PayerPaymentDocumentDetail.ChildPayerPaymentDocumentDetailCollection _PayerPaymentDocumentDetails = null;
        public PayerPaymentDocumentDetail.ChildPayerPaymentDocumentDetailCollection PayerPaymentDocumentDetails
        {
            get
            {
                if (_AccountDocumentDetails == null)
                    CreateAccountDocumentDetailsCollection();
                return _PayerPaymentDocumentDetails;
            }            
        }

        private SubCashOfficeReceiptDocDet.ChildSubCashOfficeReceiptDocDetCollection _SubCashOfficeReceiptDocumentDetails = null;
        public SubCashOfficeReceiptDocDet.ChildSubCashOfficeReceiptDocDetCollection SubCashOfficeReceiptDocumentDetails
        {
            get
            {
                if (_AccountDocumentDetails == null)
                    CreateAccountDocumentDetailsCollection();
                return _SubCashOfficeReceiptDocumentDetails;
            }            
        }

        private GeneralReceiptDocumentDetail.ChildGeneralReceiptDocumentDetailCollection _GeneralReceiptDocumentDetails = null;
        public GeneralReceiptDocumentDetail.ChildGeneralReceiptDocumentDetailCollection GeneralReceiptDocumentDetails
        {
            get
            {
                if (_AccountDocumentDetails == null)
                    CreateAccountDocumentDetailsCollection();
                return _GeneralReceiptDocumentDetails;
            }            
        }

        protected AccountDocumentGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AccountDocumentGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AccountDocumentGroup(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AccountDocumentGroup(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AccountDocumentGroup(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ACCOUNTDOCUMENTGROUP", dataRow) { }
        protected AccountDocumentGroup(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ACCOUNTDOCUMENTGROUP", dataRow, isImported) { }
        public AccountDocumentGroup(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AccountDocumentGroup(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AccountDocumentGroup() : base() { }

    }
}