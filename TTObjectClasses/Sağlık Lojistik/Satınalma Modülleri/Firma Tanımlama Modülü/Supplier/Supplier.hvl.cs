
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Supplier")] 

    /// <summary>
    /// Tedarikçi tanımlama modülü için ana sınıftır
    /// </summary>
    public  partial class Supplier : TerminologyManagerDef, ISupplier
    {
        public class SupplierList : TTObjectCollection<Supplier> { }
                    
        public class ChildSupplierCollection : TTObject.TTChildObjectCollection<Supplier>
        {
            public ChildSupplierCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSupplierCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class SupplierDefFormNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUPPLIER"].AllPropertyDefs["CODE"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUPPLIER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Address
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADDRESS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUPPLIER"].AllPropertyDefs["ADDRESS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Telephone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TELEPHONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUPPLIER"].AllPropertyDefs["TELEPHONE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Fax
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FAX"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUPPLIER"].AllPropertyDefs["FAX"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string TaxNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TAXNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUPPLIER"].AllPropertyDefs["TAXNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string SupplierNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUPPLIERNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUPPLIER"].AllPropertyDefs["SUPPLIERNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public SupplierTypeEnum? Type
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUPPLIER"].AllPropertyDefs["TYPE"].DataType;
                    return (SupplierTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public SupplierDefFormNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public SupplierDefFormNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected SupplierDefFormNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetSupplierRecordReportQuery_Class : TTReportNqlObject 
        {
            public long? Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUPPLIER"].AllPropertyDefs["CODE"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUPPLIER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public SupplierTypeEnum? Type
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUPPLIER"].AllPropertyDefs["TYPE"].DataType;
                    return (SupplierTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Address
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADDRESS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUPPLIER"].AllPropertyDefs["ADDRESS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Telephone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TELEPHONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUPPLIER"].AllPropertyDefs["TELEPHONE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Fax
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FAX"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUPPLIER"].AllPropertyDefs["FAX"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Email
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EMAIL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUPPLIER"].AllPropertyDefs["EMAIL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string TaxNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TAXNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUPPLIER"].AllPropertyDefs["TAXNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string RelatedPerson
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RELATEDPERSON"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUPPLIER"].AllPropertyDefs["RELATEDPERSON"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetSupplierRecordReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSupplierRecordReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSupplierRecordReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetSupplierList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUPPLIER"].AllPropertyDefs["CODE"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUPPLIER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string TaxNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TAXNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUPPLIER"].AllPropertyDefs["TAXNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Boolean? IsActive
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISACTIVE"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
                }
            }

            public GetSupplierList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSupplierList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSupplierList_Class() : base() { }
        }

        public static BindingList<Supplier.SupplierDefFormNQL_Class> SupplierDefFormNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUPPLIER"].QueryDefs["SupplierDefFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Supplier.SupplierDefFormNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Supplier.SupplierDefFormNQL_Class> SupplierDefFormNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUPPLIER"].QueryDefs["SupplierDefFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Supplier.SupplierDefFormNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Supplier.GetSupplierRecordReportQuery_Class> GetSupplierRecordReportQuery(SupplierTypeEnum SUPPLIERTYPE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUPPLIER"].QueryDefs["GetSupplierRecordReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUPPLIERTYPE", (int)SUPPLIERTYPE);

            return TTReportNqlObject.QueryObjects<Supplier.GetSupplierRecordReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Supplier.GetSupplierRecordReportQuery_Class> GetSupplierRecordReportQuery(TTObjectContext objectContext, SupplierTypeEnum SUPPLIERTYPE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUPPLIER"].QueryDefs["GetSupplierRecordReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUPPLIERTYPE", (int)SUPPLIERTYPE);

            return TTReportNqlObject.QueryObjects<Supplier.GetSupplierRecordReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<Supplier.GetSupplierList_Class> GetSupplierList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUPPLIER"].QueryDefs["GetSupplierList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Supplier.GetSupplierList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<Supplier.GetSupplierList_Class> GetSupplierList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SUPPLIER"].QueryDefs["GetSupplierList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<Supplier.GetSupplierList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Not
    /// </summary>
        public string Note
        {
            get { return (string)this["NOTE"]; }
            set { this["NOTE"] = value; }
        }

    /// <summary>
    /// Tipi
    /// </summary>
        public SupplierTypeEnum? Type
        {
            get { return (SupplierTypeEnum?)(int?)this["TYPE"]; }
            set { this["TYPE"] = value; }
        }

    /// <summary>
    /// Elektronik Posta
    /// </summary>
        public string Email
        {
            get { return (string)this["EMAIL"]; }
            set { this["EMAIL"] = value; }
        }

    /// <summary>
    /// Adresi
    /// </summary>
        public string Address
        {
            get { return (string)this["ADDRESS"]; }
            set { this["ADDRESS"] = value; }
        }

    /// <summary>
    /// Vergi Dairesi
    /// </summary>
        public string TaxOfficeName
        {
            get { return (string)this["TAXOFFICENAME"]; }
            set { this["TAXOFFICENAME"] = value; }
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
    /// Vergi No
    /// </summary>
        public string TaxNo
        {
            get { return (string)this["TAXNO"]; }
            set { this["TAXNO"] = value; }
        }

    /// <summary>
    /// Faks
    /// </summary>
        public string Fax
        {
            get { return (string)this["FAX"]; }
            set { this["FAX"] = value; }
        }

    /// <summary>
    /// Telefon
    /// </summary>
        public string Telephone
        {
            get { return (string)this["TELEPHONE"]; }
            set { this["TELEPHONE"] = value; }
        }

    /// <summary>
    /// İlgili Kişi
    /// </summary>
        public string RelatedPerson
        {
            get { return (string)this["RELATEDPERSON"]; }
            set { this["RELATEDPERSON"] = value; }
        }

    /// <summary>
    /// Kod
    /// </summary>
        public TTSequence Code
        {
            get { return GetSequence("CODE"); }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

    /// <summary>
    /// Firma GLN No
    /// </summary>
        public string GLNNo
        {
            get { return (string)this["GLNNO"]; }
            set { this["GLNNO"] = value; }
        }

    /// <summary>
    /// Faaliyet Alanı
    /// </summary>
        public ActivityTypeEnum? ActivityType
        {
            get { return (ActivityTypeEnum?)(int?)this["ACTIVITYTYPE"]; }
            set { this["ACTIVITYTYPE"] = value; }
        }

    /// <summary>
    /// Bayi No
    /// </summary>
        public string SupplierNumber
        {
            get { return (string)this["SUPPLIERNUMBER"]; }
            set { this["SUPPLIERNUMBER"] = value; }
        }

    /// <summary>
    /// Firma Tanımlayıcı No
    /// </summary>
        public long? FirmIdentifierNo
        {
            get { return (long?)this["FIRMIDENTIFIERNO"]; }
            set { this["FIRMIDENTIFIERNO"] = value; }
        }

        virtual protected void CreateCashOfficeReceiptDocumentCollection()
        {
            _CashOfficeReceiptDocument = new CashOfficeReceiptDocument.ChildCashOfficeReceiptDocumentCollection(this, new Guid("645d3868-c69f-4250-a193-ebd42370ce31"));
            ((ITTChildObjectCollection)_CashOfficeReceiptDocument).GetChildren();
        }

        protected CashOfficeReceiptDocument.ChildCashOfficeReceiptDocumentCollection _CashOfficeReceiptDocument = null;
        public CashOfficeReceiptDocument.ChildCashOfficeReceiptDocumentCollection CashOfficeReceiptDocument
        {
            get
            {
                if (_CashOfficeReceiptDocument == null)
                    CreateCashOfficeReceiptDocumentCollection();
                return _CashOfficeReceiptDocument;
            }
        }

        protected Supplier(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Supplier(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Supplier(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Supplier(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Supplier(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SUPPLIER", dataRow) { }
        protected Supplier(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SUPPLIER", dataRow, isImported) { }
        public Supplier(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Supplier(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Supplier() : base() { }

    }
}