
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PatientBruiseAssessmentTracing")] 

    public  partial class PatientBruiseAssessmentTracing : TerminologyManagerDef
    {
        public class PatientBruiseAssessmentTracingList : TTObjectCollection<PatientBruiseAssessmentTracing> { }
                    
        public class ChildPatientBruiseAssessmentTracingCollection : TTObject.TTChildObjectCollection<PatientBruiseAssessmentTracing>
        {
            public ChildPatientBruiseAssessmentTracingCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPatientBruiseAssessmentTracingCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPatientBruiseAssessmentTracingDef_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTBRUISEASSESSMENTTRACING"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPatientBruiseAssessmentTracingDef_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPatientBruiseAssessmentTracingDef_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPatientBruiseAssessmentTracingDef_Class() : base() { }
        }

        [Serializable] 

        public partial class GetPatientBruiseAssessmentTracing_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENTBRUISEASSESSMENTTRACING"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPatientBruiseAssessmentTracing_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPatientBruiseAssessmentTracing_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPatientBruiseAssessmentTracing_Class() : base() { }
        }

        public static BindingList<PatientBruiseAssessmentTracing.GetPatientBruiseAssessmentTracingDef_Class> GetPatientBruiseAssessmentTracingDef(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTBRUISEASSESSMENTTRACING"].QueryDefs["GetPatientBruiseAssessmentTracingDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PatientBruiseAssessmentTracing.GetPatientBruiseAssessmentTracingDef_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PatientBruiseAssessmentTracing.GetPatientBruiseAssessmentTracingDef_Class> GetPatientBruiseAssessmentTracingDef(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTBRUISEASSESSMENTTRACING"].QueryDefs["GetPatientBruiseAssessmentTracingDef"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PatientBruiseAssessmentTracing.GetPatientBruiseAssessmentTracingDef_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PatientBruiseAssessmentTracing.GetPatientBruiseAssessmentTracing_Class> GetPatientBruiseAssessmentTracing(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTBRUISEASSESSMENTTRACING"].QueryDefs["GetPatientBruiseAssessmentTracing"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PatientBruiseAssessmentTracing.GetPatientBruiseAssessmentTracing_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PatientBruiseAssessmentTracing.GetPatientBruiseAssessmentTracing_Class> GetPatientBruiseAssessmentTracing(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTBRUISEASSESSMENTTRACING"].QueryDefs["GetPatientBruiseAssessmentTracing"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PatientBruiseAssessmentTracing.GetPatientBruiseAssessmentTracing_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PatientBruiseAssessmentTracing> GetPatientBruiseAssmntTrcngByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PATIENTBRUISEASSESSMENTTRACING"].QueryDefs["GetPatientBruiseAssmntTrcngByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<PatientBruiseAssessmentTracing>(queryDef, paramList);
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

    /// <summary>
    /// Yara Bölgesi
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        protected PatientBruiseAssessmentTracing(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PatientBruiseAssessmentTracing(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PatientBruiseAssessmentTracing(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PatientBruiseAssessmentTracing(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PatientBruiseAssessmentTracing(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PATIENTBRUISEASSESSMENTTRACING", dataRow) { }
        protected PatientBruiseAssessmentTracing(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PATIENTBRUISEASSESSMENTTRACING", dataRow, isImported) { }
        public PatientBruiseAssessmentTracing(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PatientBruiseAssessmentTracing(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PatientBruiseAssessmentTracing() : base() { }

    }
}