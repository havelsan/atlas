
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="BaseDrug")] 

    public  partial class BaseDrug : TerminologyManagerDef
    {
        public class BaseDrugList : TTObjectCollection<BaseDrug> { }
                    
        public class ChildBaseDrugCollection : TTObject.TTChildObjectCollection<BaseDrug>
        {
            public ChildBaseDrugCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildBaseDrugCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetBaseDrugList_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASEDRUG"].AllPropertyDefs["VADEMECUMID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["BASEDRUG"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetBaseDrugList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetBaseDrugList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetBaseDrugList_Class() : base() { }
        }

        public static BindingList<BaseDrug.GetBaseDrugList_Class> GetBaseDrugList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEDRUG"].QueryDefs["GetBaseDrugList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<BaseDrug.GetBaseDrugList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<BaseDrug.GetBaseDrugList_Class> GetBaseDrugList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["BASEDRUG"].QueryDefs["GetBaseDrugList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<BaseDrug.GetBaseDrugList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
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

        protected BaseDrug(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected BaseDrug(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected BaseDrug(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected BaseDrug(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected BaseDrug(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "BASEDRUG", dataRow) { }
        protected BaseDrug(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "BASEDRUG", dataRow, isImported) { }
        public BaseDrug(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public BaseDrug(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public BaseDrug() : base() { }

    }
}