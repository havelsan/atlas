
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="Weight")] 

    public  partial class Weight : VitalSign
    {
        public class WeightList : TTObjectCollection<Weight> { }
                    
        public class ChildWeightCollection : TTObject.TTChildObjectCollection<Weight>
        {
            public ChildWeightCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildWeightCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPatientLastWeight_Class : TTReportNqlObject 
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

            public double? Value
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["VALUE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["WEIGHT"].AllPropertyDefs["VALUE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public GetPatientLastWeight_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPatientLastWeight_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPatientLastWeight_Class() : base() { }
        }

        public static BindingList<Weight.GetPatientLastWeight_Class> GetPatientLastWeight(Guid PATIENT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["WEIGHT"].QueryDefs["GetPatientLastWeight"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<Weight.GetPatientLastWeight_Class>(queryDef, paramList, pi);
        }

        public static BindingList<Weight.GetPatientLastWeight_Class> GetPatientLastWeight(TTObjectContext objectContext, Guid PATIENT, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["WEIGHT"].QueryDefs["GetPatientLastWeight"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENT", PATIENT);

            return TTReportNqlObject.QueryObjects<Weight.GetPatientLastWeight_Class>(objectContext, queryDef, paramList, pi);
        }

        public double? Value
        {
            get { return (double?)this["VALUE"]; }
            set { this["VALUE"] = value; }
        }

        protected Weight(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected Weight(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected Weight(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected Weight(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected Weight(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "WEIGHT", dataRow) { }
        protected Weight(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "WEIGHT", dataRow, isImported) { }
        public Weight(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public Weight(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public Weight() : base() { }

    }
}