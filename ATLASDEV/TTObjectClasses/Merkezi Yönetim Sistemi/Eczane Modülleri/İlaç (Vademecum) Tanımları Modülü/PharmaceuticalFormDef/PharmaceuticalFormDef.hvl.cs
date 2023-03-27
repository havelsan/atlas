
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PharmaceuticalFormDef")] 

    public  partial class PharmaceuticalFormDef : TerminologyManagerDef
    {
        public class PharmaceuticalFormDefList : TTObjectCollection<PharmaceuticalFormDef> { }
                    
        public class ChildPharmaceuticalFormDefCollection : TTObject.TTChildObjectCollection<PharmaceuticalFormDef>
        {
            public ChildPharmaceuticalFormDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPharmaceuticalFormDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPharmaceuticalFormDefList_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHARMACEUTICALFORMDEF"].AllPropertyDefs["VADEMECUMID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHARMACEUTICALFORMDEF"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPharmaceuticalFormDefList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPharmaceuticalFormDefList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPharmaceuticalFormDefList_Class() : base() { }
        }

        public static BindingList<PharmaceuticalFormDef.GetPharmaceuticalFormDefList_Class> GetPharmaceuticalFormDefList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHARMACEUTICALFORMDEF"].QueryDefs["GetPharmaceuticalFormDefList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PharmaceuticalFormDef.GetPharmaceuticalFormDefList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PharmaceuticalFormDef.GetPharmaceuticalFormDefList_Class> GetPharmaceuticalFormDefList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHARMACEUTICALFORMDEF"].QueryDefs["GetPharmaceuticalFormDefList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PharmaceuticalFormDef.GetPharmaceuticalFormDefList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
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

        public DrugApplicationMethod DrugApplicationMethod
        {
            get { return (DrugApplicationMethod)((ITTObject)this).GetParent("DRUGAPPLICATIONMETHOD"); }
            set { this["DRUGAPPLICATIONMETHOD"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DrugAffectingBodyPart DrugAffectingBodyPart
        {
            get { return (DrugAffectingBodyPart)((ITTObject)this).GetParent("DRUGAFFECTINGBODYPART"); }
            set { this["DRUGAFFECTINGBODYPART"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected PharmaceuticalFormDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PharmaceuticalFormDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PharmaceuticalFormDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PharmaceuticalFormDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PharmaceuticalFormDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PHARMACEUTICALFORMDEF", dataRow) { }
        protected PharmaceuticalFormDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PHARMACEUTICALFORMDEF", dataRow, isImported) { }
        public PharmaceuticalFormDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PharmaceuticalFormDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PharmaceuticalFormDef() : base() { }

    }
}