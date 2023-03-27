
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SendToDoctorPerformance")] 

    public  partial class SendToDoctorPerformance : TTObject
    {
        public class SendToDoctorPerformanceList : TTObjectCollection<SendToDoctorPerformance> { }
                    
        public class ChildSendToDoctorPerformanceCollection : TTObject.TTChildObjectCollection<SendToDoctorPerformance>
        {
            public ChildSendToDoctorPerformanceCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSendToDoctorPerformanceCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetByStatus_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? RecordDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RECORDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SENDTODOCTORPERFORMANCE"].AllPropertyDefs["RECORDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? InternalObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["INTERNALOBJECTID"]);
                }
            }

            public string InternalObjectDefName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INTERNALOBJECTDEFNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SENDTODOCTORPERFORMANCE"].AllPropertyDefs["INTERNALOBJECTDEFNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DPInternalObjectStatus? InternalObjectStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["INTERNALOBJECTSTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SENDTODOCTORPERFORMANCE"].AllPropertyDefs["INTERNALOBJECTSTATUS"].DataType;
                    return (DPInternalObjectStatus?)(int)dataType.ConvertValue(val);
                }
            }

            public GetByStatus_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetByStatus_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetByStatus_Class() : base() { }
        }

        public static BindingList<SendToDoctorPerformance.GetByStatus_Class> GetByStatus(DPStatus STATUS, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SENDTODOCTORPERFORMANCE"].QueryDefs["GetByStatus"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STATUS", (int)STATUS);

            return TTReportNqlObject.QueryObjects<SendToDoctorPerformance.GetByStatus_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SendToDoctorPerformance.GetByStatus_Class> GetByStatus(TTObjectContext objectContext, DPStatus STATUS, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SENDTODOCTORPERFORMANCE"].QueryDefs["GetByStatus"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STATUS", (int)STATUS);

            return TTReportNqlObject.QueryObjects<SendToDoctorPerformance.GetByStatus_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public DPStatus? Status
        {
            get { return (DPStatus?)(int?)this["STATUS"]; }
            set { this["STATUS"] = value; }
        }

    /// <summary>
    /// Kayıt Tarihi
    /// </summary>
        public DateTime? RecordDate
        {
            get { return (DateTime?)this["RECORDDATE"]; }
            set { this["RECORDDATE"] = value; }
        }

        public DPInternalObjectStatus? InternalObjectStatus
        {
            get { return (DPInternalObjectStatus?)(int?)this["INTERNALOBJECTSTATUS"]; }
            set { this["INTERNALOBJECTSTATUS"] = value; }
        }

        public Guid? InternalObjectID
        {
            get { return (Guid?)this["INTERNALOBJECTID"]; }
            set { this["INTERNALOBJECTID"] = value; }
        }

        public string InternalObjectDefName
        {
            get { return (string)this["INTERNALOBJECTDEFNAME"]; }
            set { this["INTERNALOBJECTDEFNAME"] = value; }
        }

        protected SendToDoctorPerformance(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SendToDoctorPerformance(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SendToDoctorPerformance(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SendToDoctorPerformance(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SendToDoctorPerformance(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SENDTODOCTORPERFORMANCE", dataRow) { }
        protected SendToDoctorPerformance(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SENDTODOCTORPERFORMANCE", dataRow, isImported) { }
        public SendToDoctorPerformance(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SendToDoctorPerformance(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SendToDoctorPerformance() : base() { }

    }
}