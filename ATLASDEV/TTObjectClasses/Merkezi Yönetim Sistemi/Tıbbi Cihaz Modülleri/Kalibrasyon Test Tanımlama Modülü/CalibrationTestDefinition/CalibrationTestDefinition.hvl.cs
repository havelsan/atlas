
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CalibrationTestDefinition")] 

    public  partial class CalibrationTestDefinition : TerminologyManagerDef
    {
        public class CalibrationTestDefinitionList : TTObjectCollection<CalibrationTestDefinition> { }
                    
        public class ChildCalibrationTestDefinitionCollection : TTObject.TTChildObjectCollection<CalibrationTestDefinition>
        {
            public ChildCalibrationTestDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCalibrationTestDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class CalibrationTestDefinitionFormNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string ProcedureName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDURENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATIONTESTDEFINITION"].AllPropertyDefs["PROCEDURENAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ProcedureNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDURENO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CALIBRATIONTESTDEFINITION"].AllPropertyDefs["PROCEDURENO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public CalibrationTestDefinitionFormNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CalibrationTestDefinitionFormNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CalibrationTestDefinitionFormNQL_Class() : base() { }
        }

        public static BindingList<CalibrationTestDefinition.CalibrationTestDefinitionFormNQL_Class> CalibrationTestDefinitionFormNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CALIBRATIONTESTDEFINITION"].QueryDefs["CalibrationTestDefinitionFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CalibrationTestDefinition.CalibrationTestDefinitionFormNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<CalibrationTestDefinition.CalibrationTestDefinitionFormNQL_Class> CalibrationTestDefinitionFormNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CALIBRATIONTESTDEFINITION"].QueryDefs["CalibrationTestDefinitionFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CalibrationTestDefinition.CalibrationTestDefinitionFormNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Revizyon No
    /// </summary>
        public string RevisionNo
        {
            get { return (string)this["REVISIONNO"]; }
            set { this["REVISIONNO"] = value; }
        }

    /// <summary>
    /// Prosedür No
    /// </summary>
        public string ProcedureNo
        {
            get { return (string)this["PROCEDURENO"]; }
            set { this["PROCEDURENO"] = value; }
        }

    /// <summary>
    /// Prosedür Adı
    /// </summary>
        public string ProcedureName
        {
            get { return (string)this["PROCEDURENAME"]; }
            set { this["PROCEDURENAME"] = value; }
        }

    /// <summary>
    /// Uygulanacak Test Sayısı
    /// </summary>
        public long? ApplicableTestCount
        {
            get { return (long?)this["APPLICABLETESTCOUNT"]; }
            set { this["APPLICABLETESTCOUNT"] = value; }
        }

        public string ProcedureNo_Shadow
        {
            get { return (string)this["PROCEDURENO_SHADOW"]; }
        }

        public object Report
        {
            get { return (object)this["REPORT"]; }
            set { this["REPORT"] = value; }
        }

        public string ProcedureName_Shadow
        {
            get { return (string)this["PROCEDURENAME_SHADOW"]; }
        }

    /// <summary>
    /// Onay Tarihi
    /// </summary>
        public DateTime? ApprovalDate
        {
            get { return (DateTime?)this["APPROVALDATE"]; }
            set { this["APPROVALDATE"] = value; }
        }

        protected CalibrationTestDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CalibrationTestDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CalibrationTestDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CalibrationTestDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CalibrationTestDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CALIBRATIONTESTDEFINITION", dataRow) { }
        protected CalibrationTestDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CALIBRATIONTESTDEFINITION", dataRow, isImported) { }
        public CalibrationTestDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CalibrationTestDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CalibrationTestDefinition() : base() { }

    }
}