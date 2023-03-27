
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SurgeryRobsonDefinition")] 

    /// <summary>
    /// Robson Grubu
    /// </summary>
    public  partial class SurgeryRobsonDefinition : TTDefinitionSet
    {
        public class SurgeryRobsonDefinitionList : TTObjectCollection<SurgeryRobsonDefinition> { }
                    
        public class ChildSurgeryRobsonDefinitionCollection : TTObject.TTChildObjectCollection<SurgeryRobsonDefinition>
        {
            public ChildSurgeryRobsonDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSurgeryRobsonDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class RobsonGroupDefinitionNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public Boolean? IsActive
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISACTIVE"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
                }
            }

            public DateTime? LastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTUPDATE"]);
                    if (val == null)
                        return null;
                    return (DateTime)Convert.ChangeType(val, typeof(DateTime)); 
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SURGERYROBSONDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public RobsonGroupDefinitionNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public RobsonGroupDefinitionNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected RobsonGroupDefinitionNQL_Class() : base() { }
        }

        public static BindingList<SurgeryRobsonDefinition.RobsonGroupDefinitionNQL_Class> RobsonGroupDefinitionNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERYROBSONDEFINITION"].QueryDefs["RobsonGroupDefinitionNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SurgeryRobsonDefinition.RobsonGroupDefinitionNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SurgeryRobsonDefinition.RobsonGroupDefinitionNQL_Class> RobsonGroupDefinitionNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SURGERYROBSONDEFINITION"].QueryDefs["RobsonGroupDefinitionNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SurgeryRobsonDefinition.RobsonGroupDefinitionNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Robson Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        protected SurgeryRobsonDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SurgeryRobsonDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SurgeryRobsonDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SurgeryRobsonDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SurgeryRobsonDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SURGERYROBSONDEFINITION", dataRow) { }
        protected SurgeryRobsonDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SURGERYROBSONDEFINITION", dataRow, isImported) { }
        public SurgeryRobsonDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SurgeryRobsonDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SurgeryRobsonDefinition() : base() { }

    }
}