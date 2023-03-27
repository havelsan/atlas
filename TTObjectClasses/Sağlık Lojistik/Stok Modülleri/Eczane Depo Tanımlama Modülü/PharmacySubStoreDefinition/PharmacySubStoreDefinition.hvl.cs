
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PharmacySubStoreDefinition")] 

    public  partial class PharmacySubStoreDefinition : SubStoreDefinition
    {
        public class PharmacySubStoreDefinitionList : TTObjectCollection<PharmacySubStoreDefinition> { }
                    
        public class ChildPharmacySubStoreDefinitionCollection : TTObject.TTChildObjectCollection<PharmacySubStoreDefinition>
        {
            public ChildPharmacySubStoreDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPharmacySubStoreDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPharmacySubStoreDefinitionList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string QREF
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QREF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHARMACYSUBSTOREDEFINITION"].AllPropertyDefs["QREF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHARMACYSUBSTOREDEFINITION"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHARMACYSUBSTOREDEFINITION"].AllPropertyDefs["STATUS"].DataType;
                    return (OpenCloseEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHARMACYSUBSTOREDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPharmacySubStoreDefinitionList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPharmacySubStoreDefinitionList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPharmacySubStoreDefinitionList_Class() : base() { }
        }

        public static BindingList<PharmacySubStoreDefinition.GetPharmacySubStoreDefinitionList_Class> GetPharmacySubStoreDefinitionList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHARMACYSUBSTOREDEFINITION"].QueryDefs["GetPharmacySubStoreDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PharmacySubStoreDefinition.GetPharmacySubStoreDefinitionList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PharmacySubStoreDefinition.GetPharmacySubStoreDefinitionList_Class> GetPharmacySubStoreDefinitionList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHARMACYSUBSTOREDEFINITION"].QueryDefs["GetPharmacySubStoreDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PharmacySubStoreDefinition.GetPharmacySubStoreDefinitionList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PharmacySubStoreDefinition> GetPharmacySubStore(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHARMACYSUBSTOREDEFINITION"].QueryDefs["GetPharmacySubStore"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<PharmacySubStoreDefinition>(queryDef, paramList);
        }

        protected PharmacySubStoreDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PharmacySubStoreDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PharmacySubStoreDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PharmacySubStoreDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PharmacySubStoreDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PHARMACYSUBSTOREDEFINITION", dataRow) { }
        protected PharmacySubStoreDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PHARMACYSUBSTOREDEFINITION", dataRow, isImported) { }
        public PharmacySubStoreDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PharmacySubStoreDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PharmacySubStoreDefinition() : base() { }

    }
}