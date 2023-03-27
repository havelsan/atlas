
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AdditionalReport")] 

    /// <summary>
    /// İşlem Raporu
    /// </summary>
    public  partial class AdditionalReport : BaseAdditionalInfo
    {
        public class AdditionalReportList : TTObjectCollection<AdditionalReport> { }
                    
        public class ChildAdditionalReportCollection : TTObject.TTChildObjectCollection<AdditionalReport>
        {
            public ChildAdditionalReportCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAdditionalReportCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetAdditionalReportInfoByPatientID_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public bool? IsCompleted
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISCOMPLETED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ADDITIONALREPORT"].AllPropertyDefs["ISCOMPLETED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? CreationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CREATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ADDITIONALREPORT"].AllPropertyDefs["CREATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OpeningDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OPENINGDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["OPENINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string ProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Procedurecode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDURECODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Procedurename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDURENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Doctorname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCTORNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Baseaddappobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["BASEADDAPPOBJECTID"]);
                }
            }

            public GetAdditionalReportInfoByPatientID_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetAdditionalReportInfoByPatientID_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetAdditionalReportInfoByPatientID_Class() : base() { }
        }

        public static BindingList<AdditionalReport.GetAdditionalReportInfoByPatientID_Class> GetAdditionalReportInfoByPatientID(Guid PATIENTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ADDITIONALREPORT"].QueryDefs["GetAdditionalReportInfoByPatientID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTID", PATIENTID);

            return TTReportNqlObject.QueryObjects<AdditionalReport.GetAdditionalReportInfoByPatientID_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AdditionalReport.GetAdditionalReportInfoByPatientID_Class> GetAdditionalReportInfoByPatientID(TTObjectContext objectContext, Guid PATIENTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ADDITIONALREPORT"].QueryDefs["GetAdditionalReportInfoByPatientID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTID", PATIENTID);

            return TTReportNqlObject.QueryObjects<AdditionalReport.GetAdditionalReportInfoByPatientID_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Tamamlandı
    /// </summary>
        public bool? IsCompleted
        {
            get { return (bool?)this["ISCOMPLETED"]; }
            set { this["ISCOMPLETED"] = value; }
        }

    /// <summary>
    /// Rapor
    /// </summary>
        public object Report
        {
            get { return (object)this["REPORT"]; }
            set { this["REPORT"] = value; }
        }

        protected AdditionalReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AdditionalReport(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AdditionalReport(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AdditionalReport(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AdditionalReport(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ADDITIONALREPORT", dataRow) { }
        protected AdditionalReport(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ADDITIONALREPORT", dataRow, isImported) { }
        public AdditionalReport(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AdditionalReport(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AdditionalReport() : base() { }

    }
}