
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="TentativeStoreDefinition")] 

    /// <summary>
    /// Muvakkat Depo
    /// </summary>
    public  partial class TentativeStoreDefinition : Store
    {
        public class TentativeStoreDefinitionList : TTObjectCollection<TentativeStoreDefinition> { }
                    
        public class ChildTentativeStoreDefinitionCollection : TTObject.TTChildObjectCollection<TentativeStoreDefinition>
        {
            public ChildTentativeStoreDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildTentativeStoreDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetTentativeStore_Class : TTReportNqlObject 
        {
            public string QREF
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QREF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TENTATIVESTOREDEFINITION"].AllPropertyDefs["QREF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TENTATIVESTOREDEFINITION"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["TENTATIVESTOREDEFINITION"].AllPropertyDefs["STATUS"].DataType;
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

            public GetTentativeStore_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetTentativeStore_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetTentativeStore_Class() : base() { }
        }

        public static BindingList<TentativeStoreDefinition.GetTentativeStore_Class> GetTentativeStore(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TENTATIVESTOREDEFINITION"].QueryDefs["GetTentativeStore"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<TentativeStoreDefinition.GetTentativeStore_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<TentativeStoreDefinition.GetTentativeStore_Class> GetTentativeStore(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TENTATIVESTOREDEFINITION"].QueryDefs["GetTentativeStore"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<TentativeStoreDefinition.GetTentativeStore_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<TentativeStoreDefinition> GetAllTentativeStores(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["TENTATIVESTOREDEFINITION"].QueryDefs["GetAllTentativeStores"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<TentativeStoreDefinition>(queryDef, paramList);
        }

        protected TentativeStoreDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected TentativeStoreDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected TentativeStoreDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected TentativeStoreDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected TentativeStoreDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "TENTATIVESTOREDEFINITION", dataRow) { }
        protected TentativeStoreDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "TENTATIVESTOREDEFINITION", dataRow, isImported) { }
        public TentativeStoreDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public TentativeStoreDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public TentativeStoreDefinition() : base() { }

    }
}