
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="UnitStoreGetData")] 

    public  partial class UnitStoreGetData : TerminologyManagerDef
    {
        public class UnitStoreGetDataList : TTObjectCollection<UnitStoreGetData> { }
                    
        public class ChildUnitStoreGetDataCollection : TTObject.TTChildObjectCollection<UnitStoreGetData>
        {
            public ChildUnitStoreGetDataCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildUnitStoreGetDataCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetUnitStoreGetDataList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public int? StoreRecordNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STORERECORDNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UNITSTOREGETDATA"].AllPropertyDefs["STORERECORDNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string StoreCode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STORECODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UNITSTOREGETDATA"].AllPropertyDefs["STORECODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string StoreDefinition
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOREDEFINITION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UNITSTOREGETDATA"].AllPropertyDefs["STOREDEFINITION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string IntegrationScope
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INTEGRATIONSCOPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UNITSTOREGETDATA"].AllPropertyDefs["INTEGRATIONSCOPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? UnitRecordNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNITRECORDNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["UNITSTOREGETDATA"].AllPropertyDefs["UNITRECORDNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public GetUnitStoreGetDataList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetUnitStoreGetDataList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetUnitStoreGetDataList_Class() : base() { }
        }

        public static BindingList<UnitStoreGetData.GetUnitStoreGetDataList_Class> GetUnitStoreGetDataList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["UNITSTOREGETDATA"].QueryDefs["GetUnitStoreGetDataList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<UnitStoreGetData.GetUnitStoreGetDataList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<UnitStoreGetData.GetUnitStoreGetDataList_Class> GetUnitStoreGetDataList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["UNITSTOREGETDATA"].QueryDefs["GetUnitStoreGetDataList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<UnitStoreGetData.GetUnitStoreGetDataList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public int? StoreRecordNo
        {
            get { return (int?)this["STORERECORDNO"]; }
            set { this["STORERECORDNO"] = value; }
        }

        public string StoreCode
        {
            get { return (string)this["STORECODE"]; }
            set { this["STORECODE"] = value; }
        }

        public string StoreDefinition
        {
            get { return (string)this["STOREDEFINITION"]; }
            set { this["STOREDEFINITION"] = value; }
        }

        public string IntegrationScope
        {
            get { return (string)this["INTEGRATIONSCOPE"]; }
            set { this["INTEGRATIONSCOPE"] = value; }
        }

        public int? UnitRecordNo
        {
            get { return (int?)this["UNITRECORDNO"]; }
            set { this["UNITRECORDNO"] = value; }
        }

        protected UnitStoreGetData(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected UnitStoreGetData(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected UnitStoreGetData(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected UnitStoreGetData(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected UnitStoreGetData(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "UNITSTOREGETDATA", dataRow) { }
        protected UnitStoreGetData(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "UNITSTOREGETDATA", dataRow, isImported) { }
        public UnitStoreGetData(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public UnitStoreGetData(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public UnitStoreGetData() : base() { }

    }
}