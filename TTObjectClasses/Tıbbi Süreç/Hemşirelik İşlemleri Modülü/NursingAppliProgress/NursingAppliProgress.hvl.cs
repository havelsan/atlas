
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="NursingAppliProgress")] 

    /// <summary>
    /// Hemşire Güncesi Sekmesi
    /// </summary>
    public  partial class NursingAppliProgress : BaseNursingDataEntry
    {
        public class NursingAppliProgressList : TTObjectCollection<NursingAppliProgress> { }
                    
        public class ChildNursingAppliProgressCollection : TTObject.TTChildObjectCollection<NursingAppliProgress>
        {
            public ChildNursingAppliProgressCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildNursingAppliProgressCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetNursingApplicationProgress_Class : TTReportNqlObject 
        {
            public DateTime? ProgressDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROGRESSDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGAPPLIPROGRESS"].AllPropertyDefs["PROGRESSDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGAPPLIPROGRESS"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetNursingApplicationProgress_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetNursingApplicationProgress_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetNursingApplicationProgress_Class() : base() { }
        }

        [Serializable] 

        public partial class GetNursingApplicationProgressAndUser_Class : TTReportNqlObject 
        {
            public DateTime? ProgressDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROGRESSDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGAPPLIPROGRESS"].AllPropertyDefs["PROGRESSDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGAPPLIPROGRESS"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Username
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetNursingApplicationProgressAndUser_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetNursingApplicationProgressAndUser_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetNursingApplicationProgressAndUser_Class() : base() { }
        }

        [Serializable] 

        public partial class GetNursingAppliProgressByPatient_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? Progressdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROGRESSDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGAPPLIPROGRESS"].AllPropertyDefs["APPLICATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? ApplicationUser
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["APPLICATIONUSER"]);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGAPPLIPROGRESS"].AllPropertyDefs["DESCRIPTION"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Surname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? HandOverNote
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HANDOVERNOTE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["NURSINGAPPLIPROGRESS"].AllPropertyDefs["HANDOVERNOTE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public GetNursingAppliProgressByPatient_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetNursingAppliProgressByPatient_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetNursingAppliProgressByPatient_Class() : base() { }
        }

        new public static class States
        {
            public static Guid Yeni { get { return new Guid("2f6b2d75-fb0e-43c9-a964-af59bb71f8b9"); } }
    /// <summary>
    /// Yanlış veriyi silmek için
    /// </summary>
            public static Guid Cancelled { get { return new Guid("c9a1ec5b-749a-4cff-9a32-d66e3b0d807b"); } }
        }

        public static BindingList<NursingAppliProgress.GetNursingApplicationProgress_Class> GetNursingApplicationProgress(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGAPPLIPROGRESS"].QueryDefs["GetNursingApplicationProgress"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<NursingAppliProgress.GetNursingApplicationProgress_Class>(queryDef, paramList, pi);
        }

        public static BindingList<NursingAppliProgress.GetNursingApplicationProgress_Class> GetNursingApplicationProgress(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGAPPLIPROGRESS"].QueryDefs["GetNursingApplicationProgress"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<NursingAppliProgress.GetNursingApplicationProgress_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<NursingAppliProgress.GetNursingApplicationProgressAndUser_Class> GetNursingApplicationProgressAndUser(Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGAPPLIPROGRESS"].QueryDefs["GetNursingApplicationProgressAndUser"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<NursingAppliProgress.GetNursingApplicationProgressAndUser_Class>(queryDef, paramList, pi);
        }

        public static BindingList<NursingAppliProgress.GetNursingApplicationProgressAndUser_Class> GetNursingApplicationProgressAndUser(TTObjectContext objectContext, Guid TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGAPPLIPROGRESS"].QueryDefs["GetNursingApplicationProgressAndUser"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<NursingAppliProgress.GetNursingApplicationProgressAndUser_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<NursingAppliProgress.GetNursingAppliProgressByPatient_Class> GetNursingAppliProgressByPatient(DateTime StartDate, DateTime EndDate, Guid MasterResource, IList<string> PATIENTS, int PATIENTCONTROL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGAPPLIPROGRESS"].QueryDefs["GetNursingAppliProgressByPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", StartDate);
            paramList.Add("ENDDATE", EndDate);
            paramList.Add("MASTERRESOURCE", MasterResource);
            paramList.Add("PATIENTS", PATIENTS);
            paramList.Add("PATIENTCONTROL", PATIENTCONTROL);

            return TTReportNqlObject.QueryObjects<NursingAppliProgress.GetNursingAppliProgressByPatient_Class>(queryDef, paramList, pi);
        }

        public static BindingList<NursingAppliProgress.GetNursingAppliProgressByPatient_Class> GetNursingAppliProgressByPatient(TTObjectContext objectContext, DateTime StartDate, DateTime EndDate, Guid MasterResource, IList<string> PATIENTS, int PATIENTCONTROL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["NURSINGAPPLIPROGRESS"].QueryDefs["GetNursingAppliProgressByPatient"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", StartDate);
            paramList.Add("ENDDATE", EndDate);
            paramList.Add("MASTERRESOURCE", MasterResource);
            paramList.Add("PATIENTS", PATIENTS);
            paramList.Add("PATIENTCONTROL", PATIENTCONTROL);

            return TTReportNqlObject.QueryObjects<NursingAppliProgress.GetNursingAppliProgressByPatient_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

    /// <summary>
    /// Tarih/Saat
    /// </summary>
        public DateTime? ProgressDate
        {
            get { return (DateTime?)this["PROGRESSDATE"]; }
            set { this["PROGRESSDATE"] = value; }
        }

        public bool? HandOverNote
        {
            get { return (bool?)this["HANDOVERNOTE"]; }
            set { this["HANDOVERNOTE"] = value; }
        }

        protected NursingAppliProgress(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected NursingAppliProgress(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected NursingAppliProgress(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected NursingAppliProgress(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected NursingAppliProgress(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "NURSINGAPPLIPROGRESS", dataRow) { }
        protected NursingAppliProgress(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "NURSINGAPPLIPROGRESS", dataRow, isImported) { }
        public NursingAppliProgress(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public NursingAppliProgress(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public NursingAppliProgress() : base() { }

    }
}