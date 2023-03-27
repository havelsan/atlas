
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ChildPercentileValues")] 

    public  partial class ChildPercentileValues : TTObject
    {
        public class ChildPercentileValuesList : TTObjectCollection<ChildPercentileValues> { }
                    
        public class ChildChildPercentileValuesCollection : TTObject.TTChildObjectCollection<ChildPercentileValues>
        {
            public ChildChildPercentileValuesCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildChildPercentileValuesCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetChildPercentileValuesNql_Class : TTReportNqlObject 
        {
            public int? Day
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CHILDPERCENTILEVALUES"].AllPropertyDefs["DAY"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string Length
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LENGTH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CHILDPERCENTILEVALUES"].AllPropertyDefs["LENGTH"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string P3
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["P3"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CHILDPERCENTILEVALUES"].AllPropertyDefs["P3"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string P15
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["P15"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CHILDPERCENTILEVALUES"].AllPropertyDefs["P15"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string P50
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["P50"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CHILDPERCENTILEVALUES"].AllPropertyDefs["P50"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string P85
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["P85"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CHILDPERCENTILEVALUES"].AllPropertyDefs["P85"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string P97
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["P97"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CHILDPERCENTILEVALUES"].AllPropertyDefs["P97"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetChildPercentileValuesNql_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetChildPercentileValuesNql_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetChildPercentileValuesNql_Class() : base() { }
        }

        public static BindingList<ChildPercentileValues.GetChildPercentileValuesNql_Class> GetChildPercentileValuesNql(string SEX, string TYPE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CHILDPERCENTILEVALUES"].QueryDefs["GetChildPercentileValuesNql"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SEX", SEX);
            paramList.Add("TYPE", TYPE);

            return TTReportNqlObject.QueryObjects<ChildPercentileValues.GetChildPercentileValuesNql_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ChildPercentileValues.GetChildPercentileValuesNql_Class> GetChildPercentileValuesNql(TTObjectContext objectContext, string SEX, string TYPE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CHILDPERCENTILEVALUES"].QueryDefs["GetChildPercentileValuesNql"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SEX", SEX);
            paramList.Add("TYPE", TYPE);

            return TTReportNqlObject.QueryObjects<ChildPercentileValues.GetChildPercentileValuesNql_Class>(objectContext, queryDef, paramList, pi);
        }

        public int? Day
        {
            get { return (int?)this["DAY"]; }
            set { this["DAY"] = value; }
        }

        public string Type
        {
            get { return (string)this["TYPE"]; }
            set { this["TYPE"] = value; }
        }

        public string Mean
        {
            get { return (string)this["MEAN"]; }
            set { this["MEAN"] = value; }
        }

        public string StandardDeviation
        {
            get { return (string)this["STANDARDDEVIATION"]; }
            set { this["STANDARDDEVIATION"] = value; }
        }

        public string P01
        {
            get { return (string)this["P01"]; }
            set { this["P01"] = value; }
        }

        public string P1
        {
            get { return (string)this["P1"]; }
            set { this["P1"] = value; }
        }

        public string P3
        {
            get { return (string)this["P3"]; }
            set { this["P3"] = value; }
        }

        public string P5
        {
            get { return (string)this["P5"]; }
            set { this["P5"] = value; }
        }

        public string P10
        {
            get { return (string)this["P10"]; }
            set { this["P10"] = value; }
        }

        public string P15
        {
            get { return (string)this["P15"]; }
            set { this["P15"] = value; }
        }

        public string P25
        {
            get { return (string)this["P25"]; }
            set { this["P25"] = value; }
        }

        public string P50
        {
            get { return (string)this["P50"]; }
            set { this["P50"] = value; }
        }

        public string P75
        {
            get { return (string)this["P75"]; }
            set { this["P75"] = value; }
        }

        public string P85
        {
            get { return (string)this["P85"]; }
            set { this["P85"] = value; }
        }

        public string P90
        {
            get { return (string)this["P90"]; }
            set { this["P90"] = value; }
        }

        public string P95
        {
            get { return (string)this["P95"]; }
            set { this["P95"] = value; }
        }

        public string P97
        {
            get { return (string)this["P97"]; }
            set { this["P97"] = value; }
        }

        public string P99
        {
            get { return (string)this["P99"]; }
            set { this["P99"] = value; }
        }

        public string P999
        {
            get { return (string)this["P999"]; }
            set { this["P999"] = value; }
        }

        public string Sex
        {
            get { return (string)this["SEX"]; }
            set { this["SEX"] = value; }
        }

        public string Length
        {
            get { return (string)this["LENGTH"]; }
            set { this["LENGTH"] = value; }
        }

        public bool? ShowInGraph
        {
            get { return (bool?)this["SHOWINGRAPH"]; }
            set { this["SHOWINGRAPH"] = value; }
        }

        protected ChildPercentileValues(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ChildPercentileValues(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ChildPercentileValues(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ChildPercentileValues(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ChildPercentileValues(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CHILDPERCENTILEVALUES", dataRow) { }
        protected ChildPercentileValues(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CHILDPERCENTILEVALUES", dataRow, isImported) { }
        public ChildPercentileValues(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ChildPercentileValues(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ChildPercentileValues() : base() { }

    }
}