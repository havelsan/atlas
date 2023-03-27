
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RoomStoreDefinition")] 

    /// <summary>
    /// Oda Depo Tanımları
    /// </summary>
    public  partial class RoomStoreDefinition : Store
    {
        public class RoomStoreDefinitionList : TTObjectCollection<RoomStoreDefinition> { }
                    
        public class ChildRoomStoreDefinitionCollection : TTObject.TTChildObjectCollection<RoomStoreDefinition>
        {
            public ChildRoomStoreDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRoomStoreDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetRoomStore_Class : TTReportNqlObject 
        {
            public string QREF
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QREF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ROOMSTOREDEFINITION"].AllPropertyDefs["QREF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ROOMSTOREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public OpenCloseEnum? Status
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ROOMSTOREDEFINITION"].AllPropertyDefs["STATUS"].DataType;
                    return (OpenCloseEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetRoomStore_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetRoomStore_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetRoomStore_Class() : base() { }
        }

        public static BindingList<RoomStoreDefinition.GetRoomStore_Class> GetRoomStore(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ROOMSTOREDEFINITION"].QueryDefs["GetRoomStore"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<RoomStoreDefinition.GetRoomStore_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<RoomStoreDefinition.GetRoomStore_Class> GetRoomStore(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ROOMSTOREDEFINITION"].QueryDefs["GetRoomStore"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<RoomStoreDefinition.GetRoomStore_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<RoomStoreDefinition> GetParentStoreByRoomStore(TTObjectContext objectContext, Guid STOREID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ROOMSTOREDEFINITION"].QueryDefs["GetParentStoreByRoomStore"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STOREID", STOREID);

            return ((ITTQuery)objectContext).QueryObjects<RoomStoreDefinition>(queryDef, paramList);
        }

        public ResUser StoreResponsible
        {
            get { return (ResUser)((ITTObject)this).GetParent("STORERESPONSIBLE"); }
            set { this["STORERESPONSIBLE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public Store ParentStore
        {
            get { return (Store)((ITTObject)this).GetParent("PARENTSTORE"); }
            set { this["PARENTSTORE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected RoomStoreDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RoomStoreDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RoomStoreDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RoomStoreDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RoomStoreDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ROOMSTOREDEFINITION", dataRow) { }
        protected RoomStoreDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ROOMSTOREDEFINITION", dataRow, isImported) { }
        public RoomStoreDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RoomStoreDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RoomStoreDefinition() : base() { }

    }
}