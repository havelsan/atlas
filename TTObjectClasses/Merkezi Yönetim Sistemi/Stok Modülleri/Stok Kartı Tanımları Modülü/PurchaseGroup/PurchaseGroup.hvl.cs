
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PurchaseGroup")] 

    /// <summary>
    /// İstek Kalemi Tanımı
    /// </summary>
    public  partial class PurchaseGroup : TerminologyManagerDef
    {
        public class PurchaseGroupList : TTObjectCollection<PurchaseGroup> { }
                    
        public class ChildPurchaseGroupCollection : TTObject.TTChildObjectCollection<PurchaseGroup>
        {
            public ChildPurchaseGroupCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPurchaseGroupCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPurchaseGroupList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEGROUP"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEGROUP"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsMaterial
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISMATERIAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASEGROUP"].AllPropertyDefs["ISMATERIAL"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetPurchaseGroupList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPurchaseGroupList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPurchaseGroupList_Class() : base() { }
        }

        public static BindingList<PurchaseGroup.GetPurchaseGroupList_Class> GetPurchaseGroupList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEGROUP"].QueryDefs["GetPurchaseGroupList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PurchaseGroup.GetPurchaseGroupList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PurchaseGroup.GetPurchaseGroupList_Class> GetPurchaseGroupList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASEGROUP"].QueryDefs["GetPurchaseGroupList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PurchaseGroup.GetPurchaseGroupList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Malzeme İstek Kalemi
    /// </summary>
        public bool? IsMaterial
        {
            get { return (bool?)this["ISMATERIAL"]; }
            set { this["ISMATERIAL"] = value; }
        }

        protected PurchaseGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PurchaseGroup(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PurchaseGroup(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PurchaseGroup(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PurchaseGroup(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PURCHASEGROUP", dataRow) { }
        protected PurchaseGroup(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PURCHASEGROUP", dataRow, isImported) { }
        public PurchaseGroup(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PurchaseGroup(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PurchaseGroup() : base() { }

    }
}