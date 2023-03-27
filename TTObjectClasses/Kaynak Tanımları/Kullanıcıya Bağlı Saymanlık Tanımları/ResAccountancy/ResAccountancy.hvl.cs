
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResAccountancy")] 

    /// <summary>
    /// Saymanlık
    /// </summary>
    public  partial class ResAccountancy : ResSection
    {
        public class ResAccountancyList : TTObjectCollection<ResAccountancy> { }
                    
        public class ChildResAccountancyCollection : TTObject.TTChildObjectCollection<ResAccountancy>
        {
            public ChildResAccountancyCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResAccountancyCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class OLAP_ResAccountancy_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESACCOUNTANCY"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESACCOUNTANCY"].AllPropertyDefs["NAME"].DataType;
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

            public OLAP_ResAccountancy_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_ResAccountancy_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_ResAccountancy_Class() : base() { }
        }

        [Serializable] 

        public partial class GetResAccountancyReport_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESACCOUNTANCY"].AllPropertyDefs["QREF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESACCOUNTANCY"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Accountancyname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCOUNTANCYNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ACCOUNTANCY"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetResAccountancyReport_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetResAccountancyReport_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetResAccountancyReport_Class() : base() { }
        }

        public static BindingList<ResAccountancy.OLAP_ResAccountancy_Class> OLAP_ResAccountancy(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESACCOUNTANCY"].QueryDefs["OLAP_ResAccountancy"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResAccountancy.OLAP_ResAccountancy_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResAccountancy.OLAP_ResAccountancy_Class> OLAP_ResAccountancy(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESACCOUNTANCY"].QueryDefs["OLAP_ResAccountancy"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResAccountancy.OLAP_ResAccountancy_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ResAccountancy.GetResAccountancyReport_Class> GetResAccountancyReport(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESACCOUNTANCY"].QueryDefs["GetResAccountancyReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResAccountancy.GetResAccountancyReport_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResAccountancy.GetResAccountancyReport_Class> GetResAccountancyReport(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESACCOUNTANCY"].QueryDefs["GetResAccountancyReport"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResAccountancy.GetResAccountancyReport_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public Accountancy Accountancy
        {
            get { return (Accountancy)((ITTObject)this).GetParent("ACCOUNTANCY"); }
            set { this["ACCOUNTANCY"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// XXXXXX
    /// </summary>
        public ResHospital Hospital
        {
            get { return (ResHospital)((ITTObject)this).GetParent("HOSPITAL"); }
            set { this["HOSPITAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateStockControlSectionsCollection()
        {
            _StockControlSections = new ResStockControlSection.ChildResStockControlSectionCollection(this, new Guid("d64a743c-fa82-43e1-982f-180653f9fec3"));
            ((ITTChildObjectCollection)_StockControlSections).GetChildren();
        }

        protected ResStockControlSection.ChildResStockControlSectionCollection _StockControlSections = null;
        public ResStockControlSection.ChildResStockControlSectionCollection StockControlSections
        {
            get
            {
                if (_StockControlSections == null)
                    CreateStockControlSectionsCollection();
                return _StockControlSections;
            }
        }

        virtual protected void CreateStorageSectionsCollection()
        {
            _StorageSections = new ResStorageSection.ChildResStorageSectionCollection(this, new Guid("36204976-5821-47f1-8d84-3b0112116098"));
            ((ITTChildObjectCollection)_StorageSections).GetChildren();
        }

        protected ResStorageSection.ChildResStorageSectionCollection _StorageSections = null;
        public ResStorageSection.ChildResStorageSectionCollection StorageSections
        {
            get
            {
                if (_StorageSections == null)
                    CreateStorageSectionsCollection();
                return _StorageSections;
            }
        }

        virtual protected void CreateDependentUnitsCollection()
        {
            _DependentUnits = new ResDependentUnit.ChildResDependentUnitCollection(this, new Guid("4a05c7d3-61be-4af1-a241-b71b56d7056a"));
            ((ITTChildObjectCollection)_DependentUnits).GetChildren();
        }

        protected ResDependentUnit.ChildResDependentUnitCollection _DependentUnits = null;
        public ResDependentUnit.ChildResDependentUnitCollection DependentUnits
        {
            get
            {
                if (_DependentUnits == null)
                    CreateDependentUnitsCollection();
                return _DependentUnits;
            }
        }

        protected ResAccountancy(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResAccountancy(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResAccountancy(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResAccountancy(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResAccountancy(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESACCOUNTANCY", dataRow) { }
        protected ResAccountancy(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESACCOUNTANCY", dataRow, isImported) { }
        public ResAccountancy(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResAccountancy(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResAccountancy() : base() { }

    }
}