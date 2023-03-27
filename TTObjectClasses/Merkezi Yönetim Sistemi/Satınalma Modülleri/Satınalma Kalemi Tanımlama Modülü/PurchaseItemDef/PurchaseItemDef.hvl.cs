
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PurchaseItemDef")] 

    /// <summary>
    /// Satınalma Kalemi Tanımlama
    /// </summary>
    public  partial class PurchaseItemDef : TerminologyManagerDef
    {
        public class PurchaseItemDefList : TTObjectCollection<PurchaseItemDef> { }
                    
        public class ChildPurchaseItemDefCollection : TTObject.TTChildObjectCollection<PurchaseItemDef>
        {
            public ChildPurchaseItemDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPurchaseItemDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class PIDefinitionFormNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string ItemName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ITEMNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEITEMDEF"].AllPropertyDefs["ITEMNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Classname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CLASSNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARDCLASS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Typename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TYPENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public PIDefinitionFormNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public PIDefinitionFormNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected PIDefinitionFormNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPurchaseItemDefs_Class : TTReportNqlObject 
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

            public string ItemName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ITEMNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEITEMDEF"].AllPropertyDefs["ITEMNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ItemName_Shadow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ITEMNAME_SHADOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEITEMDEF"].AllPropertyDefs["ITEMNAME_SHADOW"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string TempDistributionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TEMPDISTRIBUTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEITEMDEF"].AllPropertyDefs["TEMPDISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPurchaseItemDefs_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPurchaseItemDefs_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPurchaseItemDefs_Class() : base() { }
        }

        public static BindingList<PurchaseItemDef.PIDefinitionFormNQL_Class> PIDefinitionFormNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEITEMDEF"].QueryDefs["PIDefinitionFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PurchaseItemDef.PIDefinitionFormNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PurchaseItemDef.PIDefinitionFormNQL_Class> PIDefinitionFormNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEITEMDEF"].QueryDefs["PIDefinitionFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PurchaseItemDef.PIDefinitionFormNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PurchaseItemDef> GetPurchaseItemByStockCard(TTObjectContext objectContext, string STOCKCARD)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEITEMDEF"].QueryDefs["GetPurchaseItemByStockCard"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOCKCARD", STOCKCARD);

            return ((ITTQuery)objectContext).QueryObjects<PurchaseItemDef>(queryDef, paramList);
        }

        public static BindingList<PurchaseItemDef> GetPurchaseItemDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEITEMDEF"].QueryDefs["GetPurchaseItemDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<PurchaseItemDef>(queryDef, paramList);
        }

        public static BindingList<PurchaseItemDef.GetPurchaseItemDefs_Class> GetPurchaseItemDefs(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEITEMDEF"].QueryDefs["GetPurchaseItemDefs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PurchaseItemDef.GetPurchaseItemDefs_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PurchaseItemDef.GetPurchaseItemDefs_Class> GetPurchaseItemDefs(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEITEMDEF"].QueryDefs["GetPurchaseItemDefs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PurchaseItemDef.GetPurchaseItemDefs_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Kalem Adı
    /// </summary>
        public string ItemName
        {
            get { return (string)this["ITEMNAME"]; }
            set { this["ITEMNAME"] = value; }
        }

        public string ItemName_Shadow
        {
            get { return (string)this["ITEMNAME_SHADOW"]; }
        }

    /// <summary>
    /// Geçici Ölçü Birimi
    /// </summary>
        public string TempDistributionType
        {
            get { return (string)this["TEMPDISTRIBUTIONTYPE"]; }
            set { this["TEMPDISTRIBUTIONTYPE"] = value; }
        }

        public StockCard StockCard
        {
            get { return (StockCard)((ITTObject)this).GetParent("STOCKCARD"); }
            set { this["STOCKCARD"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public GMDNDefinition GMDNDefinition
        {
            get { return (GMDNDefinition)((ITTObject)this).GetParent("GMDNDEFINITION"); }
            set { this["GMDNDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PurchaseItemDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PurchaseItemDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PurchaseItemDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PurchaseItemDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PurchaseItemDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PURCHASEITEMDEF", dataRow) { }
        protected PurchaseItemDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PURCHASEITEMDEF", dataRow, isImported) { }
        public PurchaseItemDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PurchaseItemDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PurchaseItemDef() : base() { }

    }
}