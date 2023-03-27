
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResAdministrativeUnit")] 

    /// <summary>
    /// İdari Birim
    /// </summary>
    public  partial class ResAdministrativeUnit : ResSection
    {
        public class ResAdministrativeUnitList : TTObjectCollection<ResAdministrativeUnit> { }
                    
        public class ChildResAdministrativeUnitCollection : TTObject.TTChildObjectCollection<ResAdministrativeUnit>
        {
            public ChildResAdministrativeUnitCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResAdministrativeUnitCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class OLAP_ResAdministrativeUnit_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESADMINISTRATIVEUNIT"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESADMINISTRATIVEUNIT"].AllPropertyDefs["NAME"].DataType;
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

            public OLAP_ResAdministrativeUnit_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_ResAdministrativeUnit_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_ResAdministrativeUnit_Class() : base() { }
        }

        public static BindingList<ResAdministrativeUnit.OLAP_ResAdministrativeUnit_Class> OLAP_ResAdministrativeUnit(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESADMINISTRATIVEUNIT"].QueryDefs["OLAP_ResAdministrativeUnit"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResAdministrativeUnit.OLAP_ResAdministrativeUnit_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResAdministrativeUnit.OLAP_ResAdministrativeUnit_Class> OLAP_ResAdministrativeUnit(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESADMINISTRATIVEUNIT"].QueryDefs["OLAP_ResAdministrativeUnit"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResAdministrativeUnit.OLAP_ResAdministrativeUnit_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// XXXXXX
    /// </summary>
        public ResHospital Hospital
        {
            get { return (ResHospital)((ITTObject)this).GetParent("HOSPITAL"); }
            set { this["HOSPITAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateCashOfficesCollection()
        {
            _CashOffices = new ResCashOffice.ChildResCashOfficeCollection(this, new Guid("6facb166-140e-4e02-9406-18826dda4b9e"));
            ((ITTChildObjectCollection)_CashOffices).GetChildren();
        }

        protected ResCashOffice.ChildResCashOfficeCollection _CashOffices = null;
    /// <summary>
    /// Child collection for İdari Birim
    /// </summary>
        public ResCashOffice.ChildResCashOfficeCollection CashOffices
        {
            get
            {
                if (_CashOffices == null)
                    CreateCashOfficesCollection();
                return _CashOffices;
            }
        }

        protected ResAdministrativeUnit(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResAdministrativeUnit(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResAdministrativeUnit(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResAdministrativeUnit(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResAdministrativeUnit(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESADMINISTRATIVEUNIT", dataRow) { }
        protected ResAdministrativeUnit(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESADMINISTRATIVEUNIT", dataRow, isImported) { }
        public ResAdministrativeUnit(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResAdministrativeUnit(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResAdministrativeUnit() : base() { }

    }
}