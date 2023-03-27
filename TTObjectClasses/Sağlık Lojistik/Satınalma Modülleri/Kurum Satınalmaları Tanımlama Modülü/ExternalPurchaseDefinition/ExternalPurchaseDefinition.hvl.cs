
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ExternalPurchaseDefinition")] 

    /// <summary>
    /// Kurum Satınalmaları Tanımlama Modülü
    /// </summary>
    public  partial class ExternalPurchaseDefinition : TTDefinitionSet
    {
        public class ExternalPurchaseDefinitionList : TTObjectCollection<ExternalPurchaseDefinition> { }
                    
        public class ChildExternalPurchaseDefinitionCollection : TTObject.TTChildObjectCollection<ExternalPurchaseDefinition>
        {
            public ChildExternalPurchaseDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildExternalPurchaseDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class ExternalPurchaseDefFormNQL_Class : TTReportNqlObject 
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

            public DateTime? PurchaseDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PURCHASEDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXTERNALPURCHASEDEFINITION"].AllPropertyDefs["PURCHASEDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string PurchasedBy
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PURCHASEDBY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXTERNALPURCHASEDEFINITION"].AllPropertyDefs["PURCHASEDBY"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public BigCurrency? UnitPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXTERNALPURCHASEDEFINITION"].AllPropertyDefs["UNITPRICE"].DataType;
                    return (BigCurrency?)dataType.ConvertValue(val);
                }
            }

            public Currency? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["EXTERNALPURCHASEDEFINITION"].AllPropertyDefs["AMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public Guid? Objectid1
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID1"]);
                }
            }

            public string Purchaseitemdef
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PURCHASEITEMDEF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEITEMDEF"].AllPropertyDefs["ITEMNAME"].DataType;
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

            public ExternalPurchaseDefFormNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public ExternalPurchaseDefFormNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected ExternalPurchaseDefFormNQL_Class() : base() { }
        }

        public static BindingList<ExternalPurchaseDefinition.ExternalPurchaseDefFormNQL_Class> ExternalPurchaseDefFormNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EXTERNALPURCHASEDEFINITION"].QueryDefs["ExternalPurchaseDefFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ExternalPurchaseDefinition.ExternalPurchaseDefFormNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ExternalPurchaseDefinition.ExternalPurchaseDefFormNQL_Class> ExternalPurchaseDefFormNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EXTERNALPURCHASEDEFINITION"].QueryDefs["ExternalPurchaseDefFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ExternalPurchaseDefinition.ExternalPurchaseDefFormNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ExternalPurchaseDefinition> GetExternalPurchases(TTObjectContext objectContext, string PURCHASEITEMDEF)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["EXTERNALPURCHASEDEFINITION"].QueryDefs["GetExternalPurchases"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PURCHASEITEMDEF", PURCHASEITEMDEF);

            return ((ITTQuery)objectContext).QueryObjects<ExternalPurchaseDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Alım Tarihi
    /// </summary>
        public DateTime? PurchaseDate
        {
            get { return (DateTime?)this["PURCHASEDATE"]; }
            set { this["PURCHASEDATE"] = value; }
        }

    /// <summary>
    /// Alımı Yapan Kurum
    /// </summary>
        public string PurchasedBy
        {
            get { return (string)this["PURCHASEDBY"]; }
            set { this["PURCHASEDBY"] = value; }
        }

    /// <summary>
    /// Alım Fiyatı
    /// </summary>
        public BigCurrency? UnitPrice
        {
            get { return (BigCurrency?)this["UNITPRICE"]; }
            set { this["UNITPRICE"] = value; }
        }

    /// <summary>
    /// Miktar
    /// </summary>
        public Currency? Amount
        {
            get { return (Currency?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

        public Supplier Supplier
        {
            get { return (Supplier)((ITTObject)this).GetParent("SUPPLIER"); }
            set { this["SUPPLIER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public PurchaseItemDef PurchaseItemDef
        {
            get { return (PurchaseItemDef)((ITTObject)this).GetParent("PURCHASEITEMDEF"); }
            set { this["PURCHASEITEMDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ExternalPurchaseDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ExternalPurchaseDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ExternalPurchaseDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ExternalPurchaseDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ExternalPurchaseDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "EXTERNALPURCHASEDEFINITION", dataRow) { }
        protected ExternalPurchaseDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "EXTERNALPURCHASEDEFINITION", dataRow, isImported) { }
        public ExternalPurchaseDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ExternalPurchaseDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ExternalPurchaseDefinition() : base() { }

    }
}