
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResSterilizationUnit")] 

    /// <summary>
    /// Sterilizasyon Birimi
    /// </summary>
    public  partial class ResSterilizationUnit : ResSection
    {
        public class ResSterilizationUnitList : TTObjectCollection<ResSterilizationUnit> { }
                    
        public class ChildResSterilizationUnitCollection : TTObject.TTChildObjectCollection<ResSterilizationUnit>
        {
            public ChildResSterilizationUnitCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResSterilizationUnitCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetResSterilizationUnit_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSTERILIZATIONUNIT"].AllPropertyDefs["QREF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSTERILIZATIONUNIT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Buildingname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BUILDINGNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESBUILDING"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetResSterilizationUnit_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetResSterilizationUnit_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetResSterilizationUnit_Class() : base() { }
        }

        public static BindingList<ResSterilizationUnit.GetResSterilizationUnit_Class> GetResSterilizationUnit(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESSTERILIZATIONUNIT"].QueryDefs["GetResSterilizationUnit"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResSterilizationUnit.GetResSterilizationUnit_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResSterilizationUnit.GetResSterilizationUnit_Class> GetResSterilizationUnit(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESSTERILIZATIONUNIT"].QueryDefs["GetResSterilizationUnit"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResSterilizationUnit.GetResSterilizationUnit_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResSterilizationUnit> GetAllResSterilizationUnit(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESSTERILIZATIONUNIT"].QueryDefs["GetAllResSterilizationUnit"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ResSterilizationUnit>(queryDef, paramList, injectionSQL);
        }

        public ResBuilding Building
        {
            get { return (ResBuilding)((ITTObject)this).GetParent("BUILDING"); }
            set { this["BUILDING"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateResSterilizationDeviceCollection()
        {
            _ResSterilizationDevice = new ResSterilizationDevice.ChildResSterilizationDeviceCollection(this, new Guid("0406d792-b379-4014-8caa-06cd8b1ac129"));
            ((ITTChildObjectCollection)_ResSterilizationDevice).GetChildren();
        }

        protected ResSterilizationDevice.ChildResSterilizationDeviceCollection _ResSterilizationDevice = null;
        public ResSterilizationDevice.ChildResSterilizationDeviceCollection ResSterilizationDevice
        {
            get
            {
                if (_ResSterilizationDevice == null)
                    CreateResSterilizationDeviceCollection();
                return _ResSterilizationDevice;
            }
        }

        protected ResSterilizationUnit(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResSterilizationUnit(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResSterilizationUnit(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResSterilizationUnit(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResSterilizationUnit(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESSTERILIZATIONUNIT", dataRow) { }
        protected ResSterilizationUnit(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESSTERILIZATIONUNIT", dataRow, isImported) { }
        public ResSterilizationUnit(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResSterilizationUnit(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResSterilizationUnit() : base() { }

    }
}