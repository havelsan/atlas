
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Height")] 

    public  partial class Height : VitalSign
    {
        public class HeightList : TTObjectCollection<Height> { }
                    
        public class ChildHeightCollection : TTObject.TTChildObjectCollection<Height>
        {
            public ChildHeightCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHeightCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPatientLastHeight_Class : TTReportNqlObject 
        {
            public Object Nqlcolumn
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["NQLCOLUMN"]);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public int? Value
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VALUE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HEIGHT"].AllPropertyDefs["VALUE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public GetPatientLastHeight_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPatientLastHeight_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPatientLastHeight_Class() : base() { }
        }

        public static BindingList<Height.GetPatientLastHeight_Class> GetPatientLastHeight(Guid PATIENT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEIGHT"].QueryDefs["GetPatientLastHeight"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<Height.GetPatientLastHeight_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Height.GetPatientLastHeight_Class> GetPatientLastHeight(TTObjectContext objectContext, Guid PATIENT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HEIGHT"].QueryDefs["GetPatientLastHeight"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<Height.GetPatientLastHeight_Class>(objectContext, queryDef, paramList, pi);
        }

        public int? Value
        {
            get { return (int?)this["VALUE"]; }
            set { this["VALUE"] = value; }
        }

        protected Height(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Height(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Height(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Height(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Height(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HEIGHT", dataRow) { }
        protected Height(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HEIGHT", dataRow, isImported) { }
        public Height(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Height(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Height() : base() { }

    }
}