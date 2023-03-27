
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResCommandershipSubUnit")] 

    /// <summary>
    /// XXXXXXlık Alt Birimi
    /// </summary>
    public  partial class ResCommandershipSubUnit : ResSection
    {
        public class ResCommandershipSubUnitList : TTObjectCollection<ResCommandershipSubUnit> { }
                    
        public class ChildResCommandershipSubUnitCollection : TTObject.TTChildObjectCollection<ResCommandershipSubUnit>
        {
            public ChildResCommandershipSubUnitCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResCommandershipSubUnitCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class OLAP_ResCommandershipSubUnit_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCOMMANDERSHIPSUBUNIT"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCOMMANDERSHIPSUBUNIT"].AllPropertyDefs["NAME"].DataType;
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

            public Guid? ResCommandership
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["RESCOMMANDERSHIP"]);
                }
            }

            public OLAP_ResCommandershipSubUnit_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_ResCommandershipSubUnit_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_ResCommandershipSubUnit_Class() : base() { }
        }

        public static BindingList<ResCommandershipSubUnit.OLAP_ResCommandershipSubUnit_Class> OLAP_ResCommandershipSubUnit(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESCOMMANDERSHIPSUBUNIT"].QueryDefs["OLAP_ResCommandershipSubUnit"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResCommandershipSubUnit.OLAP_ResCommandershipSubUnit_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResCommandershipSubUnit.OLAP_ResCommandershipSubUnit_Class> OLAP_ResCommandershipSubUnit(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESCOMMANDERSHIPSUBUNIT"].QueryDefs["OLAP_ResCommandershipSubUnit"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResCommandershipSubUnit.OLAP_ResCommandershipSubUnit_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// XXXXXXlık
    /// </summary>
        public ResCommandership ResCommandership
        {
            get { return (ResCommandership)((ITTObject)this).GetParent("RESCOMMANDERSHIP"); }
            set { this["RESCOMMANDERSHIP"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ResCommandershipSubUnit(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResCommandershipSubUnit(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResCommandershipSubUnit(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResCommandershipSubUnit(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResCommandershipSubUnit(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESCOMMANDERSHIPSUBUNIT", dataRow) { }
        protected ResCommandershipSubUnit(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESCOMMANDERSHIPSUBUNIT", dataRow, isImported) { }
        public ResCommandershipSubUnit(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResCommandershipSubUnit(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResCommandershipSubUnit() : base() { }

    }
}