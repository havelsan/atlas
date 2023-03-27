
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DrugApplicationMethod")] 

    public  partial class DrugApplicationMethod : TerminologyManagerDef
    {
        public class DrugApplicationMethodList : TTObjectCollection<DrugApplicationMethod> { }
                    
        public class ChildDrugApplicationMethodCollection : TTObject.TTChildObjectCollection<DrugApplicationMethod>
        {
            public ChildDrugApplicationMethodCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDrugApplicationMethodCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDrugApplicationMethodList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? VademecumID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VADEMECUMID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGAPPLICATIONMETHOD"].AllPropertyDefs["VADEMECUMID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGAPPLICATIONMETHOD"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetDrugApplicationMethodList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDrugApplicationMethodList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDrugApplicationMethodList_Class() : base() { }
        }

        public static BindingList<DrugApplicationMethod.GetDrugApplicationMethodList_Class> GetDrugApplicationMethodList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGAPPLICATIONMETHOD"].QueryDefs["GetDrugApplicationMethodList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DrugApplicationMethod.GetDrugApplicationMethodList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DrugApplicationMethod.GetDrugApplicationMethodList_Class> GetDrugApplicationMethodList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGAPPLICATIONMETHOD"].QueryDefs["GetDrugApplicationMethodList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DrugApplicationMethod.GetDrugApplicationMethodList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public long? VademecumID
        {
            get { return (long?)this["VADEMECUMID"]; }
            set { this["VADEMECUMID"] = value; }
        }

        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        protected DrugApplicationMethod(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DrugApplicationMethod(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DrugApplicationMethod(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DrugApplicationMethod(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DrugApplicationMethod(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DRUGAPPLICATIONMETHOD", dataRow) { }
        protected DrugApplicationMethod(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DRUGAPPLICATIONMETHOD", dataRow, isImported) { }
        public DrugApplicationMethod(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DrugApplicationMethod(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DrugApplicationMethod() : base() { }

    }
}