
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BankAccountDefinition")] 

    /// <summary>
    /// Banka Hesap Tanımı
    /// </summary>
    public  partial class BankAccountDefinition : TTDefinitionSet
    {
        public class BankAccountDefinitionList : TTObjectCollection<BankAccountDefinition> { }
                    
        public class ChildBankAccountDefinitionCollection : TTObject.TTChildObjectCollection<BankAccountDefinition>
        {
            public ChildBankAccountDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBankAccountDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetBankAccountDefinitions_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Bankname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BANKNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BANKDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Branchcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BRANCHCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BANKBRANCHDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Branchname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BRANCHNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BANKBRANCHDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string AccountNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCOUNTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BANKACCOUNTDEFINITION"].AllPropertyDefs["ACCOUNTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string IBAN
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["IBAN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BANKACCOUNTDEFINITION"].AllPropertyDefs["IBAN"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string AccountCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCOUNTCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BANKACCOUNTDEFINITION"].AllPropertyDefs["ACCOUNTCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetBankAccountDefinitions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetBankAccountDefinitions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetBankAccountDefinitions_Class() : base() { }
        }

        public static BindingList<BankAccountDefinition.GetBankAccountDefinitions_Class> GetBankAccountDefinitions(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BANKACCOUNTDEFINITION"].QueryDefs["GetBankAccountDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<BankAccountDefinition.GetBankAccountDefinitions_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<BankAccountDefinition.GetBankAccountDefinitions_Class> GetBankAccountDefinitions(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BANKACCOUNTDEFINITION"].QueryDefs["GetBankAccountDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<BankAccountDefinition.GetBankAccountDefinitions_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<BankAccountDefinition> GetBankAccountToUseInInvoicePayment(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BANKACCOUNTDEFINITION"].QueryDefs["GetBankAccountToUseInInvoicePayment"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<BankAccountDefinition>(queryDef, paramList);
        }

        public string AccountNo_Shadow
        {
            get { return (string)this["ACCOUNTNO_SHADOW"]; }
        }

    /// <summary>
    /// Fatura Tahsilat Ekranında Kullan
    /// </summary>
        public bool? UseInInvoicePayment
        {
            get { return (bool?)this["USEININVOICEPAYMENT"]; }
            set { this["USEININVOICEPAYMENT"] = value; }
        }

    /// <summary>
    /// Muhasebe Kodu
    /// </summary>
        public string AccountCode
        {
            get { return (string)this["ACCOUNTCODE"]; }
            set { this["ACCOUNTCODE"] = value; }
        }

    /// <summary>
    /// Hesap Numarası
    /// </summary>
        public string AccountNo
        {
            get { return (string)this["ACCOUNTNO"]; }
            set { this["ACCOUNTNO"] = value; }
        }

    /// <summary>
    /// IBAN
    /// </summary>
        public string IBAN
        {
            get { return (string)this["IBAN"]; }
            set { this["IBAN"] = value; }
        }

    /// <summary>
    /// Şube Hesap İlişkisi
    /// </summary>
        public BankBranchDefinition BankBranch
        {
            get { return (BankBranchDefinition)((ITTObject)this).GetParent("BANKBRANCH"); }
            set { this["BANKBRANCH"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateBankDecountsCollection()
        {
            _BankDecounts = new BankDecount.ChildBankDecountCollection(this, new Guid("be47da62-ced0-4367-abf9-3fc9d8a43f04"));
            ((ITTChildObjectCollection)_BankDecounts).GetChildren();
        }

        protected BankDecount.ChildBankDecountCollection _BankDecounts = null;
    /// <summary>
    /// Child collection for Banka Hesap No
    /// </summary>
        public BankDecount.ChildBankDecountCollection BankDecounts
        {
            get
            {
                if (_BankDecounts == null)
                    CreateBankDecountsCollection();
                return _BankDecounts;
            }
        }

        protected BankAccountDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BankAccountDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BankAccountDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BankAccountDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BankAccountDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BANKACCOUNTDEFINITION", dataRow) { }
        protected BankAccountDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BANKACCOUNTDEFINITION", dataRow, isImported) { }
        public BankAccountDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BankAccountDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BankAccountDefinition() : base() { }

    }
}