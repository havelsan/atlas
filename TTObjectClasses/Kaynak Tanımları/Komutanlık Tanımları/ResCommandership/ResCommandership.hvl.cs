
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResCommandership")] 

    /// <summary>
    /// XXXXXXlık
    /// </summary>
    public  partial class ResCommandership : ResSection
    {
        public class ResCommandershipList : TTObjectCollection<ResCommandership> { }
                    
        public class ChildResCommandershipCollection : TTObject.TTChildObjectCollection<ResCommandership>
        {
            public ChildResCommandershipCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResCommandershipCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class OLAP_ResCommandership_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCOMMANDERSHIP"].AllPropertyDefs["ID"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESCOMMANDERSHIP"].AllPropertyDefs["NAME"].DataType;
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

            public OLAP_ResCommandership_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public OLAP_ResCommandership_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected OLAP_ResCommandership_Class() : base() { }
        }

        public static BindingList<ResCommandership.OLAP_ResCommandership_Class> OLAP_ResCommandership(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESCOMMANDERSHIP"].QueryDefs["OLAP_ResCommandership"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResCommandership.OLAP_ResCommandership_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ResCommandership.OLAP_ResCommandership_Class> OLAP_ResCommandership(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESCOMMANDERSHIP"].QueryDefs["OLAP_ResCommandership"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResCommandership.OLAP_ResCommandership_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// XXXXXX
    /// </summary>
        public ResHospital Hospital
        {
            get { return (ResHospital)((ITTObject)this).GetParent("HOSPITAL"); }
            set { this["HOSPITAL"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateResCommandershipSubUnitsCollection()
        {
            _ResCommandershipSubUnits = new ResCommandershipSubUnit.ChildResCommandershipSubUnitCollection(this, new Guid("821386df-0b27-4eac-9e71-82c4d45c1243"));
            ((ITTChildObjectCollection)_ResCommandershipSubUnits).GetChildren();
        }

        protected ResCommandershipSubUnit.ChildResCommandershipSubUnitCollection _ResCommandershipSubUnits = null;
    /// <summary>
    /// Child collection for XXXXXXlık
    /// </summary>
        public ResCommandershipSubUnit.ChildResCommandershipSubUnitCollection ResCommandershipSubUnits
        {
            get
            {
                if (_ResCommandershipSubUnits == null)
                    CreateResCommandershipSubUnitsCollection();
                return _ResCommandershipSubUnits;
            }
        }

        protected ResCommandership(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResCommandership(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResCommandership(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResCommandership(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResCommandership(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESCOMMANDERSHIP", dataRow) { }
        protected ResCommandership(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESCOMMANDERSHIP", dataRow, isImported) { }
        public ResCommandership(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResCommandership(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResCommandership() : base() { }

    }
}