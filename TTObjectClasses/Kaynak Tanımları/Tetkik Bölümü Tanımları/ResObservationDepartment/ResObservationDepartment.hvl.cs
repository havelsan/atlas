
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResObservationDepartment")] 

    /// <summary>
    /// Tetkik Bölümü
    /// </summary>
    public  partial class ResObservationDepartment : ResSection
    {
        public class ResObservationDepartmentList : TTObjectCollection<ResObservationDepartment> { }
                    
        public class ChildResObservationDepartmentCollection : TTObject.TTChildObjectCollection<ResObservationDepartment>
        {
            public ChildResObservationDepartmentCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResObservationDepartmentCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class OLAP_ResObservationDepartment_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESOBSERVATIONDEPARTMENT"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESOBSERVATIONDEPARTMENT"].AllPropertyDefs["NAME"].DataType;
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

            public OLAP_ResObservationDepartment_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_ResObservationDepartment_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_ResObservationDepartment_Class() : base() { }
        }

        public static BindingList<ResObservationDepartment.OLAP_ResObservationDepartment_Class> OLAP_ResObservationDepartment(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESOBSERVATIONDEPARTMENT"].QueryDefs["OLAP_ResObservationDepartment"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResObservationDepartment.OLAP_ResObservationDepartment_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResObservationDepartment.OLAP_ResObservationDepartment_Class> OLAP_ResObservationDepartment(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESOBSERVATIONDEPARTMENT"].QueryDefs["OLAP_ResObservationDepartment"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResObservationDepartment.OLAP_ResObservationDepartment_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// XXXXXX
    /// </summary>
        public ResHospital Hospital
        {
            get { return (ResHospital)((ITTObject)this).GetParent("HOSPITAL"); }
            set { this["HOSPITAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateObservationUnitsCollection()
        {
            _ObservationUnits = new ResObservationUnit.ChildResObservationUnitCollection(this, new Guid("60a27c2f-c394-4d88-992e-217ab7fb7f76"));
            ((ITTChildObjectCollection)_ObservationUnits).GetChildren();
        }

        protected ResObservationUnit.ChildResObservationUnitCollection _ObservationUnits = null;
    /// <summary>
    /// Child collection for Labaratuvar Bölümü
    /// </summary>
        public ResObservationUnit.ChildResObservationUnitCollection ObservationUnits
        {
            get
            {
                if (_ObservationUnits == null)
                    CreateObservationUnitsCollection();
                return _ObservationUnits;
            }
        }

        protected ResObservationDepartment(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResObservationDepartment(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResObservationDepartment(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResObservationDepartment(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResObservationDepartment(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESOBSERVATIONDEPARTMENT", dataRow) { }
        protected ResObservationDepartment(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESOBSERVATIONDEPARTMENT", dataRow, isImported) { }
        public ResObservationDepartment(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResObservationDepartment(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResObservationDepartment() : base() { }

    }
}