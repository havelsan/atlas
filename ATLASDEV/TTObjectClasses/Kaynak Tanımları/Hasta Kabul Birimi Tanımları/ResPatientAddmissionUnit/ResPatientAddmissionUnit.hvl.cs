
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResPatientAddmissionUnit")] 

    /// <summary>
    /// Hasta Kabul Birimi
    /// </summary>
    public  partial class ResPatientAddmissionUnit : ResSection
    {
        public class ResPatientAddmissionUnitList : TTObjectCollection<ResPatientAddmissionUnit> { }
                    
        public class ChildResPatientAddmissionUnitCollection : TTObject.TTChildObjectCollection<ResPatientAddmissionUnit>
        {
            public ChildResPatientAddmissionUnitCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResPatientAddmissionUnitCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class OLAP_ResPatientAddmissionUnit_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESPATIENTADDMISSIONUNIT"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESPATIENTADDMISSIONUNIT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Boolean? Active
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIVE"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
                }
            }

            public Guid? Hospital
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["HOSPITAL"]);
                }
            }

            public OLAP_ResPatientAddmissionUnit_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_ResPatientAddmissionUnit_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_ResPatientAddmissionUnit_Class() : base() { }
        }

        public static BindingList<ResPatientAddmissionUnit.OLAP_ResPatientAddmissionUnit_Class> OLAP_ResPatientAddmissionUnit(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESPATIENTADDMISSIONUNIT"].QueryDefs["OLAP_ResPatientAddmissionUnit"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResPatientAddmissionUnit.OLAP_ResPatientAddmissionUnit_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResPatientAddmissionUnit.OLAP_ResPatientAddmissionUnit_Class> OLAP_ResPatientAddmissionUnit(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESPATIENTADDMISSIONUNIT"].QueryDefs["OLAP_ResPatientAddmissionUnit"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResPatientAddmissionUnit.OLAP_ResPatientAddmissionUnit_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// XXXXXX
    /// </summary>
        public ResHospital Hospital
        {
            get { return (ResHospital)((ITTObject)this).GetParent("HOSPITAL"); }
            set { this["HOSPITAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ResPatientAddmissionUnit(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResPatientAddmissionUnit(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResPatientAddmissionUnit(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResPatientAddmissionUnit(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResPatientAddmissionUnit(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESPATIENTADDMISSIONUNIT", dataRow) { }
        protected ResPatientAddmissionUnit(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESPATIENTADDMISSIONUNIT", dataRow, isImported) { }
        public ResPatientAddmissionUnit(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResPatientAddmissionUnit(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResPatientAddmissionUnit() : base() { }

    }
}