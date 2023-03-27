
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Accountancy")] 

    /// <summary>
    /// Saymanlık Tanımları
    /// </summary>
    public  partial class Accountancy : TerminologyManagerDef, IAccountancy
    {
        public class AccountancyList : TTObjectCollection<Accountancy> { }
                    
        public class ChildAccountancyCollection : TTObject.TTChildObjectCollection<Accountancy>
        {
            public ChildAccountancyCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAccountancyCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetAccountancyList_Class : TTReportNqlObject 
        {
            public string QREF
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QREF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTANCY"].AllPropertyDefs["QREF"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string AccountancyNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCOUNTANCYNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTANCY"].AllPropertyDefs["ACCOUNTANCYNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string AccountancyCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCOUNTANCYCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTANCY"].AllPropertyDefs["ACCOUNTANCYCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTANCY"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Militaryunitname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MILITARYUNITNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYUNIT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetAccountancyList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAccountancyList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAccountancyList_Class() : base() { }
        }

        public static BindingList<Accountancy.GetAccountancyList_Class> GetAccountancyList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTANCY"].QueryDefs["GetAccountancyList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Accountancy.GetAccountancyList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Accountancy.GetAccountancyList_Class> GetAccountancyList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTANCY"].QueryDefs["GetAccountancyList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Accountancy.GetAccountancyList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Accountancy> GetAccountacy(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTANCY"].QueryDefs["GetAccountacy"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<Accountancy>(queryDef, paramList);
        }

        public static BindingList<Accountancy> GetAccountancybyLastupdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTANCY"].QueryDefs["GetAccountancybyLastupdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<Accountancy>(queryDef, paramList);
        }

        public static BindingList<Accountancy> GetAccountancies(TTObjectContext objectContext, IList<Guid> OBJECTIDS)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTANCY"].QueryDefs["GetAccountancies"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTIDS", OBJECTIDS);

            return ((ITTQuery)objectContext).QueryObjects<Accountancy>(queryDef, paramList);
        }

        public static BindingList<Accountancy> GetIsSupportedAccountancies(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTANCY"].QueryDefs["GetIsSupportedAccountancies"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<Accountancy>(queryDef, paramList);
        }

    /// <summary>
    /// Hızlı Referans
    /// </summary>
        public string QREF
        {
            get { return (string)this["QREF"]; }
            set { this["QREF"] = value; }
        }

    /// <summary>
    /// Saymanlık Kodu
    /// </summary>
        public string AccountancyCode
        {
            get { return (string)this["ACCOUNTANCYCODE"]; }
            set { this["ACCOUNTANCYCODE"] = value; }
        }

    /// <summary>
    /// Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Adres
    /// </summary>
        public string Address
        {
            get { return (string)this["ADDRESS"]; }
            set { this["ADDRESS"] = value; }
        }

    /// <summary>
    /// Saymanlık NO
    /// </summary>
        public string AccountancyNO
        {
            get { return (string)this["ACCOUNTANCYNO"]; }
            set { this["ACCOUNTANCYNO"] = value; }
        }

    /// <summary>
    /// Barkodsuz Malzemeye Çıkış Yapabilir
    /// </summary>
        public bool? IsNonBarcode
        {
            get { return (bool?)this["ISNONBARCODE"]; }
            set { this["ISNONBARCODE"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

        public string QREF_Shadow
        {
            get { return (string)this["QREF_SHADOW"]; }
        }

    /// <summary>
    /// Firma GLN No
    /// </summary>
        public string GLNNo
        {
            get { return (string)this["GLNNO"]; }
            set { this["GLNNO"] = value; }
        }

        public MilitaryUnit AccountancyMilitaryUnit
        {
            get { return (MilitaryUnit)((ITTObject)this).GetParent("ACCOUNTANCYMILITARYUNIT"); }
            set { this["ACCOUNTANCYMILITARYUNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// MKYSStore
    /// </summary>
        public UnitStoreGetData UnitStoreGetData
        {
            get { return (UnitStoreGetData)((ITTObject)this).GetParent("UNITSTOREGETDATA"); }
            set { this["UNITSTOREGETDATA"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateTemporaryReceivingGoodsTakeInspectionsCollection()
        {
            _TemporaryReceivingGoodsTakeInspections = new PurchaseExamination.ChildPurchaseExaminationCollection(this, new Guid("55c1c619-5c0a-4aa0-a759-914027cfeebb"));
            ((ITTChildObjectCollection)_TemporaryReceivingGoodsTakeInspections).GetChildren();
        }

        protected PurchaseExamination.ChildPurchaseExaminationCollection _TemporaryReceivingGoodsTakeInspections = null;
        public PurchaseExamination.ChildPurchaseExaminationCollection TemporaryReceivingGoodsTakeInspections
        {
            get
            {
                if (_TemporaryReceivingGoodsTakeInspections == null)
                    CreateTemporaryReceivingGoodsTakeInspectionsCollection();
                return _TemporaryReceivingGoodsTakeInspections;
            }
        }

        virtual protected void CreateMainStoresCollection()
        {
            _MainStores = new MainStoreDefinition.ChildMainStoreDefinitionCollection(this, new Guid("617483d8-eff1-4a52-b625-9133336c6ed9"));
            ((ITTChildObjectCollection)_MainStores).GetChildren();
        }

        protected MainStoreDefinition.ChildMainStoreDefinitionCollection _MainStores = null;
        public MainStoreDefinition.ChildMainStoreDefinitionCollection MainStores
        {
            get
            {
                if (_MainStores == null)
                    CreateMainStoresCollection();
                return _MainStores;
            }
        }

        virtual protected void CreateAccountingTermsCollection()
        {
            _AccountingTerms = new AccountingTerm.ChildAccountingTermCollection(this, new Guid("d6af5798-4170-4cd0-a744-c6d6f129692c"));
            ((ITTChildObjectCollection)_AccountingTerms).GetChildren();
        }

        protected AccountingTerm.ChildAccountingTermCollection _AccountingTerms = null;
        public AccountingTerm.ChildAccountingTermCollection AccountingTerms
        {
            get
            {
                if (_AccountingTerms == null)
                    CreateAccountingTermsCollection();
                return _AccountingTerms;
            }
        }

        protected Accountancy(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Accountancy(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Accountancy(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Accountancy(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Accountancy(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ACCOUNTANCY", dataRow) { }
        protected Accountancy(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ACCOUNTANCY", dataRow, isImported) { }
        public Accountancy(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Accountancy(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Accountancy() : base() { }

    }
}