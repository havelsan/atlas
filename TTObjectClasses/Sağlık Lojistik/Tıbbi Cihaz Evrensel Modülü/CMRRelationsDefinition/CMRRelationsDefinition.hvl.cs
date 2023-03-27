
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CMRRelationsDefinition")] 

    /// <summary>
    /// Birlik Üst Kademe Tanımlama
    /// </summary>
    public  partial class CMRRelationsDefinition : TTDefinitionSet
    {
        public class CMRRelationsDefinitionList : TTObjectCollection<CMRRelationsDefinition> { }
                    
        public class ChildCMRRelationsDefinitionCollection : TTObject.TTChildObjectCollection<CMRRelationsDefinition>
        {
            public ChildCMRRelationsDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCMRRelationsDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class CMRRelationsDefFormNQL_Class : TTReportNqlObject 
        {
            public string Repair
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPAIR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STAGEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Calibration
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CALIBRATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STAGEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public CMRRelationsDefFormNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CMRRelationsDefFormNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CMRRelationsDefFormNQL_Class() : base() { }
        }

        public static BindingList<CMRRelationsDefinition.CMRRelationsDefFormNQL_Class> CMRRelationsDefFormNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CMRRELATIONSDEFINITION"].QueryDefs["CMRRelationsDefFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CMRRelationsDefinition.CMRRelationsDefFormNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<CMRRelationsDefinition.CMRRelationsDefFormNQL_Class> CMRRelationsDefFormNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CMRRELATIONSDEFINITION"].QueryDefs["CMRRelationsDefFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CMRRelationsDefinition.CMRRelationsDefFormNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Kademe Mevcut Mu?
    /// </summary>
        public bool? HasStage
        {
            get { return (bool?)this["HASSTAGE"]; }
            set { this["HASSTAGE"] = value; }
        }

        public MilitaryUnit MilitaryUnit
        {
            get { return (MilitaryUnit)((ITTObject)this).GetParent("MILITARYUNIT"); }
            set { this["MILITARYUNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public StageDefinition CalibrationStage
        {
            get { return (StageDefinition)((ITTObject)this).GetParent("CALIBRATIONSTAGE"); }
            set { this["CALIBRATIONSTAGE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public StageDefinition MaintenanceRepairStage
        {
            get { return (StageDefinition)((ITTObject)this).GetParent("MAINTENANCEREPAIRSTAGE"); }
            set { this["MAINTENANCEREPAIRSTAGE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected CMRRelationsDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CMRRelationsDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CMRRelationsDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CMRRelationsDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CMRRelationsDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CMRRELATIONSDEFINITION", dataRow) { }
        protected CMRRelationsDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CMRRELATIONSDEFINITION", dataRow, isImported) { }
        public CMRRelationsDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CMRRelationsDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CMRRelationsDefinition() : base() { }

    }
}