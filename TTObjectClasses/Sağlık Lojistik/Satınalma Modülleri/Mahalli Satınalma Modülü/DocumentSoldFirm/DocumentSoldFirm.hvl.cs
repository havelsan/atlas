
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DocumentSoldFirm")] 

    /// <summary>
    /// İhale İçin Döküman Satın Almış Firmaların ve Satış Bilgilerinin Tutulduğu Sınıftır
    /// </summary>
    public  partial class DocumentSoldFirm : TTObject
    {
        public class DocumentSoldFirmList : TTObjectCollection<DocumentSoldFirm> { }
                    
        public class ChildDocumentSoldFirmCollection : TTObject.TTChildObjectCollection<DocumentSoldFirm>
        {
            public ChildDocumentSoldFirmCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDocumentSoldFirmCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDocumentSoldFirmsByProjectObjectID_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public DateTime? LastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTUPDATE"]);
                    if (val == null)
                        return null;
                    return (DateTime)Convert.ChangeType(val, typeof(DateTime)); 
                }
            }

            public string Purchaser
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PURCHASER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTSOLDFIRM"].AllPropertyDefs["PURCHASER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? OrderNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTSOLDFIRM"].AllPropertyDefs["ORDERNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Annex
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ANNEX"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTSOLDFIRM"].AllPropertyDefs["ANNEX"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? SaleDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SALEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTSOLDFIRM"].AllPropertyDefs["SALEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string SaleReceipNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SALERECEIPNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTSOLDFIRM"].AllPropertyDefs["SALERECEIPNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTSOLDFIRM"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Supplier
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUPPLIER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUPPLIER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Supplieraddress
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUPPLIERADDRESS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUPPLIER"].AllPropertyDefs["ADDRESS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? TenderDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TENDERDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["TENDERDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? SufficiencyDueDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUFFICIENCYDUEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["SUFFICIENCYDUEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Responsibleprocurementunitdef
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESPONSIBLEPROCUREMENTUNITDEF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCUREMENTUNITDEF"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string KIKTenderRegisterNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KIKTENDERREGISTERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["KIKTENDERREGISTERNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ActDefine
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTDEFINE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEPROJECT"].AllPropertyDefs["ACTDEFINE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Purchasetypedefinitionobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PURCHASETYPEDEFINITIONOBJECTID"]);
                }
            }

            public string Sellername
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SELLERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public UserTitleEnum? Sellertitle
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SELLERTITLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["TITLE"].DataType;
                    return (UserTitleEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public GetDocumentSoldFirmsByProjectObjectID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDocumentSoldFirmsByProjectObjectID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDocumentSoldFirmsByProjectObjectID_Class() : base() { }
        }

        public static BindingList<DocumentSoldFirm.GetDocumentSoldFirmsByProjectObjectID_Class> GetDocumentSoldFirmsByProjectObjectID(string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTSOLDFIRM"].QueryDefs["GetDocumentSoldFirmsByProjectObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<DocumentSoldFirm.GetDocumentSoldFirmsByProjectObjectID_Class>(queryDef, paramList, pi);
        }

        public static BindingList<DocumentSoldFirm.GetDocumentSoldFirmsByProjectObjectID_Class> GetDocumentSoldFirmsByProjectObjectID(TTObjectContext objectContext, string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DOCUMENTSOLDFIRM"].QueryDefs["GetDocumentSoldFirmsByProjectObjectID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<DocumentSoldFirm.GetDocumentSoldFirmsByProjectObjectID_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Dökümanı Satın Alan
    /// </summary>
        public string Purchaser
        {
            get { return (string)this["PURCHASER"]; }
            set { this["PURCHASER"] = value; }
        }

    /// <summary>
    /// Sıra No
    /// </summary>
        public long? OrderNo
        {
            get { return (long?)this["ORDERNO"]; }
            set { this["ORDERNO"] = value; }
        }

    /// <summary>
    /// Zeyilname
    /// </summary>
        public string Annex
        {
            get { return (string)this["ANNEX"]; }
            set { this["ANNEX"] = value; }
        }

    /// <summary>
    /// Döküman Satış Tarihi
    /// </summary>
        public DateTime? SaleDate
        {
            get { return (DateTime?)this["SALEDATE"]; }
            set { this["SALEDATE"] = value; }
        }

    /// <summary>
    /// Döküman Bedelinin Tahsilat Belge No
    /// </summary>
        public string SaleReceipNo
        {
            get { return (string)this["SALERECEIPNO"]; }
            set { this["SALERECEIPNO"] = value; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

        public Supplier Supplier
        {
            get { return (Supplier)((ITTObject)this).GetParent("SUPPLIER"); }
            set { this["SUPPLIER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser Seller
        {
            get { return (ResUser)((ITTObject)this).GetParent("SELLER"); }
            set { this["SELLER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PurchaseProject PurchaseProject
        {
            get { return (PurchaseProject)((ITTObject)this).GetParent("PURCHASEPROJECT"); }
            set { this["PURCHASEPROJECT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DocumentSoldFirm(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DocumentSoldFirm(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DocumentSoldFirm(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DocumentSoldFirm(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DocumentSoldFirm(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DOCUMENTSOLDFIRM", dataRow) { }
        protected DocumentSoldFirm(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DOCUMENTSOLDFIRM", dataRow, isImported) { }
        public DocumentSoldFirm(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DocumentSoldFirm(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DocumentSoldFirm() : base() { }

    }
}