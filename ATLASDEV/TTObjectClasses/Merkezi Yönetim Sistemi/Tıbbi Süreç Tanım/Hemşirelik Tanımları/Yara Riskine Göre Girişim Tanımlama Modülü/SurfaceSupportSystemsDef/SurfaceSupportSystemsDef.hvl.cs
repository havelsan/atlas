
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SurfaceSupportSystemsDef")] 

    public  partial class SurfaceSupportSystemsDef : TerminologyManagerDef
    {
        public class SurfaceSupportSystemsDefList : TTObjectCollection<SurfaceSupportSystemsDef> { }
                    
        public class ChildSurfaceSupportSystemsDefCollection : TTObject.TTChildObjectCollection<SurfaceSupportSystemsDef>
        {
            public ChildSurfaceSupportSystemsDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSurfaceSupportSystemsDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSurfaceSupportSystemDef_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Definition
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DEFINITION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURFACESUPPORTSYSTEMSDEF"].AllPropertyDefs["DEFINITION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? PlusTenRiskChecked
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PLUSTENRISKCHECKED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURFACESUPPORTSYSTEMSDEF"].AllPropertyDefs["PLUSTENRISKCHECKED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? PlusFifteenRiskChecked
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PLUSFIFTEENRISKCHECKED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURFACESUPPORTSYSTEMSDEF"].AllPropertyDefs["PLUSFIFTEENRISKCHECKED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? PlusTwentyRiskChecked
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PLUSTWENTYRISKCHECKED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURFACESUPPORTSYSTEMSDEF"].AllPropertyDefs["PLUSTWENTYRISKCHECKED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetSurfaceSupportSystemDef_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSurfaceSupportSystemDef_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSurfaceSupportSystemDef_Class() : base() { }
        }

        public static BindingList<SurfaceSupportSystemsDef.GetSurfaceSupportSystemDef_Class> GetSurfaceSupportSystemDef(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURFACESUPPORTSYSTEMSDEF"].QueryDefs["GetSurfaceSupportSystemDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SurfaceSupportSystemsDef.GetSurfaceSupportSystemDef_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SurfaceSupportSystemsDef.GetSurfaceSupportSystemDef_Class> GetSurfaceSupportSystemDef(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURFACESUPPORTSYSTEMSDEF"].QueryDefs["GetSurfaceSupportSystemDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SurfaceSupportSystemsDef.GetSurfaceSupportSystemDef_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SurfaceSupportSystemsDef> GetSurfaceSupportSystemDefinition(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURFACESUPPORTSYSTEMSDEF"].QueryDefs["GetSurfaceSupportSystemDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<SurfaceSupportSystemsDef>(queryDef, paramList, injectionSQL);
        }

    /// <summary>
    /// Yüzey Destek Sistemleri Tanımı
    /// </summary>
        public string Definition
        {
            get { return (string)this["DEFINITION"]; }
            set { this["DEFINITION"] = value; }
        }

        public bool? PlusTenRiskChecked
        {
            get { return (bool?)this["PLUSTENRISKCHECKED"]; }
            set { this["PLUSTENRISKCHECKED"] = value; }
        }

        public bool? PlusFifteenRiskChecked
        {
            get { return (bool?)this["PLUSFIFTEENRISKCHECKED"]; }
            set { this["PLUSFIFTEENRISKCHECKED"] = value; }
        }

        public bool? PlusTwentyRiskChecked
        {
            get { return (bool?)this["PLUSTWENTYRISKCHECKED"]; }
            set { this["PLUSTWENTYRISKCHECKED"] = value; }
        }

        protected SurfaceSupportSystemsDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SurfaceSupportSystemsDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SurfaceSupportSystemsDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SurfaceSupportSystemsDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SurfaceSupportSystemsDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SURFACESUPPORTSYSTEMSDEF", dataRow) { }
        protected SurfaceSupportSystemsDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SURFACESUPPORTSYSTEMSDEF", dataRow, isImported) { }
        public SurfaceSupportSystemsDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SurfaceSupportSystemsDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SurfaceSupportSystemsDef() : base() { }

    }
}