
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResCashOffice")] 

    /// <summary>
    /// Vezne
    /// </summary>
    public  partial class ResCashOffice : ResSection
    {
        public class ResCashOfficeList : TTObjectCollection<ResCashOffice> { }
                    
        public class ChildResCashOfficeCollection : TTObject.TTChildObjectCollection<ResCashOffice>
        {
            public ChildResCashOfficeCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResCashOfficeCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class OLAP_ResCashOffice_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCASHOFFICE"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCASHOFFICE"].AllPropertyDefs["NAME"].DataType;
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

            public Guid? AdministrativeUnit
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["ADMINISTRATIVEUNIT"]);
                }
            }

            public OLAP_ResCashOffice_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_ResCashOffice_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_ResCashOffice_Class() : base() { }
        }

        public static BindingList<ResCashOffice.OLAP_ResCashOffice_Class> OLAP_ResCashOffice(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESCASHOFFICE"].QueryDefs["OLAP_ResCashOffice"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResCashOffice.OLAP_ResCashOffice_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResCashOffice.OLAP_ResCashOffice_Class> OLAP_ResCashOffice(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESCASHOFFICE"].QueryDefs["OLAP_ResCashOffice"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResCashOffice.OLAP_ResCashOffice_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// İdari Birim
    /// </summary>
        public ResAdministrativeUnit AdministrativeUnit
        {
            get { return (ResAdministrativeUnit)((ITTObject)this).GetParent("ADMINISTRATIVEUNIT"); }
            set { this["ADMINISTRATIVEUNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ResCashOffice(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResCashOffice(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResCashOffice(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResCashOffice(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResCashOffice(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESCASHOFFICE", dataRow) { }
        protected ResCashOffice(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESCASHOFFICE", dataRow, isImported) { }
        public ResCashOffice(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResCashOffice(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResCashOffice() : base() { }

    }
}