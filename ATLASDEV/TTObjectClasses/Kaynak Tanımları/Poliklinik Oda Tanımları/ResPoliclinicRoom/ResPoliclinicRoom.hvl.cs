
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ResPoliclinicRoom")] 

    /// <summary>
    /// Poliklinik Oda Tanımları
    /// </summary>
    public  partial class ResPoliclinicRoom : ResSection
    {
        public class ResPoliclinicRoomList : TTObjectCollection<ResPoliclinicRoom> { }
                    
        public class ChildResPoliclinicRoomCollection : TTObject.TTChildObjectCollection<ResPoliclinicRoom>
        {
            public ChildResPoliclinicRoomCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildResPoliclinicRoomCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPoliclinicRoomDefinition_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESPOLICLINICROOM"].AllPropertyDefs["QREF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESPOLICLINICROOM"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Policlinicname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["POLICLINICNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESPOLICLINIC"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Policlinic
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["POLICLINIC"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESPOLICLINIC"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPoliclinicRoomDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPoliclinicRoomDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPoliclinicRoomDefinition_Class() : base() { }
        }

        public static BindingList<ResPoliclinicRoom.GetPoliclinicRoomDefinition_Class> GetPoliclinicRoomDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESPOLICLINICROOM"].QueryDefs["GetPoliclinicRoomDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResPoliclinicRoom.GetPoliclinicRoomDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ResPoliclinicRoom.GetPoliclinicRoomDefinition_Class> GetPoliclinicRoomDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RESPOLICLINICROOM"].QueryDefs["GetPoliclinicRoomDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ResPoliclinicRoom.GetPoliclinicRoomDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public ResPoliclinic Policlinic
        {
            get { return (ResPoliclinic)((ITTObject)this).GetParent("POLICLINIC"); }
            set { this["POLICLINIC"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected ResPoliclinicRoom(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ResPoliclinicRoom(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ResPoliclinicRoom(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ResPoliclinicRoom(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ResPoliclinicRoom(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RESPOLICLINICROOM", dataRow) { }
        protected ResPoliclinicRoom(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RESPOLICLINICROOM", dataRow, isImported) { }
        public ResPoliclinicRoom(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ResPoliclinicRoom(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ResPoliclinicRoom() : base() { }

    }
}