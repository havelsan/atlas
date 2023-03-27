
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DependentStoreDefinition")] 

    /// <summary>
    /// Bağlı Birlik Depo Tanımları
    /// </summary>
    public  partial class DependentStoreDefinition : Store
    {
        public class DependentStoreDefinitionList : TTObjectCollection<DependentStoreDefinition> { }
                    
        public class ChildDependentStoreDefinitionCollection : TTObject.TTChildObjectCollection<DependentStoreDefinition>
        {
            public ChildDependentStoreDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDependentStoreDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDependentStoreDefinition_Class : TTReportNqlObject 
        {
            public string QREF
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QREF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEPENDENTSTOREDEFINITION"].AllPropertyDefs["QREF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEPENDENTSTOREDEFINITION"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEPENDENTSTOREDEFINITION"].AllPropertyDefs["STATUS"].DataType;
                    return (OpenCloseEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string GoodsResponsible
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GOODSRESPONSIBLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEPENDENTSTOREDEFINITION"].AllPropertyDefs["GOODSRESPONSIBLE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DEPENDENTSTOREDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
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

            public GetDependentStoreDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDependentStoreDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDependentStoreDefinition_Class() : base() { }
        }

        public static BindingList<DependentStoreDefinition.GetDependentStoreDefinition_Class> GetDependentStoreDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DEPENDENTSTOREDEFINITION"].QueryDefs["GetDependentStoreDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DependentStoreDefinition.GetDependentStoreDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DependentStoreDefinition.GetDependentStoreDefinition_Class> GetDependentStoreDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DEPENDENTSTOREDEFINITION"].QueryDefs["GetDependentStoreDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DependentStoreDefinition.GetDependentStoreDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DependentStoreDefinition> GetDependentStoreDefinitionByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DEPENDENTSTOREDEFINITION"].QueryDefs["GetDependentStoreDefinitionByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<DependentStoreDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Mal Sorumlusu
    /// </summary>
        public string GoodsResponsible
        {
            get { return (string)this["GOODSRESPONSIBLE"]; }
            set { this["GOODSRESPONSIBLE"] = value; }
        }

        public Sites Site
        {
            get { return (Sites)((ITTObject)this).GetParent("SITE"); }
            set { this["SITE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser StoreResponsible
        {
            get { return (ResUser)((ITTObject)this).GetParent("STORERESPONSIBLE"); }
            set { this["STORERESPONSIBLE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected DependentStoreDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DependentStoreDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DependentStoreDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DependentStoreDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DependentStoreDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DEPENDENTSTOREDEFINITION", dataRow) { }
        protected DependentStoreDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DEPENDENTSTOREDEFINITION", dataRow, isImported) { }
        public DependentStoreDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DependentStoreDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DependentStoreDefinition() : base() { }

    }
}