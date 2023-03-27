
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DrugType")] 

    public  partial class DrugType : TerminologyManagerDef
    {
        public class DrugTypeList : TTObjectCollection<DrugType> { }
                    
        public class ChildDrugTypeCollection : TTObject.TTChildObjectCollection<DrugType>
        {
            public ChildDrugTypeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDrugTypeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDrugTypeList_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGTYPE"].AllPropertyDefs["VADEMECUMID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DRUGTYPE"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetDrugTypeList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDrugTypeList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDrugTypeList_Class() : base() { }
        }

        public static BindingList<DrugType.GetDrugTypeList_Class> GetDrugTypeList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGTYPE"].QueryDefs["GetDrugTypeList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DrugType.GetDrugTypeList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DrugType.GetDrugTypeList_Class> GetDrugTypeList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DRUGTYPE"].QueryDefs["GetDrugTypeList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DrugType.GetDrugTypeList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
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

        protected DrugType(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DrugType(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DrugType(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DrugType(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DrugType(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DRUGTYPE", dataRow) { }
        protected DrugType(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DRUGTYPE", dataRow, isImported) { }
        public DrugType(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DrugType(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DrugType() : base() { }

    }
}