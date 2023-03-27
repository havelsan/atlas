
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MaintenanceParameterDefinition")] 

    /// <summary>
    /// Bakım Peryodu Tanımlama
    /// </summary>
    public  partial class MaintenanceParameterDefinition : TerminologyManagerDef
    {
        public class MaintenanceParameterDefinitionList : TTObjectCollection<MaintenanceParameterDefinition> { }
                    
        public class ChildMaintenanceParameterDefinitionCollection : TTObject.TTChildObjectCollection<MaintenanceParameterDefinition>
        {
            public ChildMaintenanceParameterDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMaintenanceParameterDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class MaintenanceParameterDefFormNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Parameter
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PARAMETER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEPARAMETERDEFINITION"].AllPropertyDefs["PARAMETER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public MaintenanceParameterDefFormNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public MaintenanceParameterDefFormNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected MaintenanceParameterDefFormNQL_Class() : base() { }
        }

        public static BindingList<MaintenanceParameterDefinition.MaintenanceParameterDefFormNQL_Class> MaintenanceParameterDefFormNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEPARAMETERDEFINITION"].QueryDefs["MaintenanceParameterDefFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MaintenanceParameterDefinition.MaintenanceParameterDefFormNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MaintenanceParameterDefinition.MaintenanceParameterDefFormNQL_Class> MaintenanceParameterDefFormNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEPARAMETERDEFINITION"].QueryDefs["MaintenanceParameterDefFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MaintenanceParameterDefinition.MaintenanceParameterDefFormNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MaintenanceParameterDefinition> GetMaintenanceParbyLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MAINTENANCEPARAMETERDEFINITION"].QueryDefs["GetMaintenanceParbyLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<MaintenanceParameterDefinition>(queryDef, paramList);
        }

        public string Parameter_Shadow
        {
            get { return (string)this["PARAMETER_SHADOW"]; }
        }

    /// <summary>
    /// Kontrol Parametresi
    /// </summary>
        public string Parameter
        {
            get { return (string)this["PARAMETER"]; }
            set { this["PARAMETER"] = value; }
        }

    /// <summary>
    /// Kontrol Listesi
    /// </summary>
        public bool? AllMaintenanceAction
        {
            get { return (bool?)this["ALLMAINTENANCEACTION"]; }
            set { this["ALLMAINTENANCEACTION"] = value; }
        }

    /// <summary>
    /// Cihaz ile İlgili
    /// </summary>
        public bool? AboutWithDevice
        {
            get { return (bool?)this["ABOUTWITHDEVICE"]; }
            set { this["ABOUTWITHDEVICE"] = value; }
        }

        protected MaintenanceParameterDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MaintenanceParameterDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MaintenanceParameterDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MaintenanceParameterDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MaintenanceParameterDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MAINTENANCEPARAMETERDEFINITION", dataRow) { }
        protected MaintenanceParameterDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MAINTENANCEPARAMETERDEFINITION", dataRow, isImported) { }
        public MaintenanceParameterDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MaintenanceParameterDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MaintenanceParameterDefinition() : base() { }

    }
}