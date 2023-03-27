
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResObservationUnit")] 

    /// <summary>
    /// Tetkik Birimi
    /// </summary>
    public  partial class ResObservationUnit : ResSection
    {
        public class ResObservationUnitList : TTObjectCollection<ResObservationUnit> { }
                    
        public class ChildResObservationUnitCollection : TTObject.TTChildObjectCollection<ResObservationUnit>
        {
            public ChildResObservationUnitCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResObservationUnitCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetObservationUnit_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Qref
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QREF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESOBSERVATIONUNIT"].AllPropertyDefs["QREF"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESOBSERVATIONUNIT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetObservationUnit_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetObservationUnit_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetObservationUnit_Class() : base() { }
        }

        [Serializable] 

        public partial class GetObservationUnitNql_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Qref
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QREF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESOBSERVATIONUNIT"].AllPropertyDefs["QREF"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESOBSERVATIONUNIT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetObservationUnitNql_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetObservationUnitNql_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetObservationUnitNql_Class() : base() { }
        }

        [Serializable] 

        public partial class OLAP_ResObservationUnit_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESOBSERVATIONUNIT"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESOBSERVATIONUNIT"].AllPropertyDefs["NAME"].DataType;
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

            public Guid? Department
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DEPARTMENT"]);
                }
            }

            public Guid? ObservationDepartment
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBSERVATIONDEPARTMENT"]);
                }
            }

            public OLAP_ResObservationUnit_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_ResObservationUnit_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_ResObservationUnit_Class() : base() { }
        }

        [Serializable] 

        public partial class GetAllObservationUnit_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Qref
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QREF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESOBSERVATIONUNIT"].AllPropertyDefs["QREF"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESOBSERVATIONUNIT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetAllObservationUnit_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAllObservationUnit_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAllObservationUnit_Class() : base() { }
        }

        public static BindingList<ResObservationUnit.GetObservationUnit_Class> GetObservationUnit(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESOBSERVATIONUNIT"].QueryDefs["GetObservationUnit"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResObservationUnit.GetObservationUnit_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResObservationUnit.GetObservationUnit_Class> GetObservationUnit(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESOBSERVATIONUNIT"].QueryDefs["GetObservationUnit"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResObservationUnit.GetObservationUnit_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResObservationUnit.GetObservationUnitNql_Class> GetObservationUnitNql(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESOBSERVATIONUNIT"].QueryDefs["GetObservationUnitNql"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResObservationUnit.GetObservationUnitNql_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResObservationUnit.GetObservationUnitNql_Class> GetObservationUnitNql(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESOBSERVATIONUNIT"].QueryDefs["GetObservationUnitNql"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResObservationUnit.GetObservationUnitNql_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResObservationUnit.OLAP_ResObservationUnit_Class> OLAP_ResObservationUnit(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESOBSERVATIONUNIT"].QueryDefs["OLAP_ResObservationUnit"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResObservationUnit.OLAP_ResObservationUnit_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResObservationUnit.OLAP_ResObservationUnit_Class> OLAP_ResObservationUnit(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESOBSERVATIONUNIT"].QueryDefs["OLAP_ResObservationUnit"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResObservationUnit.OLAP_ResObservationUnit_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ResObservationUnit.GetAllObservationUnit_Class> GetAllObservationUnit(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESOBSERVATIONUNIT"].QueryDefs["GetAllObservationUnit"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResObservationUnit.GetAllObservationUnit_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResObservationUnit.GetAllObservationUnit_Class> GetAllObservationUnit(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESOBSERVATIONUNIT"].QueryDefs["GetAllObservationUnit"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResObservationUnit.GetAllObservationUnit_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Dış tetkik birimi olduğunu belirler
    /// </summary>
        public bool? IsExternalObservationUnit
        {
            get { return (bool?)this["ISEXTERNALOBSERVATIONUNIT"]; }
            set { this["ISEXTERNALOBSERVATIONUNIT"] = value; }
        }

    /// <summary>
    /// Bölüm
    /// </summary>
        public ResDepartment Department
        {
            get { return (ResDepartment)((ITTObject)this).GetParent("DEPARTMENT"); }
            set { this["DEPARTMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Labaratuvar Bölümü
    /// </summary>
        public ResObservationDepartment ObservationDepartment
        {
            get { return (ResObservationDepartment)((ITTObject)this).GetParent("OBSERVATIONDEPARTMENT"); }
            set { this["OBSERVATIONDEPARTMENT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateEquipmentsCollection()
        {
            _Equipments = new ResEquipment.ChildResEquipmentCollection(this, new Guid("4dfe47ac-593d-40ef-8fb0-27cba2c1a4d9"));
            ((ITTChildObjectCollection)_Equipments).GetChildren();
        }

        protected ResEquipment.ChildResEquipmentCollection _Equipments = null;
    /// <summary>
    /// Child collection for Labaratuvar Birimi
    /// </summary>
        public ResEquipment.ChildResEquipmentCollection Equipments
        {
            get
            {
                if (_Equipments == null)
                    CreateEquipmentsCollection();
                return _Equipments;
            }
        }

        protected ResObservationUnit(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResObservationUnit(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResObservationUnit(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResObservationUnit(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResObservationUnit(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESOBSERVATIONUNIT", dataRow) { }
        protected ResObservationUnit(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESOBSERVATIONUNIT", dataRow, isImported) { }
        public ResObservationUnit(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResObservationUnit(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResObservationUnit() : base() { }

    }
}